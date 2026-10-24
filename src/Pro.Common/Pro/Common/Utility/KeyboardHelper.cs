using System;
using System.Linq;
using System.Windows.Input;

namespace Pro.Common.Utility;

public static class KeyboardHelper
{
	public static bool IsModifierPressed(params ModifierKeys[] keys)
	{
		return keys.Any((ModifierKeys k) => ((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)k));
	}

	public static bool IsModifierKey(this Key key)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		if ((int)key != 118 && (int)key != 119 && (int)key != 120 && (int)key != 121 && (int)key != 116)
		{
			return (int)key == 117;
		}
		return true;
	}
}
