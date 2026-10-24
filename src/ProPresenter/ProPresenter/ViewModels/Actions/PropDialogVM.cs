using System.Collections.Generic;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Props;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Actions;

public class PropDialogVM : ActionDialogContentVM
{
	private readonly IPropPrompts _propPrompts;

	public PropAction PropAction => (PropAction)base.Action;

	public double AutoClearDuration
	{
		get
		{
			return PropAction.AutoClearDuration;
		}
		private set
		{
			PropAction.AutoClearDuration = value;
			OnPropertyChanged("AutoClearDuration");
		}
	}

	public double DefaultAutoClearDuration => PropAction.DefaultAutoClearDuration;

	public bool AutoClearFollowsPropDuration
	{
		get
		{
			return PropAction.AutoClearFollowsPropDuration;
		}
		private set
		{
			PropAction.AutoClearFollowsPropDuration = value;
			OnPropertyChanged("AutoClearFollowsPropDuration");
		}
	}

	public IEnumerable<IPropCue> Props => DataVault.PropSource.FlatCollection;

	public INotifyEnumerableChanged<IPropGroup> PropGroups => DataVault.PropGroupCollection;

	public ICommand<IPropCue> SelectPropCommand => new RelayCommand<IPropCue>(OnSelectPropCommand, (IPropCue p) => base.ActionStore.CanAssignData(p, base.Action));

	public ICommand<PropTriggerType> ChangePropTriggerTypeCommand => new RelayCommand<PropTriggerType>(OnChangePropTriggerTypeCommand);

	public bool TriggerItemsVisible => PropAction.PropTriggerType == PropTriggerType.Trigger;

	public ICommand<double> SetAutoClearCommand => new RelayCommand<double>(OnSetAutoClearCommandExecute);

	public ICommand SetAutoClearCommandToDefault => new RelayCommand(OnSetAutoClearCommandToDefaultExecute);

	public ICommand PopupAutoClearCustomCommand => new RelayCommand(OnPopupAutoClearCustomCommandExecute);

	public PropDialogVM(IPropPrompts propPrompts)
	{
		_propPrompts = propPrompts;
		LinkProperties("AutoClearDuration", "AutoClearDuration");
		LinkProperties("PropTriggerType", "TriggerItemsVisible");
		LinkProperties("DefaultAutoClearDuration", "DefaultAutoClearDuration");
		LinkProperties("AutoClearFollowsPropDuration", "AutoClearFollowsPropDuration");
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
		base.OnContextChanged(oldValue, newValue);
	}

	private void OnSelectPropCommand(IPropCue prop)
	{
		PropAction.SetIdentifier(prop.ID, prop.Name, prop.ParentCollectionID, prop.ParentCollectionName, PropTrigger.Trigger);
	}

	private void OnChangePropTriggerTypeCommand(PropTriggerType type)
	{
		PropAction.ChangeTriggerType(type);
	}

	private void OnSetAutoClearCommandExecute(double value)
	{
		AutoClearDuration = value;
		AutoClearFollowsPropDuration = false;
	}

	private void OnPopupAutoClearCustomCommandExecute()
	{
		double? num = _propPrompts.ShowDialogAutoClearCustomTimePrompt(AutoClearDuration);
		if (num.HasValue && num >= 0.0)
		{
			AutoClearDuration = num.Value;
			AutoClearFollowsPropDuration = false;
		}
	}

	private void OnSetAutoClearCommandToDefaultExecute()
	{
		AutoClearDuration = PropAction.DefaultAutoClearDuration;
		AutoClearFollowsPropDuration = true;
	}
}
