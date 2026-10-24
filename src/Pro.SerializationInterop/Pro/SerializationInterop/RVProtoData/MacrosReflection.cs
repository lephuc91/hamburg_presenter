using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class MacrosReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static MacrosReflection()
	{
		_003C_003Ey__InlineArray49<string> buffer = default(_003C_003Ey__InlineArray49<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 0) = "CgxtYWNyb3MucHJvdG8SB3J2LmRhdGEaDGFjdGlvbi5wcm90bxoVYXBwbGlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 1) = "YXRpb25JbmZvLnByb3RvGgtjb2xvci5wcm90bxoTY3VzdG9tT3B0aW9ucy5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 2) = "cm90bxoKdXVpZC5wcm90byLWDwoOTWFjcm9zRG9jdW1lbnQSOAoQYXBwbGlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 3) = "YXRpb25faW5mbxgBIAEoCzIYLnJ2LmRhdGEuQXBwbGljYXRpb25JbmZvQgSo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 4) = "hhkBEjMKBm1hY3JvcxgCIAMoCzIdLnJ2LmRhdGEuTWFjcm9zRG9jdW1lbnQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 5) = "TWFjcm9CBKiGGQESQgoRbWFjcm9fY29sbGVjdGlvbnMYAyADKAsyJy5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 6) = "YXRhLk1hY3Jvc0RvY3VtZW50Lk1hY3JvQ29sbGVjdGlvbhqoDAoFTWFjcm8S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 7) = "GwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBIMCgRuYW1lGAIgASgJEh0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 8) = "BWNvbG9yGAMgASgLMg4ucnYuZGF0YS5Db2xvchIgCgdhY3Rpb25zGAQgAygL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 9) = "Mg8ucnYuZGF0YS5BY3Rpb24SGgoSdHJpZ2dlcl9vbl9zdGFydHVwGAUgASgI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 10) = "EjsKCmltYWdlX3R5cGUYBiABKA4yJy5ydi5kYXRhLk1hY3Jvc0RvY3VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 11) = "Lk1hY3JvLkltYWdlVHlwZRIYCgppbWFnZV9kYXRhGAcgASgMQgSghhkBIr8K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 12) = "CglJbWFnZVR5cGUSFAoQSW1hZ2VUeXBlRGVmYXVsdBAAEhAKDEltYWdlVHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 13) = "ZU9uZRABEhAKDEltYWdlVHlwZVR3bxACEhIKDkltYWdlVHlwZVRocmVlEAMS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 14) = "EQoNSW1hZ2VUeXBlRm91chAEEhEKDUltYWdlVHlwZUZpdmUQBRIQCgxJbWFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 15) = "ZVR5cGVTaXgQBhISCg5JbWFnZVR5cGVTZXZlbhAHEhIKDkltYWdlVHlwZUVp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 16) = "Z2h0EAgSEQoNSW1hZ2VUeXBlTmluZRAJEhEKDUltYWdlVHlwZVplcm8QChIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 17) = "Cg5JbWFnZVR5cGVBcnJvdxALEhIKDkltYWdlVHlwZUF1ZGlvEAwSEQoNSW1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 18) = "Z2VUeXBlQmVsbBANEhEKDUltYWdlVHlwZUJ1bGIQDhISCg5JbWFnZVR5cGVD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 19) = "bG91ZBAPEhQKEEltYWdlVHlwZUN1cGNha2UQEBIYChRJbWFnZVR5cGVFeGNs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 20) = "YW1hdGlvbhAREhIKDkltYWdlVHlwZUZsYXNrEBISEwoPSW1hZ2VUeXBlRmxv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 21) = "d2VyEBMSFAoQSW1hZ2VUeXBlR2xhc3NlcxAUEhQKEEltYWdlVHlwZUhhc2h0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 22) = "YWcQFRIQCgxJbWFnZVR5cGVIYXQQFhISCg5JbWFnZVR5cGVIZWFydBAXEhYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 23) = "EkltYWdlVHlwZU1lZ2FwaG9uZRAYEhQKEEltYWdlVHlwZU1lc3NhZ2UQGRIW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 24) = "ChJJbWFnZVR5cGVQYXBlcmNsaXAQGhIRCg1JbWFnZVR5cGVQbGF5EBsSEgoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 25) = "SW1hZ2VUeXBlU2xpZGUQHBIRCg1JbWFnZVR5cGVTdGFyEB0SEAoMSW1hZ2VU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 26) = "eXBlU3VuEB4SFwoTSW1hZ2VUeXBlU3VuZ2xhc3NlcxAfEhMKD0ltYWdlVHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 27) = "ZVRhcmdldBAgEhIKDkltYWdlVHlwZVRpbWVyECESFwoTSW1hZ2VUeXBlVmlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 28) = "ZW9JbnB1dBAiEhMKD0ltYWdlVHlwZVhDbGVhchAjEhQKEEltYWdlVHlwZUxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 29) = "dHRlckEQJBIUChBJbWFnZVR5cGVMZXR0ZXJCECUSFAoQSW1hZ2VUeXBlTGV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 30) = "dGVyQxAmEhQKEEltYWdlVHlwZUxldHRlckQQJxIUChBJbWFnZVR5cGVMZXR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 31) = "ZXJFECgSFAoQSW1hZ2VUeXBlTGV0dGVyRhApEhQKEEltYWdlVHlwZUxldHRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 32) = "ckcQKhIUChBJbWFnZVR5cGVMZXR0ZXJIECsSFAoQSW1hZ2VUeXBlTGV0dGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 33) = "SRAsEhQKEEltYWdlVHlwZUxldHRlckoQLRIUChBJbWFnZVR5cGVMZXR0ZXJL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 34) = "EC4SFAoQSW1hZ2VUeXBlTGV0dGVyTBAvEhQKEEltYWdlVHlwZUxldHRlck0Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 35) = "MBIUChBJbWFnZVR5cGVMZXR0ZXJOEDESFAoQSW1hZ2VUeXBlTGV0dGVyTxAy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 36) = "EhQKEEltYWdlVHlwZUxldHRlclAQMxIUChBJbWFnZVR5cGVMZXR0ZXJREDQS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 37) = "FAoQSW1hZ2VUeXBlTGV0dGVyUhA1EhQKEEltYWdlVHlwZUxldHRlclMQNhIU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 38) = "ChBJbWFnZVR5cGVMZXR0ZXJUEDcSFAoQSW1hZ2VUeXBlTGV0dGVyVRA4EhQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 39) = "EEltYWdlVHlwZUxldHRlclYQORIUChBJbWFnZVR5cGVMZXR0ZXJXEDoSFAoQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 40) = "SW1hZ2VUeXBlTGV0dGVyWBA7EhQKEEltYWdlVHlwZUxldHRlclkQPBIUChBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 41) = "bWFnZVR5cGVMZXR0ZXJaED0SEwoPSW1hZ2VUeXBlQ3VzdG9tED4a5QEKD01h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 42) = "Y3JvQ29sbGVjdGlvbhIbCgR1dWlkGAEgASgLMg0ucnYuZGF0YS5VVUlEEgwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 43) = "BG5hbWUYAiABKAkSQQoFaXRlbXMYAyADKAsyLC5ydi5kYXRhLk1hY3Jvc0Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 44) = "Y3VtZW50Lk1hY3JvQ29sbGVjdGlvbi5JdGVtQgSohhkBEi0KBm1hY3JvcxgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 45) = "IAMoCzIdLnJ2LmRhdGEuTWFjcm9zRG9jdW1lbnQuTWFjcm8aNQoESXRlbRIh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 46) = "CghtYWNyb19pZBgBIAEoCzINLnJ2LmRhdGEuVVVJREgAQgoKCEl0ZW1UeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 47) = "QjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 48) = "AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray49<string>, string>(in buffer, 49))), new FileDescriptor[5]
		{
			ActionReflection.Descriptor,
			ApplicationInfoReflection.Descriptor,
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(MacrosDocument), MacrosDocument.Parser, new string[3] { "ApplicationInfo", "Macros", "MacroCollections" }, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(MacrosDocument.Types.Macro), MacrosDocument.Types.Macro.Parser, new string[7] { "Uuid", "Name", "Color", "Actions", "TriggerOnStartup", "ImageType", "ImageData" }, null, new Type[1] { typeof(MacrosDocument.Types.Macro.Types.ImageType) }, null, null),
				new GeneratedClrTypeInfo(typeof(MacrosDocument.Types.MacroCollection), MacrosDocument.Types.MacroCollection.Parser, new string[4] { "Uuid", "Name", "Items", "Macros" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(MacrosDocument.Types.MacroCollection.Types.Item), MacrosDocument.Types.MacroCollection.Types.Item.Parser, new string[1] { "MacroId" }, new string[1] { "ItemType" }, null, null, null)
				})
			})
		}));
	}
}
