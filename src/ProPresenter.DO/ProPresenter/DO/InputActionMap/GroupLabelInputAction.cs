using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Label;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.UI.InputActions;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.InputActionMap;

public class GroupLabelInputAction : InputAction
{
	private Pro.DO.Hotkey? _hotkey;

	public override InputActionType Type => InputActionType.GroupLabel;

	public Identifier? GroupLabelId { get; private set; }

	protected override bool RequireModifiers => false;

	public override ObjectBinder<InputAction, IKeyMapping> Bind(IEntityFactory entityFactory, IKeyMapping entity)
	{
		ObjectBinder<InputAction, IKeyMapping> objectBinder = new ObjectBinder<InputAction, IKeyMapping>(this, entity);
		InputAction.BindKeyGesture(objectBinder);
		objectBinder.Bind((InputAction l) => (l is GroupLabelInputAction) ? l.WhenPropertyChanges("GroupLabelId").ToUnit() : Observable.Empty<Unit>(), (IKeyMapping r) => r.TargetIdentifier.WhenValueChanges, delegate(InputAction l, IKeyMapping r)
		{
			if (l is GroupLabelInputAction groupLabelInputAction)
			{
				IKeyMapping.Types.ITargetIdentifier.IGroupIdentifier groupIdentifier = entityFactory.Create<IKeyMapping.Types.ITargetIdentifier.IGroupIdentifier>();
				groupIdentifier.Value.ParameterUuid.Set(groupLabelInputAction.GroupLabelId?.ID);
				groupIdentifier.Value.ParameterName.Set(groupLabelInputAction.GroupLabelId?.Name);
				r.TargetIdentifier.Set(groupIdentifier);
			}
		}, delegate(IKeyMapping r, InputAction l)
		{
			if (l is GroupLabelInputAction groupLabelInputAction2)
			{
				if (r.TargetIdentifier.Value is IKeyMapping.Types.ITargetIdentifier.IGroupIdentifier groupIdentifier2)
				{
					Pro.DO.Hotkey hotkey = new Pro.DO.Hotkey((Key)0);
					Guid id = groupIdentifier2.Value.ParameterUuid.ToGuidOrEmpty();
					string name = groupIdentifier2.Value.ParameterName.Value;
					if (groupLabelInputAction2.ParentGroup is GroupLabelGroup groupLabelGroup)
					{
						GroupLabel groupLabel = groupLabelGroup.Source?.FirstOrDefaultBy((GroupLabel g) => g.ID == id, (GroupLabel g) => g.Name == name);
						if (groupLabel != null)
						{
							hotkey = groupLabel.Hotkey;
						}
					}
					groupLabelInputAction2.SetGroupLabelId(new Identifier(groupIdentifier2.Value.ParameterUuid.ToGuidOrEmpty(), groupIdentifier2.Value.ParameterName.Value ?? string.Empty), hotkey);
				}
				else
				{
					groupLabelInputAction2.SetGroupLabelId(null, null);
				}
			}
		});
		return objectBinder;
	}

	public GroupLabelInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures, GroupLabelGroup parentGroup)
		: base(identifier, label, defaultGestures, parentGroup)
	{
	}

	public void SetGroupLabelId(Identifier? groupLabelId, Pro.DO.Hotkey? hotkey)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		GroupLabelId = groupLabelId;
		base.Label = groupLabelId?.Name ?? string.Empty;
		_hotkey = hotkey;
		if ((object)hotkey != null && hotkey.Key.IsSupported(out var virtualKey))
		{
			VirtualKeyGesture gesture = VirtualKeyGesture.CreateKeyGesture(virtualKey, (ModifierKeys)0);
			ChangeDefaultGesture(gesture);
		}
		OnPropertyChanged("GroupLabelId");
	}

	protected override void OnKeyboardGestureChanged(VirtualKeyGesture? oldValue, VirtualKeyGesture? newValue)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if ((object)_hotkey != null)
		{
			_hotkey.Key = (Key)(((object)newValue != null) ? ((int)newValue.Key.GetData().Key) : 0);
		}
	}

	protected override bool ValidateKeyGesture(VirtualKeyGesture? virtualKeyGesture)
	{
		if ((object)virtualKeyGesture != null)
		{
			if (virtualKeyGesture.Key >= VirtualKey.A && virtualKeyGesture.Key <= VirtualKey.Z)
			{
				return (object)GroupLabelId != null;
			}
			return false;
		}
		return true;
	}

	protected override bool OnIsConflict(InputAction other)
	{
		if (!(other is GroupLabelInputAction groupLabelInputAction))
		{
			return true;
		}
		if (GroupLabelId?.Name == null || groupLabelInputAction.GroupLabelId?.Name == null)
		{
			return false;
		}
		if (GroupLabelId.Name.Contains(groupLabelInputAction.GroupLabelId.Name))
		{
			return groupLabelInputAction.GroupLabelId.Name.Contains(GroupLabelId.Name);
		}
		return false;
	}
}
