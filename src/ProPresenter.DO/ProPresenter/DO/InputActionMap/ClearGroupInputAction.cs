using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.UI.InputActions;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.InputActionMap;

public class ClearGroupInputAction : InputAction
{
	public override InputActionType Type => InputActionType.ClearGroup;

	public Identifier? ClearGroupId { get; private set; }

	public override ObjectBinder<InputAction, IKeyMapping> Bind(IEntityFactory entityFactory, IKeyMapping entity)
	{
		ObjectBinder<InputAction, IKeyMapping> objectBinder = new ObjectBinder<InputAction, IKeyMapping>(this, entity);
		InputAction.BindKeyGesture(objectBinder);
		objectBinder.Bind((InputAction l) => (l is ClearGroupInputAction) ? l.WhenPropertyChanges("ClearGroupId").ToUnit() : Observable.Empty<Unit>(), (IKeyMapping r) => r.TargetIdentifier.WhenValueChanges, delegate(InputAction l, IKeyMapping r)
		{
			if (l is ClearGroupInputAction clearGroupInputAction)
			{
				IKeyMapping.Types.ITargetIdentifier.IClearGroupIdentifier clearGroupIdentifier = entityFactory.Create<IKeyMapping.Types.ITargetIdentifier.IClearGroupIdentifier>();
				clearGroupIdentifier.Value.ParameterUuid.Set(clearGroupInputAction.ClearGroupId?.ID ?? Guid.Empty);
				clearGroupIdentifier.Value.ParameterName.Set(clearGroupInputAction.ClearGroupId?.Name ?? string.Empty);
				r.TargetIdentifier.Set(clearGroupIdentifier);
			}
		}, delegate(IKeyMapping r, InputAction l)
		{
			if (l is ClearGroupInputAction clearGroupInputAction2)
			{
				if (r.TargetIdentifier.Value is IKeyMapping.Types.ITargetIdentifier.IClearGroupIdentifier clearGroupIdentifier2)
				{
					clearGroupInputAction2.SetClearGroupId(new Identifier(clearGroupIdentifier2.Value.ParameterUuid.ToGuidOrEmpty(), clearGroupIdentifier2.Value.ParameterName.Value ?? string.Empty));
				}
				else
				{
					clearGroupInputAction2.SetClearGroupId(null);
				}
			}
		});
		return objectBinder;
	}

	public ClearGroupInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures, ClearGroupGroup parentGroup)
		: base(identifier, label, defaultGestures, parentGroup)
	{
	}

	public void SetClearGroupId(Identifier? clearGroupId)
	{
		ClearGroupId = clearGroupId;
		base.Label = clearGroupId?.Name ?? string.Empty;
		OnPropertyChanged("ClearGroupId");
	}
}
