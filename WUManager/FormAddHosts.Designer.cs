namespace WUManager
{
    partial class FormAddHosts
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchAD = new System.Windows.Forms.Button();
            this.lblLines = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.textHosts = new System.Windows.Forms.TextBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.DefaultLdapPatchChBox = new System.Windows.Forms.CheckBox();
            this.txtBoxCustomLdapPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 1);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.lblInstructions);
            this.splitContainer1.Size = new System.Drawing.Size(564, 421);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxCustomLdapPath);
            this.groupBox1.Controls.Add(this.DefaultLdapPatchChBox);
            this.groupBox1.Controls.Add(this.btnSearchAD);
            this.groupBox1.Controls.Add(this.lblLines);
            this.groupBox1.Controls.Add(this.cmdAdd);
            this.groupBox1.Controls.Add(this.textHosts);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(556, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hosts";
            // 
            // btnSearchAD
            // 
            this.btnSearchAD.Location = new System.Drawing.Point(14, 308);
            this.btnSearchAD.Name = "btnSearchAD";
            this.btnSearchAD.Size = new System.Drawing.Size(111, 28);
            this.btnSearchAD.TabIndex = 3;
            this.btnSearchAD.Text = "Get AD Host";
            this.btnSearchAD.UseVisualStyleBackColor = true;
            this.btnSearchAD.Click += new System.EventHandler(this.BtnSearchAD_Click);
            // 
            // lblLines
            // 
            this.lblLines.AutoSize = true;
            this.lblLines.Location = new System.Drawing.Point(11, 242);
            this.lblLines.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(89, 17);
            this.lblLines.TabIndex = 2;
            this.lblLines.Text = "Lines: Empty";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(13, 267);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(112, 28);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // textHosts
            // 
            this.textHosts.Location = new System.Drawing.Point(11, 20);
            this.textHosts.Margin = new System.Windows.Forms.Padding(4);
            this.textHosts.Multiline = true;
            this.textHosts.Name = "textHosts";
            this.textHosts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textHosts.Size = new System.Drawing.Size(535, 216);
            this.textHosts.TabIndex = 0;
            this.textHosts.TextChanged += new System.EventHandler(this.TextHosts_TextChanged);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(4, 9);
            this.lblInstructions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(403, 51);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Add one host per line.\r\nEmpty lines are ignored.\r\nSpaces at the beginning, middle" +
    " and end of lines are removed.";
            // 
            // DefaultLdapPatchChBox
            // 
            this.DefaultLdapPatchChBox.AutoSize = true;
            this.DefaultLdapPatchChBox.Checked = true;
            this.DefaultLdapPatchChBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DefaultLdapPatchChBox.Location = new System.Drawing.Point(145, 308);
            this.DefaultLdapPatchChBox.Name = "DefaultLdapPatchChBox";
            this.DefaultLdapPatchChBox.Size = new System.Drawing.Size(108, 21);
            this.DefaultLdapPatchChBox.TabIndex = 4;
            this.DefaultLdapPatchChBox.Text = "Default Path";
            this.DefaultLdapPatchChBox.UseVisualStyleBackColor = true;
            this.DefaultLdapPatchChBox.CheckedChanged += new System.EventHandler(this.DefaultLdapPatchChBox_CheckedChanged);
            // 
            // txtBoxCustomLdapPath
            // 
            this.txtBoxCustomLdapPath.Location = new System.Drawing.Point(259, 308);
            this.txtBoxCustomLdapPath.Name = "txtBoxCustomLdapPath";
            this.txtBoxCustomLdapPath.Size = new System.Drawing.Size(286, 22);
            this.txtBoxCustomLdapPath.TabIndex = 5;
            this.txtBoxCustomLdapPath.Text = "OU=Server,DC=contoso,DC=LOCAL";
            this.txtBoxCustomLdapPath.Visible = false;
            // 
            // FormAddHosts
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 431);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddHosts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Hosts";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textHosts;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblLines;
        private System.Windows.Forms.Button btnSearchAD;
        private System.Windows.Forms.TextBox txtBoxCustomLdapPath;
        private System.Windows.Forms.CheckBox DefaultLdapPatchChBox;
    }
}