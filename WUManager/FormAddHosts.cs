namespace WUManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textHosts.Text))
            {
                DataGridViewAddRowsDelegate delegateAddRows =
                    new DataGridViewAddRowsDelegate(this.formMain.DataGridViewAddRow);

                delegateAddRows.BeginInvoke(textHosts.Lines, null, null);

                this.Close();
            }
        }

        private void textHosts_TextChanged(object sender, EventArgs e)
        {
            lblLines.Text = string.Format("Lines: {0}", textHosts.Lines.Length);
        }

    }
}
