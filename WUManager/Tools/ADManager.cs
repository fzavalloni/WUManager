using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;

namespace WUManager.Tools
{
    class ADManager : IDisposable
    {
        string ldapRootPath;
        DirectoryEntry adEntry;

        public ADManager(string ldapPath)
        {
            this.ldapRootPath = ldapPath;
            adEntry = new DirectoryEntry(ldapRootPath);
        }

        public ADManager()
        {            
            adEntry = new DirectoryEntry();
        }

        public StringBuilder GetADHosts()
        {            
            DirectorySearcher searcher = new DirectorySearcher(adEntry)
            {
                Filter = @"(&(&(&(objectCategory=computer)(objectClass=computer)(!(description=Failover\20cluster\20virtual\20network\20name*)))))",                
            };
            searcher.PropertiesToLoad.Add("name");

            SearchResultCollection result = searcher.FindAll();
            StringBuilder sb = new StringBuilder();
            foreach(SearchResult obj in result)
            {
                sb.AppendLine(obj.Properties["name"][0].ToString());
            }

            return sb;            
        }

        public void Dispose()
        {
            adEntry.Dispose();
        }        
    }
}
