using System;
using System.Drawing;
using System.Windows.Forms;
using WUManager.Tools;

namespace WUManagerConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = args[0];
            string serverName = args[1];

            if (action.Equals("IsRebootRequired", StringComparison.InvariantCultureIgnoreCase))
            {
                TestIsRebootRequired(serverName);
            }
            else if (action.Equals("RebootServer", StringComparison.InvariantCultureIgnoreCase))
            {
                TestRebootServer(serverName);
            }
            else if (action.Equals("GetLastBootDateTime", StringComparison.InvariantCultureIgnoreCase))
            {
                TestGetLastBootDateTime(serverName);
            }
        }

        static void TestIsRebootRequired(string serverName)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("=== Reboot Requerido -> Iniciando  ===");
                Console.WriteLine("");

                OperSystemUtils operUtils = new OperSystemUtils(ConfigurationFileHelper.RemoteOperationsUsesDCOM);

                Console.WriteLine("RemoteOperationsUsesDCOM: {0}", ConfigurationFileHelper.RemoteOperationsUsesDCOM);
                Console.WriteLine("Registry Path: {0}", operUtils.GetRebootRequiredRegistryPath());

                Console.WriteLine("IsRebootRequired: {0}", operUtils.IsRebootRequired(serverName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("=== Reboot Requerido -> Concluido ===");
            }
        }

        static void TestRebootServer(string serverName)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("=== Reboot Server -> Iniciando  ===");
                Console.WriteLine("");

                // Required parameters
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 16, FontStyle.Regular, GraphicsUnit.Pixel);
                DataGridViewRow drRow = new DataGridViewRow();

                OSManager osMgr = new OSManager(font, ConfigurationFileHelper.RemoteOperationsUsesDCOM);
                osMgr.StartReboot(serverName, ref drRow);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("=== Reboot Server -> Concluido ===");
            }
        }

        static void TestGetLastBootDateTime(string serverName)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("=== Get Last Boot Date -> Iniciando  ===");
                Console.WriteLine("");

                // Required parameters
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 16, FontStyle.Regular, GraphicsUnit.Pixel);
                DataGridViewRow drRow = new DataGridViewRow();

                OSManager osMgr = new OSManager(font, ConfigurationFileHelper.RemoteOperationsUsesDCOM);
                DateTime lastBootDate = osMgr.GetLastBootDateTimeObject(serverName, ref drRow);

                Console.WriteLine("Last boot date: {0}", lastBootDate.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("=== Get Last Boot Date -> Concluido ===");
            }
        }
    }
}
