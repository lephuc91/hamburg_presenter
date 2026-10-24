using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class KeymappingReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static KeymappingReflection()
	{
		_003C_003Ey__InlineArray29<string> buffer = default(_003C_003Ey__InlineArray29<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 0) = "ChBrZXltYXBwaW5nLnByb3RvEgdydi5kYXRhGhVhcHBsaWNhdGlvbkluZm8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 1) = "cHJvdG8aG2NvbGxlY3Rpb25FbGVtZW50VHlwZS5wcm90bxoTY3VzdG9tT3B0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 2) = "aW9ucy5wcm90byL9BgoKS2V5TWFwcGluZxI2CghrZXlib2FyZBgBIAEoCzIk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 3) = "LnJ2LmRhdGEuS2V5TWFwcGluZy5Db21wdXRlcktleWJvYXJkEi4KBG1pZGkY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 4) = "AiABKAsyIC5ydi5kYXRhLktleU1hcHBpbmcuTUlESUtleWJvYXJkEhMKCW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 5) = "bnVfaXRlbRhkIAEoCUgAEkAKFmNsZWFyX2dyb3VwX2lkZW50aWZpZXIYZSAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 6) = "KAsyHi5ydi5kYXRhLkNvbGxlY3Rpb25FbGVtZW50VHlwZUgAEjgKDmN1ZV9p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 7) = "ZGVudGlmaWVyGGYgASgLMh4ucnYuZGF0YS5Db2xsZWN0aW9uRWxlbWVudFR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 8) = "cGVIABI6ChBncm91cF9pZGVudGlmaWVyGGcgASgLMh4ucnYuZGF0YS5Db2xs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 9) = "ZWN0aW9uRWxlbWVudFR5cGVIABI6ChBtYWNyb19pZGVudGlmaWVyGGggASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 10) = "Mh4ucnYuZGF0YS5Db2xsZWN0aW9uRWxlbWVudFR5cGVIABI5Cg9wcm9wX2lk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 11) = "ZW50aWZpZXIYaSABKAsyHi5ydi5kYXRhLkNvbGxlY3Rpb25FbGVtZW50VHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 12) = "ZUgAEjoKEHRpbWVyX2lkZW50aWZpZXIYaiABKAsyHi5ydi5kYXRhLkNvbGxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 13) = "Y3Rpb25FbGVtZW50VHlwZUgAGrACChBDb21wdXRlcktleWJvYXJkEhYKDmtl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 14) = "eV9lcXVpdmFsZW50GAEgASgJElkKHWtleV9lcXVpdmFsZW50X21vZGlmaWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 15) = "X2ZsYWdzGAIgAygOMjIucnYuZGF0YS5LZXlNYXBwaW5nLkNvbXB1dGVyS2V5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 16) = "Ym9hcmQuTW9kaWZpZXJGbGFncyKoAQoNTW9kaWZpZXJGbGFncxIdChlNT0RJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 17) = "RklFUkZMQUdTX0NPTU1BTkRfS0VZEAASGwoXTU9ESUZJRVJGTEFHU19TSElG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 18) = "VF9LRVkQARIcChhNT0RJRklFUkZMQUdTX09QVElPTl9LRVkQAhIdChlNT0RJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 19) = "RklFUkZMQUdTX0NPTlRST0xfS0VZEAMSHgoaTU9ESUZJRVJGTEFHU19GVU5D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 20) = "VElPTl9LRVkQBBpACgxNSURJS2V5Ym9hcmQSDwoHY2hhbm5lbBgBIAEoBRIN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 21) = "CgVwaXRjaBgCIAEoBRIQCgh2ZWxvY2l0eRgDIAEoBUISChBUYXJnZXRJZGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 22) = "dGlmaWVyItoBChJLZXlNYXBwaW5nRG9jdW1lbnQSOAoQYXBwbGljYXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 23) = "aW5mbxgBIAEoCzIYLnJ2LmRhdGEuQXBwbGljYXRpb25JbmZvQgSohhkBEigK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 24) = "C2tleW1hcHBpbmdzGAIgAygLMhMucnYuZGF0YS5LZXlNYXBwaW5nEi4KEW1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 25) = "Y29zX2tleW1hcHBpbmdzGAMgAygLMhMucnYuZGF0YS5LZXlNYXBwaW5nEjAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 26) = "E3dpbmRvd3Nfa2V5bWFwcGluZ3MYBCADKAsyEy5ydi5kYXRhLktleU1hcHBp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 27) = "bmdCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 28) = "YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray29<string>, string>(in buffer, 29))), new FileDescriptor[3]
		{
			ApplicationInfoReflection.Descriptor,
			CollectionElementTypeReflection.Descriptor,
			CustomOptionsReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(KeyMapping), KeyMapping.Parser, new string[9] { "Keyboard", "Midi", "MenuItem", "ClearGroupIdentifier", "CueIdentifier", "GroupIdentifier", "MacroIdentifier", "PropIdentifier", "TimerIdentifier" }, new string[1] { "TargetIdentifier" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(KeyMapping.Types.ComputerKeyboard), KeyMapping.Types.ComputerKeyboard.Parser, new string[2] { "KeyEquivalent", "KeyEquivalentModifierFlags" }, null, new Type[1] { typeof(KeyMapping.Types.ComputerKeyboard.Types.ModifierFlags) }, null, null),
				new GeneratedClrTypeInfo(typeof(KeyMapping.Types.MIDIKeyboard), KeyMapping.Types.MIDIKeyboard.Parser, new string[3] { "Channel", "Pitch", "Velocity" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(KeyMappingDocument), KeyMappingDocument.Parser, new string[4] { "ApplicationInfo", "Keymappings", "MacosKeymappings", "WindowsKeymappings" }, null, null, null, null)
		}));
	}
}
