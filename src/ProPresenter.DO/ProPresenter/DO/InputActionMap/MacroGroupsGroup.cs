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
using ProPresenter.DO.MacroGroups;

namespace ProPresenter.DO.InputActionMap;

public class MacroGroupsGroup : InputActionGroupBase
{
	[CompilerGenerated]
	private sealed class _003CSerializeGroups_003Ed__15 : IEnumerable<KeyMapping>, IEnumerable, IEnumerator<KeyMapping>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private KeyMapping? _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public MacroGroupsGroup _003C_003E4__this;

		private IEnumerator<InputAction> _003C_003E7__wrap1;

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
				MacroGroupsGroup macroGroupsGroup = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (macroGroupsGroup.Children == null)
					{
						return false;
					}
					_003C_003E7__wrap1 = macroGroupsGroup.Children.SelectMany((InputActionGroupBase g) => g).GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					InputAction current = _003C_003E7__wrap1.Current;
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

	private readonly MacroGroupsInputActionCollection _children;

	private readonly Dictionary<MacroGroup, IMacroGroup> _macroGroupsData = new Dictionary<MacroGroup, IMacroGroup>();

	private readonly List<KeyMapping> _macroGroupsKeyMappings = new List<KeyMapping>();

	internal event System.Action? CollectionDataChanged;

	public MacroGroupsGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		_children = new MacroGroupsInputActionCollection(SetupGroup, TeardownGroup);
		base.Children = _children;
		base.Children.CollectionChanged += Children_CollectionChanged;
	}

	private void Children_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		this.CollectionDataChanged?.Invoke();
	}

	public void Initilalize(IMacroGroupCollection macroGroupCollection)
	{
		_children.ChangeSource(macroGroupCollection);
		Deserialize();
	}

	private MacroGroup SetupGroup(IMacroGroup group)
	{
		MacroGroup macroGroup = new MacroGroup(group.Name, _children);
		macroGroup.Initialize(group);
		macroGroup.DataModified += base.OnDataModified;
		group.PropertyChanged += Group_PropertyChanged;
		macroGroup.CollectionChanged += Group_CollectionChanged;
		_macroGroupsData[macroGroup] = group;
		return macroGroup;
	}

	private void Group_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Remove)
		{
			((from g in e.OldItems?.OfType<MacroInputAction>()
				select g.Serialize()).ToArray() ?? Array.Empty<KeyMapping>()).NonNull().ForEach(_macroGroupsKeyMappings.Add);
		}
		if (e.Action == NotifyCollectionChangedAction.Add && sender is MacroGroup macroGroup)
		{
			macroGroup.DeserializeMacros(_macroGroupsKeyMappings, fallbackToName: false);
		}
		this.CollectionDataChanged?.Invoke();
	}

	private void TeardownGroup(MacroGroup group)
	{
		if (_macroGroupsData.TryGetValue(group, out IMacroGroup value))
		{
			group.DataModified -= base.OnDataModified;
			group.CollectionChanged -= Group_CollectionChanged;
			value.PropertyChanged -= Group_PropertyChanged;
			_macroGroupsData.Remove(group);
		}
	}

	private void Group_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		IMacroGroup macroGroup = sender as IMacroGroup;
		if (macroGroup != null && e.PropertyName == "Name")
		{
			MacroGroup key = _macroGroupsData.FirstOrDefault<KeyValuePair<MacroGroup, IMacroGroup>>((KeyValuePair<MacroGroup, IMacroGroup> kvp) => kvp.Value == macroGroup).Key;
			if (key != null)
			{
				key.Label = macroGroup.Name;
			}
		}
	}

	public void Deserialize(IEnumerable<KeyMapping?>? protoKeyMappings)
	{
		_protoKeyMappings = protoKeyMappings;
		foreach (MacroGroup item in base.Children?.OfType<MacroGroup>() ?? Enumerable.Empty<MacroGroup>())
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

	private void Deserialize()
	{
		Deserialize(_protoKeyMappings);
	}
}
