using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1MessageReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1MessageReflection()
	{
		_003C_003Ey__InlineArray69<string> buffer = default(_003C_003Ey__InlineArray69<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 0) = "ChVwcm9BcGlWMU1lc3NhZ2UucHJvdG8SB3J2LmRhdGEaGHByb0FwaVYxSWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 1) = "bnRpZmllci5wcm90bxoTcHJvQXBpVjFUaW1lci5wcm90byLjCQoOQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 2) = "X01lc3NhZ2USJgoCaWQYASABKAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 3) = "aWVyEg8KB21lc3NhZ2UYAiABKAkSOwoGdG9rZW5zGAMgAygLMisucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 4) = "YS5BUElfdjFfTWVzc2FnZS5BUElfdjFfTWVzc2FnZVRva2VuEikKBXRoZW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 5) = "GAQgASgLMhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmllchIaChJ2aXNpYmxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 6) = "X29uX25ldHdvcmsYBSABKAgSEQoJaXNfYWN0aXZlGAYgASgIGoAIChNBUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 7) = "djFfTWVzc2FnZVRva2VuEgwKBHV1aWQYASABKAkSDAoEbmFtZRgCIAEoCRJM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 8) = "CgR0ZXh0GAMgASgLMjwucnYuZGF0YS5BUElfdjFfTWVzc2FnZS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 9) = "TWVzc2FnZVRva2VuLkFQSV92MV9UZXh0VG9rZW5IABJOCgV0aW1lchgEIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 10) = "CzI9LnJ2LmRhdGEuQVBJX3YxX01lc3NhZ2UuQVBJX3YxX01lc3NhZ2VUb2tl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 11) = "bi5BUElfdjFfVGltZXJUb2tlbkgAEk4KBWNsb2NrGAUgASgLMj0ucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 12) = "YS5BUElfdjFfTWVzc2FnZS5BUElfdjFfTWVzc2FnZVRva2VuLkFQSV92MV9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 13) = "bG9ja1Rva2VuSAAaIAoQQVBJX3YxX1RleHRUb2tlbhIMCgR0ZXh0GAEgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 14) = "GuoCChFBUElfdjFfVGltZXJUb2tlbhImCgJpZBgBIAEoCzIaLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 15) = "QVBJX3YxX0lkZW50aWZpZXISFgoOYWxsb3dzX292ZXJydW4YAiABKAgSQQoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 16) = "Y291bnRkb3duGAMgASgLMiwucnYuZGF0YS5BUElfdjFfVGltZXIuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 17) = "X1RpbWVyX0NvdW50ZG93bkgAElAKEmNvdW50X2Rvd25fdG9fdGltZRgEIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 18) = "CzIyLnJ2LmRhdGEuQVBJX3YxX1RpbWVyLkFQSV92MV9UaW1lcl9Db3VudGRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 19) = "d25Ub1RpbWVIABI9CgdlbGFwc2VkGAUgASgLMioucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 20) = "VGltZXIuQVBJX3YxX1RpbWVyX0VsYXBzZWRIABIrCgZmb3JtYXQYBiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 21) = "Gy5ydi5kYXRhLkFQSV92MV9UaW1lckZvcm1hdEIUChJUaW1lckNvbmZpZ3Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 22) = "YXRpb24awgIKEUFQSV92MV9DbG9ja1Rva2VuEmMKBGRhdGUYASABKA4yVS5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 23) = "di5kYXRhLkFQSV92MV9NZXNzYWdlLkFQSV92MV9NZXNzYWdlVG9rZW4uQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 24) = "X3YxX0Nsb2NrVG9rZW4uQVBJX3YxX0Nsb2NrVG9rZW5Gb3JtYXQSYwoEdGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 25) = "ZRgCIAEoDjJVLnJ2LmRhdGEuQVBJX3YxX01lc3NhZ2UuQVBJX3YxX01lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 26) = "Z2VUb2tlbi5BUElfdjFfQ2xvY2tUb2tlbi5BUElfdjFfQ2xvY2tUb2tlbkZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 27) = "cm1hdBITCgtpc18yNF9ob3VycxgDIAEoCCJOChdBUElfdjFfQ2xvY2tUb2tl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 28) = "bkZvcm1hdBIICgRub25lEAASCQoFc2hvcnQQARIKCgZtZWRpdW0QAhIICgRs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 29) = "b25nEAMSCAoEZnVsbBAEQgsKCVRva2VuVHlwZSLjBgoWQVBJX3YxX01lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 30) = "Z2VfUmVxdWVzdBI8CghtZXNzYWdlcxgBIAEoCzIoLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 31) = "X01lc3NhZ2VfUmVxdWVzdC5NZXNzYWdlc0gAEkcKDmNyZWF0ZV9tZXNzYWdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 32) = "GAIgASgLMi0ucnYuZGF0YS5BUElfdjFfTWVzc2FnZV9SZXF1ZXN0LkNyZWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 33) = "ZU1lc3NhZ2VIABJBCgtnZXRfbWVzc2FnZRgDIAEoCzIqLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 34) = "X3YxX01lc3NhZ2VfUmVxdWVzdC5HZXRNZXNzYWdlSAASQQoLcHV0X21lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 35) = "Z2UYBCABKAsyKi5ydi5kYXRhLkFQSV92MV9NZXNzYWdlX1JlcXVlc3QuUHV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 36) = "TWVzc2FnZUgAEkcKDmRlbGV0ZV9tZXNzYWdlGAUgASgLMi0ucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 37) = "UElfdjFfTWVzc2FnZV9SZXF1ZXN0LkRlbGV0ZU1lc3NhZ2VIABJJCg90cmln";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 38) = "Z2VyX21lc3NhZ2UYBiABKAsyLi5ydi5kYXRhLkFQSV92MV9NZXNzYWdlX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 39) = "cXVlc3QuVHJpZ2dlck1lc3NhZ2VIABJFCg1jbGVhcl9tZXNzYWdlGAcgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 40) = "MiwucnYuZGF0YS5BUElfdjFfTWVzc2FnZV9SZXF1ZXN0LkNsZWFyTWVzc2Fn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 41) = "ZUgAGgoKCE1lc3NhZ2VzGjkKDUNyZWF0ZU1lc3NhZ2USKAoHbWVzc2FnZRgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 42) = "IAEoCzIXLnJ2LmRhdGEuQVBJX3YxX01lc3NhZ2UaGAoKR2V0TWVzc2FnZRIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 43) = "CgJpZBgBIAEoCRpCCgpQdXRNZXNzYWdlEgoKAmlkGAEgASgJEigKB21lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 44) = "Z2UYAiABKAsyFy5ydi5kYXRhLkFQSV92MV9NZXNzYWdlGhsKDURlbGV0ZU1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 45) = "c3NhZ2USCgoCaWQYASABKAkaeAoOVHJpZ2dlck1lc3NhZ2USCgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 46) = "KAkSOwoGdG9rZW5zGAIgAygLMisucnYuZGF0YS5BUElfdjFfTWVzc2FnZS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 47) = "UElfdjFfTWVzc2FnZVRva2VuEh0KFXJlcXVpcmVzX2NvbmZpcm1hdGlvbhgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 48) = "IAEoCBoaCgxDbGVhck1lc3NhZ2USCgoCaWQYASABKAlCCQoHUmVxdWVzdCKp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 49) = "BgoXQVBJX3YxX01lc3NhZ2VfUmVzcG9uc2USPQoIbWVzc2FnZXMYASABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 50) = "KS5ydi5kYXRhLkFQSV92MV9NZXNzYWdlX1Jlc3BvbnNlLk1lc3NhZ2VzSAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 51) = "SAoOY3JlYXRlX21lc3NhZ2UYAiABKAsyLi5ydi5kYXRhLkFQSV92MV9NZXNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 52) = "YWdlX1Jlc3BvbnNlLkNyZWF0ZU1lc3NhZ2VIABJCCgtnZXRfbWVzc2FnZRgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 53) = "IAEoCzIrLnJ2LmRhdGEuQVBJX3YxX01lc3NhZ2VfUmVzcG9uc2UuR2V0TWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 54) = "c2FnZUgAEkIKC3B1dF9tZXNzYWdlGAQgASgLMisucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 55) = "TWVzc2FnZV9SZXNwb25zZS5QdXRNZXNzYWdlSAASSAoOZGVsZXRlX21lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 56) = "Z2UYBSABKAsyLi5ydi5kYXRhLkFQSV92MV9NZXNzYWdlX1Jlc3BvbnNlLkRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 57) = "bGV0ZU1lc3NhZ2VIABJKCg90cmlnZ2VyX21lc3NhZ2UYBiABKAsyLy5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 58) = "YXRhLkFQSV92MV9NZXNzYWdlX1Jlc3BvbnNlLlRyaWdnZXJNZXNzYWdlSAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 59) = "RgoNY2xlYXJfbWVzc2FnZRgHIAEoCzItLnJ2LmRhdGEuQVBJX3YxX01lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 60) = "Z2VfUmVzcG9uc2UuQ2xlYXJNZXNzYWdlSAAaNQoITWVzc2FnZXMSKQoIbWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 61) = "c2FnZXMYASADKAsyFy5ydi5kYXRhLkFQSV92MV9NZXNzYWdlGjkKDUNyZWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 62) = "ZU1lc3NhZ2USKAoHbWVzc2FnZRgBIAEoCzIXLnJ2LmRhdGEuQVBJX3YxX01l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 63) = "c3NhZ2UaNgoKR2V0TWVzc2FnZRIoCgdtZXNzYWdlGAEgASgLMhcucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 64) = "YS5BUElfdjFfTWVzc2FnZRo2CgpQdXRNZXNzYWdlEigKB21lc3NhZ2UYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 65) = "KAsyFy5ydi5kYXRhLkFQSV92MV9NZXNzYWdlGg8KDURlbGV0ZU1lc3NhZ2Ua";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 66) = "EAoOVHJpZ2dlck1lc3NhZ2UaDgoMQ2xlYXJNZXNzYWdlQgoKCFJlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 67) = "QjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray69<string>, string>(ref buffer, 68) = "AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray69<string>, string>(in buffer, 69))), new FileDescriptor[2]
		{
			ProApiV1IdentifierReflection.Descriptor,
			ProApiV1TimerReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[3]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Message), API_v1_Message.Parser, new string[6] { "Id", "Message", "Tokens", "Theme", "VisibleOnNetwork", "IsActive" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Message.Types.API_v1_MessageToken), API_v1_Message.Types.API_v1_MessageToken.Parser, new string[5] { "Uuid", "Name", "Text", "Timer", "Clock" }, new string[1] { "TokenType" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TextToken), API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TextToken.Parser, new string[1] { "Text" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TimerToken), API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TimerToken.Parser, new string[6] { "Id", "AllowsOverrun", "Countdown", "CountDownToTime", "Elapsed", "Format" }, new string[1] { "TimerConfiguration" }, null, null, null),
					new GeneratedClrTypeInfo(typeof(API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken), API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Parser, new string[3] { "Date", "Time", "Is24Hours" }, null, new Type[1] { typeof(API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat) }, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Message_Request), API_v1_Message_Request.Parser, new string[7] { "Messages", "CreateMessage", "GetMessage", "PutMessage", "DeleteMessage", "TriggerMessage", "ClearMessage" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[7]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Request.Types.Messages), API_v1_Message_Request.Types.Messages.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Request.Types.CreateMessage), API_v1_Message_Request.Types.CreateMessage.Parser, new string[1] { "Message" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Request.Types.GetMessage), API_v1_Message_Request.Types.GetMessage.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Request.Types.PutMessage), API_v1_Message_Request.Types.PutMessage.Parser, new string[2] { "Id", "Message" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Request.Types.DeleteMessage), API_v1_Message_Request.Types.DeleteMessage.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Request.Types.TriggerMessage), API_v1_Message_Request.Types.TriggerMessage.Parser, new string[3] { "Id", "Tokens", "RequiresConfirmation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Request.Types.ClearMessage), API_v1_Message_Request.Types.ClearMessage.Parser, new string[1] { "Id" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Message_Response), API_v1_Message_Response.Parser, new string[7] { "Messages", "CreateMessage", "GetMessage", "PutMessage", "DeleteMessage", "TriggerMessage", "ClearMessage" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[7]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Response.Types.Messages), API_v1_Message_Response.Types.Messages.Parser, new string[1] { "Messages_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Response.Types.CreateMessage), API_v1_Message_Response.Types.CreateMessage.Parser, new string[1] { "Message" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Response.Types.GetMessage), API_v1_Message_Response.Types.GetMessage.Parser, new string[1] { "Message" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Response.Types.PutMessage), API_v1_Message_Response.Types.PutMessage.Parser, new string[1] { "Message" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Response.Types.DeleteMessage), API_v1_Message_Response.Types.DeleteMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Response.Types.TriggerMessage), API_v1_Message_Response.Types.TriggerMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Message_Response.Types.ClearMessage), API_v1_Message_Response.Types.ClearMessage.Parser, null, null, null, null, null)
			})
		}));
	}
}
