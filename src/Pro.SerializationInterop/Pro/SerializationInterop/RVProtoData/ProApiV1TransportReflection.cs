using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1TransportReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1TransportReflection()
	{
		_003C_003Ey__InlineArray56<string> buffer = default(_003C_003Ey__InlineArray56<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 0) = "Chdwcm9BcGlWMVRyYW5zcG9ydC5wcm90bxIHcnYuZGF0YRoXcHJvQXBpVjFM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 1) = "YXllclR5cGUucHJvdG8iygoKGEFQSV92MV9UcmFuc3BvcnRfUmVxdWVzdBI2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 2) = "CgRwbGF5GAEgASgLMiYucnYuZGF0YS5BUElfdjFfVHJhbnNwb3J0X1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 3) = "c3QuUGxheUgAEjgKBXBhdXNlGAIgASgLMicucnYuZGF0YS5BUElfdjFfVHJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 4) = "bnNwb3J0X1JlcXVlc3QuUGF1c2VIABJHCg1za2lwX2JhY2t3YXJkGAMgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 5) = "Mi4ucnYuZGF0YS5BUElfdjFfVHJhbnNwb3J0X1JlcXVlc3QuU2tpcEJhY2t3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 6) = "YXJkSAASRQoMc2tpcF9mb3J3YXJkGAQgASgLMi0ucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 7) = "VHJhbnNwb3J0X1JlcXVlc3QuU2tpcEZvcndhcmRIABI+Cglnb190b19lbmQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 8) = "BSABKAsyKS5ydi5kYXRhLkFQSV92MV9UcmFuc3BvcnRfUmVxdWVzdC5Hb1Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 9) = "RW5kSAASPQoIZ2V0X3RpbWUYBiABKAsyKS5ydi5kYXRhLkFQSV92MV9UcmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 10) = "c3BvcnRfUmVxdWVzdC5HZXRUaW1lSAASPQoIcHV0X3RpbWUYByABKAsyKS5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 11) = "di5kYXRhLkFQSV92MV9UcmFuc3BvcnRfUmVxdWVzdC5QdXRUaW1lSAASTAoQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 12) = "Z2V0X2F1dG9fYWR2YW5jZRgIIAEoCzIwLnJ2LmRhdGEuQVBJX3YxX1RyYW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 13) = "cG9ydF9SZXF1ZXN0LkdldEF1dG9BZHZhbmNlSAASUgoTZGVsZXRlX2F1dG9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 14) = "YWR2YW5jZRgJIAEoCzIzLnJ2LmRhdGEuQVBJX3YxX1RyYW5zcG9ydF9SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 15) = "ZXN0LkRlbGV0ZUF1dG9BZHZhbmNlSAASTgoRZ2V0X2N1cnJlbnRfbWVkaWEY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 16) = "CiABKAsyMS5ydi5kYXRhLkFQSV92MV9UcmFuc3BvcnRfUmVxdWVzdC5HZXRD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 17) = "dXJyZW50TWVkaWFIABowCgRQbGF5EigKBWxheWVyGAEgASgOMhkucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 18) = "YS5BUElfdjFfTGF5ZXJUeXBlGjEKBVBhdXNlEigKBWxheWVyGAEgASgOMhku";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 19) = "cnYuZGF0YS5BUElfdjFfTGF5ZXJUeXBlGkkKDFNraXBCYWNrd2FyZBIoCgVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 20) = "YXllchgBIAEoDjIZLnJ2LmRhdGEuQVBJX3YxX0xheWVyVHlwZRIPCgdzZWNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 21) = "bmRzGAIgASgBGkgKC1NraXBGb3J3YXJkEigKBWxheWVyGAEgASgOMhkucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 22) = "ZGF0YS5BUElfdjFfTGF5ZXJUeXBlEg8KB3NlY29uZHMYAiABKAEaRAoHR29U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 23) = "b0VuZBIoCgVsYXllchgBIAEoDjIZLnJ2LmRhdGEuQVBJX3YxX0xheWVyVHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 24) = "ZRIPCgdzZWNvbmRzGAIgASgBGjMKB0dldFRpbWUSKAoFbGF5ZXIYASABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 25) = "GS5ydi5kYXRhLkFQSV92MV9MYXllclR5cGUaRAoHUHV0VGltZRIoCgVsYXll";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 26) = "chgBIAEoDjIZLnJ2LmRhdGEuQVBJX3YxX0xheWVyVHlwZRIPCgdzZWNvbmRz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 27) = "GAIgASgBGjoKDkdldEF1dG9BZHZhbmNlEigKBWxheWVyGAEgASgOMhkucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 28) = "ZGF0YS5BUElfdjFfTGF5ZXJUeXBlGj0KEURlbGV0ZUF1dG9BZHZhbmNlEigK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 29) = "BWxheWVyGAEgASgOMhkucnYuZGF0YS5BUElfdjFfTGF5ZXJUeXBlGjsKD0dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 30) = "dEN1cnJlbnRNZWRpYRIoCgVsYXllchgBIAEoDjIZLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 31) = "X0xheWVyVHlwZUIJCgdSZXF1ZXN0IvsHChlBUElfdjFfVHJhbnNwb3J0X1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 32) = "c3BvbnNlEjcKBHBsYXkYASABKAsyJy5ydi5kYXRhLkFQSV92MV9UcmFuc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 33) = "cnRfUmVzcG9uc2UuUGxheUgAEjkKBXBhdXNlGAIgASgLMigucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 34) = "UElfdjFfVHJhbnNwb3J0X1Jlc3BvbnNlLlBhdXNlSAASSAoNc2tpcF9iYWNr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 35) = "d2FyZBgDIAEoCzIvLnJ2LmRhdGEuQVBJX3YxX1RyYW5zcG9ydF9SZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 36) = "ZS5Ta2lwQmFja3dhcmRIABJGCgxza2lwX2ZvcndhcmQYBCABKAsyLi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 37) = "YXRhLkFQSV92MV9UcmFuc3BvcnRfUmVzcG9uc2UuU2tpcEZvcndhcmRIABI/";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 38) = "Cglnb190b19lbmQYBSABKAsyKi5ydi5kYXRhLkFQSV92MV9UcmFuc3BvcnRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 39) = "UmVzcG9uc2UuR29Ub0VuZEgAEj4KCGdldF90aW1lGAYgASgLMioucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 40) = "YS5BUElfdjFfVHJhbnNwb3J0X1Jlc3BvbnNlLkdldFRpbWVIABI+CghwdXRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 41) = "dGltZRgHIAEoCzIqLnJ2LmRhdGEuQVBJX3YxX1RyYW5zcG9ydF9SZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 42) = "ZS5QdXRUaW1lSAASTQoQZ2V0X2F1dG9fYWR2YW5jZRgIIAEoCzIxLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 43) = "dGEuQVBJX3YxX1RyYW5zcG9ydF9SZXNwb25zZS5HZXRBdXRvQWR2YW5jZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 44) = "ElMKE2RlbGV0ZV9hdXRvX2FkdmFuY2UYCSABKAsyNC5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 45) = "MV9UcmFuc3BvcnRfUmVzcG9uc2UuRGVsZXRlQXV0b0FkdmFuY2VIABJPChFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 46) = "ZXRfY3VycmVudF9tZWRpYRgKIAEoCzIyLnJ2LmRhdGEuQVBJX3YxX1RyYW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 47) = "cG9ydF9SZXNwb25zZS5HZXRDdXJyZW50TWVkaWFIABoGCgRQbGF5GgcKBVBh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 48) = "dXNlGg4KDFNraXBCYWNrd2FyZBoNCgtTa2lwRm9yd2FyZBoJCgdHb1RvRW5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 49) = "GhoKB0dldFRpbWUSDwoHc2Vjb25kcxgBIAEoARoJCgdQdXRUaW1lGiYKDkdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 50) = "dEF1dG9BZHZhbmNlEhQKDGF1dG9fYWR2YW5jZRgBIAEoCBoTChFEZWxldGVB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 51) = "dXRvQWR2YW5jZRp3Cg9HZXRDdXJyZW50TWVkaWESEgoKaXNfcGxheWluZxgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 52) = "IAEoCBIMCgR1dWlkGAIgASgJEgwKBG5hbWUYAyABKAkSDgoGYXJ0aXN0GAQg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 53) = "ASgJEhIKCmF1ZGlvX29ubHkYBSABKAgSEAoIZHVyYXRpb24YBiABKAFCCgoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 54) = "UmVzcG9uc2VCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 55) = "b3RvRGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray56<string>, string>(in buffer, 56))), new FileDescriptor[1] { ProApiV1LayerTypeReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request), API_v1_Transport_Request.Parser, new string[10] { "Play", "Pause", "SkipBackward", "SkipForward", "GoToEnd", "GetTime", "PutTime", "GetAutoAdvance", "DeleteAutoAdvance", "GetCurrentMedia" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[10]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.Play), API_v1_Transport_Request.Types.Play.Parser, new string[1] { "Layer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.Pause), API_v1_Transport_Request.Types.Pause.Parser, new string[1] { "Layer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.SkipBackward), API_v1_Transport_Request.Types.SkipBackward.Parser, new string[2] { "Layer", "Seconds" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.SkipForward), API_v1_Transport_Request.Types.SkipForward.Parser, new string[2] { "Layer", "Seconds" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.GoToEnd), API_v1_Transport_Request.Types.GoToEnd.Parser, new string[2] { "Layer", "Seconds" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.GetTime), API_v1_Transport_Request.Types.GetTime.Parser, new string[1] { "Layer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.PutTime), API_v1_Transport_Request.Types.PutTime.Parser, new string[2] { "Layer", "Seconds" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.GetAutoAdvance), API_v1_Transport_Request.Types.GetAutoAdvance.Parser, new string[1] { "Layer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.DeleteAutoAdvance), API_v1_Transport_Request.Types.DeleteAutoAdvance.Parser, new string[1] { "Layer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Request.Types.GetCurrentMedia), API_v1_Transport_Request.Types.GetCurrentMedia.Parser, new string[1] { "Layer" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response), API_v1_Transport_Response.Parser, new string[10] { "Play", "Pause", "SkipBackward", "SkipForward", "GoToEnd", "GetTime", "PutTime", "GetAutoAdvance", "DeleteAutoAdvance", "GetCurrentMedia" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[10]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.Play), API_v1_Transport_Response.Types.Play.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.Pause), API_v1_Transport_Response.Types.Pause.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.SkipBackward), API_v1_Transport_Response.Types.SkipBackward.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.SkipForward), API_v1_Transport_Response.Types.SkipForward.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.GoToEnd), API_v1_Transport_Response.Types.GoToEnd.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.GetTime), API_v1_Transport_Response.Types.GetTime.Parser, new string[1] { "Seconds" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.PutTime), API_v1_Transport_Response.Types.PutTime.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.GetAutoAdvance), API_v1_Transport_Response.Types.GetAutoAdvance.Parser, new string[1] { "AutoAdvance" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.DeleteAutoAdvance), API_v1_Transport_Response.Types.DeleteAutoAdvance.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Transport_Response.Types.GetCurrentMedia), API_v1_Transport_Response.Types.GetCurrentMedia.Parser, new string[6] { "IsPlaying", "Uuid", "Name", "Artist", "AudioOnly", "Duration" }, null, null, null, null)
			})
		}));
	}
}
