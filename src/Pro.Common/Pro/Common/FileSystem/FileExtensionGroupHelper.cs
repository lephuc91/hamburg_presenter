using System.Collections.Generic;
using System.Linq;

namespace Pro.Common.FileSystem;

public static class FileExtensionGroupHelper
{
	public static string GenerateFilter(FileExtensionGroup extensions)
	{
		return GenerateFilter(extensions.DisplayName, extensions);
	}

	public static string GenerateFilterGroup(bool allowAllTypes, params FileExtensionGroup[] extensionGroups)
	{
		IEnumerable<FileExtensionGroup> enumerable = extensionGroups;
		bool flag = extensionGroups.Any();
		if (allowAllTypes)
		{
			enumerable = enumerable.Concat(new FileExtensionGroup[1]
			{
				new FileExtensionGroup("All Files", ".*")
			});
		}
		string element = GenerateFilter("All Supported Files", extensionGroups);
		if (!flag)
		{
			element = string.Empty;
		}
		IEnumerable<string> source = enumerable.Select(GenerateFilter);
		source = source.Prepend(element);
		return string.Join("|", source.Where((string s) => !string.IsNullOrEmpty(s)));
	}

	public static string GenerateFilter(string displayName, params FileExtensionGroup[] extensionGroups)
	{
		List<string> list = new List<string>();
		foreach (string item in extensionGroups.SelectMany((FileExtensionGroup e) => e.SupportedExtensions))
		{
			list.Add($"*{item}");
		}
		string text = string.Join(";", list);
		return displayName + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")|" + text) : string.Empty);
	}

	public static string GenerateFilterGroup(params FileExtensionGroup[] extensionGroups)
	{
		return GenerateFilterGroup(allowAllTypes: true, extensionGroups);
	}
}
