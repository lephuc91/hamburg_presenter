using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using Pro.Common.Utility;

namespace Pro.UI.InputActions;

public static class VirtualKeyGestureExtensions
{
	private static readonly ConstructorInfo? KeyGestureCtor;

	private static readonly MethodInfo? KeyGestureIsValidMethod;

	private static readonly Dictionary<VirtualKey, VirtualKeyDataAttribute> _virtualKeyToDataMap;

	private static readonly Dictionary<Key, VirtualKey> _supportedKeyMap;

	private static readonly Dictionary<string, (VirtualKey key, bool shiftImplied)> _unicodeToVirtualKeyMap;

	static VirtualKeyGestureExtensions()
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		KeyGestureCtor = typeof(KeyGesture).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[4]
		{
			typeof(Key),
			typeof(ModifierKeys),
			typeof(string),
			typeof(bool)
		}, null);
		KeyGestureIsValidMethod = typeof(KeyGesture).GetMethod("IsValid", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, new Type[2]
		{
			typeof(Key),
			typeof(ModifierKeys)
		}, null);
		_virtualKeyToDataMap = new Dictionary<VirtualKey, VirtualKeyDataAttribute>();
		_supportedKeyMap = new Dictionary<Key, VirtualKey>();
		_unicodeToVirtualKeyMap = new Dictionary<string, (VirtualKey, bool)>();
		VirtualKey[] values = Enum.GetValues<VirtualKey>();
		foreach (VirtualKey virtualKey in values)
		{
			VirtualKeyDataAttribute attribute = virtualKey.GetAttribute<VirtualKey, VirtualKeyDataAttribute>();
			_virtualKeyToDataMap.Add(virtualKey, attribute);
			_supportedKeyMap.Add(attribute.Key, virtualKey);
			_unicodeToVirtualKeyMap.Add(attribute.SerializedValue, (virtualKey, false));
			if (attribute.IsShiftImplied && !_unicodeToVirtualKeyMap.ContainsKey(attribute.ShiftedSerializedValue))
			{
				_unicodeToVirtualKeyMap.Add(attribute.ShiftedSerializedValue, (virtualKey, true));
			}
		}
	}

	public static bool IsSupported(this Key key, out VirtualKey virtualKey)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		if (_supportedKeyMap.TryGetValue(key, out virtualKey))
		{
			return virtualKey != VirtualKey.None;
		}
		return false;
	}

	public static VirtualKey FindVirtualKey(this string unicodeString, out bool hasShiftModifier)
	{
		if (_unicodeToVirtualKeyMap.TryGetValue(unicodeString, out (VirtualKey, bool) value))
		{
			hasShiftModifier = value.Item2;
			return value.Item1;
		}
		hasShiftModifier = false;
		return VirtualKey.None;
	}

	public static VirtualKeyDataAttribute GetData(this VirtualKey key)
	{
		return _virtualKeyToDataMap[key];
	}

	public static KeyGesture? ToKeyGesture(this VirtualKeyGesture? virtualKeyGesture)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if ((object)virtualKeyGesture == null)
		{
			return null;
		}
		return (KeyGesture)(KeyGestureCtor?.Invoke(new object[4]
		{
			virtualKeyGesture.Key.GetData().Key,
			virtualKeyGesture.Modifiers,
			virtualKeyGesture.GestureText,
			false
		}));
	}

	public static bool IsValid(this VirtualKeyGesture? virtualKeyGesture)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((object)virtualKeyGesture == null)
		{
			return true;
		}
		object obj = KeyGestureIsValidMethod?.Invoke(null, new object[2]
		{
			virtualKeyGesture.Key.GetData().Key,
			virtualKeyGesture.Modifiers
		});
		if (obj is bool)
		{
			return (bool)obj;
		}
		return false;
	}
}
