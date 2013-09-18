namespace SolutionCleaner
{
    partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			this.txbPath = new System.Windows.Forms.TextBox();
			this.btnExplorer = new System.Windows.Forms.Button();
			this.btnClean = new System.Windows.Forms.Button();
			this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
			this.txbOutput = new System.Windows.Forms.RichTextBox();
			this.txbPattern = new System.Windows.Forms.TextBox();
			this.tip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// txbPath
			// 
			this.txbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txbPath.Location = new System.Drawing.Point(12, 10);
			this.txbPath.Name = "txbPath";
			this.txbPath.Size = new System.Drawing.Size(293, 21);
			this.txbPath.TabIndex = 0;
			// 
			// btnExplorer
			// 
			this.btnExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExplorer.Location = new System.Drawing.Point(311, 8);
			this.btnExplorer.Name = "btnExplorer";
			this.btnExplorer.Size = new System.Drawing.Size(75, 23);
			this.btnExplorer.TabIndex = 1;
			this.btnExplorer.Text = "浏览";
			this.btnExplorer.UseVisualStyleBackColor = true;
			this.btnExplorer.Click += new System.EventHandler(this.btnExplorer_Click);
			// 
			// btnClean
			// 
			this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClean.Location = new System.Drawing.Point(311, 35);
			this.btnClean.Name = "btnClean";
			this.btnClean.Size = new System.Drawing.Size(75, 23);
			this.btnClean.TabIndex = 2;
			this.btnClean.Text = "清理";
			this.btnClean.UseVisualStyleBackColor = true;
			this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
			// 
			// txbOutput
			// 
			this.txbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txbOutput.Location = new System.Drawing.Point(12, 70);
			this.txbOutput.Name = "txbOutput";
			this.txbOutput.Size = new System.Drawing.Size(374, 444);
			this.txbOutput.TabIndex = 3;
			this.txbOutput.Text = "";
			// 
			// txbPattern
			// 
			this.txbPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txbPattern.Location = new System.Drawing.Point(12, 37);
			this.txbPattern.Name = "txbPattern";
			this.txbPattern.Size = new System.Drawing.Size(293, 21);
			this.txbPattern.TabIndex = 4;
			this.txbPattern.Text = "*.vssscc;*.scc;*.vspscc";
			this.txbPattern.MouseHover += new System.EventHandler(this.txbPattern_MouseHover);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(398, 526);
			this.Controls.Add(this.txbPattern);
			this.Controls.Add(this.txbOutput);
			this.Controls.Add(this.btnClean);
			this.Controls.Add(this.btnExplorer);
			this.Controls.Add(this.txbPath);
			this.Name = "frmMain";
			this.Text = "Cleaner";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.Button btnExplorer;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.RichTextBox txbOutput;
        private System.Windows.Forms.TextBox txbPattern;
        private System.Windows.Forms.ToolTip tip;
    }
}

