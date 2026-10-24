using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1CaptureReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1CaptureReflection()
	{
		_003C_003Ey__InlineArray49<string> buffer = default(_003C_003Ey__InlineArray49<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 0) = "ChVwcm9BcGlWMUNhcHR1cmUucHJvdG8SB3J2LmRhdGEaEnByb0FwaVYxU2l6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 1) = "ZS5wcm90bxoKdXVpZC5wcm90byKCAgoWQVBJX3YxX0NhcHR1cmVTZXR0aW5n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 2) = "cxIdCgZzb3VyY2UYASABKAsyDS5ydi5kYXRhLlVVSUQSMwoNYXVkaW9fcm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 3) = "dGluZxgCIAMoCzIcLnJ2LmRhdGEuQVBJX3YxX0F1ZGlvUm91dGluZxIrCgRk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 4) = "aXNrGAMgASgLMhsucnYuZGF0YS5BUElfdjFfRGlza0NhcHR1cmVIABIrCgRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 5) = "dG1wGAQgASgLMhsucnYuZGF0YS5BUElfdjFfUlRNUENhcHR1cmVIABIrCgRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 6) = "ZXNpGAUgASgLMhsucnYuZGF0YS5BUElfdjFfUmVzaUNhcHR1cmVIAEINCgtE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 7) = "ZXN0aW5hdGlvbiIiChNBUElfdjFfQXVkaW9Sb3V0aW5nEgsKA21hcBgBIAMo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 8) = "DSJ4ChJBUElfdjFfRGlza0NhcHR1cmUSFQoNZmlsZV9sb2NhdGlvbhgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 9) = "CRINCgVjb2RlYxgCIAEoCRIoCgpyZXNvbHV0aW9uGAMgASgLMhQucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 10) = "YS5BUElfdjFfU2l6ZRISCgpmcmFtZV9yYXRlGAQgASgBIm4KEkFQSV92MV9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 11) = "VE1QQ2FwdHVyZRIOCgZzZXJ2ZXIYASABKAkSCwoDa2V5GAIgASgJEhAKCGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 12) = "Y29kaW5nGAMgASgJEhIKCnNhdmVfbG9jYWwYBCABKAgSFQoNZmlsZV9sb2Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 13) = "dGlvbhgFIAEoCSJwChJBUElfdjFfUmVzaUNhcHR1cmUSEgoKZXZlbnRfbmFt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 14) = "ZRgBIAEoCRIZChFldmVudF9kZXNjcmlwdGlvbhgCIAEoCRIZChFkZXN0aW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 15) = "dGlvbl9ncm91cBgDIAEoCRIQCghlbmNvZGluZxgEIAEoCSKPBQoWQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 16) = "X0NhcHR1cmVfUmVxdWVzdBI8CgpnZXRfc3RhdHVzGAEgASgLMiYucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 17) = "YS5BUElfdjFfQ2FwdHVyZV9SZXF1ZXN0LlN0YXR1c0gAEj4KCW9wZXJhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 18) = "bhgCIAEoCzIpLnJ2LmRhdGEuQVBJX3YxX0NhcHR1cmVfUmVxdWVzdC5PcGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 19) = "YXRpb25IABJDCgxnZXRfc2V0dGluZ3MYAyABKAsyKy5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 20) = "MV9DYXB0dXJlX1JlcXVlc3QuR2V0U2V0dGluZ3NIABJDCgxzZXRfc2V0dGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 21) = "Z3MYBCABKAsyKy5ydi5kYXRhLkFQSV92MV9DYXB0dXJlX1JlcXVlc3QuU2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 22) = "U2V0dGluZ3NIABJCCg1nZXRfZW5jb2RpbmdzGAUgASgLMikucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 23) = "UElfdjFfQ2FwdHVyZV9SZXF1ZXN0LkVuY29kaW5nc0gAGggKBlN0YXR1cxqD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 24) = "AQoJT3BlcmF0aW9uEk0KCW9wZXJhdGlvbhgBIAEoDjI6LnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 25) = "X3YxX0NhcHR1cmVfUmVxdWVzdC5PcGVyYXRpb24uQ2FwdHVyZU9wZXJhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 26) = "biInChBDYXB0dXJlT3BlcmF0aW9uEgkKBXN0YXJ0EAASCAoEc3RvcBABGg0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 27) = "C0dldFNldHRpbmdzGkAKC1NldFNldHRpbmdzEjEKCHNldHRpbmdzGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 28) = "Mh8ucnYuZGF0YS5BUElfdjFfQ2FwdHVyZVNldHRpbmdzGj0KCUVuY29kaW5n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 29) = "cxIwCgR0eXBlGAEgASgOMiIucnYuZGF0YS5BUElfdjFfQ2FwdHVyZURlc3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 30) = "bmF0aW9uQgkKB1JlcXVlc3Qi3gQKF0FQSV92MV9DYXB0dXJlX1Jlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 31) = "EkAKCmdldF9zdGF0dXMYASABKAsyKi5ydi5kYXRhLkFQSV92MV9DYXB0dXJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 32) = "X1Jlc3BvbnNlLkdldFN0YXR1c0gAEj8KCW9wZXJhdGlvbhgCIAEoCzIqLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 33) = "LmRhdGEuQVBJX3YxX0NhcHR1cmVfUmVzcG9uc2UuT3BlcmF0aW9uSAASRAoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 34) = "Z2V0X3NldHRpbmdzGAMgASgLMiwucnYuZGF0YS5BUElfdjFfQ2FwdHVyZV9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 35) = "ZXNwb25zZS5HZXRTZXR0aW5nc0gAEkQKDHNldF9zZXR0aW5ncxgEIAEoCzIs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 36) = "LnJ2LmRhdGEuQVBJX3YxX0NhcHR1cmVfUmVzcG9uc2UuU2V0U2V0dGluZ3NI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 37) = "ABJDCg1nZXRfZW5jb2RpbmdzGAUgASgLMioucnYuZGF0YS5BUElfdjFfQ2Fw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 38) = "dHVyZV9SZXNwb25zZS5FbmNvZGluZ3NIABplCglHZXRTdGF0dXMSLQoGc3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 39) = "dHVzGAEgASgOMh0ucnYuZGF0YS5BUElfdjFfQ2FwdHVyZVN0YXR1cxIUCgxj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 40) = "YXB0dXJlX3RpbWUYAiABKAkSEwoLc3RhdHVzX3RleHQYAyABKAkaCwoJT3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 41) = "cmF0aW9uGkAKC0dldFNldHRpbmdzEjEKCHNldHRpbmdzGAEgASgLMh8ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 42) = "ZGF0YS5BUElfdjFfQ2FwdHVyZVNldHRpbmdzGg0KC1NldFNldHRpbmdzGh4K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 43) = "CUVuY29kaW5ncxIRCgllbmNvZGluZ3MYASADKAlCCgoIUmVzcG9uc2UqOQoZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 44) = "QVBJX3YxX0NhcHR1cmVEZXN0aW5hdGlvbhIICgRkaXNrEAASCAoEcnRtcBAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 45) = "EggKBHJlc2kQAipIChRBUElfdjFfQ2FwdHVyZVN0YXR1cxIKCgZhY3RpdmUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 46) = "ABIMCghpbmFjdGl2ZRABEgsKB2NhdXRpb24QAhIJCgVlcnJvchADQjT4AQGq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 47) = "AiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray49<string>, string>(ref buffer, 48) = "dGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray49<string>, string>(in buffer, 49))), new FileDescriptor[2]
		{
			ProApiV1SizeReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(new Type[2]
		{
			typeof(API_v1_CaptureDestination),
			typeof(API_v1_CaptureStatus)
		}, null, new GeneratedClrTypeInfo[7]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_CaptureSettings), API_v1_CaptureSettings.Parser, new string[5] { "Source", "AudioRouting", "Disk", "Rtmp", "Resi" }, new string[1] { "Destination" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_AudioRouting), API_v1_AudioRouting.Parser, new string[1] { "Map" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_DiskCapture), API_v1_DiskCapture.Parser, new string[4] { "FileLocation", "Codec", "Resolution", "FrameRate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_RTMPCapture), API_v1_RTMPCapture.Parser, new string[5] { "Server", "Key", "Encoding", "SaveLocal", "FileLocation" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_ResiCapture), API_v1_ResiCapture.Parser, new string[4] { "EventName", "EventDescription", "DestinationGroup", "Encoding" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Capture_Request), API_v1_Capture_Request.Parser, new string[5] { "GetStatus", "Operation", "GetSettings", "SetSettings", "GetEncodings" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[5]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Request.Types.Status), API_v1_Capture_Request.Types.Status.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Request.Types.Operation), API_v1_Capture_Request.Types.Operation.Parser, new string[1] { "Operation_" }, null, new Type[1] { typeof(API_v1_Capture_Request.Types.Operation.Types.CaptureOperation) }, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Request.Types.GetSettings), API_v1_Capture_Request.Types.GetSettings.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Request.Types.SetSettings), API_v1_Capture_Request.Types.SetSettings.Parser, new string[1] { "Settings" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Request.Types.Encodings), API_v1_Capture_Request.Types.Encodings.Parser, new string[1] { "Type" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Capture_Response), API_v1_Capture_Response.Parser, new string[5] { "GetStatus", "Operation", "GetSettings", "SetSettings", "GetEncodings" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[5]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Response.Types.GetStatus), API_v1_Capture_Response.Types.GetStatus.Parser, new string[3] { "Status", "CaptureTime", "StatusText" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Response.Types.Operation), API_v1_Capture_Response.Types.Operation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Response.Types.GetSettings), API_v1_Capture_Response.Types.GetSettings.Parser, new string[1] { "Settings" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Response.Types.SetSettings), API_v1_Capture_Response.Types.SetSettings.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Capture_Response.Types.Encodings), API_v1_Capture_Response.Types.Encodings.Parser, new string[1] { "Encodings_" }, null, null, null, null)
			})
		}));
	}
}
