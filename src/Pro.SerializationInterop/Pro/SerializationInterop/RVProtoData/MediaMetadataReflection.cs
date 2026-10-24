using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class MediaMetadataReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static MediaMetadataReflection()
	{
		_003C_003Ey__InlineArray29<string> buffer = default(_003C_003Ey__InlineArray29<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 0) = "ChNtZWRpYU1ldGFkYXRhLnByb3RvEgdydi5kYXRhGg1lZmZlY3RzLnByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 1) = "GhJncmFwaGljc0RhdGEucHJvdG8aD2FscGhhVHlwZS5wcm90byL8AwoYTWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 2) = "aWFNZXRhZGF0YVJlcXVlc3RJbmZvEhEKCWZpbGVfcGF0aBgBIAEoCRIMCgR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 3) = "aW1lGAIgASgCEg0KBXdpZHRoGAMgASgNEg4KBmhlaWdodBgEIAEoDRIgCgdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 4) = "ZmZlY3RzGAUgAygLMg8ucnYuZGF0YS5FZmZlY3QSMQoLY3JvcF9pbnNldHMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 5) = "BiABKAsyHC5ydi5kYXRhLkdyYXBoaWNzLkVkZ2VJbnNldHMSTAoPbmF0aXZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 6) = "X3JvdGF0aW9uGAcgASgOMjMucnYuZGF0YS5NZWRpYS5EcmF3aW5nUHJvcGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 7) = "dGllcy5OYXRpdmVSb3RhdGlvblR5cGUSHAoUZmxpcHBlZF9ob3Jpem9udGFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 8) = "bHkYCCABKAgSGgoSZmxpcHBlZF92ZXJ0aWNhbGx5GAkgASgIEiYKCmFscGhh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 9) = "X3R5cGUYCiABKA4yEi5ydi5kYXRhLkFscGhhVHlwZRJFCg1idWZmZXJfZm9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 10) = "bWF0GAsgASgOMi4ucnYuZGF0YS5NZWRpYU1ldGFkYXRhUmVxdWVzdEluZm8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 11) = "QnVmZmVyRm9ybWF0IlQKDEJ1ZmZlckZvcm1hdBIVChFCVUZGRVJfRk9STUFU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 12) = "X1JBVxAAEhUKEUJVRkZFUl9GT1JNQVRfUE5HEAESFgoSQlVGRkVSX0ZPUk1B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 13) = "VF9OT05FEAIi9AQKHE1lZGlhTWV0YWRhdGFSZXF1ZXN0UmVzcG9uc2USQAoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 14) = "bWV0YWRhdGEYASABKAsyLi5ydi5kYXRhLk1lZGlhTWV0YWRhdGFSZXF1ZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 15) = "UmVzcG9uc2UuTWV0YWRhdGESTwoVZ2VuZXJhdGVkX2JpdG1hcF9pbmZvGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 16) = "ASgLMjAucnYuZGF0YS5NZWRpYU1ldGFkYXRhUmVxdWVzdFJlc3BvbnNlLkJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 17) = "dG1hcEluZm8ahQMKCE1ldGFkYXRhEg0KBXdpZHRoGAEgASgNEg4KBmhlaWdo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 18) = "dBgCIAEoDRILCgNmcHMYAyABKAISEAoIZHVyYXRpb24YBCABKAISHQoVbnVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 19) = "YmVyX2F1ZGlvX2NoYW5uZWxzGAUgASgNEg0KBWNvZGVjGAYgASgJEg4KBmFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 20) = "dGlzdBgHIAEoCRINCgV0aXRsZRgIIAEoCRIQCghyb3RhdGlvbhgJIAEoAhJQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 21) = "Cgxjb250ZW50X3R5cGUYCiABKA4yOi5ydi5kYXRhLk1lZGlhTWV0YWRhdGFS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 22) = "ZXF1ZXN0UmVzcG9uc2UuTWV0YWRhdGEuQ29udGVudFR5cGUSGQoRaGFzX2Fs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 23) = "cGhhX2NoYW5uZWwYCyABKAgibwoLQ29udGVudFR5cGUSGAoUQ09OVEVOVF9U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 24) = "WVBFX1VOS05PV04QABIWChJDT05URU5UX1RZUEVfQVVESU8QARIWChJDT05U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 25) = "RU5UX1RZUEVfSU1BR0UQAhIWChJDT05URU5UX1RZUEVfVklERU8QAxo5CgpC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 26) = "aXRtYXBJbmZvEg0KBXdpZHRoGAEgASgNEg4KBmhlaWdodBgCIAEoDRIMCgRz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 27) = "aXplGAMgASgEQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 28) = "cm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray29<string>, string>(in buffer, 29))), new FileDescriptor[3]
		{
			EffectsReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			AlphaTypeReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(MediaMetadataRequestInfo), MediaMetadataRequestInfo.Parser, new string[11]
			{
				"FilePath", "Time", "Width", "Height", "Effects", "CropInsets", "NativeRotation", "FlippedHorizontally", "FlippedVertically", "AlphaType",
				"BufferFormat"
			}, null, new Type[1] { typeof(MediaMetadataRequestInfo.Types.BufferFormat) }, null, null),
			new GeneratedClrTypeInfo(typeof(MediaMetadataRequestResponse), MediaMetadataRequestResponse.Parser, new string[2] { "Metadata", "GeneratedBitmapInfo" }, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(MediaMetadataRequestResponse.Types.Metadata), MediaMetadataRequestResponse.Types.Metadata.Parser, new string[11]
				{
					"Width", "Height", "Fps", "Duration", "NumberAudioChannels", "Codec", "Artist", "Title", "Rotation", "ContentType",
					"HasAlphaChannel"
				}, null, new Type[1] { typeof(MediaMetadataRequestResponse.Types.Metadata.Types.ContentType) }, null, null),
				new GeneratedClrTypeInfo(typeof(MediaMetadataRequestResponse.Types.BitmapInfo), MediaMetadataRequestResponse.Types.BitmapInfo.Parser, new string[3] { "Width", "Height", "Size" }, null, null, null, null)
			})
		}));
	}
}
