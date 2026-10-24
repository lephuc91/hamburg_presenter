using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI.Welcome;

public partial class CreateWorkspacePage : UserControl, IComponentConnector
{
	private static readonly char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();

	public CreateWorkspacePage()
	{
		InitializeComponent();
	}

	private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
	{
		e.Handled = e.Text.Any((char c) => InvalidFileNameChars.Contains(c));
	}

	private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
	{
		if (!(sender is TextBox textBox))
		{
			return;
		}
		if (e.DataObject.GetDataPresent(typeof(string)))
		{
			string text = (string)e.DataObject.GetData(typeof(string));
			if (!ContainsInvalidCharacters(text))
			{
				return;
			}
			e.CancelCommand();
			string text2 = SanitizeText(text);
			if (!string.IsNullOrEmpty(text2))
			{
				int selectionStart = textBox.SelectionStart;
				int selectionLength = textBox.SelectionLength;
				string text3 = textBox.Text.Remove(selectionStart, selectionLength);
				text3 = text3.Insert(selectionStart, text2);
				if (textBox.MaxLength > 0 && text3.Length > textBox.MaxLength)
				{
					text3 = text3.Substring(0, textBox.MaxLength);
				}
				textBox.Text = text3;
				textBox.SelectionStart = selectionStart + text2.Length;
			}
		}
		else
		{
			e.CancelCommand();
		}
	}

	private static bool ContainsInvalidCharacters(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		return text.Any((char c) => InvalidFileNameChars.Contains(c));
	}

	private static string SanitizeText(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		return new string(text.Where((char c) => !InvalidFileNameChars.Contains(c)).ToArray());
	}
}
