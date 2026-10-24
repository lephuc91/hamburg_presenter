using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1StatusReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1StatusReflection()
	{
		_003C_003Ey__InlineArray47<string> buffer = default(_003C_003Ey__InlineArray47<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 0) = "ChRwcm9BcGlWMVN0YXR1cy5wcm90bxIHcnYuZGF0YRoYcHJvQXBpVjFJZGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 1) = "dGlmaWVyLnByb3RvGhJwcm9BcGlWMVNpemUucHJvdG8iRwoaQVBJX3YxX1Ns";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 2) = "aWRlRGlzcGxheURldGFpbHMSDAoEdGV4dBgBIAEoCRINCgVub3RlcxgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 3) = "CRIMCgR1dWlkGAMgASgJIpIBChNBUElfdjFfU2NyZWVuQ29uZmlnEiYKAmlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 4) = "GAEgASgLMhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmllchIiCgRzaXplGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 5) = "ASgLMhQucnYuZGF0YS5BUElfdjFfU2l6ZRIvCgtzY3JlZW5fdHlwZRgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 6) = "DjIaLnJ2LmRhdGEuQVBJX3YxX1NjcmVlblR5cGUivQUKFUFQSV92MV9TdGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 7) = "dXNfUmVxdWVzdBI+CgpnZXRfbGF5ZXJzGAEgASgLMigucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 8) = "djFfU3RhdHVzX1JlcXVlc3QuR2V0TGF5ZXJzSAASSwoRZ2V0X3N0YWdlX3Nj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 9) = "cmVlbnMYAiABKAsyLi5ydi5kYXRhLkFQSV92MV9TdGF0dXNfUmVxdWVzdC5H";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 10) = "ZXRTdGFnZVNjcmVlbnNIABJLChFwdXRfc3RhZ2Vfc2NyZWVucxgDIAEoCzIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 11) = "LnJ2LmRhdGEuQVBJX3YxX1N0YXR1c19SZXF1ZXN0LlB1dFN0YWdlU2NyZWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 12) = "c0gAElEKFGdldF9hdWRpZW5jZV9zY3JlZW5zGAQgASgLMjEucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 13) = "UElfdjFfU3RhdHVzX1JlcXVlc3QuR2V0QXVkaWVuY2VTY3JlZW5zSAASUQoU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 14) = "cHV0X2F1ZGllbmNlX3NjcmVlbnMYBSABKAsyMS5ydi5kYXRhLkFQSV92MV9T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 15) = "dGF0dXNfUmVxdWVzdC5QdXRBdWRpZW5jZVNjcmVlbnNIABJACgtnZXRfc2Ny";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 16) = "ZWVucxgGIAEoCzIpLnJ2LmRhdGEuQVBJX3YxX1N0YXR1c19SZXF1ZXN0Lkdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 17) = "dFNjcmVlbnNIABI8CglnZXRfc2xpZGUYByABKAsyJy5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 18) = "MV9TdGF0dXNfUmVxdWVzdC5HZXRTbGlkZUgAGgsKCUdldExheWVycxoRCg9H";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 19) = "ZXRTdGFnZVNjcmVlbnMaIgoPUHV0U3RhZ2VTY3JlZW5zEg8KB2VuYWJsZWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 20) = "ASABKAgaFAoSR2V0QXVkaWVuY2VTY3JlZW5zGiUKElB1dEF1ZGllbmNlU2Ny";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 21) = "ZWVucxIPCgdlbmFibGVkGAEgASgIGgwKCkdldFNjcmVlbnMaCgoIR2V0U2xp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 22) = "ZGVCCQoHUmVxdWVzdCLZBwoWQVBJX3YxX1N0YXR1c19SZXNwb25zZRI/Cgpn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 23) = "ZXRfbGF5ZXJzGAEgASgLMikucnYuZGF0YS5BUElfdjFfU3RhdHVzX1Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 24) = "bnNlLkdldExheWVyc0gAEkwKEWdldF9zdGFnZV9zY3JlZW5zGAIgASgLMi8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 25) = "cnYuZGF0YS5BUElfdjFfU3RhdHVzX1Jlc3BvbnNlLkdldFN0YWdlU2NyZWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 26) = "c0gAEkwKEXB1dF9zdGFnZV9zY3JlZW5zGAMgASgLMi8ucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 27) = "djFfU3RhdHVzX1Jlc3BvbnNlLlB1dFN0YWdlU2NyZWVuc0gAElIKFGdldF9h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 28) = "dWRpZW5jZV9zY3JlZW5zGAQgASgLMjIucnYuZGF0YS5BUElfdjFfU3RhdHVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 29) = "X1Jlc3BvbnNlLkdldEF1ZGllbmNlU2NyZWVuc0gAElIKFHB1dF9hdWRpZW5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 30) = "ZV9zY3JlZW5zGAUgASgLMjIucnYuZGF0YS5BUElfdjFfU3RhdHVzX1Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 31) = "bnNlLlB1dEF1ZGllbmNlU2NyZWVuc0gAEkEKC2dldF9zY3JlZW5zGAYgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 32) = "MioucnYuZGF0YS5BUElfdjFfU3RhdHVzX1Jlc3BvbnNlLkdldFNjcmVlbnNI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 33) = "ABI9CglnZXRfc2xpZGUYByABKAsyKC5ydi5kYXRhLkFQSV92MV9TdGF0dXNf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 34) = "UmVzcG9uc2UuR2V0U2xpZGVIABqFAQoJR2V0TGF5ZXJzEhMKC3ZpZGVvX2lu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 35) = "cHV0GAEgASgIEg0KBW1lZGlhGAIgASgIEg0KBXNsaWRlGAMgASgIEhUKDWFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 36) = "bm91bmNlbWVudHMYBCABKAgSDQoFcHJvcHMYBSABKAgSEAoIbWVzc2FnZXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 37) = "BiABKAgSDQoFYXVkaW8YByABKAgaIgoPR2V0U3RhZ2VTY3JlZW5zEg8KB2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 38) = "YWJsZWQYASABKAgaEQoPUHV0U3RhZ2VTY3JlZW5zGiUKEkdldEF1ZGllbmNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 39) = "U2NyZWVucxIPCgdlbmFibGVkGAEgASgIGhQKElB1dEF1ZGllbmNlU2NyZWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 40) = "cxo7CgpHZXRTY3JlZW5zEi0KB3NjcmVlbnMYASADKAsyHC5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 41) = "SV92MV9TY3JlZW5Db25maWcacwoIR2V0U2xpZGUSNAoHY3VycmVudBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 42) = "CzIjLnJ2LmRhdGEuQVBJX3YxX1NsaWRlRGlzcGxheURldGFpbHMSMQoEbmV4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 43) = "dBgCIAEoCzIjLnJ2LmRhdGEuQVBJX3YxX1NsaWRlRGlzcGxheURldGFpbHNC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 44) = "CgoIUmVzcG9uc2UqLAoRQVBJX3YxX1NjcmVlblR5cGUSDAoIYXVkaWVuY2UQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 45) = "ABIJCgVzdGFnZRABQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray47<string>, string>(ref buffer, 46) = "UlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray47<string>, string>(in buffer, 47))), new FileDescriptor[2]
		{
			ProApiV1IdentifierReflection.Descriptor,
			ProApiV1SizeReflection.Descriptor
		}, new GeneratedClrTypeInfo(new Type[1] { typeof(API_v1_ScreenType) }, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_SlideDisplayDetails), API_v1_SlideDisplayDetails.Parser, new string[3] { "Text", "Notes", "Uuid" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_ScreenConfig), API_v1_ScreenConfig.Parser, new string[3] { "Id", "Size", "ScreenType" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Status_Request), API_v1_Status_Request.Parser, new string[7] { "GetLayers", "GetStageScreens", "PutStageScreens", "GetAudienceScreens", "PutAudienceScreens", "GetScreens", "GetSlide" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[7]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Request.Types.GetLayers), API_v1_Status_Request.Types.GetLayers.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Request.Types.GetStageScreens), API_v1_Status_Request.Types.GetStageScreens.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Request.Types.PutStageScreens), API_v1_Status_Request.Types.PutStageScreens.Parser, new string[1] { "Enabled" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Request.Types.GetAudienceScreens), API_v1_Status_Request.Types.GetAudienceScreens.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Request.Types.PutAudienceScreens), API_v1_Status_Request.Types.PutAudienceScreens.Parser, new string[1] { "Enabled" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Request.Types.GetScreens), API_v1_Status_Request.Types.GetScreens.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Request.Types.GetSlide), API_v1_Status_Request.Types.GetSlide.Parser, null, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Status_Response), API_v1_Status_Response.Parser, new string[7] { "GetLayers", "GetStageScreens", "PutStageScreens", "GetAudienceScreens", "PutAudienceScreens", "GetScreens", "GetSlide" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[7]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Response.Types.GetLayers), API_v1_Status_Response.Types.GetLayers.Parser, new string[7] { "VideoInput", "Media", "Slide", "Announcements", "Props", "Messages", "Audio" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Response.Types.GetStageScreens), API_v1_Status_Response.Types.GetStageScreens.Parser, new string[1] { "Enabled" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Response.Types.PutStageScreens), API_v1_Status_Response.Types.PutStageScreens.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Response.Types.GetAudienceScreens), API_v1_Status_Response.Types.GetAudienceScreens.Parser, new string[1] { "Enabled" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Response.Types.PutAudienceScreens), API_v1_Status_Response.Types.PutAudienceScreens.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Response.Types.GetScreens), API_v1_Status_Response.Types.GetScreens.Parser, new string[1] { "Screens" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Status_Response.Types.GetSlide), API_v1_Status_Response.Types.GetSlide.Parser, new string[2] { "Current", "Next" }, null, null, null, null)
			})
		}));
	}
}
