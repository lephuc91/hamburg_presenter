using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class BaseDocumentReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static BaseDocumentReflection()
	{
		_003C_003Ey__InlineArray25<string> buffer = default(_003C_003Ey__InlineArray25<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 0) = "ChJiYXNlRG9jdW1lbnQucHJvdG8SB3J2LmRhdGEaFWFwcGxpY2F0aW9uSW5m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 1) = "by5wcm90bxoTY3VzdG9tT3B0aW9ucy5wcm90bxoJdXJsLnByb3RvGgp1dWlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 2) = "LnByb3RvGg12ZXJzaW9uLnByb3RvGg93b3Jrc3BhY2UucHJvdG8ipAEKCERv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 3) = "Y3VtZW50EjgKEGFwcGxpY2F0aW9uX2luZm8YASABKAsyGC5ydi5kYXRhLkFw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 4) = "cGxpY2F0aW9uSW5mb0IEqIYZARIbCgR1dWlkGAIgASgLMg0ucnYuZGF0YS5V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 5) = "VUlEEhoKEnVzZXNfcmVsYXRpdmVfdXJscxgDIAEoCBIlCgl3b3Jrc3BhY2UY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 6) = "CiABKAsyEi5ydi5kYXRhLldvcmtzcGFjZSKOAQoJQ2FjaGVJbmZvEhsKBHV1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 7) = "aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSLQoTYXBwbGljYXRpb25fdmVyc2lv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 8) = "bhgCIAEoCzIQLnJ2LmRhdGEuVmVyc2lvbhIZCgN1cmwYAyABKAsyDC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 9) = "YXRhLlVSTBIaChJsYXN0X21vZGlmaWVkX2RhdGUYBCABKAEi3QQKEFBWUERv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 10) = "Y3VtZW50U3RhdGUSQQoQcHJpbWFyeV9wbGF5bGlzdBgBIAEoCzInLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 11) = "dGEuUFZQRG9jdW1lbnRTdGF0ZS5QbGF5bGlzdFN0YXRlEkMKEmFsdGVybmF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 12) = "ZV9wbGF5bGlzdBgCIAEoCzInLnJ2LmRhdGEuUFZQRG9jdW1lbnRTdGF0ZS5Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 13) = "bGF5bGlzdFN0YXRlEiIKGnBsYXlsaXN0X3NwbGl0X2lzX3ZlcnRpY2FsGAMg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 14) = "ASgIEiUKDnRhcmdldGVkX2xheWVyGAQgASgLMg0ucnYuZGF0YS5VVUlEEiUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 15) = "DnNlbGVjdGVkX2xheWVyGAUgASgLMg0ucnYuZGF0YS5VVUlEEiMKDGxvY2tl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 16) = "ZF9sYXllchgGIAEoCzINLnJ2LmRhdGEuVVVJRBIhChlsaXZlX3ZpZGVvX3Bs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 17) = "YXlsaXN0X3NjYWxlGAcgASgBEiMKG3NwbGl0X3ZpZXdfZGl2aWRlcl9wb3Np";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 18) = "dGlvbhgIIAEoARrhAQoNUGxheWxpc3RTdGF0ZRIbCgR1dWlkGAIgASgLMg0u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 19) = "cnYuZGF0YS5VVUlEEkIKBmxheW91dBgDIAEoDjIyLnJ2LmRhdGEuUFZQRG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 20) = "dW1lbnRTdGF0ZS5QbGF5bGlzdFN0YXRlLkxheW91dFR5cGUSEgoKaXRlbV9z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 21) = "Y2FsZRgEIAEoASJVCgpMYXlvdXRUeXBlEhMKD0xBWU9VVF9UWVBFX0NVRRAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 22) = "EhYKEkxBWU9VVF9UWVBFX0FDVElPThABEhoKFkxBWU9VVF9UWVBFX0xJVkVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 23) = "VklERU8QAkoECAEQAkI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 24) = "LlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray25<string>, string>(in buffer, 25))), new FileDescriptor[6]
		{
			ApplicationInfoReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor,
			VersionReflection.Descriptor,
			WorkspaceReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[3]
		{
			new GeneratedClrTypeInfo(typeof(Document), Document.Parser, new string[4] { "ApplicationInfo", "Uuid", "UsesRelativeUrls", "Workspace" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CacheInfo), CacheInfo.Parser, new string[4] { "Uuid", "ApplicationVersion", "Url", "LastModifiedDate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PVPDocumentState), PVPDocumentState.Parser, new string[8] { "PrimaryPlaylist", "AlternatePlaylist", "PlaylistSplitIsVertical", "TargetedLayer", "SelectedLayer", "LockedLayer", "LiveVideoPlaylistScale", "SplitViewDividerPosition" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(PVPDocumentState.Types.PlaylistState), PVPDocumentState.Types.PlaylistState.Parser, new string[3] { "Uuid", "Layout", "ItemScale" }, null, new Type[1] { typeof(PVPDocumentState.Types.PlaylistState.Types.LayoutType) }, null, null)
			})
		}));
	}
}
