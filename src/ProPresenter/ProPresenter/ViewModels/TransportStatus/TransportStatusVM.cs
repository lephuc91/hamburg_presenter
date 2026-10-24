using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Entity;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.InputActionMap;
using ProPresenter.UI.TransportStatus;
using ProPresenter.UI.ViewModels.TransportStatus;

namespace ProPresenter.ViewModels.TransportStatus;

public class TransportStatusVM : LinkedNotifyPropertyChangedBase, ITransportStatusVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private TransportStatusView _view = TransportStatusView.Presentation;

	public TransportStatusView View
	{
		get
		{
			return _view;
		}
		set
		{
			SetValue("View", ref _view, value);
		}
	}

	public IPlaybackStatusVM PresentationStatusVM { get; }

	public IPlaybackStatusVM AnnouncementStatusVM { get; }

	public IPlaybackStatusVM AudioStatusVM { get; }

	public bool SlideOnStageDisplayOnly => _manager.SlideOnStageDisplayOnly;

	public ICommand CancelGotoNextCommand => new RelayCommand(OnCancelGotoNextCommand);

	public ICommand CancelSlideOnStageDisplayOnlyCommand => new RelayCommand(OnCancelSlideOnStageDisplayOnly);

	public TransportStatusVM(ICoreManager manager, IPlaybackMarkerAnalyticsEvents playbackMarkerAnalyticsEvents, IActionsMenuVMFactory actionsMenuVMFactory, IInputActions inputActions, IEntityFactory entityFactory)
	{
		IPlaybackMarkerAnalyticsEvents playbackMarkerAnalyticsEvents2 = playbackMarkerAnalyticsEvents;
		IActionsMenuVMFactory actionsMenuVMFactory2 = actionsMenuVMFactory;
		IInputActions inputActions2 = inputActions;
		base._002Ector();
		TransportStatusVM transportStatusVM = this;
		_manager = manager;
		LinkProperties("SlideOnStageDisplayOnly", "SlideOnStageDisplayOnly");
		_manager.PropertyChanged += base.RaiseLinkedValues;
		PresentationStatusVM = generatePlaybackVM(TransportStatusView.Presentation);
		AnnouncementStatusVM = generatePlaybackVM(TransportStatusView.Announcement);
		AudioStatusVM = generatePlaybackVM(TransportStatusView.Audio);
		PlaybackStatusVM generatePlaybackVM(TransportStatusView view)
		{
			return new PlaybackStatusVM(_manager, view, new TransportMediaProvider(_manager, view), playbackMarkerAnalyticsEvents2, actionsMenuVMFactory2, inputActions2);
		}
	}

	private void OnCancelGotoNextCommand()
	{
		View.ViewAction(delegate
		{
			_manager.CancelPresentationGotoNext();
		}, delegate
		{
			_manager.CancelAnnouncementGotoNext();
		}, delegate
		{
			_manager.CancelAudioGotoNext();
		});
	}

	private void OnCancelSlideOnStageDisplayOnly()
	{
		_manager.TriggerSlideOnStageDisplayOnly(stageOnly: false);
	}
}
