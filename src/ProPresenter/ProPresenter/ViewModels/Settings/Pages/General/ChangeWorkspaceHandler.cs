using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Pro.Common.FileSystem;
using Pro.Common.Time;
using Pro.Localization;
using ProPresenter.Controller;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.Settings.PageTemplates.General;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public class ChangeWorkspaceHandler : IChangeWorkspaceHandler
{
	private readonly DispatcherTimer _closeProgressTimer = new DispatcherTimer((DispatcherPriority)4);

	private readonly IChangeDirectoryProcessFactory _processFactory;

	private readonly ICommonPathsWrapper _commonPaths;

	private readonly ICoreManager _coreManager;

	private ChangeDirectoryProgressWindow? _progressWindow;

	public event Action<ChangeWorkspaceCompleted>? Completed;

	public ChangeWorkspaceHandler(IChangeDirectoryProcessFactory processFactory, ICommonPathsWrapper commonPaths, ICoreManager coreManager)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		_closeProgressTimer.Interval = TimeSlice.FromSeconds(1.0);
		_closeProgressTimer.Tick += TimerTick;
		_processFactory = processFactory;
		_commonPaths = commonPaths;
		_coreManager = coreManager;
	}

	public void ChangeWorkspace(IWorkspace newWorkspace, bool publishAfterChange = false)
	{
		IWorkspace oldWorkspace = _commonPaths.Workspaces.FirstOrDefault((IWorkspace w) => w.Path.IsPathEqual(_commonPaths.Base));
		IChangeDirectoryProcess changeDirectoryProcess = _processFactory.CreateChangeDirectoryProcess(oldWorkspace, newWorkspace);
		changeDirectoryProcess.Started += ChangeDirectoryProcess_Started;
		changeDirectoryProcess.Completed += (publishAfterChange ? new Action<(IChangeDirectoryProcess, bool)>(ChangeDirectoryProcess_Completed_WithPublish) : new Action<(IChangeDirectoryProcess, bool)>(ChangeDirectoryProcess_Completed_WithoutPublish));
		changeDirectoryProcess.Start();
	}

	private void ChangeDirectoryProcess_Started(IChangeDirectoryProcess process)
	{
		process.Started -= ChangeDirectoryProcess_Started;
		string title = LocalizedStrings.Get("LOCALWORKSPACE_SWITCHING_WORKSPACE_DIALOG_title");
		_progressWindow = new ChangeDirectoryProgressWindow
		{
			Title = title,
			Process = process
		};
		_progressWindow.Show();
	}

	private void ChangeDirectoryProcess_Completed_WithPublish((IChangeDirectoryProcess Process, bool) completed)
	{
		completed.Process.Completed -= ChangeDirectoryProcess_Completed_WithPublish;
		CompleteChangeDirectoryProcess(completed, publishAfterChange: true);
	}

	private void ChangeDirectoryProcess_Completed_WithoutPublish((IChangeDirectoryProcess Process, bool) completed)
	{
		completed.Process.Completed -= ChangeDirectoryProcess_Completed_WithoutPublish;
		CompleteChangeDirectoryProcess(completed, publishAfterChange: false);
	}

	private void CompleteChangeDirectoryProcess((IChangeDirectoryProcess Process, bool Success) completed, bool publishAfterChange)
	{
		_coreManager.SendDocumentsToCore();
		this.Completed?.Invoke(new ChangeWorkspaceCompleted(completed.Process.OldWorkspace, completed.Process.NewWorkspace, completed.Success, publishAfterChange));
		ChangeDirectoryProgressWindow? progressWindow = _progressWindow;
		if (progressWindow != null && progressWindow.Visibility == Visibility.Visible)
		{
			_closeProgressTimer.Start();
		}
	}

	private void TimerTick(object? sender, EventArgs e)
	{
		_progressWindow?.Close();
		_closeProgressTimer.Stop();
	}
}
