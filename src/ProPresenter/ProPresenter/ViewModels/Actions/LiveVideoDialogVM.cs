using System.Collections.Generic;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.LiveVideo;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public class LiveVideoDialogVM : ActionDialogContentVM
{
	private readonly ILiveVideoDialogService _service;

	public IEnumerable<LiveVideoInput> AvailableInputs => _service.AvailableInputs;

	public LiveVideoInput? LiveVideoInput
	{
		get
		{
			return ((MediaAction)base.Action).LiveVideo.LiveVideo.Input;
		}
		set
		{
			((MediaAction)base.Action).LiveVideo.LiveVideo.Input = value;
		}
	}

	public ICommand OpenSetupCommand => new RelayCommand(delegate
	{
		_service.OpenSetup(LiveVideoInput);
	});

	public LiveVideoDialogVM(IActionDialogService actionDialogService)
	{
		_service = actionDialogService;
		LinkProperties("Input", "LiveVideoInput");
	}

	protected override void OnContextChanged(IActionDialogContext? oldValue, IActionDialogContext? newValue)
	{
		if (oldValue?.Action is MediaAction mediaAction)
		{
			mediaAction.LiveVideo.LiveVideo.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (newValue?.Action is MediaAction mediaAction2)
		{
			mediaAction2.LiveVideo.LiveVideo.PropertyChanged += base.RaiseLinkedValues;
		}
	}
}
