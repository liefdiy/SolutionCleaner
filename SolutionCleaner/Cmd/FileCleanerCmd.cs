using System;
using System.IO;
using SolutionCleaner.Utilities;

namespace SolutionCleaner.Cmd
{
	public class FileCleanerCmd : ICmd
	{
		private readonly string _root = string.Empty;
		private readonly string _pattern = string.Empty;

		private event DirectoryHandler _onFileDeleting;

		public event DirectoryHandler OnFileDeleting
		{
			add { _onFileDeleting += value; }
			remove { _onFileDeleting -= value; }
		}

		private event DirectoryHandler _onFileDeleted;

		public event DirectoryHandler OnFileDeleted
		{
			add { _onFileDeleted += value; }
			remove { _onFileDeleted -= value; }
		}

		/// <summary>
		/// 删除root下的pattern匹配文件
		/// </summary>
		/// <param name="root"></param>
		/// <param name="pattern"></param>
		/// <param name="onDirectoryDeleting"></param>
		/// <param name="onDirectoryDeleted"></param>
		public FileCleanerCmd(string root, string pattern, DirectoryHandler onDirectoryDeleting = null, DirectoryHandler onDirectoryDeleted = null)
		{
			_root = root;
			_pattern = pattern;
			_onFileDeleting += onDirectoryDeleting;
			_onFileDeleted += onDirectoryDeleted;
		}

		private void Clean(string path, bool isbackup)
		{
			try {
				DeleteFiles(path, isbackup);
				if( _onFileDeleted != null ) {
					_onFileDeleted(string.Format("\r\n ---------- All files has been deleted. ----------\r\n"));
				}
			}
			catch( Exception ex )
			{
				_onFileDeleting(string.Format("delete error: \r\n{0}", ex));
			}
		}

		private void DeleteFiles(string path, bool isbackup)
		{
			string[] files = Directory.GetFiles(path, _pattern, SearchOption.AllDirectories);

			foreach( string file in files ) {
				try {
					BackupHelper.Delete(file, _root, isbackup);
					if( _onFileDeleting != null ) {
						_onFileDeleting(string.Format("\r\n{0} has been deleted.\r\n", file));
					}
				}
				catch( Exception ex ) {
					_onFileDeleting(string.Format("\r\n{0} can't be deleted:\r\n{1}", file, ex.Message));
				}
			}
		}

		public void Do(object isbackup)
		{
			Clean(_root, (bool)isbackup);
		}

		public bool Redo()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return string.Format("{0}路径下{1}删除出错:\r\n", _root, _pattern);
		}
	}
}