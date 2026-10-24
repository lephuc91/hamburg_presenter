using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1PrerollReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1PrerollReflection()
	{
		_003C_003Ey__InlineArray44<string> buffer = default(_003C_003Ey__InlineArray44<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 0) = "ChVwcm9BcGlWMVByZXJvbGwucHJvdG8SB3J2LmRhdGEaGHByb0FwaVYxSWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 1) = "bnRpZmllci5wcm90byKLCwoWQVBJX3YxX1ByZXJvbGxfUmVxdWVzdBJBCgtw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 2) = "cmVyb2xsX2N1ZRgBIAEoCzIqLnJ2LmRhdGEuQVBJX3YxX1ByZXJvbGxfUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 3) = "dWVzdC5QcmVyb2xsQ3VlSAASVAoVcHJlcm9sbF9wbGF5bGlzdF9pdGVtGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 4) = "ASgLMjMucnYuZGF0YS5BUElfdjFfUHJlcm9sbF9SZXF1ZXN0LlByZXJvbGxQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 5) = "bGF5bGlzdEl0ZW1IABJOChJwcmVyb2xsX21lZGlhX2l0ZW0YAyABKAsyMC5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 6) = "di5kYXRhLkFQSV92MV9QcmVyb2xsX1JlcXVlc3QuUHJlcm9sbE1lZGlhSXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 7) = "bUgAEk4KEnByZXJvbGxfYXVkaW9faXRlbRgEIAEoCzIwLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 8) = "X3YxX1ByZXJvbGxfUmVxdWVzdC5QcmVyb2xsQXVkaW9JdGVtSAASUAoTcHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 9) = "cm9sbF92aWRlb19pbnB1dBgFIAEoCzIxLnJ2LmRhdGEuQVBJX3YxX1ByZXJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 10) = "bGxfUmVxdWVzdC5QcmVyb2xsVmlkZW9JbnB1dEgAElIKFHByZXJvbGxfbGli";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 11) = "cmFyeV9pdGVtGAYgASgLMjIucnYuZGF0YS5BUElfdjFfUHJlcm9sbF9SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 12) = "ZXN0LlByZXJvbGxMaWJyYXJ5SXRlbUgAEkMKDHByZXJvbGxfbmV4dBgHIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 13) = "CzIrLnJ2LmRhdGEuQVBJX3YxX1ByZXJvbGxfUmVxdWVzdC5QcmVyb2xsTmV4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 14) = "dEgAEksKEHByZXJvbGxfcHJldmlvdXMYCCABKAsyLy5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 15) = "MV9QcmVyb2xsX1JlcXVlc3QuUHJlcm9sbFByZXZpb3VzSAASVAoVYWN0aXZh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 16) = "dGVfcHJlcm9sbF9pdGVtGAkgASgLMjMucnYuZGF0YS5BUElfdjFfUHJlcm9s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 17) = "bF9SZXF1ZXN0LkFjdGl2YXRlUHJlcm9sbEl0ZW1IABJQChNjYW5jZWxfcHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 18) = "cm9sbF9pdGVtGAogASgLMjEucnYuZGF0YS5BUElfdjFfUHJlcm9sbF9SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 19) = "ZXN0LkNhbmNlbFByZXJvbGxJdGVtSAAaLwoKUHJlcm9sbEN1ZRINCgVpbmRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 20) = "eBgBIAEoBRISCgpwcmVyb2xsX2lkGAIgASgEGlMKE1ByZXJvbGxQbGF5bGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 21) = "dEl0ZW0SKAoEcGF0aBgBIAMoCzIaLnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 22) = "ZXISEgoKcHJlcm9sbF9pZBgCIAEoBBpQChBQcmVyb2xsTWVkaWFJdGVtEigK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 23) = "BHBhdGgYASADKAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyEhIKCnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 24) = "ZXJvbGxfaWQYAiABKAQaUAoQUHJlcm9sbEF1ZGlvSXRlbRIoCgRwYXRoGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 25) = "AygLMhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmllchISCgpwcmVyb2xsX2lk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 26) = "GAIgASgEGjMKEVByZXJvbGxWaWRlb0lucHV0EgoKAmlkGAEgASgJEhIKCnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 27) = "ZXJvbGxfaWQYAiABKAQaUgoSUHJlcm9sbExpYnJhcnlJdGVtEigKBHBhdGgY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 28) = "ASADKAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyEhIKCnByZXJvbGxf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 29) = "aWQYAiABKAQaIQoLUHJlcm9sbE5leHQSEgoKcHJlcm9sbF9pZBgBIAEoBBol";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 30) = "Cg9QcmVyb2xsUHJldmlvdXMSEgoKcHJlcm9sbF9pZBgBIAEoBBovChNBY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 31) = "dmF0ZVByZXJvbGxJdGVtEgoKAmlkGAEgASgEEgwKBHRpbWUYAiABKAQaHwoR";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 32) = "Q2FuY2VsUHJlcm9sbEl0ZW0SCgoCaWQYASABKARCCQoHUmVxdWVzdCKgAwoX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 33) = "QVBJX3YxX1ByZXJvbGxfUmVzcG9uc2USRgoNcHJlcm9sbF9yZWFkeRgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 34) = "CzItLnJ2LmRhdGEuQVBJX3YxX1ByZXJvbGxfUmVzcG9uc2UuUHJlcm9sbFJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 35) = "YWR5SAASVQoVYWN0aXZhdGVfcHJlcm9sbF9pdGVtGAMgASgLMjQucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 36) = "YS5BUElfdjFfUHJlcm9sbF9SZXNwb25zZS5BY3RpdmF0ZVByZXJvbGxJdGVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 37) = "SAASUQoTY2FuY2VsX3ByZXJvbGxfaXRlbRgEIAEoCzIyLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 38) = "X3YxX1ByZXJvbGxfUmVzcG9uc2UuQ2FuY2VsUHJlcm9sbEl0ZW1IABo5CgxQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 39) = "cmVyb2xsUmVhZHkSCgoCaWQYASABKAQSDwoHbGF0ZW5jeRgCIAEoBBIMCgR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 40) = "aW1lGAMgASgEGiYKE0FjdGl2YXRlUHJlcm9sbEl0ZW0SDwoHc3VjY2VzcxgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 41) = "IAEoCBokChFDYW5jZWxQcmVyb2xsSXRlbRIPCgdzdWNjZXNzGAEgASgIQgoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 42) = "CFJlc3BvbnNlQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray44<string>, string>(ref buffer, 43) = "cm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray44<string>, string>(in buffer, 44))), new FileDescriptor[1] { ProApiV1IdentifierReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request), API_v1_Preroll_Request.Parser, new string[10] { "PrerollCue", "PrerollPlaylistItem", "PrerollMediaItem", "PrerollAudioItem", "PrerollVideoInput", "PrerollLibraryItem", "PrerollNext", "PrerollPrevious", "ActivatePrerollItem", "CancelPrerollItem" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[10]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.PrerollCue), API_v1_Preroll_Request.Types.PrerollCue.Parser, new string[2] { "Index", "PrerollId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.PrerollPlaylistItem), API_v1_Preroll_Request.Types.PrerollPlaylistItem.Parser, new string[2] { "Path", "PrerollId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.PrerollMediaItem), API_v1_Preroll_Request.Types.PrerollMediaItem.Parser, new string[2] { "Path", "PrerollId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.PrerollAudioItem), API_v1_Preroll_Request.Types.PrerollAudioItem.Parser, new string[2] { "Path", "PrerollId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.PrerollVideoInput), API_v1_Preroll_Request.Types.PrerollVideoInput.Parser, new string[2] { "Id", "PrerollId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.PrerollLibraryItem), API_v1_Preroll_Request.Types.PrerollLibraryItem.Parser, new string[2] { "Path", "PrerollId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.PrerollNext), API_v1_Preroll_Request.Types.PrerollNext.Parser, new string[1] { "PrerollId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.PrerollPrevious), API_v1_Preroll_Request.Types.PrerollPrevious.Parser, new string[1] { "PrerollId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.ActivatePrerollItem), API_v1_Preroll_Request.Types.ActivatePrerollItem.Parser, new string[2] { "Id", "Time" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Request.Types.CancelPrerollItem), API_v1_Preroll_Request.Types.CancelPrerollItem.Parser, new string[1] { "Id" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Response), API_v1_Preroll_Response.Parser, new string[3] { "PrerollReady", "ActivatePrerollItem", "CancelPrerollItem" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Response.Types.PrerollReady), API_v1_Preroll_Response.Types.PrerollReady.Parser, new string[3] { "Id", "Latency", "Time" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Response.Types.ActivatePrerollItem), API_v1_Preroll_Response.Types.ActivatePrerollItem.Parser, new string[1] { "Success" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Preroll_Response.Types.CancelPrerollItem), API_v1_Preroll_Response.Types.CancelPrerollItem.Parser, new string[1] { "Success" }, null, null, null, null)
			})
		}));
	}
}
