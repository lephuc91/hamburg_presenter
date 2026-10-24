using Pro.Common.Strings;

namespace Pro.Common.DataStore.Storage;

public static class StorageHelper
{
	public static string Escape(this string value)
	{
		return LineBreaks.Replace(value.Replace("\\", "\\\\"), "\\n");
	}

	public static string Unescape(this string value)
	{
		string text = string.Empty;
		bool flag = false;
		foreach (char c in value)
		{
			if (flag)
			{
				flag = false;
				switch (c)
				{
				case '\\':
					text += c;
					continue;
				case 'n':
					text += "\n";
					continue;
				}
				text += "\\";
			}
			else if (c == '\\')
			{
				flag = true;
				continue;
			}
			text += c;
		}
		return text;
	}
}
