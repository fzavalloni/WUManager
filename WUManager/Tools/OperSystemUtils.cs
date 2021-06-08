using System;
using System.IO;
using System.Diagnostics;

namespace WUManager.Tools
{
    public class OperSystemUtils
    {
        private string key = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update";
        private string subKey = "RebootRequired";
        private bool remoteOperationsUsesDCOM;

        public OperSystemUtils(bool remoteOperationsUsesDCOM)
        {
            this.remoteOperationsUsesDCOM = remoteOperationsUsesDCOM;
        }

        public bool IsRebootRequired(string host)
        {
            // Para Windows 2012 e 2012 R2 a chave de registro é diferente
            // Verifica se o Servidor local é Windows 2008, isso porque o Remote Registry não consegue abrir
            // As chaves de registro de Update
            if (IsLocalServerWin2008())
            {
                throw new Exception("Local Operation System cannot open Remote Registry. Try to run in another source server.");
            }

            // Valida tipo de acesso remoto
            if (remoteOperationsUsesDCOM)
            {
                return CheckIsRebootRequiredViaDCOM(host, key, subKey);
            }
            else
            {
                return CheckIsRebootRequiredViaPsExec(host, key, subKey);
            }
        }

        public bool ReportUpdatesToWsus(string host)
        {
            StreamReader executionOutput = null;

            bool execResult = ExecProcessViaPsExec(host, "wuauclt.exe", "/reportnow", out executionOutput);

            if (execResult)
            {
                string resultContent = executionOutput.ReadToEnd();
                return (resultContent == null || resultContent.Trim().Length == 0);
            }

            return false;
        }

        public bool ResetAuthorizationOnWsus(string host)
        {
            StreamReader executionOutput = null;

            bool execResult = ExecProcessViaPsExec(host, "wuauclt.exe", "/resetauthorization /detectnow", out executionOutput);

            if (execResult)
            {
                string resultContent = executionOutput.ReadToEnd();
                return (resultContent == null || resultContent.Trim().Length == 0);
            }

            return false;
        }

        private bool CheckIsRebootRequiredViaDCOM(string host, string key, string subKey)
        {
            bool isRequired = false;

            RegUtils reg = new RegUtils(host);

            //Checa para Windows
            if (reg.GetKeyValue(key, subKey) != null)
                isRequired = true;

            return isRequired;
        }

        private bool CheckIsRebootRequiredViaPsExec(string host, string key, string subKey)
        {
            bool isRequired = false;
            StreamReader executionOutput = null;

            bool execResult = ExecProcessViaPsExec(host, "reg.exe", string.Format("query \"{0}\"", GetRebootRequiredRegistryPath()), out executionOutput);

            if (execResult)
            {
                string resultContent = executionOutput.ReadToEnd();
                isRequired = (resultContent != null && resultContent.Trim().Length > 0);
            }

            return isRequired;
        }

        private bool IsLocalServerWin2008()
        {
            bool isWin2008 = false;

            try
            {
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                if (osInfo.Version.Major == 6)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        isWin2008 = true;
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Error checking local SO:" + erro.Message);
            }

            return isWin2008;
        }

        public void CopyPsExec(string hostName)
        {
            string destFile1 = string.Format(@"\\{0}\Admin$\System32\Wua.exe", hostName);
            string destFile2 = string.Format(@"\\{0}\Admin$\System32\Interop.WUApiLib.dll", hostName);

            File.Copy("Wua.exe", destFile1, true);
            File.Copy("Interop.WUApiLib.dll", destFile2, true);
        }

        public StreamReader ExecWua(string arguments, string hostName)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "psexec.exe";
                process.StartInfo.Arguments = string.Format(@"-s -accepteula \\{0} Wua.exe {1}", hostName, arguments);

                process.StartInfo.ErrorDialog = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                process.Start();

                return process.StandardOutput;
            }
        }

        public bool ExecProcessViaPsExec(string hostName, string program, string arguments, out StreamReader executionOutput)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "psexec.exe";
                process.StartInfo.Arguments = string.Format(@"-s -accepteula \\{0} {1} {2}", hostName, program, arguments);

                process.StartInfo.ErrorDialog = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                process.Start();
                process.WaitForExit();

                if (process.StandardOutput != null)
                {
                    executionOutput = process.StandardOutput;
                    return true;
                }
                else
                {
                    executionOutput = process.StandardError;
                    return false;
                }
            }
        }

        public bool ExecProcess(string processName, string arguments, out StreamReader executionOutput)
        {
            using (Process process = new Process())
            {
                Console.WriteLine(processName);
                Console.WriteLine(arguments);

                process.StartInfo.FileName = processName;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.ErrorDialog = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                process.Start();
                process.WaitForExit();

                if (process.StandardOutput != null)
                {
                    executionOutput = process.StandardOutput;
                    return true;
                }
                else
                {
                    executionOutput = process.StandardError;
                    return false;
                }
            }
        }

        public string GetRebootRequiredRegistryPath()
        {
            return System.IO.Path.Combine(key, subKey);
        }
    }
}
