using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.InputActions;
using ProPresenter.DO.Props;

namespace ProPresenter.DO.InputActionMap;

public class PropsGroupsGroup : InputActionGroupBase
{
	[CompilerGenerated]
	private sealed class _003CSerializeGroups_003Ed__15 : IEnumerable<KeyMapping>, IEnumerable, IEnumerator<KeyMapping>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private KeyMapping? _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public PropsGroupsGroup _003C_003E4__this;

		private IEnumerator<PropInputAction> _003C_003E7__wrap1;

		KeyMapping? IEnumerator<KeyMapping>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSerializeGroups_003Ed__15(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				PropsGroupsGroup propsGroupsGroup = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = propsGroupsGroup.GetAllActions().GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					PropInputAction current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = current.Serialize();
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<KeyMapping> IEnumerable<KeyMapping>.GetEnumerator()
		{
			_003CSerializeGroups_003Ed__15 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CSerializeGroups_003Ed__15(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<KeyMapping>)this).GetEnumerator();
		}
	}

	private IEnumerable<KeyMapping?>? _protoKeyMappings;

	private readonly PropGroupInputActionCollection _children;

	private readonly Dictionary<PropGroup, IPropGroup> _groupsData = new Dictionary<PropGroup, IPropGroup>();

	private readonly List<KeyMapping> _groupsKeyMappings = new List<KeyMapping>();

	internal event System.Action? CollectionDataChanged;

	public PropsGroupsGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		_children = new PropGroupInputActionCollection(SetupGroup, TeardownGroup);
		base.Children = _children;
		base.Children.CollectionChanged += Children_CollectionChanged;
	}

	private void Children_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		this.CollectionDataChanged?.Invoke();
	}

	public void Initilalize(IPropGroupCollection propGroupCollection)
	{
		_children.ChangeSource(propGroupCollection);
		Deserialize();
	}

	private PropGroup SetupGroup(IPropGroup group)
	{
		PropGroup propGroup = new PropGroup(group.Name, _children);
		propGroup.Initialize(group);
		propGroup.DataModified += base.OnDataModified;
		group.PropertyChanged += Group_PropertyChanged;
		propGroup.CollectionChanged += Group_CollectionChanged;
		_groupsData[propGroup] = group;
		return propGroup;
	}

	private void Group_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Remove)
		{
			((from g in e.OldItems?.OfType<PropInputAction>()
				select g.Serialize()).ToArray() ?? Array.Empty<KeyMapping>()).NonNull().ForEach(_groupsKeyMappings.Add);
		}
		if (e.Action == NotifyCollectionChangedAction.Add && sender is PropGroup propGroup)
		{
			propGroup.DeserializeProps(_groupsKeyMappings, fallbackToName: false);
		}
		this.CollectionDataChanged?.Invoke();
	}

	private void TeardownGroup(PropGroup group)
	{
		if (_groupsData.TryGetValue(group, out IPropGroup value))
		{
			group.DataModified -= base.OnDataModified;
			group.CollectionChanged -= Group_CollectionChanged;
			value.PropertyChanged -= Group_PropertyChanged;
			_groupsData.Remove(group);
		}
	}

	private void Group_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		IPropGroup propGroup = sender as IPropGroup;
		if (propGroup != null && e.PropertyName == "Name")
		{
			PropGroup key = _groupsData.FirstOrDefault<KeyValuePair<PropGroup, IPropGroup>>((KeyValuePair<PropGroup, IPropGroup> kvp) => kvp.Value == propGroup).Key;
			if (key != null)
			{
				key.Label = propGroup.Name;
			}
		}
	}

	public void Deserialize(IEnumerable<KeyMapping?>? protoKeyMappings)
	{
		_protoKeyMappings = protoKeyMappings;
		foreach (PropGroup item in base.Children?.OfType<PropGroup>() ?? Enumerable.Empty<PropGroup>())
		{
			item.Deserialize(protoKeyMappings ?? Enumerable.Empty<KeyMapping>());
		}
	}

	[IteratorStateMachine(typeof(_003CSerializeGroups_003Ed__15))]
	public IEnumerable<KeyMapping?> SerializeGroups()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSerializeGroups_003Ed__15(-2)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerable<PropInputAction> GetAllActions()
	{
		return base.Children?.SelectMany((InputActionGroupBase g) => g.OfType<PropInputAction>()) ?? Array.Empty<PropInputAction>();
	}

	private void Deserialize()
	{
		Deserialize(_protoKeyMappings);
	}
}
