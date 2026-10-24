using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProAudienceLookReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProAudienceLookReflection()
	{
		_003C_003Ey__InlineArray19<string> buffer = default(_003C_003Ey__InlineArray19<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 0) = "ChVwcm9BdWRpZW5jZUxvb2sucHJvdG8SB3J2LmRhdGEaE2N1c3RvbU9wdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 1) = "bnMucHJvdG8aCXVybC5wcm90bxoKdXVpZC5wcm90byKABQoPUHJvQXVkaWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 2) = "Y2VMb29rEhsKBHV1aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSEgoEbmFtZRgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 3) = "IAEoCUIEoIYZARI8CgxzY3JlZW5fbG9va3MYAyADKAsyJi5ydi5kYXRhLlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 4) = "b0F1ZGllbmNlTG9vay5Qcm9TY3JlZW5Mb29rEi8KEm9yaWdpbmFsX2xvb2tf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 5) = "dXVpZBgEIAEoCzINLnJ2LmRhdGEuVVVJREIEoIYZARIbChN0cmFuc2l0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 6) = "X2R1cmF0aW9uGAUgASgBGq8DCg1Qcm9TY3JlZW5Mb29rEiYKD3Byb19zY3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 7) = "ZW5fdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBIZCg1wcm9wc19lbmFibGVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 8) = "GAIgASgIQgIYARIaChJsaXZlX3ZpZGVvX2VuYWJsZWQYAyABKAgSJwofcHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 9) = "c2VudGF0aW9uX2JhY2tncm91bmRfZW5hYmxlZBgEIAEoCBI3Cht0ZW1wbGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 10) = "ZV9kb2N1bWVudF9maWxlX3BhdGgYBSABKAsyDC5ydi5kYXRhLlVSTEIEoIYZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 11) = "ARIwChN0ZW1wbGF0ZV9zbGlkZV91dWlkGAYgASgLMg0ucnYuZGF0YS5VVUlE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 12) = "QgSghhkBEicKH3ByZXNlbnRhdGlvbl9mb3JlZ3JvdW5kX2VuYWJsZWQYByAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 13) = "KAgSJgoJbWFza191dWlkGAggASgLMg0ucnYuZGF0YS5VVUlEQgSghhkBEh0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 14) = "FWFubm91bmNlbWVudHNfZW5hYmxlZBgJIAEoCBIbChNwcm9wc19sYXllcl9l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 15) = "bmFibGVkGAogASgIEh4KFm1lc3NhZ2VzX2xheWVyX2VuYWJsZWQYCyABKAgi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 16) = "RgoWQXVkaWVuY2VMb29rQ29sbGVjdGlvbhIsCgpjb2xsZWN0aW9uGAEgAygL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 17) = "MhgucnYuZGF0YS5Qcm9BdWRpZW5jZUxvb2tCNPgBAaoCJFByby5TZXJpYWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 18) = "emF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray19<string>, string>(in buffer, 19))), new FileDescriptor[3]
		{
			CustomOptionsReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(ProAudienceLook), ProAudienceLook.Parser, new string[5] { "Uuid", "Name", "ScreenLooks", "OriginalLookUuid", "TransitionDuration" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(ProAudienceLook.Types.ProScreenLook), ProAudienceLook.Types.ProScreenLook.Parser, new string[11]
				{
					"ProScreenUuid", "PropsEnabled", "LiveVideoEnabled", "PresentationBackgroundEnabled", "TemplateDocumentFilePath", "TemplateSlideUuid", "PresentationForegroundEnabled", "MaskUuid", "AnnouncementsEnabled", "PropsLayerEnabled",
					"MessagesLayerEnabled"
				}, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(AudienceLookCollection), AudienceLookCollection.Parser, new string[1] { "Collection" }, null, null, null, null)
		}));
	}
}
