using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class HotKeyReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static HotKeyReflection()
	{
		_003C_003Ey__InlineArray65<string> buffer = default(_003C_003Ey__InlineArray65<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 0) = "Cgxob3RLZXkucHJvdG8SB3J2LmRhdGEaE2N1c3RvbU9wdGlvbnMucHJvdG8i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 1) = "SgoGSG90S2V5Eh4KBGNvZGUYASABKA4yEC5ydi5kYXRhLktleUNvZGUSIAoS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 2) = "Y29udHJvbF9pZGVudGlmaWVyGAIgASgJQgSohhkBKpkVCgdLZXlDb2RlEhQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 3) = "EEtFWV9DT0RFX1VOS05PV04QABITCg9LRVlfQ09ERV9BTlNJX0EQARITCg9L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 4) = "RVlfQ09ERV9BTlNJX0IQAhITCg9LRVlfQ09ERV9BTlNJX0MQAxITCg9LRVlf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 5) = "Q09ERV9BTlNJX0QQBBITCg9LRVlfQ09ERV9BTlNJX0UQBRITCg9LRVlfQ09E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 6) = "RV9BTlNJX0YQBhITCg9LRVlfQ09ERV9BTlNJX0cQBxITCg9LRVlfQ09ERV9B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 7) = "TlNJX0gQCBITCg9LRVlfQ09ERV9BTlNJX0kQCRITCg9LRVlfQ09ERV9BTlNJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 8) = "X0oQChITCg9LRVlfQ09ERV9BTlNJX0sQCxITCg9LRVlfQ09ERV9BTlNJX0wQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 9) = "DBITCg9LRVlfQ09ERV9BTlNJX00QDRITCg9LRVlfQ09ERV9BTlNJX04QDhIT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 10) = "Cg9LRVlfQ09ERV9BTlNJX08QDxITCg9LRVlfQ09ERV9BTlNJX1AQEBITCg9L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 11) = "RVlfQ09ERV9BTlNJX1EQERITCg9LRVlfQ09ERV9BTlNJX1IQEhITCg9LRVlf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 12) = "Q09ERV9BTlNJX1MQExITCg9LRVlfQ09ERV9BTlNJX1QQFBITCg9LRVlfQ09E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 13) = "RV9BTlNJX1UQFRITCg9LRVlfQ09ERV9BTlNJX1YQFhITCg9LRVlfQ09ERV9B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 14) = "TlNJX1cQFxITCg9LRVlfQ09ERV9BTlNJX1gQGBITCg9LRVlfQ09ERV9BTlNJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 15) = "X1kQGRITCg9LRVlfQ09ERV9BTlNJX1oQGhITCg9LRVlfQ09ERV9BTlNJXzAQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 16) = "GxITCg9LRVlfQ09ERV9BTlNJXzEQHBITCg9LRVlfQ09ERV9BTlNJXzIQHRIT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 17) = "Cg9LRVlfQ09ERV9BTlNJXzMQHhITCg9LRVlfQ09ERV9BTlNJXzQQHxITCg9L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 18) = "RVlfQ09ERV9BTlNJXzUQIBITCg9LRVlfQ09ERV9BTlNJXzYQIRITCg9LRVlf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 19) = "Q09ERV9BTlNJXzcQIhITCg9LRVlfQ09ERV9BTlNJXzgQIxITCg9LRVlfQ09E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 20) = "RV9BTlNJXzkQJBIXChNLRVlfQ09ERV9BTlNJX0VRVUFMECUSFwoTS0VZX0NP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 21) = "REVfQU5TSV9NSU5VUxAmEh8KG0tFWV9DT0RFX0FOU0lfUklHSFRfQlJBQ0tF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 22) = "VBAnEh4KGktFWV9DT0RFX0FOU0lfTEVGVF9CUkFDS0VUECgSFwoTS0VZX0NP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 23) = "REVfQU5TSV9RVU9URRApEhsKF0tFWV9DT0RFX0FOU0lfU0VNSUNPTE9OECoS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 24) = "GwoXS0VZX0NPREVfQU5TSV9CQUNLU0xBU0gQKxIXChNLRVlfQ09ERV9BTlNJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 25) = "X0NPTU1BECwSFwoTS0VZX0NPREVfQU5TSV9TTEFTSBAtEhgKFEtFWV9DT0RF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 26) = "X0FOU0lfUEVSSU9EEC4SFwoTS0VZX0NPREVfQU5TSV9HUkFWRRAvEiAKHEtF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 27) = "WV9DT0RFX0FOU0lfS0VZUEFEX0RFQ0lNQUwQMBIdChlLRVlfQ09ERV9BTlNJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 28) = "X0tFWVBBRF9QTFVTEDESHgoaS0VZX0NPREVfQU5TSV9LRVlQQURfQ0xFQVIQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 29) = "MhIfChtLRVlfQ09ERV9BTlNJX0tFWVBBRF9ESVZJREUQMxIeChpLRVlfQ09E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 30) = "RV9BTlNJX0tFWVBBRF9FTlRFUhA0Eh4KGktFWV9DT0RFX0FOU0lfS0VZUEFE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 31) = "X01JTlVTEDUSHwobS0VZX0NPREVfQU5TSV9LRVlQQURfRVFVQUxTEDYSGgoW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 32) = "S0VZX0NPREVfQU5TSV9LRVlQQURfMBA3EhoKFktFWV9DT0RFX0FOU0lfS0VZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 33) = "UEFEXzEQOBIaChZLRVlfQ09ERV9BTlNJX0tFWVBBRF8yEDkSGgoWS0VZX0NP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 34) = "REVfQU5TSV9LRVlQQURfMxA6EhoKFktFWV9DT0RFX0FOU0lfS0VZUEFEXzQQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 35) = "OxIaChZLRVlfQ09ERV9BTlNJX0tFWVBBRF81EDwSGgoWS0VZX0NPREVfQU5T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 36) = "SV9LRVlQQURfNhA9EhoKFktFWV9DT0RFX0FOU0lfS0VZUEFEXzcQPhIaChZL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 37) = "RVlfQ09ERV9BTlNJX0tFWVBBRF84ED8SGgoWS0VZX0NPREVfQU5TSV9LRVlQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 38) = "QURfORBAEg8KC0tFWV9DT0RFX0YxEEESDwoLS0VZX0NPREVfRjIQQhIPCgtL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 39) = "RVlfQ09ERV9GMxBDEg8KC0tFWV9DT0RFX0Y0EEQSDwoLS0VZX0NPREVfRjUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 40) = "RRIPCgtLRVlfQ09ERV9GNhBGEg8KC0tFWV9DT0RFX0Y3EEcSDwoLS0VZX0NP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 41) = "REVfRjgQSBIPCgtLRVlfQ09ERV9GORBJEhAKDEtFWV9DT0RFX0YxMBBKEhAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 42) = "DEtFWV9DT0RFX0YxMRBLEhAKDEtFWV9DT0RFX0YxMhBMEhAKDEtFWV9DT0RF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 43) = "X0YxMxBNEhAKDEtFWV9DT0RFX0YxNBBOEhAKDEtFWV9DT0RFX0YxNRBPEhAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 44) = "DEtFWV9DT0RFX0YxNhBQEhAKDEtFWV9DT0RFX0YxNxBREhAKDEtFWV9DT0RF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 45) = "X0YxOBBSEhAKDEtFWV9DT0RFX0YxORBTEhAKDEtFWV9DT0RFX0YyMBBUEhUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 46) = "EUtFWV9DT0RFX0ZVTkNUSU9OEFUSEwoPS0VZX0NPREVfUkVUVVJOEFYSEAoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 47) = "S0VZX0NPREVfVEFCEFcSEgoOS0VZX0NPREVfU1BBQ0UQWBITCg9LRVlfQ09E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 48) = "RV9ERUxFVEUQWRITCg9LRVlfQ09ERV9FU0NBUEUQWhIUChBLRVlfQ09ERV9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 49) = "T01NQU5EEFsSEgoOS0VZX0NPREVfU0hJRlQQXBIWChJLRVlfQ09ERV9DQVBT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 50) = "X0xPQ0sQXRITCg9LRVlfQ09ERV9PUFRJT04QXhIUChBLRVlfQ09ERV9DT05U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 51) = "Uk9MEF8SGAoUS0VZX0NPREVfUklHSFRfU0hJRlQQYBIZChVLRVlfQ09ERV9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 52) = "SUdIVF9PUFRJT04QYRIaChZLRVlfQ09ERV9SSUdIVF9DT05UUk9MEGISFgoS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 53) = "S0VZX0NPREVfVk9MVU1FX1VQEGMSGAoUS0VZX0NPREVfVk9MVU1FX0RPV04Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 54) = "ZBIRCg1LRVlfQ09ERV9NVVRFEGUSEQoNS0VZX0NPREVfSEVMUBBmEhEKDUtF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 55) = "WV9DT0RFX0hPTUUQZxIUChBLRVlfQ09ERV9QQUdFX1VQEGgSGwoXS0VZX0NP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 56) = "REVfRk9SV0FSRF9ERUxFVEUQaRIQCgxLRVlfQ09ERV9FTkQQahIWChJLRVlf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 57) = "Q09ERV9QQUdFX0RPV04QaxIXChNLRVlfQ09ERV9MRUZUX0FSUk9XEGwSGAoU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 58) = "S0VZX0NPREVfUklHSFRfQVJST1cQbRIXChNLRVlfQ09ERV9ET1dOX0FSUk9X";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 59) = "EG4SFQoRS0VZX0NPREVfVVBfQVJST1cQbxIaChZLRVlfQ09ERV9JU09fU0VM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 60) = "RUNUSU9OEHASFAoQS0VZX0NPREVfSklTX1lFThBxEhsKF0tFWV9DT0RFX0pJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 61) = "U19VTkRFUlNDT1JFEHISHQoZS0VZX0NPREVfSklTX0tFWVBBRF9DT01NQRBz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 62) = "EhUKEUtFWV9DT0RFX0pJU19FSVNVEHQSFQoRS0VZX0NPREVfSklTX0tBTkEQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 63) = "dUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 64) = "ugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray65<string>, string>(in buffer, 65))), new FileDescriptor[1] { CustomOptionsReflection.Descriptor }, new GeneratedClrTypeInfo(new Type[1] { typeof(KeyCode) }, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(HotKey), HotKey.Parser, new string[2] { "Code", "ControlIdentifier" }, null, null, null, null)
		}));
	}
}
