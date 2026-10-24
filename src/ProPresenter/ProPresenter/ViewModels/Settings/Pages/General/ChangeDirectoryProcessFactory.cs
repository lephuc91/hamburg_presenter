using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.CoreApplication.Media;
using ProPresenter.DO;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public class ChangeDirectoryProcessFactory : IChangeDirectoryProcessFactory
{
	private readonly IUiDispatcher _uiDispatcher;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IMediaService _mediaService;

	private readonly ICrdtProtoDirectoryFileScanner _crdtProtoDirectoryFileScanner;

	public ChangeDirectoryProcessFactory(IUiDispatcher uiDispatcher, IAsyncExecutor asyncExecutor, IMediaService mediaService, ICrdtProtoDirectoryFileScanner crdtProtoDirectoryFileScanner)
	{
		_uiDispatcher = uiDispatcher;
		_asyncExecutor = asyncExecutor;
		_mediaService = mediaService;
		_crdtProtoDirectoryFileScanner = crdtProtoDirectoryFileScanner;
	}

	public IChangeDirectoryProcess CreateChangeDirectoryProcess(IWorkspace? oldWorkspace, IWorkspace newWorkspace)
	{
		return new ChangeDirectoryProcess(newWorkspace, oldWorkspace, _uiDispatcher, _asyncExecutor, _mediaService, _crdtProtoDirectoryFileScanner, ChangeDirectoryPrompt.Listeners, delegate(IWorkspace p)
		{
			CommonPaths.Base = p.Path;
		});
	}
}
