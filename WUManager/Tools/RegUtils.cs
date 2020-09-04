using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace WUManager.Tools
{
    public class RegUtils
    {
        private string machineName;

        public RegUtils(string machineName)
        {
            this.machineName = machineName;
        }

        public object GetKeyValue(string key, string subKey)
        {
            object result = null;

            using (RegistryKey regKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, this.machineName))
            {
                RegistryKey item = regKey.OpenSubKey(key);

                foreach (string obj in item.GetSubKeyNames())
                {
                    if (obj == subKey)
                    {
                        result = obj;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
