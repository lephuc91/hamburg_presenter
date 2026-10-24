using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class EffectsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static EffectsReflection()
	{
		_003C_003Ey__InlineArray42<string> buffer = default(_003C_003Ey__InlineArray42<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 0) = "Cg1lZmZlY3RzLnByb3RvEgdydi5kYXRhGgtjb2xvci5wcm90bxoTY3VzdG9t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 1) = "T3B0aW9ucy5wcm90bxoKdXVpZC5wcm90byLnCwoGRWZmZWN0EhsKBHV1aWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 2) = "ASABKAsyDS5ydi5kYXRhLlVVSUQSDwoHZW5hYmxlZBgCIAEoCBIMCgRuYW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 3) = "GAMgASgJEhEKCXJlbmRlcl9pZBgEIAEoCRIcChRiZWhhdmlvcl9kZXNjcmlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 4) = "dGlvbhgFIAEoCRIQCghjYXRlZ29yeRgGIAEoCRIxCgl2YXJpYWJsZXMYByAD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 5) = "KAsyHi5ydi5kYXRhLkVmZmVjdC5FZmZlY3RWYXJpYWJsZRrTCQoORWZmZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 6) = "VmFyaWFibGUSDAoEbmFtZRgBIAEoCRITCgtkZXNjcmlwdGlvbhgCIAEoCRI3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 7) = "CgNpbnQYAyABKAsyKC5ydi5kYXRhLkVmZmVjdC5FZmZlY3RWYXJpYWJsZS5F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 8) = "ZmZlY3RJbnRIABI7CgVmbG9hdBgEIAEoCzIqLnJ2LmRhdGEuRWZmZWN0LkVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 9) = "ZmVjdFZhcmlhYmxlLkVmZmVjdEZsb2F0SAASOwoFY29sb3IYBSABKAsyKi5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 10) = "di5kYXRhLkVmZmVjdC5FZmZlY3RWYXJpYWJsZS5FZmZlY3RDb2xvckgAEkMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 11) = "CWRpcmVjdGlvbhgGIAEoCzIuLnJ2LmRhdGEuRWZmZWN0LkVmZmVjdFZhcmlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 12) = "YmxlLkVmZmVjdERpcmVjdGlvbkgAEj0KBmRvdWJsZRgHIAEoCzIrLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 13) = "dGEuRWZmZWN0LkVmZmVjdFZhcmlhYmxlLkVmZmVjdERvdWJsZUgAGksKCUVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 14) = "ZmVjdEludBINCgV2YWx1ZRgBIAEoBRIVCg1kZWZhdWx0X3ZhbHVlGAIgASgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 15) = "EgsKA21pbhgDIAEoBRILCgNtYXgYBCABKAUaTQoLRWZmZWN0RmxvYXQSDQoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 16) = "dmFsdWUYASABKAISFQoNZGVmYXVsdF92YWx1ZRgCIAEoAhILCgNtaW4YAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 17) = "KAISCwoDbWF4GAQgASgCGk4KDEVmZmVjdERvdWJsZRINCgV2YWx1ZRgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 18) = "ARIVCg1kZWZhdWx0X3ZhbHVlGAIgASgBEgsKA21pbhgDIAEoARILCgNtYXgY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 19) = "BCABKAEaUwoLRWZmZWN0Q29sb3ISHQoFY29sb3IYASABKAsyDi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 20) = "LkNvbG9yEiUKDWRlZmF1bHRfY29sb3IYAiABKAsyDi5ydi5kYXRhLkNvbG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 21) = "Gp0ECg9FZmZlY3REaXJlY3Rpb24SUQoJZGlyZWN0aW9uGAEgASgOMj4ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 22) = "ZGF0YS5FZmZlY3QuRWZmZWN0VmFyaWFibGUuRWZmZWN0RGlyZWN0aW9uLkVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 23) = "ZmVjdERpcmVjdGlvbhJZChFkZWZhdWx0X2RpcmVjdGlvbhgCIAEoDjI+LnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 24) = "LmRhdGEuRWZmZWN0LkVmZmVjdFZhcmlhYmxlLkVmZmVjdERpcmVjdGlvbi5F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 25) = "ZmZlY3REaXJlY3Rpb24SHAoUYXZhaWxhYmxlX2RpcmVjdGlvbnMYAyABKA0i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 26) = "vQIKD0VmZmVjdERpcmVjdGlvbhIZChVFRkZFQ1RfRElSRUNUSU9OX05PTkUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 27) = "ABIdChlFRkZFQ1RfRElSRUNUSU9OX1RPUF9MRUZUEAESGAoURUZGRUNUX0RJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 28) = "UkVDVElPTl9UT1AQAhIeChpFRkZFQ1RfRElSRUNUSU9OX1RPUF9SSUdIVBAE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 29) = "EhkKFUVGRkVDVF9ESVJFQ1RJT05fTEVGVBAIEhsKF0VGRkVDVF9ESVJFQ1RJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 30) = "T05fQ0VOVEVSEBASGgoWRUZGRUNUX0RJUkVDVElPTl9SSUdIVBAgEiAKHEVG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 31) = "RkVDVF9ESVJFQ1RJT05fQk9UVE9NX0xFRlQQQBIcChdFRkZFQ1RfRElSRUNU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 32) = "SU9OX0JPVFRPTRCAARIiCh1FRkZFQ1RfRElSRUNUSU9OX0JPVFRPTV9SSUdI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 33) = "VBCAAkIGCgRUeXBlGlUKBlByZXNldBIbCgR1dWlkGAEgASgLMg0ucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 34) = "YS5VVUlEEgwKBG5hbWUYAiABKAkSIAoHZWZmZWN0cxgDIAMoCzIPLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 35) = "dGEuRWZmZWN0IskBCgpUcmFuc2l0aW9uEhAKCGR1cmF0aW9uGAEgASgBEioK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 36) = "DWZhdm9yaXRlX3V1aWQYAiABKAsyDS5ydi5kYXRhLlVVSURCBKCGGQESHwoG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 37) = "ZWZmZWN0GAMgASgLMg8ucnYuZGF0YS5FZmZlY3QaXAoGUHJlc2V0EhsKBHV1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 38) = "aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSDAoEbmFtZRgCIAEoCRInCgp0cmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 39) = "c2l0aW9uGAMgASgLMhMucnYuZGF0YS5UcmFuc2l0aW9uQjT4AQGqAiRQcm8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 40) = "U2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray42<string>, string>(ref buffer, 41) = "cm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray42<string>, string>(in buffer, 42))), new FileDescriptor[3]
		{
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Effect), Effect.Parser, new string[7] { "Uuid", "Enabled", "Name", "RenderId", "BehaviorDescription", "Category", "Variables" }, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(Effect.Types.EffectVariable), Effect.Types.EffectVariable.Parser, new string[7] { "Name", "Description", "Int", "Float", "Color", "Direction", "Double" }, new string[1] { "Type" }, null, null, new GeneratedClrTypeInfo[5]
				{
					new GeneratedClrTypeInfo(typeof(Effect.Types.EffectVariable.Types.EffectInt), Effect.Types.EffectVariable.Types.EffectInt.Parser, new string[4] { "Value", "DefaultValue", "Min", "Max" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Effect.Types.EffectVariable.Types.EffectFloat), Effect.Types.EffectVariable.Types.EffectFloat.Parser, new string[4] { "Value", "DefaultValue", "Min", "Max" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Effect.Types.EffectVariable.Types.EffectDouble), Effect.Types.EffectVariable.Types.EffectDouble.Parser, new string[4] { "Value", "DefaultValue", "Min", "Max" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Effect.Types.EffectVariable.Types.EffectColor), Effect.Types.EffectVariable.Types.EffectColor.Parser, new string[2] { "Color", "DefaultColor" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Effect.Types.EffectVariable.Types.EffectDirection), Effect.Types.EffectVariable.Types.EffectDirection.Parser, new string[3] { "Direction", "DefaultDirection", "AvailableDirections" }, null, new Type[1] { typeof(Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection) }, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Effect.Types.Preset), Effect.Types.Preset.Parser, new string[3] { "Uuid", "Name", "Effects" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(Transition), Transition.Parser, new string[3] { "Duration", "FavoriteUuid", "Effect" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Transition.Types.Preset), Transition.Types.Preset.Parser, new string[3] { "Uuid", "Name", "Transition" }, null, null, null, null)
			})
		}));
	}
}
