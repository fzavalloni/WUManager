namespace WUManager.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Management;
    using System.Drawing;
    using System.IO;
    using WUManager.Enums;

    public class OSManager
    {
        private delegate void RowReadnessMethodDelegate(string host, ref DataGridViewRow row, bool checkActiveResource);
        private delegate void RowMethodDelegate(string host, ref DataGridViewRow row);
        private List<DataGridViewRow> listRebootRow;
        private List<DataGridViewRow> listReadinessRow;
        private Font defaultCellStyle;
        private bool remoteOperationsUsesDCOM;

        public OSManager(Font defaultCellStyle, bool remoteOperationsUsesDCOM)
        {
            this.listRebootRow = new List<DataGridViewRow>();
            this.listReadinessRow = new List<DataGridViewRow>();
            this.defaultCellStyle = defaultCellStyle;
            this.remoteOperationsUsesDCOM = remoteOperationsUsesDCOM;
        }

        public void BeginReboot(DataGridViewRow row, string host)
        {
            lock (listRebootRow)
            {
                if (!listRebootRow.Contains(row))
                {
                    DgvUtils.SetRowStyleForeColor(ref row, WUCollums.LastBoot, Color.Black);
                    DgvUtils.SetRowValue(ref row, WUCollums.Status, "OS Preparing");
                    //SetLastBootRowStyleFont(ref row, new Font(defaultCellStyle, FontStyle.Regular));                    

                    listRebootRow.Add(row);

                    RowMethodDelegate de = new RowMethodDelegate(StartReboot);
                    de.BeginInvoke(host, ref row, null, null);
                }
            }
        }

        public void BeginHostReadiness(string host, DataGridViewRow row, bool checkActiveResource)
        {
            lock (listReadinessRow)
            {
                if (!listReadinessRow.Contains(row))
                {
                    listReadinessRow.Add(row);
                    RowReadnessMethodDelegate de = new RowReadnessMethodDelegate(StartHostReadiness);
                    de.BeginInvoke(host, ref row, checkActiveResource, null, null);
                }
            }
        }

        public void EndReadiness(ref DataGridViewRow row)
        {
            lock (listReadinessRow)
            {
                listReadinessRow.Remove(row);
            }
        }

        public void EndReboot(ref DataGridViewRow row)
        {
            lock (listRebootRow)
            {
                listRebootRow.Remove(row);
            }
        }

        public void StartReboot(string host, ref DataGridViewRow row)
        {
            if (remoteOperationsUsesDCOM)
            {
                StartRebootInternalViaDCOM(host, ref row);
            }
            else
            {
                StartRebootInternalViaPsExec(host, ref row);
            }
        }

        private void StartRebootInternalViaDCOM(string host, ref DataGridViewRow row)
        {
            object rebootResult = string.Empty;
            string rebootStatus = string.Empty;
            Color resultColor = Color.Black;

            try
            {
                DgvUtils.SetRowValue(ref row, WUCollums.Status, "OS Connecting");

                ManagementScope scope = GetWmiManagementScope(host);

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                using (ManagementObjectSearcher mos = new ManagementObjectSearcher(scope, query))
                {
                    foreach (ManagementObject mo in mos.Get())
                    {
                        ManagementBaseObject inParams = mo.GetMethodParameters("Win32Shutdown");
                        inParams["Flags"] = "6";
                        inParams["Reserved"] = "0";

                        ManagementBaseObject outParams = mo.InvokeMethod("Win32Shutdown", inParams, null);

                        rebootResult = outParams["returnValue"];

                        if (Convert.ToInt32(rebootResult).Equals(0))
                        {
                            resultColor = Color.Black;
                            rebootStatus = "OS Reboot completed";
                            rebootResult = "";
                            DgvUtils.SetRowValue(ref row, WUCollums.RebootRequired, false);
                        }
                        else
                        {
                            resultColor = Color.Red;
                            rebootStatus = "OS Reboot error";
                            rebootResult = "Error: " + rebootResult;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultColor = Color.Red;
                rebootStatus = "OS Reboot error";
                rebootResult = ex.Message;
            }
            finally
            {
                EndReboot(ref row);

                DgvUtils.SetRowStyleForeColor(ref row, WUCollums.OperationResults, resultColor);
                DgvUtils.SetRowValue(ref row, WUCollums.Status, rebootStatus);
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, rebootResult);
                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, string.Empty);
            }
        }

        private void StartRebootInternalViaPsExec(string host, ref DataGridViewRow row)
        {
            object rebootResult = string.Empty;
            string rebootStatus = string.Empty;
            Color resultColor = Color.Black;

            try
            {
                DgvUtils.SetRowValue(ref row, WUCollums.Status, "OS Connecting");

                StreamReader executionOutput = null;
                bool rebootIsInProgress = false;

                OperSystemUtils operUtils = new OperSystemUtils(remoteOperationsUsesDCOM);
                bool execResult = operUtils.ExecProcessViaPsExec(host, "shutdown.exe", "/r /t 0", out executionOutput);

                if (execResult)
                {
                    string resultContent = executionOutput.ReadToEnd();
                    rebootIsInProgress = (resultContent == null || resultContent.Trim().Length == 0);

                    if (rebootIsInProgress)
                    {
                        resultColor = Color.Black;
                        rebootStatus = "OS Reboot completed";
                        rebootResult = "";
                        DgvUtils.SetRowValue(ref row, WUCollums.RebootRequired, false);
                    }
                    else
                    {
                        resultColor = Color.Red;
                        rebootStatus = "OS Reboot error";
                        rebootResult = "Error: " + resultContent;
                    }
                }
            }
            catch (Exception ex)
            {
                resultColor = Color.Red;
                rebootStatus = "OS Reboot error";
                rebootResult = ex.Message;
            }
            finally
            {
                EndReboot(ref row);

                DgvUtils.SetRowStyleForeColor(ref row, WUCollums.OperationResults, resultColor);
                DgvUtils.SetRowValue(ref row, WUCollums.Status, rebootStatus);
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, rebootResult);
                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, string.Empty);
            }
        }

        public DateTime GetLastBootDateTimeObject(string host, ref DataGridViewRow row)
        {
            if (remoteOperationsUsesDCOM)
            {
                ManagementScope scope = GetWmiManagementScope(host);
                return GetLasBoot(scope);
            }
            else
            {
                /*
                    C:\Windows\system32>wmic path Win32_OperatingSystem get LastBootUpTime
                    LastBootUpTime
                    20200830222819.410301-180                 
                */

                StreamReader executionOutput = null;
                DateTime lastBoot = default(DateTime);

                OperSystemUtils operUtils = new OperSystemUtils(remoteOperationsUsesDCOM);
                bool execResult = operUtils.ExecProcessViaPsExec(host, "wmic.exe", "path Win32_OperatingSystem get LastBootUpTime", out executionOutput);

                if (execResult)
                {
                    string execOutputString = executionOutput.ReadToEnd();
                    lastBoot = ParseCIMDateTime(execOutputString.Replace("LastBootUpTime", "").Trim());
                }

                return lastBoot;
            }
        }

        public void StartHostReadiness(string host, ref DataGridViewRow row, bool hasActiveResources)
        {
            if (remoteOperationsUsesDCOM)
            {
                StartHostReadinessViaDCOM(host, ref row, hasActiveResources);
            }
            else
            {
                StartHostReadinessViaPsExec(host, ref row, hasActiveResources);
            }
        }

        public void StartHostReadinessViaDCOM(string host, ref DataGridViewRow row, bool hasActiveResources)
        {
            DateTime lastBootDate = DateTime.MinValue;
            ServiceHostStatus automaticServicesStatus;

            DgvUtils.SetRowStyleForeColor(ref row, WUCollums.LastBoot, Color.Black);
            DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, string.Empty);
            DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, string.Empty);
            DgvUtils.SetRowValue(ref row, WUCollums.ServicesRunning, string.Empty);
            DgvUtils.SetRowValue(ref row, WUCollums.Cluster, false);

            try
            {
                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, "OS Connecting");
                ManagementScope scope = GetWmiManagementScope(host);

                lastBootDate = GetLasBoot(scope);
                automaticServicesStatus = GetAutomaticServiceStatus(scope);
                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, lastBootDate.ToString("dd/MM/yyyy HH:mm"));
                DgvUtils.SetRowValue(ref row, WUCollums.Cluster, automaticServicesStatus.IsClustered);
                // Added as string to not broke the ordering in the Datagridview
                DgvUtils.SetRowValue(ref row, WUCollums.ServicesRunning, automaticServicesStatus.ServicesRunning.ToString());

                if (hasActiveResources && automaticServicesStatus.IsClustered)
                {
                    DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Executing remote powershell...");
                    string fqdnHostName = $"{host}.{GetFqdnDomain(scope)}";
                    string resultOutput = string.Empty;
                    int activeResourcesCount = 0;

                    using (PsManager ps = new PsManager(fqdnHostName))
                    {
                        activeResourcesCount = ps.GetActiveClusterResources().Count;
                        resultOutput = $"Clustered resources qty: [{activeResourcesCount}]";
                        if (activeResourcesCount != 0)
                        {
                            resultOutput = $"{resultOutput} - Resource Names: [{string.Join(", ", ps.GetActiveClusterResources().ToArray())}]";
                        }

                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, resultOutput);
                    }
                }
            }
            catch (Exception ex)
            {
                DgvUtils.SetRowStyleForeColor(ref row, WUCollums.LastBoot, Color.Red);
                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, ex.Message);
            }
            finally
            {
                EndReadiness(ref row);
            }
        }

        public void StartHostReadinessViaPsExec(string host, ref DataGridViewRow row, bool hasActiveResources)
        {
            try
            {
                DgvUtils.SetRowStyleForeColor(ref row, WUCollums.LastBoot, Color.Black);
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, string.Empty);
                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, string.Empty);
                DgvUtils.SetRowValue(ref row, WUCollums.Status, "Starting");
                DateTime lastBootDate = GetLastBootDateTimeObject(host, ref row);
                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, lastBootDate.ToString("dd/MM/yyyy HH:mm"));
                DgvUtils.SetRowValue(ref row, WUCollums.Status, "Finish");
            }
            catch (Exception ex)
            {
                DgvUtils.SetRowStyleForeColor(ref row, WUCollums.LastBoot, Color.Red);
                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, ex.Message);
            }
            finally
            {
                EndReadiness(ref row);
            }
        }

        public void FailOverClusterNode(string host)
        {
            ManagementScope scope = GetWmiManagementScope(host);
            string fqdnHostName = $"{host}.{GetFqdnDomain(scope)}";

            using (PsManager ps = new PsManager(fqdnHostName))
            {
                ps.FailOverClusterNode();
            }
        }

        private ManagementScope GetWmiManagementScope(string host)
        {
            ManagementScope scope = new ManagementScope(string.Format(@"\\{0}\root\cimv2", host));
            scope.Options.EnablePrivileges = true;
            scope.Options.Timeout = TimeSpan.FromSeconds(10);

            if (Credentials.IsAlternativeCredentialEnabled)
            {
                scope.Options.Username = Credentials.UserName;
                scope.Options.Password = Credentials.Password;
            }
            scope.Connect();
            return scope;
        }

        private ServiceHostStatus GetAutomaticServiceStatus(ManagementScope scope)
        {
            int automaticServiceStartedCounter = 0;
            bool isClusterMember = false;

            ObjectQuery servicesQuery = new ObjectQuery("SELECT * FROM Win32_Service WHERE StartMode='Auto'");

            foreach (ManagementObject mo in GetWmiResults(scope, servicesQuery))
            {
                if (!IsAutomaticDelayService(mo))
                {
                    if (Convert.ToBoolean(mo["Started"]))
                        automaticServiceStartedCounter++;
                    if (string.Equals(mo["Name"].ToString(), "ClusSvc", StringComparison.CurrentCultureIgnoreCase))
                        isClusterMember = true;
                }
            }

            return new ServiceHostStatus
            {
                ServicesRunning = automaticServiceStartedCounter,
                IsClustered = isClusterMember
            };
        }

        private bool IsAutomaticDelayService(ManagementObject mo)
        {
            //This wmi attribute is always available for Windows 10/2016
            //In case of exptions(not found) it returns false
            try
            {
                return Convert.ToBoolean(mo["DelayedAutoStart"]);
            }
            catch
            {
                return false;
            }
        }

        private string GetFqdnDomain(ManagementScope scope)
        {
            string fgdn = string.Empty;
            ObjectQuery fqdn = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            ManagementObjectCollection wmiResults = GetWmiResults(scope, fqdn);
            foreach (ManagementObject mo in wmiResults)
            {
                fgdn = mo["Domain"].ToString();
            }

            return fgdn;
        }

        private DateTime GetLasBoot(ManagementScope scope)
        {
            DateTime date = DateTime.MinValue;
            ObjectQuery lastBootQuery = new ObjectQuery("SELECT LastBootUpTime FROM Win32_OperatingSystem");
            ManagementObjectCollection wmiResults = GetWmiResults(scope, lastBootQuery);
            foreach (ManagementObject mo in wmiResults)
            {
                date = ParseCIMDateTime(mo["LastBootUpTime"].ToString());
            }

            return date;
        }

        private ManagementObjectCollection GetWmiResults(ManagementScope scope, ObjectQuery query)
        {
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(scope, query))
            {
                return mos.Get();
            }
        }

        private static DateTime ParseCIMDateTime(string wmiDate)
        {
            //datetime object to store the return value
            DateTime date = DateTime.MinValue;

            //check date integrity
            if (wmiDate != null && wmiDate.IndexOf('.') != -1)
            {
                //obtain the date with miliseconds
                string tempDate = wmiDate.Substring(0, wmiDate.IndexOf('.') + 4);

                //check the lenght
                if (tempDate.Length == 18)
                {
                    //extract each date component
                    int year = Convert.ToInt32(tempDate.Substring(0, 4));
                    int month = Convert.ToInt32(tempDate.Substring(4, 2));
                    int day = Convert.ToInt32(tempDate.Substring(6, 2));
                    int hour = Convert.ToInt32(tempDate.Substring(8, 2));
                    int minute = Convert.ToInt32(tempDate.Substring(10, 2));
                    int second = Convert.ToInt32(tempDate.Substring(12, 2));
                    int milisecond = Convert.ToInt32(tempDate.Substring(15, 3));

                    //compose the new datetime object
                    date = new DateTime(year, month, day, hour, minute, second, milisecond);
                }
            }

            //return datetime
            return date;
        }
    }

    public class ServiceHostStatus
    {
        public int ServicesRunning { get; set; }
        public bool IsClustered { get; set; }
    }
}
