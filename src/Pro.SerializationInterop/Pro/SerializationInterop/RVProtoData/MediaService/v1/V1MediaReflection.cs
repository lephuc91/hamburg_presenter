using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Pro.SerializationInterop.RVProtoData.MediaService.v1;

public static class V1MediaReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static V1MediaReflection()
	{
		_003C_003Ey__InlineArray56<string> buffer = default(_003C_003Ey__InlineArray56<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 0) = "Cg52MS1tZWRpYS5wcm90bxIIbWVkaWEudjEaFnYxLWhlbHBlci1jb21tb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 1) = "cHJvdG8ixgQKDE5vdGlmaWNhdGlvbhI7Cg9tZWRpYV9yZWZlcmVuY2UYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 2) = "KAsyIC5oZWxwZXIuY29tbW9uLnYxLk1lZGlhUmVmZXJlbmNlSAASSgoUdW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 3) = "dWJzY3JpYmVfY29tcGxldGUYAiABKAsyKi5tZWRpYS52MS5Ob3RpZmljYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 4) = "b24uVW5zdWJzY3JpYmVDb21wbGV0ZUgAEjUKCWNvbm5lY3RlZBgDIAEoCzIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 5) = "Lm1lZGlhLnYxLk5vdGlmaWNhdGlvbi5Db25uZWN0ZWRIABI7CgxkaXNjb25u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 6) = "ZWN0ZWQYBCABKAsyIy5tZWRpYS52MS5Ob3RpZmljYXRpb24uRGlzY29ubmVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 7) = "dGVkSAASOwoMdW5yZXNwb25zaXZlGAUgASgLMiMubWVkaWEudjEuTm90aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 8) = "Y2F0aW9uLlVucmVzcG9uc2l2ZUgAEj8KEWdlbmVyYXRpb25fc3RhdHVzGAYg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 9) = "ASgLMiIuaGVscGVyLmNvbW1vbi52MS5HZW5lcmF0aW9uU3RhdHVzSAAaFQoT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 10) = "VW5zdWJzY3JpYmVDb21wbGV0ZRoOCgxEaXNjb25uZWN0ZWQaNwoJQ29ubmVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 11) = "dGVkEioKB3ZlcnNpb24YASABKAsyGS5oZWxwZXIuY29tbW9uLnYxLlZlcnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 12) = "b24aSwoMVW5yZXNwb25zaXZlEioKB3JlcXVlc3QYASABKAsyGS5tZWRpYS52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 13) = "MS5SZXF1ZXN0RW52ZWxvcGUSDwoHc2Vjb25kcxgCIAEoDUIOCgxub3RpZmlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 14) = "YXRpb24irgYKD1JlcXVlc3RFbnZlbG9wZRJGChVjaGFuZ2Vfc2hvd19kaXJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 15) = "Y3RvcnkYASABKAsyJS5oZWxwZXIuY29tbW9uLnYxLkNoYW5nZVNob3dEaXJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 16) = "Y3RvcnlIABJKChNnZXRfbWVkaWFfcmVmZXJlbmNlGAIgASgLMisubWVkaWEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 17) = "djEuUmVxdWVzdEVudmVsb3BlLkdldE1lZGlhUmVmZXJlbmNlSAASQgoTYWRk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 18) = "X21lZGlhX3JlZmVyZW5jZRgDIAEoCzIjLmhlbHBlci5jb21tb24udjEuQWRk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 19) = "TWVkaWFSZWZlcmVuY2VIABJOChlkdXBsaWNhdGVfbWVkaWFfcmVmZXJlbmNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 20) = "GAQgASgLMikuaGVscGVyLmNvbW1vbi52MS5EdXBsaWNhdGVNZWRpYVJlZmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 21) = "ZW5jZUgAEkUKFGFwcGx5X3RyYW5zZm9ybWF0aW9uGAUgASgLMiUuaGVscGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 22) = "LmNvbW1vbi52MS5BcHBseVRyYW5zZm9ybWF0aW9uSAASSQoWcmVtb3ZlX21l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 23) = "ZGlhX3JlZmVyZW5jZRgGIAEoCzInLmhlbHBlci5jb21tb24udjEuUmVtb3Zl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 24) = "TWVkaWFSZWZlcmVuY2VzSAASSgoXdHJpZ2dlcl9tZWRpYV9yZWZlcmVuY2UY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 25) = "ByABKAsyJy5oZWxwZXIuY29tbW9uLnYxLlRyaWdnZXJNZWRpYVJlZmVyZW5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 26) = "ZUgAEiYKBHBpbmcYCCABKAsyFi5oZWxwZXIuY29tbW9uLnYxLlBpbmdIABI/";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 27) = "ChF1cGRhdGVfd29ya3NwYWNlcxgJIAEoCzIiLmhlbHBlci5jb21tb24udjEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 28) = "VXBkYXRlV29ya3NwYWNlc0gAEj0KEHBhdXNlX2dlbmVyYXRpb24YCiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 29) = "IS5oZWxwZXIuY29tbW9uLnYxLlBhdXNlR2VuZXJhdGlvbkgAEj8KEXJlc3Vt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 30) = "ZV9nZW5lcmF0aW9uGAsgASgLMiIuaGVscGVyLmNvbW1vbi52MS5SZXN1bWVH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 31) = "ZW5lcmF0aW9uSAAaIQoRR2V0TWVkaWFSZWZlcmVuY2USDAoEdXVpZBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 32) = "CUIJCgdyZXF1ZXN0Ir8HChBSZXNwb25zZUVudmVsb3BlEjEKAm9rGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 33) = "MiMubWVkaWEudjEuUmVzcG9uc2VFbnZlbG9wZS5SZXNwb25zZUgAEi8KBWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 34) = "cm9yGAIgASgLMh4uaGVscGVyLmNvbW1vbi52MS5SZXF1ZXN0RXJyb3JIABod";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 35) = "ChtDaGFuZ2VTaG93RGlyZWN0b3J5UmVzcG9uc2UaTAoZR2V0TWVkaWFSZWZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 36) = "cmVuY2VSZXNwb25zZRIvCgVzdGF0ZRgBIAEoCzIgLmhlbHBlci5jb21tb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 37) = "djEuTWVkaWFSZWZlcmVuY2UazwUKCFJlc3BvbnNlEkgKBmNoYW5nZRgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 38) = "CzI2Lm1lZGlhLnYxLlJlc3BvbnNlRW52ZWxvcGUuQ2hhbmdlU2hvd0RpcmVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 39) = "dG9yeVJlc3BvbnNlSAASQwoDZ2V0GAIgASgLMjQubWVkaWEudjEuUmVzcG9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 40) = "c2VFbnZlbG9wZS5HZXRNZWRpYVJlZmVyZW5jZVJlc3BvbnNlSAASOgoDYWRk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 41) = "GAMgASgLMisuaGVscGVyLmNvbW1vbi52MS5BZGRNZWRpYVJlZmVyZW5jZVJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 42) = "c3BvbnNlSAASRgoJZHVwbGljYXRlGAQgASgLMjEuaGVscGVyLmNvbW1vbi52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 43) = "MS5EdXBsaWNhdGVNZWRpYVJlZmVyZW5jZVJlc3BvbnNlSAASPgoFYXBwbHkY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 44) = "BSABKAsyLS5oZWxwZXIuY29tbW9uLnYxLkFwcGx5VHJhbnNmb3JtYXRpb25S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 45) = "ZXNwb25zZUgAEkAKBnJlbW92ZRgGIAEoCzIuLmhlbHBlci5jb21tb24udjEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 46) = "UmVtb3ZlTWVkaWFSZWZlcmVuY2VSZXNwb25zZUgAEkIKB3RyaWdnZXIYByAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 47) = "KAsyLy5oZWxwZXIuY29tbW9uLnYxLlRyaWdnZXJNZWRpYVJlZmVyZW5jZVJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 48) = "c3BvbnNlSAASJgoEcG9uZxgIIAEoCzIWLmhlbHBlci5jb21tb24udjEuUG9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 49) = "Z0gAEjwKBnVwZGF0ZRgJIAEoCzIqLmhlbHBlci5jb21tb24udjEuVXBkYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 50) = "V29ya3NwYWNlc1Jlc3BvbnNlSAASOgoFcGF1c2UYCiABKAsyKS5oZWxwZXIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 51) = "Y29tbW9uLnYxLlBhdXNlR2VuZXJhdGlvblJlc3BvbnNlSAASPAoGcmVzdW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 52) = "GAsgASgLMiouaGVscGVyLmNvbW1vbi52MS5SZXN1bWVHZW5lcmF0aW9uUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 53) = "cG9uc2VIAEIKCghyZXNwb25zZUIICgZyZXN1bHRCUaoCNFByby5TZXJpYWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 54) = "emF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YS5NZWRpYVNlcnZpY2UudjG6AhdS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray56<string>, string>(ref buffer, 55) = "VkRhdGFfTWVkaWFTZXJ2aWNlX3YxX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray56<string>, string>(in buffer, 56))), new FileDescriptor[1] { V1HelperCommonReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[3]
		{
			new GeneratedClrTypeInfo(typeof(Notification), Notification.Parser, new string[6] { "MediaReference", "UnsubscribeComplete", "Connected", "Disconnected", "Unresponsive", "GenerationStatus" }, new string[1] { "Notification" }, null, null, new GeneratedClrTypeInfo[4]
			{
				new GeneratedClrTypeInfo(typeof(Notification.Types.UnsubscribeComplete), Notification.Types.UnsubscribeComplete.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Disconnected), Notification.Types.Disconnected.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Connected), Notification.Types.Connected.Parser, new string[1] { "Version" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Unresponsive), Notification.Types.Unresponsive.Parser, new string[2] { "Request", "Seconds" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(RequestEnvelope), RequestEnvelope.Parser, new string[11]
			{
				"ChangeShowDirectory", "GetMediaReference", "AddMediaReference", "DuplicateMediaReference", "ApplyTransformation", "RemoveMediaReference", "TriggerMediaReference", "Ping", "UpdateWorkspaces", "PauseGeneration",
				"ResumeGeneration"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.GetMediaReference), RequestEnvelope.Types.GetMediaReference.Parser, new string[1] { "Uuid" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(ResponseEnvelope), ResponseEnvelope.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.ChangeShowDirectoryResponse), ResponseEnvelope.Types.ChangeShowDirectoryResponse.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.GetMediaReferenceResponse), ResponseEnvelope.Types.GetMediaReferenceResponse.Parser, new string[1] { "State" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response), ResponseEnvelope.Types.Response.Parser, new string[11]
				{
					"Change", "Get", "Add", "Duplicate", "Apply", "Remove", "Trigger", "Pong", "Update", "Pause",
					"Resume"
				}, new string[1] { "Response" }, null, null, null)
			})
		}));
	}
}
