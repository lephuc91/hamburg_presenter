using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Pro.Common.FileSystem;

public class FileExtensionGroup
{
	public string DisplayName { get; }

	public IEnumerable<string> SupportedExtensions { get; }

	public FileExtensionGroup(string displayName, params string[] supportedExtensions)
	{
		DisplayName = displayName;
		SupportedExtensions = supportedExtensions;
	}

	public bool DoesMatch([NotNullWhen(true)] string? filename)
	{
		return SupportedExtensions.Contains<string>(Path.GetExtension(filename), StringComparer.OrdinalIgnoreCase);
	}

	public FileExtensionGroup Customize(params string[] supportedExtensions)
	{
		string[] supportedExtensions2 = SupportedExtensions.Concat(supportedExtensions).ToArray();
		return new FileExtensionGroup(DisplayName, supportedExtensions2);
	}
}
