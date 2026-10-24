using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class CcliReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static CcliReflection()
	{
		_003C_003Ey__InlineArray19<string> buffer = default(_003C_003Ey__InlineArray19<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 0) = "CgpjY2xpLnByb3RvEgdydi5kYXRhGhVhcHBsaWNhdGlvbkluZm8ucHJvdG8a";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 1) = "E2N1c3RvbU9wdGlvbnMucHJvdG8aDnRlbXBsYXRlLnByb3RvIpgDCgxDQ0xJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 2) = "RG9jdW1lbnQSOAoQYXBwbGljYXRpb25faW5mbxgBIAEoCzIYLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 3) = "QXBwbGljYXRpb25JbmZvQgSohhkBEhsKE2VuYWJsZV9jY2xpX2Rpc3BsYXkY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 4) = "AiABKAgSFAoMY2NsaV9saWNlbnNlGAMgASgJEjcKDGRpc3BsYXlfdHlwZRgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 5) = "IAEoDjIhLnJ2LmRhdGEuQ0NMSURvY3VtZW50LkRpc3BsYXlUeXBlEikKCHRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 6) = "bXBsYXRlGAUgASgLMhcucnYuZGF0YS5UZW1wbGF0ZS5TbGlkZRIoCgZsYXlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 7) = "dXQYBiABKAsyGC5ydi5kYXRhLkNvcHlyaWdodExheW91dCKMAQoLRGlzcGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 8) = "eVR5cGUSHAoYRElTUExBWV9UWVBFX0ZJUlNUX1NMSURFEAASGwoXRElTUExB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 9) = "WV9UWVBFX0xBU1RfU0xJREUQARIlCiFESVNQTEFZX1RZUEVfRklSU1RfQU5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 10) = "X0xBU1RfU0xJREUQAhIbChdESVNQTEFZX1RZUEVfQUxMX1NMSURFUxADIpsC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 11) = "Cg9Db3B5cmlnaHRMYXlvdXQSLgoGdG9rZW5zGAIgAygLMh4ucnYuZGF0YS5D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 12) = "b3B5cmlnaHRMYXlvdXQuVG9rZW4aWQoFVG9rZW4SNgoKdG9rZW5fdHlwZRgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 13) = "IAEoDjIiLnJ2LmRhdGEuQ29weXJpZ2h0TGF5b3V0LlRva2VuVHlwZRISCgR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 14) = "ZXh0GAIgASgJQgSghhkBOgSAgBkBIn0KCVRva2VuVHlwZRIICgRUZXh0EAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 15) = "CgoGQXJ0aXN0EAESCgoGQXV0aG9yEAISDQoJUHVibGlzaGVyEAMSCQoFVGl0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 16) = "bGUQBBIRCg1Db3B5cmlnaHRZZWFyEAUSEQoNTGljZW5zZU51bWJlchAGEg4K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 17) = "ClNvbmdOdW1iZXIQB0I0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray19<string>, string>(ref buffer, 18) = "LlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray19<string>, string>(in buffer, 19))), new FileDescriptor[3]
		{
			ApplicationInfoReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			TemplateReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(CCLIDocument), CCLIDocument.Parser, new string[6] { "ApplicationInfo", "EnableCcliDisplay", "CcliLicense", "DisplayType", "Template", "Layout" }, null, new Type[1] { typeof(CCLIDocument.Types.DisplayType) }, null, null),
			new GeneratedClrTypeInfo(typeof(CopyrightLayout), CopyrightLayout.Parser, new string[1] { "Tokens" }, null, new Type[1] { typeof(CopyrightLayout.Types.TokenType) }, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(CopyrightLayout.Types.Token), CopyrightLayout.Types.Token.Parser, new string[2] { "TokenType", "Text" }, null, null, null, null)
			})
		}));
	}
}
