using System;
using System.Windows.Forms;

namespace WUManager
{
    public partial class FormStartBatch : Form
    {        
        FormMain formMain;
        public FormStartBatch()
        {
            InitializeComponent();

            throw new Exception("Use constructor with parameter 'FormMain'");
        }

        public FormStartBatch(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void FormStartBatch_Load(object sender, EventArgs e)
        {
            dtPicker.Value = DateTime.Now;
        }

        private void ChkBoxRunner_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRunner.Checked)
            {
                dtPicker.Visible = false;
                lblExecution.Visible = false;
            }
            else
            {
                dtPicker.Visible = true;
                lblExecution.Visible = true;
            }
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            DateTime executionTime = new DateTime();

            if (chkBoxRunner.Checked)
            {
                executionTime = DateTime.Now;
            }
            else
            {
                executionTime = dtPicker.Value;
            }            
            this.formMain.Act_InstallUpdateBatchInSelectedItens(executionTime);
            this.Close();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
