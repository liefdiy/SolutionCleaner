using System.Collections.Generic;

namespace SolutionCleaner.Cmd
{
	internal class CmdParser
	{
		public static List<ICmd> Parse(string root, string pattern, DirectoryHandler onDirectoryDeleting = null, DirectoryHandler onDirectoryDeleted = null)
		{
			if( string.IsNullOrEmpty(pattern) ) {
				return null;
			}

			List<ICmd> cmds = new List<ICmd>();
			string[] patterns = pattern.Split(';');	//分号分隔不同类型文件或者文件夹

			foreach( var s in patterns ) {
				if( s.IndexOf('.') > 0 ) {
					cmds.Add(new FileCleanerCmd(root, s, onDirectoryDeleting, onDirectoryDeleted));	//files
				}
				else {
					cmds.Add(new DirCleanerCmd(root, s, onDirectoryDeleting, onDirectoryDeleted));	//dir
				}
			}
			return cmds;
		}
	}
}