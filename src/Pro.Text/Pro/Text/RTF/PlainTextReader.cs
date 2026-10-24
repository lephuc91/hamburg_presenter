using Pro.Common.Strings;
using Pro.Text.RTF.Tokens;

namespace Pro.Text.RTF;

public class PlainTextReader : DocumentReader
{
	private string? _text;

	public string ReadText(string rtfData)
	{
		_text = string.Empty;
		Group group = TokenReader.Parse(rtfData);
		if (group != null)
		{
			ParseData(group);
		}
		return _text;
	}

	protected override void InsertPlainText(string text)
	{
		_text += text;
	}

	protected override void StartParagraph()
	{
		_text += LineBreaks.NewLine;
	}
}
