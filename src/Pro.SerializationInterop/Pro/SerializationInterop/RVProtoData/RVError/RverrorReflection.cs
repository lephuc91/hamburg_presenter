using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.RVError;

public static class RverrorReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static RverrorReflection()
	{
		_003C_003Ey__InlineArray6<string> buffer = default(_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = "Cg1ydmVycm9yLnByb3RvEgdydmVycm9yIqUBCg1SZXBvcnRlZEVycm9yEhMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "C2Rlc2NyaXB0aW9uGAEgASgJEgwKBHR5cGUYAiABKAkSDAoEZmlsZRgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "CRIMCgRsaW5lGAQgASgNEjEKCHNldmVyaXR5GAUgASgOMh8ucnZlcnJvci5S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "ZXBvcnRlZEVycm9yLlNldmVyaXR5IiIKCFNldmVyaXR5EgsKB0hBTkRMRUQQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "ABIJCgVGQVRBTBABQkGqAixQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "cm90b0RhdGEuUlZFcnJvcroCD1JWRGF0YV9SVkVycm9yX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<string>, string>(in buffer, 6))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(ReportedError), ReportedError.Parser, new string[5] { "Description", "Type", "File", "Line", "Severity" }, null, new Type[1] { typeof(ReportedError.Types.Severity) }, null, null)
		}));
	}
}
