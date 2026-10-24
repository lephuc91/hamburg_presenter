using System.IO.Abstractions;
using Pro.Common.HTTP;
using Pro.Common.Logging;

namespace Pro.Reporting.UserFeedback.AttachmentUpload;

public sealed class AttachmentUploadJobFactory : IAttachmentUploadJobFactory
{
	private readonly IRestClientFactory _restClientFactory;

	private readonly IFileSystem _fileSystem;

	private readonly ILogger _logger;

	public AttachmentUploadJobFactory(IRestClientFactory restClientFactory, IFileSystem fileSystem, ILogger logger)
	{
		_restClientFactory = restClientFactory;
		_fileSystem = fileSystem;
		_logger = logger;
	}

	public IAttachmentUploadJob CreateAttachmentUploadJob(AttachmentUploadDefinition uploadDefinition, int numberOfRetries = 3, int timeoutSeconds = 300)
	{
		return new AttachmentUploadJob(uploadDefinition, _restClientFactory, _fileSystem, _logger, numberOfRetries, timeoutSeconds);
	}
}
