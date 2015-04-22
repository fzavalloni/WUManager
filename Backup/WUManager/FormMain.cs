namespace WUManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;
    using System.Threading;
    using System.Diagnostics;
    using System.Security.Permissions;

    using WUManager.Enums;
    using WUManager.Tools;

    delegate void DataGridViewAddRowDelegate(string host);
    delegate void DataGridViewAddRowsDelegate(string[] hosts);
    delegate void DataGridViewRowDelegate(DataGridViewRow row);

    public partial class FormMain : Form
    {
        private Dictionary<DataGridViewRow, Thread> threadList;
        private Tools.Pinger pinger;
        private Tools.OSManager osManager;

        public FormMain()
        {
            InitializeComponent();

            this.threadList = new Dictionary<DataGridViewRow, Thread>();
            this.pinger = new Tools.Pinger(this.dataGridView.DefaultCellStyle.Font);
            this.osManager = new Tools.OSManager(this.dataGridView.DefaultCellStyle.Font);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        public void DataGridViewAddRow(string host)
        {
            if (dataGridView.InvokeRequired)
            {
                // this is worker thread
                DataGridViewAddRowDelegate delegateAddRow =
                    new DataGridViewAddRowDelegate(DataGridViewAddRow);
                dataGridView.Invoke(delegateAddRow, host);
            }
            else
            {
                // this is UI thread
                // formating data
                host = host.Replace("\t", "");
                host = host.Replace("\r\n", "");
                host = host.Replace(" ", "");
                // add line.
                if (!string.IsNullOrEmpty(host))
                {
                    dataGridView.Rows.Add(host);
                }
            }
        }

        public void DataGridViewAddRow(string[] hosts)
        {
            foreach (string host in hosts)
            {
                DataGridViewAddRow(host);
            }
        }

        private void OpenFormAddHosts()
        {
            FormAddHosts f = new FormAddHosts(this);
            f.ShowDialog();
        }

        private void addHosts_Click(object sender, EventArgs e)
        {
            this.OpenFormAddHosts();
        }

        #region Actions

        private void Act_InstallUpdateInSelectedItens()
        {
            DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_InstallUpdates);

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                de.BeginInvoke(row, null, null);
            }
        }

        private void Act_InstallUpdates(DataGridViewRow row)
        {
            lock (threadList)
            {
                if (threadList.ContainsKey(row))
                {
                    return;
                }
            }

            DgvUtils.SetRowValue(ref row, WUCollums.Status, "Initializing");
            Thread newThread = new Thread(Act_InstallUpdatesExecutor);

            lock (threadList)
            {
                threadList.Add(row, newThread);
            }

            newThread.IsBackground = true;
            newThread.Start(row);
        }

        private void Act_InstallUpdatesInterpretor(ref DataGridViewRow row, string line)
        {
            string[] lineParts = line.Split(':');

            string operation = lineParts[0];

            string[] parameters = new string[] { string.Empty };
            if (lineParts.Length > 1)
            {
                parameters = lineParts[1].Split('|');
            }

            WUAOperations operations = (WUAOperations)Enum.Parse(typeof(WUAOperations), operation);

            switch (operations)
            {
                case WUAOperations.WUA_Starting:
                    {
                        //WUA_Starting

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Starting");
                        break;
                    }
                case WUAOperations.WUA_IsBusy:
                    {
                        //WUA_IsBusy

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Is Busy");
                        break;
                    }
                case WUAOperations.WUA_FindingUpdates:
                    {
                        //WUA_FindingUpdates

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Finding Updates");
                        break;
                    }
                case WUAOperations.WUA_NoApplicableUpdates:
                    {
                        //WUA_NoApplicableUpdates

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU No Applicable Updates");
                        break;
                    }
                case WUAOperations.WUA_UpdateItem:
                    {
                        //WUA_UpdateItem:N|Title

                        DgvUtils.SetRowValue(ref row, WUCollums.Updates, Convert.ToInt32(parameters[0]));
                        break;
                    }
                case WUAOperations.WUA_DownloadingStarted:
                    {
                        //WUA_DownloadingStarted

                        DgvUtils.SetRowProgressColor(ref row, Color.Tomato, Color.Red);
                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Downloading Started");
                        break;
                    }
                case WUAOperations.WUA_DownloadingProgress:
                    {
                        //WUA_DownloadingProgress:N|N%|T%

                        DgvUtils.SetRowValue(ref row, WUCollums.Progress, Convert.ToInt32(parameters[2]));
                        break;
                    }
                case WUAOperations.WUA_DownloadingCompleted:
                    {
                        //WUA_DownloadingCompleted:ResultCode

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Downloading Completed");
                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Downloading result: " + parameters[0]);
                        break;
                    }
                case WUAOperations.WUA_InstallationStarted:
                    {
                        //WUA_InstallationStarted

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Installation Started");
                        DgvUtils.SetRowValue(ref row, WUCollums.Progress, 0);
                        DgvUtils.SetRowProgressColor(ref row, Color.MediumSpringGreen, Color.Green);
                        break;
                    }
                case WUAOperations.WUA_InstallationProgress:
                    {
                        //WUA_InstallationProgress:N|N%|T%

                        DgvUtils.SetRowValue(ref row, WUCollums.Progress, Convert.ToInt32(parameters[2]));
                        break;
                    }
                case WUAOperations.WUA_InstallationCompleted:
                    {
                        //WUA_InstallationCompleted:ResultCode|RebootRequired

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Installation Completed");
                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Installation result: " + parameters[0]);
                        DgvUtils.SetRowValue(ref row, WUCollums.RebootRequired, Convert.ToBoolean(parameters[1]));
                        break;
                    }
                case WUAOperations.WUA_InstallationResult:
                    {
                        //WUA_InstallationResult:N|ResultCode|RebootRequired

                        break;
                    }
                case WUAOperations.WUA_Finish:
                    {
                        //WUA_Finish

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Finish");
                        break;
                    }
                case WUAOperations.WUA_InternalError:
                    {
                        //WUA_InternalError:Message

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Internal Error");
                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, parameters[0]);
                        break;
                    }
            }
        }

        private void Act_InstallUpdatesExecutor(object rowObject)
        {
            DataGridViewRow row = (DataGridViewRow)rowObject;

            try
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 160);
                row.DefaultCellStyle.SelectionBackColor = Color.Coral;

                DgvUtils.SetRowValue(ref row, WUCollums.Status, "Starting");
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, string.Empty);
                DgvUtils.SetRowValue(ref row, WUCollums.Progress, 0);

                string hostName = row.Cells["Host"].Value.ToString();

                string destFile1 = string.Format(@"\\{0}\Admin$\System32\Wua.exe", hostName);
                string destFile2 = string.Format(@"\\{0}\Admin$\System32\Interop.WUApiLib.dll", hostName);

                try
                {
                    File.Copy("Wua.exe", destFile1, true);
                    File.Copy("Interop.WUApiLib.dll", destFile2, true);
                }
                catch (Exception ex)
                {
                    DgvUtils.SetRowValue(ref row, WUCollums.Status, "StartError");
                    DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, ex.Message);
                    this.Sys_RemoveThreadRow(ref row);
                    return;
                }

                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "psexec.exe";
                    process.StartInfo.Arguments = string.Format(@"-s -accepteula \\{0} Wua.exe /install /showProgress", hostName);

                    process.StartInfo.ErrorDialog = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardInput = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    process.Start();

                    StreamReader reader = process.StandardOutput;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Act_InstallUpdatesInterpretor(ref row, line);
                    }
                }
            }
            catch (Exception ex)
            {
                DgvUtils.SetRowValue(ref row, WUCollums.Status, "ThreadError");
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, ex.Message);
            }
            finally
            {
                this.Sys_RemoveThreadRow(ref row);
            }
        }

        private void Sys_RemoveThreadRow(ref DataGridViewRow row)
        {
            lock (threadList)
            {
                if (threadList.ContainsKey(row))
                {
                    threadList.Remove(row);
                }
            }
        }

        private void Act_RemoveSelectedItens()
        {
            DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_RemoveItem);

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                de.BeginInvoke(row, null, null);
            }
        }

        private void Act_RemoveItem(DataGridViewRow row)
        {
            if (dataGridView.InvokeRequired)
            {
                DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_RemoveItem);
                dataGridView.Invoke(de, row);
            }
            else
            {
                pinger.BeginStop(row);

                lock (row)
                {
                    lock (threadList)
                    {
                        if (threadList.ContainsKey(row))
                        {
                            threadList[row].Abort(null);
                            threadList.Remove(row);
                        }
                    }

                    dataGridView.Rows.Remove(row);
                }
            }
        }

        private void Act_Exit()
        {
            lock (threadList)
            {
                foreach (KeyValuePair<DataGridViewRow, Thread> item in threadList)
                {
                    item.Value.Abort();
                }
            }

            this.Close();
        }

        private void Act_StartPingInSelectedItens()
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                string host = row.Cells["Host"].Value.ToString();
                pinger.BeginStart(host, row);
            }
        }

        private void Act_StopPingInSelectedItens()
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                pinger.BeginStop(row);
            }
        }

        private void Act_GetLastBootInSelectedItens()
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                string host = row.Cells["Host"].Value.ToString();
                osManager.BeginGetLastBoot(host, row);
            }
        }

        private void Act_RebootSelectedItens()
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_StopThreadAndReboot);
                de.BeginInvoke(row, null, null);
            }
        }

        private void Act_StopThreadAndReboot(DataGridViewRow row)
        {
            if (dataGridView.InvokeRequired)
            {
                DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_StopThreadAndReboot);
                dataGridView.Invoke(de, row);
            }
            else
            {
                lock (row)
                {
                    string host = row.Cells["Host"].Value.ToString();
                    pinger.BeginStart(host, row);

                    lock (threadList)
                    {
                        if (threadList.ContainsKey(row))
                        {
                            DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Aborting, wait ...");

                            threadList[row].Abort(null);

                            Thread.Sleep(5000);
                        }
                    }

                    osManager.BeginReboot(row, host);
                }
            }
        }

        #endregion

        #region Tool Strip Menu

        private void addToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.OpenFormAddHosts();
        }

        private void installUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_InstallUpdateInSelectedItens();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_Exit();
        }

        private void startPingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_StartPingInSelectedItens();
        }

        private void stopPingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_StopPingInSelectedItens();
        }

        private void getLastBootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_GetLastBootInSelectedItens();
        }

        private void rebootToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_RebootSelectedItens();
        }

        private void startPingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_StartPingInSelectedItens();
        }

        private void stopPingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_StopPingInSelectedItens();
        }

        private void getLastBootToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_GetLastBootInSelectedItens();
        }

        private void rebootToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Act_RebootSelectedItens();
        }

        private void installUpdatesContextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_InstallUpdateInSelectedItens();
        }

        private void removeItensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_RemoveSelectedItens();
        }

        private void removeContextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_RemoveSelectedItens();
        }

        #endregion
    }
}
