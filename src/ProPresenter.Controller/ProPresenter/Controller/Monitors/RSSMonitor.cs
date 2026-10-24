using System;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using ProPresenter.DO.RSS;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Slide.Links.Text.RssFeed;

namespace ProPresenter.Controller.Monitors;

public class RSSMonitor : MonitorBase
{
	private enum RequestState
	{
		Ready,
		Waiting,
		Stopped
	}

	private static readonly TimeSlice UpdateDelay = TimeSlice.FromSeconds(10.0);

	private readonly IPeriodicTimer _updateTimer;

	private readonly IRestClientFactory _restClientFactory;

	private readonly object _stateLock = new object();

	private volatile RequestState _state;

	private string[] _lastContent = Array.Empty<string>();

	public override MonitorType MonitorType => MonitorType.RSSFeed;

	public string Url { get; }

	public RssFeedContentMode ContentMode { get; }

	public RSSMonitor(ITimerFactory timerFactory, IRestClientFactory restClientFactory, string url, RssFeedContentMode contentMode)
	{
		Url = url;
		ContentMode = contentMode;
		_restClientFactory = restClientFactory;
		_updateTimer = timerFactory.CreatePeriodicDispatched(UpdateDelay, CheckForUpdates);
		CheckForUpdates();
		_updateTimer.Start();
	}

	public override void StopMonitoring()
	{
		_updateTimer.Stop();
		lock (_stateLock)
		{
			_state = RequestState.Stopped;
		}
	}

	private void CheckForUpdates()
	{
		lock (_stateLock)
		{
			if (_state != 0)
			{
				return;
			}
			_state = RequestState.Waiting;
		}
		SharedWorkerPool.Queue.AddJob(delegate
		{
			try
			{
				RSSFeed rSSFeed = RssFeedUtility.LoadFeed(Url, _restClientFactory);
				if (rSSFeed == null)
				{
					lock (_stateLock)
					{
						if (_state == RequestState.Waiting)
						{
							_state = RequestState.Ready;
						}
						return;
					}
				}
				string[] array = RssFeedUtility.ParseFeed(rSSFeed, ContentMode);
				lock (_stateLock)
				{
					if (_state != RequestState.Stopped)
					{
						if (!_lastContent.ContentsMatchExactly(array))
						{
							OnResourceChanged();
						}
						_lastContent = array;
						_state = RequestState.Ready;
					}
				}
			}
			catch (Exception exception)
			{
				lock (_stateLock)
				{
					if (_state == RequestState.Waiting)
					{
						_state = RequestState.Ready;
					}
				}
				Log.Error(exception);
			}
		}, "RSS Update Check [" + Url + "]");
	}
}
