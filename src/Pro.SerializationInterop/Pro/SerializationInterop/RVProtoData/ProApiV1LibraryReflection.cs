using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1LibraryReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1LibraryReflection()
	{
		_003C_003Ey__InlineArray21<string> buffer = default(_003C_003Ey__InlineArray21<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 0) = "ChVwcm9BcGlWMUxpYnJhcnkucHJvdG8SB3J2LmRhdGEaGHByb0FwaVYxSWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 1) = "bnRpZmllci5wcm90byLGAgoWQVBJX3YxX0xpYnJhcnlfUmVxdWVzdBI+Cgls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 2) = "aWJyYXJpZXMYASABKAsyKS5ydi5kYXRhLkFQSV92MV9MaWJyYXJ5X1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 3) = "c3QuTGlicmFyaWVzSAASOgoHbGlicmFyeRgCIAEoCzInLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 4) = "X3YxX0xpYnJhcnlfUmVxdWVzdC5MaWJyYXJ5SAASOgoHdHJpZ2dlchgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 5) = "CzInLnJ2LmRhdGEuQVBJX3YxX0xpYnJhcnlfUmVxdWVzdC5UcmlnZ2VySAAa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 6) = "CwoJTGlicmFyaWVzGhUKB0xpYnJhcnkSCgoCaWQYASABKAkaRQoHVHJpZ2dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 7) = "chISCgpsaWJyYXJ5X2lkGAEgASgJEhcKD3ByZXNlbnRhdGlvbl9pZBgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 8) = "CRINCgVpbmRleBgDIAEoDUIJCgdSZXF1ZXN0ItUDChdBUElfdjFfTGlicmFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 9) = "eV9SZXNwb25zZRI/CglsaWJyYXJpZXMYASABKAsyKi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 10) = "MV9MaWJyYXJ5X1Jlc3BvbnNlLkxpYnJhcmllc0gAEjsKB2xpYnJhcnkYAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 11) = "KAsyKC5ydi5kYXRhLkFQSV92MV9MaWJyYXJ5X1Jlc3BvbnNlLkxpYnJhcnlI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 12) = "ABI8Cgh0cmlnZ2dlchgDIAEoCzIoLnJ2LmRhdGEuQVBJX3YxX0xpYnJhcnlf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 13) = "UmVzcG9uc2UuVHJpZ2dlckgAGjoKCUxpYnJhcmllcxItCglsaWJyYXJpZXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 14) = "ASADKAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyGqoBCgdMaWJyYXJ5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 15) = "EkgKC3VwZGF0ZV90eXBlGAEgASgOMjMucnYuZGF0YS5BUElfdjFfTGlicmFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 16) = "eV9SZXNwb25zZS5MaWJyYXJ5LlVwZGF0ZVR5cGUSKQoFaXRlbXMYAiADKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 17) = "Gi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyIioKClVwZGF0ZVR5cGUSBwoD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 18) = "YWxsEAASBwoDYWRkEAESCgoGcmVtb3ZlEAIaCQoHVHJpZ2dlckIKCghSZXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 19) = "b25zZUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 20) = "YXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray21<string>, string>(in buffer, 21))), new FileDescriptor[1] { ProApiV1IdentifierReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Library_Request), API_v1_Library_Request.Parser, new string[3] { "Libraries", "Library", "Trigger" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Library_Request.Types.Libraries), API_v1_Library_Request.Types.Libraries.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Library_Request.Types.Library), API_v1_Library_Request.Types.Library.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Library_Request.Types.Trigger), API_v1_Library_Request.Types.Trigger.Parser, new string[3] { "LibraryId", "PresentationId", "Index" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Library_Response), API_v1_Library_Response.Parser, new string[3] { "Libraries", "Library", "Triggger" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Library_Response.Types.Libraries), API_v1_Library_Response.Types.Libraries.Parser, new string[1] { "Libraries_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Library_Response.Types.Library), API_v1_Library_Response.Types.Library.Parser, new string[2] { "UpdateType", "Items" }, null, new Type[1] { typeof(API_v1_Library_Response.Types.Library.Types.UpdateType) }, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Library_Response.Types.Trigger), API_v1_Library_Response.Types.Trigger.Parser, null, null, null, null, null)
			})
		}));
	}
}
