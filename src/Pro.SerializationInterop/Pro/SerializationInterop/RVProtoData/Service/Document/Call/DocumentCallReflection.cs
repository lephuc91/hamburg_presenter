using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Document.Call;

public static class DocumentCallReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static DocumentCallReflection()
	{
		_003C_003Ey__InlineArray25<string> buffer = default(_003C_003Ey__InlineArray25<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 0) = "ChNkb2N1bWVudC5jYWxsLnByb3RvEg1kb2N1bWVudC5jYWxsGhdkb2N1bWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 1) = "dC5lbnRpdGllcy5wcm90byJaCgVFcnJvchInCgRjb2RlGAEgASgOMhkuZG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 2) = "dW1lbnQuY2FsbC5FcnJvci5Db2RlEhMKC2Rlc2NyaXB0aW9uGAIgASgJIhMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 3) = "BENvZGUSCwoHVU5LTk9XThAAIpMBCgVQYXRjaBIMCgR1dWlkGAEgASgJEg0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 4) = "BXBhdGNoGAIgASgMGm0KBlJlc3VsdBIsCgJvaxgBIAEoCzIeLmRvY3VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 5) = "LmNhbGwuUGF0Y2guUmVzdWx0Lk9rSAASJQoFZXJyb3IYAiABKAsyFC5kb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 6) = "bWVudC5jYWxsLkVycm9ySAAaBAoCT2tCCAoGcmVzdWx0IpABCgRMb2FkEgwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 7) = "BHV1aWQYASABKAkSDAoEYmxvYhgCIAEoDBpsCgZSZXN1bHQSKwoCb2sYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 8) = "KAsyHS5kb2N1bWVudC5jYWxsLkxvYWQuUmVzdWx0Lk9rSAASJQoFZXJyb3IY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 9) = "AiABKAsyFC5kb2N1bWVudC5jYWxsLkVycm9ySAAaBAoCT2tCCAoGcmVzdWx0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 10) = "IsMBCgNBZGQSDAoEdXVpZBgBIAEoCRIlCgRraW5kGAIgASgOMhcuZG9jdW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 11) = "bnQuRG9jdW1lbnQuS2luZBIMCgRwYXRoGAMgASgJEgwKBGRhdGEYCyABKAwa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 12) = "awoGUmVzdWx0EioKAm9rGAEgASgLMhwuZG9jdW1lbnQuY2FsbC5BZGQuUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 13) = "dWx0Lk9rSAASJQoFZXJyb3IYAiABKAsyFC5kb2N1bWVudC5jYWxsLkVycm9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 14) = "SAAaBAoCT2tCCAoGcmVzdWx0Iq0BCgZSZW1vdmUSDAoEdXVpZBgBIAEoCRIl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 15) = "CgRraW5kGAIgASgOMhcuZG9jdW1lbnQuRG9jdW1lbnQuS2luZBpuCgZSZXN1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 16) = "bHQSLQoCb2sYASABKAsyHy5kb2N1bWVudC5jYWxsLlJlbW92ZS5SZXN1bHQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 17) = "T2tIABIlCgVlcnJvchgCIAEoCzIULmRvY3VtZW50LmNhbGwuRXJyb3JIABoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 18) = "CgJPa0IICgZyZXN1bHQivwEKCFJlbG9jYXRlEgwKBHV1aWQYASABKAkSJQoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 19) = "a2luZBgCIAEoDjIXLmRvY3VtZW50LkRvY3VtZW50LktpbmQSDAoEcGF0aBgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 20) = "IAEoCRpwCgZSZXN1bHQSLwoCb2sYASABKAsyIS5kb2N1bWVudC5jYWxsLlJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 21) = "bG9jYXRlLlJlc3VsdC5Pa0gAEiUKBWVycm9yGAIgASgLMhQuZG9jdW1lbnQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 22) = "Y2FsbC5FcnJvckgAGgQKAk9rQggKBnJlc3VsdEJdqgI6UHJvLlNlcmlhbGl6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 23) = "YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhLlNlcnZpY2UuRG9jdW1lbnQuQ2Fs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray25<string>, string>(ref buffer, 24) = "bLoCHVJWRGF0YV9TZXJ2aWNlX0RvY3VtZW50X0NhbGxfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray25<string>, string>(in buffer, 25))), new FileDescriptor[1] { DocumentEntitiesReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[6]
		{
			new GeneratedClrTypeInfo(typeof(Error), Error.Parser, new string[2] { "Code", "Description" }, null, new Type[1] { typeof(Error.Types.Code) }, null, null),
			new GeneratedClrTypeInfo(typeof(Patch), Patch.Parser, new string[2] { "Uuid", "Patch_" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Patch.Types.Result), Patch.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Patch.Types.Result.Types.Ok), Patch.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(Load), Load.Parser, new string[2] { "Uuid", "Blob" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Load.Types.Result), Load.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Load.Types.Result.Types.Ok), Load.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(Add), Add.Parser, new string[4] { "Uuid", "Kind", "Path", "Data" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Add.Types.Result), Add.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Add.Types.Result.Types.Ok), Add.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(Remove), Remove.Parser, new string[2] { "Uuid", "Kind" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Remove.Types.Result), Remove.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Remove.Types.Result.Types.Ok), Remove.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(Relocate), Relocate.Parser, new string[3] { "Uuid", "Kind", "Path" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Relocate.Types.Result), Relocate.Types.Result.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Relocate.Types.Result.Types.Ok), Relocate.Types.Result.Types.Ok.Parser, null, null, null, null, null)
				})
			})
		}));
	}
}
