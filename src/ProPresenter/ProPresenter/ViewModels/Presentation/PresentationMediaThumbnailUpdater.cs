using System.IO;
using System.Linq;
using Pro.Common.Nullability;
using ProPresenter.DO;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;

namespace ProPresenter.ViewModels.Presentation;

public class PresentationMediaThumbnailUpdater : IPresentationMediaThumbnailUpdater
{
	private readonly IPresentation? _presentation;

	public PresentationMediaThumbnailUpdater(IPresentation? presentation)
	{
		_presentation = presentation;
	}

	public void UpdateThumbnail(string mediaFile)
	{
		if (mediaFile.NullableIsNullOrEmpty() || _presentation == null)
		{
			return;
		}
		foreach (FileMediaBase item in _presentation.FindMedia().OfType<FileMediaBase>())
		{
			string? fullPath = item.SourceFile.FullPath;
			if (fullPath != null && fullPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).Contains(CommonPaths.MediaAssets) && mediaFile == item.SourceFile.Filename && item is VisualMedia visualMedia)
			{
				visualMedia.UpdateSource(userInitiated: true, item.SourceFile);
			}
		}
	}
}
