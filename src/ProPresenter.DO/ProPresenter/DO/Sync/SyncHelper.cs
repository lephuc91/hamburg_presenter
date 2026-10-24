using Pro.Common.FileSystem;

namespace ProPresenter.DO.Sync;

public static class SyncHelper
{
	public static string ConvertToRepoFile(this string file, string syncFolder)
	{
		string text = syncFolder.NormalizePath().TrimTrailingSlashes();
		string oldValue = CommonPaths.Base.NormalizePath().TrimTrailingSlashes();
		if (string.IsNullOrEmpty(text))
		{
			return file;
		}
		return file.NormalizePath(isDirectory: false).Replace(oldValue, text);
	}

	public static string ConvertToLocalFile(this string file, string syncFolder)
	{
		string text = syncFolder.NormalizePath().TrimTrailingSlashes();
		string newValue = CommonPaths.Base.NormalizePath().TrimTrailingSlashes();
		if (string.IsNullOrEmpty(text))
		{
			return file;
		}
		return file.NormalizePath(isDirectory: false).Replace(text, newValue);
	}
}
