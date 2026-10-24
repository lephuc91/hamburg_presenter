using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.InputActions;
using ProPresenter.DO.Actions;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;

namespace ProPresenter.DO.InputActionMap;

public class MacroGroup : InputActionGroupBase
{
	private IEnumerable<KeyMapping>? _protoKeyMappings;

	public MacroGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
	}

	public void Initialize(IMacroSource macroSource)
	{
		if (macroSource != null)
		{
			macroSource.MacroCollectionsChanged += Macros_CollectionChanged;
			macroSource.FlatCollection.ForEach(delegate(ProPresenterMacro m)
			{
				AddMacro(base.Collection.Count, m);
			});
		}
		DeserializeMacros();
	}

	public void Initialize(IMacroGroup macroGroup)
	{
		if (macroGroup != null)
		{
			macroGroup.CollectionChanged += Macros_CollectionChanged;
			macroGroup.ForEach(delegate(ProPresenterMacro m)
			{
				AddMacro(base.Collection.Count, m);
			});
		}
		DeserializeMacros();
	}

	private void Macros_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Move)
		{
			_protoKeyMappings = this.Serialize().ToArray();
		}
		e.OldItems?.OfType<ProPresenterMacro>().ForEach(RemoveMacro);
		e.NewItems?.OfType<ProPresenterMacro>().Reverse().ForEach(delegate(ProPresenterMacro m)
		{
			AddMacro(e.NewStartingIndex, m);
		});
		DeserializeMacros();
		CheckConflict();
	}

	private void AddMacro(int index, ProPresenterMacro macro)
	{
		if (CreateInputAction(macro.Name, macro.Name) is MacroInputAction macroInputAction)
		{
			macro.PropertyChanged += Macro_PropertyChanged;
			macroInputAction.SetMacroId(new Identifier(macro.ID, macro.Name));
			Insert(index, macroInputAction);
		}
	}

	private void Macro_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!(e.PropertyName == "Name"))
		{
			return;
		}
		ProPresenterMacro macro = sender as ProPresenterMacro;
		if (macro != null)
		{
			MacroInputAction macroInputAction = base.Collection.OfType<MacroInputAction>().FirstOrDefaultBy((MacroInputAction i) => i.MacroId?.ID == macro.ID, (MacroInputAction i) => i.MacroId?.Name == macro.Name);
			if (macroInputAction != null)
			{
				macroInputAction.Label = macro.Name;
			}
		}
	}

	private void RemoveMacro(ProPresenterMacro macro)
	{
		macro.PropertyChanged -= Macro_PropertyChanged;
		MacroInputAction action = base.Collection.OfType<MacroInputAction>().FirstOrDefaultBy((MacroInputAction i) => i.MacroId?.ID == macro.ID, (MacroInputAction i) => i.MacroId?.Name == macro.Name);
		Remove(action);
	}

	protected override InputAction CreateInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures = null, IEnumerable<string>? accessPath = null, bool requireModifiers = true)
	{
		return new MacroInputAction(identifier, label, defaultGestures, this);
	}

	internal void Deserialize(IEnumerable<KeyMapping?> protoKeyMappings)
	{
		_protoKeyMappings = (from i in protoKeyMappings?.NonNull()
			where i.MacroIdentifier != null
			select i).ToArray();
		DeserializeMacros();
	}

	internal void DeserializeMacros(List<KeyMapping>? protoKeyMappings, bool fallbackToName = true)
	{
		IEnumerable<KeyMapping> enumerable = protoKeyMappings?.ToArray();
		foreach (KeyMapping protoKeyMap in enumerable ?? Enumerable.Empty<KeyMapping>())
		{
			MacroInputAction macroInputAction = base.Collection.OfType<MacroInputAction>().FirstOrDefaultBy(delegate(MacroInputAction i)
			{
				Guid? guid = i.MacroId?.ID;
				Guid? guid2 = protoKeyMap.MacroIdentifier?.ParameterUuid.ToGuid();
				if (guid.HasValue != guid2.HasValue)
				{
					return false;
				}
				return !guid.HasValue || guid.GetValueOrDefault() == guid2.GetValueOrDefault();
			}, (MacroInputAction i) => fallbackToName && i.MacroId?.Name == protoKeyMap.MacroIdentifier.ParameterName);
			if (macroInputAction != null)
			{
				protoKeyMappings.Remove(protoKeyMap);
				macroInputAction.DeserializeKeyboardGesture(protoKeyMap);
			}
		}
	}

	private void DeserializeMacros()
	{
		if (_protoKeyMappings != null)
		{
			DeserializeMacros(_protoKeyMappings.ToList());
			_protoKeyMappings = null;
		}
	}

	protected override bool CanConflict(InputActionGroupBase other)
	{
		return !(other is EditorMenuGroup);
	}
}
