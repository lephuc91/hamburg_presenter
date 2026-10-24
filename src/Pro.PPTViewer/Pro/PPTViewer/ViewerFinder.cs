using System;
using System.IO;

namespace Pro.PPTViewer;

public static class ViewerFinder
{
	public const string DownloadUrl = "https://renewedvision.com/downloads/pc/PowerPointViewer.exe";

	private const string ViewerLocation = "Microsoft Office\\Office";

	private const string ViewerExecutable = "PPTVIEW.EXE";

	private static readonly int[] SupportedVersions;

	public static bool IsFound { get; }

	public static string ViewerPath { get; }

	static ViewerFinder()
	{
		SupportedVersions = new int[3] { 14, 12, 11 };
		IsFound = false;
		ViewerPath = string.Empty;
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
		int[] supportedVersions = SupportedVersions;
		foreach (int num in supportedVersions)
		{
			string viewerPath = Path.Combine(folderPath, "Microsoft Office\\Office" + num, "PPTVIEW.EXE");
			if (IsValidViewer(viewerPath))
			{
				ViewerPath = viewerPath;
				IsFound = true;
			}
		}
	}

	public static bool IsValidViewer(string viewerPath)
	{
		if (File.Exists(viewerPath))
		{
			return Path.GetFileName(viewerPath) == "PPTVIEW.EXE";
		}
		return false;
	}
}
