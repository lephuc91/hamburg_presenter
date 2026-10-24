using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Logging;

public static class LogReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static LogReflection()
	{
		_003C_003Ey__InlineArray6<string> buffer = default(_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = "Cglsb2cucHJvdG8SB2xvZ2dpbmciTQoITG9nRW50cnkSDwoHbWVzc2FnZRgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "IAEoCRIgCgVsZXZlbBgCIAEoDjIRLmxvZ2dpbmcuTG9nTGV2ZWwSDgoGdGFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "Z2V0GAMgASgJKlgKCExvZ0xldmVsEg4KCkxldmVsVHJhY2UQABIOCgpMZXZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "bERlYnVnEAESDQoJTGV2ZWxJbmZvEAISDQoJTGV2ZWxXYXJuEAMSDgoKTGV2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "ZWxFcnJvchAEQkGqAixQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "b0RhdGEuTG9nZ2luZ7oCD1JWRGF0YV9Mb2dnaW5nX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<string>, string>(in buffer, 6))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[1] { typeof(LogLevel) }, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(LogEntry), LogEntry.Parser, new string[3] { "Message", "Level", "Target" }, null, null, null, null)
		}));
	}
}
