using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class MasksReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static MasksReflection()
	{
		_003C_003Ey__InlineArray8<string> buffer = default(_003C_003Ey__InlineArray8<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 0) = "CgttYXNrcy5wcm90bxIHcnYuZGF0YRoLY29sb3IucHJvdG8aEmdyYXBoaWNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 1) = "RGF0YS5wcm90bxoKdXVpZC5wcm90byLJAQoETWFzaxIbCgR1dWlkGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 2) = "Mg0ucnYuZGF0YS5VVUlEEgwKBG5hbWUYAiABKAkSHQoFY29sb3IYAyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 3) = "Di5ydi5kYXRhLkNvbG9yEiAKBG1vZGUYBCABKA4yEi5ydi5kYXRhLk1hc2su";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 4) = "TW9kZRIpCgZzaGFwZXMYBSADKAsyGS5ydi5kYXRhLkdyYXBoaWNzLkVsZW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 5) = "bnQiKgoETW9kZRIQCgxNT0RFX09WRVJMQVkQABIQCgxNT0RFX0tFWUhPTEUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 6) = "AUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 7) = "ugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray8<string>, string>(in buffer, 8))), new FileDescriptor[3]
		{
			ColorReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Mask), Mask.Parser, new string[5] { "Uuid", "Name", "Color", "Mode", "Shapes" }, null, new Type[1] { typeof(Mask.Types.Mode) }, null, null)
		}));
	}
}
