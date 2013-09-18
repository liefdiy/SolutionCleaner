using System;
using System.Diagnostics;
using System.IO;

namespace SolutionCleaner.Utilities
{
	public static class BackupHelper
	{
		#region IBackup 成员

		/// <summary>
		/// 备份
		/// </summary>
		/// <param name="source">文件的路径</param>
		/// <param name="root">搜索文件夹根目录</param>
		/// <param name="isBackup">是否备份，默认备份</param>
		public static void Delete(string source, string root, bool isBackup = true)
		{
			if( string.IsNullOrEmpty(source) || source.Contains("_Backup") ) {
				return;
			}

			string backupPath = Path.Combine(root, "_Backup");						//备份根目录
			string relativePath = source.Replace(root, "");							//备份在根目录中的相对路径
			string destination = string.Format("{0}{1}", backupPath, relativePath);	//备份存放的绝对路径

			if( !Directory.Exists(backupPath) ) {
				Directory.CreateDirectory(backupPath);
			}

			try {
				if( source.IndexOf('.') > 0 ) {
					HandlerFiles(source, destination);
				}
				else {
					HandlerDir(source, destination);
				}
			}
			catch( Exception ex ) {
#if DEBUG
				Debug.WriteLine("\r\n Backup file error: \r\n" + ex);
#endif
			}
		}

		private static void HandlerFiles(string source, string destination, bool isBackup = true)
		{
			if( !File.Exists(source) )
				return;

			string dir = Path.GetDirectoryName(destination);
			if( !string.IsNullOrEmpty(dir) && !Directory.Exists(dir) ) {
				Directory.CreateDirectory(dir);
			}

			if( isBackup ) {
				File.Move(source, destination);
			}
			else {
				File.Delete(source);
			}
		}

		private static void HandlerDir(string source, string destination, bool isBackup = true)
		{
			if( !Directory.Exists(source) )
				return;

			if( isBackup ) {
				Directory.Move(source, destination);
			}
			else {
				Directory.Delete(source);
			}
		}

		#endregion IBackup 成员
	}
}