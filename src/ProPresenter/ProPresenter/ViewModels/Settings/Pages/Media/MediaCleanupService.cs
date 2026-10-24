using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.UI.Utility;
using ProPresenter.DO.Analytics.Events.TrackedEvents.MediaCleanupSize;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public class MediaCleanupService : IMediaCleanupService
{
	private readonly IMediaCleanupPrompt _mediaCleanupPrompt;

	private readonly IFileSystem _fileSystem;

	private readonly ILogger _logger;

	private readonly IMediaFilesProvider _mediaFilesProvider;

	private readonly IMediaCleanupSizeEventPublisher _mediaCleanupSizeEventPublisher;

	private readonly IFileUtility _fileUtility;

	private readonly IFileSelectorService _fileSelector;

	public MediaCleanupService(IMediaCleanupPrompt mediaCleanupPrompt, IFileSystem fileSystem, ILogger logger, IMediaFilesProvider mediaFilesProvider, IMediaCleanupSizeEventPublisher mediaCleanupSizeEventPublisher, IFileUtility fileUtility, IFileSelectorService fileSelector)
	{
		_mediaCleanupPrompt = mediaCleanupPrompt;
		_fileSystem = fileSystem;
		_logger = logger;
		_mediaFilesProvider = mediaFilesProvider;
		_mediaCleanupSizeEventPublisher = mediaCleanupSizeEventPublisher;
		_fileUtility = fileUtility;
		_fileSelector = fileSelector;
	}

	public async Task CleanUpMediaFilesAsync()
	{
		IEnumerable<string> enumerable = await _mediaFilesProvider.GetUnlinkedMediaFilesAsync();
		if (!enumerable.Any())
		{
			_mediaCleanupPrompt.ShowInformation();
			return;
		}
		MediaCleanupButtons? mediaCleanupButtons = _mediaCleanupPrompt.ConfirmDeletion();
		if (mediaCleanupButtons.HasValue)
		{
			switch (mediaCleanupButtons.GetValueOrDefault())
			{
			case MediaCleanupButtons.MoveToTrash:
				await MoveToTrash(enumerable);
				break;
			case MediaCleanupButtons.MoveToFolder:
				await MoveToFolder(enumerable);
				break;
			}
		}
	}

	private async Task MoveToTrash(IEnumerable<string> unlinkedMediaFiles)
	{
		PublishTotalBytesDeleted(await DeleteFiles(unlinkedMediaFiles, _fileUtility.MoveToRecycleBin));
	}

	private async Task MoveToFolder(IEnumerable<string> unlinkedMediaFiles)
	{
		if (_fileSelector.SelectFolderPath(out string folder))
		{
			PublishTotalBytesDeleted(await DeleteFiles(unlinkedMediaFiles, async (string f) => await _fileUtility.MoveToFolder(f, folder)));
		}
	}

	private async Task<ulong> DeleteFiles(IEnumerable<string> files, Func<string, Task<bool>> doDelete)
	{
		ulong totalBytesDeleted = 0uL;
		Task[] tasks = files.Select((Func<string, Task>)async delegate(string file)
		{
			try
			{
				IFileInfo fileInfo = _fileSystem.FileInfo.New(file);
				long fileSize = fileInfo.Length;
				if (await doDelete(file))
				{
					totalBytesDeleted += (ulong)fileSize;
				}
			}
			catch (Exception value)
			{
				_logger.Error($"Error deleting file '{file}': {value}");
			}
		}).ToArray();
		try
		{
			await Task.WhenAll(tasks);
		}
		catch (AggregateException ex)
		{
			foreach (Exception innerException in ex.InnerExceptions)
			{
				_logger.Error($"An unexpected error occurred while deleting unlinked media files: {innerException}");
			}
		}
		return totalBytesDeleted;
	}

	private void PublishTotalBytesDeleted(ulong totalBytesDeleted)
	{
		_mediaCleanupSizeEventPublisher.Publish(totalBytesDeleted);
	}
}
