using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

public static class AnalyticsTriggerMediaReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsTriggerMediaReflection()
	{
		_003C_003Ey__InlineArray69<string> buffer = default(_003C_003Ey__InlineArray69<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 0) = "ChthbmFseXRpY3NUcmlnZ2VyTWVkaWEucHJvdG8SGnJ2LmFuYWx5dGljcy50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 1) = "cmlnZ2VyLm1lZGlhIi4KClRyYW5zaXRpb24SEgoKaXNfZGVmYXVsdBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 2) = "CBIMCgRuYW1lGAIgASgJIv4FCgtWaXN1YWxNZWRpYRJCCghiZWhhdmlvchgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 3) = "IAEoDjIwLnJ2LmFuYWx5dGljcy50cmlnZ2VyLm1lZGlhLlZpc3VhbE1lZGlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 4) = "LkJlaGF2aW9yEkUKCnNjYWxlX21vZGUYAiABKA4yMS5ydi5hbmFseXRpY3Mu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 5) = "dHJpZ2dlci5tZWRpYS5WaXN1YWxNZWRpYS5TY2FsZU1vZGUSQwoJZmxpcF9t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 6) = "b2RlGAMgASgOMjAucnYuYW5hbHl0aWNzLnRyaWdnZXIubWVkaWEuVmlzdWFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 7) = "TWVkaWEuRmxpcE1vZGUSTwoPbmF0aXZlX3JvdGF0aW9uGAQgASgOMjYucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 8) = "YW5hbHl0aWNzLnRyaWdnZXIubWVkaWEuVmlzdWFsTWVkaWEuTmF0aXZlUm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 9) = "YXRpb24SQAoKcmVzb2x1dGlvbhgFIAEoCzIsLnJ2LmFuYWx5dGljcy50cmln";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 10) = "Z2VyLm1lZGlhLlZpc3VhbE1lZGlhLlNpemUSHQoVZW5hYmxlZF9lZmZlY3Rz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 11) = "X2NvdW50GAYgASgNEhkKEWhhc19lZmZlY3RfcHJlc2V0GAcgASgIEjoKCnRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 12) = "YW5zaXRpb24YCCABKAsyJi5ydi5hbmFseXRpY3MudHJpZ2dlci5tZWRpYS5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 13) = "cmFuc2l0aW9uGiUKBFNpemUSDQoFd2lkdGgYASABKA0SDgoGaGVpZ2h0GAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 14) = "ASgNIjsKCEJlaGF2aW9yEg4KCkJBQ0tHUk9VTkQQABIOCgpGT1JFR1JPVU5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 15) = "EAESDwoLVklERU9fSU5QVVQQAiI1CglTY2FsZU1vZGUSBwoDRklUEAASCAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 16) = "RklMTBABEgsKB1NUUkVUQ0gQAhIICgRCTFVSEAMiPAoIRmxpcE1vZGUSCAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 17) = "Tk9ORRAAEg4KCkhPUklaT05UQUwQARIMCghWRVJUSUNBTBACEggKBEJPVEgQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 18) = "AyI9Cg5OYXRpdmVSb3RhdGlvbhIMCghTVEFOREFSRBAAEgcKA185MBBaEgkK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 19) = "BF8xODAQtAESCQoEXzI3MBCOAiKVAwoJVHJhbnNwb3J0ElIKFXNvdXJjZV9k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 20) = "dXJhdGlvbl9yYW5nZRgBIAEoDjIzLnJ2LmFuYWx5dGljcy50cmlnZ2VyLm1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 21) = "ZGlhLlRyYW5zcG9ydC5EdXJhdGlvblJhbmdlEhkKEWhhc19hdWRpb19yYW1w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 22) = "X2luGAIgASgIEhoKEmhhc19hdWRpb19yYW1wX291dBgDIAEoCBIUCgxoYXNf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 23) = "aW5fcG9pbnQYBCABKAgSFQoNaGFzX291dF9wb2ludBgFIAEoCBIRCglwbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 24) = "X3JhdGUYBiABKAESHQoVcGxheWJhY2tfbWFya2VyX2NvdW50GAcgASgNIp0B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 25) = "Cg1EdXJhdGlvblJhbmdlEg0KCVVOREVSXzEwUxAAEg8KC18xMFNfVE9fMzBT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 26) = "EAESDwoLXzMwU19UT182MFMQAhINCglfMU1fVE9fNU0QAxIOCgpfNU1fVE9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 27) = "MTBNEAQSDwoLXzEwTV9UT18zME0QBRIPCgtfMzBNX1RPXzYwTRAGEg0KCV8x";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 28) = "SF9UT18ySBAHEgsKB09WRVJfMkgQCCKZBQoFVmlkZW8SPQoMdmlzdWFsX21l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 29) = "ZGlhGAcgASgLMicucnYuYW5hbHl0aWNzLnRyaWdnZXIubWVkaWEuVmlzdWFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 30) = "TWVkaWESTQoRcGxheWJhY2tfYmVoYXZpb3IYCCABKA4yMi5ydi5hbmFseXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 31) = "Y3MudHJpZ2dlci5tZWRpYS5WaWRlby5QbGF5YmFja0JlaGF2aW9yEkcKEWNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 32) = "bXBsZXRpb25fdGFyZ2V0GAkgASgOMiwucnYuYW5hbHl0aWNzLnRyaWdnZXIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 33) = "bWVkaWEuQ29tcGxldGlvblRhcmdldBIZChFzb2Z0X2xvb3BfZW5hYmxlZBgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 34) = "IAEoCBIaChJzb2Z0X2xvb3BfZHVyYXRpb24YCyABKAESEgoKZnJhbWVfcmF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 35) = "ZRgMIAEoARIbChNhdWRpb19jaGFubmVsX2NvdW50GA0gASgNEjgKCXRyYW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 36) = "cG9ydBgOIAEoCzIlLnJ2LmFuYWx5dGljcy50cmlnZ2VyLm1lZGlhLlRyYW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 37) = "cG9ydBI7Cgtzb3VyY2VfdHlwZRgPIAEoDjImLnJ2LmFuYWx5dGljcy50cmln";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 38) = "Z2VyLm1lZGlhLlNvdXJjZVR5cGUSUQoRaGFyZHdhcmVfZGVjb2RpbmcYECAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 39) = "KA4yNi5ydi5hbmFseXRpY3MudHJpZ2dlci5tZWRpYS5WaWRlby5IYXJkd2Fy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 40) = "ZURlY29kaW5nVHlwZSJSChBQbGF5YmFja0JlaGF2aW9yEggKBFNUT1AQABII";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 41) = "CgRMT09QEAESFwoTTE9PUF9GT1JfUExBWV9DT1VOVBACEhEKDUxPT1BfRk9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 42) = "X1RJTUUQAyIzChRIYXJkd2FyZURlY29kaW5nVHlwZRINCglBVVRPTUFUSUMQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 43) = "ABIMCghESVNBQkxFRBABIrcDCgVBdWRpbxI8CghiZWhhdmlvchgBIAEoDjIq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 44) = "LnJ2LmFuYWx5dGljcy50cmlnZ2VyLm1lZGlhLkF1ZGlvLkJlaGF2aW9yEk0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 45) = "EXBsYXliYWNrX2JlaGF2aW9yGAIgASgOMjIucnYuYW5hbHl0aWNzLnRyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 46) = "ZXIubWVkaWEuQXVkaW8uUGxheWJhY2tCZWhhdmlvchI6Cgp0cmFuc2l0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 47) = "GAMgASgLMiYucnYuYW5hbHl0aWNzLnRyaWdnZXIubWVkaWEuVHJhbnNpdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 48) = "bhIbChNhdWRpb19jaGFubmVsX2NvdW50GAQgASgNEjgKCXRyYW5zcG9ydBgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 49) = "IAEoCzIlLnJ2LmFuYWx5dGljcy50cmlnZ2VyLm1lZGlhLlRyYW5zcG9ydBI7";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 50) = "Cgtzb3VyY2VfdHlwZRgGIAEoDjImLnJ2LmFuYWx5dGljcy50cmlnZ2VyLm1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 51) = "ZGlhLlNvdXJjZVR5cGUiHwoIQmVoYXZpb3ISCAoEVFVORRAAEgkKBVNPVU5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 52) = "EAEiMAoQUGxheWJhY2tCZWhhdmlvchIICgRTVE9QEAASCAoETE9PUBABEggK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 53) = "BE5FWFQQAiLMAQoFSW1hZ2USPQoMdmlzdWFsX21lZGlhGAEgASgLMicucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 54) = "YW5hbHl0aWNzLnRyaWdnZXIubWVkaWEuVmlzdWFsTWVkaWESRwoRY29tcGxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 55) = "dGlvbl90YXJnZXQYAiABKA4yLC5ydi5hbmFseXRpY3MudHJpZ2dlci5tZWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 56) = "YS5Db21wbGV0aW9uVGFyZ2V0EjsKC3NvdXJjZV90eXBlGAMgASgOMiYucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 57) = "YW5hbHl0aWNzLnRyaWdnZXIubWVkaWEuU291cmNlVHlwZSK5AQoKVmlkZW9J";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 58) = "bnB1dBI9Cgx2aXN1YWxfbWVkaWEYASABKAsyJy5ydi5hbmFseXRpY3MudHJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 59) = "Z2dlci5tZWRpYS5WaXN1YWxNZWRpYRISCgpmcmFtZV9yYXRlGAIgASgBEhsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 60) = "E2F1ZGlvX2NoYW5uZWxfY291bnQYAyABKA0SOwoLc291cmNlX3R5cGUYBCAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 61) = "KA4yJi5ydi5hbmFseXRpY3MudHJpZ2dlci5tZWRpYS5Tb3VyY2VUeXBlIigK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 62) = "DEFpckNhc3RWaWRlbxIYChBwYXNzd29yZF9lbmFibGVkGAEgASgIIigKDEFp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 63) = "ckNhc3RBdWRpbxIYChBwYXNzd29yZF9lbmFibGVkGAEgASgIKkYKEENvbXBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 64) = "ZXRpb25UYXJnZXQSCAoETk9ORRAAEggKBE5FWFQQARIKCgZSQU5ET00QAhIH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 65) = "CgNDVUUQAxIJCgVGSVJTVBAEKicKClNvdXJjZVR5cGUSCQoFTE9DQUwQABIO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 66) = "CgpQUk9DT05URU5UEAFCXfgBAaoCPFByby5TZXJpYWxpemF0aW9uSW50ZXJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 67) = "cC5SVlByb3RvRGF0YS5BbmFseXRpY3MuVHJpZ2dlci5NZWRpYboCGEFuYWx5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 68) = "dGljc19UcmlnZ2VyX01lZGlhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray69<string>, string>(in buffer, 69))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[2]
		{
			typeof(CompletionTarget),
			typeof(SourceType)
		}, null, new GeneratedClrTypeInfo[9]
		{
			new GeneratedClrTypeInfo(typeof(Transition), Transition.Parser, new string[2] { "IsDefault", "Name" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(VisualMedia), VisualMedia.Parser, new string[8] { "Behavior", "ScaleMode", "FlipMode", "NativeRotation", "Resolution", "EnabledEffectsCount", "HasEffectPreset", "Transition" }, null, new Type[4]
			{
				typeof(VisualMedia.Types.Behavior),
				typeof(VisualMedia.Types.ScaleMode),
				typeof(VisualMedia.Types.FlipMode),
				typeof(VisualMedia.Types.NativeRotation)
			}, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(VisualMedia.Types.Size), VisualMedia.Types.Size.Parser, new string[2] { "Width", "Height" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(Transport), Transport.Parser, new string[7] { "SourceDurationRange", "HasAudioRampIn", "HasAudioRampOut", "HasInPoint", "HasOutPoint", "PlayRate", "PlaybackMarkerCount" }, null, new Type[1] { typeof(Transport.Types.DurationRange) }, null, null),
			new GeneratedClrTypeInfo(typeof(Video), Video.Parser, new string[10] { "VisualMedia", "PlaybackBehavior", "CompletionTarget", "SoftLoopEnabled", "SoftLoopDuration", "FrameRate", "AudioChannelCount", "Transport", "SourceType", "HardwareDecoding" }, null, new Type[2]
			{
				typeof(Video.Types.PlaybackBehavior),
				typeof(Video.Types.HardwareDecodingType)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(Audio), Audio.Parser, new string[6] { "Behavior", "PlaybackBehavior", "Transition", "AudioChannelCount", "Transport", "SourceType" }, null, new Type[2]
			{
				typeof(Audio.Types.Behavior),
				typeof(Audio.Types.PlaybackBehavior)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(Image), Image.Parser, new string[3] { "VisualMedia", "CompletionTarget", "SourceType" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(VideoInput), VideoInput.Parser, new string[4] { "VisualMedia", "FrameRate", "AudioChannelCount", "SourceType" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AirCastVideo), AirCastVideo.Parser, new string[1] { "PasswordEnabled" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AirCastAudio), AirCastAudio.Parser, new string[1] { "PasswordEnabled" }, null, null, null, null)
		}));
	}
}
