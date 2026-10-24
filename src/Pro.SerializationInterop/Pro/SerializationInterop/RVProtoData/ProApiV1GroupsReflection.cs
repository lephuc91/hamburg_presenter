using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1GroupsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1GroupsReflection()
	{
		_003C_003Ey__InlineArray17<string> buffer = default(_003C_003Ey__InlineArray17<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 0) = "ChRwcm9BcGlWMUdyb3Vwcy5wcm90bxIHcnYuZGF0YRoTcHJvQXBpVjFDb2xv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 1) = "ci5wcm90bxoYcHJvQXBpVjFJZGVudGlmaWVyLnByb3RvIt0BChVBUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 2) = "R3JvdXBzX1JlcXVlc3QSRgoOZ3JvdXBzX3JlcXVlc3QYASABKAsyLC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 3) = "YXRhLkFQSV92MV9Hcm91cHNfUmVxdWVzdC5Hcm91cHNSZXF1ZXN0SAASRAoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 4) = "dHJpZ2dlcl9ncm91cBgCIAEoCzIrLnJ2LmRhdGEuQVBJX3YxX0dyb3Vwc19S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 5) = "ZXF1ZXN0LlRyaWdnZXJHcm91cEgAGg8KDUdyb3Vwc1JlcXVlc3QaGgoMVHJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 6) = "Z2dlckdyb3VwEgoKAmlkGAEgASgJQgkKB1JlcXVlc3Qi6gIKFkFQSV92MV9H";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 7) = "cm91cHNfUmVzcG9uc2USPwoGZ3JvdXBzGAEgASgLMi0ucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 8) = "djFfR3JvdXBzX1Jlc3BvbnNlLkdyb3Vwc1JlcXVlc3RIABJFCg10cmlnZ2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 9) = "X2dyb3VwGAIgASgLMiwucnYuZGF0YS5BUElfdjFfR3JvdXBzX1Jlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 10) = "LlRyaWdnZXJHcm91cEgAGqsBCg1Hcm91cHNSZXF1ZXN0EkMKBmdyb3VwcxgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 11) = "IAMoCzIzLnJ2LmRhdGEuQVBJX3YxX0dyb3Vwc19SZXNwb25zZS5Hcm91cHNS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 12) = "ZXF1ZXN0Lkdyb3VwGlUKBUdyb3VwEiYKAmlkGAEgASgLMhoucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 13) = "UElfdjFfSWRlbnRpZmllchIkCgVjb2xvchgCIAEoCzIVLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 14) = "X3YxX0NvbG9yGg4KDFRyaWdnZXJHcm91cEIKCghSZXNwb25zZUI0+AEBqgIk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 15) = "UHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 16) = "X2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray17<string>, string>(in buffer, 17))), new FileDescriptor[2]
		{
			ProApiV1ColorReflection.Descriptor,
			ProApiV1IdentifierReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Groups_Request), API_v1_Groups_Request.Parser, new string[2] { "GroupsRequest", "TriggerGroup" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Groups_Request.Types.GroupsRequest), API_v1_Groups_Request.Types.GroupsRequest.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Groups_Request.Types.TriggerGroup), API_v1_Groups_Request.Types.TriggerGroup.Parser, new string[1] { "Id" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Groups_Response), API_v1_Groups_Response.Parser, new string[2] { "Groups", "TriggerGroup" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Groups_Response.Types.GroupsRequest), API_v1_Groups_Response.Types.GroupsRequest.Parser, new string[1] { "Groups" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(API_v1_Groups_Response.Types.GroupsRequest.Types.Group), API_v1_Groups_Response.Types.GroupsRequest.Types.Group.Parser, new string[2] { "Id", "Color" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(API_v1_Groups_Response.Types.TriggerGroup), API_v1_Groups_Response.Types.TriggerGroup.Parser, null, null, null, null, null)
			})
		}));
	}
}
