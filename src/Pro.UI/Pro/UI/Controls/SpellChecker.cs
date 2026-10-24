using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;
using Pro.Common.Logging;
using Pro.Text;

namespace Pro.UI.Controls;

public class SpellChecker : ISpellChecker
{
	public async Task<IEnumerable<Pro.Text.Range>> GetMisspelledWordsAsync(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return Array.Empty<Pro.Text.Range>();
		}
		TextBox textBox = new TextBox();
		textBox.SpellCheck.IsEnabled = true;
		textBox.AcceptsReturn = true;
		textBox.Text = text;
		List<Pro.Text.Range> misspelledWords = new List<Pro.Text.Range>();
		await Dispatcher.CurrentDispatcher.InvokeAsync((Action)delegate
		{
			int num = 0;
			while (num >= 0 && num < textBox.Text.Length)
			{
				if (textBox.GetSpellingError(num) != null)
				{
					int spellingErrorStart = textBox.GetSpellingErrorStart(num);
					int end = spellingErrorStart + textBox.GetSpellingErrorLength(num);
					Pro.Text.Range item = new Pro.Text.Range(spellingErrorStart, end);
					misspelledWords.Add(item);
					num = item.End;
				}
				num = textBox.GetNextSpellingErrorCharacterIndex(num, LogicalDirection.Forward);
			}
		}, (DispatcherPriority)1);
		return misspelledWords;
	}

	public IEnumerable<string> GetSuggestions(string text)
	{
		try
		{
			TextBox textBox = new TextBox();
			textBox.SpellCheck.IsEnabled = true;
			textBox.AcceptsReturn = true;
			textBox.Text = text;
			return textBox.GetSpellingError(0)?.Suggestions.ToArray() ?? Array.Empty<string>();
		}
		catch (FileLoadException ex)
		{
			Log.Info("[{0}]Failed to spell check {1} because of {2}", GetType().Name, text, ex);
			return Enumerable.Empty<string>();
		}
	}
}
