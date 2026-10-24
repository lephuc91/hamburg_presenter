using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class LayersReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static LayersReflection()
	{
		_003C_003Ey__InlineArray43<string> buffer = default(_003C_003Ey__InlineArray43<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 0) = "CgxsYXllcnMucHJvdG8SB3J2LmRhdGEaC2NvbG9yLnByb3RvGhNjdXN0b21P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 1) = "cHRpb25zLnByb3RvGg1lZmZlY3RzLnByb3RvGgxob3RLZXkucHJvdG8aCnV1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 2) = "aWQucHJvdG8i1w0KBUxheWVyEhsKBHV1aWQYASABKAsyDS5ydi5kYXRhLlVV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 3) = "SUQSDAoEbmFtZRgCIAEoCRIdCgVjb2xvchgDIAEoCzIOLnJ2LmRhdGEuQ29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 4) = "b3ISDQoFbXV0ZWQYBCABKAgSDgoGaGlkZGVuGAUgASgIEjAKCmJsZW5kX21v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 5) = "ZGUYBiABKA4yGC5ydi5kYXRhLkxheWVyLkJsZW5kTW9kZUICGAESEwoHb3Bh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 6) = "Y2l0eRgHIAEoAUICGAESLwoYc2VsZWN0ZWRfdGFyZ2V0X3NldF91dWlkGAgg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 7) = "ASgLMg0ucnYuZGF0YS5VVUlEEioKE2VmZmVjdHNfcHJlc2V0X3V1aWQYCSAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 8) = "KAsyDS5ydi5kYXRhLlVVSUQSHgoWZWZmZWN0c19idWlsZF9kdXJhdGlvbhgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 9) = "IAEoARIoChFsYXllcl9wcmVzZXRfdXVpZBgLIAEoCzINLnJ2LmRhdGEuVVVJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 10) = "RBIgCgdob3Rfa2V5GAwgASgLMg8ucnYuZGF0YS5Ib3RLZXkSJwoKdHJhbnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 11) = "dGlvbhgNIAEoCzITLnJ2LmRhdGEuVHJhbnNpdGlvbhIgCgdlZmZlY3RzGA4g";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 12) = "AygLMg8ucnYuZGF0YS5FZmZlY3QSLAoFYmxlbmQYDyABKAsyFy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 13) = "LkxheWVyLkJsZW5kaW5nQgSohhkBGlIKBlByZXNldBIbCgR1dWlkGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 14) = "Mg0ucnYuZGF0YS5VVUlEEgwKBG5hbWUYAiABKAkSHQoFbGF5ZXIYAyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 15) = "Di5ydi5kYXRhLkxheWVyGsADCghCbGVuZGluZxI0CghzdGFuZGFyZBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 16) = "CzIgLnJ2LmRhdGEuTGF5ZXIuQmxlbmRpbmcuU3RhbmRhcmRIABIuCgVtYXR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 17) = "ZRgCIAEoCzIdLnJ2LmRhdGEuTGF5ZXIuQmxlbmRpbmcuTWF0dGVIABpDCghT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 18) = "dGFuZGFyZBImCgRtb2RlGAEgASgOMhgucnYuZGF0YS5MYXllci5CbGVuZE1v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 19) = "ZGUSDwoHb3BhY2l0eRgCIAEoARr4AQoFTWF0dGUSNAoFYWxwaGEYASABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 20) = "Iy5ydi5kYXRhLkxheWVyLkJsZW5kaW5nLk1hdHRlLkFscGhhSAASMgoEbHVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 21) = "YRgCIAEoCzIiLnJ2LmRhdGEuTGF5ZXIuQmxlbmRpbmcuTWF0dGUuTHVtYUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 22) = "EjQKBXdoaXRlGAQgASgLMiMucnYuZGF0YS5MYXllci5CbGVuZGluZy5NYXR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 23) = "ZS5XaGl0ZUgAGhkKBUFscGhhEhAKCGludmVydGVkGAEgASgIGhgKBEx1bWES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 24) = "EAoIaW52ZXJ0ZWQYASABKAgaBwoFV2hpdGVCCwoJTWF0dGVUeXBlSgQIAxAE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 25) = "Qg4KDEJsZW5kaW5nVHlwZSLEBQoJQmxlbmRNb2RlEhUKEUJMRU5EX01PREVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 26) = "Tk9STUFMEAASFwoTQkxFTkRfTU9ERV9ESVNTT0xWRRABEhUKEUJMRU5EX01P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 27) = "REVfREFSS0VOEAISFwoTQkxFTkRfTU9ERV9NVUxUSVBMWRADEhkKFUJMRU5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 28) = "X01PREVfQ09MT1JfQlVSThAEEhoKFkJMRU5EX01PREVfTElORUFSX0JVUk4Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 29) = "BRIbChdCTEVORF9NT0RFX0RBUktFUl9DT0xPUhAGEhYKEkJMRU5EX01PREVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 30) = "TElHSFRFThAHEhUKEUJMRU5EX01PREVfU0NSRUVOEAgSGgoWQkxFTkRfTU9E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 31) = "RV9DT0xPUl9ET0RHRRAJEhsKF0JMRU5EX01PREVfTElORUFSX0RPREdFEAoS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 32) = "HAoYQkxFTkRfTU9ERV9MSUdIVEVSX0NPTE9SEAsSFgoSQkxFTkRfTU9ERV9P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 33) = "VkVSTEFZEAwSGQoVQkxFTkRfTU9ERV9TT0ZUX0xJR0hUEA0SGQoVQkxFTkRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 34) = "TU9ERV9IQVJEX0xJR0hUEA4SGgoWQkxFTkRfTU9ERV9WSVZJRF9MSUdIVBAP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 35) = "EhsKF0JMRU5EX01PREVfTElORUFSX0xJR0hUEBASGAoUQkxFTkRfTU9ERV9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 36) = "SU5fTElHSFQQERIXChNCTEVORF9NT0RFX0hBUkRfTUlYEBISGQoVQkxFTkRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 37) = "TU9ERV9ESUZGRVJFTkNFEBMSGAoUQkxFTkRfTU9ERV9FWENMVVNJT04QFBIX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 38) = "ChNCTEVORF9NT0RFX1NVQlRSQUNUEBUSFQoRQkxFTkRfTU9ERV9ESVZJREUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 39) = "FhISCg5CTEVORF9NT0RFX0hVRRAXEhkKFUJMRU5EX01PREVfU0FUVVJBVElP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 40) = "ThAYEhQKEEJMRU5EX01PREVfQ09MT1IQGRIZChVCTEVORF9NT0RFX0xVTUlO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 41) = "T1NJVFkQGkI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray43<string>, string>(ref buffer, 42) = "dG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray43<string>, string>(in buffer, 43))), new FileDescriptor[5]
		{
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			EffectsReflection.Descriptor,
			HotKeyReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Layer), Layer.Parser, new string[15]
			{
				"Uuid", "Name", "Color", "Muted", "Hidden", "BlendMode", "Opacity", "SelectedTargetSetUuid", "EffectsPresetUuid", "EffectsBuildDuration",
				"LayerPresetUuid", "HotKey", "Transition", "Effects", "Blend"
			}, null, new Type[1] { typeof(Layer.Types.BlendMode) }, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(Layer.Types.Preset), Layer.Types.Preset.Parser, new string[3] { "Uuid", "Name", "Layer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Layer.Types.Blending), Layer.Types.Blending.Parser, new string[2] { "Standard", "Matte" }, new string[1] { "BlendingType" }, null, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(Layer.Types.Blending.Types.Standard), Layer.Types.Blending.Types.Standard.Parser, new string[2] { "Mode", "Opacity" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Layer.Types.Blending.Types.Matte), Layer.Types.Blending.Types.Matte.Parser, new string[3] { "Alpha", "Luma", "White" }, new string[1] { "MatteType" }, null, null, new GeneratedClrTypeInfo[3]
					{
						new GeneratedClrTypeInfo(typeof(Layer.Types.Blending.Types.Matte.Types.Alpha), Layer.Types.Blending.Types.Matte.Types.Alpha.Parser, new string[1] { "Inverted" }, null, null, null, null),
						new GeneratedClrTypeInfo(typeof(Layer.Types.Blending.Types.Matte.Types.Luma), Layer.Types.Blending.Types.Matte.Types.Luma.Parser, new string[1] { "Inverted" }, null, null, null, null),
						new GeneratedClrTypeInfo(typeof(Layer.Types.Blending.Types.Matte.Types.White), Layer.Types.Blending.Types.Matte.Types.White.Parser, null, null, null, null, null)
					})
				})
			})
		}));
	}
}
