using System.Collections.Generic;
using System.Threading.Tasks;
using Pro.Text;

namespace Pro.UI.Controls;

public interface ISpellChecker
{
	Task<IEnumerable<Range>> GetMisspelledWordsAsync(string text);

	IEnumerable<string> GetSuggestions(string text);
}
