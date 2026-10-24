using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using Pro.Common.IO;
using Pro.Localization;

namespace ProPresenter.UI.Validation;

public class ExportValidationRule : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string name = (value as string) ?? string.Empty;
		var (isValid, errorContent) = validate();
		return new ValidationResult(isValid, errorContent);
		(bool, string) validate()
		{
			List<string> reservedWords;
			List<char> invalidCharacters;
			return IOValidation.Validate(string.Empty, name, string.Empty, out reservedWords, out invalidCharacters) switch
			{
				IOValidationError.InvalidCharacters => (false, LocalizedStrings.Get("INVALID_FILENAME_INVALID_CHARACTERS_message")), 
				IOValidationError.ReservedWord => (false, LocalizedStrings.Get("INVALID_FILENAME_RESERVED_WORD_message", new object[1] { string.Join(", ", reservedWords) })), 
				IOValidationError.Empty => (false, LocalizedStrings.Get("INVALID_FILENAME_BLANK_message")), 
				_ => (true, string.Empty), 
			};
		}
	}
}
