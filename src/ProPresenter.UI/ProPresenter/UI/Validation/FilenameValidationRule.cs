using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Pro.Common.IO;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.UI.Validation;

public abstract class FilenameValidationRule : ValidationRule
{
	protected abstract string TargetDirectory { get; }

	protected abstract string FileExtension { get; }

	public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
	{
		return new ValidationResult(IsFileNameValid((value as string) ?? string.Empty), string.Empty);
	}

	private bool IsFileNameValid(string name)
	{
		List<string> reservedWords;
		List<char> invalidCharacters;
		switch (IOValidation.Validate(TargetDirectory, name, FileExtension, out reservedWords, out invalidCharacters))
		{
		case IOValidationError.None:
			return true;
		case IOValidationError.Exists:
			showMessage(LocalizedStrings.Get("INVALID_FILENAME_NAME_IN_USE_message", new object[1] { name }));
			return false;
		case IOValidationError.TooLong:
			showMessage(LocalizedStrings.Get("INVALID_FILENAME_NAME_TOO_LONG_message", new object[1] { name }));
			return false;
		case IOValidationError.InvalidCharacters:
			showMessage(LocalizedStrings.Get("INVALID_FILENAME_INVALID_CHARACTERS_message", new object[1] { string.Join(", ", invalidCharacters.Select((char c) => $"'{c}'")) }));
			return false;
		case IOValidationError.ReservedWord:
			showMessage(LocalizedStrings.Get("INVALID_FILENAME_RESERVED_WORD_message", new object[1] { string.Join(", ", reservedWords) }));
			return false;
		case IOValidationError.Empty:
			showMessage(LocalizedStrings.Get("INVALID_FILENAME_BLANK_message"));
			return false;
		case IOValidationError.InvalidEnding:
			showMessage(LocalizedStrings.Get("INVALID_FILENAME_INVALID_TRAILING_CHARACTER_message"));
			return false;
		default:
			throw new NotSupportedException();
		}
		static void showMessage(string message)
		{
			MessageDialogService.ShowAlert(message);
		}
	}
}
