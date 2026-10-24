using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class AudioReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AudioReflection()
	{
		_003C_003Ey__InlineArray27<string> buffer = default(_003C_003Ey__InlineArray27<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 0) = "CgthdWRpby5wcm90bxIHcnYuZGF0YRoKdXVpZC5wcm90byK2CAoFQXVkaW8a";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 1) = "jQEKEFNldHRpbmdzRG9jdW1lbnQSMAoMb3V0cHV0X3NldHVwGAEgASgLMhou";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 2) = "cnYuZGF0YS5BdWRpby5PdXRwdXRTZXR1cBItCg5tb25pdG9yX2RldmljZRgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 3) = "IAEoCzIVLnJ2LmRhdGEuQXVkaW8uRGV2aWNlEhgKEG1vbml0b3Jfb25fbWFp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 4) = "bnMYAyABKAga9QEKC091dHB1dFNldHVwEhsKBHV1aWQYASABKAsyDS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 5) = "YXRhLlVVSUQSKwoMYXVkaW9fZGV2aWNlGAIgASgLMhUucnYuZGF0YS5BdWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 6) = "by5EZXZpY2USNwoQbG9naWNhbF9jaGFubmVscxgDIAMoCzIdLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 7) = "QXVkaW8uTG9naWNhbENoYW5uZWwSEwoLYXVkaW9fZGVsYXkYBCABKAESFAoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 8) = "bWFzdGVyX2xldmVsGAUgASgBEjgKEHBoeXNpY2FsX2NoYW5lbHMYBiADKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 9) = "Hi5ydi5kYXRhLkF1ZGlvLlBoeXNpY2FsQ2hhbm5lbBqcAgoGRGV2aWNlEgwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 10) = "BG5hbWUYASABKAkSEAoIcmVuZGVySUQYAiABKAkSGwoTaW5wdXRfY2hhbm5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 11) = "bF9jb3VudBgDIAEoDRIcChRvdXRwdXRfY2hhbm5lbF9jb3VudBgEIAEoDRIt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 12) = "Cgdmb3JtYXRzGAUgAygLMhwucnYuZGF0YS5BdWRpby5EZXZpY2UuRm9ybWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 13) = "GocBCgZGb3JtYXQSEwoLc2FtcGxlX3JhdGUYASABKA0SEQoJYml0X2RlcHRo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 14) = "GAIgASgNEi8KBHR5cGUYAyABKA4yIS5ydi5kYXRhLkF1ZGlvLkRldmljZS5G";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 15) = "b3JtYXQuVHlwZSIkCgRUeXBlEgwKCFRZUEVfSU5UEAASDgoKVFlQRV9GTE9B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 16) = "VBABGqQCCg5Mb2dpY2FsQ2hhbm5lbBIbCgR1dWlkGAEgASgLMg0ucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 17) = "YS5VVUlEEgwKBG5hbWUYAiABKAkSDQoFaW5kZXgYAyABKA0SDQoFbXV0ZWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 18) = "BCABKAgSTAoXcGh5c2ljYWxfYXVkaW9fY2hhbm5lbHMYBSADKAsyKy5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 19) = "YXRhLkF1ZGlvLkxvZ2ljYWxDaGFubmVsLk91dHB1dENoYW5uZWwSDAoEc29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 20) = "bxgGIAEoCBIRCgl0ZXN0X3RvbmUYByABKAgaWgoNT3V0cHV0Q2hhbm5lbBIN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 21) = "CgVpbmRleBgBIAEoDRIRCgVtdXRlZBgCIAEoCEICGAESEAoEc29sbxgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 22) = "CEICGAESFQoJdGVzdF90b25lGAQgASgIQgIYARpfCg9QaHlzaWNhbENoYW5u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 23) = "ZWwSDQoFaW5kZXgYASABKA0SEwoLbXV0ZV9lbmFibGUYAiABKAgSEwoLc29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 24) = "b19lbmFibGUYAyABKAgSEwoLdG9uZV9lbmFibGUYBCABKAhCNPgBAaoCJFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 25) = "by5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 26) = "BnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray27<string>, string>(in buffer, 27))), new FileDescriptor[1] { UuidReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Audio), Audio.Parser, null, null, null, null, new GeneratedClrTypeInfo[5]
			{
				new GeneratedClrTypeInfo(typeof(Audio.Types.SettingsDocument), Audio.Types.SettingsDocument.Parser, new string[3] { "OutputSetup", "MonitorDevice", "MonitorOnMains" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Audio.Types.OutputSetup), Audio.Types.OutputSetup.Parser, new string[6] { "Uuid", "AudioDevice", "LogicalChannels", "AudioDelay", "MasterLevel", "PhysicalChanels" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Audio.Types.Device), Audio.Types.Device.Parser, new string[5] { "Name", "RenderID", "InputChannelCount", "OutputChannelCount", "Formats" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Audio.Types.Device.Types.Format), Audio.Types.Device.Types.Format.Parser, new string[3] { "SampleRate", "BitDepth", "Type" }, null, new Type[1] { typeof(Audio.Types.Device.Types.Format.Types.Type) }, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Audio.Types.LogicalChannel), Audio.Types.LogicalChannel.Parser, new string[7] { "Uuid", "Name", "Index", "Muted", "PhysicalAudioChannels", "Solo", "TestTone" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Audio.Types.LogicalChannel.Types.OutputChannel), Audio.Types.LogicalChannel.Types.OutputChannel.Parser, new string[4] { "Index", "Muted", "Solo", "TestTone" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Audio.Types.PhysicalChannel), Audio.Types.PhysicalChannel.Parser, new string[4] { "Index", "MuteEnable", "SoloEnable", "ToneEnable" }, null, null, null, null)
			})
		}));
	}
}
