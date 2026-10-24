using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Helper.Workspace.V1;

public static class V1HelperWorkspaceReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static V1HelperWorkspaceReflection()
	{
		_003C_003Ey__InlineArray60<string> buffer = default(_003C_003Ey__InlineArray60<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 0) = "Chl2MS1oZWxwZXItd29ya3NwYWNlLnByb3RvEhNoZWxwZXIud29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 1) = "LnYxGhZ2MS1oZWxwZXItY29tbW9uLnByb3RvIpwBCgxOb3RpZmljYXRpb24S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 2) = "OwoPbWVkaWFfcmVmZXJlbmNlGAEgASgLMiAuaGVscGVyLmNvbW1vbi52MS5N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 3) = "ZWRpYVJlZmVyZW5jZUgAEj8KEWdlbmVyYXRpb25fc3RhdHVzGAIgASgLMiIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 4) = "aGVscGVyLmNvbW1vbi52MS5HZW5lcmF0aW9uU3RhdHVzSABCDgoMbm90aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 5) = "Y2F0aW9uIq0HCg9SZXF1ZXN0RW52ZWxvcGUSOwoGaGVhZGVyGAEgASgLMisu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 6) = "aGVscGVyLndvcmtzcGFjZS52MS5SZXF1ZXN0RW52ZWxvcGUuSGVhZGVyEjsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 7) = "BXN0YXJ0GAIgASgLMiouaGVscGVyLndvcmtzcGFjZS52MS5SZXF1ZXN0RW52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 8) = "ZWxvcGUuU3RhcnRIABJGChVjaGFuZ2Vfc2hvd19kaXJlY3RvcnkYAyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 9) = "JS5oZWxwZXIuY29tbW9uLnYxLkNoYW5nZVNob3dEaXJlY3RvcnlIABIyCgNh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 10) = "ZGQYBCABKAsyIy5oZWxwZXIuY29tbW9uLnYxLkFkZE1lZGlhUmVmZXJlbmNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 11) = "SAASPgoJZHVwbGljYXRlGAUgASgLMikuaGVscGVyLmNvbW1vbi52MS5EdXBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 12) = "aWNhdGVNZWRpYVJlZmVyZW5jZUgAEjYKBWFwcGx5GAYgASgLMiUuaGVscGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 13) = "LmNvbW1vbi52MS5BcHBseVRyYW5zZm9ybWF0aW9uSAASOQoGcmVtb3ZlGAcg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 14) = "ASgLMicuaGVscGVyLmNvbW1vbi52MS5SZW1vdmVNZWRpYVJlZmVyZW5jZXNI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 15) = "ABI6Cgd0cmlnZ2VyGAggASgLMicuaGVscGVyLmNvbW1vbi52MS5UcmlnZ2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 16) = "TWVkaWFSZWZlcmVuY2VIABImCgRwaW5nGAkgASgLMhYuaGVscGVyLmNvbW1v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 17) = "bi52MS5QaW5nSAASPwoRdXBkYXRlX3dvcmtzcGFjZXMYCiABKAsyIi5oZWxw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 18) = "ZXIuY29tbW9uLnYxLlVwZGF0ZVdvcmtzcGFjZXNIABI9ChBwYXVzZV9nZW5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 19) = "cmF0aW9uGAsgASgLMiEuaGVscGVyLmNvbW1vbi52MS5QYXVzZUdlbmVyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 20) = "b25IABI/ChFyZXN1bWVfZ2VuZXJhdGlvbhgMIAEoCzIiLmhlbHBlci5jb21t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 21) = "b24udjEuUmVzdW1lR2VuZXJhdGlvbkgAEkIKCWdldF9zdGF0ZRgNIAEoCzIt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 22) = "LmhlbHBlci53b3Jrc3BhY2UudjEuUmVxdWVzdEVudmVsb3BlLkdldFN0YXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 23) = "SAAaWwoFU3RhcnQSOgoMcHJvZHVjdF9pbmZvGAEgASgLMiQuaGVscGVyLmNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 24) = "bW1vbi52MS5Qcm9kdWN0SW5mb3JtYXRpb24SFgoOc2hvd19kaXJlY3RvcnkY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 25) = "AiABKAkaFAoGSGVhZGVyEgoKAmlkGAEgASgJGgoKCEdldFN0YXRlQgkKB3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 26) = "cXVlc3Qi+wkKEFJlc3BvbnNlRW52ZWxvcGUSPAoGaGVhZGVyGAEgASgLMiwu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 27) = "aGVscGVyLndvcmtzcGFjZS52MS5SZXNwb25zZUVudmVsb3BlLkhlYWRlchI8";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 28) = "CgJvaxgCIAEoCzIuLmhlbHBlci53b3Jrc3BhY2UudjEuUmVzcG9uc2VFbnZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 29) = "bG9wZS5SZXNwb25zZUgAEi8KBWVycm9yGAMgASgLMh4uaGVscGVyLmNvbW1v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 30) = "bi52MS5SZXF1ZXN0RXJyb3JIABoUCgZIZWFkZXISCgoCaWQYASABKAkamQgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 31) = "CFJlc3BvbnNlEk0KBXN0YXJ0GAEgASgLMjwuaGVscGVyLndvcmtzcGFjZS52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 32) = "MS5SZXNwb25zZUVudmVsb3BlLlJlc3BvbnNlLlN0YXJ0UmVzcG9uc2VIABJr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 33) = "ChVjaGFuZ2Vfc2hvd19kaXJlY3RvcnkYAiABKAsySi5oZWxwZXIud29ya3Nw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 34) = "YWNlLnYxLlJlc3BvbnNlRW52ZWxvcGUuUmVzcG9uc2UuQ2hhbmdlU2hvd0Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 35) = "cmVjdG9yeVJlc3BvbnNlSAASOgoDYWRkGAMgASgLMisuaGVscGVyLmNvbW1v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 36) = "bi52MS5BZGRNZWRpYVJlZmVyZW5jZVJlc3BvbnNlSAASRgoJZHVwbGljYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 37) = "GAQgASgLMjEuaGVscGVyLmNvbW1vbi52MS5EdXBsaWNhdGVNZWRpYVJlZmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 38) = "ZW5jZVJlc3BvbnNlSAASPgoFYXBwbHkYBSABKAsyLS5oZWxwZXIuY29tbW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 39) = "LnYxLkFwcGx5VHJhbnNmb3JtYXRpb25SZXNwb25zZUgAEkAKBnJlbW92ZRgG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 40) = "IAEoCzIuLmhlbHBlci5jb21tb24udjEuUmVtb3ZlTWVkaWFSZWZlcmVuY2VS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 41) = "ZXNwb25zZUgAEkIKB3RyaWdnZXIYByABKAsyLy5oZWxwZXIuY29tbW9uLnYx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 42) = "LlRyaWdnZXJNZWRpYVJlZmVyZW5jZVJlc3BvbnNlSAASJgoEcG9uZxgIIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 43) = "CzIWLmhlbHBlci5jb21tb24udjEuUG9uZ0gAEkcKEXVwZGF0ZV93b3Jrc3Bh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 44) = "Y2VzGAkgASgLMiouaGVscGVyLmNvbW1vbi52MS5VcGRhdGVXb3Jrc3BhY2Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 45) = "UmVzcG9uc2VIABI6CgVwYXVzZRgKIAEoCzIpLmhlbHBlci5jb21tb24udjEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 46) = "UGF1c2VHZW5lcmF0aW9uUmVzcG9uc2VIABI8CgZyZXN1bWUYCyABKAsyKi5o";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 47) = "ZWxwZXIuY29tbW9uLnYxLlJlc3VtZUdlbmVyYXRpb25SZXNwb25zZUgAElQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 48) = "CWdldF9zdGF0ZRgMIAEoCzI/LmhlbHBlci53b3Jrc3BhY2UudjEuUmVzcG9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 49) = "c2VFbnZlbG9wZS5SZXNwb25zZS5HZXRTdGF0ZVJlc3BvbnNlSAAaSwoNU3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 50) = "cnRSZXNwb25zZRI6ChBtZWRpYV9yZWZlcmVuY2VzGAEgAygLMiAuaGVscGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 51) = "LmNvbW1vbi52MS5NZWRpYVJlZmVyZW5jZRpZChtDaGFuZ2VTaG93RGlyZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 52) = "b3J5UmVzcG9uc2USOgoQbWVkaWFfcmVmZXJlbmNlcxgBIAMoCzIgLmhlbHBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 53) = "ci5jb21tb24udjEuTWVkaWFSZWZlcmVuY2UaEgoQR2V0U3RhdGVSZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 54) = "ZUIKCghyZXNwb25zZUIICgZyZXN1bHQiUwoNQ2xpZW50TWVzc2FnZRI3Cgdy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 55) = "ZXF1ZXN0GAEgASgLMiQuaGVscGVyLndvcmtzcGFjZS52MS5SZXF1ZXN0RW52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 56) = "ZWxvcGVIAEIJCgdwYXlsb2FkIpABCg1TZXJ2ZXJNZXNzYWdlEjkKCHJlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 57) = "bnNlGAEgASgLMiUuaGVscGVyLndvcmtzcGFjZS52MS5SZXNwb25zZUVudmVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 58) = "b3BlSAASOQoMbm90aWZpY2F0aW9uGAIgASgLMiEuaGVscGVyLndvcmtzcGFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray60<string>, string>(ref buffer, 59) = "ZS52MS5Ob3RpZmljYXRpb25IAEIJCgdwYXlsb2FkYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray60<string>, string>(in buffer, 60))), new FileDescriptor[1] { V1HelperCommonReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(Notification), Notification.Parser, new string[2] { "MediaReference", "GenerationStatus" }, new string[1] { "Notification" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(RequestEnvelope), RequestEnvelope.Parser, new string[13]
			{
				"Header", "Start", "ChangeShowDirectory", "Add", "Duplicate", "Apply", "Remove", "Trigger", "Ping", "UpdateWorkspaces",
				"PauseGeneration", "ResumeGeneration", "GetState"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.Start), RequestEnvelope.Types.Start.Parser, new string[2] { "ProductInfo", "ShowDirectory" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.Header), RequestEnvelope.Types.Header.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.GetState), RequestEnvelope.Types.GetState.Parser, null, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(ResponseEnvelope), ResponseEnvelope.Parser, new string[3] { "Header", "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Header), ResponseEnvelope.Types.Header.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response), ResponseEnvelope.Types.Response.Parser, new string[12]
				{
					"Start", "ChangeShowDirectory", "Add", "Duplicate", "Apply", "Remove", "Trigger", "Pong", "UpdateWorkspaces", "Pause",
					"Resume", "GetState"
				}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response.Types.StartResponse), ResponseEnvelope.Types.Response.Types.StartResponse.Parser, new string[1] { "MediaReferences" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response.Types.ChangeShowDirectoryResponse), ResponseEnvelope.Types.Response.Types.ChangeShowDirectoryResponse.Parser, new string[1] { "MediaReferences" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response.Types.GetStateResponse), ResponseEnvelope.Types.Response.Types.GetStateResponse.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(ClientMessage), ClientMessage.Parser, new string[1] { "Request" }, new string[1] { "Payload" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(ServerMessage), ServerMessage.Parser, new string[2] { "Response", "Notification" }, new string[1] { "Payload" }, null, null, null)
		}));
	}
}
