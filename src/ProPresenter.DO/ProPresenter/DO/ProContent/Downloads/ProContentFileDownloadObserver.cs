using System;
using System.IO.Abstractions;
using Pro.Common.Collections;
using Pro.Common.Downloads;
using Pro.Common.FileSystem;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.ProContent.Downloads;

public class ProContentFileDownloadObserver : IFileDownloadObserver
{
	private readonly VisualPlaylist _playlist;

	private readonly Action<ProContentDownloadObserveCallbackData>? _downloadObserveCallback;

	public MediaCue MediaCue { get; }

	public MediaCue Cloned { get; }

	public ProContentFileDownloadObserver(ProContentFileDownload fileDownload, VisualPlaylist playlist, Action<IDownloadObserverCallbackData>? importCallback, IFileSystem fileSystem, IImport import, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		MediaCue = CreateMediaCue(fileDownload, fileSystem, import, app, mediaFactory, transitionDescriptions);
		Cloned = (MediaCue)MediaCue.Clone();
		_playlist = playlist;
		_downloadObserveCallback = importCallback;
	}

	private static MediaCue CreateMediaCue(ProContentFileDownload fileDownload, IFileSystem fileSystem, IImport import, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		string text = CreateProContentFileDestination(fileDownload.RelativePath, fileSystem);
		ProContentDownloadAssetType assetType = fileDownload.AssetType;
		string fileNameWithoutExtension = fileSystem.Path.GetFileNameWithoutExtension(text);
		MediaCue mediaCue = new MediaCue(app, mediaFactory.CreateVisualMedia("", null), transitionDescriptions)
		{
			Name = fileNameWithoutExtension
		};
		if (text.IsVisualMediaFile())
		{
			mediaCue = new MediaCue(new MediaAction(mediaFactory.CreateEmptyFileMedia(text, "", null), app, transitionDescriptions))
			{
				Name = fileNameWithoutExtension
			};
		}
		ProContentDownloadAssetType proContentDownloadAssetType = assetType;
		ProContentDownloadAssetType proContentDownloadAssetType2 = proContentDownloadAssetType;
		if (proContentDownloadAssetType2.HasFlag(ProContentDownloadAssetType.Loop))
		{
			if (mediaCue.MediaAction != null)
			{
				mediaCue.MediaAction.TriggerLayer = TriggerLayer.Background;
				if (mediaCue.MediaAction.VideoMedia != null)
				{
					mediaCue.MediaAction.VideoMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Loop;
					mediaCue.MediaAction.VideoMedia.Drawing.ScaleBehavior = ScaleBehavior.ScaleToFill;
				}
			}
		}
		else
		{
			ProContentDownloadAssetType proContentDownloadAssetType3 = proContentDownloadAssetType;
			if (proContentDownloadAssetType3.HasFlag(ProContentDownloadAssetType.Countdown))
			{
				if (mediaCue.MediaAction != null)
				{
					mediaCue.MediaAction.TriggerLayer = TriggerLayer.Foreground;
					if (mediaCue.MediaAction.VideoMedia != null)
					{
						mediaCue.MediaAction.VideoMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
						mediaCue.MediaAction.VideoMedia.Drawing.ScaleBehavior = ScaleBehavior.ScaleToFill;
					}
				}
			}
			else
			{
				import.ApplyImportSettings(mediaCue);
			}
		}
		mediaCue.MediaAction?.FileMedia?.UpdateSource(userInitiated: false, new RelativePath(text));
		if (mediaCue.MediaAction?.Media is IFileMedia fileMedia)
		{
			fileMedia.File.RemoteProperties = new ProContentFileProperties(fileDownload.AssetIdentifier);
		}
		return mediaCue;
	}

	private static string CreateProContentFileDestination(string relativePath, IFileSystem fileSystem)
	{
		relativePath = relativePath.TrimStart(fileSystem.Path.DirectorySeparatorChar, fileSystem.Path.AltDirectorySeparatorChar);
		return fileSystem.Path.Combine(CommonPaths.ProContentAssets, relativePath);
	}

	public void Observe(IDownloadItem downloadItem)
	{
		AddCueToPlaylist(MediaCue, Cloned);
		downloadItem.WhenDownloadProgressChanged.Subscribe(delegate(DownloadProgress d)
		{
			if (d.Status == DownloadStatus.Cleanup)
			{
				RemoveCueFromPlaylist(MediaCue, Cloned);
			}
		});
	}

	private void AddCueToPlaylist(MediaCue mediaCue, MediaCue cloned)
	{
		_playlist.AddItem(mediaCue);
		_downloadObserveCallback?.Invoke(new ProContentDownloadObserveCallbackData(cloned));
	}

	private void RemoveCueFromPlaylist(MediaCue mediaCue, MediaCue cloned)
	{
		_playlist.RemoveCues(mediaCue.ToEnumerable(), isReversible: false);
		_downloadObserveCallback?.Invoke(new ProContentDownloadObserveCallbackData(cloned, Cleanup: true));
	}
}
