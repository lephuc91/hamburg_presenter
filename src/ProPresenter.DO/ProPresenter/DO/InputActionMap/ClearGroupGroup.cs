using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.InputActions;
using ProPresenter.DO.Actions;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.DO.InputActionMap;

public class ClearGroupGroup : InputActionGroupBase
{
	private ClearGroupCollection? _clearGroups;

	private IEnumerable<KeyMapping>? _protoKeyMappings;

	public ClearGroupGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
	}

	public void Initialize(ClearGroupCollection clearGroups)
	{
		if (_clearGroups != null)
		{
			throw new InvalidOperationException();
		}
		_clearGroups = clearGroups;
		_clearGroups.CollectionChanged += ClearGroups_CollectionChanged;
		_clearGroups.ForEach(delegate(ClearGroup g)
		{
			AddGroup(base.Collection.Count, g);
		});
		OnReset();
		DeserializeGroups();
	}

	private void ClearGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Move)
		{
			_protoKeyMappings = this.Serialize().ToArray();
		}
		e.OldItems?.OfType<ClearGroup>().ForEach(RemoveGroup);
		e.NewItems?.OfType<ClearGroup>().Reverse().ForEach(delegate(ClearGroup g)
		{
			AddGroup(e.NewStartingIndex, g);
		});
		DeserializeGroups();
		CheckConflict();
	}

	private ClearGroupInputAction? AddGroup(int index, ClearGroup clearGroup)
	{
		if (CreateInputAction(clearGroup.Name, clearGroup.Name) is ClearGroupInputAction clearGroupInputAction)
		{
			clearGroup.PropertyChanged += ClearGroup_PropertyChanged;
			clearGroupInputAction.SetClearGroupId(new Identifier(clearGroup.ID, clearGroup.Name));
			Insert(index, clearGroupInputAction);
			return clearGroupInputAction;
		}
		return null;
	}

	private void ClearGroup_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!(e.PropertyName == "Name"))
		{
			return;
		}
		ClearGroup clearGroup = sender as ClearGroup;
		if (clearGroup != null)
		{
			base.Collection.OfType<ClearGroupInputAction>().FirstOrDefaultBy((ClearGroupInputAction i) => i.ClearGroupId?.ID == clearGroup.ID, (ClearGroupInputAction i) => i.ClearGroupId?.Name == clearGroup.Name)?.SetClearGroupId(new Identifier(clearGroup.ID, clearGroup.Name));
		}
	}

	private void RemoveGroup(ClearGroup clearGroup)
	{
		clearGroup.PropertyChanged -= ClearGroup_PropertyChanged;
		ClearGroupInputAction action = base.Collection.OfType<ClearGroupInputAction>().FirstOrDefaultBy((ClearGroupInputAction i) => i.ClearGroupId?.ID == clearGroup.ID, (ClearGroupInputAction i) => i.ClearGroupId?.Name == clearGroup.Name);
		Remove(action);
	}

	protected override InputAction CreateInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures = null, IEnumerable<string>? accessPath = null, bool requireModifiers = true)
	{
		return new ClearGroupInputAction(identifier, label, defaultGestures, this);
	}

	internal void Deserialize(IEnumerable<KeyMapping> protoKeyMappings)
	{
		_protoKeyMappings = protoKeyMappings?.Where((KeyMapping i) => i.ClearGroupIdentifier != null).ToArray();
		if (_clearGroups != null)
		{
			DeserializeGroups();
		}
	}

	private void DeserializeGroups()
	{
		if (_protoKeyMappings == null)
		{
			return;
		}
		foreach (KeyMapping protoKeyMap in _protoKeyMappings)
		{
			base.Collection.OfType<ClearGroupInputAction>().FirstOrDefaultBy(delegate(ClearGroupInputAction i)
			{
				Guid? guid = i.ClearGroupId?.ID;
				Guid? guid2 = protoKeyMap.ClearGroupIdentifier?.ParameterUuid.ToGuid();
				if (guid.HasValue != guid2.HasValue)
				{
					return false;
				}
				return !guid.HasValue || guid.GetValueOrDefault() == guid2.GetValueOrDefault();
			}, (ClearGroupInputAction i) => i.ClearGroupId?.Name == protoKeyMap.ClearGroupIdentifier.ParameterName)?.DeserializeKeyboardGesture(protoKeyMap);
		}
		_protoKeyMappings = null;
	}

	protected override void OnReset()
	{
		base.Collection.FirstOrDefault()?.ChangeDefaultGesture(VirtualKeyGesture.CreateKeyGesture(VirtualKey.F1, (ModifierKeys)0));
	}
}
