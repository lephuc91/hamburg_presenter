using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.DO.Storage;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.Helpers;

public class DiskUsageEventHelper(IProPresenterResourceService _resourceService, IFileSystem _fileSystem, IAudienceLookCollection _looks, IAsyncExecutor _executor, IMaskCollection _masks) : IDiskUsageEventHelper
{
	public void PublishDiskUsageEvent()
	{
		_executor.ExecuteAsync(FireAndForgetPublishDiskUsage);
	}

	private async Task FireAndForgetPublishDiskUsage()
	{
		Task<long> bytesOfShowDirectoryFiles = GetBytesOfShowDirectoryFiles();
		Task<long> numberOfMediaAssetFiles = GetNumberOfMediaAssetFiles();
		Task<long> bytesOfMediaAssetFiles = GetBytesOfMediaAssetFiles();
		Task<long> bytesOfUnmanagedMediaAssetFiles = GetBytesOfUnmanagedMediaAssetFiles();
		global::_003C_003Ey__InlineArray4<Task<long>> buffer = default(global::_003C_003Ey__InlineArray4<Task<long>>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<Task<long>>, Task<long>>(ref buffer, 0) = numberOfMediaAssetFiles;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<Task<long>>, Task<long>>(ref buffer, 1) = bytesOfMediaAssetFiles;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<Task<long>>, Task<long>>(ref buffer, 2) = bytesOfShowDirectoryFiles;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<Task<long>>, Task<long>>(ref buffer, 3) = bytesOfUnmanagedMediaAssetFiles;
		long[] array = await Task.WhenAll(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<Task<long>>, Task<long>>(in buffer, 4));
		DiskUsageEvent.Publish((ulong)array[0], (ulong)array[1], (ulong)array[2], (ulong)array[3]);
	}

	private Task<long> GetNumberOfMediaAssetFiles()
	{
		return Task.Run((Func<long>)(() => (!_fileSystem.Directory.Exists(CommonPaths.MediaAssets)) ? 0 : _fileSystem.Directory.GetFiles(CommonPaths.MediaAssets, "*", SearchOption.AllDirectories).Length));
	}

	private Task<long> GetBytesOfMediaAssetFiles()
	{
		return Task.Run(delegate
		{
			long num = 0L;
			if (_fileSystem.Directory.Exists(CommonPaths.MediaAssets))
			{
				IDirectoryInfo directoryInfo = _fileSystem.DirectoryInfo.New(CommonPaths.MediaAssets);
				num += directoryInfo.GetFiles("*", SearchOption.AllDirectories).Sum((IFileInfo fileInfo) => fileInfo.Length);
			}
			return num;
		});
	}

	private Task<long> GetBytesOfUnmanagedMediaAssetFiles()
	{
		return Task.Run(() => (from file in MediaHelper.GetAllMediaFiles(_resourceService, _looks, _masks)
			select new RelativePath(file) into relPath
			where _fileSystem.File.Exists(relPath) && !IsManagedFile(relPath)
			select relPath).Sum((RelativePath relPath) => _fileSystem.FileInfo.New(relPath).Length));
	}

	private async Task<long> GetBytesOfShowDirectoryFiles()
	{
		if (_fileSystem.Directory.Exists(CommonPaths.Libraries))
		{
			IDirectoryInfo dirInfo = _fileSystem.DirectoryInfo.New(CommonPaths.Libraries);
			return await Task.Run(() => dirInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum((IFileInfo file) => file.Length));
		}
		return 0L;
	}

	private static bool IsManagedFile(string filePath)
	{
		return filePath.Replace("//", "/").Contains(CommonPaths.MediaAssets);
	}
}
