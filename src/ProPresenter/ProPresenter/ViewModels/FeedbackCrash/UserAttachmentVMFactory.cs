using System.IO.Abstractions;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.Reporting;
using Pro.Reporting.UserFeedback;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.UserAttachments;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.UserAttachments;
using ProPresenter.ViewModels.UserAttachments;

namespace ProPresenter.ViewModels.FeedbackCrash;

public class UserAttachmentVMFactory : IUserAttachmentVMFactory
{
	private readonly IUserFeedbackConsumer _apiConsumer;

	private readonly ILogger _logger;

	private readonly IFileSystem _fileSystem;

	private readonly IProcessHelper _processHelper;

	private readonly IBuildAppMetaDataFile _buildAppMetaDataFile;

	private readonly ISystemInfoProvider _systemInfoProvider;

	private readonly IWorkspaceService _workspaceService;

	public UserAttachmentVMFactory(IUserFeedbackConsumer apiConsumer, ILogger logger, IFileSystem fileSystem, IProcessHelper processHelper, IBuildAppMetaDataFile buildAppMetaDataFile, ISystemInfoProvider systemInfoProvider, IWorkspaceService workspaceService, ICommonPathsWrapper commonPathsWrapper)
	{
		_apiConsumer = apiConsumer;
		_logger = logger;
		_fileSystem = fileSystem;
		_processHelper = processHelper;
		_buildAppMetaDataFile = buildAppMetaDataFile;
		_systemInfoProvider = systemInfoProvider;
		_workspaceService = workspaceService;
	}

	public IUserAttachmentCollectionVM CreateUserAttachmentCollectionVM(IUserAttachSettings userAttachSettings)
	{
		return new UserAttachmentCollectionVM(_fileSystem, this, userAttachSettings, _logger);
	}

	public IUserAttachmentsVM CreateUserAttachmentsVM(IUserAttachmentCollectionVM attachments)
	{
		return new UserAttachmentsVM(attachments, _apiConsumer, _logger, _fileSystem, _processHelper, _buildAppMetaDataFile, _systemInfoProvider, _workspaceService);
	}

	public IUserAttachment CreateUserAttachmentVM(string file, bool isReadOnly = false)
	{
		return new UserAttachmentVM(file, isReadOnly);
	}
}
