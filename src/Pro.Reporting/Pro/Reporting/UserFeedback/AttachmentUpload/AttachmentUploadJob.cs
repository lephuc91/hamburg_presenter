using System;
using System.CodeDom.Compiler;
using System.IO;
using System.IO.Abstractions;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Async;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using RestSharp;

namespace Pro.Reporting.UserFeedback.AttachmentUpload;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_progressStream", "_uploadSubjects", "_uploadCompleteSubject" })]
public sealed class AttachmentUploadJob : IAttachmentUploadJob, IDisposable
{
	private sealed class ProgressStream : Stream
	{
		private readonly Stream _baseStream;

		private readonly SubjectBase<long> _consumedBytesSubject = new BehaviorSubject<long>(0L);

		public override bool CanRead => _baseStream.CanRead;

		public override bool CanSeek => _baseStream.CanSeek;

		public override bool CanWrite => false;

		public override long Length => _baseStream.Length;

		public override long Position
		{
			get
			{
				return _baseStream?.Position ?? 0;
			}
			set
			{
				if (_baseStream != null)
				{
					_baseStream.Position = value;
				}
			}
		}

		public IObservable<long> WhenConsumedBytesChanged => _consumedBytesSubject;

		public ProgressStream(Stream input)
		{
			_baseStream = input;
		}

		public override void Flush()
		{
			throw new NotImplementedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return _baseStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (_baseStream == null)
			{
				return 0;
			}
			int result = _baseStream.Read(buffer, offset, count);
			_consumedBytesSubject.OnNext(_baseStream.Position);
			return result;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (_baseStream == null)
			{
				return 0;
			}
			int result = await _baseStream.ReadAsync(buffer, offset, count, cancellationToken);
			_consumedBytesSubject.OnNext(_baseStream.Position);
			return result;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		protected override void Dispose(bool disposing)
		{
			_baseStream?.Dispose();
			_consumedBytesSubject.Dispose();
			base.Dispose(disposing);
		}
	}

	private const int MAXIMUM_TIMEOUT_SECONDS = 2147483;

	private readonly AttachmentUploadDefinition _uploadDefinition;

	private readonly IRestClientFactory _restClientFactory;

	private readonly IFileSystem _fileSystem;

	private readonly ILogger _logger;

	private readonly int _numberOfRetries;

	private readonly int _initialTimeoutSeconds;

	private readonly SubjectBase<IObservable<UploadProgress>> _uploadSubjects;

	private readonly SubjectBase<UploadCompletionResult> _uploadCompleteSubject;

	private ProgressStream? _progressStream;

	private Task? _uploadTask;

	private UploadCompletionResult? _uploadResult;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<UploadProgress> WhenUploadProgressChanged => _uploadSubjects.Switch();

	public IObservable<UploadCompletionResult> WhenUploadFinished => _uploadCompleteSubject;

	public AttachmentUploadJob(AttachmentUploadDefinition uploadDefinition, IRestClientFactory restClientFactory, IFileSystem fileSystem, ILogger logger, int numberOfRetries, int initialTimeoutSeconds)
	{
		_uploadDefinition = uploadDefinition;
		_restClientFactory = restClientFactory;
		_fileSystem = fileSystem;
		_logger = logger;
		_numberOfRetries = numberOfRetries;
		_initialTimeoutSeconds = initialTimeoutSeconds;
		_uploadSubjects = new BehaviorSubject<IObservable<UploadProgress>>(Observable.Return(new UploadProgress(0L, _uploadDefinition.FileSize)));
		_uploadCompleteSubject = new Subject<UploadCompletionResult>();
	}

	public void StartUploading(CancellationToken cancellation = default(CancellationToken))
	{
		if (_uploadTask != null)
		{
			throw new InvalidOperationException();
		}
		_uploadTask = DoUploadAsync(cancellation);
	}

	public UploadCompletionResult Upload()
	{
		if (_uploadTask != null)
		{
			throw new InvalidOperationException();
		}
		using PumpingSynchronizationContextExecutor pumpingSynchronizationContextExecutor = new PumpingSynchronizationContextExecutor(() => DoUploadAsync());
		pumpingSynchronizationContextExecutor.Run();
		return _uploadResult ?? new UploadCompletionResult(this, Successful: false);
	}

	private async Task DoUploadAsync(CancellationToken cancellation = default(CancellationToken))
	{
		for (int i = 0; i < _numberOfRetries; i++)
		{
			if (cancellation.IsCancellationRequested)
			{
				return;
			}
			int num = (int)Math.Min(2147483 - _initialTimeoutSeconds, Math.Pow(100.0, i));
			RestRequest restRequest = new RestRequest(_uploadDefinition.UploadUrl, RestSharp.Method.Put)
			{
				Timeout = TimeSpan.FromSeconds(_initialTimeoutSeconds + num)
			};
			restRequest.AlwaysSingleFileAsContent = true;
			_progressStream = new ProgressStream(_fileSystem.File.OpenRead(_uploadDefinition.FilePath));
			_uploadSubjects.OnNext(_progressStream.WhenConsumedBytesChanged.Select((long uploadedBytes) => new UploadProgress(uploadedBytes, _uploadDefinition.FileSize)));
			restRequest.AddFile(_uploadDefinition.FilePath, () => _progressStream, _uploadDefinition.FilePath);
			restRequest.AddHeaders(_uploadDefinition.UploadHeaders);
			if (await ExecuteWithErrorHandlingAsync(restRequest, cancellation).ConfigureAwait(continueOnCapturedContext: false))
			{
				SetUploadResult(success: true);
				return;
			}
		}
		SetUploadResult(success: false);
	}

	private void SetUploadResult(bool success)
	{
		_uploadResult = new UploadCompletionResult(this, success);
		_uploadCompleteSubject.OnNext(_uploadResult);
		_uploadCompleteSubject.OnCompleted();
	}

	private async Task<bool> ExecuteWithErrorHandlingAsync(RestRequest request, CancellationToken cancellationToken)
	{
		using IRestClient client = _restClientFactory.Get(delegate(RestClientOptions options)
		{
			options.Timeout = TimeSpan.FromMilliseconds(2147483647L, 0L);
		});
		try
		{
			RestResponse restResponse = await client.ExecuteAsync(request, cancellationToken);
			if (restResponse.IsSuccessful)
			{
				return true;
			}
			_logger.Warning("[{0}] Failed to post resource {1}. Returned status code: {2}, Returned response status:{4}, returned data: {3}", "AttachmentUploadJob", request.Resource, restResponse.StatusCode, restResponse.Content, restResponse.ResponseStatus);
		}
		catch (Exception ex)
		{
			_logger.Warning("[{0}] Failed to post resource {1}. Exception was thrown:{2}", "AttachmentUploadJob", request.Resource, ex);
		}
		return false;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_progressStream?.Dispose();
			_uploadSubjects.Dispose();
			_uploadCompleteSubject.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_uploadTask?.Wait();
		if (_fileSystem.File.Exists(_uploadDefinition.FilePath))
		{
			try
			{
				_fileSystem.File.Delete(_uploadDefinition.FilePath);
			}
			catch (Exception ex)
			{
				_logger.Warning("Unable to delete file - " + _uploadDefinition.FilePath + " after uploading attachment.");
				_logger.Error(ex);
			}
		}
	}
}
