using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

public static class AnalyticsStartupReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsStartupReflection()
	{
		_003C_003Ey__InlineArray119<string> buffer = default(_003C_003Ey__InlineArray119<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 0) = "ChZhbmFseXRpY3NTdGFydHVwLnByb3RvEhRydi5hbmFseXRpY3Muc3RhcnR1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 1) = "cCIfCgVMb29rcxIWCg5udW1iZXJfcHJlc2V0cxgBIAEoBSJbCgdTdW1tYXJ5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 2) = "EhUKDXRvdGFsX3NjcmVlbnMYASABKAUSHQoVYXVkaWVuY2Vfc2NyZWVuX2Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 3) = "dW50GAIgASgFEhoKEnN0YWdlX3NjcmVlbl9jb3VudBgDIAEoBSLnBgoGT3V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 4) = "cHV0EkIKDnByb3NjcmVlbl90eXBlGAEgASgOMioucnYuYW5hbHl0aWNzLnN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 5) = "YXJ0dXAuT3V0cHV0LlByb1NjcmVlblR5cGUSPAoLb3V0cHV0X3R5cGUYAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 6) = "KA4yJy5ydi5hbmFseXRpY3Muc3RhcnR1cC5PdXRwdXQuT3V0cHV0VHlwZRIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 7) = "Chhjb2xvcl9jb3JyZWN0aW9uX2VuYWJsZWQYAyABKAgSGgoSY29ybmVyX3Bp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 8) = "bl9lbmFibGVkGAQgASgIEjkKCWFsaWdubWVudBgFIAEoDjImLnJ2LmFuYWx5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 9) = "dGljcy5zdGFydHVwLk91dHB1dC5BbGlnbm1lbnQSDQoFd2lkdGgYBiABKAUS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 10) = "DgoGaGVpZ2h0GAcgASgFEkEKDmFscGhhX2tleV9tb2RlGAggASgOMikucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 11) = "YW5hbHl0aWNzLnN0YXJ0dXAuT3V0cHV0LkFscGhhS2V5TW9kZRI+CgxhbHBo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 12) = "YV9kZXZpY2UYCSABKA4yKC5ydi5hbmFseXRpY3Muc3RhcnR1cC5PdXRwdXQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 13) = "QWxwaGFEZXZpY2USEwoLaXNfZGlzYWJsZWQYCiABKAgiYwoNUHJvU2NyZWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 14) = "VHlwZRIbChdQUk9fU0NSRUVOX1RZUEVfVU5LTk9XThAAEgoKBlNJTkdMRRAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 15) = "EgwKCE1JUlJPUkVEEAISDgoKRURHRV9CTEVORBADEgsKB0dST1VQRUQQBCJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 16) = "CgpPdXRwdXRUeXBlEhcKE09VVFBVVF9UWVBFX1VOS05PV04QABIHCgNTREkQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 17) = "ARIHCgNOREkQAhIKCgZTWVBIT04QAxIKCgZTWVNURU0QBBIPCgtQTEFDRUhP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 18) = "TERFUhAFEgcKA0RWSRAGIlYKCUFsaWdubWVudBIVChFBTElHTk1FTlRfVU5L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 19) = "Tk9XThAAEggKBEZVTEwQARIICgRfMlgxEAISCAoEXzNYMRADEggKBF8yWDIQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 20) = "BBIKCgZDVVNUT00QBSJICgxBbHBoYUtleU1vZGUSFwoTQUxQSEFfS0VZX01P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 21) = "REVfTk9ORRAAEhEKDVBSRU1VTFRJUExJRUQQARIMCghTVFJBSUdIVBACIjkK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 22) = "C0FscGhhRGV2aWNlEhUKEUFMUEhBX0RFVklDRV9OT05FEAASCAoEU0VMRhAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 23) = "EgkKBU9USEVSEAIiXQoGU2luZ2xlEjUKC3NjcmVlbl90eXBlGAEgASgOMiAu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 24) = "cnYuYW5hbHl0aWNzLnN0YXJ0dXAuU2NyZWVuVHlwZRIcChRzY3JlZW5fY29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 25) = "b3JfZW5hYmxlZBgCIAEoCCJuCghNaXJyb3JlZBI1CgtzY3JlZW5fdHlwZRgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 26) = "IAEoDjIgLnJ2LmFuYWx5dGljcy5zdGFydHVwLlNjcmVlblR5cGUSHAoUc2Ny";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 27) = "ZWVuX2NvbG9yX2VuYWJsZWQYAiABKAgSDQoFY291bnQYAyABKAUibwoJRWRn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 28) = "ZUJsZW5kEjUKC3NjcmVlbl90eXBlGAEgASgOMiAucnYuYW5hbHl0aWNzLnN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 29) = "YXJ0dXAuU2NyZWVuVHlwZRIcChRzY3JlZW5fY29sb3JfZW5hYmxlZBgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 30) = "CBINCgVjb3VudBgDIAEoBSJ9CgdHcm91cGVkEjUKC3NjcmVlbl90eXBlGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 31) = "ASgOMiAucnYuYW5hbHl0aWNzLnN0YXJ0dXAuU2NyZWVuVHlwZRIcChRzY3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 32) = "ZW5fY29sb3JfZW5hYmxlZBgCIAEoCBIPCgdjb2x1bW5zGAMgASgFEgwKBHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 33) = "d3MYBCABKAUipgUKC1ByZWZlcmVuY2VzEhgKEGhvdXNlX29mX3dvcnNoaXAY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 34) = "ASABKAgSFwoPaGFzX2N1c3RvbV9sb2dvGAIgASgIEhkKEWNvcHlyaWdodF9l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 35) = "bmFibGVkGAMgASgIEkkKD2NvcHlyaWdodF9zdHlsZRgEIAEoDjIwLnJ2LmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 36) = "YWx5dGljcy5zdGFydHVwLlByZWZlcmVuY2VzLkNvcHlyaWdodFN0eWxlEh0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 37) = "FWNvcHlyaWdodF9oYXNfbGljZW5zZRgFIAEoCBJBCgtyZW5kZXJfbW9kZRgG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 38) = "IAEoDjIsLnJ2LmFuYWx5dGljcy5zdGFydHVwLlByZWZlcmVuY2VzLlJlbmRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 39) = "ck1vZGUSGwoTc3VwcHJlc3NfYXV0b19zdGFydBgHIAEoCBIiChptYW5hZ2Vf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 40) = "bWVkaWFfYXV0b21hdGljYWxseRgIIAEoCBIbChNzZWFyY2hfcGF0aHNfcmVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 41) = "aW5rGAkgASgIEkcKDnVwZGF0ZV9jaGFubmVsGAogASgOMi8ucnYuYW5hbHl0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 42) = "aWNzLnN0YXJ0dXAuUHJlZmVyZW5jZXMuVXBkYXRlQ2hhbm5lbCJmCg5Db3B5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 43) = "cmlnaHRTdHlsZRIbChdDT1BZUklHSFRfU1RZTEVfVU5LTk9XThAAEgkKBUZJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 44) = "UlNUEAESCAoETEFTVBACEhIKDkZJUlNUX0FORF9MQVNUEAMSDgoKQUxMX1NM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 45) = "SURFUxAEIkkKClJlbmRlck1vZGUSFwoTUkVOREVSX01PREVfVU5LTk9XThAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 46) = "EgoKBk9QRU5HTBABEgkKBU1FVEFMEAISCwoHRElSRUNUWBADIkIKDVVwZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 47) = "ZUNoYW5uZWwSGgoWVVBEQVRFX0NIQU5ORUxfVU5LTk9XThAAEgsKB1JFTEVB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 48) = "U0UQARIICgRCRVRBEAIijgEKB1NjcmVlbnMSGwoTc2hvd19zY3JlZW5zX2xh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 49) = "dW5jaBgBIAEoCBIiChpzaG93X3BlcmZvcm1hbmNlX29uX3NjcmVlbhgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 50) = "CBIgChhpZ25vcmVfYmFja2dyb3VuZF9jb2xvcnMYAyABKAgSIAoYc2hvd19r";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 51) = "ZXlub3RlX3BwdF9zY3JlZW5zGAQgASgIIj8KClNvbmdTZWxlY3QSEQoJbG9n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 52) = "Z2VkX2luGAEgASgIEh4KFmF1dG9fcmVwb3J0aW5nX2VuYWJsZWQYAiABKAgi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 53) = "swYKB0NvbnRlbnQSFQoNbGlicmFyeV9jb3VudBgBIAEoBRIeChZsaWJyYXJ5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 54) = "X3BsYXlsaXN0X2NvdW50GAIgASgFEiUKHWxpYnJhcnlfcGxheWxpc3RfZm9s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 55) = "ZGVyX2NvdW50GAMgASgFEiIKGmxpYnJhcnlfcGxheWxpc3RfbWF4X2RlcHRo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 56) = "GAQgASgFEiYKHm1lZGlhX2Jpbl90b3RhbF9wbGF5bGlzdF9jb3VudBgFIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 57) = "BRInCh9tZWRpYV9iaW5fcGxheWxpc3RfZm9sZGVyX2NvdW50GAYgASgFEiQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 58) = "HG1lZGlhX2Jpbl9wbGF5bGlzdF9tYXhfZGVwdGgYByABKAUSJwofbWVkaWFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 59) = "YmluX25vcm1hbF9wbGF5bGlzdF9jb3VudBgIIAEoBRImCh5tZWRpYV9iaW5f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 60) = "c21hcnRfcGxheWxpc3RfY291bnQYCSABKAUSIwobbWVkaWFfYmluX3ZpZGVv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 61) = "X2lucHV0X2NvdW50GAogASgFEiAKGGF1ZGlvX2Jpbl9wbGF5bGlzdF9jb3Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 62) = "dBgLIAEoBRInCh9hdWRpb19iaW5fcGxheWxpc3RfZm9sZGVyX2NvdW50GAwg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 63) = "ASgFEiQKHGF1ZGlvX2Jpbl9wbGF5bGlzdF9tYXhfZGVwdGgYDSABKAUSEwoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 64) = "dGltZXJfY291bnQYDiABKAUSFgoObWVzc2FnZXNfY291bnQYDyABKAUSEwoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 65) = "cHJvcHNfY291bnQYECABKAUSHgoWcHJvcHNfYXV0b19jbGVhcl9jb3VudBgR";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 66) = "IAEoBRIeChZwcm9wX2NvbGxlY3Rpb25zX2NvdW50GBIgASgFEjIKKnByb3Bf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 67) = "Y29sbGVjdGlvbnNfc2luZ2xlX3Byb3BfZW5hYmxlZF9jb3VudBgTIAEoBRIa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 68) = "ChJzdGFnZV9sYXlvdXRfY291bnQYFCABKAUSFAoMbWFjcm9zX2NvdW50GBUg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 69) = "ASgFEiAKGG1hY3Jvc19jb2xsZWN0aW9uc19jb3VudBgWIAEoBRIbChNtYWNy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 70) = "b3NfY3VzdG9tX2ljb25zGBcgASgFEiEKGXViaXF1aXRvdXNfc2hvd19kaXJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 71) = "Y3RvcnkYGCABKAgidQoGVGhlbWVzEhMKC3RoZW1lX2NvdW50GAEgASgFEhoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 72) = "EnRoZW1lX2ZvbGRlcl9jb3VudBgCIAEoBRIeChZ0aGVtZV9mb2xkZXJfbWF4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 73) = "X2RlcHRoGAMgASgFEhoKEnRoZW1lX3NsaWRlc19jb3VudBgEIAEoBSIpCgVN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 74) = "YWNybxIgChh0cmlnZ2VyX29uX3N0YXJ0dXBfY291bnQYASABKAUimQEKCkNs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 75) = "ZWFyR3JvdXASGQoRY2xlYXJfZ3JvdXBfY291bnQYASABKAUSIAoYaGlkZGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 76) = "X2NsZWFyX2dyb3VwX2NvdW50GAIgASgFEhoKEmRlZmF1bHRfaWNvbl9jb3Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 77) = "dBgDIAEoBRIZChFjdXN0b21faWNvbl9jb3VudBgEIAEoBRIXCg9pY29uX3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 78) = "bnRfY291bnQYBSABKAUidgoKS2V5TWFwcGluZxIUCgx0b3RhbF9tYXBwZWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 79) = "ASABKAUSFAoMY2xlYXJfZ3JvdXBzGAIgASgFEg4KBmdyb3VwcxgDIAEoBRIO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 80) = "CgZtYWNyb3MYBCABKAUSDQoFcHJvcHMYBSABKAUSDQoFbWVudXMYBiABKAUi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 81) = "NAoLTmV0d29ya0xpbmsSDwoHZW5hYmxlZBgBIAEoCBIUCgxtZW1iZXJfY291";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 82) = "bnQYAiABKA0idAoHQ2FwdHVyZRIVCg1wcmVzZXRzX2NvdW50GAEgASgFEhoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 83) = "EmRpc2tfcHJlc2V0c19jb3VudBgCIAEoBRIaChJydG1wX3ByZXNldHNfY291";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 84) = "bnQYAyABKAUSGgoScmVzaV9wcmVzZXRzX2NvdW50GAQgASgFIiUKClZlcnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 85) = "b25pbmcSFwoPaGlnaGVzdF92ZXJzaW9uGAEgASgJIp8BCglEaXNrVXNhZ2US";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 86) = "GwoTYnl0ZXNfb2Zfc2hvd19maWxlcxgBIAEoBBIiChpieXRlc19vZl9tZWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 87) = "YV9hc3NldF9maWxlcxgCIAEoBBIjChtudW1iZXJfb2ZfbWVkaWFfYXNzZXRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 88) = "ZmlsZXMYAyABKAQSLAokYnl0ZXNfb2ZfdW5tYW5hZ2VkX21lZGlhX2Fzc2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 89) = "X2ZpbGVzGAQgASgEIk8KDExpYnJhcnlVc2FnZRIfChdudW1iZXJfb2ZfcHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 90) = "c2VudGF0aW9ucxgBIAEoBBIeChZieXRlc19vZl9wcmVzZW50YXRpb25zGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 91) = "ASgEIrsICglJbnRlcmZhY2USRwoPbGlicmFyeV9vdXRsaW5lGAEgASgOMi4u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 92) = "cnYuYW5hbHl0aWNzLnN0YXJ0dXAuSW50ZXJmYWNlLlNwbGl0Vmlld1N0YXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 93) = "EkUKDW1lZGlhX291dGxpbmUYAiABKA4yLi5ydi5hbmFseXRpY3Muc3RhcnR1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 94) = "cC5JbnRlcmZhY2UuU3BsaXRWaWV3U3RhdGUSRQoNYXVkaW9fb3V0bGluZRgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 95) = "IAEoDjIuLnJ2LmFuYWx5dGljcy5zdGFydHVwLkludGVyZmFjZS5TcGxpdFZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 96) = "ZXdTdGF0ZRIbChNjb250aW51b3VzX3BsYXlsaXN0GAQgASgIEkEKCW1lZGlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 97) = "X2JpbhgFIAEoDjIuLnJ2LmFuYWx5dGljcy5zdGFydHVwLkludGVyZmFjZS5T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 98) = "cGxpdFZpZXdTdGF0ZRJWChdwcmVzZW50YXRpb25fdmlld19zdHlsZRgGIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 99) = "DjI1LnJ2LmFuYWx5dGljcy5zdGFydHVwLkludGVyZmFjZS5QcmVzZW50YXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 100) = "b25WaWV3U3R5bGUSJgoecHJlc2VudGF0aW9uX2dyaWRfY29sdW1uX2NvdW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 101) = "GAcgASgFEk8KFG1lZGlhX2Jpbl92aWV3X3N0eWxlGAggASgOMjEucnYuYW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 102) = "bHl0aWNzLnN0YXJ0dXAuSW50ZXJmYWNlLk1lZGlhQmluVmlld1N0eWxlEiMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 103) = "G21lZGlhX2Jpbl9ncmlkX2NvbHVtbl9jb3VudBgJIAEoBRIkChxtZWRpYV9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 104) = "aW5fdGFibGVfY29sdW1uX2NvdW50GAogASgFEh8KF3ByZXNlbnRhdGlvbl90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 105) = "cmFuc2l0aW9uGAsgASgJEhgKEG1lZGlhX3RyYW5zaXRpb24YDCABKAkSFQoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 106) = "YXVkaW9fc2h1ZmZsZRgNIAEoCCJtCg5TcGxpdFZpZXdTdGF0ZRIcChhTUExJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 107) = "VF9WSUVXX1NUQVRFX1VOS05PV04QABIeChpTUExJVF9WSUVXX1NUQVRFX0NP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 108) = "TExBUFNFRBABEh0KGVNQTElUX1ZJRVdfU1RBVEVfRVhQQU5ERUQQAiKjAQoV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 109) = "UHJlc2VudGF0aW9uVmlld1N0eWxlEiMKH1BSRVNFTlRBVElPTl9WSUVXX1NU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 110) = "WUxFX1VOS05PV04QABIgChxQUkVTRU5UQVRJT05fVklFV19TVFlMRV9HUklE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 111) = "EAESIAocUFJFU0VOVEFUSU9OX1ZJRVdfU1RZTEVfRUFTWRACEiEKHVBSRVNF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 112) = "TlRBVElPTl9WSUVXX1NUWUxFX1RBQkxFEAMidAoRTWVkaWFCaW5WaWV3U3R5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 113) = "bGUSIAocTUVESUFfQklOX1ZJRVdfU1RZTEVfVU5LTk9XThAAEh0KGU1FRElB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 114) = "X0JJTl9WSUVXX1NUWUxFX0dSSUQQARIeChpNRURJQV9CSU5fVklFV19TVFlM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 115) = "RV9UQUJMRRACKj4KClNjcmVlblR5cGUSFwoTU0NSRUVOX1RZUEVfVU5LTk9X";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 116) = "ThAAEgwKCEFVRElFTkNFEAESCQoFU1RBR0UQAkJR+AEBqgI2UHJvLlNlcmlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 117) = "bGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhLkFuYWx5dGljcy5TdGFydHVw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray119<string>, string>(ref buffer, 118) = "ugISQW5hbHl0aWNzX1N0YXJ0dXBfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray119<string>, string>(in buffer, 119))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[1] { typeof(ScreenType) }, null, new GeneratedClrTypeInfo[21]
		{
			new GeneratedClrTypeInfo(typeof(Looks), Looks.Parser, new string[1] { "NumberPresets" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Summary), Summary.Parser, new string[3] { "TotalScreens", "AudienceScreenCount", "StageScreenCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Output), Output.Parser, new string[10] { "ProscreenType", "OutputType", "ColorCorrectionEnabled", "CornerPinEnabled", "Alignment", "Width", "Height", "AlphaKeyMode", "AlphaDevice", "IsDisabled" }, null, new Type[5]
			{
				typeof(Output.Types.ProScreenType),
				typeof(Output.Types.OutputType),
				typeof(Output.Types.Alignment),
				typeof(Output.Types.AlphaKeyMode),
				typeof(Output.Types.AlphaDevice)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(Single), Single.Parser, new string[2] { "ScreenType", "ScreenColorEnabled" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Mirrored), Mirrored.Parser, new string[3] { "ScreenType", "ScreenColorEnabled", "Count" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(EdgeBlend), EdgeBlend.Parser, new string[3] { "ScreenType", "ScreenColorEnabled", "Count" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Grouped), Grouped.Parser, new string[4] { "ScreenType", "ScreenColorEnabled", "Columns", "Rows" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Preferences), Preferences.Parser, new string[10] { "HouseOfWorship", "HasCustomLogo", "CopyrightEnabled", "CopyrightStyle", "CopyrightHasLicense", "RenderMode", "SuppressAutoStart", "ManageMediaAutomatically", "SearchPathsRelink", "UpdateChannel" }, null, new Type[3]
			{
				typeof(Preferences.Types.CopyrightStyle),
				typeof(Preferences.Types.RenderMode),
				typeof(Preferences.Types.UpdateChannel)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(Screens), Screens.Parser, new string[4] { "ShowScreensLaunch", "ShowPerformanceOnScreen", "IgnoreBackgroundColors", "ShowKeynotePptScreens" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SongSelect), SongSelect.Parser, new string[2] { "LoggedIn", "AutoReportingEnabled" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Content), Content.Parser, new string[24]
			{
				"LibraryCount", "LibraryPlaylistCount", "LibraryPlaylistFolderCount", "LibraryPlaylistMaxDepth", "MediaBinTotalPlaylistCount", "MediaBinPlaylistFolderCount", "MediaBinPlaylistMaxDepth", "MediaBinNormalPlaylistCount", "MediaBinSmartPlaylistCount", "MediaBinVideoInputCount",
				"AudioBinPlaylistCount", "AudioBinPlaylistFolderCount", "AudioBinPlaylistMaxDepth", "TimerCount", "MessagesCount", "PropsCount", "PropsAutoClearCount", "PropCollectionsCount", "PropCollectionsSinglePropEnabledCount", "StageLayoutCount",
				"MacrosCount", "MacrosCollectionsCount", "MacrosCustomIcons", "UbiquitousShowDirectory"
			}, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Themes), Themes.Parser, new string[4] { "ThemeCount", "ThemeFolderCount", "ThemeFolderMaxDepth", "ThemeSlidesCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Macro), Macro.Parser, new string[1] { "TriggerOnStartupCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ClearGroup), ClearGroup.Parser, new string[5] { "ClearGroupCount", "HiddenClearGroupCount", "DefaultIconCount", "CustomIconCount", "IconTintCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(KeyMapping), KeyMapping.Parser, new string[6] { "TotalMapped", "ClearGroups", "Groups", "Macros", "Props", "Menus" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NetworkLink), NetworkLink.Parser, new string[2] { "Enabled", "MemberCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Capture), Capture.Parser, new string[4] { "PresetsCount", "DiskPresetsCount", "RtmpPresetsCount", "ResiPresetsCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Versioning), Versioning.Parser, new string[1] { "HighestVersion" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DiskUsage), DiskUsage.Parser, new string[4] { "BytesOfShowFiles", "BytesOfMediaAssetFiles", "NumberOfMediaAssetFiles", "BytesOfUnmanagedMediaAssetFiles" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LibraryUsage), LibraryUsage.Parser, new string[2] { "NumberOfPresentations", "BytesOfPresentations" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Interface), Interface.Parser, new string[13]
			{
				"LibraryOutline", "MediaOutline", "AudioOutline", "ContinuousPlaylist", "MediaBin", "PresentationViewStyle", "PresentationGridColumnCount", "MediaBinViewStyle", "MediaBinGridColumnCount", "MediaBinTableColumnCount",
				"PresentationTransition", "MediaTransition", "AudioShuffle"
			}, null, new Type[3]
			{
				typeof(Interface.Types.SplitViewState),
				typeof(Interface.Types.PresentationViewStyle),
				typeof(Interface.Types.MediaBinViewStyle)
			}, null, null)
		}));
	}
}
