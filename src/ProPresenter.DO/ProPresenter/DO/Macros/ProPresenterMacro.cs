using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Macros;

public class ProPresenterMacro : Macro, IActionRepository, ITriggerable
{
	private readonly IActionGateway _validator;

	IEnumerable<IAction> IActionRepository.Actions => base.Actions;

	public ProPresenterMacro(UndoStack? undoStack = null, IActionGateway? actionValidator = null)
		: base(undoStack)
	{
		_validator = actionValidator ?? new ActionGateway(base.Actions);
	}

	public bool CanAddAction([NotNullWhen(true)] object? data)
	{
		if (data != null && CanReplace(data))
		{
			return _validator.CanAddAction(data);
		}
		return false;
	}

	public bool CanReplace(object? data)
	{
		if (data is MacroAction macroAction)
		{
			return macroAction.MacroID != base.ID;
		}
		return true;
	}

	public override IMacro Clone()
	{
		return CopyProperties(new ProPresenterMacro());
	}

	public Macro CloneWithID()
	{
		ProPresenterMacro obj = (ProPresenterMacro)Clone();
		obj.ID = base.ID;
		return obj;
	}

	protected override void OnInsertAction(IAction action, bool addMediaReferences = false)
	{
		_validator.HandleIncoming(action, out IEnumerable<IAction> replacements);
		RemoveActions(replacements);
		if (action is ICanReceiveMediaContainerIdUpdates canReceiveMediaContainerIdUpdates)
		{
			canReceiveMediaContainerIdUpdates.UpdateContainerId(MediaContainerIds.Macro(base.ParentCollectionID));
		}
	}

	protected override void OnRemoveAction(IAction action)
	{
		if (action is MediaAction { Media: ITrackedMedia media })
		{
			media.RemoveFromMediaService(deleteAssets: false);
		}
		_validator.HandleOutgoing(action);
	}

	protected override void OnParentCollectionIdChanged(Guid oldValue, Guid newValue)
	{
		foreach (ICanReceiveMediaContainerIdUpdates item in base.Actions.OfType<ICanReceiveMediaContainerIdUpdates>())
		{
			item.UpdateContainerId(MediaContainerIds.Macro(newValue));
		}
	}

	internal void SetTriggerOnstartup(bool triggerOnStartup)
	{
		base.TriggerOnStartup = triggerOnStartup;
	}

	public bool CanAssign(object data, IAction? action)
	{
		return this.CanAssignData(data, action);
	}
}
