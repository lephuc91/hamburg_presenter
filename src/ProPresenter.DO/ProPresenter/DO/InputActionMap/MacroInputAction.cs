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

public class MacroInputAction : InputAction
{
	public override InputActionType Type => InputActionType.Macro;

	public Identifier? MacroId { get; private set; }

	protected override bool RequireModifiers => false;

	public override ObjectBinder<InputAction, IKeyMapping> Bind(IEntityFactory entityFactory, IKeyMapping entity)
	{
		ObjectBinder<InputAction, IKeyMapping> objectBinder = new ObjectBinder<InputAction, IKeyMapping>(this, entity);
		InputAction.BindKeyGesture(objectBinder);
		objectBinder.Bind((InputAction l) => (l is MacroInputAction) ? l.WhenPropertyChanges("MacroId").ToUnit() : Observable.Empty<Unit>(), (IKeyMapping r) => r.TargetIdentifier.WhenValueChanges, delegate(InputAction l, IKeyMapping r)
		{
			if (l is MacroInputAction macroInputAction)
			{
				IKeyMapping.Types.ITargetIdentifier.IMacroIdentifier macroIdentifier = entityFactory.Create<IKeyMapping.Types.ITargetIdentifier.IMacroIdentifier>();
				macroIdentifier.Value.ParameterUuid.Set(macroInputAction.MacroId?.ID);
				macroIdentifier.Value.ParameterName.Set(macroInputAction.MacroId?.Name);
				r.TargetIdentifier.Set(macroIdentifier);
			}
		}, delegate(IKeyMapping r, InputAction l)
		{
			if (l is MacroInputAction macroInputAction2)
			{
				if (r.TargetIdentifier.Value is IKeyMapping.Types.ITargetIdentifier.IMacroIdentifier macroIdentifier2)
				{
					macroInputAction2.SetMacroId(new Identifier(macroIdentifier2.Value.ParameterUuid.ToGuidOrEmpty(), macroIdentifier2.Value.ParameterName.Value ?? string.Empty));
				}
				else
				{
					macroInputAction2.SetMacroId(null);
				}
			}
		});
		return objectBinder;
	}

	public MacroInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures, MacroGroup parentGroup)
		: base(identifier, label, defaultGestures, parentGroup)
	{
	}

	public void SetMacroId(Identifier? macroId)
	{
		MacroId = macroId;
		base.Label = macroId?.Name ?? string.Empty;
		OnPropertyChanged("MacroId");
	}
}
