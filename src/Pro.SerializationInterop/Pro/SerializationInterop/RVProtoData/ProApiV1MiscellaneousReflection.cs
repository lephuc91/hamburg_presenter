using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1MiscellaneousReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1MiscellaneousReflection()
	{
		_003C_003Ey__InlineArray9<string> buffer = default(_003C_003Ey__InlineArray9<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 0) = "Chtwcm9BcGlWMU1pc2NlbGxhbmVvdXMucHJvdG8SB3J2LmRhdGEihAEKHEFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 1) = "SV92MV9NaXNjZWxsYW5lb3VzX1JlcXVlc3QSSgoNZmluZF9teV9tb3VzZRgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 2) = "IAEoCzIxLnJ2LmRhdGEuQVBJX3YxX01pc2NlbGxhbmVvdXNfUmVxdWVzdC5G";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 3) = "aW5kTXlNb3VzZUgAGg0KC0ZpbmRNeU1vdXNlQgkKB1JlcXVlc3QihwEKHUFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 4) = "SV92MV9NaXNjZWxsYW5lb3VzX1Jlc3BvbnNlEksKDWZpbmRfbXlfbW91c2UY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 5) = "ASABKAsyMi5ydi5kYXRhLkFQSV92MV9NaXNjZWxsYW5lb3VzX1Jlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 6) = "LkZpbmRNeU1vdXNlSAAaDQoLRmluZE15TW91c2VCCgoIUmVzcG9uc2VCNPgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 7) = "AaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 8) = "RGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<string>, string>(in buffer, 9))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Miscellaneous_Request), API_v1_Miscellaneous_Request.Parser, new string[1] { "FindMyMouse" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Miscellaneous_Request.Types.FindMyMouse), API_v1_Miscellaneous_Request.Types.FindMyMouse.Parser, null, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Miscellaneous_Response), API_v1_Miscellaneous_Response.Parser, new string[1] { "FindMyMouse" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Miscellaneous_Response.Types.FindMyMouse), API_v1_Miscellaneous_Response.Types.FindMyMouse.Parser, null, null, null, null, null)
			})
		}));
	}
}
