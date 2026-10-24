using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaGenerator;

public static class HelperSnapshotReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static HelperSnapshotReflection()
	{
		_003C_003Ey__InlineArray31<string> buffer = default(_003C_003Ey__InlineArray31<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 0) = "ChVoZWxwZXItc25hcHNob3QucHJvdG8SD2hlbHBlci5zbmFwc2hvdBoNZWZm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 1) = "ZWN0cy5wcm90bxoPYWxwaGFUeXBlLnByb3RvImEKB1JlcXVlc3QSDQoFaW5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 2) = "dXQYASABKAkSDgoGb3V0cHV0GAIgASgJEjcKDnRyYW5zZm9ybWF0aW9uGAMg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 3) = "ASgLMh8uaGVscGVyLnNuYXBzaG90LlRyYW5zZm9ybWF0aW9uIuoBChBSZXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 4) = "b25zZUVudmVsb3BlEj4KCHJlc3BvbnNlGAEgASgLMiouaGVscGVyLnNuYXBz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 5) = "aG90LlJlc3BvbnNlRW52ZWxvcGUuUmVzcG9uc2VIABI4CgVlcnJvchgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 6) = "CzInLmhlbHBlci5zbmFwc2hvdC5SZXNwb25zZUVudmVsb3BlLkVycm9ySAAa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 7) = "OAoIUmVzcG9uc2USLAoIbWV0YWRhdGEYASABKAsyGi5oZWxwZXIuc25hcHNo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 8) = "b3QuTWVkaWFJbmZvGhgKBUVycm9yEg8KB21lc3NhZ2UYASABKAlCCAoGcmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 9) = "dWx0IpcECglNZWRpYUluZm8SCwoDdXJsGAEgASgJEg0KBXdpZHRoGAIgASgN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 10) = "Eg4KBmhlaWdodBgDIAEoDRILCgNmcHMYBCABKAISEAoIZHVyYXRpb24YBSAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 11) = "KAISGgoSbnVtX2F1ZGlvX2NoYW5uZWxzGAYgASgNEg0KBWNvZGVjGAcgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 12) = "Eg4KBmFydGlzdBgIIAEoCRINCgV0aXRsZRgJIAEoCRIQCghyb3RhdGlvbhgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 13) = "IAEoBRI8Cgxjb250ZW50X3R5cGUYCyABKA4yJi5oZWxwZXIuc25hcHNob3Qu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 14) = "TWVkaWFJbmZvLkNvbnRlbnRUeXBlEhkKEWhhc19hbHBoYV9jaGFubmVsGAwg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 15) = "ASgIEhoKEnN1cHBvcnRzX2h3X2RlY29kZRgNIAEoCBI8Cgxjb2xvcl9mb3Jt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 16) = "YXQYDiABKA4yJi5oZWxwZXIuc25hcHNob3QuTWVkaWFJbmZvLkNvbG9yRm9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 17) = "bWF0Im8KC0NvbnRlbnRUeXBlEhgKFENPTlRFTlRfVFlQRV9VTktOT1dOEAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 18) = "FgoSQ09OVEVOVF9UWVBFX0FVRElPEAESFgoSQ09OVEVOVF9UWVBFX0lNQUdF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 19) = "EAISFgoSQ09OVEVOVF9UWVBFX1ZJREVPEAMiPwoLQ29sb3JGb3JtYXQSBwoD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 20) = "U0RSEAASEwoPSERSX1JFQzIxMDBfSExHEAESEgoOSERSX1JFQzIxMDBfUFEQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 21) = "AiLMAgoOVHJhbnNmb3JtYXRpb24SIAoHZWZmZWN0cxgBIAMoCzIPLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 22) = "dGEuRWZmZWN0EhAKCHBvc2l0aW9uGAIgASgCEhAKCHJvdGF0aW9uGAMgASgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 23) = "Eg0KBXdpZHRoGAQgASgNEg4KBmhlaWdodBgFIAEoDRISCgppbnNldHNfdG9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 24) = "GAYgASgCEhMKC2luc2V0c19sZWZ0GAcgASgCEhQKDGluc2V0c19yaWdodBgI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 25) = "IAEoAhIVCg1pbnNldHNfYm90dG9tGAkgASgCEhkKEWZsaXBfaG9yaXpvbnRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 26) = "bGx5GAogASgIEhcKD2ZsaXBfdmVydGljYWxseRgLIAEoCBImCgphbHBoYV90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 27) = "eXBlGAwgASgOMhIucnYuZGF0YS5BbHBoYVR5cGUSIwobdXNlX2RlZmF1bHRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 28) = "bmF0aXZlX3JvdGF0aW9uGA0gASgIQk+qAjNQcm8uU2VyaWFsaXphdGlvbklu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 29) = "dGVyb3AuUlZQcm90b0RhdGEuTWVkaWFHZW5lcmF0b3K6AhZSVkRhdGFfTWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray31<string>, string>(ref buffer, 30) = "aWFHZW5lcmF0b3JfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray31<string>, string>(in buffer, 31))), new FileDescriptor[2]
		{
			EffectsReflection.Descriptor,
			AlphaTypeReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(Request), Request.Parser, new string[3] { "Input", "Output", "Transformation" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ResponseEnvelope), ResponseEnvelope.Parser, new string[2] { "Response", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response), ResponseEnvelope.Types.Response.Parser, new string[1] { "Metadata" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Error), ResponseEnvelope.Types.Error.Parser, new string[1] { "Message" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(MediaInfo), MediaInfo.Parser, new string[14]
			{
				"Url", "Width", "Height", "Fps", "Duration", "NumAudioChannels", "Codec", "Artist", "Title", "Rotation",
				"ContentType", "HasAlphaChannel", "SupportsHwDecode", "ColorFormat"
			}, null, new Type[2]
			{
				typeof(MediaInfo.Types.ContentType),
				typeof(MediaInfo.Types.ColorFormat)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(Transformation), Transformation.Parser, new string[13]
			{
				"Effects", "Position", "Rotation", "Width", "Height", "InsetsTop", "InsetsLeft", "InsetsRight", "InsetsBottom", "FlipHorizontally",
				"FlipVertically", "AlphaType", "UseDefaultNativeRotation"
			}, null, null, null, null)
		}));
	}
}
