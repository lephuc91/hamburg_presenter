using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1StageReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1StageReflection()
	{
		_003C_003Ey__InlineArray61<string> buffer = default(_003C_003Ey__InlineArray61<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 0) = "ChNwcm9BcGlWMVN0YWdlLnByb3RvEgdydi5kYXRhGhhwcm9BcGlWMUlkZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 1) = "aWZpZXIucHJvdG8irwEKFUFQSV92MV9TdGFnZUxheW91dE1hcBI1CgdlbnRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 2) = "aWVzGAEgAygLMiQucnYuZGF0YS5BUElfdjFfU3RhZ2VMYXlvdXRNYXAuRW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 3) = "cnkaXwoFRW50cnkSKgoGc2NyZWVuGAEgASgLMhoucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 4) = "SWRlbnRpZmllchIqCgZsYXlvdXQYAiABKAsyGi5ydi5kYXRhLkFQSV92MV9J";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 5) = "ZGVudGlmaWVyIusIChRBUElfdjFfU3RhZ2VfUmVxdWVzdBJECg5nZXRfbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 6) = "b3V0X21hcBgBIAEoCzIqLnJ2LmRhdGEuQVBJX3YxX1N0YWdlX1JlcXVlc3Qu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 7) = "R2V0TGF5b3V0TWFwSAASRAoOc2V0X2xheW91dF9tYXAYAiABKAsyKi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 8) = "YXRhLkFQSV92MV9TdGFnZV9SZXF1ZXN0LlNldExheW91dE1hcEgAEj8KC2dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 9) = "dF9tZXNzYWdlGAMgASgLMigucnYuZGF0YS5BUElfdjFfU3RhZ2VfUmVxdWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 10) = "dC5HZXRNZXNzYWdlSAASPwoLcHV0X21lc3NhZ2UYBCABKAsyKC5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 11) = "LkFQSV92MV9TdGFnZV9SZXF1ZXN0LlB1dE1lc3NhZ2VIABJFCg5kZWxldGVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 12) = "bWVzc2FnZRgFIAEoCzIrLnJ2LmRhdGEuQVBJX3YxX1N0YWdlX1JlcXVlc3Qu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 13) = "RGVsZXRlTWVzc2FnZUgAEj8KC2dldF9zY3JlZW5zGAYgASgLMigucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 14) = "YS5BUElfdjFfU3RhZ2VfUmVxdWVzdC5HZXRTY3JlZW5zSAASSgoRZ2V0X3Nj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 15) = "cmVlbl9sYXlvdXQYByABKAsyLS5ydi5kYXRhLkFQSV92MV9TdGFnZV9SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 16) = "ZXN0LkdldFNjcmVlbkxheW91dEgAEkoKEXNldF9zY3JlZW5fbGF5b3V0GAgg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 17) = "ASgLMi0ucnYuZGF0YS5BUElfdjFfU3RhZ2VfUmVxdWVzdC5TZXRTY3JlZW5M";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 18) = "YXlvdXRIABI/CgtnZXRfbGF5b3V0cxgJIAEoCzIoLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 19) = "X1N0YWdlX1JlcXVlc3QuR2V0TGF5b3V0c0gAEkMKDWRlbGV0ZV9sYXlvdXQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 20) = "CiABKAsyKi5ydi5kYXRhLkFQSV92MV9TdGFnZV9SZXF1ZXN0LkRlbGV0ZUxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 21) = "eW91dEgAElAKFGdldF9sYXlvdXRfdGh1bWJuYWlsGAsgASgLMjAucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 22) = "YS5BUElfdjFfU3RhZ2VfUmVxdWVzdC5HZXRMYXlvdXRUaHVtYm5haWxIABoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 23) = "CgxHZXRMYXlvdXRNYXAaOwoMU2V0TGF5b3V0TWFwEisKA21hcBgBIAEoCzIe";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 24) = "LnJ2LmRhdGEuQVBJX3YxX1N0YWdlTGF5b3V0TWFwGgwKCkdldE1lc3NhZ2Ua";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 25) = "HQoKUHV0TWVzc2FnZRIPCgdtZXNzYWdlGAEgASgJGg8KDURlbGV0ZU1lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 26) = "Z2UaDAoKR2V0U2NyZWVucxodCg9HZXRTY3JlZW5MYXlvdXQSCgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 27) = "KAkaLQoPU2V0U2NyZWVuTGF5b3V0EgoKAmlkGAEgASgJEg4KBmxheW91dBgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 28) = "IAEoCRoMCgpHZXRMYXlvdXRzGhoKDERlbGV0ZUxheW91dBIKCgJpZBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 29) = "CRoxChJHZXRMYXlvdXRUaHVtYm5haWwSCgoCaWQYASABKAkSDwoHcXVhbGl0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 30) = "eRgCIAEoBUIJCgdSZXF1ZXN0IoAKChVBUElfdjFfU3RhZ2VfUmVzcG9uc2US";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 31) = "RQoOZ2V0X2xheW91dF9tYXAYASABKAsyKy5ydi5kYXRhLkFQSV92MV9TdGFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 32) = "ZV9SZXNwb25zZS5HZXRMYXlvdXRNYXBIABJFCg5zZXRfbGF5b3V0X21hcBgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 33) = "IAEoCzIrLnJ2LmRhdGEuQVBJX3YxX1N0YWdlX1Jlc3BvbnNlLlNldExheW91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 34) = "dE1hcEgAEkAKC2dldF9tZXNzYWdlGAMgASgLMikucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 35) = "U3RhZ2VfUmVzcG9uc2UuR2V0TWVzc2FnZUgAEkAKC3B1dF9tZXNzYWdlGAQg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 36) = "ASgLMikucnYuZGF0YS5BUElfdjFfU3RhZ2VfUmVzcG9uc2UuUHV0TWVzc2Fn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 37) = "ZUgAEkYKDmRlbGV0ZV9tZXNzYWdlGAUgASgLMiwucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 38) = "U3RhZ2VfUmVzcG9uc2UuRGVsZXRlTWVzc2FnZUgAEkAKC2dldF9zY3JlZW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 39) = "GAYgASgLMikucnYuZGF0YS5BUElfdjFfU3RhZ2VfUmVzcG9uc2UuR2V0U2Ny";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 40) = "ZWVuc0gAEksKEWdldF9zY3JlZW5fbGF5b3V0GAcgASgLMi4ucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 41) = "UElfdjFfU3RhZ2VfUmVzcG9uc2UuR2V0U2NyZWVuTGF5b3V0SAASSwoRc2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 42) = "X3NjcmVlbl9sYXlvdXQYCCABKAsyLi5ydi5kYXRhLkFQSV92MV9TdGFnZV9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 43) = "ZXNwb25zZS5TZXRTY3JlZW5MYXlvdXRIABJACgtnZXRfbGF5b3V0cxgJIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 44) = "CzIpLnJ2LmRhdGEuQVBJX3YxX1N0YWdlX1Jlc3BvbnNlLkdldExheW91dHNI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 45) = "ABJECg1kZWxldGVfbGF5b3V0GAogASgLMisucnYuZGF0YS5BUElfdjFfU3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 46) = "Z2VfUmVzcG9uc2UuRGVsZXRlTGF5b3V0SAASUQoUZ2V0X2xheW91dF90aHVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 47) = "Ym5haWwYCyABKAsyMS5ydi5kYXRhLkFQSV92MV9TdGFnZV9SZXNwb25zZS5H";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 48) = "ZXRMYXlvdXRUaHVtYm5haWxIABo7CgxHZXRMYXlvdXRNYXASKwoDbWFwGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 49) = "ASgLMh4ucnYuZGF0YS5BUElfdjFfU3RhZ2VMYXlvdXRNYXAaDgoMU2V0TGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 50) = "b3V0TWFwGh0KCkdldE1lc3NhZ2USDwoHbWVzc2FnZRgBIAEoCRoMCgpQdXRN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 51) = "ZXNzYWdlGg8KDURlbGV0ZU1lc3NhZ2UaOQoKR2V0U2NyZWVucxIrCgdzY3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 52) = "ZW5zGAEgAygLMhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmllcho5Cg9HZXRT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 53) = "Y3JlZW5MYXlvdXQSJgoCaWQYASABKAsyGi5ydi5kYXRhLkFQSV92MV9JZGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 54) = "dGlmaWVyGhEKD1NldFNjcmVlbkxheW91dBqBAQoKR2V0TGF5b3V0cxJBCgds";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 55) = "YXlvdXRzGAEgAygLMjAucnYuZGF0YS5BUElfdjFfU3RhZ2VfUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 56) = "R2V0TGF5b3V0cy5MYXlvdXQaMAoGTGF5b3V0EiYKAmlkGAEgASgLMhoucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 57) = "ZGF0YS5BUElfdjFfSWRlbnRpZmllchoOCgxEZWxldGVMYXlvdXQaIgoSR2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 58) = "TGF5b3V0VGh1bWJuYWlsEgwKBGRhdGEYASABKAxCCgoIUmVzcG9uc2VCNPgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 59) = "AaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray61<string>, string>(ref buffer, 60) = "RGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray61<string>, string>(in buffer, 61))), new FileDescriptor[1] { ProApiV1IdentifierReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[3]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_StageLayoutMap), API_v1_StageLayoutMap.Parser, new string[1] { "Entries" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_StageLayoutMap.Types.Entry), API_v1_StageLayoutMap.Types.Entry.Parser, new string[2] { "Screen", "Layout" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request), API_v1_Stage_Request.Parser, new string[11]
			{
				"GetLayoutMap", "SetLayoutMap", "GetMessage", "PutMessage", "DeleteMessage", "GetScreens", "GetScreenLayout", "SetScreenLayout", "GetLayouts", "DeleteLayout",
				"GetLayoutThumbnail"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[11]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.GetLayoutMap), API_v1_Stage_Request.Types.GetLayoutMap.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.SetLayoutMap), API_v1_Stage_Request.Types.SetLayoutMap.Parser, new string[1] { "Map" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.GetMessage), API_v1_Stage_Request.Types.GetMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.PutMessage), API_v1_Stage_Request.Types.PutMessage.Parser, new string[1] { "Message" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.DeleteMessage), API_v1_Stage_Request.Types.DeleteMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.GetScreens), API_v1_Stage_Request.Types.GetScreens.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.GetScreenLayout), API_v1_Stage_Request.Types.GetScreenLayout.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.SetScreenLayout), API_v1_Stage_Request.Types.SetScreenLayout.Parser, new string[2] { "Id", "Layout" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.GetLayouts), API_v1_Stage_Request.Types.GetLayouts.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.DeleteLayout), API_v1_Stage_Request.Types.DeleteLayout.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Request.Types.GetLayoutThumbnail), API_v1_Stage_Request.Types.GetLayoutThumbnail.Parser, new string[2] { "Id", "Quality" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response), API_v1_Stage_Response.Parser, new string[11]
			{
				"GetLayoutMap", "SetLayoutMap", "GetMessage", "PutMessage", "DeleteMessage", "GetScreens", "GetScreenLayout", "SetScreenLayout", "GetLayouts", "DeleteLayout",
				"GetLayoutThumbnail"
			}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[11]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.GetLayoutMap), API_v1_Stage_Response.Types.GetLayoutMap.Parser, new string[1] { "Map" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.SetLayoutMap), API_v1_Stage_Response.Types.SetLayoutMap.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.GetMessage), API_v1_Stage_Response.Types.GetMessage.Parser, new string[1] { "Message" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.PutMessage), API_v1_Stage_Response.Types.PutMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.DeleteMessage), API_v1_Stage_Response.Types.DeleteMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.GetScreens), API_v1_Stage_Response.Types.GetScreens.Parser, new string[1] { "Screens" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.GetScreenLayout), API_v1_Stage_Response.Types.GetScreenLayout.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.SetScreenLayout), API_v1_Stage_Response.Types.SetScreenLayout.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.GetLayouts), API_v1_Stage_Response.Types.GetLayouts.Parser, new string[1] { "Layouts" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.GetLayouts.Types.Layout), API_v1_Stage_Response.Types.GetLayouts.Types.Layout.Parser, new string[1] { "Id" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.DeleteLayout), API_v1_Stage_Response.Types.DeleteLayout.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Stage_Response.Types.GetLayoutThumbnail), API_v1_Stage_Response.Types.GetLayoutThumbnail.Parser, new string[1] { "Data" }, null, null, null, null)
			})
		}));
	}
}
