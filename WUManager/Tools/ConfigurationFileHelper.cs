using System;
using System.Configuration;

namespace WUManager.Tools
{
    public class ConfigurationFileHelper
    {
        private static bool? remoteOperationsUsesDCOM;

        public static bool RemoteOperationsUsesDCOM
        {
            get
            {
                if (!remoteOperationsUsesDCOM.HasValue)
                {
                    remoteOperationsUsesDCOM = Convert.ToBoolean(ConfigurationManager.AppSettings["remoteOperationsUsesDCOM"]);
                }

                return (bool)remoteOperationsUsesDCOM;
            }
        }
    }
}
