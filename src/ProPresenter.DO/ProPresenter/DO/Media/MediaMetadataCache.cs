using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Media.Imaging;
using Pro.Common.Logging;
using Pro.Common.Utility;

namespace ProPresenter.DO.Media;

public class MediaMetadataCache : IMediaMetadataCacheService
{
	private readonly IMediaMetadataCacheRepository _metadataCacheRepository;

	public MediaMetadataCache(IMediaMetadataCacheRepository metadataCacheRepository)
	{
		_metadataCacheRepository = metadataCacheRepository;
	}

	public bool TryGetCachedMetadata(MediaMetadataRequest metadataRequest, [NotNullWhen(true)] out string? previewImagePath, [NotNullWhen(true)] out MediaMetadata? mediaMetadata)
	{
		previewImagePath = null;
		mediaMetadata = null;
		if (metadataRequest == null)
		{
			return false;
		}
		string key = metadataRequest.BuildKey();
		string fingerprint = metadataRequest.BuildFingerprint();
		if (_metadataCacheRepository.TryGetCachedMetadata(key, fingerprint, out string thumbnail, out mediaMetadata))
		{
			thumbnail = Path.Combine(CommonPaths.ThumbnailCache, thumbnail);
			if (File.Exists(thumbnail))
			{
				previewImagePath = thumbnail;
				return true;
			}
			_metadataCacheRepository.RemoveCachedMetadata(key, fingerprint);
			return false;
		}
		Log.Info("Media metadata wasn't found in the cache [{0}]", metadataRequest.Filename);
		return false;
	}

	public void CacheMetadata(MediaMetadataRequest metadataRequest, MediaMetadata? mediaMetadata, BitmapSource? previewImage, Guid? thumbnail = null)
	{
		if ((object)mediaMetadata == null || previewImage == null)
		{
			return;
		}
		Guid valueOrDefault = thumbnail.GetValueOrDefault();
		if (!thumbnail.HasValue)
		{
			valueOrDefault = Guid.NewGuid();
			thumbnail = valueOrDefault;
		}
		string targetFilename = Path.Combine(CommonPaths.ThumbnailCache, thumbnail.ToString());
		try
		{
			previewImage.TryWriteImage(targetFilename);
			string key = metadataRequest.BuildKey();
			string fingerprint = metadataRequest.BuildFingerprint();
			_metadataCacheRepository.CacheMetadata(key, fingerprint, thumbnail.ToString(), mediaMetadata);
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}

	public void RemoveOrphanedThumbnailFiles()
	{
		if (!Directory.Exists(CommonPaths.ThumbnailCache))
		{
			return;
		}
		try
		{
			HashSet<string> hashSet = new HashSet<string>(_metadataCacheRepository.GetAllThumbnailFilenames(), StringComparer.OrdinalIgnoreCase);
			foreach (string item in Directory.EnumerateFiles(CommonPaths.ThumbnailCache))
			{
				string fileName = Path.GetFileName(item);
				if (!hashSet.Contains(fileName) && !string.Equals(fileName, "cache.sqlite3", StringComparison.OrdinalIgnoreCase))
				{
					try
					{
						File.Delete(item);
					}
					catch (Exception ex)
					{
						Log.Error("[{0}] Failed to delete orphaned thumbnail file '{1}': {2}", "MediaMetadataCache", item, ex.Message);
					}
				}
			}
		}
		catch (Exception ex2)
		{
			Log.Error("[{0}] Failed to remove orphaned thumbnail files: {1}", "MediaMetadataCache", ex2.Message);
		}
	}
}
