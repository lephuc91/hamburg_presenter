using System;
using System.Runtime.InteropServices;
using Pro.Common.Utility;
using Pro.Common.Win32;

namespace Pro.Common.FileSystem;

public static class KnownFolderExtensions
{
	public static string? GetPath(this KnownFolder knownFolder)
	{
		if (WindowsFunctions.SHGetKnownFolderPath(Guid.Parse(knownFolder.GetEnumDescription()), 0u, IntPtr.Zero, out var ppszPath) < 0)
		{
			throw new Exception("Failed to get known folder");
		}
		string? result = Marshal.PtrToStringUni(ppszPath);
		Marshal.FreeCoTaskMem(ppszPath);
		return result;
	}
}
