using System;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.PCO;

public class PCOUpdater : IPCOUpdater
{
	private readonly IPCOConsumer _consumer;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IProPresenterResourceService _resourceService;

	private readonly IInternetAccess _internetAccess;

	private readonly IStoredPcoOptions _storedPcoOptions;

	private readonly IPeriodicTimer _autoUpdateTimer;

	public PCOUpdater(IPCOConsumer consumer, ITimerFactory timerFactory, IUiDispatcher uiDispatcher, IAsyncExecutor asyncExecutor, IProPresenterResourceService resourceService, IInternetAccess internetAccess, IStoredPcoOptions storedPcoOptions)
	{
		_consumer = consumer;
		_uiDispatcher = uiDispatcher;
		_asyncExecutor = asyncExecutor;
		_resourceService = resourceService;
		_internetAccess = internetAccess;
		_storedPcoOptions = storedPcoOptions;
		_autoUpdateTimer = timerFactory.CreatePeriodicDispatched(TimeSlice.FromMinutes(1.0), delegate
		{
			_asyncExecutor.ExecuteAsync(async delegate
			{
				await CheckUpdates();
			});
		});
		ValidateTimerStatus();
		storedPcoOptions.PropertyChanged += delegate
		{
			ValidateTimerStatus();
		};
		_consumer.PropertyChanged += delegate
		{
			ValidateTimerStatus();
		};
	}

	private void ValidateTimerStatus()
	{
		if (_storedPcoOptions.AutoPlanUpdate && _consumer.IsAuthorized)
		{
			if (!_autoUpdateTimer.IsRunning())
			{
				_autoUpdateTimer.Start();
			}
		}
		else
		{
			_autoUpdateTimer.Stop();
		}
	}

	private async Task CheckUpdates()
	{
		if (!_internetAccess.IsInternetAvailable())
		{
			return;
		}
		foreach (PCOPlaylist pcoPlaylist in _resourceService.LibraryPlaylists.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.Type == PlaylistType.PCO).Cast<PCOPlaylist>())
		{
			(pcoPlaylist.PCOPlan?.ID).ThrowWhenNull("pcoPlaylist.PCOPlan?.ID");
			DateTime? lastUpdateTime = await _consumer.GetLastUpdateTimeForPlanAsync(pcoPlaylist.PCOPlan.ServiceTypeID, pcoPlaylist.PCOPlan.ID);
			await _uiDispatcher.InvokeAsync(delegate
			{
				pcoPlaylist.CheckUpdates(lastUpdateTime);
			});
		}
	}
}
