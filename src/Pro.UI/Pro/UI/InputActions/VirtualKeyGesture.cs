using System;
using System.Windows.Input;
using Pro.Common.Utility;

namespace Pro.UI.InputActions;

public class VirtualKeyGesture : IEquatable<VirtualKeyGesture>
{
	public VirtualKey Key { get; }

	public ModifierKeys Modifiers { get; }

	public string GestureText { get; }

	private VirtualKeyGesture(VirtualKey key, ModifierKeys modifiers, string gestureText)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		Key = key;
		Modifiers = modifiers;
		GestureText = gestureText;
	}

	public static VirtualKeyGesture? CreateKeyGesture(VirtualKey virtualKey, ModifierKeys modifiers = 0)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		if (virtualKey == VirtualKey.None)
		{
			return null;
		}
		string text = string.Empty;
		if (((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)2))
		{
			text += "Ctrl+";
		}
		if (((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)1))
		{
			text += "Alt+";
		}
		VirtualKeyDataAttribute data = virtualKey.GetData();
		if (!data.IsShiftImplied && ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)4))
		{
			text += "Shift+";
		}
		string text2 = ((data.IsShiftImplied && ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)4)) ? data.ShiftedDisplayText : data.DisplayText);
		string gestureText = text + text2;
		return new VirtualKeyGesture(virtualKey, modifiers, gestureText);
	}

	public bool Equals(VirtualKeyGesture? other)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (Key == other?.Key)
		{
			return Modifiers == other.Modifiers;
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is VirtualKeyGesture other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		return HashCodeHelper.GenerateHashCode(Key, Modifiers);
	}

	public static bool operator ==(VirtualKeyGesture? lhs, VirtualKeyGesture? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(VirtualKeyGesture? lhs, VirtualKeyGesture? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
