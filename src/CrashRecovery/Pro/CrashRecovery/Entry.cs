using System;
using System.Diagnostics;
using System.IO;

namespace Pro.CrashRecovery;

public static class Entry
{
	private const int NormalExitCode = 0;

	private const int InvalidArgsCode = -1;

	private const int ErrorExitCode = -2;

	[STAThread]
	public static int Main(string[] args)
	{
		try
		{
			if (args.Length != 4)
			{
				return -1;
			}
			string text = args[0];
			string text2 = args[1];
			string arguments = args[2];
			string text3 = args[3];
			if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3))
			{
				return -1;
			}
			if (new CrashWindow
			{
				AppName = text,
				CrashDetails = File.ReadAllText(text3)
			}.ShowDialog() == true)
			{
				Process.Start(new ProcessStartInfo(text2, arguments)
				{
					UseShellExecute = true
				});
			}
		}
		catch
		{
			return -2;
		}
		return 0;
	}
}
