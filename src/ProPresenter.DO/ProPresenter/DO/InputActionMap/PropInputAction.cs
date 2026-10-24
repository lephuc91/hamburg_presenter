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

public class PropInputAction : InputAction
{
	public override InputActionType Type => InputActionType.Prop;

	public Identifier? PropId { get; private set; }

	protected override bool RequireModifiers => false;

	public override ObjectBinder<InputAction, IKeyMapping> Bind(IEntityFactory entityFactory, IKeyMapping entity)
	{
		ObjectBinder<InputAction, IKeyMapping> objectBinder = new ObjectBinder<InputAction, IKeyMapping>(this, entity);
		InputAction.BindKeyGesture(objectBinder);
		objectBinder.Bind((InputAction l) => (l is PropInputAction) ? l.WhenPropertyChanges("PropId").ToUnit() : Observable.Empty<Unit>(), (IKeyMapping r) => r.TargetIdentifier.WhenValueChanges, delegate(InputAction l, IKeyMapping r)
		{
			if (l is PropInputAction propInputAction)
			{
				IKeyMapping.Types.ITargetIdentifier.IPropIdentifier propIdentifier = entityFactory.Create<IKeyMapping.Types.ITargetIdentifier.IPropIdentifier>();
				propIdentifier.Value.ParameterUuid.Set(propInputAction.PropId?.ID);
				propIdentifier.Value.ParameterName.Set(propInputAction.PropId?.Name);
				r.TargetIdentifier.Set(propIdentifier);
			}
		}, delegate(IKeyMapping r, InputAction l)
		{
			if (l is PropInputAction propInputAction2)
			{
				if (r.TargetIdentifier.Value is IKeyMapping.Types.ITargetIdentifier.IPropIdentifier propIdentifier2)
				{
					propInputAction2.SetPropId(new Identifier(propIdentifier2.Value.ParameterUuid.ToGuidOrEmpty(), propIdentifier2.Value.ParameterName.Value ?? string.Empty));
				}
				else
				{
					propInputAction2.SetPropId(null);
				}
			}
		});
		return objectBinder;
	}

	internal PropInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures, PropGroup parentGroup)
		: base(identifier, label, defaultGestures, parentGroup)
	{
	}

	public void SetPropId(Identifier? propId)
	{
		PropId = propId;
		base.Label = propId?.Name ?? string.Empty;
		OnPropertyChanged("PropId");
	}
}
