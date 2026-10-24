using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class InputReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static InputReflection()
	{
		_003C_003Ey__InlineArray35<string> buffer = default(_003C_003Ey__InlineArray35<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 0) = "CgtpbnB1dC5wcm90bxIHcnYuZGF0YRoPYWxwaGFUeXBlLnByb3RvGgtjb2xv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 1) = "ci5wcm90bxoTY3VzdG9tT3B0aW9ucy5wcm90bxoSZGlnaXRhbEF1ZGlvLnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 2) = "b3RvGhJncmFwaGljc0RhdGEucHJvdG8aCXVybC5wcm90bxoKdXVpZC5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 3) = "byLfBAoKVmlkZW9JbnB1dBIbCgR1dWlkGAEgASgLMg0ucnYuZGF0YS5VVUlE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 4) = "Eh4KEHVzZXJfZGVzY3JpcHRpb24YAiABKAlCBKCGGQESPAoSdmlkZW9faW5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 5) = "dXRfZGV2aWNlGAMgASgLMhoucnYuZGF0YS5NZWRpYS5WaWRlb0RldmljZUIE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 6) = "oIYZARIlCg1kaXNwbGF5X2NvbG9yGAQgASgLMg4ucnYuZGF0YS5Db2xvchIq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 7) = "Cg50aHVtYm5haWxfcGF0aBgFIAEoCzIMLnJ2LmRhdGEuVVJMQgSohhkBEjQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 8) = "DGF1ZGlvX2RldmljZRgGIAEoCzIcLnJ2LmRhdGEuRGlnaXRhbEF1ZGlvLkRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 9) = "dmljZUgAEjIKDHZpZGVvX2RldmljZRgHIAEoCzIaLnJ2LmRhdGEuTWVkaWEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 10) = "VmlkZW9EZXZpY2VIABI3CgphdWRpb190eXBlGAggASgOMiMucnYuZGF0YS5W";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 11) = "aWRlb0lucHV0LkF1ZGlvRGV2aWNlVHlwZRImCgphbHBoYV90eXBlGAkgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 12) = "MhIucnYuZGF0YS5BbHBoYVR5cGUaNwoQU2V0dGluZ3NEb2N1bWVudBIjCgZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 13) = "bnB1dHMYASADKAsyEy5ydi5kYXRhLlZpZGVvSW5wdXQibQoPQXVkaW9EZXZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 14) = "Y2VUeXBlEh0KGUFVRElPX0RFVklDRV9UWVBFX0RFRkFVTFQQABIaChZBVURJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 15) = "T19ERVZJQ0VfVFlQRV9OT05FEAESHwobQVVESU9fREVWSUNFX1RZUEVfQUxU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 16) = "RVJOQVRFEAJCEAoOQWx0QXVkaW9Tb3VyY2UiqgQKCkF1ZGlvSW5wdXQSGwoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 17) = "dXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBIYChB1c2VyX2Rlc2NyaXB0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 18) = "GAIgASgJEjQKDGF1ZGlvX2RldmljZRgDIAEoCzIcLnJ2LmRhdGEuRGlnaXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 19) = "bEF1ZGlvLkRldmljZUgAEjIKDHZpZGVvX2RldmljZRgEIAEoCzIaLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 20) = "dGEuTWVkaWEuVmlkZW9EZXZpY2VIABI3Cg1iZWhhdmlvcl9tb2RlGAUgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 21) = "MiAucnYuZGF0YS5BdWRpb0lucHV0LkJlaGF2aW9yTW9kZRq3AgoMQmVoYXZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 22) = "b3JNb2RlEjEKAm9uGAEgASgLMiMucnYuZGF0YS5BdWRpb0lucHV0LkJlaGF2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 23) = "aW9yTW9kZS5PbkgAEjMKA29mZhgCIAEoCzIkLnJ2LmRhdGEuQXVkaW9JbnB1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 24) = "dC5CZWhhdmlvck1vZGUuT2ZmSAASOgoHYXV0b19vbhgDIAEoCzInLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 25) = "dGEuQXVkaW9JbnB1dC5CZWhhdmlvck1vZGUuQXV0b09uSAASPAoIYXV0b19v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 26) = "ZmYYBCABKAsyKC5ydi5kYXRhLkF1ZGlvSW5wdXQuQmVoYXZpb3JNb2RlLkF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 27) = "dG9PZmZIABoECgJPbhoFCgNPZmYaCQoHQXV0b09mZholCgZBdXRvT24SGwoT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 28) = "bGlua2VkX3ZpZGVvX2lucHV0cxgBIAMoDUIGCgRNb2RlQggKBlNvdXJjZSJ6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 29) = "Cg9DbG91ZFZpZGVvSW5wdXQSGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 30) = "RBIeChB1c2VyX2Rlc2NyaXB0aW9uGAIgASgJQgSghhkBEioKDnRodW1ibmFp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 31) = "bF9wYXRoGAMgASgLMgwucnYuZGF0YS5VUkxCBKCGGQEiSAoPQ2xvdWRBdWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 32) = "b0lucHV0EhsKBHV1aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSGAoQdXNlcl9k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 33) = "ZXNjcmlwdGlvbhgCIAEoCUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray35<string>, string>(ref buffer, 34) = "cm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray35<string>, string>(in buffer, 35))), new FileDescriptor[7]
		{
			AlphaTypeReflection.Descriptor,
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			DigitalAudioReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(VideoInput), VideoInput.Parser, new string[9] { "Uuid", "UserDescription", "VideoInputDevice", "DisplayColor", "ThumbnailPath", "AudioDevice", "VideoDevice", "AudioType", "AlphaType" }, new string[1] { "AltAudioSource" }, new Type[1] { typeof(VideoInput.Types.AudioDeviceType) }, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(VideoInput.Types.SettingsDocument), VideoInput.Types.SettingsDocument.Parser, new string[1] { "Inputs" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(AudioInput), AudioInput.Parser, new string[5] { "Uuid", "UserDescription", "AudioDevice", "VideoDevice", "BehaviorMode" }, new string[1] { "Source" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(AudioInput.Types.BehaviorMode), AudioInput.Types.BehaviorMode.Parser, new string[4] { "On", "Off", "AutoOn", "AutoOff" }, new string[1] { "Mode" }, null, null, new GeneratedClrTypeInfo[4]
				{
					new GeneratedClrTypeInfo(typeof(AudioInput.Types.BehaviorMode.Types.On), AudioInput.Types.BehaviorMode.Types.On.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(AudioInput.Types.BehaviorMode.Types.Off), AudioInput.Types.BehaviorMode.Types.Off.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(AudioInput.Types.BehaviorMode.Types.AutoOff), AudioInput.Types.BehaviorMode.Types.AutoOff.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(AudioInput.Types.BehaviorMode.Types.AutoOn), AudioInput.Types.BehaviorMode.Types.AutoOn.Parser, new string[1] { "LinkedVideoInputs" }, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(CloudVideoInput), CloudVideoInput.Parser, new string[3] { "Uuid", "UserDescription", "ThumbnailPath" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CloudAudioInput), CloudAudioInput.Parser, new string[2] { "Uuid", "UserDescription" }, null, null, null, null)
		}));
	}
}
