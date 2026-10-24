using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProPresenter.DO.Media;

public interface IMediaMetadataCacheRepository : IDisposable
{
	bool TryGetCachedMetadata(string key, string fingerprint, [NotNullWhen(true)] out string? thumbnail, [NotNullWhen(true)] out MediaMetadata? mediaMetadata);

	void CacheMetadata(string key, string fingerprint, string thumbnail, MediaMetadata mediaMetadata);

	void RemoveCachedMetadata(string key, string fingerprint);

	IReadOnlyCollection<string> GetAllThumbnailFilenames();
}
