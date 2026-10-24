using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Downloads;
using Pro.Common.Nullability;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.ProContent.Model.Download;

namespace ProPresenter.DO.ProContent.Downloads;

public sealed class ProContentDownloadItem : DownloadItemBase, IProContentDownloadItem, IDownloadItem, IDisposable
{
	private const string ValidHexCharacters = "0123456789ABCDEFabcdef";

	private readonly IFileSystem _fileSystem;

	private readonly IProContentDownloadDataRefresher _downloadDataRefresher;

	private readonly BehaviorSubject<ProContentFileDownload> _downloadData;

	public override IObservable<string> WhenNameChanged => _downloadData.Select((ProContentFileDownload d) => d.DisplayName);

	public override IObservable<Uri> WhenThumbnailUrlChanged => _downloadData.Select((ProContentFileDownload d) => d.ThumbnailUrl);

	protected override Func<IEnumerable<KeyValuePair<string, IEnumerable<string>>>, Task<bool>>? IsDuplicate => IsFileAlreadyLoaded;

	protected override string DownloadUrl => _downloadData.Value.DownloadUrl.ToString();

	public string AssetIdentifier => _downloadData.Value.AssetIdentifier;

	public ProContentDownloadItem(ProContentFileDownload downloadData, IDownloadProcessFactory processFactory, IFileService fileService, IFileSystem fileSystem, IProContentDownloadDataRefresher downloadDataRefresher)
		: base(processFactory, fileService, fileSystem)
	{
		_downloadData = new BehaviorSubject<ProContentFileDownload>(downloadData);
		_fileSystem = fileSystem;
		_downloadDataRefresher = downloadDataRefresher;
	}

	public override void Retry()
	{
		if (CanRetry())
		{
			TryDownloadLocked(DoRetryAsyncUnsafe);
		}
	}

	public override bool CanRetry()
	{
		return base.Status == DownloadStatus.Stopped;
	}

	public bool MatchesActiveDownload(ProContentFileDownload other)
	{
		DownloadStatus status = base.Status;
		if ((uint)status <= 1u)
		{
			return _downloadData.Value.RelativePath == other.RelativePath;
		}
		return false;
	}

	protected override string GetImportDestination()
	{
		return CreateProContentFileDestination(_downloadData.Value.RelativePath);
	}

	private string CreateProContentFileDestination(string relativePath)
	{
		relativePath = relativePath.TrimStart(_fileSystem.Path.DirectorySeparatorChar, _fileSystem.Path.AltDirectorySeparatorChar);
		string text = _fileSystem.Path.Combine(CommonPaths.ProContentAssets, relativePath);
		string directoryName = _fileSystem.Path.GetDirectoryName(text);
		if (!directoryName.NullableIsNullOrEmpty())
		{
			_fileSystem.Directory.CreateDirectory(directoryName);
		}
		return text;
	}

	private async Task DoRetryAsyncUnsafe(CancellationToken token)
	{
		ProContentFileDownload proContentFileDownload = await _downloadDataRefresher.RefreshDownloadData(_downloadData.Value);
		if (proContentFileDownload != null)
		{
			_downloadData.OnNext(proContentFileDownload);
			await DoDownloadAsyncUnsafe(token);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_downloadData.Dispose();
		}
		base.Dispose(disposing);
	}

	private async Task<bool> IsFileAlreadyLoaded(IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
	{
		foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
		{
			if (header.Key == "ETag")
			{
				return await IsFileAlreadyLoaded(string.Join("", header.Value));
			}
		}
		return false;
	}

	private async Task<bool> IsFileAlreadyLoaded(string etag)
	{
		ReadOnlySpan<char> readOnlySpan = MemoryExtensions.Trim(MemoryExtensions.AsSpan(etag), '"');
		if (readOnlySpan.Length % 2 != 0)
		{
			return false;
		}
		if (MemoryExtensions.ContainsAnyExcept<char>(readOnlySpan, (ReadOnlySpan<char>)"0123456789ABCDEFabcdef"))
		{
			return false;
		}
		string localFilePath = GetImportDestination();
		if (!_fileSystem.File.Exists(localFilePath))
		{
			return false;
		}
		byte[] etagBytes = Convert.FromHexString(readOnlySpan);
		return etagBytes.SequenceEqual(await Task.Run(() => ComputeHash(localFilePath)));
	}

	private byte[] ComputeHash(string fileName)
	{
		using MD5 mD = MD5.Create();
		using FileSystemStream inputStream = _fileSystem.File.OpenRead(fileName);
		return mD.ComputeHash(inputStream);
	}
}
