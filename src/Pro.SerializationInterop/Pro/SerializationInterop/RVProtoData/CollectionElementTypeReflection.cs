using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class CollectionElementTypeReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static CollectionElementTypeReflection()
	{
		_003C_003Ey__InlineArray7<string> buffer = default(_003C_003Ey__InlineArray7<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 0) = "Chtjb2xsZWN0aW9uRWxlbWVudFR5cGUucHJvdG8SB3J2LmRhdGEaE2N1c3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 1) = "bU9wdGlvbnMucHJvdG8aCnV1aWQucHJvdG8iowEKFUNvbGxlY3Rpb25FbGVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 2) = "ZW50VHlwZRIrCg5wYXJhbWV0ZXJfdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 3) = "REIEoIYZARIcCg5wYXJhbWV0ZXJfbmFtZRgCIAEoCUIEoIYZARI/ChFwYXJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 4) = "bnRfY29sbGVjdGlvbhgDIAEoCzIeLnJ2LmRhdGEuQ29sbGVjdGlvbkVsZW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 5) = "bnRUeXBlQgSghhkBQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 6) = "UlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<string>, string>(in buffer, 7))), new FileDescriptor[2]
		{
			CustomOptionsReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(CollectionElementType), CollectionElementType.Parser, new string[3] { "ParameterUuid", "ParameterName", "ParentCollection" }, null, null, null, null)
		}));
	}
}
