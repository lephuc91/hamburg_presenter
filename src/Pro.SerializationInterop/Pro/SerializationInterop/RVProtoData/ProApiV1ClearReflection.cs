using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1ClearReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1ClearReflection()
	{
		_003C_003Ey__InlineArray58<string> buffer = default(_003C_003Ey__InlineArray58<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 0) = "ChNwcm9BcGlWMUNsZWFyLnByb3RvEgdydi5kYXRhGhNwcm9BcGlWMUNvbG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 1) = "LnByb3RvGhhwcm9BcGlWMUlkZW50aWZpZXIucHJvdG8aF3Byb0FwaVYxTGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 2) = "ZXJUeXBlLnByb3RvIsMDChFBUElfdjFfQ2xlYXJHcm91cBImCgJpZBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 3) = "CzIaLnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZpZXISDAoEaWNvbhgCIAEoCRIj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 4) = "CgR0aW50GAMgASgLMhUucnYuZGF0YS5BUElfdjFfQ29sb3ISRQoGbGF5ZXJz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 5) = "GAQgAygOMjUucnYuZGF0YS5BUElfdjFfQ2xlYXJHcm91cC5BUElfdjFfQ2xl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 6) = "YXJHcm91cExheWVyVHlwZRIjChtzdG9wX3RpbWVsaW5lX2Fubm91bmNlbWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 7) = "dHMYBSABKAgSIgoac3RvcF90aW1lbGluZV9wcmVzZW50YXRpb24YBiABKAgS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 8) = "HwoXY2xlYXJfbmV4dF9wcmVzZW50YXRpb24YByABKAgioQEKGkFQSV92MV9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 9) = "bGVhckdyb3VwTGF5ZXJUeXBlEgkKBW11c2ljEAASEQoNYXVkaW9fZWZmZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 10) = "cxABEgkKBXByb3BzEAISDAoIbWVzc2FnZXMQAxIRCg1hbm5vdW5jZW1lbnRz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 11) = "EAQSEAoMcHJlc2VudGF0aW9uEAUSFgoScHJlc2VudGF0aW9uX21lZGlhEAYS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 12) = "DwoLdmlkZW9faW5wdXQQByLfBwoUQVBJX3YxX0NsZWFyX1JlcXVlc3QSPwoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 13) = "Y2xlYXJfbGF5ZXIYASABKAsyKC5ydi5kYXRhLkFQSV92MV9DbGVhcl9SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 14) = "ZXN0LkNsZWFyTGF5ZXJIABJBCgxjcmVhdGVfZ3JvdXAYAiABKAsyKS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 15) = "YXRhLkFQSV92MV9DbGVhcl9SZXF1ZXN0LkNyZWF0ZUdyb3VwSAASOwoJZ2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 16) = "X2dyb3VwGAMgASgLMiYucnYuZGF0YS5BUElfdjFfQ2xlYXJfUmVxdWVzdC5H";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 17) = "ZXRHcm91cEgAEjsKCXB1dF9ncm91cBgEIAEoCzImLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 18) = "X0NsZWFyX1JlcXVlc3QuUHV0R3JvdXBIABJECg5nZXRfZ3JvdXBfaWNvbhgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 19) = "IAEoCzIqLnJ2LmRhdGEuQVBJX3YxX0NsZWFyX1JlcXVlc3QuR2V0R3JvdXBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 20) = "Y29uSAASRAoOcHV0X2dyb3VwX2ljb24YBiABKAsyKi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 21) = "MV9DbGVhcl9SZXF1ZXN0LlB1dEdyb3VwSWNvbkgAEkEKDGRlbGV0ZV9ncm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 22) = "cBgHIAEoCzIpLnJ2LmRhdGEuQVBJX3YxX0NsZWFyX1JlcXVlc3QuRGVsZXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 23) = "R3JvdXBIABJDCg10cmlnZ2VyX2dyb3VwGAggASgLMioucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 24) = "djFfQ2xlYXJfUmVxdWVzdC5UcmlnZ2VyR3JvdXBIABI9CgpnZXRfZ3JvdXBz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 25) = "GAkgASgLMicucnYuZGF0YS5BUElfdjFfQ2xlYXJfUmVxdWVzdC5HZXRHcm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 26) = "cHNIABo2CgpDbGVhckxheWVyEigKBWxheWVyGAEgASgOMhkucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 27) = "UElfdjFfTGF5ZXJUeXBlGjgKC0NyZWF0ZUdyb3VwEikKBWdyb3VwGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 28) = "MhoucnYuZGF0YS5BUElfdjFfQ2xlYXJHcm91cBoWCghHZXRHcm91cBIKCgJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 29) = "ZBgBIAEoCRpBCghQdXRHcm91cBIKCgJpZBgBIAEoCRIpCgVncm91cBgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 30) = "CzIaLnJ2LmRhdGEuQVBJX3YxX0NsZWFyR3JvdXAaGgoMR2V0R3JvdXBJY29u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 31) = "EgoKAmlkGAEgASgJGj4KDFB1dEdyb3VwSWNvbhIKCgJpZBgBIAEoCRIUCgxj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 32) = "b250ZW50X3R5cGUYAiABKAkSDAoEaWNvbhgDIAEoDBoZCgtEZWxldGVHcm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 33) = "cBIKCgJpZBgBIAEoCRoaCgxUcmlnZ2VyR3JvdXASCgoCaWQYASABKAkaCwoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 34) = "R2V0R3JvdXBzQgkKB1JlcXVlc3QizwcKFUFQSV92MV9DbGVhcl9SZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 35) = "ZRJACgtjbGVhcl9sYXllchgBIAEoCzIpLnJ2LmRhdGEuQVBJX3YxX0NsZWFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 36) = "X1Jlc3BvbnNlLkNsZWFyTGF5ZXJIABJCCgxjcmVhdGVfZ3JvdXAYAiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 37) = "Ki5ydi5kYXRhLkFQSV92MV9DbGVhcl9SZXNwb25zZS5DcmVhdGVHcm91cEgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 38) = "EjwKCWdldF9ncm91cBgDIAEoCzInLnJ2LmRhdGEuQVBJX3YxX0NsZWFyX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 39) = "c3BvbnNlLkdldEdyb3VwSAASPAoJcHV0X2dyb3VwGAQgASgLMicucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 40) = "YS5BUElfdjFfQ2xlYXJfUmVzcG9uc2UuUHV0R3JvdXBIABJCCgxkZWxldGVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 41) = "Z3JvdXAYBSABKAsyKi5ydi5kYXRhLkFQSV92MV9DbGVhcl9SZXNwb25zZS5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 42) = "ZWxldGVHcm91cEgAEkQKDXRyaWdnZXJfZ3JvdXAYBiABKAsyKy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 43) = "LkFQSV92MV9DbGVhcl9SZXNwb25zZS5UcmlnZ2VyR3JvdXBIABI+CgpnZXRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 44) = "Z3JvdXBzGAcgASgLMigucnYuZGF0YS5BUElfdjFfQ2xlYXJfUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 45) = "R2V0R3JvdXBzSAASRQoOZ2V0X2dyb3VwX2ljb24YCCABKAsyKy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 46) = "LkFQSV92MV9DbGVhcl9SZXNwb25zZS5HZXRHcm91cEljb25IABJFCg5wdXRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 47) = "Z3JvdXBfaWNvbhgJIAEoCzIrLnJ2LmRhdGEuQVBJX3YxX0NsZWFyX1Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 48) = "bnNlLlB1dEdyb3VwSWNvbkgAGgwKCkNsZWFyTGF5ZXIaNQoIUHV0R3JvdXAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 49) = "KQoFZ3JvdXAYASABKAsyGi5ydi5kYXRhLkFQSV92MV9DbGVhckdyb3VwGg0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 50) = "C0RlbGV0ZUdyb3VwGg4KDFRyaWdnZXJHcm91cBo4CgtDcmVhdGVHcm91cBIp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 51) = "CgVncm91cBgBIAEoCzIaLnJ2LmRhdGEuQVBJX3YxX0NsZWFyR3JvdXAaNQoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 52) = "R2V0R3JvdXASKQoFZ3JvdXAYASABKAsyGi5ydi5kYXRhLkFQSV92MV9DbGVh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 53) = "ckdyb3VwGjcKCUdldEdyb3VwcxIqCgZncm91cHMYASADKAsyGi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 54) = "LkFQSV92MV9DbGVhckdyb3VwGjIKDEdldEdyb3VwSWNvbhIUCgxjb250ZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 55) = "X3R5cGUYASABKAkSDAoEaWNvbhgCIAEoDBoOCgxQdXRHcm91cEljb25CCgoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 56) = "UmVzcG9uc2VCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray58<string>, string>(ref buffer, 57) = "b3RvRGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray58<string>, string>(in buffer, 58))), new FileDescriptor[3]
		{
			ProApiV1ColorReflection.Descriptor,
			ProApiV1IdentifierReflection.Descriptor,
			ProApiV1LayerTypeReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[3]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_ClearGroup), API_v1_ClearGroup.Parser, new string[7] { "Id", "Icon", "Tint", "Layers", "StopTimelineAnnouncements", "StopTimelinePresentation", "ClearNextPresentation" }, null, new Type[1] { typeof(API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType) }, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request), API_v1_Clear_Request.Parser, new string[9] { "ClearLayer", "CreateGroup", "GetGroup", "PutGroup", "GetGroupIcon", "PutGroupIcon", "DeleteGroup", "TriggerGroup", "GetGroups" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[9]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.ClearLayer), API_v1_Clear_Request.Types.ClearLayer.Parser, new string[1] { "Layer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.CreateGroup), API_v1_Clear_Request.Types.CreateGroup.Parser, new string[1] { "Group" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.GetGroup), API_v1_Clear_Request.Types.GetGroup.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.PutGroup), API_v1_Clear_Request.Types.PutGroup.Parser, new string[2] { "Id", "Group" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.GetGroupIcon), API_v1_Clear_Request.Types.GetGroupIcon.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.PutGroupIcon), API_v1_Clear_Request.Types.PutGroupIcon.Parser, new string[3] { "Id", "ContentType", "Icon" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.DeleteGroup), API_v1_Clear_Request.Types.DeleteGroup.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.TriggerGroup), API_v1_Clear_Request.Types.TriggerGroup.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Request.Types.GetGroups), API_v1_Clear_Request.Types.GetGroups.Parser, null, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response), API_v1_Clear_Response.Parser, new string[9] { "ClearLayer", "CreateGroup", "GetGroup", "PutGroup", "DeleteGroup", "TriggerGroup", "GetGroups", "GetGroupIcon", "PutGroupIcon" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[9]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.ClearLayer), API_v1_Clear_Response.Types.ClearLayer.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.PutGroup), API_v1_Clear_Response.Types.PutGroup.Parser, new string[1] { "Group" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.DeleteGroup), API_v1_Clear_Response.Types.DeleteGroup.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.TriggerGroup), API_v1_Clear_Response.Types.TriggerGroup.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.CreateGroup), API_v1_Clear_Response.Types.CreateGroup.Parser, new string[1] { "Group" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.GetGroup), API_v1_Clear_Response.Types.GetGroup.Parser, new string[1] { "Group" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.GetGroups), API_v1_Clear_Response.Types.GetGroups.Parser, new string[1] { "Groups" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.GetGroupIcon), API_v1_Clear_Response.Types.GetGroupIcon.Parser, new string[2] { "ContentType", "Icon" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Clear_Response.Types.PutGroupIcon), API_v1_Clear_Response.Types.PutGroupIcon.Parser, null, null, null, null, null)
			})
		}));
	}
}
