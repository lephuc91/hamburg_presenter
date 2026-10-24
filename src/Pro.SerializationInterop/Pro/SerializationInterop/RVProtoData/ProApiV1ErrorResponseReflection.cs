using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1ErrorResponseReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1ErrorResponseReflection()
	{
		_003C_003Ey__InlineArray7<string> buffer = default(_003C_003Ey__InlineArray7<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 0) = "Chtwcm9BcGlWMUVycm9yUmVzcG9uc2UucHJvdG8SB3J2LmRhdGEiswEKFUFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 1) = "SV92MV9FcnJvcl9SZXNwb25zZRI/CgVlcnJvchgBIAEoDjIwLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 2) = "QVBJX3YxX0Vycm9yX1Jlc3BvbnNlLkFQSV92MV9FcnJvcl9UeXBlIlkKEUFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 3) = "SV92MV9FcnJvcl9UeXBlEg0KCU5PVF9GT1VORBAAEg8KC0JBRF9SRVFVRVNU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 4) = "EAESEgoOSU5URVJOQUxfRVJST1IQAhIQCgxVTkFVVEhPUklaRUQQA0I0+AEB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 5) = "qgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 6) = "YXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<string>, string>(in buffer, 7))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Error_Response), API_v1_Error_Response.Parser, new string[1] { "Error" }, null, new Type[1] { typeof(API_v1_Error_Response.Types.API_v1_Error_Type) }, null, null)
		}));
	}
}
