using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.Common.Nullability;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.UI.Settings.PageTemplates.Registration;

public class LicenseCodeTextBox : TextBox
{
	private const string BlockPattern = "([A-Z0-9]{0,5})";

	private const int MaxCodeCharacters = 47;

	private bool _ignoreNextChanged;

	[GeneratedRegex("^[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex CodeMatchRegex()
	{
		return _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__CodeMatchRegex_0.Instance;
	}

	public LicenseCodeTextBox()
	{
		base.MaxLength = 47;
		base.CharacterCasing = CharacterCasing.Upper;
		DataObject.AddPastingHandler((DependencyObject)(object)this, OnPaste);
	}

	protected override void OnPreviewTextInput(TextCompositionEventArgs e)
	{
		string nextText = GetNextText(e.Text);
		e.Handled = !CodeMatchRegex().IsMatch(nextText);
		base.OnPreviewTextInput(e);
	}

	private void OnPaste(object? sender, DataObjectPastingEventArgs e)
	{
		if (e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, autoConvert: true))
		{
			string text = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;
			if (!text.NullableIsNullOrEmpty())
			{
				string nextText = GetNextText(text);
				if (CodeMatchRegex().IsMatch(nextText))
				{
					return;
				}
			}
		}
		e.CancelCommand();
	}

	private string GetNextText(string incomingText)
	{
		string text = base.Text.Remove(base.CaretIndex, base.SelectionLength).Insert(base.CaretIndex, incomingText.ToUpperInvariant());
		return text.Substring(0, Math.Min(text.Length, 47));
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		if (_ignoreNextChanged)
		{
			_ignoreNextChanged = false;
			return;
		}
		Match match = CodeMatchRegex().Match(base.Text);
		if (!match.Success)
		{
			MessageDialogService.ShowSimpleContent(LocalizedStrings.Get("REGISTRATION_ERROR_ALERT_message"), LocalizedStrings.Get("REGISTRATION_ERROR_INVALID_CODE_FORMAT_ALERT_info"));
			return;
		}
		string text = string.Join("-", from g in match.Groups.Cast<Group>().Skip(1)
			where !string.IsNullOrWhiteSpace(g.Value)
			select g.Value);
		if (text != base.Text)
		{
			_ignoreNextChanged = true;
			int caretIndex = base.CaretIndex;
			bool flag = caretIndex == base.Text.Length;
			base.Text = text;
			base.CaretIndex = (flag ? text.Length : caretIndex);
		}
		base.OnTextChanged(e);
	}
}
