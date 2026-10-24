using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1VideoInputsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1VideoInputsReflection()
	{
		_003C_003Ey__InlineArray13<string> buffer = default(_003C_003Ey__InlineArray13<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 0) = "Chlwcm9BcGlWMVZpZGVvSW5wdXRzLnByb3RvEgdydi5kYXRhGhhwcm9BcGlW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 1) = "MUlkZW50aWZpZXIucHJvdG8iygEKG0FQSV92MV9WaWRlb19JbnB1dHNfUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 2) = "dWVzdBI+CgdnZXRfYWxsGAEgASgLMisucnYuZGF0YS5BUElfdjFfVmlkZW9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 3) = "SW5wdXRzX1JlcXVlc3QuR2V0QWxsSAASPwoHdHJpZ2dlchgCIAEoCzIsLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 4) = "LmRhdGEuQVBJX3YxX1ZpZGVvX0lucHV0c19SZXF1ZXN0LlRyaWdnZXJIABoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 5) = "CgZHZXRBbGwaFQoHVHJpZ2dlchIKCgJpZBgBIAEoCUIJCgdSZXF1ZXN0Iu0B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 6) = "ChxBUElfdjFfVmlkZW9fSW5wdXRzX1Jlc3BvbnNlEj8KB2dldF9hbGwYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 7) = "KAsyLC5ydi5kYXRhLkFQSV92MV9WaWRlb19JbnB1dHNfUmVzcG9uc2UuR2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 8) = "QWxsSAASQAoHdHJpZ2dlchgCIAEoCzItLnJ2LmRhdGEuQVBJX3YxX1ZpZGVv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 9) = "X0lucHV0c19SZXNwb25zZS5UcmlnZ2VySAAaNAoGR2V0QWxsEioKBmlucHV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 10) = "cxgBIAMoCzIaLnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZpZXIaCQoHVHJpZ2dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 11) = "ckIJCgdSZXF1ZXN0QjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 12) = "UlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray13<string>, string>(in buffer, 13))), new FileDescriptor[1] { ProApiV1IdentifierReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Video_Inputs_Request), API_v1_Video_Inputs_Request.Parser, new string[2] { "GetAll", "Trigger" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Video_Inputs_Request.Types.GetAll), API_v1_Video_Inputs_Request.Types.GetAll.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Video_Inputs_Request.Types.Trigger), API_v1_Video_Inputs_Request.Types.Trigger.Parser, new string[1] { "Id" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Video_Inputs_Response), API_v1_Video_Inputs_Response.Parser, new string[2] { "GetAll", "Trigger" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Video_Inputs_Response.Types.GetAll), API_v1_Video_Inputs_Response.Types.GetAll.Parser, new string[1] { "Inputs" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Video_Inputs_Response.Types.Trigger), API_v1_Video_Inputs_Response.Types.Trigger.Parser, null, null, null, null, null)
			})
		}));
	}
}
