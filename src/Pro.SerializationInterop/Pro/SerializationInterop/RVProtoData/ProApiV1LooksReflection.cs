using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1LooksReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1LooksReflection()
	{
		_003C_003Ey__InlineArray47<string> buffer = default(_003C_003Ey__InlineArray47<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 0) = "ChNwcm9BcGlWMUxvb2tzLnByb3RvEgdydi5kYXRhGhhwcm9BcGlWMUlkZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 1) = "aWZpZXIucHJvdG8iXgoLQVBJX3YxX0xvb2sSJgoCaWQYASABKAsyGi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 2) = "YXRhLkFQSV92MV9JZGVudGlmaWVyEicKB3NjcmVlbnMYAiADKAsyFi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 3) = "YXRhLkFQSV92MV9TY3JlZW4ingEKDUFQSV92MV9TY3JlZW4SEwoLdmlkZW9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 4) = "aW5wdXQYASABKAgSDQoFbWVkaWEYAiABKAgSDQoFc2xpZGUYAyABKAgSFQoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 5) = "YW5ub3VuY2VtZW50cxgEIAEoCBINCgVwcm9wcxgFIAEoCBIQCghtZXNzYWdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 6) = "cxgGIAEoCBIUCgxwcmVzZW50YXRpb24YByABKAkSDAoEbWFzaxgIIAEoCSKw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 7) = "BgoUQVBJX3YxX0xvb2tzX1JlcXVlc3QSNAoFbG9va3MYASABKAsyIy5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 8) = "YXRhLkFQSV92MV9Mb29rc19SZXF1ZXN0Lkxvb2tzSAASPwoLY3JlYXRlX2xv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 9) = "b2sYAiABKAsyKC5ydi5kYXRhLkFQSV92MV9Mb29rc19SZXF1ZXN0LkNyZWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 10) = "ZUxvb2tIABJIChBnZXRfY3VycmVudF9sb29rGAMgASgLMiwucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 11) = "UElfdjFfTG9va3NfUmVxdWVzdC5HZXRDdXJyZW50TG9va0gAEkgKEHB1dF9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 12) = "dXJyZW50X2xvb2sYBCABKAsyLC5ydi5kYXRhLkFQSV92MV9Mb29rc19SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 13) = "ZXN0LlB1dEN1cnJlbnRMb29rSAASOQoIZ2V0X2xvb2sYBSABKAsyJS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 14) = "YXRhLkFQSV92MV9Mb29rc19SZXF1ZXN0LkdldExvb2tIABI5CghwdXRfbG9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 15) = "axgGIAEoCzIlLnJ2LmRhdGEuQVBJX3YxX0xvb2tzX1JlcXVlc3QuUHV0TG9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 16) = "a0gAEj8KC2RlbGV0ZV9sb29rGAcgASgLMigucnYuZGF0YS5BUElfdjFfTG9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 17) = "a3NfUmVxdWVzdC5EZWxldGVMb29rSAASQQoMdHJpZ2dlcl9sb29rGAggASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 18) = "MikucnYuZGF0YS5BUElfdjFfTG9va3NfUmVxdWVzdC5UcmlnZ2VyTG9va0gA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 19) = "GgcKBUxvb2tzGjAKCkNyZWF0ZUxvb2sSIgoEbG9vaxgBIAEoCzIULnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 20) = "dGEuQVBJX3YxX0xvb2saEAoOR2V0Q3VycmVudExvb2saNAoOUHV0Q3VycmVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 21) = "dExvb2sSIgoEbG9vaxgBIAEoCzIULnJ2LmRhdGEuQVBJX3YxX0xvb2saFQoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 22) = "R2V0TG9vaxIKCgJpZBgBIAEoCRo5CgdQdXRMb29rEgoKAmlkGAEgASgJEiIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 23) = "BGxvb2sYAiABKAsyFC5ydi5kYXRhLkFQSV92MV9Mb29rGhgKCkRlbGV0ZUxv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 24) = "b2sSCgoCaWQYASABKAkaGQoLVHJpZ2dlckxvb2sSCgoCaWQYASABKAlCCQoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 25) = "UmVxdWVzdCL3BgoVQVBJX3YxX0xvb2tzX1Jlc3BvbnNlEjUKBWxvb2tzGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 26) = "ASgLMiQucnYuZGF0YS5BUElfdjFfTG9va3NfUmVzcG9uc2UuTG9va3NIABJA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 27) = "CgtjcmVhdGVfbG9vaxgCIAEoCzIpLnJ2LmRhdGEuQVBJX3YxX0xvb2tzX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 28) = "c3BvbnNlLkNyZWF0ZUxvb2tIABJJChBnZXRfY3VycmVudF9sb29rGAMgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 29) = "Mi0ucnYuZGF0YS5BUElfdjFfTG9va3NfUmVzcG9uc2UuR2V0Q3VycmVudExv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 30) = "b2tIABJJChBwdXRfY3VycmVudF9sb29rGAQgASgLMi0ucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 31) = "djFfTG9va3NfUmVzcG9uc2UuUHV0Q3VycmVudExvb2tIABI6CghnZXRfbG9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 32) = "axgFIAEoCzImLnJ2LmRhdGEuQVBJX3YxX0xvb2tzX1Jlc3BvbnNlLkdldExv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 33) = "b2tIABI6CghwdXRfbG9vaxgGIAEoCzImLnJ2LmRhdGEuQVBJX3YxX0xvb2tz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 34) = "X1Jlc3BvbnNlLlB1dExvb2tIABJACgtkZWxldGVfbG9vaxgHIAEoCzIpLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 35) = "LmRhdGEuQVBJX3YxX0xvb2tzX1Jlc3BvbnNlLkRlbGV0ZUxvb2tIABJCCgx0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 36) = "cmlnZ2VyX2xvb2sYCCABKAsyKi5ydi5kYXRhLkFQSV92MV9Mb29rc19SZXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 37) = "b25zZS5UcmlnZ2VyTG9va0gAGiwKBUxvb2tzEiMKBWxvb2tzGAEgAygLMhQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 38) = "cnYuZGF0YS5BUElfdjFfTG9vaxowCgpDcmVhdGVMb29rEiIKBGxvb2sYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 39) = "KAsyFC5ydi5kYXRhLkFQSV92MV9Mb29rGjQKDkdldEN1cnJlbnRMb29rEiIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 40) = "BGxvb2sYASABKAsyFC5ydi5kYXRhLkFQSV92MV9Mb29rGjQKDlB1dEN1cnJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 41) = "bnRMb29rEiIKBGxvb2sYASABKAsyFC5ydi5kYXRhLkFQSV92MV9Mb29rGi0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 42) = "B0dldExvb2sSIgoEbG9vaxgBIAEoCzIULnJ2LmRhdGEuQVBJX3YxX0xvb2sa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 43) = "LQoHUHV0TG9vaxIiCgRsb29rGAEgASgLMhQucnYuZGF0YS5BUElfdjFfTG9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 44) = "axoMCgpEZWxldGVMb29rGg0KC1RyaWdnZXJMb29rQgoKCFJlc3BvbnNlQjT4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 45) = "AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 46) = "VkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray47<string>, string>(in buffer, 47))), new FileDescriptor[1] { ProApiV1IdentifierReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Look), API_v1_Look.Parser, new string[2] { "Id", "Screens" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Screen), API_v1_Screen.Parser, new string[8] { "VideoInput", "Media", "Slide", "Announcements", "Props", "Messages", "Presentation", "Mask" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request), API_v1_Looks_Request.Parser, new string[8] { "Looks", "CreateLook", "GetCurrentLook", "PutCurrentLook", "GetLook", "PutLook", "DeleteLook", "TriggerLook" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[8]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request.Types.Looks), API_v1_Looks_Request.Types.Looks.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request.Types.CreateLook), API_v1_Looks_Request.Types.CreateLook.Parser, new string[1] { "Look" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request.Types.GetCurrentLook), API_v1_Looks_Request.Types.GetCurrentLook.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request.Types.PutCurrentLook), API_v1_Looks_Request.Types.PutCurrentLook.Parser, new string[1] { "Look" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request.Types.GetLook), API_v1_Looks_Request.Types.GetLook.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request.Types.PutLook), API_v1_Looks_Request.Types.PutLook.Parser, new string[2] { "Id", "Look" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request.Types.DeleteLook), API_v1_Looks_Request.Types.DeleteLook.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Request.Types.TriggerLook), API_v1_Looks_Request.Types.TriggerLook.Parser, new string[1] { "Id" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response), API_v1_Looks_Response.Parser, new string[8] { "Looks", "CreateLook", "GetCurrentLook", "PutCurrentLook", "GetLook", "PutLook", "DeleteLook", "TriggerLook" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[8]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response.Types.Looks), API_v1_Looks_Response.Types.Looks.Parser, new string[1] { "Looks_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response.Types.CreateLook), API_v1_Looks_Response.Types.CreateLook.Parser, new string[1] { "Look" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response.Types.GetCurrentLook), API_v1_Looks_Response.Types.GetCurrentLook.Parser, new string[1] { "Look" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response.Types.PutCurrentLook), API_v1_Looks_Response.Types.PutCurrentLook.Parser, new string[1] { "Look" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response.Types.GetLook), API_v1_Looks_Response.Types.GetLook.Parser, new string[1] { "Look" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response.Types.PutLook), API_v1_Looks_Response.Types.PutLook.Parser, new string[1] { "Look" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response.Types.DeleteLook), API_v1_Looks_Response.Types.DeleteLook.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Looks_Response.Types.TriggerLook), API_v1_Looks_Response.Types.TriggerLook.Parser, null, null, null, null, null)
			})
		}));
	}
}
