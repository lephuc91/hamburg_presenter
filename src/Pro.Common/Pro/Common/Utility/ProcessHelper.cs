using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.Win32;

namespace Pro.Common.Utility;

public class ProcessHelper : IProcessHelper
{
	private const string ExplorerExecutable = "explorer.exe";

	public static event Action? FileNotFound;

	public static bool StartProcess(string? filename, string? arguments = null)
	{
		Log.Info("Starting process: " + filename + " " + arguments);
		filename.ThrowWhenNull("filename");
		try
		{
			if (arguments == null)
			{
				Process.Start(new ProcessStartInfo(filename)
				{
					UseShellExecute = true
				});
			}
			else
			{
				Process.Start(new ProcessStartInfo(filename, arguments)
				{
					UseShellExecute = true
				});
			}
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			return false;
		}
		return true;
	}

	public void OpenFileInExplorer(string fileName)
	{
		ShowFileInExplorer(fileName);
	}

	public static void ShowFileInExplorer(string? path)
	{
		if (path.NullableIsNullOrWhiteSpace() || (!File.Exists(path) && !Directory.Exists(path)))
		{
			Log.Warning("Path could not be resolved: " + (path ?? "(null)"));
			ProcessHelper.FileNotFound?.Invoke();
			return;
		}
		path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
		Log.Info("Starting process: explorer.exe " + path);
		try
		{
			nint num = WindowsFunctions.ILCreateFromPathW(path);
			if (num != IntPtr.Zero)
			{
				try
				{
					Marshal.ThrowExceptionForHR(WindowsFunctions.SHOpenFolderAndSelectItems(num, 0u, IntPtr.Zero, 0u));
					return;
				}
				finally
				{
					WindowsFunctions.ILFree(num);
				}
			}
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}
}
