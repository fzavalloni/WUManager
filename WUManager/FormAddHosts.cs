namespace WUManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using WUManager.Tools;

    public partial class FormAddHosts : Form
    {
        FormMain formMain;

        public FormAddHosts()
        {
            InitializeComponent();

            throw new Exception("Use constructor with parameter 'FormMain'");
        }

        public FormAddHosts(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textHosts.Text))
            {
                DataGridViewAddRowsDelegate delegateAddRows =
                    new DataGridViewAddRowsDelegate(this.formMain.DataGridViewAddRow);

                delegateAddRows.BeginInvoke(textHosts.Lines, null, null);

                this.Close();
            }
        }

        private void TextHosts_TextChanged(object sender, EventArgs e)
        {
            lblLines.Text = string.Format("Lines: {0}", textHosts.Lines.Length);
        }

        private void BtnSearchAD_Click(object sender, EventArgs e)
        {
            string ldapADPath = txtBoxCustomLdapPath.Text;
            ADManager adMgr;

            if (DefaultLdapPatchChBox.Checked)
            {
                adMgr = new ADManager();
            }
            else
            {
                adMgr = new ADManager($"LDAP://{ldapADPath}");
            }

            try
            {                                
                textHosts.Text = adMgr.GetADHosts().ToString();
            }
            catch (Exception err)
            {
                lblLines.Text = err.Message;
            }
            finally
            {
                adMgr.Dispose();
            }
        }

        private void DefaultLdapPatchChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultLdapPatchChBox.Checked)
            {
                txtBoxCustomLdapPath.Visible = false;
            }
            else
            {
                txtBoxCustomLdapPath.Visible = true;
            }
        }
    }
}
