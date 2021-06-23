using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WUManager.Tools;

namespace WUManager
{
    public partial class FormCredential : Form
    {
        public FormCredential()
        {
            InitializeComponent();           
            chkAltCred.Checked = Credentials.IsAlternativeCredentialEnabled;

            if (chkAltCred.Checked)
            {
                txtUser.Text = Credentials.UserName;
                txtPasswd.Text = Credentials.Password;
            }
            else
            {
                txtUser.Enabled = false;
                txtPasswd.Enabled = false;
            }

        }

        private void chkAltCred_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAltCred.Checked == true)
            {
                txtUser.Enabled = true;
                txtPasswd.Enabled = true;
            }
            else if (chkAltCred.Checked == false)
            {
                txtUser.Enabled = false;
                txtPasswd.Enabled = false;
            }
        }

        private void btnAltCred_Click(object sender, EventArgs e)
        {
            if (chkAltCred.Checked == true)
            {
                Credentials.IsAlternativeCredentialEnabled = true;
                Credentials.UserName = txtUser.Text;
                Credentials.Password = txtPasswd.Text;
            }
            else if(chkAltCred.Checked == false)
            {
                Credentials.IsAlternativeCredentialEnabled = false;
                Credentials.UserName = string.Empty;
                Credentials.Password = string.Empty;
            }

            this.Close();
        }
    }
}
