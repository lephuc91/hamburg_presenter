using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class MessagesReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static MessagesReflection()
	{
		_003C_003Ey__InlineArray38<string> buffer = default(_003C_003Ey__InlineArray38<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 0) = "Cg5tZXNzYWdlcy5wcm90bxIHcnYuZGF0YRoVYXBwbGljYXRpb25JbmZvLnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 1) = "b3RvGhNjdXN0b21PcHRpb25zLnByb3RvGhx0ZW1wbGF0ZUlkZW50aWZpY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 2) = "aW9uLnByb3RvGgx0aW1lcnMucHJvdG8aCnV1aWQucHJvdG8i3QkKB01lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 3) = "Z2USGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBINCgV0aXRsZRgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 4) = "CRIWCg50aW1lX3RvX3JlbW92ZRgDIAEoARIaChJ2aXNpYmxlX29uX25ldHdv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 5) = "cmsYBCABKAgSNwoIdGVtcGxhdGUYBiABKAsyHy5ydi5kYXRhLlRlbXBsYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 6) = "SWRlbnRpZmljYXRpb25CBKCGGQESLgoKY2xlYXJfdHlwZRgJIAEoDjIaLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 7) = "LmRhdGEuTWVzc2FnZS5DbGVhclR5cGUSFAoMbWVzc2FnZV90ZXh0GAogASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 8) = "EiYKBnRva2VucxgLIAMoCzIWLnJ2LmRhdGEuTWVzc2FnZS5Ub2tlbhI3Cgx0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 9) = "b2tlbl92YWx1ZXMYDCADKAsyGy5ydi5kYXRhLk1lc3NhZ2UuVG9rZW5WYWx1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 10) = "ZUIEqIYZARrLAgoFVG9rZW4SGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 11) = "RBI0CgR0ZXh0GAIgASgLMiQucnYuZGF0YS5NZXNzYWdlLlRva2VuLlRva2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 12) = "VHlwZVRleHRIABI2CgV0aW1lchgDIAEoCzIlLnJ2LmRhdGEuTWVzc2FnZS5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 13) = "b2tlbi5Ub2tlblR5cGVUaW1lckgAEjYKBWNsb2NrGAQgASgLMiUucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 14) = "YS5NZXNzYWdlLlRva2VuLlRva2VuVHlwZUNsb2NrSAAaHQoNVG9rZW5UeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 15) = "VGV4dBIMCgRuYW1lGAEgASgJGkEKDlRva2VuVHlwZVRpbWVyEgwKBG5hbWUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 16) = "ASABKAkSIQoKdGltZXJfdXVpZBgCIAEoCzINLnJ2LmRhdGEuVVVJRBoQCg5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 17) = "b2tlblR5cGVDbG9ja0ILCglUb2tlblR5cGUa1QMKClRva2VuVmFsdWUSHwoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 18) = "dG9rZW5faWQYASABKAsyDS5ydi5kYXRhLlVVSUQSOgoEdGV4dBgCIAEoCzIq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 19) = "LnJ2LmRhdGEuTWVzc2FnZS5Ub2tlblZhbHVlLlRva2VuVmFsdWVUZXh0SAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 20) = "PAoFdGltZXIYAyABKAsyKy5ydi5kYXRhLk1lc3NhZ2UuVG9rZW5WYWx1ZS5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 21) = "b2tlblZhbHVlVGltZXJIABI8CgVjbG9jaxgEIAEoCzIrLnJ2LmRhdGEuTWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 22) = "c2FnZS5Ub2tlblZhbHVlLlRva2VuVmFsdWVDbG9ja0gAEhIKCnRva2VuX25h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 23) = "bWUYBSABKAkaHwoOVG9rZW5WYWx1ZVRleHQSDQoFdmFsdWUYASABKAkabQoP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 24) = "VG9rZW5WYWx1ZVRpbWVyEjMKDWNvbmZpZ3VyYXRpb24YASABKAsyHC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 25) = "YXRhLlRpbWVyLkNvbmZpZ3VyYXRpb24SJQoGZm9ybWF0GAIgASgLMhUucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 26) = "ZGF0YS5UaW1lci5Gb3JtYXQaOAoPVG9rZW5WYWx1ZUNsb2NrEiUKBmZvcm1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 27) = "dBgBIAEoCzIVLnJ2LmRhdGEuQ2xvY2suRm9ybWF0QhAKDlRva2VuVmFsdWVU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 28) = "eXBlIloKCUNsZWFyVHlwZRIVChFDTEVBUl9UWVBFX01BTlVBTBAAEhkKFUNM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 29) = "RUFSX1RZUEVfQUZURVJfVElNRRABEhsKF0NMRUFSX1RZUEVfQUZURVJfVElN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 30) = "RVJTEAJKBAgFEAZKBAgHEAhKBAgIEAkibwoPTWVzc2FnZURvY3VtZW50EjgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 31) = "EGFwcGxpY2F0aW9uX2luZm8YASABKAsyGC5ydi5kYXRhLkFwcGxpY2F0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 32) = "SW5mb0IEqIYZARIiCghtZXNzYWdlcxgCIAMoCzIQLnJ2LmRhdGEuTWVzc2Fn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 33) = "ZSJeCgxMb2NhbE1lc3NhZ2USGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 34) = "RBIxCgx0b2tlbl92YWx1ZXMYAiADKAsyGy5ydi5kYXRhLk1lc3NhZ2UuVG9r";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 35) = "ZW5WYWx1ZSI/ChRNZXNzYWdlTG9jYWxEb2N1bWVudBInCghtZXNzYWdlcxgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 36) = "IAMoCzIVLnJ2LmRhdGEuTG9jYWxNZXNzYWdlQjT4AQGqAiRQcm8uU2VyaWFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray38<string>, string>(ref buffer, 37) = "aXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray38<string>, string>(in buffer, 38))), new FileDescriptor[5]
		{
			ApplicationInfoReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			TemplateIdentificationReflection.Descriptor,
			TimersReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(Message), Message.Parser, new string[9] { "Uuid", "Title", "TimeToRemove", "VisibleOnNetwork", "Template", "ClearType", "MessageText", "Tokens", "TokenValues" }, null, new Type[1] { typeof(Message.Types.ClearType) }, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(Message.Types.Token), Message.Types.Token.Parser, new string[4] { "Uuid", "Text", "Timer", "Clock" }, new string[1] { "TokenType" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(Message.Types.Token.Types.TokenTypeText), Message.Types.Token.Types.TokenTypeText.Parser, new string[1] { "Name" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Message.Types.Token.Types.TokenTypeTimer), Message.Types.Token.Types.TokenTypeTimer.Parser, new string[2] { "Name", "TimerUuid" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Message.Types.Token.Types.TokenTypeClock), Message.Types.Token.Types.TokenTypeClock.Parser, null, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Message.Types.TokenValue), Message.Types.TokenValue.Parser, new string[5] { "TokenId", "Text", "Timer", "Clock", "TokenName" }, new string[1] { "TokenValueType" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(Message.Types.TokenValue.Types.TokenValueText), Message.Types.TokenValue.Types.TokenValueText.Parser, new string[1] { "Value" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Message.Types.TokenValue.Types.TokenValueTimer), Message.Types.TokenValue.Types.TokenValueTimer.Parser, new string[2] { "Configuration", "Format" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Message.Types.TokenValue.Types.TokenValueClock), Message.Types.TokenValue.Types.TokenValueClock.Parser, new string[1] { "Format" }, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(MessageDocument), MessageDocument.Parser, new string[2] { "ApplicationInfo", "Messages" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LocalMessage), LocalMessage.Parser, new string[2] { "Uuid", "TokenValues" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MessageLocalDocument), MessageLocalDocument.Parser, new string[1] { "Messages" }, null, null, null, null)
		}));
	}
}
