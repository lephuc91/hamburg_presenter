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
using ProPresenter.DO.Props;

namespace ProPresenter.DO.InputActionMap;

public class PropGroup : InputActionGroupBase
{
	private IEnumerable<KeyMapping>? _protoKeyMappings;

	public PropGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
	}

	public void Initialize(IPropSource propSource)
	{
		if (propSource != null)
		{
			propSource.PropCollectionChanged += Props_CollectionChanged;
			propSource.FlatCollection.ForEach(delegate(IPropCue m)
			{
				AddProp(base.Collection.Count, m);
			});
		}
		DeserializeProps();
	}

	public void Initialize(IPropGroup props)
	{
		if (props != null)
		{
			props.CollectionChanged += Props_CollectionChanged;
			props.ForEach(delegate(IPropCue m)
			{
				AddProp(base.Collection.Count, m);
			});
		}
		DeserializeProps();
	}

	private void Props_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Remove)
		{
			_protoKeyMappings = this.Serialize().ToArray();
		}
		e.OldItems?.OfType<IPropCue>().ForEach(RemoveProp);
		e.NewItems?.OfType<IPropCue>().Reverse().ForEach(delegate(IPropCue m)
		{
			AddProp(e.NewStartingIndex, m);
		});
		DeserializeProps();
		CheckConflict();
	}

	private void AddProp(int index, IPropCue prop)
	{
		if (CreateInputAction(prop.Name, prop.Name) is PropInputAction propInputAction)
		{
			prop.PropertyChanged += Prop_PropertyChanged;
			propInputAction.SetPropId(new Identifier(prop.ID, prop.Name));
			Insert(index, propInputAction);
		}
	}

	private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!(e.PropertyName == "Name"))
		{
			return;
		}
		IPropCue prop = sender as IPropCue;
		if (prop != null)
		{
			PropInputAction propInputAction = base.Collection.OfType<PropInputAction>().FirstOrDefaultBy((PropInputAction i) => i.PropId?.ID == prop.ID, (PropInputAction i) => i.PropId?.Name == prop.Name);
			if (propInputAction != null)
			{
				propInputAction.Label = prop.Name;
			}
		}
	}

	private void RemoveProp(IPropCue prop)
	{
		prop.PropertyChanged -= Prop_PropertyChanged;
		PropInputAction action = base.Collection.OfType<PropInputAction>().FirstOrDefault((PropInputAction i) => i.PropId?.ID == prop.ID);
		Remove(action);
	}

	protected override InputAction CreateInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures = null, IEnumerable<string>? accessPath = null, bool requireModifiers = true)
	{
		return new PropInputAction(identifier, label, defaultGestures, this);
	}

	internal void Deserialize(IEnumerable<KeyMapping?> protoKeyMappings)
	{
		_protoKeyMappings = (from i in protoKeyMappings?.NonNull()
			where i.PropIdentifier != null
			select i).ToArray();
		DeserializeProps();
	}

	internal void DeserializeProps(List<KeyMapping>? protoKeyMappings, bool fallbackToName = true)
	{
		IEnumerable<KeyMapping> enumerable = protoKeyMappings?.ToArray();
		foreach (KeyMapping protoKeyMap in enumerable ?? Enumerable.Empty<KeyMapping>())
		{
			PropInputAction propInputAction = base.Collection.OfType<PropInputAction>().FirstOrDefaultBy(delegate(PropInputAction i)
			{
				Guid? guid = i.PropId?.ID;
				Guid? guid2 = protoKeyMap.PropIdentifier?.ParameterUuid.ToGuid();
				if (guid.HasValue != guid2.HasValue)
				{
					return false;
				}
				return !guid.HasValue || guid.GetValueOrDefault() == guid2.GetValueOrDefault();
			}, (PropInputAction i) => fallbackToName && i.PropId?.Name == protoKeyMap.PropIdentifier.ParameterName);
			if (propInputAction != null)
			{
				protoKeyMappings.Remove(protoKeyMap);
				propInputAction.DeserializeKeyboardGesture(protoKeyMap);
			}
		}
	}

	private void DeserializeProps()
	{
		if (_protoKeyMappings != null)
		{
			DeserializeProps(_protoKeyMappings.ToList());
			_protoKeyMappings = null;
		}
	}

	protected override bool CanConflict(InputActionGroupBase other)
	{
		return !(other is EditorMenuGroup);
	}
}
