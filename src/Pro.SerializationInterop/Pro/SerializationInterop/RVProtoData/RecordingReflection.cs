using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class RecordingReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static RecordingReflection()
	{
		_003C_003Ey__InlineArray48<string> buffer = default(_003C_003Ey__InlineArray48<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 0) = "Cg9yZWNvcmRpbmcucHJvdG8SB3J2LmRhdGEaE2N1c3RvbU9wdGlvbnMucHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 1) = "dG8aEmRpZ2l0YWxBdWRpby5wcm90bxoJdXJsLnByb3RvGgp1dWlkLnByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 2) = "IsMPCglSZWNvcmRpbmcaqAEKEFNldHRpbmdzRG9jdW1lbnQSMAoHc3RyZWFt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 3) = "cxgBIAMoCzIZLnJ2LmRhdGEuUmVjb3JkaW5nLlN0cmVhbUIEqIYZARIqCgdw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 4) = "cmVzZXRzGAIgAygLMhkucnYuZGF0YS5SZWNvcmRpbmcuUHJlc2V0EjYKDWFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 5) = "dGl2ZV9wcmVzZXQYAyABKAsyGS5ydi5kYXRhLlJlY29yZGluZy5QcmVzZXRC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 6) = "BKCGGQEaXQoGUHJlc2V0EhkKAmlkGAEgASgLMg0ucnYuZGF0YS5VVUlEEgwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 7) = "BG5hbWUYAiABKAkSKgoHc3RyZWFtcxgDIAMoCzIZLnJ2LmRhdGEuUmVjb3Jk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 8) = "aW5nLlN0cmVhbRqrDQoGU3RyZWFtEhkKAmlkGAEgASgLMg0ucnYuZGF0YS5V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 9) = "VUlEEkUKDW91dHB1dF9zY3JlZW4YAiABKAsyLC5ydi5kYXRhLlJlY29yZGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 10) = "Zy5TdHJlYW0uT3V0cHV0U2NyZWVuU291cmNlSAASMgoHZW5jb2RlchgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 11) = "CzIhLnJ2LmRhdGEuUmVjb3JkaW5nLlN0cmVhbS5FbmNvZGVyEjsKDGRlc3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 12) = "bmF0aW9ucxgEIAMoCzIlLnJ2LmRhdGEuUmVjb3JkaW5nLlN0cmVhbS5EZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 13) = "aW5hdGlvbhIzCglhdWRpb19tYXAYBSADKAsyIC5ydi5kYXRhLkRpZ2l0YWxB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 14) = "dWRpby5EZXZpY2UuTWFwEhsKE2lzQXVkaW9DdXN0b21NYXBwZWQYBiABKAga";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 15) = "4QEKB0VuY29kZXISLgoFY29kZWMYASABKA4yHy5ydi5kYXRhLlJlY29yZGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 16) = "Zy5TdHJlYW0uQ29kZWMSEwoLdmlkZW9fd2lkdGgYAiABKA0SFAoMdmlkZW9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 17) = "aGVpZ2h0GAMgASgNEhUKDWlzX2ludGVybGFjZWQYBCABKAgSNgoJZnJhbWVS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 18) = "YXRlGAUgASgOMiMucnYuZGF0YS5SZWNvcmRpbmcuU3RyZWFtLkZyYW1lUmF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 19) = "ZRIVCg12aWRlb19iaXRyYXRlGAYgASgNEhUKDWF1ZGlvX2JpdHJhdGUYByAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 20) = "KA0aVwoST3V0cHV0U2NyZWVuU291cmNlEiYKCXNjcmVlbl9pZBgBIAEoCzIN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 21) = "LnJ2LmRhdGEuVVVJREIEoIYZARIZCgtzY3JlZW5fbmFtZRgCIAEoCUIEoIYZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 22) = "ARppCg9EaXNrRGVzdGluYXRpb24SHgoIbG9jYXRpb24YASABKAsyDC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 23) = "YXRhLlVSTBI2Cgljb250YWluZXIYAiABKA4yIy5ydi5kYXRhLlJlY29yZGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 24) = "Zy5TdHJlYW0uQ29udGFpbmVyGi8KD1JUTVBEZXN0aW5hdGlvbhIPCgdhZGRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 25) = "ZXNzGAEgASgJEgsKA2tleRgCIAEoCRq6AgoLRGVzdGluYXRpb24SOQoEZGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 26) = "axgBIAEoCzIpLnJ2LmRhdGEuUmVjb3JkaW5nLlN0cmVhbS5EaXNrRGVzdGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 27) = "YXRpb25IABI5CgRydG1wGAIgASgLMikucnYuZGF0YS5SZWNvcmRpbmcuU3Ry";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 28) = "ZWFtLlJUTVBEZXN0aW5hdGlvbkgAEjoKBHJlc2kYAyABKAsyKi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 29) = "LlJlY29yZGluZy5TdHJlYW0uRGVzdGluYXRpb24uUmVzaUgAGmoKBFJlc2kS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 30) = "MQoUZGVzdGluYXRpb25fZ3JvdXBfaWQYASABKAsyDS5ydi5kYXRhLlVVSURC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 31) = "BKCGGQESLwoSZW5jb2Rlcl9wcm9maWxlX2lkGAIgASgLMg0ucnYuZGF0YS5V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 32) = "VUlEQgSghhkBQg0KC0Rlc3RpbmF0aW9uIkgKCUNvbnRhaW5lchIVChFDT05U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 33) = "QUlORVJfVU5LTk9XThAAEhEKDUNPTlRBSU5FUl9NT1YQARIRCg1DT05UQUlO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 34) = "RVJfTVA0EAIi4AIKBUNvZGVjEhMKD0NPREVDX0FVVE9NQVRJQxAAEg4KCkNP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 35) = "REVDX0gyNjQQARIOCgpDT0RFQ19IMjY1EAISGgoWQ09ERUNfUFJPUkVTXzQy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 36) = "Ml9QUk9YWRADEhcKE0NPREVDX1BST1JFU180MjJfTFQQBBIUChBDT0RFQ19Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 37) = "Uk9SRVNfNDIyEAUSFwoTQ09ERUNfUFJPUkVTXzQyMl9IURAGEhUKEUNPREVD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 38) = "X1BST1JFU180NDQ0EAcSGAoUQ09ERUNfUFJPUkVTXzQ0NDRfWFEQCBINCglD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 39) = "T0RFQ19IQVAQCRITCg9DT0RFQ19IQVBfQUxQSEEQChIPCgtDT0RFQ19IQVBf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 40) = "URALEhUKEUNPREVDX0hBUF9RX0FMUEhBEAwSDwoLQ09ERUNfTk9UQ0gQDRIX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 41) = "ChNDT0RFQ19IMjY0X1NPRlRXQVJFEA4SFwoTQ09ERUNfSDI2NV9TT0ZUV0FS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 42) = "RRAPIq4BCglGcmFtZVJhdGUSFgoSRlJBTUVfUkFURV9VTktOT1dOEAASEQoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 43) = "RlJBTUVfUkFURV8yNBABEhEKDUZSQU1FX1JBVEVfMjUQAhIUChBGUkFNRV9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 44) = "QVRFXzI5Xzk3EAMSEQoNRlJBTUVfUkFURV8zMBAEEhEKDUZSQU1FX1JBVEVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 45) = "NTAQBRIUChBGUkFNRV9SQVRFXzU5Xzk0EAYSEQoNRlJBTUVfUkFURV82MBAH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 46) = "QggKBlNvdXJjZUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray48<string>, string>(ref buffer, 47) = "UHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray48<string>, string>(in buffer, 48))), new FileDescriptor[4]
		{
			CustomOptionsReflection.Descriptor,
			DigitalAudioReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Recording), Recording.Parser, null, null, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(Recording.Types.SettingsDocument), Recording.Types.SettingsDocument.Parser, new string[3] { "Streams", "Presets", "ActivePreset" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Recording.Types.Preset), Recording.Types.Preset.Parser, new string[3] { "Id", "Name", "Streams" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Recording.Types.Stream), Recording.Types.Stream.Parser, new string[6] { "Id", "OutputScreen", "Encoder", "Destinations", "AudioMap", "IsAudioCustomMapped" }, new string[1] { "Source" }, new Type[3]
				{
					typeof(Recording.Types.Stream.Types.Container),
					typeof(Recording.Types.Stream.Types.Codec),
					typeof(Recording.Types.Stream.Types.FrameRate)
				}, null, new GeneratedClrTypeInfo[5]
				{
					new GeneratedClrTypeInfo(typeof(Recording.Types.Stream.Types.Encoder), Recording.Types.Stream.Types.Encoder.Parser, new string[7] { "Codec", "VideoWidth", "VideoHeight", "IsInterlaced", "FrameRate", "VideoBitrate", "AudioBitrate" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Recording.Types.Stream.Types.OutputScreenSource), Recording.Types.Stream.Types.OutputScreenSource.Parser, new string[2] { "ScreenId", "ScreenName" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Recording.Types.Stream.Types.DiskDestination), Recording.Types.Stream.Types.DiskDestination.Parser, new string[2] { "Location", "Container" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Recording.Types.Stream.Types.RTMPDestination), Recording.Types.Stream.Types.RTMPDestination.Parser, new string[2] { "Address", "Key" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Recording.Types.Stream.Types.Destination), Recording.Types.Stream.Types.Destination.Parser, new string[3] { "Disk", "Rtmp", "Resi" }, new string[1] { "Destination" }, null, null, new GeneratedClrTypeInfo[1]
					{
						new GeneratedClrTypeInfo(typeof(Recording.Types.Stream.Types.Destination.Types.Resi), Recording.Types.Stream.Types.Destination.Types.Resi.Parser, new string[2] { "DestinationGroupId", "EncoderProfileId" }, null, null, null, null)
					})
				})
			})
		}));
	}
}
