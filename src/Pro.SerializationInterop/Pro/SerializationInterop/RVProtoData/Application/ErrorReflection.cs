using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Application;

public static class ErrorReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ErrorReflection()
	{
		_003C_003Ey__InlineArray13<string> buffer = default(_003C_003Ey__InlineArray13<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 0) = "CgtlcnJvci5wcm90bxILYXBwbGljYXRpb24iUwoFRXJyb3ISJwoHc2Vydmlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 1) = "ZRgBIAEoDjIWLmFwcGxpY2F0aW9uLlNlcnZpY2VJRBIMCgRjb2RlGAIgASgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 2) = "EhMKC2Rlc2NyaXB0aW9uGAMgASgJInMKDlJlc3VsdEVudmVsb3BlEiwKAm9r";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 3) = "GAEgASgLMh4uYXBwbGljYXRpb24uUmVzdWx0RW52ZWxvcGUuT2tIABIjCgVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 4) = "cnJvchgCIAEoCzISLmFwcGxpY2F0aW9uLkVycm9ySAAaBAoCT2tCCAoGcmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 5) = "dWx0KmkKCVNlcnZpY2VJRBIPCgtBUFBMSUNBVElPThAAEgkKBU1FRElBEAES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 6) = "EQoNRkVBVFVSRV9GTEFHUxACEhAKDFJFR0lTVFJBVElPThADEgwKCERPQ1VN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 7) = "RU5UEAQSDQoJV09SS1NQQUNFEAUqhQEKCUVycm9yQ29kZRILCgdSVU5USU1F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 8) = "EAASCAoEQ0FMTBABEgoKBlBBUkFNUxACEggKBERBVEEQAxIJCgVQQU5JQxAE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 9) = "EggKBEpPSU4QBRIHCgNISUQQBhIKCgZSRU1PVEUQBxIOCgpERVBFTkRFTkNZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 10) = "EAgSEQoNTUVESUFfVkVSU0lPThAJQkmqAjBQcm8uU2VyaWFsaXphdGlvbklu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 11) = "dGVyb3AuUlZQcm90b0RhdGEuQXBwbGljYXRpb266AhNSVkRhdGFfQXBwbGlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 12) = "YXRpb25fYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray13<string>, string>(in buffer, 13))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[2]
		{
			typeof(ServiceID),
			typeof(ErrorCode)
		}, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Error), Error.Parser, new string[3] { "Service", "Code", "Description" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ResultEnvelope), ResultEnvelope.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(ResultEnvelope.Types.Ok), ResultEnvelope.Types.Ok.Parser, null, null, null, null, null)
			})
		}));
	}
}
