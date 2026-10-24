using System;

namespace Pro.Common.Strings;

public static class LineBreaks
{
	public const string Return = "\r";

	public const string LineFeed = "\n";

	public static string NewLine => Environment.NewLine;

	public static string[] All => new string[3] { NewLine, "\r", "\n" };

	public static string Replace(string value, string replacement = "")
	{
		if (string.IsNullOrEmpty(value))
		{
			return string.Empty;
		}
		string[] all = All;
		foreach (string oldValue in all)
		{
			value = value.Replace(oldValue, replacement);
		}
		return value;
	}
}
