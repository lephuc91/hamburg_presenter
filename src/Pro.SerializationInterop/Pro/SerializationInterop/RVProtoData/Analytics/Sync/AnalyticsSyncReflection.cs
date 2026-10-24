using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Sync;

public static class AnalyticsSyncReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsSyncReflection()
	{
		_003C_003Ey__InlineArray14<string> buffer = default(_003C_003Ey__InlineArray14<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 0) = "ChNhbmFseXRpY3NTeW5jLnByb3RvEhFydi5hbmFseXRpY3Muc3luYyLsAQoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 1) = "TG9jYWwSMAoJc3luY190eXBlGAEgASgOMh0ucnYuYW5hbHl0aWNzLnN5bmMu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 2) = "TG9jYWwuVHlwZRIXCg9pbmNsdWRlX2xpYnJhcnkYAiABKAgSFQoNaW5jbHVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 3) = "ZV9tZWRpYRgDIAEoCBIZChFpbmNsdWRlX3BsYXlsaXN0cxgEIAEoCBIWCg5p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 4) = "bmNsdWRlX3RoZW1lcxgFIAEoCBIdChVpbmNsdWRlX3N1cHBvcnRfZmlsZXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 5) = "BiABKAgSFQoNcmVwbGFjZV9maWxlcxgHIAEoCCIYCgRUeXBlEgYKAlVQEAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 6) = "CAoERE9XThABIn4KGVdlYlNvY2tldENvbm5lY3Rpb25GYWlsZWQSOQoGcmVh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 7) = "c29uGAEgASgOMikucnYuYW5hbHl0aWNzLnN5bmMuV2ViU29ja2V0RmFpbHVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 8) = "ZVJlYXNvbhILCgN1cmwYAiABKAkSGQoRZXJyb3JfZGVzY3JpcHRpb24YAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 9) = "KAkqaQoWV2ViU29ja2V0RmFpbHVyZVJlYXNvbhILCgdVTktOT1dOEAASEgoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 10) = "QVVUSEVOVElDQVRJT04QARILCgdUSU1FT1VUEAISDwoLTk9fSU5URVJORVQQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 11) = "AxIQCgxTRVJWRVJfRVJST1IQBEJL+AEBqgIzUHJvLlNlcmlhbGl6YXRpb25J";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 12) = "bnRlcm9wLlJWUHJvdG9EYXRhLkFuYWx5dGljcy5TeW5jugIPQW5hbHl0aWNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 13) = "X1N5bmNfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray14<string>, string>(in buffer, 14))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[1] { typeof(WebSocketFailureReason) }, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Local), Local.Parser, new string[7] { "SyncType", "IncludeLibrary", "IncludeMedia", "IncludePlaylists", "IncludeThemes", "IncludeSupportFiles", "ReplaceFiles" }, null, new Type[1] { typeof(Local.Types.Type) }, null, null),
			new GeneratedClrTypeInfo(typeof(WebSocketConnectionFailed), WebSocketConnectionFailed.Parser, new string[3] { "Reason", "Url", "ErrorDescription" }, null, null, null, null)
		}));
	}
}
