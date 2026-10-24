using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.IO;
using Pro.Localization;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public static class LibraryHelper
{
	public static bool ValidateName(string directory, Action<string> showMessage, string name, string? fileExtension = null, Action<string>? duplicateName = null)
	{
		List<string> reservedWords;
		List<char> invalidCharacters;
		switch (IOValidation.Validate(directory, name, fileExtension ?? string.Empty, out reservedWords, out invalidCharacters))
		{
		case IOValidationError.None:
			return true;
		case IOValidationError.Exists:
			if (duplicateName == null)
			{
				showMessage(LocalizedStrings.Get("INVALID_FILENAME_NAME_IN_USE_message", new object[1] { name }));
				return false;
			}
			duplicateName(name);
			return true;
		case IOValidationError.TooLong:
			showMessage(LocalizedStrings.Get("INVALID_FILENAME_NAME_IN_USE_message", new object[1] { name }));
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
	}

	public static Timeline? GetTimeline(this IDocumentCue document)
	{
		return document.DocumentAction?.Presentation?.PresentationTimeline;
	}
}
