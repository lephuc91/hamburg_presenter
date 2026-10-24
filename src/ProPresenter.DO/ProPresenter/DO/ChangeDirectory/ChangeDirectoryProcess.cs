using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V1;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.ChangeDirectory;

public class ChangeDirectoryProcess : NotifyPropertyChangedBase, IChangeDirectoryProcess, INotifyPropertyChanged
{
	private int _processesRunning;

	private double _completedPercentage;

	private readonly IUiDispatcher _dispatcher;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IMediaService _mediaService;

	private readonly ICrdtProtoDirectoryFileScanner _crdtProtoDirectoryFileScanner;

	private readonly IReadOnlyCollection<ChangeDirectoryListener> _listeners;

	private readonly Action<IWorkspace> _setDirectoryCallback;

	public double CompletedPercentage
	{
		get
		{
			return _completedPercentage;
		}
		set
		{
			SetValue("CompletedPercentage", ref _completedPercentage, value);
		}
	}

	public IWorkspace? OldWorkspace { get; }

	public IWorkspace NewWorkspace { get; }

	public event Action<IChangeDirectoryProcess>? Started;

	public event Action<(IChangeDirectoryProcess, bool)>? Completed;

	public ChangeDirectoryProcess(IWorkspace newWorkspace, IWorkspace? oldWorkspace, IUiDispatcher dispatcher, IAsyncExecutor asyncExecutor, IMediaService mediaService, ICrdtProtoDirectoryFileScanner crdtProtoDirectoryFileScanner, IReadOnlyCollection<ChangeDirectoryListener> listeners, Action<IWorkspace> setDirectoryCallback)
	{
		NewWorkspace = newWorkspace;
		_dispatcher = dispatcher;
		_asyncExecutor = asyncExecutor;
		_mediaService = mediaService;
		_crdtProtoDirectoryFileScanner = crdtProtoDirectoryFileScanner;
		_listeners = listeners;
		_setDirectoryCallback = setDirectoryCallback;
		OldWorkspace = oldWorkspace;
	}

	public void Start()
	{
		if (Interlocked.CompareExchange(ref _processesRunning, 1, 0) <= 0)
		{
			OnStart();
		}
	}

	protected virtual void OnStart()
	{
		this.Started?.Invoke(this);
		_asyncExecutor.ExecuteAsync(async delegate
		{
			_ = 4;
			try
			{
				_crdtProtoDirectoryFileScanner.ValidateWorkspace(NewWorkspace);
				bool shouldLoadLegacy = _crdtProtoDirectoryFileScanner.ShouldLoadLegacy;
				if (_mediaService is IMediaServiceV1 mediaServiceV)
				{
					if (!((await mediaServiceV.ChangeShowDirectoryAsync(NewWorkspace.Path)) is MediaServiceOkResponse<ResponseEnvelope.Types.ChangeShowDirectoryResponse>))
					{
						await _dispatcher.InvokeAsync(delegate
						{
							this.Completed?.Invoke((this, false));
						});
					}
					else
					{
						await _dispatcher.InvokeAsync(delegate
						{
							DoChangeDirectory(shouldLoadLegacy);
						});
					}
				}
				else
				{
					await _dispatcher.InvokeAsync(delegate
					{
						DoChangeDirectory(shouldLoadLegacy);
					});
				}
			}
			catch (Exception)
			{
				await _dispatcher.InvokeAsync(delegate
				{
					this.Completed?.Invoke((this, false));
				});
				throw;
			}
			finally
			{
				Interlocked.Decrement(ref _processesRunning);
			}
		});
	}

	protected void DoChangeDirectory(bool loadLegacy)
	{
		int num = 0;
		double num2 = (double)(_listeners.Count * 2) + 1.0;
		foreach (ChangeDirectoryListener listener in _listeners)
		{
			CompletedPercentage = (double)(++num) / num2;
			listener.Start();
		}
		_setDirectoryCallback(NewWorkspace);
		CompletedPercentage = (double)(++num) / num2;
		foreach (ChangeDirectoryListener listener2 in _listeners)
		{
			listener2.Complete(loadLegacy);
			CompletedPercentage = (double)(++num) / num2;
		}
		this.Completed?.Invoke((this, true));
	}
}
