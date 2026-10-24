using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Threading;
using Newtonsoft.Json;
using Pro.Common.Background;
using Pro.Common.Logging;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Web;
using RestSharp;

namespace ProPresenter.DO.Media.Sample;

public class SampleContentClient
{
	private double _currentBytes;

	private double _totalDownloadSize;

	private readonly Queue<DownloadData> _downloadQueue = new Queue<DownloadData>();

	private readonly IWebSourceProvider _webSource;

	private Action<double>? _totalProgressCallback;

	private Action<DownloadData>? _completedCallback;

	private Action<IEnumerable<DownloadData>>? _allCompleteCallback;

	private DownloadData? _inProgress;

	private readonly List<DownloadData> _downloadedFiles = new List<DownloadData>();

	private int _totalItemCount;

	private int _completedItemCount;

	private double _currentFileProgress;

	public SampleContentClient(IWebSourceProvider webSource)
	{
		_webSource = webSource;
	}

	public void DownloadContents(SampleContents contents, Action<double> progressCallback, Action<DownloadData>? completedCallback, Action<IEnumerable<DownloadData>>? allCompleteCallback, Dispatcher? dispatcher = null)
	{
		_downloadQueue.Clear();
		_totalProgressCallback = progressCallback;
		_completedCallback = completedCallback;
		_allCompleteCallback = allCompleteCallback;
		_totalDownloadSize = 0.0;
		_downloadedFiles.Clear();
		_totalDownloadSize += GetDownloadSize(contents.LibraryData);
		_totalDownloadSize += GetDownloadSize(contents.MediaData);
		EnqueueDownload(contents.LibraryData, PlaylistLocation.Library, dispatcher);
		EnqueueDownload(contents.MediaData, PlaylistLocation.MediaBin, dispatcher);
		_totalItemCount = _downloadQueue.Count;
		_completedItemCount = 0;
		if (_downloadQueue.Count == 0)
		{
			allCompleteCallback?.Invoke(_downloadedFiles);
			return;
		}
		_inProgress = _downloadQueue.Dequeue();
		_inProgress.FileDownload.StartDownload();
	}

	private double GetDownloadSize(SampleData[]? data)
	{
		double num = 0.0;
		if (data != null)
		{
			foreach (SampleData sampleData in data)
			{
				switch (sampleData.Type)
				{
				case SampleType.Group:
					num += GetDownloadSize(sampleData.Children ?? Array.Empty<SampleData>());
					break;
				case SampleType.Content:
					num += (double)sampleData.DownloadSize;
					break;
				}
			}
		}
		return num;
	}

	public void EnqueueDownload(SampleData[]? sampleData, PlaylistLocation location, Dispatcher? dispatcher)
	{
		if (sampleData == null || !sampleData.Any())
		{
			return;
		}
		foreach (SampleData sampleData2 in sampleData)
		{
			switch (sampleData2.Type)
			{
			case SampleType.Group:
			{
				IEnumerable<SampleData> children = sampleData2.Children;
				foreach (SampleData item in children ?? Enumerable.Empty<SampleData>())
				{
					if (item != null && !string.IsNullOrWhiteSpace(item.ResourceKey))
					{
						EnqueueDownload(item, location, dispatcher);
					}
				}
				break;
			}
			case SampleType.Content:
				if (!string.IsNullOrWhiteSpace(sampleData2.ResourceKey))
				{
					EnqueueDownload(sampleData2, location, dispatcher);
				}
				break;
			}
		}
	}

	public void EnqueueDownload(SampleData data, PlaylistLocation location, Dispatcher? dispatcher)
	{
		string tempFile = ImportHelper.GetTempFile((location == PlaylistLocation.Library) ? ".proPlaylist" : ".sampleContent");
		WebFileDownload fileDownload = new WebFileDownload(_webSource.GenerateSampleContentDownloadLink(data.ResourceKey ?? string.Empty).ToString(), tempFile, BytesReceivedCallback, FileProgressCallback, CompletedCallback, dispatcher);
		_downloadQueue.Enqueue(new DownloadData(data, fileDownload, location, tempFile));
	}

	private void FileProgressCallback(double percentage)
	{
		_currentFileProgress = percentage;
		if (_totalDownloadSize <= 0.0 && _totalItemCount > 0)
		{
			_totalProgressCallback?.Invoke(((double)_completedItemCount + _currentFileProgress) / (double)_totalItemCount);
		}
	}

	private void BytesReceivedCallback(double bytesIn)
	{
		if (_totalDownloadSize > 0.0)
		{
			_totalProgressCallback?.Invoke((_currentBytes + bytesIn) / _totalDownloadSize);
		}
	}

	private void CompletedCallback(string fileDestination, bool success)
	{
		if (_inProgress != null)
		{
			_inProgress.Success = success;
			_completedItemCount++;
			_currentFileProgress = 0.0;
			_downloadedFiles.Add(_inProgress);
			_completedCallback?.Invoke(_inProgress);
			if (success)
			{
				_currentBytes += _inProgress.Data.DownloadSize;
			}
			else
			{
				_currentBytes -= _inProgress.Data.DownloadSize;
				_totalDownloadSize -= _inProgress.Data.DownloadSize;
			}
		}
		if (_downloadQueue.Any())
		{
			_inProgress = _downloadQueue.Dequeue();
			_inProgress.FileDownload.StartDownload();
		}
		else
		{
			_allCompleteCallback?.Invoke(_downloadedFiles);
		}
	}

	public void Cancel()
	{
		_downloadQueue.Clear();
		_downloadedFiles.Clear();
		_currentBytes = 0.0;
		_totalItemCount = 0;
		_completedItemCount = 0;
		_currentFileProgress = 0.0;
		_inProgress = null;
		_totalProgressCallback = null;
		_completedCallback = null;
		_allCompleteCallback = null;
	}

	public void GetSampleData(Action<SampleContents?> contentsCallback, Dispatcher? dispatcher = null)
	{
		dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
		SharedWorkerPool.Queue.AddJob(delegate
		{
			RestRequest request = new RestRequest();
			RestResponse restResponse = new RestClient(_webSource.SampleContentData).Execute(request);
			if (restResponse.StatusCode == HttpStatusCode.OK)
			{
				SampleContents sampleContents = JsonConvert.DeserializeObject<SampleContents>(restResponse.Content ?? string.Empty);
				Dispatcher? obj = dispatcher;
				if (obj != null)
				{
					obj.InvokeAsync((Action)delegate
					{
						contentsCallback?.Invoke(sampleContents);
					});
				}
			}
			else
			{
				Log.Error($"Error trying to get sample contents with code: {restResponse.StatusCode}");
				if (restResponse.StatusDescription != null)
				{
					Log.Error(restResponse.StatusDescription);
				}
				Dispatcher? obj2 = dispatcher;
				if (obj2 != null)
				{
					obj2.InvokeAsync((Action)delegate
					{
						contentsCallback?.Invoke(null);
					});
				}
			}
		});
	}
}
