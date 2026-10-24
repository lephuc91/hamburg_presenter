using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace Pro.UI.InputActions;

public class VirtualKeyDataAttribute : Attribute
{
	public Key Key { get; }

	public string DisplayText { get; }

	public string SerializedValue { get; }

	[MemberNotNullWhen(true, "ShiftedDisplayText")]
	[MemberNotNullWhen(true, "ShiftedSerializedValue")]
	public bool IsShiftImplied
	{
		[MemberNotNullWhen(true, "ShiftedDisplayText")]
		[MemberNotNullWhen(true, "ShiftedSerializedValue")]
		get;
	}

	public string? ShiftedDisplayText { get; }

	public string? ShiftedSerializedValue { get; }

	public VirtualKeyDataAttribute(Key key, string displayText, string serializedValue)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		Key = key;
		DisplayText = displayText;
		SerializedValue = serializedValue;
	}

	public VirtualKeyDataAttribute(Key key, string displayText, string serializedValue, string shiftedDisplayText, string shiftedSerializedValue)
		: this(key, displayText, serializedValue)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		ShiftedDisplayText = shiftedDisplayText;
		ShiftedSerializedValue = shiftedSerializedValue;
		IsShiftImplied = true;
	}
}
