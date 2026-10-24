using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class BackgroundReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static BackgroundReflection()
	{
		_003C_003Ey__InlineArray6<string> buffer = default(_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = "ChBiYWNrZ3JvdW5kLnByb3RvEgdydi5kYXRhGgtjb2xvci5wcm90bxoSZ3Jh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "cGhpY3NEYXRhLnByb3RvInkKCkJhY2tncm91bmQSHwoFY29sb3IYASABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "Di5ydi5kYXRhLkNvbG9ySAASLgoIZ3JhZGllbnQYAiABKAsyGi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "LkdyYXBoaWNzLkdyYWRpZW50SAASEgoKaXNfZW5hYmxlZBgDIAEoCEIGCgRG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "aWxsQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "dGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<string>, string>(in buffer, 6))), new FileDescriptor[2]
		{
			ColorReflection.Descriptor,
			GraphicsDataReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Background), Background.Parser, new string[3] { "Color", "Gradient", "IsEnabled" }, new string[1] { "Fill" }, null, null, null)
		}));
	}
}
