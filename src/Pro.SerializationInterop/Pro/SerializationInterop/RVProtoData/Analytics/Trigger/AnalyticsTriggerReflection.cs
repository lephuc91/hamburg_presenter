using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

public static class AnalyticsTriggerReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsTriggerReflection()
	{
		_003C_003Ey__InlineArray63<string> buffer = default(_003C_003Ey__InlineArray63<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 0) = "ChZhbmFseXRpY3NUcmlnZ2VyLnByb3RvEhRydi5hbmFseXRpY3MudHJpZ2dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 1) = "ciKiAQoSQWN0aW9uQ2FwdHVyZVN0YXJ0EkgKC3ByZXNldF90eXBlGAEgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 2) = "MjMucnYuYW5hbHl0aWNzLnRyaWdnZXIuQWN0aW9uQ2FwdHVyZVN0YXJ0LlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 3) = "ZXNldFR5cGUiQgoKUHJlc2V0VHlwZRILCgdVTktOT1dOEAASEwoPQUNUSVZF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 4) = "X1NFVFRJTkdTEAESEgoOQ0FQVFVSRV9QUkVTRVQQAiI0ChFBY3Rpb25DYXB0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 5) = "dXJlU3RvcBIfChdjb25maXJtX2JlZm9yZV9zdG9wcGluZxgBIAEoCCLbAQoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 6) = "QWN0aW9uQ2xlYXISNAoEdHlwZRgBIAEoDjImLnJ2LmFuYWx5dGljcy50cmln";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 7) = "Z2VyLkFjdGlvbkNsZWFyLlR5cGUilQEKBFR5cGUSCwoHVU5LTk9XThAAEgkK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 8) = "BUFVRElPEAESDAoITUVTU0FHRVMQAhIJCgVQUk9QUxADEhEKDUFOTk9VTkNF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 9) = "TUVOVFMQBBIJCgVTTElERRAFEgkKBU1FRElBEAYSDwoLVklERU9fSU5QVVQQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 10) = "BxIRCg1DTEVBUl9UT19MT0dPEAgSDwoLQ0xFQVJfR1JPVVAQCSK1AQoQQWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 11) = "aW9uQ2xlYXJHcm91cBITCgtsYXllcl9hdWRpbxgBIAEoCBIWCg5sYXllcl9t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 12) = "ZXNzYWdlcxgCIAEoCBITCgtsYXllcl9wcm9wcxgDIAEoCBIaChJsYXllcl9h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 13) = "bm5vdW5jZW1lbnQYBCABKAgSEwoLbGF5ZXJfc2xpZGUYBSABKAgSEwoLbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 14) = "ZXJfbWVkaWEYBiABKAgSGQoRbGF5ZXJfdmlkZW9faW5wdXQYByABKAgiFgoU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 15) = "QWN0aW9uQ29tbXVuaWNhdGlvbnMitQQKCkFjdGlvbkxvb2sSGgoSdG90YWxf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 16) = "c2NyZWVuX2NvdW50GAEgASgFEjYKBG1hc2sYAiABKA4yKC5ydi5hbmFseXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 17) = "Y3MudHJpZ2dlci5BY3Rpb25Mb29rLlNldHRpbmcSOgoIbWVzc2FnZXMYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 18) = "KA4yKC5ydi5hbmFseXRpY3MudHJpZ2dlci5BY3Rpb25Mb29rLlNldHRpbmcS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 19) = "NwoFcHJvcHMYBCABKA4yKC5ydi5hbmFseXRpY3MudHJpZ2dlci5BY3Rpb25M";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 20) = "b29rLlNldHRpbmcSPwoNYW5ub3VuY2VtZW50cxgFIAEoDjIoLnJ2LmFuYWx5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 21) = "dGljcy50cmlnZ2VyLkFjdGlvbkxvb2suU2V0dGluZxJEChJwcmVzZW50YXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 22) = "b25fdGhlbWUYBiABKA4yKC5ydi5hbmFseXRpY3MudHJpZ2dlci5BY3Rpb25M";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 23) = "b29rLlNldHRpbmcSNwoFc2xpZGUYByABKA4yKC5ydi5hbmFseXRpY3MudHJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 24) = "Z2dlci5BY3Rpb25Mb29rLlNldHRpbmcSNwoFbWVkaWEYCCABKA4yKC5ydi5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 25) = "bmFseXRpY3MudHJpZ2dlci5BY3Rpb25Mb29rLlNldHRpbmcSPQoLdmlkZW9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 26) = "aW5wdXQYCSABKA4yKC5ydi5hbmFseXRpY3MudHJpZ2dlci5BY3Rpb25Mb29r";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 27) = "LlNldHRpbmciJgoHU2V0dGluZxIICgROT05FEAASCAoEU09NRRABEgcKA0FM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 28) = "TBACIlkKC0FjdGlvbk1hY3JvEhQKDGFjdGlvbl9jb3VudBgBIAEoBRIYChBj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 29) = "dWVfYWN0aW9uX2NvdW50GAIgASgFEhoKEnRvdGFsX2FjdGlvbl9jb3VudBgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 30) = "IAEoBSKLAQoNQWN0aW9uTWVzc2FnZRITCgt0b2tlbl9jb3VudBgBIAEoBRIY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 31) = "ChB0ZXh0X3Rva2VuX2NvdW50GAIgASgFEhkKEXRpbWVyX3Rva2VuX2NvdW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 32) = "GAMgASgFEhkKEWNsb2NrX3Rva2VuX2NvdW50GAQgASgFEhUKDXNob3dpbmdf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 33) = "Y291bnQYBSABKAUiggMKCkFjdGlvblByb3ASEgoKdHJhbnNpdGlvbhgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 34) = "CRIzCgR0eXBlGAIgASgOMiUucnYuYW5hbHl0aWNzLnRyaWdnZXIuQWN0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 35) = "UHJvcC5UeXBlEj4KCmF1dG9fY2xlYXIYAyABKA4yKi5ydi5hbmFseXRpY3Mu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 36) = "dHJpZ2dlci5BY3Rpb25Qcm9wLkF1dG9DbGVhciJLCgRUeXBlEhAKDFRZUEVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 37) = "VU5LTk9XThAAEgsKB1RSSUdHRVIQARIJCgVDTEVBUhACEhkKFVRSSUdHRVJf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 38) = "RlJPTV9QUk9QX0JJThADIp0BCglBdXRvQ2xlYXISCwoHVU5LTk9XThAAEhQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 39) = "EERFRkFVTFRfRElTQUJMRUQQARITCg9ERUZBVUxUX0VOQUJMRUQQAhIMCghE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 40) = "SVNBQkxFRBADEgsKB0VOQUJMRUQQBBIVChFESVNBQkxFRF9PVkVSUklERRAF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 41) = "EhQKEEVOQUJMRURfT1ZFUlJJREUQBhIQCgxDTEVBUl9BQ1RJT04QByLZAQoW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 42) = "QWN0aW9uU2xpZGVEZXN0aW5hdGlvbhJlChhjaGFuZ2Vfc2xpZGVfZGVzdGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 43) = "YXRpb24YASABKA4yQy5ydi5hbmFseXRpY3MudHJpZ2dlci5BY3Rpb25TbGlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 44) = "ZURlc3RpbmF0aW9uLkNoYW5nZVNsaWRlRGVzdGluYXRpb24iWAoWQ2hhbmdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 45) = "U2xpZGVEZXN0aW5hdGlvbhILCgdVTktOT1dOEAASDQoJTk9fQ0hBTkdFEAES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 46) = "DgoKU1RBR0VfT05MWRACEhIKDlNUQUdFX0FVRElFTkNFEAMiOwoLQWN0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 47) = "U3RhZ2USDwoHbGF5b3V0cxgBIAEoBRIbChN0b3RhbF9zdGFnZV9zY3JlZW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 48) = "GAIgASgFIsABCgtBY3Rpb25UaW1lchI0CgR0eXBlGAEgASgOMiYucnYuYW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 49) = "bHl0aWNzLnRyaWdnZXIuQWN0aW9uVGltZXIuVHlwZSJ7CgRUeXBlEgsKB1VO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 50) = "S05PV04QABIbChdTVEFSVF9TRVRfQ09ORklHVVJBVElPThABEgkKBVNUQVJU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 51) = "EAISCAoEU1RPUBADEgkKBVJFU0VUEAQSGgoWU1RPUF9TRVRfQ09ORklHVVJB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 52) = "VElPThAFEg0KCUlOQ1JFTUVOVBAGItACCgtUZXN0UGF0dGVybhI6CgdwYXR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 53) = "ZXJuGAEgASgOMikucnYuYW5hbHl0aWNzLnRyaWdnZXIuVGVzdFBhdHRlcm4u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 54) = "UGF0dGVybhI0CgRsb2dvGAIgASgOMiYucnYuYW5hbHl0aWNzLnRyaWdnZXIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 55) = "VGVzdFBhdHRlcm4uTG9nbyKeAQoHUGF0dGVybhIUChBBVURJT19WSURFT19T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 56) = "WU5DEAASDgoKQkxFTkRfR1JJRBABEg4KCkNPTE9SX0JBUlMQAhIRCg1DVVNU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 57) = "T01fQ09MT1JTEAMSCQoFRk9DVVMQBBIOCgpHUkFZX1NDQUxFEAUSCQoFTElO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 58) = "RVMQBhIPCgtMT0dPX0JPVU5DRRAHEgkKBVJBREFSEAgSCAoEVEVYVBAJIi4K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 59) = "BExvZ28SCAoETk9ORRAAEhAKDFBST1BSRVNFTlRFUhABEgoKBkNVU1RPTRAC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 60) = "QlH4AQGqAjZQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 61) = "QW5hbHl0aWNzLlRyaWdnZXK6AhJBbmFseXRpY3NfVHJpZ2dlcl9iBnByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray63<string>, string>(ref buffer, 62) = "Mw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray63<string>, string>(in buffer, 63))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[13]
		{
			new GeneratedClrTypeInfo(typeof(ActionCaptureStart), ActionCaptureStart.Parser, new string[1] { "PresetType" }, null, new Type[1] { typeof(ActionCaptureStart.Types.PresetType) }, null, null),
			new GeneratedClrTypeInfo(typeof(ActionCaptureStop), ActionCaptureStop.Parser, new string[1] { "ConfirmBeforeStopping" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActionClear), ActionClear.Parser, new string[1] { "Type" }, null, new Type[1] { typeof(ActionClear.Types.Type) }, null, null),
			new GeneratedClrTypeInfo(typeof(ActionClearGroup), ActionClearGroup.Parser, new string[7] { "LayerAudio", "LayerMessages", "LayerProps", "LayerAnnouncement", "LayerSlide", "LayerMedia", "LayerVideoInput" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActionCommunications), ActionCommunications.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActionLook), ActionLook.Parser, new string[9] { "TotalScreenCount", "Mask", "Messages", "Props", "Announcements", "PresentationTheme", "Slide", "Media", "VideoInput" }, null, new Type[1] { typeof(ActionLook.Types.Setting) }, null, null),
			new GeneratedClrTypeInfo(typeof(ActionMacro), ActionMacro.Parser, new string[3] { "ActionCount", "CueActionCount", "TotalActionCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActionMessage), ActionMessage.Parser, new string[5] { "TokenCount", "TextTokenCount", "TimerTokenCount", "ClockTokenCount", "ShowingCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActionProp), ActionProp.Parser, new string[3] { "Transition", "Type", "AutoClear" }, null, new Type[2]
			{
				typeof(ActionProp.Types.Type),
				typeof(ActionProp.Types.AutoClear)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(ActionSlideDestination), ActionSlideDestination.Parser, new string[1] { "ChangeSlideDestination" }, null, new Type[1] { typeof(ActionSlideDestination.Types.ChangeSlideDestination) }, null, null),
			new GeneratedClrTypeInfo(typeof(ActionStage), ActionStage.Parser, new string[2] { "Layouts", "TotalStageScreens" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActionTimer), ActionTimer.Parser, new string[1] { "Type" }, null, new Type[1] { typeof(ActionTimer.Types.Type) }, null, null),
			new GeneratedClrTypeInfo(typeof(TestPattern), TestPattern.Parser, new string[2] { "Pattern", "Logo" }, null, new Type[2]
			{
				typeof(TestPattern.Types.Pattern),
				typeof(TestPattern.Types.Logo)
			}, null, null)
		}));
	}
}
