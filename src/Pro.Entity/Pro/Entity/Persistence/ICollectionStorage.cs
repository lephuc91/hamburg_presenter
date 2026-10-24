using System;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;

namespace Pro.Entity.Persistence;

public interface ICollectionStorage
{
	public class ObservationDetails
	{
		public required string ContainingFolder { get; init; }

		public string? FileName { get; init; }

		public string LegacyFileExtension { get; init; } = string.Empty;

		public bool AllowNesting { get; init; }

		public required bool LoadInitialFilesFromLegacy { get; init; }

		[GeneratedRegex("^\\.([^.*\\s]+)$")]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
		private static Regex ExtensionRegex()
		{
			return _003CRegexGenerator_g_003EF1CCF1E6C09450ECA2B4292A0A7490D5145696E05E6E06ADC4F01B8723EFF1CE6__ExtensionRegex_0.Instance;
		}

		public void Validate()
		{
			bool num = IsValidLegacyFileExtension(LegacyFileExtension);
			bool flag = !string.IsNullOrEmpty(FileName);
			if (!num && !flag)
			{
				throw new InvalidOperationException("Either the LegacyFileExtension property must match the regex pattern ^\\.([^.*\\s]+)$ or the FileName property must be non empty");
			}
		}

		public string GetLegacyFileMatchPatternByFileName()
		{
			if (string.IsNullOrEmpty(FileName))
			{
				return "*" + LegacyFileExtension;
			}
			return FileName + LegacyFileExtension;
		}

		public string GetCloudFileMatchPatternByFileName()
		{
			if (string.IsNullOrEmpty(FileName))
			{
				return "*.proCloud";
			}
			return FileName + "-*.proCloud";
		}

		private static bool IsValidLegacyFileExtension(string extension)
		{
			return ExtensionRegex().IsMatch(extension);
		}
	}

	IDisposable SubscribeForFiles(ObservationDetails details, Action<string, bool, Guid?> onAdd, Action<Guid> onRemove, Action<Guid, string> onMove);

	void HandleLocalLegacyFileCreated(string filePath);
}
