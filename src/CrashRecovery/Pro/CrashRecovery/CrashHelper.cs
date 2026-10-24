using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Pro.CrashRecovery;

public static class CrashHelper
{
	public static void ShowCrashReport(string appName, string relaunchParameters, string crashReportFilename)
	{
		string assemblyExe = GetAssemblyExe(Assembly.GetExecutingAssembly());
		string assemblyExe2 = GetAssemblyExe(Assembly.GetEntryAssembly());
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = appName;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = assemblyExe2;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = EscapeParameters(relaunchParameters);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = crashReportFilename;
		Process.Start(new ProcessStartInfo(assemblyExe, string.Format("\"{0}\" \"{1}\" \"{2}\" \"{3}\"", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)))
		{
			UseShellExecute = true
		});
	}

	private static string GetAssemblyExe(Assembly assembly)
	{
		string text = Path.GetFullPath(assembly.Location);
		string extension = Path.GetExtension(text);
		if (extension != ".exe")
		{
			text = text.Replace(extension, ".exe");
		}
		return text;
	}

	private static string EscapeParameters(string command)
	{
		return command.Replace("\"", "\"\"");
	}

	public static void StageCrashReportFiles(string outDir, IEnumerable<string> files)
	{
		if (Directory.Exists(outDir))
		{
			new DirectoryInfo(outDir).Delete(recursive: true);
		}
		Directory.CreateDirectory(outDir);
		if (!Directory.Exists(outDir))
		{
			return;
		}
		foreach (string file in files)
		{
			File.Copy(file, Path.Combine(outDir, Path.GetFileName(file)), overwrite: true);
		}
	}
}
