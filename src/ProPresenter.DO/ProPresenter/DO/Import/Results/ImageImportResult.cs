using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Dispatcher;
using Pro.DO.Storage;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Import.Results;

public class ImageImportResult : IImportResult
{
	private readonly IMediaFactory _mediaFactory;

	private readonly IEnumerable<string> _images;

	private readonly IPresentationFactory _presentationFactory;

	private readonly ISizeProvider _sizeProvider;

	public ImageImportResult(IMediaFactory mediaFactory, IEnumerable<string> images, IPresentationFactory presentationFactory, ISizeProvider sizeProvider)
	{
		_mediaFactory = mediaFactory;
		_images = images;
		_presentationFactory = presentationFactory;
		_sizeProvider = sizeProvider;
	}

	public string GetTargetFilename(IImportRequest request)
	{
		return string.Empty;
	}

	public void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId)
	{
		Dictionary<MediaBase, Action<MediaBase>> handlers = new Dictionary<MediaBase, Action<MediaBase>>();
		CustomPresentation presentation = _presentationFactory.CreateCustom();
		presentation.Name = Path.GetFileNameWithoutExtension(name);
		presentation.ChangeSize(_sizeProvider.GetSize());
		dispatcher.InvokeAsync(delegate
		{
			foreach (string image in _images)
			{
				RelativePath relativePath = (RelativePath)image;
				if (relativePath.IsValid)
				{
					FileMediaBase media = _mediaFactory.CreateEmptyFileMedia(relativePath, containerId, null);
					handlers.Add(media, delegate(MediaBase m)
					{
						media.MetadataLoadSuccessful -= handlers[media];
						presentation.AddCue().AddMediaElement(m, userInitiated: true);
						handlers.Remove(media);
						if (!handlers.Any())
						{
							process.SelectedLibrary?.Add(presentation, userInitiated: true);
						}
					});
					media.MetadataLoadSuccessful += handlers[media];
					media.UpdateSource(userInitiated: true, relativePath);
				}
			}
		});
	}
}
