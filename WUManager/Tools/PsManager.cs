using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace WUManager.Tools
{
    class PsManager : IDisposable
    {
        Runspace runspace;
        string hostname;

        public PsManager(string fqdnHostname)
        {
            this.hostname = fqdnHostname;
            this.runspace = RunspaceFactory.CreateRunspace(GetRemoteConnectionInfo(this.hostname));
            runspace.Open();
        }

        public List<string> GetActiveClusterResources()
        {
            List<string> resourceList = new List<string>();
            string getClusterResourceScript = $"Get-ClusterNode {this.hostname}| Get-ClusterGroup";
            Collection<PSObject> result = ExecuteScript(getClusterResourceScript);

            foreach (PSObject obj in result)
            {
                resourceList.Add(obj.Members["Name"].Value.ToString());
            }
            return resourceList;
        }

        public void FailOverClusterNode()
        {
            string failoverScript = $"Get-ClusterNode {this.hostname}| Get-ClusterGroup | Move-ClusterGroup";

            ExecuteScript(failoverScript);
        }

        public void Dispose()
        {
            runspace.Close();
        }

        private Collection<PSObject> ExecuteScript(string script)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = runspace;
                ps.AddScript(script);

                return ps.Invoke();
            }
        }

        private WSManConnectionInfo GetRemoteConnectionInfo(string host)
        {
            return new WSManConnectionInfo
            {
                ComputerName = host
            };
        }
    }
}
