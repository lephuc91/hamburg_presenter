namespace Pro.Common.Strings;

public static class FormatByteHelper
{
	private static readonly string[] Sizes = new string[5] { "B", "KB", "MB", "GB", "TB" };

	public static string BytesToReadableSizeFormat(this long value)
	{
		int num = 0;
		while ((value >= 1024 || value <= -1024) && num < Sizes.Length - 1)
		{
			num++;
			value /= 1024;
		}
		return $"{value:0.##} {Sizes[num]}";
	}
}
