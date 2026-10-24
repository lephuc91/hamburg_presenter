using System;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Rv.Data;

public static class CustomOptionsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static CustomOptionsReflection()
	{
		_003C_003Ey__InlineArray8<string> buffer = default(_003C_003Ey__InlineArray8<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 0) = "ChNjdXN0b21PcHRpb25zLnByb3RvEgdydi5kYXRhGiBnb29nbGUvcHJvdG9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 1) = "dWYvZGVzY3JpcHRvci5wcm90bzo0CgZhdG9taWMSHy5nb29nbGUucHJvdG9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 2) = "dWYuTWVzc2FnZU9wdGlvbnMYgJADIAEoCIgBATo0CghvcHRpb25hbBIdLmdv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 3) = "b2dsZS5wcm90b2J1Zi5GaWVsZE9wdGlvbnMY5JADIAEoCIgBATo0CghvYnNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 4) = "bGV0ZRIdLmdvb2dsZS5wcm90b2J1Zi5GaWVsZE9wdGlvbnMY5ZADIAEoCIgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 5) = "ATo5Cg1tYXBfa2V5X2ZpZWxkEh0uZ29vZ2xlLnByb3RvYnVmLkZpZWxkT3B0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 6) = "aW9ucxjmkAMgASgJiAEBOjoKDm9wdGlvbmFsX29uZW9mEh0uZ29vZ2xlLnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 7) = "b3RvYnVmLk9uZW9mT3B0aW9ucxjIkQMgASgIiAEBYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray8<string>, string>(in buffer, 8))), new FileDescriptor[1] { DescriptorReflection.Descriptor }, new GeneratedClrTypeInfo(null, new Extension[5]
		{
			CustomOptionsExtensions.Atomic,
			CustomOptionsExtensions.Optional,
			CustomOptionsExtensions.Obsolete,
			CustomOptionsExtensions.MapKeyField,
			CustomOptionsExtensions.OptionalOneof
		}, null));
	}
}
