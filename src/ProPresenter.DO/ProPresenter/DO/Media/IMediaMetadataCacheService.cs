using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media.Imaging;

namespace ProPresenter.DO.Media;

public interface IMediaMetadataCacheService
{
	bool TryGetCachedMetadata(MediaMetadataRequest metadataRequest, [NotNullWhen(true)] out string? previewImagePath, [NotNullWhen(true)] out MediaMetadata? mediaMetadata);

	void CacheMetadata(MediaMetadataRequest metadataRequest, MediaMetadata? mediaMetadata, BitmapSource? previewImage, Guid? thumbnail = null);

	void RemoveOrphanedThumbnailFiles();
}
