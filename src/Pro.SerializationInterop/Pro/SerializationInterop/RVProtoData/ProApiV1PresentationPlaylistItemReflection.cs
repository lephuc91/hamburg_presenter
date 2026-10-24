using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1PresentationPlaylistItemReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1PresentationPlaylistItemReflection()
	{
		_003C_003Ey__InlineArray5<string> buffer = default(_003C_003Ey__InlineArray5<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 0) = "CiZwcm9BcGlWMVByZXNlbnRhdGlvblBsYXlsaXN0SXRlbS5wcm90bxIHcnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 1) = "ZGF0YSJwCh9BUElfdjFfUGxheWxpc3RQcmVzZW50YXRpb25JdGVtEhkKEXBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 2) = "ZXNlbnRhdGlvbl91dWlkGAEgASgJEhgKEGFycmFuZ2VtZW50X25hbWUYAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 3) = "KAkSGAoQYXJyYW5nZW1lbnRfdXVpZBgDIAEoCUI0+AEBqgIkUHJvLlNlcmlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 4) = "bGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<string>, string>(in buffer, 5))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_PlaylistPresentationItem), API_v1_PlaylistPresentationItem.Parser, new string[3] { "PresentationUuid", "ArrangementName", "ArrangementUuid" }, null, null, null, null)
		}));
	}
}
