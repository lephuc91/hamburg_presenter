using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1LinkReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1LinkReflection()
	{
		_003C_003Ey__InlineArray55<string> buffer = default(_003C_003Ey__InlineArray55<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 0) = "ChJwcm9BcGlWMUxpbmsucHJvdG8SB3J2LmRhdGEaEXJ2dGltZXN0YW1wLnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 1) = "b3RvGgp1dWlkLnByb3RvIi4KEkFQSV92MV9Hcm91cE1lbWJlchIKCgJpcBgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 2) = "IAEoCRIMCgRwb3J0GAIgASgNIssEChhBUElfdjFfR3JvdXBNZW1iZXJTdGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 3) = "dXMSCgoCaXAYASABKAkSDAoEcG9ydBgCIAEoDRIMCgRuYW1lGAMgASgJElUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 4) = "CHBsYXRmb3JtGAQgASgOMkMucnYuZGF0YS5BUElfdjFfR3JvdXBNZW1iZXJT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 5) = "dGF0dXMuQVBJX3YxX0dyb3VwTWVtYmVyU3RhdHVzX1BsYXRmb3JtEhIKCm9z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 6) = "X3ZlcnNpb24YBSABKAkSGAoQaG9zdF9kZXNjcmlwdGlvbhgGIAEoCRITCgth";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 7) = "cGlfdmVyc2lvbhgHIAEoCRJmChFjb25uZWN0aW9uX3N0YXR1cxgIIAEoDjJL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 8) = "LnJ2LmRhdGEuQVBJX3YxX0dyb3VwTWVtYmVyU3RhdHVzLkFQSV92MV9Hcm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 9) = "cE1lbWJlclN0YXR1c19Db25uZWN0aW9uU3RhdHVzIo8BCilBUElfdjFfR3Jv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 10) = "dXBNZW1iZXJTdGF0dXNfQ29ubmVjdGlvblN0YXR1cxIdChlDT05ORUNUSU9O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 11) = "X1NUQVRVU19VTktOT1dOEAASHwobQ09OTkVDVElPTl9TVEFUVVNfQ09OTkVD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 12) = "VEVEEAESIgoeQ09OTkVDVElPTl9TVEFUVVNfRElTQ09OTkVDVEVEEAIicwoh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 13) = "QVBJX3YxX0dyb3VwTWVtYmVyU3RhdHVzX1BsYXRmb3JtEhQKEFBMQVRGT1JN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 14) = "X1VOS05PV04QABISCg5QTEFURk9STV9NQUNPUxABEhIKDlBMQVRGT1JNX1dJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 15) = "TjMyEAISEAoMUExBVEZPUk1fV0VCEAMitAEKFkFQSV92MV9Hcm91cERlZmlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 16) = "aXRpb24SJQoJdGltZXN0YW1wGAEgASgLMhIucnYuZGF0YS5UaW1lc3RhbXAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 17) = "DgoGc2VjcmV0GAIgASgJEgwKBG5hbWUYAyABKAkSLAoHbWVtYmVycxgEIAMo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 18) = "CzIbLnJ2LmRhdGEuQVBJX3YxX0dyb3VwTWVtYmVyEicKEGdyb3VwX2lkZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 19) = "aWZpZXIYBSABKAsyDS5ydi5kYXRhLlVVSUQiqAQKE0FQSV92MV9MaW5rX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 20) = "cXVlc3QSOwoJaGVhcnRiZWF0GAEgASgLMiYucnYuZGF0YS5BUElfdjFfTGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 21) = "a19SZXF1ZXN0LkhlYXJ0YmVhdEgAEjUKBnN0YXR1cxgCIAEoCzIjLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 22) = "dGEuQVBJX3YxX0xpbmtfUmVxdWVzdC5TdGF0dXNIABI8CgphZGRfbWVtYmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 23) = "GAMgASgLMiYucnYuZGF0YS5BUElfdjFfTGlua19SZXF1ZXN0LkFkZE1lbWJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 24) = "ckgAEkIKDXJlbW92ZV9tZW1iZXIYBCABKAsyKS5ydi5kYXRhLkFQSV92MV9M";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 25) = "aW5rX1JlcXVlc3QuUmVtb3ZlTWVtYmVySAAaNAoJSGVhcnRiZWF0EgwKBHBv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 26) = "cnQYASABKA0SGQoRaWZfbW9kaWZpZWRfc2luY2UYAiABKAkaCAoGU3RhdHVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 27) = "GooBCglBZGRNZW1iZXISOwoQZ3JvdXBfZGVmaW5pdGlvbhgBIAEoCzIfLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 28) = "LmRhdGEuQVBJX3YxX0dyb3VwRGVmaW5pdGlvbkgAEjUKDm1lbWJlcl9kZXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 29) = "aWxzGAIgASgLMhsucnYuZGF0YS5BUElfdjFfR3JvdXBNZW1iZXJIAEIJCgdB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 30) = "ZGRUeXBlGkMKDFJlbW92ZU1lbWJlchIzCg5tZW1iZXJfZGV0YWlscxgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 31) = "CzIbLnJ2LmRhdGEuQVBJX3YxX0dyb3VwTWVtYmVyQgkKB1JlcXVlc3QivgcK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 32) = "FEFQSV92MV9MaW5rX1Jlc3BvbnNlEjwKCWhlYXJ0YmVhdBgBIAEoCzInLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 33) = "LmRhdGEuQVBJX3YxX0xpbmtfUmVzcG9uc2UuSGVhcnRiZWF0SAASNgoGc3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 34) = "dHVzGAIgASgLMiQucnYuZGF0YS5BUElfdjFfTGlua19SZXNwb25zZS5TdGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 35) = "dXNIABI9CgphZGRfbWVtYmVyGAMgASgLMicucnYuZGF0YS5BUElfdjFfTGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 36) = "a19SZXNwb25zZS5BZGRNZW1iZXJIABJDCg1yZW1vdmVfbWVtYmVyGAQgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 37) = "MioucnYuZGF0YS5BUElfdjFfTGlua19SZXNwb25zZS5SZW1vdmVNZW1iZXJI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 38) = "ABp5CglIZWFydGJlYXQSOQoQZ3JvdXBfZGVmaW5pdGlvbhgBIAEoCzIfLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 39) = "LmRhdGEuQVBJX3YxX0dyb3VwRGVmaW5pdGlvbhIxCgZzdGF0dXMYAiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 40) = "IS5ydi5kYXRhLkFQSV92MV9Hcm91cE1lbWJlclN0YXR1cxpYCgZTdGF0dXMS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 41) = "OQoQZ3JvdXBfZGVmaW5pdGlvbhgBIAEoCzIfLnJ2LmRhdGEuQVBJX3YxX0dy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 42) = "b3VwRGVmaW5pdGlvbhITCgttZW1iZXJfbmFtZRgCIAEoCRq6AwoJQWRkTWVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 43) = "YmVyEjsKEGdyb3VwX2RlZmluaXRpb24YASABKAsyHy5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 44) = "MV9Hcm91cERlZmluaXRpb25IABJOCgZhY2NlcHQYAiABKAsyPC5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 45) = "LkFQSV92MV9MaW5rX1Jlc3BvbnNlLkFkZE1lbWJlci5SZW1vdGVNYWNoaW5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 46) = "QWNjZXB0c0gAEk8KB2RlY2xpbmUYAyABKAsyPC5ydi5kYXRhLkFQSV92MV9M";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 47) = "aW5rX1Jlc3BvbnNlLkFkZE1lbWJlci5SZW1vdGVNYWNoaW5lRGVjbGluZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 48) = "GhYKFFJlbW90ZU1hY2hpbmVBY2NlcHRzGqwBChRSZW1vdGVNYWNoaW5lRGVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 49) = "bGluZRJaCgZyZWFzb24YASABKA4ySi5ydi5kYXRhLkFQSV92MV9MaW5rX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 50) = "c3BvbnNlLkFkZE1lbWJlci5SZW1vdGVNYWNoaW5lRGVjbGluZS5EZWNsaW5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 51) = "UmVhc29uIjgKDURlY2xpbmVSZWFzb24SFAoQQUxSRUFEWV9JTl9HUk9VUBAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 52) = "EhEKDVVTRVJfREVDTElORUQQAUIICgZSZXN1bHQaDgoMUmVtb3ZlTWVtYmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 53) = "QgoKCFJlc3BvbnNlQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 54) = "UlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray55<string>, string>(in buffer, 55))), new FileDescriptor[2]
		{
			RvtimestampReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_GroupMember), API_v1_GroupMember.Parser, new string[2] { "Ip", "Port" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_GroupMemberStatus), API_v1_GroupMemberStatus.Parser, new string[8] { "Ip", "Port", "Name", "Platform", "OsVersion", "HostDescription", "ApiVersion", "ConnectionStatus" }, null, new Type[2]
			{
				typeof(API_v1_GroupMemberStatus.Types.API_v1_GroupMemberStatus_ConnectionStatus),
				typeof(API_v1_GroupMemberStatus.Types.API_v1_GroupMemberStatus_Platform)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_GroupDefinition), API_v1_GroupDefinition.Parser, new string[5] { "Timestamp", "Secret", "Name", "Members", "GroupIdentifier" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Link_Request), API_v1_Link_Request.Parser, new string[4] { "Heartbeat", "Status", "AddMember", "RemoveMember" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[4]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Link_Request.Types.Heartbeat), API_v1_Link_Request.Types.Heartbeat.Parser, new string[2] { "Port", "IfModifiedSince" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Link_Request.Types.Status), API_v1_Link_Request.Types.Status.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Link_Request.Types.AddMember), API_v1_Link_Request.Types.AddMember.Parser, new string[2] { "GroupDefinition", "MemberDetails" }, new string[1] { "AddType" }, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Link_Request.Types.RemoveMember), API_v1_Link_Request.Types.RemoveMember.Parser, new string[1] { "MemberDetails" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Link_Response), API_v1_Link_Response.Parser, new string[4] { "Heartbeat", "Status", "AddMember", "RemoveMember" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[4]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Link_Response.Types.Heartbeat), API_v1_Link_Response.Types.Heartbeat.Parser, new string[2] { "GroupDefinition", "Status" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Link_Response.Types.Status), API_v1_Link_Response.Types.Status.Parser, new string[2] { "GroupDefinition", "MemberName" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Link_Response.Types.AddMember), API_v1_Link_Response.Types.AddMember.Parser, new string[3] { "GroupDefinition", "Accept", "Decline" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(API_v1_Link_Response.Types.AddMember.Types.RemoteMachineAccepts), API_v1_Link_Response.Types.AddMember.Types.RemoteMachineAccepts.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(API_v1_Link_Response.Types.AddMember.Types.RemoteMachineDecline), API_v1_Link_Response.Types.AddMember.Types.RemoteMachineDecline.Parser, new string[1] { "Reason" }, null, new Type[1] { typeof(API_v1_Link_Response.Types.AddMember.Types.RemoteMachineDecline.Types.DeclineReason) }, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(API_v1_Link_Response.Types.RemoveMember), API_v1_Link_Response.Types.RemoveMember.Parser, null, null, null, null, null)
			})
		}));
	}
}
