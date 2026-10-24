using System.Collections.Generic;
using System.IO;
using Pro.Common.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.UI.Thumbnails;

public class DropMediaFilesCommandParameters : DragDropCommandParameters<SlideCue, CustomPresentation>
{
	public IRemoteFile? RemoteFile { get; }

	public IEnumerable<FileInfo>? Files { get; }

	public DropMediaFilesCommandParameters(CustomPresentation? targetPresentation, SlideCue? targetCue, IRemoteFile remoteFile, bool droppedBefore, bool droppedOutside)
		: base(targetPresentation, (IEnumerable<SlideCue>?)null, targetCue, -1, droppedBefore, droppedOutside, copy: false)
	{
		RemoteFile = remoteFile;
	}

	public DropMediaFilesCommandParameters(CustomPresentation? targetPresentation, SlideCue? targetCue, IEnumerable<FileInfo> files, bool droppedBefore, bool droppedOutside)
		: base(targetPresentation, (IEnumerable<SlideCue>?)null, targetCue, -1, droppedBefore, droppedOutside, copy: false)
	{
		Files = files;
	}
}
