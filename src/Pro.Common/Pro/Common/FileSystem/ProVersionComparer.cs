using System.Collections.Generic;
using System.IO;

namespace Pro.Common.FileSystem;

public class ProVersionComparer : IComparer<string>
{
	public int Compare(string? lFilename, string? rFilename)
	{
		try
		{
			string? extension = Path.GetExtension(lFilename);
			string extension2 = Path.GetExtension(rFilename);
			return getVal(extension) - getVal(extension2);
		}
		catch
		{
		}
		return 0;
		static int getVal(string? ext)
		{
			return ext switch
			{
				".pro" => 7, 
				".pro6" => 6, 
				".pro5" => 5, 
				".pro4" => 4, 
				_ => 0, 
			};
		}
	}
}
