using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WUManager.Tools
{
    public class OperSystemUtils
    {
        public bool IsRebootRequired(string host)
        {
            bool isRequired = false;
            
            string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update\";            
            //para Windows 2012 e 2012 R2 a chave de registro é diferente
            string subKey = "RebootRequired";

            //Verifica se o Servidor local é Windows 2008, isso porque o Remote Registry não consegue abrir
            //As chaves de registro de Update
            if (IsLocalServerWin2008())
            {
                throw new Exception("Local Operation System cannot open Remote Registry. Try to run in another source server.");
            }
            
            RegUtils reg = new RegUtils(host);    
            
            //Checa para Windows
            if (reg.GetKeyValue(key, subKey) != null)
                isRequired = true;                      
            
            return  isRequired;
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

        public StreamReader ExecWua(string argumets, string hostName)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "psexec.exe";
                process.StartInfo.Arguments = string.Format(@"-s -accepteula \\{0} Wua.exe {1}", hostName, argumets);

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
        public StreamReader ExecWua(string argumets, string hostName, string username, string password)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "psexec.exe";
                process.StartInfo.Arguments = string.Format(@"-s -accepteula -u {0} -p {1} \\{2} Wua.exe {3}", username, password, hostName, argumets);

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

        private System.Security.SecureString ConvertToSecureString(string password)
        {
            var secure = new System.Security.SecureString();
            foreach (char c in password)
            {
                secure.AppendChar(c);
            }
            return secure;
        }
    }
}
