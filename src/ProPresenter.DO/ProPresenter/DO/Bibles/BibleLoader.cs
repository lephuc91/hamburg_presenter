using System;
using System.IO;
using Pro.Common.Logging;
using ProPresenter.DO.Bibles.Formats;

namespace ProPresenter.DO.Bibles;

internal static class BibleLoader
{
	public static BibleBase? TryLoad(string installPath, InstalledBible installedBible)
	{
		return TryLoad(Path.Combine(installPath, installedBible.ID.ToString()), installedBible.Format, installedBible.Name);
	}

	public static BibleBase? TryLoad(string biblePath, BibleFormat bibleFormat, string bibleName)
	{
		try
		{
			return DoLoadBible(biblePath, bibleFormat);
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			Log.Error("Unable to load bible: {0}", bibleName);
			return null;
		}
	}

	private static BibleBase DoLoadBible(string biblePath, BibleFormat format)
	{
		return format switch
		{
			BibleFormat.DB3 => new DB3Bible(biblePath), 
			BibleFormat.USX => new USXBible(biblePath), 
			_ => throw new NotSupportedException("Unknown bible format"), 
		};
	}
}
