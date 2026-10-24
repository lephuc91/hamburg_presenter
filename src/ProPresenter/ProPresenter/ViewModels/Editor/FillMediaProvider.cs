using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Storage;
using Pro.UI.Utility;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;

namespace ProPresenter.ViewModels.Editor;

public class FillMediaProvider : IMediaProvider
{
	private readonly IMediaValidator _mediaValidator;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private readonly Func<string> _getFileFilter;

	private readonly Func<string?> _getMediaRoot;

	public FillMediaProvider(IMediaValidator mediaValidator, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, Func<string> getFileFilter, Func<string?> getMediaRoot)
	{
		_mediaValidator = mediaValidator;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactory;
		_getFileFilter = getFileFilter;
		_getMediaRoot = getMediaRoot;
	}

	public void GetMedia(string containerId, Action<MediaBase?> mediaCallback)
	{
		if (DialogHelper.SelectFile(out string selectedFile, _getFileFilter()))
		{
			GetMedia(containerId, null, selectedFile.ToEnumerable(), mediaCallback);
		}
		else
		{
			mediaCallback(null);
		}
	}

	public void GetMedia(MediaBase currentMedia, Action<MediaBase?> mediaCallback)
	{
		if (DialogHelper.SelectFile(out string selectedFile, _getFileFilter()))
		{
			GetMedia(null, currentMedia, selectedFile.ToEnumerable(), mediaCallback);
		}
		else
		{
			mediaCallback(null);
		}
	}

	public void GetMedia(string containerId, IEnumerable<string>? files, Action<MediaBase> mediaCallback)
	{
		GetMedia(containerId, null, files, mediaCallback);
	}

	public void GetMedia(MediaBase currentMedia, IEnumerable<string>? files, Action<MediaBase> mediaCallback)
	{
		GetMedia(null, currentMedia, files, mediaCallback);
	}

	private void GetMedia(string? containerId, MediaBase? currentMedia, IEnumerable<string>? files, Action<MediaBase> mediaCallback)
	{
		List<FileImportRequest> list = new List<FileImportRequest>();
		IMediaFactory mediaFactory = _mediaFactory;
		foreach (string item in files ?? Enumerable.Empty<string>())
		{
			list.Add(new FileImportRequest(item, delegate(string _, string n, FileMediaBase? createdMedia)
			{
				if (_mediaValidator == null || _mediaValidator.IsValid(n))
				{
					FileMediaBase fileMediaBase = createdMedia ?? mediaFactory.CreateEmptyFileMedia(n, containerId ?? (currentMedia as IFileMedia)?.ContainerId ?? string.Empty, null);
					mediaCallback?.Invoke(fileMediaBase);
					if (currentMedia != null)
					{
						fileMediaBase.TransposeProperties(currentMedia);
					}
					if (fileMediaBase is VisualMedia visualMedia)
					{
						visualMedia.SetThumbnailToFullSize();
					}
					if (createdMedia == null)
					{
						fileMediaBase.UpdateSource(userInitiated: true, (RelativePath)n);
					}
				}
			})
			{
				TargetFolder = _getMediaRoot(),
				ContainerId = (containerId ?? (currentMedia as IFileMedia)?.ContainerId ?? string.Empty)
			});
		}
		_importProcessFactory.Create(list).StartImport();
	}
}
