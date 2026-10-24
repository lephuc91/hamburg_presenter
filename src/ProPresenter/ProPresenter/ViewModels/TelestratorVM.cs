using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class TelestratorVM : LinkedNotifyPropertyChangedBase, ITelestratorVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	public IImmutableObservableCollection<ArrangedCue>? Slides => (_manager.ActivePlaylistItem as DocumentCue)?.DocumentAction.ActiveArrangement?.ArrangedCues;

	public ArrangedCue? ActiveSlide => _manager.ActiveSlide;

	public TelestratorPreferences Settings => TelestratorPreferences.Settings;

	public ICommand<ArrangedCue> TriggerSlideCommand => new RelayCommand<ArrangedCue>(delegate(ArrangedCue s)
	{
		_service.TriggerSlide(s);
	});

	public TelestratorVM(ICoreManager manager, ITriggeringFactory triggeringFactory)
	{
		_manager = manager;
		_service = triggeringFactory.Create();
		LinkProperties("ActivePlaylistItem", "Slides");
		LinkProperties("ActiveSlide", "ActiveSlide");
		_manager.PropertyChanged += base.RaiseLinkedValues;
	}
}
