using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Label;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.InputActions;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Label;

namespace ProPresenter.DO.InputActionMap;

public class GroupLabelGroup : InputActionGroupBase
{
	private GroupLabelCollection? _groupLabels;

	private IEnumerable<KeyMapping>? _protoKeyMappings;

	internal GroupLabelCollection? Source => _groupLabels;

	public GroupLabelGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
	}

	public void Initialize(GroupLabelCollection groupLabels)
	{
		if (_groupLabels != null)
		{
			throw new NotSupportedException();
		}
		_groupLabels = groupLabels;
		_groupLabels.CollectionChanged += GroupLabels_CollectionChanged;
		_groupLabels.ForEach(delegate(GroupLabel g)
		{
			AddGroup(base.Count, g);
		});
		Deserialize(_protoKeyMappings ?? Array.Empty<KeyMapping>());
	}

	private void GroupLabels_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<GroupLabel>().ForEach(RemoveGroup);
		e.NewItems?.OfType<GroupLabel>().Reverse().ForEach(delegate(GroupLabel g)
		{
			AddGroup(e.NewStartingIndex, g);
		});
		CheckConflict();
	}

	private void AddGroup(int index, GroupLabel label)
	{
		if (CreateInputAction(label.Text, label.Text) is GroupLabelInputAction groupLabelInputAction)
		{
			label.PropertyChanged += GroupLabel_PropertyChanged;
			groupLabelInputAction.SetGroupLabelId(new Identifier(label.ID, label.Text), label.Hotkey);
			Insert(index, groupLabelInputAction);
		}
	}

	private void GroupLabel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!(e.PropertyName == "Text"))
		{
			return;
		}
		GroupLabel groupLabel = sender as GroupLabel;
		if (groupLabel != null)
		{
			base.Collection.OfType<GroupLabelInputAction>().FirstOrDefaultBy((GroupLabelInputAction i) => i.GroupLabelId?.ID == groupLabel.ID, (GroupLabelInputAction i) => i.GroupLabelId?.Name == groupLabel.Text)?.SetGroupLabelId(new Identifier(groupLabel.ID, groupLabel.Text), groupLabel.Hotkey);
		}
	}

	private void RemoveGroup(GroupLabel groupLabel)
	{
		groupLabel.PropertyChanged -= GroupLabel_PropertyChanged;
		GroupLabelInputAction action = base.Collection.OfType<GroupLabelInputAction>().FirstOrDefaultBy((GroupLabelInputAction i) => i.GroupLabelId?.ID == groupLabel.ID, (GroupLabelInputAction i) => i.GroupLabelId?.Name == groupLabel.Text);
		Remove(action);
	}

	protected override InputAction CreateInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures = null, IEnumerable<string>? accessPath = null, bool requireModifiers = true)
	{
		return new GroupLabelInputAction(identifier, label, defaultGestures, this);
	}

	public void Deserialize(IEnumerable<KeyMapping> protoKeyMappings)
	{
		_protoKeyMappings = protoKeyMappings;
		KeyMapping[] array = protoKeyMappings.Where((KeyMapping i) => i.GroupIdentifier != null).ToArray();
		foreach (KeyMapping protoKeyMap in array)
		{
			base.Collection.OfType<GroupLabelInputAction>().FirstOrDefaultBy((GroupLabelInputAction i) => i.GroupLabelId?.ID == protoKeyMap.GroupIdentifier.ParameterUuid.ToGuid(), (GroupLabelInputAction i) => i.GroupLabelId?.Name == protoKeyMap.GroupIdentifier.ParameterName)?.DeserializeKeyboardGesture(protoKeyMap);
		}
	}

	protected override bool CanConflict(InputActionGroupBase other)
	{
		return !(other is EditorMenuGroup);
	}
}
