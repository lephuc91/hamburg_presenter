using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public static class InputActionSerializationExtensions
{
	public static KeyMapping? Serialize(this InputAction inputAction)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		if (!inputAction.IsCustomized)
		{
			return null;
		}
		KeyMapping keyMapping = new KeyMapping
		{
			Keyboard = new KeyMapping.Types.ComputerKeyboard()
		};
		if ((object)inputAction.KeyboardGesture != null)
		{
			keyMapping.Keyboard.KeyEquivalentModifierFlags.AddRange(inputAction.KeyboardGesture.Modifiers.ToProtoModifierFlags());
			VirtualKeyDataAttribute data = inputAction.KeyboardGesture.Key.GetData();
			keyMapping.Keyboard.KeyEquivalent = ((data.IsShiftImplied && ((Enum)inputAction.KeyboardGesture.Modifiers).HasFlag((Enum)(object)(ModifierKeys)4)) ? data.ShiftedSerializedValue : data.SerializedValue);
		}
		if (inputAction.Type == InputActionType.MenuItem)
		{
			keyMapping.MenuItem = inputAction.Identifier ?? string.Empty;
		}
		else if (inputAction is ClearGroupInputAction clearGroupInputAction)
		{
			keyMapping.ClearGroupIdentifier = new CollectionElementType
			{
				ParameterUuid = clearGroupInputAction.ClearGroupId?.ID.ToUUID(),
				ParameterName = (clearGroupInputAction.ClearGroupId?.Name ?? string.Empty)
			};
		}
		else if (inputAction is GroupLabelInputAction groupLabelInputAction)
		{
			keyMapping.GroupIdentifier = new CollectionElementType
			{
				ParameterUuid = groupLabelInputAction.GroupLabelId?.ID.ToUUID(),
				ParameterName = (groupLabelInputAction.GroupLabelId?.Name ?? string.Empty)
			};
		}
		else if (inputAction is MacroInputAction macroInputAction)
		{
			keyMapping.MacroIdentifier = new CollectionElementType
			{
				ParameterUuid = macroInputAction.MacroId?.ID.ToUUID(),
				ParameterName = (macroInputAction.MacroId?.Name ?? string.Empty)
			};
		}
		else if (inputAction is PropInputAction propInputAction)
		{
			keyMapping.PropIdentifier = new CollectionElementType
			{
				ParameterUuid = propInputAction.PropId?.ID.ToUUID(),
				ParameterName = (propInputAction.PropId?.Name ?? string.Empty)
			};
		}
		return keyMapping;
	}

	public static IEnumerable<KeyMapping> Serialize(this InputActionGroupBase group)
	{
		return group.Select((InputAction i) => i.Serialize()).NonNull();
	}

	public static void DeserializeKeyboardGesture(this InputAction action, KeyMapping proto)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (action == null || proto == null)
		{
			return;
		}
		ModifierKeys val = proto.Keyboard.KeyEquivalentModifierFlags.ToModifierKeys();
		bool hasShiftModifier;
		VirtualKey virtualKey = proto.Keyboard.KeyEquivalent.FindVirtualKey(out hasShiftModifier);
		if (virtualKey == VirtualKey.None)
		{
			action.KeyboardGesture = null;
			return;
		}
		if (hasShiftModifier && !((Enum)val).HasFlag((Enum)(object)(ModifierKeys)4))
		{
			val = (ModifierKeys)(val | 4);
		}
		action.KeyboardGesture = VirtualKeyGesture.CreateKeyGesture(virtualKey, val);
	}

	public static void DeserializeMenu(this InputActionGroupBase group, IEnumerable<KeyMapping> protoKeyMappings)
	{
		KeyMapping[] array = protoKeyMappings.Where((KeyMapping i) => i.MenuItem != null).ToArray();
		foreach (KeyMapping protoKeyMap in array)
		{
			group.FirstOrDefault((InputAction a) => a.Identifier == protoKeyMap.MenuItem)?.DeserializeKeyboardGesture(protoKeyMap);
		}
	}
}
