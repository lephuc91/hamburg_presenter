using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class TemplateIdentificationReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static TemplateIdentificationReflection()
	{
		_003C_003Ey__InlineArray7<string> buffer = default(_003C_003Ey__InlineArray7<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 0) = "Chx0ZW1wbGF0ZUlkZW50aWZpY2F0aW9uLnByb3RvEgdydi5kYXRhGhNjdXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 1) = "b21PcHRpb25zLnByb3RvGgp1dWlkLnByb3RvIpUBChZUZW1wbGF0ZUlkZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 2) = "aWZpY2F0aW9uEiEKBHV1aWQYASABKAsyDS5ydi5kYXRhLlVVSURCBKCGGQES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 3) = "DAoEbmFtZRgCIAEoCRIhCgpzbGlkZV91dWlkGAMgASgLMg0ucnYuZGF0YS5V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 4) = "VUlEEhIKCnNsaWRlX25hbWUYBCABKAkSEwoLc2xpZGVfaW5kZXgYBSABKA1C";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 5) = "NPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 6) = "B1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<string>, string>(in buffer, 7))), new FileDescriptor[2]
		{
			CustomOptionsReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(TemplateIdentification), TemplateIdentification.Parser, new string[5] { "Uuid", "Name", "SlideUuid", "SlideName", "SlideIndex" }, null, null, null, null)
		}));
	}
}
