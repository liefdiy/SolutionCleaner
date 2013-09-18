using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SolutionCleaner.Cmd;

namespace SolutionCleaner
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void btnExplorer_Click(object sender, EventArgs e)
		{
			if( fbdDirectory.ShowDialog() == DialogResult.OK ) {
				txbPath.Text = fbdDirectory.SelectedPath;
			}
		}

		private void btnClean_Click(object sender, EventArgs e)
		{
			if( string.IsNullOrEmpty(txbPath.Text) || string.IsNullOrEmpty(txbPattern.Text) )
				return;

			var result = MessageBox.Show("清理后无法恢复，是否自动备份？", "提示", MessageBoxButtons.YesNoCancel);

			if( result == DialogResult.Cancel ) {
				return;
			}

			AsyncMethodHandler handler = Execute;
			this.Invoke(handler, result == DialogResult.Yes);
		}

		private delegate void AsyncMethodHandler(object args);

		private void Execute(object args)
		{
			this.btnClean.Enabled = false;
			List<ICmd> cmds = CmdParser.Parse(txbPath.Text, txbPattern.Text, Output, OnFinished);
			foreach( var cmd in cmds ) {
				try
				{
					cmd.Do((bool)args);
				}
				catch (Exception ex)
				{
					Output(cmd.ToString() + ex);
				}
			}
		}

		private void Output(string info)
		{
			txbOutput.AppendText(string.Format("{0}\r\n", info));
		}

		private void OnFinished(string path)
		{
			Output(path);
			this.btnClean.Enabled = true;
		}

		private void txbPattern_MouseHover(object sender, EventArgs e)
		{
			tip.SetToolTip(txbPattern, "输入要删除路径的正则表达式");
		}
	}
}