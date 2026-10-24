using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Local;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace.Call;

public static class WorkspaceCallsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static WorkspaceCallsReflection()
	{
		_003C_003Ey__InlineArray32<string> buffer = default(_003C_003Ey__InlineArray32<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 0) = "ChV3b3Jrc3BhY2UuY2FsbHMucHJvdG8SDndvcmtzcGFjZS5jYWxsGh53b3Jr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 1) = "c3BhY2UuZW50aXRpZXMubG9jYWwucHJvdG8aH3dvcmtzcGFjZS5lbnRpdGll";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 2) = "cy5yZW1vdGUucHJvdG8iWwoFRXJyb3ISKAoEY29kZRgBIAEoDjIaLndvcmtz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 3) = "cGFjZS5jYWxsLkVycm9yLkNvZGUSEwoLZGVzY3JpcHRpb24YAiABKAkiEwoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 4) = "Q29kZRILCgdVTktOT1dOEAAirwEKCU9wZW5Mb2NhbBItCgl3b3Jrc3BhY2UY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 5) = "ASABKAsyGi53b3Jrc3BhY2UubG9jYWwuV29ya3NwYWNlGnMKBlJlc3VsdBIx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 6) = "CgJvaxgBIAEoCzIjLndvcmtzcGFjZS5jYWxsLk9wZW5Mb2NhbC5SZXN1bHQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 7) = "T2tIABImCgVlcnJvchgCIAEoCzIVLndvcmtzcGFjZS5jYWxsLkVycm9ySAAa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 8) = "BAoCT2tCCAoGcmVzdWx0Is8BCgpPcGVuUmVtb3RlEgwKBHV1aWQYASABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 9) = "DAoEcGF0aBgCIAEoCRqkAQoGUmVzdWx0EjIKAm9rGAEgASgLMiQud29ya3Nw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 10) = "YWNlLmNhbGwuT3BlblJlbW90ZS5SZXN1bHQuT2tIABImCgVlcnJvchgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 11) = "CzIVLndvcmtzcGFjZS5jYWxsLkVycm9ySAAaNAoCT2sSLgoJd29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 12) = "GAEgASgLMhsud29ya3NwYWNlLnJlbW90ZS5Xb3Jrc3BhY2VCCAoGcmVzdWx0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 13) = "IooBCgdQdWJsaXNoGn8KBlJlc3VsdBIvCgJvaxgBIAEoCzIhLndvcmtzcGFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 14) = "ZS5jYWxsLlB1Ymxpc2guUmVzdWx0Lk9rSAASJgoFZXJyb3IYAiABKAsyFS53";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 15) = "b3Jrc3BhY2UuY2FsbC5FcnJvckgAGhIKAk9rEgwKBHV1aWQYASABKAlCCAoG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 16) = "cmVzdWx0IooBCg5Db252ZXJ0VG9Mb2NhbBp4CgZSZXN1bHQSNgoCb2sYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 17) = "KAsyKC53b3Jrc3BhY2UuY2FsbC5Db252ZXJ0VG9Mb2NhbC5SZXN1bHQuT2tI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 18) = "ABImCgVlcnJvchgCIAEoCzIVLndvcmtzcGFjZS5jYWxsLkVycm9ySAAaBAoC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 19) = "T2tCCAoGcmVzdWx0IqQBCgZSZW5hbWUSEQoEdXVpZBgBIAEoCUgAiAEBEgwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 20) = "BG5hbWUYAiABKAkacAoGUmVzdWx0Ei4KAm9rGAEgASgLMiAud29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 21) = "LmNhbGwuUmVuYW1lLlJlc3VsdC5Pa0gAEiYKBWVycm9yGAIgASgLMhUud29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 22) = "a3NwYWNlLmNhbGwuRXJyb3JIABoECgJPa0IICgZyZXN1bHRCBwoFX3V1aWQi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 23) = "mAEKCVBhdXNlU3luYxIWCg51bnRpbF90aW1lX3V0YxgBIAEoBBpzCgZSZXN1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 24) = "bHQSMQoCb2sYASABKAsyIy53b3Jrc3BhY2UuY2FsbC5QYXVzZVN5bmMuUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 25) = "dWx0Lk9rSAASJgoFZXJyb3IYAiABKAsyFS53b3Jrc3BhY2UuY2FsbC5FcnJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 26) = "ckgAGgQKAk9rQggKBnJlc3VsdCKCAQoKUmVzdW1lU3luYxp0CgZSZXN1bHQS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 27) = "MgoCb2sYASABKAsyJC53b3Jrc3BhY2UuY2FsbC5SZXN1bWVTeW5jLlJlc3Vs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 28) = "dC5Pa0gAEiYKBWVycm9yGAIgASgLMhUud29ya3NwYWNlLmNhbGwuRXJyb3JI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 29) = "ABoECgJPa0IICgZyZXN1bHRCX6oCO1Byby5TZXJpYWxpemF0aW9uSW50ZXJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 30) = "cC5SVlByb3RvRGF0YS5TZXJ2aWNlLldvcmtzcGFjZS5DYWxsugIeUlZEYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 31) = "X1NlcnZpY2VfV29ya3NwYWNlX0NhbGxfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray32<string>, string>(in buffer, 32))), new FileDescriptor[2]
		{
			WorkspaceEntitiesLocalReflection.Descriptor,
			WorkspaceEntitiesRemoteReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[8]
		{
			new GeneratedClrTypeInfo(typeof(Error), Error.Parser, new string[2] { "Code", "Description" }, null, new Type[1] { typeof(Error.Types.Code) }, null, null),
			new GeneratedClrTypeInfo(typeof(OpenLocal), OpenLocal.Parser, new string[1] { "Workspace" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(OpenLocal.Types.Result), OpenLocal.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(OpenLocal.Types.Result.Types.Ok), OpenLocal.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(OpenRemote), OpenRemote.Parser, new string[2] { "Uuid", "Path" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(OpenRemote.Types.Result), OpenRemote.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(OpenRemote.Types.Result.Types.Ok), OpenRemote.Types.Result.Types.Ok.Parser, new string[1] { "Workspace" }, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(Publish), Publish.Parser, null, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Publish.Types.Result), Publish.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Publish.Types.Result.Types.Ok), Publish.Types.Result.Types.Ok.Parser, new string[1] { "Uuid" }, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(ConvertToLocal), ConvertToLocal.Parser, null, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(ConvertToLocal.Types.Result), ConvertToLocal.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(ConvertToLocal.Types.Result.Types.Ok), ConvertToLocal.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(Rename), Rename.Parser, new string[2] { "Uuid", "Name" }, new string[1] { "Uuid" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Rename.Types.Result), Rename.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Rename.Types.Result.Types.Ok), Rename.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(PauseSync), PauseSync.Parser, new string[1] { "UntilTimeUtc" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(PauseSync.Types.Result), PauseSync.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(PauseSync.Types.Result.Types.Ok), PauseSync.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(ResumeSync), ResumeSync.Parser, null, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(ResumeSync.Types.Result), ResumeSync.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(ResumeSync.Types.Result.Types.Ok), ResumeSync.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			})
		}));
	}
}
