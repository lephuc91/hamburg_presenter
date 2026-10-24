using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class TimedPlaybackReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static TimedPlaybackReflection()
	{
		_003C_003Ey__InlineArray59<string> buffer = default(_003C_003Ey__InlineArray59<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 0) = "ChN0aW1lZFBsYXliYWNrLnByb3RvEgdydi5kYXRhGgxhY3Rpb24ucHJvdG8a";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 1) = "CWN1ZS5wcm90bxoScHJlc2VudGF0aW9uLnByb3RvGg5wbGF5bGlzdC5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 2) = "bxoKdXVpZC5wcm90byKoAwoNVHJpZ2dlclNvdXJjZRI6ChBsaWJyYXJ5X2xv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 3) = "Y2F0aW9uGAEgASgLMh4ucnYuZGF0YS5UcmlnZ2VyU291cmNlLkxpYnJhcnlI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 4) = "ABI8ChFwbGF5bGlzdF9sb2NhdGlvbhgCIAEoCzIfLnJ2LmRhdGEuVHJpZ2dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 5) = "clNvdXJjZS5QbGF5bGlzdEgAEkIKF21lZGlhX3BsYXlsaXN0X2xvY2F0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 6) = "GAMgASgLMh8ucnYuZGF0YS5UcmlnZ2VyU291cmNlLlBsYXlsaXN0SAASQgoX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 7) = "YXVkaW9fcGxheWxpc3RfbG9jYXRpb24YBCABKAsyHy5ydi5kYXRhLlRyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 8) = "ZXJTb3VyY2UuUGxheWxpc3RIABoyCgdMaWJyYXJ5EgwKBHBhdGgYASABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 9) = "GQoRcHJlc2VudGF0aW9uX25hbWUYAiABKAkaVQoIUGxheWxpc3QSIQoKaWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 10) = "bnRpZmllchgBIAEoCzINLnJ2LmRhdGEuVVVJRBImCg9pdGVtX2lkZW50aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 11) = "ZXIYAiABKAsyDS5ydi5kYXRhLlVVSURCCgoITG9jYXRpb24igxAKDVRpbWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 12) = "UGxheWJhY2sSMQoIc2VxdWVuY2UYASABKAsyHy5ydi5kYXRhLlRpbWVkUGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 13) = "eWJhY2suU2VxdWVuY2USLQoGdGltaW5nGAIgASgLMh0ucnYuZGF0YS5UaW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 14) = "ZFBsYXliYWNrLlRpbWluZxrqAwoIU2VxdWVuY2USPgoIc2VxdWVuY2UYASAD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 15) = "KAsyLC5ydi5kYXRhLlRpbWVkUGxheWJhY2suU2VxdWVuY2UuU2VxdWVuY2VJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 16) = "dGVtEj8KE2NvbnRlbnRfZGVzdGluYXRpb24YAiABKA4yIi5ydi5kYXRhLkFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 17) = "dGlvbi5Db250ZW50RGVzdGluYXRpb24SKwoMcHJlc2VudGF0aW9uGAMgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 18) = "MhUucnYuZGF0YS5QcmVzZW50YXRpb24SIwoIcGxheWxpc3QYBCABKAsyES5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 19) = "di5kYXRhLlBsYXlsaXN0GooCCgxTZXF1ZW5jZUl0ZW0SIQoKaWRlbnRpZmll";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 20) = "chgBIAEoCzINLnJ2LmRhdGEuVVVJRBIMCgR0aW1lGAIgASgBEi4KDnRyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 21) = "ZXJfc291cmNlGAMgASgLMhYucnYuZGF0YS5UcmlnZ2VyU291cmNlEj8KE2Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 22) = "bnRlbnRfZGVzdGluYXRpb24YBCABKA4yIi5ydi5kYXRhLkFjdGlvbi5Db250";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 23) = "ZW50RGVzdGluYXRpb24SGwoDY3VlGAUgASgLMgwucnYuZGF0YS5DdWVIABIh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 24) = "CgZhY3Rpb24YBiABKAsyDy5ydi5kYXRhLkFjdGlvbkgAEhAKCGVuZF90aW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 25) = "GAcgASgBQgYKBEl0ZW0anQQKBlRpbWluZxJHCg9sYXllcl90cmFuc3BvcnQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 26) = "ASABKAsyLC5ydi5kYXRhLlRpbWVkUGxheWJhY2suVGltaW5nLkxheWVyVHJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 27) = "bnNwb3J0SAASRQoOc21wdGVfdGltZWNvZGUYAiABKAsyKy5ydi5kYXRhLlRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 28) = "bWVkUGxheWJhY2suVGltaW5nLlNNUFRFVGltZWNvZGVIABI6CghpbnRlcm5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 29) = "bBgDIAEoCzImLnJ2LmRhdGEuVGltZWRQbGF5YmFjay5UaW1pbmcuSW50ZXJu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 30) = "YWxIABofCg5MYXllclRyYW5zcG9ydBINCgVsYXllchgBIAEoBRroAQoNU01Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 31) = "VEVUaW1lY29kZRIZChFkZXZpY2VfaWRlbnRpZmllchgBIAEoCRIPCgdjaGFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 32) = "bmVsGAIgASgFEkIKBmZvcm1hdBgDIAEoDjIyLnJ2LmRhdGEuVGltZWRQbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 33) = "YmFjay5UaW1pbmcuU01QVEVUaW1lY29kZS5Gb3JtYXQSDgoGb2Zmc2V0GAQg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 34) = "ASgBIlcKBkZvcm1hdBIRCg1GT1JNQVRfMjRfRlBTEAASEQoNRk9STUFUXzI1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 35) = "X0ZQUxABEhQKEEZPUk1BVF8yOV85N19GUFMQAhIRCg1GT1JNQVRfMzBfRlBT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 36) = "EAMaMQoISW50ZXJuYWwSEAoIZHVyYXRpb24YASABKAESEwoLc2hvdWxkX2xv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 37) = "b3AYAiABKAhCCAoGU291cmNlGoIHCgZVcGRhdGUSMgoEcGxheRgBIAEoCzIi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 38) = "LnJ2LmRhdGEuVGltZWRQbGF5YmFjay5VcGRhdGUuUGxheUgAEjYKBnJlY29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 39) = "ZBgCIAEoCzIkLnJ2LmRhdGEuVGltZWRQbGF5YmFjay5VcGRhdGUuUmVjb3Jk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 40) = "SAASNAoFcGF1c2UYAyABKAsyIy5ydi5kYXRhLlRpbWVkUGxheWJhY2suVXBk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 41) = "YXRlLlBhdXNlSAASNAoFcmVzZXQYBCABKAsyIy5ydi5kYXRhLlRpbWVkUGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 42) = "eWJhY2suVXBkYXRlLlJlc2V0SAASQAoManVtcF90b190aW1lGAUgASgLMigu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 43) = "cnYuZGF0YS5UaW1lZFBsYXliYWNrLlVwZGF0ZS5KdW1wVG9UaW1lSAASPwoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 44) = "c3RhcnRfc2NydWIYBiABKAsyKC5ydi5kYXRhLlRpbWVkUGxheWJhY2suVXBk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 45) = "YXRlLlN0YXJ0U2NydWJIABI7CgllbmRfc2NydWIYByABKAsyJi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 46) = "LlRpbWVkUGxheWJhY2suVXBkYXRlLkVuZFNjcnViSAASOgoIZHVyYXRpb24Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 47) = "CCABKAsyJi5ydi5kYXRhLlRpbWVkUGxheWJhY2suVXBkYXRlLkR1cmF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 48) = "SAASMgoEbG9vcBgJIAEoCzIiLnJ2LmRhdGEuVGltZWRQbGF5YmFjay5VcGRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 49) = "dGUuTG9vcEgAEjoKD3VwZGF0ZV9zZXF1ZW5jZRgKIAEoCzIfLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 50) = "VGltZWRQbGF5YmFjay5TZXF1ZW5jZUgAEkUKDm1vbml0b3Jfc291cmNlGAsg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 51) = "ASgLMisucnYuZGF0YS5UaW1lZFBsYXliYWNrLlVwZGF0ZS5Nb25pdG9yU291";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 52) = "cmNlSAAaBgoEUGxheRoeCgZSZWNvcmQSFAoMaXNfcmVjb3JkaW5nGAEgASgI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 53) = "GgcKBVBhdXNlGgcKBVJlc2V0GhoKCkp1bXBUb1RpbWUSDAoEdGltZRgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 54) = "ARoaCgpTdGFydFNjcnViEgwKBHRpbWUYASABKAEaGAoIRW5kU2NydWISDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 55) = "dGltZRgCIAEoARocCghEdXJhdGlvbhIQCghkdXJhdGlvbhgBIAEoARoUCgRM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 56) = "b29wEgwKBGxvb3AYASABKAgaHwoNTW9uaXRvclNvdXJjZRIOCgZlbmFibGUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 57) = "ASABKAhCDAoKQWN0aW9uVHlwZUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25J";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray59<string>, string>(ref buffer, 58) = "bnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray59<string>, string>(in buffer, 59))), new FileDescriptor[5]
		{
			ActionReflection.Descriptor,
			CueReflection.Descriptor,
			PresentationReflection.Descriptor,
			PlaylistReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(TriggerSource), TriggerSource.Parser, new string[4] { "LibraryLocation", "PlaylistLocation", "MediaPlaylistLocation", "AudioPlaylistLocation" }, new string[1] { "Location" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(TriggerSource.Types.Library), TriggerSource.Types.Library.Parser, new string[2] { "Path", "PresentationName" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TriggerSource.Types.Playlist), TriggerSource.Types.Playlist.Parser, new string[2] { "Identifier", "ItemIdentifier" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(TimedPlayback), TimedPlayback.Parser, new string[2] { "Sequence", "Timing" }, null, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Sequence), TimedPlayback.Types.Sequence.Parser, new string[4] { "Sequence_", "ContentDestination", "Presentation", "Playlist" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Sequence.Types.SequenceItem), TimedPlayback.Types.Sequence.Types.SequenceItem.Parser, new string[7] { "Identifier", "Time", "TriggerSource", "ContentDestination", "Cue", "Action", "EndTime" }, new string[1] { "Item" }, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Timing), TimedPlayback.Types.Timing.Parser, new string[3] { "LayerTransport", "SmpteTimecode", "Internal" }, new string[1] { "Source" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Timing.Types.LayerTransport), TimedPlayback.Types.Timing.Types.LayerTransport.Parser, new string[1] { "Layer" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Timing.Types.SMPTETimecode), TimedPlayback.Types.Timing.Types.SMPTETimecode.Parser, new string[4] { "DeviceIdentifier", "Channel", "Format", "Offset" }, null, new Type[1] { typeof(TimedPlayback.Types.Timing.Types.SMPTETimecode.Types.Format) }, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Timing.Types.Internal), TimedPlayback.Types.Timing.Types.Internal.Parser, new string[2] { "Duration", "ShouldLoop" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update), TimedPlayback.Types.Update.Parser, new string[11]
				{
					"Play", "Record", "Pause", "Reset", "JumpToTime", "StartScrub", "EndScrub", "Duration", "Loop", "UpdateSequence",
					"MonitorSource"
				}, new string[1] { "ActionType" }, null, null, new GeneratedClrTypeInfo[10]
				{
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.Play), TimedPlayback.Types.Update.Types.Play.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.Record), TimedPlayback.Types.Update.Types.Record.Parser, new string[1] { "IsRecording" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.Pause), TimedPlayback.Types.Update.Types.Pause.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.Reset), TimedPlayback.Types.Update.Types.Reset.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.JumpToTime), TimedPlayback.Types.Update.Types.JumpToTime.Parser, new string[1] { "Time" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.StartScrub), TimedPlayback.Types.Update.Types.StartScrub.Parser, new string[1] { "Time" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.EndScrub), TimedPlayback.Types.Update.Types.EndScrub.Parser, new string[1] { "Time" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.Duration), TimedPlayback.Types.Update.Types.Duration.Parser, new string[1] { "Duration_" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.Loop), TimedPlayback.Types.Update.Types.Loop.Parser, new string[1] { "Loop_" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TimedPlayback.Types.Update.Types.MonitorSource), TimedPlayback.Types.Update.Types.MonitorSource.Parser, new string[1] { "Enable" }, null, null, null, null)
				})
			})
		}));
	}
}
