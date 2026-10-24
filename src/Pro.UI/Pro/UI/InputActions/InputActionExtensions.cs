using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.UI.InputActions;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags), typeof(IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags), DestinationToSourceMethodName = "ToProtoModifierFlag", SourceDefaultValue = "CommandKey", SourceToDestinationMethodName = "ToEntityModifierFlag", DestinationDefaultValue = "CommandKey")]
public static class InputActionExtensions
{
	[CompilerGenerated]
	private sealed class _003CToEntityModifierFlags_003Ed__1 : IEnumerable<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags>, IEnumerable, IEnumerator<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ModifierKeys modifierKeys;

		public ModifierKeys _003C_003E3__modifierKeys;

		IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags IEnumerator<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags>.Current
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
		public _003CToEntityModifierFlags_003Ed__1(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)2))
				{
					_003C_003E2__current = IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.ControlKey;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0055;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0055;
			case 2:
				_003C_003E1__state = -1;
				goto IL_0084;
			case 3:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_0084:
				if (((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)1))
				{
					_003C_003E2__current = IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.OptionKey;
					_003C_003E1__state = 3;
					return true;
				}
				break;
				IL_0055:
				if (((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)4))
				{
					_003C_003E2__current = IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.ShiftKey;
					_003C_003E1__state = 2;
					return true;
				}
				goto IL_0084;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags> IEnumerable<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags>.GetEnumerator()
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			_003CToEntityModifierFlags_003Ed__1 _003CToEntityModifierFlags_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CToEntityModifierFlags_003Ed__ = this;
			}
			else
			{
				_003CToEntityModifierFlags_003Ed__ = new _003CToEntityModifierFlags_003Ed__1(0);
			}
			_003CToEntityModifierFlags_003Ed__.modifierKeys = _003C_003E3__modifierKeys;
			return _003CToEntityModifierFlags_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CToProtoModifierFlags_003Ed__0 : IEnumerable<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags>, IEnumerable, IEnumerator<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ModifierKeys modifierKeys;

		public ModifierKeys _003C_003E3__modifierKeys;

		KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags IEnumerator<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags>.Current
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
		public _003CToProtoModifierFlags_003Ed__0(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)2))
				{
					_003C_003E2__current = KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.ControlKey;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0055;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0055;
			case 2:
				_003C_003E1__state = -1;
				goto IL_0084;
			case 3:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_0084:
				if (((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)1))
				{
					_003C_003E2__current = KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.OptionKey;
					_003C_003E1__state = 3;
					return true;
				}
				break;
				IL_0055:
				if (((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)4))
				{
					_003C_003E2__current = KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.ShiftKey;
					_003C_003E1__state = 2;
					return true;
				}
				goto IL_0084;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags> IEnumerable<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags>.GetEnumerator()
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			_003CToProtoModifierFlags_003Ed__0 _003CToProtoModifierFlags_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CToProtoModifierFlags_003Ed__ = this;
			}
			else
			{
				_003CToProtoModifierFlags_003Ed__ = new _003CToProtoModifierFlags_003Ed__0(0);
			}
			_003CToProtoModifierFlags_003Ed__.modifierKeys = _003C_003E3__modifierKeys;
			return _003CToProtoModifierFlags_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags>)this).GetEnumerator();
		}
	}

	[IteratorStateMachine(typeof(_003CToProtoModifierFlags_003Ed__0))]
	public static IEnumerable<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags> ToProtoModifierFlags(this ModifierKeys modifierKeys)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToProtoModifierFlags_003Ed__0(-2)
		{
			_003C_003E3__modifierKeys = modifierKeys
		};
	}

	[IteratorStateMachine(typeof(_003CToEntityModifierFlags_003Ed__1))]
	public static IEnumerable<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags> ToEntityModifierFlags(this ModifierKeys modifierKeys)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToEntityModifierFlags_003Ed__1(-2)
		{
			_003C_003E3__modifierKeys = modifierKeys
		};
	}

	public static ModifierKeys ToModifierKeys(this IEnumerable<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags> protoData)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		ModifierKeys val = (ModifierKeys)0;
		using IEnumerator<KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags> enumerator = protoData.GetEnumerator();
		while (enumerator.MoveNext())
		{
			switch (enumerator.Current)
			{
			case KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.ShiftKey:
				val = (ModifierKeys)(val | 4);
				break;
			case KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.OptionKey:
				val = (ModifierKeys)(val | 1);
				break;
			case KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.ControlKey:
				val = (ModifierKeys)(val | 2);
				break;
			}
		}
		return val;
	}

	public static ModifierKeys ToModifierKeys(this IEnumerable<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags> protoData)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		ModifierKeys val = (ModifierKeys)0;
		using IEnumerator<IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags> enumerator = protoData.GetEnumerator();
		while (enumerator.MoveNext())
		{
			switch (enumerator.Current)
			{
			case IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.ShiftKey:
				val = (ModifierKeys)(val | 4);
				break;
			case IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.OptionKey:
				val = (ModifierKeys)(val | 1);
				break;
			case IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.ControlKey:
				val = (ModifierKeys)(val | 2);
				break;
			}
		}
		return val;
	}

	public static IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags ToEntityModifierFlag(this KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags source)
	{
		return source switch
		{
			KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.CommandKey => IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.CommandKey, 
			KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.ShiftKey => IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.ShiftKey, 
			KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.OptionKey => IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.OptionKey, 
			KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.ControlKey => IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.ControlKey, 
			KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.FunctionKey => IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.FunctionKey, 
			_ => IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.CommandKey, 
		};
	}

	public static KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags ToProtoModifierFlag(this IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags source)
	{
		return source switch
		{
			IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.CommandKey => KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.CommandKey, 
			IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.ShiftKey => KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.ShiftKey, 
			IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.OptionKey => KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.OptionKey, 
			IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.ControlKey => KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.ControlKey, 
			IKeyMapping.Types.IComputerKeyboard.Types.ModifierFlags.FunctionKey => KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.FunctionKey, 
			_ => KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags.CommandKey, 
		};
	}
}
