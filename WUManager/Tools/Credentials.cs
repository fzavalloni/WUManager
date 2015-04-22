using System;
using System.Collections.Generic;
using System.Text;

namespace WUManager.Tools
{
    public static class Credentials
    {
        private static bool isAlternativeCredentialEnabled = false;
        public static bool IsAlternativeCredentialEnabled
        {
            get 
            {
                return isAlternativeCredentialEnabled;
            }
            set
            {
                isAlternativeCredentialEnabled = value;
            }
        }

        private static string userName;
        public static string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        private static string password;
        public static string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
