using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Security;
using Pro.Common.Utility;

namespace ProPresenter.DO.Librarian;

public class PresentationMetadataCache : DisposableBase, IPresentationMetadataCache, IDisposable
{
	private readonly IPresentationMetadataRepository _metadataCacheRepository;

	public PresentationMetadataCache(IPresentationMetadataRepository metadataCacheRepository)
	{
		_metadataCacheRepository = metadataCacheRepository;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			_metadataCacheRepository.Dispose();
		}
	}

	public bool TryGetCachedMetadata(string filename, [NotNullWhen(true)] out PresentationMetadata? presentationMetadata)
	{
		presentationMetadata = null;
		if (string.IsNullOrWhiteSpace(filename))
		{
			return false;
		}
		string key = BuildKeyFromFilename(filename);
		string fingerprint = BuildFingerprintFromFilename(filename);
		if (_metadataCacheRepository.TryGetCachedMetadata(key, fingerprint, out presentationMetadata))
		{
			return true;
		}
		Log.Info("Presentation metadata wasn't found in the cache [{0}]", filename);
		return false;
	}

	public void CacheMetadata(string filename, PresentationMetadata presentationMetadata)
	{
		if (!string.IsNullOrWhiteSpace(filename) && presentationMetadata != null)
		{
			string key = BuildKeyFromFilename(filename);
			string fingerprint = BuildFingerprintFromFilename(filename);
			_metadataCacheRepository.CacheMetadata(key, fingerprint, presentationMetadata);
			Log.Info("Saved presentation metadata into cache [{0}]", filename);
		}
	}

	private static string BuildKeyFromFilename(string filename)
	{
		return filename.Hash();
	}

	private static string BuildFingerprintFromFilename(string filename)
	{
		FileInfo fileInfo = new FileInfo(filename);
		string data;
		if (!fileInfo.Exists)
		{
			global::_003C_003Ey__InlineArray2<string> buffer = default(global::_003C_003Ey__InlineArray2<string>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<string>, string>(ref buffer, 0) = filename;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<string>, string>(ref buffer, 1) = "NOT_FOUND";
			data = string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<string>, string>(in buffer, 2));
		}
		else
		{
			global::_003C_003Ey__InlineArray5<object> buffer2 = default(global::_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 0) = filename;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 1) = "EXISTS";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 2) = fileInfo.Length;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 3) = fileInfo.CreationTimeUtc.ToUnixTimestamp();
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 4) = fileInfo.LastWriteTimeUtc.ToUnixTimestamp();
			data = string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray5<object>, object>(in buffer2, 5));
		}
		return data.Hash();
	}
}
