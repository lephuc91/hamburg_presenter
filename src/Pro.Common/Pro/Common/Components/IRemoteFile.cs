using System;
using System.IO;

namespace Pro.Common.Components;

public interface IRemoteFile
{
	string Filename { get; }

	void DownloadFile(Action<FileInfo> downloadComplete);
}
