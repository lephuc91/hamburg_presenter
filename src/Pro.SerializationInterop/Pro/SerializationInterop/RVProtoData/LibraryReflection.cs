using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class LibraryReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static LibraryReflection()
	{
		_003C_003Ey__InlineArray10<string> buffer = default(_003C_003Ey__InlineArray10<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 0) = "Cg1saWJyYXJ5LnByb3RvEgdydi5kYXRhGgl1cmwucHJvdG8ijAIKB0xpYnJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 1) = "cnkSGQoDdXJsGAEgASgLMgwucnYuZGF0YS5VUkwSOAoPbGlicmFyeUNoaWxk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 2) = "cmVuGAIgASgLMh0ucnYuZGF0YS5MaWJyYXJ5LkxpYnJhcnlBcnJheUgAEjUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 3) = "DGxpYnJhcnlJdGVtcxgDIAEoCzIdLnJ2LmRhdGEuTGlicmFyeS5MaWJyYXJ5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 4) = "SXRlbXNIABozCgxMaWJyYXJ5QXJyYXkSIwoJbGlicmFyaWVzGAEgAygLMhAu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 5) = "cnYuZGF0YS5MaWJyYXJ5GjMKDExpYnJhcnlJdGVtcxIjCgVpdGVtcxgBIAMo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 6) = "CzIULnJ2LmRhdGEuTGlicmFyeUl0ZW1CCwoJQ2hpbGRUeXBlIigKC0xpYnJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 7) = "cnlJdGVtEhkKA3VybBgBIAEoCzIMLnJ2LmRhdGEuVVJMQjT4AQGqAiRQcm8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 8) = "U2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 9) = "cm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<string>, string>(in buffer, 10))), new FileDescriptor[1] { UrlReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Library), Library.Parser, new string[3] { "Url", "LibraryChildren", "LibraryItems" }, new string[1] { "ChildType" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(Library.Types.LibraryArray), Library.Types.LibraryArray.Parser, new string[1] { "Libraries" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Library.Types.LibraryItems), Library.Types.LibraryItems.Parser, new string[1] { "Items" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(LibraryItem), LibraryItem.Parser, new string[1] { "Url" }, null, null, null, null)
		}));
	}
}
