using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.FileSystem;

namespace Pro.Common.IO;

public static class IOValidation
{
	private static readonly IEnumerable<char> _invalidNameCharacters = Path.GetInvalidFileNameChars();

	public static IOValidationError Validate(string directory, string name, string? fileExtension, out List<string>? reservedWords, out List<char>? invalidCharacters)
	{
		reservedWords = null;
		invalidCharacters = null;
		if (string.IsNullOrWhiteSpace(name))
		{
			return IOValidationError.Empty;
		}
		if (name.Any((char c) => _invalidNameCharacters.Contains(c)))
		{
			invalidCharacters = _invalidNameCharacters.Where((char c) => name.Contains(c)).ToList();
		}
		List<char>? obj = invalidCharacters;
		if (obj != null && obj.Any())
		{
			return IOValidationError.InvalidCharacters;
		}
		string text = name + fileExtension;
		if (text.Last().IsAnyOf('.', ' '))
		{
			return IOValidationError.InvalidEnding;
		}
		string text2 = Path.Combine(directory, text);
		if (text2.Length > FileHelper.MaxFilenameLength)
		{
			return IOValidationError.TooLong;
		}
		if (name.DoesIncludeReservedWords(out reservedWords))
		{
			return IOValidationError.ReservedWord;
		}
		if (Directory.Exists(text2) || (Directory.Exists(directory) && Directory.GetFiles(directory, text, SearchOption.TopDirectoryOnly).Any()))
		{
			return IOValidationError.Exists;
		}
		return IOValidationError.None;
	}
}
