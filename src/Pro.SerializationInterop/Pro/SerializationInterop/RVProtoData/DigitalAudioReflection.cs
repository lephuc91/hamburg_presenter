using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class DigitalAudioReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static DigitalAudioReflection()
	{
		_003C_003Ey__InlineArray28<string> buffer = default(_003C_003Ey__InlineArray28<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 0) = "ChJkaWdpdGFsQXVkaW8ucHJvdG8SB3J2LmRhdGEaE2N1c3RvbU9wdGlvbnMu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 1) = "cHJvdG8izQgKDERpZ2l0YWxBdWRpbxrGAgoFU2V0dXASKAoFYnVzZXMYASAD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 2) = "KAsyGS5ydi5kYXRhLkRpZ2l0YWxBdWRpby5CdXMSOgoObW9uaXRvcl9kZXZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 3) = "Y2UYAiABKAsyHC5ydi5kYXRhLkRpZ2l0YWxBdWRpby5EZXZpY2VCBKCGGQES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 4) = "PgoSbWFpbl9vdXRwdXRfZGV2aWNlGAMgASgLMhwucnYuZGF0YS5EaWdpdGFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 5) = "QXVkaW8uRGV2aWNlQgSghhkBEh0KFWVuYWJsZV9zZGlfbmRpX2RldmljZRgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 6) = "IAEoCBI6Cg5zZGlfbmRpX2RldmljZRgFIAEoCzIcLnJ2LmRhdGEuRGlnaXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 7) = "bEF1ZGlvLkRldmljZUIEoIYZARIYChBtb25pdG9yX29uX21haW5zGAYgASgI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 8) = "EiIKGmRpc2FibGVfbWFpbl9vdXRwdXRfZGV2aWNlGAcgASgIGlkKA0J1cxIM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 9) = "CgRuYW1lGAEgASgJEg0KBW11dGVkGAIgASgIEgwKBHNvbG8YAyABKAgSEQoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 10) = "dGVzdF90b25lGAQgASgIEhQKDG1hc3Rlcl9sZXZlbBgFIAEoARqYBQoGRGV2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 11) = "aWNlEgwKBG5hbWUYASABKAkSEAoIcmVuZGVySUQYAiABKAkSNAoHZm9ybWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 12) = "cxgDIAMoCzIjLnJ2LmRhdGEuRGlnaXRhbEF1ZGlvLkRldmljZS5Gb3JtYXQS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 13) = "NQoHcm91dGluZxgEIAEoCzIkLnJ2LmRhdGEuRGlnaXRhbEF1ZGlvLkRldmlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 14) = "ZS5Sb3V0aW5nGo4BCgZGb3JtYXQSEwoLc2FtcGxlX3JhdGUYASABKA0SEQoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 15) = "Yml0X2RlcHRoGAIgASgNEjYKBHR5cGUYAyABKA4yKC5ydi5kYXRhLkRpZ2l0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 16) = "YWxBdWRpby5EZXZpY2UuRm9ybWF0LlR5cGUiJAoEVHlwZRIMCghUWVBFX0lO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 17) = "VBAAEg4KClRZUEVfRkxPQVQQARo0CgNNYXASFQoNY2hhbm5lbF9pbmRleBgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 18) = "IAEoDRIWCg5tYXBwZWRfaW5kaWNlcxgCIAMoDRpsCgdDaGFubmVsEhMKC211";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 19) = "dGVfZW5hYmxlGAEgASgIEhMKC3NvbG9fZW5hYmxlGAIgASgIEhMKC3RvbmVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 20) = "ZW5hYmxlGAMgASgIEhMKC2F1ZGlvX2RlbGF5GAQgASgBEg0KBWxldmVsGAUg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 21) = "ASgBGssBCgdSb3V0aW5nEjYKCGNoYW5uZWxzGAEgAygLMiQucnYuZGF0YS5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 22) = "aWdpdGFsQXVkaW8uRGV2aWNlLkNoYW5uZWwSLQoDbWFwGAIgAygLMiAucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 23) = "ZGF0YS5EaWdpdGFsQXVkaW8uRGV2aWNlLk1hcBIVCg1pc19jdXN0b21fbWFw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 24) = "GAMgASgIEkIKDm1hc3Rlcl9jaGFubmVsGAQgASgLMiQucnYuZGF0YS5EaWdp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 25) = "dGFsQXVkaW8uRGV2aWNlLkNoYW5uZWxCBKCGGQFCNPgBAaoCJFByby5TZXJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 26) = "YWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9iBnByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray28<string>, string>(ref buffer, 27) = "Mw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray28<string>, string>(in buffer, 28))), new FileDescriptor[1] { CustomOptionsReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(DigitalAudio), DigitalAudio.Parser, null, null, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(DigitalAudio.Types.Setup), DigitalAudio.Types.Setup.Parser, new string[7] { "Buses", "MonitorDevice", "MainOutputDevice", "EnableSdiNdiDevice", "SdiNdiDevice", "MonitorOnMains", "DisableMainOutputDevice" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(DigitalAudio.Types.Bus), DigitalAudio.Types.Bus.Parser, new string[5] { "Name", "Muted", "Solo", "TestTone", "MasterLevel" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(DigitalAudio.Types.Device), DigitalAudio.Types.Device.Parser, new string[4] { "Name", "RenderID", "Formats", "Routing" }, null, null, null, new GeneratedClrTypeInfo[4]
				{
					new GeneratedClrTypeInfo(typeof(DigitalAudio.Types.Device.Types.Format), DigitalAudio.Types.Device.Types.Format.Parser, new string[3] { "SampleRate", "BitDepth", "Type" }, null, new Type[1] { typeof(DigitalAudio.Types.Device.Types.Format.Types.Type) }, null, null),
					new GeneratedClrTypeInfo(typeof(DigitalAudio.Types.Device.Types.Map), DigitalAudio.Types.Device.Types.Map.Parser, new string[2] { "ChannelIndex", "MappedIndices" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(DigitalAudio.Types.Device.Types.Channel), DigitalAudio.Types.Device.Types.Channel.Parser, new string[5] { "MuteEnable", "SoloEnable", "ToneEnable", "AudioDelay", "Level" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(DigitalAudio.Types.Device.Types.Routing), DigitalAudio.Types.Device.Types.Routing.Parser, new string[4] { "Channels", "Map", "IsCustomMap", "MasterChannel" }, null, null, null, null)
				})
			})
		}));
	}
}
