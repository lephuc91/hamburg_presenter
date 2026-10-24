using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class CueReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static CueReflection()
	{
		_003C_003Ey__InlineArray26<string> buffer = default(_003C_003Ey__InlineArray26<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 0) = "CgljdWUucHJvdG8SB3J2LmRhdGEaDGFjdGlvbi5wcm90bxoTY3VzdG9tT3B0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 1) = "aW9ucy5wcm90bxoMaG90S2V5LnByb3RvGgl1cmwucHJvdG8aCnV1aWQucHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 2) = "dG8i5AcKA0N1ZRIbCgR1dWlkGAEgASgLMg0ucnYuZGF0YS5VVUlEEhIKBG5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 3) = "bWUYAiABKAlCBKCGGQESQQoWY29tcGxldGlvbl90YXJnZXRfdHlwZRgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 4) = "DjIhLnJ2LmRhdGEuQ3VlLkNvbXBsZXRpb25UYXJnZXRUeXBlEjMKFmNvbXBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 5) = "ZXRpb25fdGFyZ2V0X3V1aWQYBCABKAsyDS5ydi5kYXRhLlVVSURCBKCGGQES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 6) = "QQoWY29tcGxldGlvbl9hY3Rpb25fdHlwZRgFIAEoDjIhLnJ2LmRhdGEuQ3Vl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 7) = "LkNvbXBsZXRpb25BY3Rpb25UeXBlEjMKFmNvbXBsZXRpb25fYWN0aW9uX3V1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 8) = "aWQYBiABKAsyDS5ydi5kYXRhLlVVSURCBKCGGQESNQoMdHJpZ2dlcl90aW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 9) = "GAcgASgLMhkucnYuZGF0YS5DdWUuVGltZWNvZGVUaW1lQgSohhkBEiAKB2hv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 10) = "dF9rZXkYCCABKAsyDy5ydi5kYXRhLkhvdEtleRIgCgdhY3Rpb25zGAogAygL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 11) = "Mg8ucnYuZGF0YS5BY3Rpb24SPwoPcGVuZGluZ19pbXBvcnRzGAsgAygLMiAu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 12) = "cnYuZGF0YS5DdWUuUGVuZGluZ0ltcG9ydHNFbnRyeUIEqIYZARIRCglpc0Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 13) = "YWJsZWQYDCABKAgSFwoPY29tcGxldGlvbl90aW1lGA0gASgBGhwKDFRpbWVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 14) = "b2RlVGltZRIMCgR0aW1lGAEgASgBGkQKE1BlbmRpbmdJbXBvcnRzRW50cnkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 15) = "CwoDa2V5GAEgASgJEhwKBXZhbHVlGAIgASgLMg0ucnYuZGF0YS5VUkxzOgI4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 16) = "ASK9AQoUQ29tcGxldGlvblRhcmdldFR5cGUSHwobQ09NUExFVElPTl9UQVJH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 17) = "RVRfVFlQRV9OT05FEAASHwobQ09NUExFVElPTl9UQVJHRVRfVFlQRV9ORVhU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 18) = "EAESIQodQ09NUExFVElPTl9UQVJHRVRfVFlQRV9SQU5ET00QAhIeChpDT01Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 19) = "TEVUSU9OX1RBUkdFVF9UWVBFX0NVRRADEiAKHENPTVBMRVRJT05fVEFSR0VU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 20) = "X1RZUEVfRklSU1QQBCKpAQoUQ29tcGxldGlvbkFjdGlvblR5cGUSIAocQ09N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 21) = "UExFVElPTl9BQ1RJT05fVFlQRV9GSVJTVBAAEh8KG0NPTVBMRVRJT05fQUNU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 22) = "SU9OX1RZUEVfTEFTVBABEicKI0NPTVBMRVRJT05fQUNUSU9OX1RZUEVfQUZU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 23) = "RVJfQUNUSU9OEAISJQohQ09NUExFVElPTl9BQ1RJT05fVFlQRV9BRlRFUl9U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 24) = "SU1FEANKBAgJEApCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray26<string>, string>(ref buffer, 25) = "VlByb3RvRGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray26<string>, string>(in buffer, 26))), new FileDescriptor[5]
		{
			ActionReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			HotKeyReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Cue), Cue.Parser, new string[12]
			{
				"Uuid", "Name", "CompletionTargetType", "CompletionTargetUuid", "CompletionActionType", "CompletionActionUuid", "TriggerTime", "HotKey", "Actions", "PendingImports",
				"IsEnabled", "CompletionTime"
			}, null, new Type[2]
			{
				typeof(Cue.Types.CompletionTargetType),
				typeof(Cue.Types.CompletionActionType)
			}, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(Cue.Types.TimecodeTime), Cue.Types.TimecodeTime.Parser, new string[1] { "Time" }, null, null, null, null),
				null
			})
		}));
	}
}
