using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class ActionReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ActionReflection()
	{
		_003C_003Ey__InlineArray232<string> buffer = default(_003C_003Ey__InlineArray232<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 0) = "CgxhY3Rpb24ucHJvdG8SB3J2LmRhdGEaEGJhY2tncm91bmQucHJvdG8aG2Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 1) = "bGxlY3Rpb25FbGVtZW50VHlwZS5wcm90bxoLY29sb3IucHJvdG8aE2N1c3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 2) = "bU9wdGlvbnMucHJvdG8aDWVmZmVjdHMucHJvdG8aEmdyYXBoaWNzRGF0YS5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 3) = "cm90bxoLaW5wdXQucHJvdG8aDmludFJhbmdlLnByb3RvGgxsYXllcnMucHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 4) = "dG8aDm1lc3NhZ2VzLnByb3RvGg9wcm9wU2xpZGUucHJvdG8aF3ByZXNlbnRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 5) = "dGlvblNsaWRlLnByb3RvGgtzdGFnZS5wcm90bxoMdGltZXJzLnByb3RvGgl1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 6) = "cmwucHJvdG8aCnV1aWQucHJvdG8i0k4KBkFjdGlvbhIbCgR1dWlkGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 7) = "Mg0ucnYuZGF0YS5VVUlEEgwKBG5hbWUYAiABKAkSJAoFbGFiZWwYAyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 8) = "FS5ydi5kYXRhLkFjdGlvbi5MYWJlbBISCgpkZWxheV90aW1lGAQgASgBEi8K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 9) = "CG9sZF90eXBlGAUgASgLMhcucnYuZGF0YS5BY3Rpb24uT2xkVHlwZUIEqIYZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 10) = "ARIRCglpc0VuYWJsZWQYBiABKAgSRwoUbGF5ZXJfaWRlbnRpZmljYXRpb24Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 11) = "ByABKAsyIy5ydi5kYXRhLkFjdGlvbi5MYXllcklkZW50aWZpY2F0aW9uQgSo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 12) = "hhkBEhAKCGR1cmF0aW9uGAggASgBEigKBHR5cGUYCSABKA4yGi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 13) = "LkFjdGlvbi5BY3Rpb25UeXBlEkIKEmNvbGxlY3Rpb25fZWxlbWVudBgQIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 14) = "CzIeLnJ2LmRhdGEuQ29sbGVjdGlvbkVsZW1lbnRUeXBlQgSohhkBSAASOQoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 15) = "cGxheWxpc3RfaXRlbRgRIAEoCzIgLnJ2LmRhdGEuQWN0aW9uLlBsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 16) = "SXRlbVR5cGVIABI5CgpibGVuZF9tb2RlGBIgASgLMh0ucnYuZGF0YS5BY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 17) = "b24uQmxlbmRNb2RlVHlwZUIEqIYZAUgAEjoKCnRyYW5zaXRpb24YEyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 18) = "Hi5ydi5kYXRhLkFjdGlvbi5UcmFuc2l0aW9uVHlwZUIEqIYZAUgAEioKBW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 19) = "ZGlhGBQgASgLMhkucnYuZGF0YS5BY3Rpb24uTWVkaWFUeXBlSAASNwoLZG91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 20) = "YmxlX2l0ZW0YFSABKAsyGi5ydi5kYXRhLkFjdGlvbi5Eb3VibGVUeXBlQgSo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 21) = "hhkBSAASNAoHZWZmZWN0cxgWIAEoCzIbLnJ2LmRhdGEuQWN0aW9uLkVmZmVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 22) = "dHNUeXBlQgSohhkBSAASKgoFc2xpZGUYFyABKAsyGS5ydi5kYXRhLkFjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 23) = "bi5TbGlkZVR5cGVIABI6CgpiYWNrZ3JvdW5kGBggASgLMh4ucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 24) = "Y3Rpb24uQmFja2dyb3VuZFR5cGVCBKiGGQFIABIqCgV0aW1lchgZIAEoCzIZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 25) = "LnJ2LmRhdGEuQWN0aW9uLlRpbWVyVHlwZUgAEioKBWNsZWFyGBogASgLMhku";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 26) = "cnYuZGF0YS5BY3Rpb24uQ2xlYXJUeXBlSAASMAoFc3RhZ2UYGyABKAsyHy5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 27) = "di5kYXRhLkFjdGlvbi5TdGFnZUxheW91dFR5cGVIABIoCgRwcm9wGBwgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 28) = "MhgucnYuZGF0YS5BY3Rpb24uUHJvcFR5cGVIABIsCgRtYXNrGB0gASgLMhgu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 29) = "cnYuZGF0YS5BY3Rpb24uTWFza1R5cGVCAhgBSAASLgoHbWVzc2FnZRgeIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 30) = "CzIbLnJ2LmRhdGEuQWN0aW9uLk1lc3NhZ2VUeXBlSAASOgoNY29tbXVuaWNh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 31) = "dGlvbhggIAEoCzIhLnJ2LmRhdGEuQWN0aW9uLkNvbW11bmljYXRpb25UeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 32) = "SAASOwoMbXVsdGlfc2NyZWVuGCEgASgLMh8ucnYuZGF0YS5BY3Rpb24uTXVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 33) = "dGlTY3JlZW5UeXBlQgIYAUgAEj0KFXByZXNlbnRhdGlvbl9kb2N1bWVudBgi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 34) = "IAEoCzIcLnJ2LmRhdGEuQWN0aW9uLkRvY3VtZW50VHlwZUgAEkkKFWV4dGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 35) = "bmFsX3ByZXNlbnRhdGlvbhgkIAEoCzIoLnJ2LmRhdGEuQWN0aW9uLkV4dGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 36) = "bmFsUHJlc2VudGF0aW9uVHlwZUgAEjkKDWF1ZGllbmNlX2xvb2sYJSABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 37) = "IC5ydi5kYXRhLkFjdGlvbi5BdWRpZW5jZUxvb2tUeXBlSAASNQoLYXVkaW9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 38) = "aW5wdXQYJiABKAsyHi5ydi5kYXRhLkFjdGlvbi5BdWRpb0lucHV0VHlwZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 39) = "EkEKEXNsaWRlX2Rlc3RpbmF0aW9uGCcgASgLMiQucnYuZGF0YS5BY3Rpb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 40) = "U2xpZGVEZXN0aW5hdGlvblR5cGVIABIqCgVtYWNybxgoIAEoCzIZLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 41) = "dGEuQWN0aW9uLk1hY3JvVHlwZUgAEjUKC2NsZWFyX2dyb3VwGCkgASgLMh4u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 42) = "cnYuZGF0YS5BY3Rpb24uQ2xlYXJHcm91cFR5cGVIABJHChF0cmFuc3BvcnRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 43) = "Y29udHJvbBgqIAEoCzIkLnJ2LmRhdGEuQWN0aW9uLlRyYW5zcG9ydENvbnRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 44) = "b2xUeXBlQgSohhkBSAASLgoHY2FwdHVyZRgrIAEoCzIbLnJ2LmRhdGEuQWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 45) = "aW9uLkNhcHR1cmVUeXBlSAAapwEKB09sZFR5cGUSMgoIY2F0ZWdvcnkYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 46) = "KA4yIC5ydi5kYXRhLkFjdGlvbi5PbGRUeXBlLkNhdGVnb3J5EhgKEGFwcGxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 47) = "Y2F0aW9uX3R5cGUYAiABKAUiTgoIQ2F0ZWdvcnkSFAoQQ0FURUdPUllfVU5L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 48) = "Tk9XThAAEhIKDkNBVEVHT1JZX01FRElBEAESGAoUQ0FURUdPUllfQVBQTElD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 49) = "QVRJT04QAhpGCgVMYWJlbBISCgR0ZXh0GAIgASgJQgSghhkBEiMKBWNvbG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 50) = "GAMgASgLMg4ucnYuZGF0YS5Db2xvckIEoIYZAUoECAEQAhpAChNMYXllcklk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 51) = "ZW50aWZpY2F0aW9uEhsKBHV1aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 52) = "bmFtZRgCIAEoCRrPAQoQUGxheWxpc3RJdGVtVHlwZRIqCg1wbGF5bGlzdF91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 53) = "dWlkGAEgASgLMg0ucnYuZGF0YS5VVUlEQgSghhkBEhsKDXBsYXlsaXN0X25h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 54) = "bWUYAiABKAlCBKCGGQESJgoJaXRlbV91dWlkGAMgASgLMg0ucnYuZGF0YS5V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 55) = "VUlEQgSghhkBEhcKCWl0ZW1fbmFtZRgEIAEoCUIEoIYZARIXCg9zZWxlY3Rf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 56) = "cGxheWxpc3QYBSABKAgSGAoQYWx3YXlzX3JldHJpZ2dlchgGIAEoCBppCg1C";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 57) = "bGVuZE1vZGVUeXBlEjAKCmJsZW5kX21vZGUYASABKA4yGC5ydi5kYXRhLkxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 58) = "eWVyLkJsZW5kTW9kZUICGAESJgoFYmxlbmQYAiABKAsyFy5ydi5kYXRhLkxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 59) = "eWVyLkJsZW5kaW5nGlIKDlRyYW5zaXRpb25UeXBlEhcKD3RyYW5zaXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 60) = "bmFtZRgBIAEoCRInCgp0cmFuc2l0aW9uGAIgASgLMhMucnYuZGF0YS5UcmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 61) = "c2l0aW9uGhsKCkRvdWJsZVR5cGUSDQoFdmFsdWUYASABKAEaLwoLRWZmZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 62) = "c1R5cGUSIAoHZWZmZWN0cxgBIAMoCzIPLnJ2LmRhdGEuRWZmZWN0GvUMCglN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 63) = "ZWRpYVR5cGUSIQoTdHJhbnNpdGlvbl9kdXJhdGlvbhgBIAEoAUIEqIYZARI4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 64) = "ChtzZWxlY3RlZF9lZmZlY3RfcHJlc2V0X3V1aWQYAiABKAsyDS5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 65) = "LlVVSURCBKiGGQESLQoKdHJhbnNpdGlvbhgDIAEoCzITLnJ2LmRhdGEuVHJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 66) = "bnNpdGlvbkIEoIYZARImCgdlZmZlY3RzGAQgAygLMg8ucnYuZGF0YS5FZmZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 67) = "Y3RCBKiGGQESHwoHZWxlbWVudBgFIAEoCzIOLnJ2LmRhdGEuTWVkaWESNgoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 68) = "aW1hZ2UYBiABKAsyHy5ydi5kYXRhLkFjdGlvbi5NZWRpYVR5cGUuSW1hZ2VC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 69) = "BKiGGQFIABI2CgV2aWRlbxgHIAEoCzIfLnJ2LmRhdGEuQWN0aW9uLk1lZGlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 70) = "VHlwZS5WaWRlb0IEqIYZAUgAEjAKBWF1ZGlvGAggASgLMh8ucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 71) = "Y3Rpb24uTWVkaWFUeXBlLkF1ZGlvSAASPwoKbGl2ZV92aWRlbxgJIAEoCzIj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 72) = "LnJ2LmRhdGEuQWN0aW9uLk1lZGlhVHlwZS5MaXZlVmlkZW9CBKiGGQFIABIt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 73) = "CgpsYXllcl90eXBlGAogASgOMhkucnYuZGF0YS5BY3Rpb24uTGF5ZXJUeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 74) = "Eh4KEGFsd2F5c19yZXRyaWdnZXIYCyABKAhCBKiGGQESOQoHbWFya2VycxgM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 75) = "IAMoCzIoLnJ2LmRhdGEuQWN0aW9uLk1lZGlhVHlwZS5QbGF5YmFja01hcmtl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 76) = "choHCgVJbWFnZRr8AQoFVmlkZW8SSQoRcGxheWJhY2tfYmVoYXZpb3IYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 77) = "KA4yKi5ydi5kYXRhLkFjdGlvbi5NZWRpYVR5cGUuUGxheWJhY2tCZWhhdmlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 78) = "ckICGAESPwoMZW5kX2JlaGF2aW9yGAIgASgOMiUucnYuZGF0YS5BY3Rpb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 79) = "TWVkaWFUeXBlLkVuZEJlaGF2aW9yQgIYARIVCglsb29wX3RpbWUYAyABKAFC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 80) = "AhgBEhkKDXRpbWVzX3RvX2xvb3AYBCABKA1CAhgBEhUKCXNvZnRfbG9vcBgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 81) = "IAEoCEICGAESHgoSc29mdF9sb29wX2R1cmF0aW9uGAYgASgBQgIYARqrAgoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 82) = "QXVkaW8SSQoRcGxheWJhY2tfYmVoYXZpb3IYASABKA4yKi5ydi5kYXRhLkFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 83) = "dGlvbi5NZWRpYVR5cGUuUGxheWJhY2tCZWhhdmlvckICGAESFQoJbG9vcF90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 84) = "aW1lGAIgASgBQgIYARIZCg10aW1lc190b19sb29wGAMgASgNQgIYARJICgph";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 85) = "dWRpb190eXBlGAQgASgOMjQucnYuZGF0YS5BY3Rpb24uTWVkaWFUeXBlLkF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 86) = "ZGlvLk1lZGlhQWN0aW9uQXVkaW9UeXBlIlsKFE1lZGlhQWN0aW9uQXVkaW9U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 87) = "eXBlEiAKHE1FRElBX0FDVElPTl9BVURJT19UWVBFX1RVTkUQABIhCh1NRURJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 88) = "QV9BQ1RJT05fQVVESU9fVFlQRV9TT1VORBABGgsKCUxpdmVWaWRlbxqQAQoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 89) = "UGxheWJhY2tNYXJrZXISGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBIM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 90) = "CgR0aW1lGAIgASgBEh0KBWNvbG9yGAMgASgLMg4ucnYuZGF0YS5Db2xvchIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 91) = "CgRuYW1lGAQgASgJQgSghhkBEiAKB2FjdGlvbnMYBSADKAsyDy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 92) = "LkFjdGlvbiKVAQoQUGxheWJhY2tCZWhhdmlvchIaChZQTEFZQkFDS19CRUhB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 93) = "VklPUl9TVE9QEAASGgoWUExBWUJBQ0tfQkVIQVZJT1JfTE9PUBABEiQKIFBM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 94) = "QVlCQUNLX0JFSEFWSU9SX0xPT1BfRk9SX0NPVU5UEAISIwofUExBWUJBQ0tf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 95) = "QkVIQVZJT1JfTE9PUF9GT1JfVElNRRADIqQBCgtFbmRCZWhhdmlvchIVChFF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 96) = "TkRfQkVIQVZJT1JfU1RPUBAAEh4KGkVORF9CRUhBVklPUl9TVE9QX09OX0JM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 97) = "QUNLEAESHgoaRU5EX0JFSEFWSU9SX1NUT1BfT05fQ0xFQVIQAhIeChpFTkRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 98) = "QkVIQVZJT1JfRkFERV9UT19CTEFDSxADEh4KGkVORF9CRUhBVklPUl9GQURF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 99) = "X1RPX0NMRUFSEARCCwoJTWVkaWFUeXBlSgQIDRAOGnwKCVNsaWRlVHlwZRIy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 100) = "CgxwcmVzZW50YXRpb24YAiABKAsyGi5ydi5kYXRhLlByZXNlbnRhdGlvblNs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 101) = "aWRlSAASIgoEcHJvcBgDIAEoCzISLnJ2LmRhdGEuUHJvcFNsaWRlSABCBwoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 102) = "U2xpZGVKBAgBEAJSCHRlbXBsYXRlGjYKDkJhY2tncm91bmRUeXBlEiQKB2Vs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 103) = "ZW1lbnQYASABKAsyEy5ydi5kYXRhLkJhY2tncm91bmQalgMKCVRpbWVyVHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 104) = "ZRI6CgthY3Rpb25fdHlwZRgCIAEoDjIlLnJ2LmRhdGEuQWN0aW9uLlRpbWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 105) = "VHlwZS5UaW1lckFjdGlvbhI8ChR0aW1lcl9pZGVudGlmaWNhdGlvbhgEIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 106) = "CzIeLnJ2LmRhdGEuQ29sbGVjdGlvbkVsZW1lbnRUeXBlEjkKE3RpbWVyX2Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 107) = "bmZpZ3VyYXRpb24YCiABKAsyHC5ydi5kYXRhLlRpbWVyLkNvbmZpZ3VyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 108) = "b24SGAoQaW5jcmVtZW50X2Ftb3VudBgLIAEoASKPAQoLVGltZXJBY3Rpb24S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 109) = "EAoMQUNUSU9OX1NUQVJUEAASDwoLQUNUSU9OX1NUT1AQARIQCgxBQ1RJT05f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 110) = "UkVTRVQQAhIaChZBQ1RJT05fUkVTRVRfQU5EX1NUQVJUEAMSGQoVQUNUSU9O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 111) = "X1NUT1BfQU5EX1JFU0VUEAQSFAoQQUNUSU9OX0lOQ1JFTUVOVBAFSgQIARAC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 112) = "SgQIAxAESgQIBRAGSgQIBhAHSgQIBxAISgQICBAJSgQICRAKGtQDCglDbGVh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 113) = "clR5cGUSQAoMdGFyZ2V0X2xheWVyGAIgASgOMioucnYuZGF0YS5BY3Rpb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 114) = "Q2xlYXJUeXBlLkNsZWFyVGFyZ2V0TGF5ZXISPwoTY29udGVudF9kZXN0aW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 115) = "dGlvbhgEIAEoDjIiLnJ2LmRhdGEuQWN0aW9uLkNvbnRlbnREZXN0aW5hdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 116) = "biKxAgoQQ2xlYXJUYXJnZXRMYXllchIaChZDTEVBUl9UQVJHRVRfTEFZRVJf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 117) = "QUxMEAASHAoYQ0xFQVJfVEFSR0VUX0xBWUVSX0FVRElPEAESIQodQ0xFQVJf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 118) = "VEFSR0VUX0xBWUVSX0JBQ0tHUk9VTkQQAhIhCh1DTEVBUl9UQVJHRVRfTEFZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 119) = "RVJfTElWRV9WSURFTxADEhsKF0NMRUFSX1RBUkdFVF9MQVlFUl9QUk9QEAQS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 120) = "HAoYQ0xFQVJfVEFSR0VUX0xBWUVSX1NMSURFEAUSGwoXQ0xFQVJfVEFSR0VU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 121) = "X0xBWUVSX0xPR08QBhIfChtDTEVBUl9UQVJHRVRfTEFZRVJfTUVTU0FHRVMQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 122) = "BxIkCiBDTEVBUl9UQVJHRVRfTEFZRVJfQVVESU9fRUZGRUNUUxAIOgSAgBkB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 123) = "SgQIARACSgQIAxAEGkgKDkNsZWFyR3JvdXBUeXBlEjYKDmlkZW50aWZpY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 124) = "aW9uGAEgASgLMh4ucnYuZGF0YS5Db2xsZWN0aW9uRWxlbWVudFR5cGUajQIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 125) = "FFRyYW5zcG9ydENvbnRyb2xUeXBlEjkKBHBsYXkYASABKAsyKS5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 126) = "LkFjdGlvbi5UcmFuc3BvcnRDb250cm9sVHlwZS5QbGF5SAASOwoFcGF1c2UY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 127) = "AiABKAsyKi5ydi5kYXRhLkFjdGlvbi5UcmFuc3BvcnRDb250cm9sVHlwZS5Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 128) = "YXVzZUgAEkUKCmp1bXBUb1RpbWUYAyABKAsyLy5ydi5kYXRhLkFjdGlvbi5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 129) = "cmFuc3BvcnRDb250cm9sVHlwZS5KdW1wVG9UaW1lSAAaBgoEUGxheRoHCgVQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 130) = "YXVzZRoaCgpKdW1wVG9UaW1lEgwKBHRpbWUYASABKAFCCQoHQ29tbWFuZBqp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 131) = "AgoPU3RhZ2VMYXlvdXRUeXBlEkEKGHN0YWdlX3NjcmVlbl9hc3NpZ25tZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 132) = "cxgEIAMoCzIfLnJ2LmRhdGEuU3RhZ2UuU2NyZWVuQXNzaWdubWVudBJBCgxz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 133) = "bGlkZV90YXJnZXQYBSABKA4yKy5ydi5kYXRhLkFjdGlvbi5TdGFnZUxheW91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 134) = "dFR5cGUuU2xpZGVUYXJnZXQiXAoLU2xpZGVUYXJnZXQSGgoWU0xJREVfVEFS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 135) = "R0VUX05PX0NIQU5HRRAAEhsKF1NMSURFX1RBUkdFVF9TVEFHRV9PTkxZEAES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 136) = "FAoQU0xJREVfVEFSR0VUX0FMTBACSgQIARACSgQIAxAEUhljb2xsZWN0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 137) = "X2lkZW50aWZpY2F0aW9uUgthY3Rpb25fdHlwZRpZChRTbGlkZURlc3RpbmF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 138) = "aW9uVHlwZRJBCgxzbGlkZV90YXJnZXQYASABKA4yKy5ydi5kYXRhLkFjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 139) = "bi5TdGFnZUxheW91dFR5cGUuU2xpZGVUYXJnZXQaygIKCFByb3BUeXBlEjYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 140) = "DmlkZW50aWZpY2F0aW9uGAMgASgLMh4ucnYuZGF0YS5Db2xsZWN0aW9uRWxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 141) = "bWVudFR5cGUSNwoHdHJpZ2dlchgEIAEoCzIkLnJ2LmRhdGEuQWN0aW9uLlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 142) = "b3BUeXBlLlByb3BUcmlnZ2VySAASMwoFY2xlYXIYBSABKAsyIi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 143) = "LkFjdGlvbi5Qcm9wVHlwZS5Qcm9wQ2xlYXJIABpwCgtQcm9wVHJpZ2dlchIa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 144) = "ChJhdXRvX2NsZWFyX2VuYWJsZWQYASABKAgSKAogYXV0b19jbGVhcl9mb2xs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 145) = "b3dzX3Byb3BfZHVyYXRpb24YAiABKAgSGwoTYXV0b19jbGVhcl9kdXJhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 146) = "bhgDIAEoARoLCglQcm9wQ2xlYXJCDQoLVHJpZ2dlclR5cGVKBAgBEAJKBAgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 147) = "EAMaTgoITWFza1R5cGUSNgoOaWRlbnRpZmljYXRpb24YAyABKAsyHi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 148) = "YXRhLkNvbGxlY3Rpb25FbGVtZW50VHlwZUoECAEQAkoECAIQAxqAAQoLTWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 149) = "c2FnZVR5cGUSPQoVbWVzc2FnZV9pZGVudGlmaWNhdG9uGAEgASgLMh4ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 150) = "ZGF0YS5Db2xsZWN0aW9uRWxlbWVudFR5cGUSLAoHY29udGVudBgDIAMoCzIb";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 151) = "LnJ2LmRhdGEuTWVzc2FnZS5Ub2tlblZhbHVlSgQIAhADGpoMChFDb21tdW5p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 152) = "Y2F0aW9uVHlwZRI9ChVkZXZpY2VfaWRlbnRpZmljYXRpb24YASABKAsyHi5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 153) = "di5kYXRhLkNvbGxlY3Rpb25FbGVtZW50VHlwZRIOCgZmb3JtYXQYAiABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 154) = "EwoLZGVzY3JpcHRpb24YAyABKAkSOwoIY29tbWFuZHMYBCADKAsyKS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 155) = "YXRhLkFjdGlvbi5Db21tdW5pY2F0aW9uVHlwZS5Db21tYW5kEkUKDG1pZGlf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 156) = "Y29tbWFuZBgFIAEoCzItLnJ2LmRhdGEuQWN0aW9uLkNvbW11bmljYXRpb25U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 157) = "eXBlLk1JRElDb21tYW5kSAASWgoUZ2xvYmFsX2NhY2hlX2NvbW1hbmQYBiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 158) = "KAsyNC5ydi5kYXRhLkFjdGlvbi5Db21tdW5pY2F0aW9uVHlwZS5HbG9iYWxD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 159) = "YWNoZUNvbW1hbmRCBKiGGQFIABJPCg5ndmcxMDBfY29tbWFuZBgHIAEoCzIv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 160) = "LnJ2LmRhdGEuQWN0aW9uLkNvbW11bmljYXRpb25UeXBlLkdWRzEwMENvbW1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 161) = "bmRCBKiGGQFIABJSChBzb255X0JWU19jb21tYW5kGAggASgLMjAucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 162) = "YS5BY3Rpb24uQ29tbXVuaWNhdGlvblR5cGUuU29ueUJWU0NvbW1hbmRCBKiG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 163) = "GQFIABptCgdDb21tYW5kEgwKBG5hbWUYASABKAkSDQoFdmFsdWUYAiABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 164) = "LAoRcmVwbGFjZW1lbnRfcmFuZ2UYAyABKAsyES5ydi5kYXRhLkludFJhbmdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 165) = "EhcKD3Bvc3NpYmxlX3ZhbHVlcxgEIAMoCRqpAQoLTUlESUNvbW1hbmQSQgoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 166) = "c3RhdGUYASABKA4yMy5ydi5kYXRhLkFjdGlvbi5Db21tdW5pY2F0aW9uVHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 167) = "ZS5NSURJQ29tbWFuZC5TdGF0ZRIPCgdjaGFubmVsGAIgASgNEgwKBG5vdGUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 168) = "AyABKA0SEQoJaW50ZW5zaXR5GAQgASgNIiQKBVN0YXRlEgwKCFNUQVRFX09O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 169) = "EAASDQoJU1RBVEVfT0ZGEAEapQIKEkdsb2JhbENhY2hlQ29tbWFuZBJaCg5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 170) = "b21tYW5kX2FjdGlvbhgBIAEoDjJCLnJ2LmRhdGEuQWN0aW9uLkNvbW11bmlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 171) = "YXRpb25UeXBlLkdsb2JhbENhY2hlQ29tbWFuZC5Db21tYW5kQWN0aW9uEg4K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 172) = "Bm91dHB1dBgCIAEoDRIQCghpbnRlcnZhbBgDIAEoDSKQAQoNQ29tbWFuZEFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 173) = "dGlvbhIVChFDT01NQU5EX0FDVElPTl9PThAAEhYKEkNPTU1BTkRfQUNUSU9O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 174) = "X09GRhABEicKI0NPTU1BTkRfQUNUSU9OX09OX09GRl9XSVRIX0lOVEVSVkFM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 175) = "EAISJwojQ09NTUFORF9BQ1RJT05fT0ZGX09OX1dJVEhfSU5URVJWQUwQAxq4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 176) = "AQoNR1ZHMTAwQ29tbWFuZBJVCg5jb21tYW5kX2FjdGlvbhgBIAEoDjI9LnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 177) = "LmRhdGEuQWN0aW9uLkNvbW11bmljYXRpb25UeXBlLkdWRzEwMENvbW1hbmQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 178) = "Q29tbWFuZEFjdGlvbiJQCg1Db21tYW5kQWN0aW9uEiAKHENPTU1BTkRfQUNU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 179) = "SU9OX0ZBREVfVE9fQkxBQ0sQABIdChlDT01NQU5EX0FDVElPTl9EU0tfVE9H";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 180) = "R0xFEAEaigIKDlNvbnlCVlNDb21tYW5kElYKDmNvbW1hbmRfYWN0aW9uGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 181) = "ASgOMj4ucnYuZGF0YS5BY3Rpb24uQ29tbXVuaWNhdGlvblR5cGUuU29ueUJW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 182) = "U0NvbW1hbmQuQ29tbWFuZEFjdGlvbiKfAQoNQ29tbWFuZEFjdGlvbhIgChxD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 183) = "T01NQU5EX0FDVElPTl9GQURFX1RPX0JMQUNLEAASGQoVQ09NTUFORF9BQ1RJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 184) = "T05fS0VZX09OEAESGgoWQ09NTUFORF9BQ1RJT05fS0VZX09GRhACEhkKFUNP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 185) = "TU1BTkRfQUNUSU9OX0RTS19PThADEhoKFkNPTU1BTkRfQUNUSU9OX0RTS19P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 186) = "RkYQBEIRCg9Db21tYW5kVHlwZURhdGEaVQoPTXVsdGlTY3JlZW5UeXBlEjYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 187) = "DmlkZW50aWZpY2F0aW9uGAMgASgLMh4ucnYuZGF0YS5Db2xsZWN0aW9uRWxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 188) = "bWVudFR5cGVKBAgBEAJKBAgCEAMawAEKDERvY3VtZW50VHlwZRI8Cg5pZGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 189) = "dGlmaWNhdGlvbhgBIAEoCzIeLnJ2LmRhdGEuQ29sbGVjdGlvbkVsZW1lbnRU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 190) = "eXBlQgSohhkBEjEKFHNlbGVjdGVkX2FycmFuZ2VtZW50GAIgASgLMg0ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 191) = "ZGF0YS5VVUlEQgSghhkBEj8KE2NvbnRlbnRfZGVzdGluYXRpb24YAyABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 192) = "Ii5ydi5kYXRhLkFjdGlvbi5Db250ZW50RGVzdGluYXRpb24aNQoYRXh0ZXJu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 193) = "YWxQcmVzZW50YXRpb25UeXBlEhkKA3VybBgBIAEoCzIMLnJ2LmRhdGEuVVJM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 194) = "GkoKEEF1ZGllbmNlTG9va1R5cGUSNgoOaWRlbnRpZmljYXRpb24YASABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 195) = "Hi5ydi5kYXRhLkNvbGxlY3Rpb25FbGVtZW50VHlwZRqYAQoOQXVkaW9JbnB1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 196) = "dFR5cGUSDQoFaW5kZXgYASABKAUSFQoNb3ZlcnJpZGVfbW9kZRgCIAEoCBI3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 197) = "Cg1iZWhhdmlvcl9tb2RlGAMgASgLMiAucnYuZGF0YS5BdWRpb0lucHV0LkJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 198) = "aGF2aW9yTW9kZRIXCg9vdmVycmlkZV92b2x1bWUYBCABKAgSDgoGdm9sdW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 199) = "GAUgASgBGkMKCU1hY3JvVHlwZRI2Cg5pZGVudGlmaWNhdGlvbhgBIAEoCzIe";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 200) = "LnJ2LmRhdGEuQ29sbGVjdGlvbkVsZW1lbnRUeXBlGpsCCgtDYXB0dXJlVHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 201) = "ZRI5CgVzdGFydBgBIAEoCzIoLnJ2LmRhdGEuQWN0aW9uLkNhcHR1cmVUeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 202) = "LkNhcHR1cmVTdGFydEgAEjcKBHN0b3AYAiABKAsyJy5ydi5kYXRhLkFjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 203) = "bi5DYXB0dXJlVHlwZS5DYXB0dXJlU3RvcEgAGlMKDENhcHR1cmVTdGFydBJD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 204) = "ChVwcmVzZXRfaWRlbnRpZmljYXRpb24YASABKAsyHi5ydi5kYXRhLkNvbGxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 205) = "Y3Rpb25FbGVtZW50VHlwZUIEoIYZARoyCgtDYXB0dXJlU3RvcBIjChtzaG93";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 206) = "c19hbGVydF9iZWZvcmVfc3RvcHBpbmcYASABKAhCDwoNQ2FwdHVyZUFjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 207) = "biJbChJDb250ZW50RGVzdGluYXRpb24SHgoaQ09OVEVOVF9ERVNUSU5BVElP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 208) = "Tl9HTE9CQUwQABIlCiFDT05URU5UX0RFU1RJTkFUSU9OX0FOTk9VTkNFTUVO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 209) = "VFMQASJsCglMYXllclR5cGUSGQoVTEFZRVJfVFlQRV9CQUNLR1JPVU5EEAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 210) = "GQoVTEFZRVJfVFlQRV9GT1JFR1JPVU5EEAESEwoPTEFZRVJfVFlQRV9GSUxM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 211) = "EAISFAoQTEFZRVJfVFlQRV9JTlBVVBADIp8GCgpBY3Rpb25UeXBlEhcKE0FD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 212) = "VElPTl9UWVBFX1VOS05PV04QABIcChhBQ1RJT05fVFlQRV9TVEFHRV9MQVlP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 213) = "VVQQARIVChFBQ1RJT05fVFlQRV9NRURJQRACEhUKEUFDVElPTl9UWVBFX1RJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 214) = "TUVSEAMSHQoZQUNUSU9OX1RZUEVfQ09NTVVOSUNBVElPThAEEhUKEUFDVElP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 215) = "Tl9UWVBFX0NMRUFSEAUSFAoQQUNUSU9OX1RZUEVfUFJPUBAGEhgKEEFDVElP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 216) = "Tl9UWVBFX01BU0sQBxoCCAESFwoTQUNUSU9OX1RZUEVfTUVTU0FHRRAIEhwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 217) = "GEFDVElPTl9UWVBFX1NPQ0lBTF9NRURJQRAJEh8KF0FDVElPTl9UWVBFX01V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 218) = "TFRJU0NSRUVOEAoaAggBEiIKHkFDVElPTl9UWVBFX1BSRVNFTlRBVElPTl9T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 219) = "TElERRALEiQKHEFDVElPTl9UWVBFX0ZPUkVHUk9VTkRfTUVESUEQDBoCCAES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 220) = "JAocQUNUSU9OX1RZUEVfQkFDS0dST1VORF9NRURJQRANGgIIARIlCiFBQ1RJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 221) = "T05fVFlQRV9QUkVTRU5UQVRJT05fRE9DVU1FTlQQDhIaChZBQ1RJT05fVFlQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 222) = "RV9QUk9QX1NMSURFEA8SJQohQUNUSU9OX1RZUEVfRVhURVJOQUxfUFJFU0VO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 223) = "VEFUSU9OEBESHQoZQUNUSU9OX1RZUEVfQVVESUVOQ0VfTE9PSxASEhsKF0FD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 224) = "VElPTl9UWVBFX0FVRElPX0lOUFVUEBMSIgoeQUNUSU9OX1RZUEVfQVVESU9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 225) = "QklOX1BMQVlMSVNUEBQSIgoeQUNUSU9OX1RZUEVfTUVESUFfQklOX1BMQVlM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 226) = "SVNUEBUSIQodQUNUSU9OX1RZUEVfU0xJREVfREVTVElOQVRJT04QFhIVChFB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 227) = "Q1RJT05fVFlQRV9NQUNSTxAXEhsKF0FDVElPTl9UWVBFX0NMRUFSX0dST1VQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 228) = "EBgSFwoTQUNUSU9OX1RZUEVfQ0FQVFVSRRAZEiAKHEFDVElPTl9UWVBFX0xJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 229) = "QlJBUllfUExBWUxJU1QQGkIQCg5BY3Rpb25UeXBlRGF0YUoECB8QIFIMc29j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 230) = "aWFsX21lZGlhQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray232<string>, string>(ref buffer, 231) = "cm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray232<string>, string>(in buffer, 232))), new FileDescriptor[16]
		{
			BackgroundReflection.Descriptor,
			CollectionElementTypeReflection.Descriptor,
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			EffectsReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			InputReflection.Descriptor,
			IntRangeReflection.Descriptor,
			LayersReflection.Descriptor,
			MessagesReflection.Descriptor,
			PropSlideReflection.Descriptor,
			PresentationSlideReflection.Descriptor,
			StageReflection.Descriptor,
			TimersReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Action), Action.Parser, new string[35]
			{
				"Uuid", "Name", "Label", "DelayTime", "OldType", "IsEnabled", "LayerIdentification", "Duration", "Type", "CollectionElement",
				"PlaylistItem", "BlendMode", "Transition", "Media", "DoubleItem", "Effects", "Slide", "Background", "Timer", "Clear",
				"Stage", "Prop", "Mask", "Message", "Communication", "MultiScreen", "PresentationDocument", "ExternalPresentation", "AudienceLook", "AudioInput",
				"SlideDestination", "Macro", "ClearGroup", "TransportControl", "Capture"
			}, new string[1] { "ActionTypeData" }, new Type[3]
			{
				typeof(Action.Types.ContentDestination),
				typeof(Action.Types.LayerType),
				typeof(Action.Types.ActionType)
			}, null, new GeneratedClrTypeInfo[28]
			{
				new GeneratedClrTypeInfo(typeof(Action.Types.OldType), Action.Types.OldType.Parser, new string[2] { "Category", "ApplicationType" }, null, new Type[1] { typeof(Action.Types.OldType.Types.Category) }, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.Label), Action.Types.Label.Parser, new string[2] { "Text", "Color" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.LayerIdentification), Action.Types.LayerIdentification.Parser, new string[2] { "Uuid", "Name" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.PlaylistItemType), Action.Types.PlaylistItemType.Parser, new string[6] { "PlaylistUuid", "PlaylistName", "ItemUuid", "ItemName", "SelectPlaylist", "AlwaysRetrigger" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.BlendModeType), Action.Types.BlendModeType.Parser, new string[2] { "BlendMode", "Blend" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.TransitionType), Action.Types.TransitionType.Parser, new string[2] { "TransitionName", "Transition" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.DoubleType), Action.Types.DoubleType.Parser, new string[1] { "Value" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.EffectsType), Action.Types.EffectsType.Parser, new string[1] { "Effects" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.MediaType), Action.Types.MediaType.Parser, new string[12]
				{
					"TransitionDuration", "SelectedEffectPresetUuid", "Transition", "Effects", "Element", "Image", "Video", "Audio", "LiveVideo", "LayerType",
					"AlwaysRetrigger", "Markers"
				}, new string[1] { "MediaType" }, new Type[2]
				{
					typeof(Action.Types.MediaType.Types.PlaybackBehavior),
					typeof(Action.Types.MediaType.Types.EndBehavior)
				}, null, new GeneratedClrTypeInfo[5]
				{
					new GeneratedClrTypeInfo(typeof(Action.Types.MediaType.Types.Image), Action.Types.MediaType.Types.Image.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.MediaType.Types.Video), Action.Types.MediaType.Types.Video.Parser, new string[6] { "PlaybackBehavior", "EndBehavior", "LoopTime", "TimesToLoop", "SoftLoop", "SoftLoopDuration" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.MediaType.Types.Audio), Action.Types.MediaType.Types.Audio.Parser, new string[4] { "PlaybackBehavior", "LoopTime", "TimesToLoop", "AudioType" }, null, new Type[1] { typeof(Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType) }, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.MediaType.Types.LiveVideo), Action.Types.MediaType.Types.LiveVideo.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.MediaType.Types.PlaybackMarker), Action.Types.MediaType.Types.PlaybackMarker.Parser, new string[5] { "Uuid", "Time", "Color", "Name", "Actions" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Action.Types.SlideType), Action.Types.SlideType.Parser, new string[2] { "Presentation", "Prop" }, new string[1] { "Slide" }, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.BackgroundType), Action.Types.BackgroundType.Parser, new string[1] { "Element" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.TimerType), Action.Types.TimerType.Parser, new string[4] { "ActionType", "TimerIdentification", "TimerConfiguration", "IncrementAmount" }, null, new Type[1] { typeof(Action.Types.TimerType.Types.TimerAction) }, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.ClearType), Action.Types.ClearType.Parser, new string[2] { "TargetLayer", "ContentDestination" }, null, new Type[1] { typeof(Action.Types.ClearType.Types.ClearTargetLayer) }, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.ClearGroupType), Action.Types.ClearGroupType.Parser, new string[1] { "Identification" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.TransportControlType), Action.Types.TransportControlType.Parser, new string[3] { "Play", "Pause", "JumpToTime" }, new string[1] { "Command" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(Action.Types.TransportControlType.Types.Play), Action.Types.TransportControlType.Types.Play.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.TransportControlType.Types.Pause), Action.Types.TransportControlType.Types.Pause.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.TransportControlType.Types.JumpToTime), Action.Types.TransportControlType.Types.JumpToTime.Parser, new string[1] { "Time" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Action.Types.StageLayoutType), Action.Types.StageLayoutType.Parser, new string[2] { "StageScreenAssignments", "SlideTarget" }, null, new Type[1] { typeof(Action.Types.StageLayoutType.Types.SlideTarget) }, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.SlideDestinationType), Action.Types.SlideDestinationType.Parser, new string[1] { "SlideTarget" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.PropType), Action.Types.PropType.Parser, new string[3] { "Identification", "Trigger", "Clear" }, new string[1] { "TriggerType" }, null, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(Action.Types.PropType.Types.PropTrigger), Action.Types.PropType.Types.PropTrigger.Parser, new string[3] { "AutoClearEnabled", "AutoClearFollowsPropDuration", "AutoClearDuration" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.PropType.Types.PropClear), Action.Types.PropType.Types.PropClear.Parser, null, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Action.Types.MaskType), Action.Types.MaskType.Parser, new string[1] { "Identification" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.MessageType), Action.Types.MessageType.Parser, new string[2] { "MessageIdentificaton", "Content" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.CommunicationType), Action.Types.CommunicationType.Parser, new string[8] { "DeviceIdentification", "Format", "Description", "Commands", "MidiCommand", "GlobalCacheCommand", "Gvg100Command", "SonyBVSCommand" }, new string[1] { "CommandTypeData" }, null, null, new GeneratedClrTypeInfo[5]
				{
					new GeneratedClrTypeInfo(typeof(Action.Types.CommunicationType.Types.Command), Action.Types.CommunicationType.Types.Command.Parser, new string[4] { "Name", "Value", "ReplacementRange", "PossibleValues" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.CommunicationType.Types.MIDICommand), Action.Types.CommunicationType.Types.MIDICommand.Parser, new string[4] { "State", "Channel", "Note", "Intensity" }, null, new Type[1] { typeof(Action.Types.CommunicationType.Types.MIDICommand.Types.State) }, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.CommunicationType.Types.GlobalCacheCommand), Action.Types.CommunicationType.Types.GlobalCacheCommand.Parser, new string[3] { "CommandAction", "Output", "Interval" }, null, new Type[1] { typeof(Action.Types.CommunicationType.Types.GlobalCacheCommand.Types.CommandAction) }, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.CommunicationType.Types.GVG100Command), Action.Types.CommunicationType.Types.GVG100Command.Parser, new string[1] { "CommandAction" }, null, new Type[1] { typeof(Action.Types.CommunicationType.Types.GVG100Command.Types.CommandAction) }, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.CommunicationType.Types.SonyBVSCommand), Action.Types.CommunicationType.Types.SonyBVSCommand.Parser, new string[1] { "CommandAction" }, null, new Type[1] { typeof(Action.Types.CommunicationType.Types.SonyBVSCommand.Types.CommandAction) }, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Action.Types.MultiScreenType), Action.Types.MultiScreenType.Parser, new string[1] { "Identification" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.DocumentType), Action.Types.DocumentType.Parser, new string[3] { "Identification", "SelectedArrangement", "ContentDestination" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.ExternalPresentationType), Action.Types.ExternalPresentationType.Parser, new string[1] { "Url" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.AudienceLookType), Action.Types.AudienceLookType.Parser, new string[1] { "Identification" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.AudioInputType), Action.Types.AudioInputType.Parser, new string[5] { "Index", "OverrideMode", "BehaviorMode", "OverrideVolume", "Volume" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.MacroType), Action.Types.MacroType.Parser, new string[1] { "Identification" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Action.Types.CaptureType), Action.Types.CaptureType.Parser, new string[2] { "Start", "Stop" }, new string[1] { "CaptureAction" }, null, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(Action.Types.CaptureType.Types.CaptureStart), Action.Types.CaptureType.Types.CaptureStart.Parser, new string[1] { "PresetIdentification" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Action.Types.CaptureType.Types.CaptureStop), Action.Types.CaptureType.Types.CaptureStop.Parser, new string[1] { "ShowsAlertBeforeStopping" }, null, null, null, null)
				})
			})
		}));
	}
}
