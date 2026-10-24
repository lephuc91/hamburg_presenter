using System;
using Pro.Common.Strings;

namespace Pro.Text.RTF;

public class PlainTextWriter : DocumentWriter
{
	public string WriteText(string text)
	{
		PrepareWrite();
		string[] array = text.Split(LineBreaks.All, StringSplitOptions.None);
		foreach (string text2 in array)
		{
			StartParagraph();
			InsertPlainText(text2);
		}
		return CompleteWrite();
	}
}
