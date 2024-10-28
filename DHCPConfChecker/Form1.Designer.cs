namespace DHCPConfChecker
{
    partial class Form1
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
            this.btnISCConfOpen = new System.Windows.Forms.Button();
            this.openConfDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnISCLdifOpen = new System.Windows.Forms.Button();
            this.openLdifDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnISCConfExport = new System.Windows.Forms.Button();
            this.btnISCLdifExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKeaConfOpen = new System.Windows.Forms.Button();
            this.btnKeaConfExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnISCConfOpen
            // 
            this.btnISCConfOpen.Location = new System.Drawing.Point(8, 19);
            this.btnISCConfOpen.Name = "btnISCConfOpen";
            this.btnISCConfOpen.Size = new System.Drawing.Size(75, 23);
            this.btnISCConfOpen.TabIndex = 0;
            this.btnISCConfOpen.Text = "isc-conf";
            this.btnISCConfOpen.UseVisualStyleBackColor = true;
            this.btnISCConfOpen.Click += new System.EventHandler(this.btnISCConfOpen_Click);
            // 
            // openConfDialog
            // 
            this.openConfDialog.FileName = "openFileDialog1";
            this.openConfDialog.Filter = "*.conf|*.conf|*.*|*.*";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 12);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(343, 137);
            this.txtResult.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 171);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(343, 78);
            this.txtMessage.TabIndex = 2;
            // 
            // btnISCLdifOpen
            // 
            this.btnISCLdifOpen.Location = new System.Drawing.Point(8, 48);
            this.btnISCLdifOpen.Name = "btnISCLdifOpen";
            this.btnISCLdifOpen.Size = new System.Drawing.Size(75, 23);
            this.btnISCLdifOpen.TabIndex = 5;
            this.btnISCLdifOpen.Text = "isc-ldif";
            this.btnISCLdifOpen.UseVisualStyleBackColor = true;
            this.btnISCLdifOpen.Click += new System.EventHandler(this.btnISCLdifOpen_Click);
            // 
            // openLdifDialog
            // 
            this.openLdifDialog.FileName = "openFileDialog1";
            this.openLdifDialog.Filter = "*.ldif|*.ldif|*.*|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "CSV File|*.csv";
            // 
            // btnISCConfExport
            // 
            this.btnISCConfExport.Location = new System.Drawing.Point(8, 17);
            this.btnISCConfExport.Name = "btnISCConfExport";
            this.btnISCConfExport.Size = new System.Drawing.Size(76, 23);
            this.btnISCConfExport.TabIndex = 6;
            this.btnISCConfExport.Text = "isc-conf";
            this.btnISCConfExport.UseVisualStyleBackColor = true;
            this.btnISCConfExport.Click += new System.EventHandler(this.btnISCConfExport_Click);
            // 
            // btnISCLdifExport
            // 
            this.btnISCLdifExport.Location = new System.Drawing.Point(9, 46);
            this.btnISCLdifExport.Name = "btnISCLdifExport";
            this.btnISCLdifExport.Size = new System.Drawing.Size(75, 23);
            this.btnISCLdifExport.TabIndex = 7;
            this.btnISCLdifExport.Text = "isc-ldif";
            this.btnISCLdifExport.UseVisualStyleBackColor = true;
            this.btnISCLdifExport.Click += new System.EventHandler(this.btnISCLdifExport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKeaConfExport);
            this.groupBox1.Controls.Add(this.btnISCLdifExport);
            this.groupBox1.Controls.Add(this.btnISCConfExport);
            this.groupBox1.Location = new System.Drawing.Point(368, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 108);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export List";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKeaConfOpen);
            this.groupBox2.Controls.Add(this.btnISCLdifOpen);
            this.groupBox2.Controls.Add(this.btnISCConfOpen);
            this.groupBox2.Location = new System.Drawing.Point(368, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 110);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dup Check";
            // 
            // btnKeaConfOpen
            // 
            this.btnKeaConfOpen.Location = new System.Drawing.Point(8, 77);
            this.btnKeaConfOpen.Name = "btnKeaConfOpen";
            this.btnKeaConfOpen.Size = new System.Drawing.Size(75, 23);
            this.btnKeaConfOpen.TabIndex = 6;
            this.btnKeaConfOpen.Text = "kea-conf";
            this.btnKeaConfOpen.UseVisualStyleBackColor = true;
            this.btnKeaConfOpen.Click += new System.EventHandler(this.btnKeaConfOpen_Click);
            // 
            // btnKeaConfExport
            // 
            this.btnKeaConfExport.Location = new System.Drawing.Point(9, 75);
            this.btnKeaConfExport.Name = "btnKeaConfExport";
            this.btnKeaConfExport.Size = new System.Drawing.Size(76, 23);
            this.btnKeaConfExport.TabIndex = 8;
            this.btnKeaConfExport.Text = "kea-conf";
            this.btnKeaConfExport.UseVisualStyleBackColor = true;
            this.btnKeaConfExport.Click += new System.EventHandler(this.btnKeaConfExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtResult);
            this.Name = "Form1";
            this.Text = "DHCPConfChecker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnISCConfOpen;
        private System.Windows.Forms.OpenFileDialog openConfDialog;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnISCLdifOpen;
        private System.Windows.Forms.OpenFileDialog openLdifDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnISCConfExport;
        private System.Windows.Forms.Button btnISCLdifExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKeaConfOpen;
        private System.Windows.Forms.Button btnKeaConfExport;
    }
}