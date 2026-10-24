using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pro.Reporting;

public class Crash : List<string>
{
	public Exception Exception { get; }

	public string ReportFile => GetEntryFromExtension(".crash") ?? string.Empty;

	public string MiniDumpFile => GetEntryFromExtension(".mdmp") ?? string.Empty;

	public Crash(Exception exception)
	{
		Exception = exception;
	}

	public Crash(Exception exception, params string[] files)
	{
		Exception = exception;
		foreach (string item in files)
		{
			Add(item);
		}
	}

	public IEnumerable<string> GetValidFiles()
	{
		return this.Where((string f) => !string.IsNullOrEmpty(f) && File.Exists(f));
	}

	public string? GetEntryFromExtension(string extension)
	{
		return this.FirstOrDefault((string k) => k.EndsWith(extension));
	}
}
