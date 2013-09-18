using System;
using System.IO;
using SolutionCleaner.Utilities;

namespace SolutionCleaner.Cmd
{
	public delegate void DirectoryHandler(string path);

	public class DirCleanerCmd : ICmd
	{
		private readonly string _root = string.Empty;
		private readonly string _pattern = string.Empty;

		private event DirectoryHandler _onDirectoryDeleting;

		public event DirectoryHandler OnDirectoryDeleting
		{
			add { _onDirectoryDeleting += value; }
			remove { _onDirectoryDeleting -= value; }
		}

		private event DirectoryHandler _onDirectoryDeleted;

		public event DirectoryHandler OnDirectoryDeleted
		{
			add { _onDirectoryDeleted += value; }
			remove { _onDirectoryDeleted -= value; }
		}

		public DirCleanerCmd(string root, string pattern, DirectoryHandler onDirectoryDeleting = null, DirectoryHandler onDirectoryDeleted = null)
		{
			_root = root;
			_pattern = pattern;
			_onDirectoryDeleting += onDirectoryDeleting;
			_onDirectoryDeleted += onDirectoryDeleted;
		}

		private void Clean(string path, bool isbackup)
		{
			string[] dirs = Directory.GetDirectories(path, _pattern, SearchOption.AllDirectories);
			foreach( string dir in dirs ) {
				try {
					BackupHelper.Delete(dir, path, isbackup);
					if( _onDirectoryDeleting != null ) {
						_onDirectoryDeleting(string.Format("\r\n{0} has been deleted.\r\n", dir));
					}
				}
				catch( Exception ex ) {
					_onDirectoryDeleting(string.Format("\r\n{0} can't be deleted:\r\n{1}", dir, ex.Message));
				}
			}

			if( _onDirectoryDeleted != null ) {
				_onDirectoryDeleted(string.Format("\r\n---------- All directories has been deleted. ----------\r\n"));
			}
		}

		public void Do(object isbackup)
		{
			//Debug.Assert(!string.IsNullOrEmpty(_root));
			//Debug.Assert(Directory.Exists(_root));

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