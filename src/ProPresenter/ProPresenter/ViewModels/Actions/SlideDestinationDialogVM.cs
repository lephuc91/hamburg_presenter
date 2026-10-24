using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public class SlideDestinationDialogVM : ActionDialogContentVM
{
	public bool StageOnly
	{
		get
		{
			SlideDestinationAction? slideDestination = SlideDestination;
			if (slideDestination == null)
			{
				return false;
			}
			return slideDestination.SlideDestination == SlideDestinationType.StageOnly;
		}
	}

	public bool StageAndAudience
	{
		get
		{
			SlideDestinationAction? slideDestination = SlideDestination;
			if (slideDestination == null)
			{
				return false;
			}
			return slideDestination.SlideDestination == SlideDestinationType.All;
		}
	}

	private SlideDestinationAction? SlideDestination => base.Action as SlideDestinationAction;

	public ICommand StageOnlyCommand => new RelayCommand(delegate
	{
		SlideDestination?.SetSlideDestination(SlideDestinationType.StageOnly);
	});

	public ICommand StageAndAudienceCommand => new RelayCommand(delegate
	{
		SlideDestination?.SetSlideDestination(SlideDestinationType.All);
	});

	public SlideDestinationDialogVM()
	{
		LinkProperties("SlideDestination", new string[2] { "StageOnly", "StageAndAudience" });
	}

	protected override void OnContextChanged(IActionDialogContext? oldValue, IActionDialogContext? newValue)
	{
		if (oldValue?.Action != null)
		{
			oldValue.Action.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (newValue?.Action != null)
		{
			newValue.Action.PropertyChanged += base.RaiseLinkedValues;
		}
	}
}
