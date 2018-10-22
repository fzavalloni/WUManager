namespace WUManager
{
    partial class FormStartBatch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartBatch));
            this.lblBatch = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.chkBoxRunner = new System.Windows.Forms.CheckBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblExecution = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(13, 13);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(0, 17);
            this.lblBatch.TabIndex = 0;
            // 
            // dtPicker
            // 
            this.dtPicker.CustomFormat = "hh:mm tt - dd/MM/yy";
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Location = new System.Drawing.Point(139, 222);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.ShowUpDown = true;
            this.dtPicker.Size = new System.Drawing.Size(166, 22);
            this.dtPicker.TabIndex = 1;
            this.dtPicker.Value = new System.DateTime(2018, 10, 19, 0, 0, 0, 0);
            this.dtPicker.Visible = false;
            // 
            // chkBoxRunner
            // 
            this.chkBoxRunner.AutoSize = true;
            this.chkBoxRunner.Checked = true;
            this.chkBoxRunner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxRunner.Location = new System.Drawing.Point(12, 198);
            this.chkBoxRunner.Name = "chkBoxRunner";
            this.chkBoxRunner.Size = new System.Drawing.Size(85, 21);
            this.chkBoxRunner.TabIndex = 2;
            this.chkBoxRunner.Text = "Run now";
            this.chkBoxRunner.UseVisualStyleBackColor = true;
            this.chkBoxRunner.CheckedChanged += new System.EventHandler(this.ChkBoxRunner_CheckedChanged);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(12, 257);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(138, 42);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(261, 257);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(138, 42);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(387, 179);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // lblExecution
            // 
            this.lblExecution.AutoSize = true;
            this.lblExecution.Location = new System.Drawing.Point(9, 222);
            this.lblExecution.Name = "lblExecution";
            this.lblExecution.Size = new System.Drawing.Size(128, 17);
            this.lblExecution.TabIndex = 6;
            this.lblExecution.Text = "Schedule to run at:";
            this.lblExecution.Visible = false;
            // 
            // FormStartBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 307);
            this.Controls.Add(this.lblExecution);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.chkBoxRunner);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.lblBatch);
            this.Name = "FormStartBatch";
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.FormStartBatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.CheckBox chkBoxRunner;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblExecution;
    }
}