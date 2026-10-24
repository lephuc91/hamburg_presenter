using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

public static class AnalyticsUIReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsUIReflection()
	{
		_003C_003Ey__InlineArray211<string> buffer = default(_003C_003Ey__InlineArray211<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 0) = "ChFhbmFseXRpY3NVSS5wcm90bxIPcnYuYW5hbHl0aWNzLnVpIqIBChBRdWlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 1) = "a1NlYXJjaFNob3duEjgKBnNvdXJjZRgBIAEoDjIoLnJ2LmFuYWx5dGljcy51";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 2) = "aS5RdWlja1NlYXJjaFNob3duLlNvdXJjZSJUCgZTb3VyY2USEgoOU09VUkNF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 3) = "X1VOS05PV04QABIUChBBUFBMSUNBVElPTl9NRU5VEAESCwoHVE9PTEJBUhAC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 4) = "EhMKD1VOTElOS0VEX0hFQURFUhADIpwBChFRdWlja1NlYXJjaFNlYXJjaBI5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 5) = "CgZzb3VyY2UYASABKA4yKS5ydi5hbmFseXRpY3MudWkuUXVpY2tTZWFyY2hT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 6) = "ZWFyY2guU291cmNlIkwKBlNvdXJjZRISCg5TT1VSQ0VfVU5LTk9XThAAEgsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 7) = "B0xJQlJBUlkQARIPCgtTT05HX1NFTEVDVBACEhAKDE1VTFRJX1RSQUNLUxAD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 8) = "IsYCChRRdWlja1NlYXJjaE9wZW5JdGVtcxI8CgZzb3VyY2UYASABKA4yLC5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 9) = "di5hbmFseXRpY3MudWkuUXVpY2tTZWFyY2hPcGVuSXRlbXMuU291cmNlEjoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 10) = "BXN0eWxlGAIgASgOMisucnYuYW5hbHl0aWNzLnVpLlF1aWNrU2VhcmNoT3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 11) = "bkl0ZW1zLlN0eWxlEg0KBWNvdW50GAMgASgFIkwKBlNvdXJjZRISCg5TT1VS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 12) = "Q0VfVU5LTk9XThAAEgsKB0xJQlJBUlkQARIPCgtTT05HX1NFTEVDVBACEhAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 13) = "DE1VTFRJX1RSQUNLUxADIlcKBVN0eWxlEhEKDVNUWUxFX1VOS05PV04QABIU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 14) = "ChBTVFlMRV9SRVRVUk5fS0VZEAESFgoSQ09NTUFORF9SRVRVUk5fS0VZEAIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 15) = "DQoJRFJBR19EUk9QEAMiEwoRVG9vbGJhclRoZW1lU2hvd24iqQEKF1Rvb2xi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 16) = "YXJUaGVtZUFwcGxpY2F0aW9uEj8KBnRhcmdldBgBIAEoDjIvLnJ2LmFuYWx5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 17) = "dGljcy51aS5Ub29sYmFyVGhlbWVBcHBsaWNhdGlvbi5UYXJnZXQiTQoGVGFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 18) = "Z2V0EhIKDlRBUkdFVF9VTktOT1dOEAASEwoPU0xJREVfU0VMRUNUSU9OEAES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 19) = "GgoWUFJFU0VOVEFUSU9OX1NFTEVDVElPThACIoUBCgxNYWluVmlld1Nob3cS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 20) = "NAoGc291cmNlGAEgASgOMiQucnYuYW5hbHl0aWNzLnVpLk1haW5WaWV3U2hv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 21) = "dy5Tb3VyY2UiPwoGU291cmNlEhIKDlNPVVJDRV9VTktOT1dOEAASCwoHVE9P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 22) = "TEJBUhABEhQKEEFQUExJQ0FUSU9OX01FTlUQAiKzAQoaTWFpblZpZXdQcmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 23) = "ZW50YXRpb25FZGl0b3ISQgoGc291cmNlGAEgASgOMjIucnYuYW5hbHl0aWNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 24) = "LnVpLk1haW5WaWV3UHJlc2VudGF0aW9uRWRpdG9yLlNvdXJjZSJRCgZTb3Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 25) = "Y2USEgoOU09VUkNFX1VOS05PV04QABILCgdUT09MQkFSEAESFAoQQVBQTElD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 26) = "QVRJT05fTUVOVRACEhAKDENPTlRFWFRfTUVOVRADIq8BChRNYWluVmlld1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 27) = "Zmxvd0VkaXRvchI8CgZzb3VyY2UYASABKA4yLC5ydi5hbmFseXRpY3MudWku";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 28) = "TWFpblZpZXdSZWZsb3dFZGl0b3IuU291cmNlIlkKBlNvdXJjZRISCg5TT1VS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 29) = "Q0VfVU5LTk9XThAAEgsKB1RPT0xCQVIQARIUChBBUFBMSUNBVElPTl9NRU5V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 30) = "EAISGAoUTElCUkFSWV9DT05URVhUX01FTlUQAyKHAQoNTWFpblZpZXdCaWJs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 31) = "ZRI1CgZzb3VyY2UYASABKA4yJS5ydi5hbmFseXRpY3MudWkuTWFpblZpZXdC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 32) = "aWJsZS5Tb3VyY2UiPwoGU291cmNlEhIKDlNPVVJDRV9VTktOT1dOEAASCwoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 33) = "VE9PTEJBUhABEhQKEEFQUExJQ0FUSU9OX01FTlUQAiI7CgxCaWJsZVRyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 34) = "ZXISKwoIbG9jYXRpb24YASABKA4yGS5ydi5hbmFseXRpY3MudWkuTG9jYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 35) = "b24ihAUKE0JpYmxlR2VuZXJhdGVTbGlkZXMSGQoRdHJhbnNsYXRpb25fY291";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 36) = "bnQYASABKAUSEwoLc2xpZGVfY291bnQYAiABKAUSTAoOdmVyc2VfbG9jYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 37) = "b24YAyABKA4yNC5ydi5hbmFseXRpY3MudWkuQmlibGVHZW5lcmF0ZVNsaWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 38) = "cy5UZXh0Qm94TG9jYXRpb24SUAoScmVmZXJlbmNlX2xvY2F0aW9uGAQgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 39) = "MjQucnYuYW5hbHl0aWNzLnVpLkJpYmxlR2VuZXJhdGVTbGlkZXMuVGV4dEJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 40) = "eExvY2F0aW9uEhoKEnNob3dfdmVyc2VfbnVtYmVycxgFIAEoCBIXCg9icmVh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 41) = "a19uZXdfdmVyc2UYBiABKAgSGwoTZGlzcGxheV90cmFuc2xhdGlvbhgHIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 42) = "CBIbChNwcmVzZXJ2ZV9mb250X2NvbG9yGAggASgIEksKD3JlZmVyZW5jZV9z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 43) = "dHlsZRgJIAEoDjIyLnJ2LmFuYWx5dGljcy51aS5CaWJsZUdlbmVyYXRlU2xp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 44) = "ZGVzLlJlZmVyZW5jZVR5cGUicwoPVGV4dEJveExvY2F0aW9uEh0KGVRFWFRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 45) = "Qk9YX0xPQ0FUSU9OX1VOS05PV04QABIRCg1MT0NBVElPTl9OT05FEAESFQoR";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 46) = "TE9DQVRJT05fVEVYVF9CT1gQAhIXChNMT0NBVElPTl9XSVRIX1ZFUlNFEAMi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 47) = "bAoNUmVmZXJlbmNlVHlwZRIaChZSRUZFUkVOQ0VfVFlQRV9VTktOT1dOEAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 48) = "EAoMUEFTU0FHRV9OT05FEAESEAoMUEFTU0FHRV9FQUNIEAISEAoMUEFTU0FH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 49) = "RV9MQVNUEAMSCQoFVkVSU0UQBCJAChFCaWJsZUdlbmVyYXRlTmV4dBIrCghs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 50) = "b2NhdGlvbhgBIAEoDjIZLnJ2LmFuYWx5dGljcy51aS5Mb2NhdGlvbiJEChVC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 51) = "aWJsZUdlbmVyYXRlUHJldmlvdXMSKwoIbG9jYXRpb24YASABKA4yGS5ydi5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 52) = "bmFseXRpY3MudWkuTG9jYXRpb24i0QEKD0JpYmxlU2F2ZVNsaWRlcxJGCgtk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 53) = "ZXN0aW5hdGlvbhgBIAEoDjIxLnJ2LmFuYWx5dGljcy51aS5CaWJsZVNhdmVT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 54) = "bGlkZXMuU2xpZGVEZXN0aW5hdGlvbiJ2ChBTbGlkZURlc3RpbmF0aW9uEh0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 55) = "GVNMSURFX0RFU1RJTkFUSU9OX1VOS05PV04QABITCg9TQVZFX1RPX0xJQlJB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 56) = "UlkQARIUChBTQVZFX1RPX1BMQVlMSVNUEAISGAoUQ09QWV9UT19QUkVTRU5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 57) = "QVRJT04QAyLeAQoLQmlibGVMb29rdXASNwoIbG9jYXRpb24YASABKA4yJS5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 58) = "di5hbmFseXRpY3MudWkuQmlibGVMb29rdXAuTG9jYXRpb24ilQEKCExvY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 59) = "aW9uEhQKEExPQ0FUSU9OX1VOS05PV04QABISCg5URVhUX1JFRkVSRU5DRRAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 60) = "Eg0KCU1FTlVfQk9PSxACEhAKDE1FTlVfQ0hBUFRFUhADEg4KCk1FTlVfVkVS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 61) = "U0UQBBIXChNURVhUX1NFQVJDSF9DSEFQVEVSEAUSFQoRVEVYVF9TRUFSQ0hf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 62) = "VkVSU0UQBiJPCgxCaWJsZUluc3RhbGwSHAoUZnJlZV9pbnN0YWxsZWRfY291";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 63) = "bnQYASABKAUSIQoZcHVyY2hhc2VkX2luc3RhbGxlZF9jb3VudBgCIAEoBSJO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 64) = "CgtCaWJsZVJlbW92ZRIcChRmcmVlX2luc3RhbGxlZF9jb3VudBgBIAEoBRIh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 65) = "ChlwdXJjaGFzZWRfaW5zdGFsbGVkX2NvdW50GAIgASgFIk8KDEJpYmxlU3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 66) = "cnR1cBIcChRmcmVlX2luc3RhbGxlZF9jb3VudBgBIAEoBRIhChlwdXJjaGFz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 67) = "ZWRfaW5zdGFsbGVkX2NvdW50GAIgASgFIpoBChJNYWluVmlld01hc2tFZGl0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 68) = "b3ISPgoGc291cmNlGAEgASgOMi4ucnYuYW5hbHl0aWNzLnVpLk1haW5WaWV3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 69) = "TWFza0VkaXRvci5NYXNrU291cmNlIkQKCk1hc2tTb3VyY2USFwoTTUFTS19T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 70) = "T1VSQ0VfVU5LTk9XThAAEgsKB1RPT0xCQVIQARIQCgxMT09LU19XSU5ET1cQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 71) = "AiK0AQoTTWFpblZpZXdTdGFnZUVkaXRvchJACgZzb3VyY2UYASABKA4yMC5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 72) = "di5hbmFseXRpY3MudWkuTWFpblZpZXdTdGFnZUVkaXRvci5TdGFnZVNvdXJj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 73) = "ZSJbCgtTdGFnZVNvdXJjZRIYChRTVEFHRV9TT1VSQ0VfVU5LTk9XThAAEgsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 74) = "B1RPT0xCQVIQARIUChBBUFBMSUNBVElPTl9NRU5VEAISDwoLTE9XRVJfUklH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 75) = "SFQQAyKlAQoTTWFpblZpZXdUaGVtZUVkaXRvchJACgZzb3VyY2UYASABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 76) = "MC5ydi5hbmFseXRpY3MudWkuTWFpblZpZXdUaGVtZUVkaXRvci5UaGVtZVNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 77) = "dXJjZSJMCgtUaGVtZVNvdXJjZRIYChRTVEFHRV9TT1VSQ0VfVU5LTk9XThAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 78) = "EgsKB1RPT0xCQVIQARIWChJUSEVNRV9DT05URVhUX01FTlUQAiKxAQoXTWFp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 79) = "blZpZXdDb3B5cmlnaHRFZGl0b3ISSAoGc291cmNlGAEgASgOMjgucnYuYW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 80) = "bHl0aWNzLnVpLk1haW5WaWV3Q29weXJpZ2h0RWRpdG9yLkNvcHlyaWdodFNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 81) = "dXJjZSJMCg9Db3B5cmlnaHRTb3VyY2USHAoYQ09QWVJJR0hUX1NPVVJDRV9V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 82) = "TktOT1dOEAASCwoHVE9PTEJBUhABEg4KClBSRUZFUkVOQ0UQAiKeAQoTTWFp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 83) = "blZpZXdQcm9wc0VkaXRvchJACgZzb3VyY2UYASABKA4yMC5ydi5hbmFseXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 84) = "Y3MudWkuTWFpblZpZXdQcm9wc0VkaXRvci5Qcm9wc1NvdXJjZSJFCgtQcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 85) = "c1NvdXJjZRIYChRQUk9QU19TT1VSQ0VfVU5LTk9XThAAEgsKB1RPT0xCQVIQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 86) = "ARIPCgtMT1dFUl9SSUdIVBACIhIKEExvd2VyUmlnaHRUaW1lcnMikwEKGExv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 87) = "d2VyUmlnaHRUaW1lcnNDb2xsYXBzZRI+CgVzdGF0ZRgBIAEoDjIvLnJ2LmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 88) = "YWx5dGljcy51aS5Mb3dlclJpZ2h0VGltZXJzQ29sbGFwc2UuU3RhdGUiNwoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 89) = "U3RhdGUSEQoNU1RBVEVfVU5LTk9XThAAEg0KCUNPTExBUFNFRBABEgwKCEVY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 90) = "UEFOREVEEAIimgEKFExvd2VyUmlnaHRUaW1lcnNFZGl0EjoKBWZpZWxkGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 91) = "ASgOMisucnYuYW5hbHl0aWNzLnVpLkxvd2VyUmlnaHRUaW1lcnNFZGl0LkZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 92) = "ZWxkIkYKBUZpZWxkEhEKDUZJRUxEX1VOS05PV04QABIICgRUWVBFEAESCQoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 93) = "VkFMVUUQAhILCgdPVkVSUlVOEAMSCAoETkFNRRAEIpABChVMb3dlclJpZ2h0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 94) = "VGltZXJzU3RhdGUSOwoFc3RhdGUYASABKA4yLC5ydi5hbmFseXRpY3MudWku";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 95) = "TG93ZXJSaWdodFRpbWVyc1N0YXRlLlN0YXRlIjoKBVN0YXRlEhEKDVNUQVRF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 96) = "X1VOS05PV04QABIJCgVTVEFSVBABEggKBFNUT1AQAhIJCgVSRVNFVBADIhgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 97) = "Fkxvd2VyUmlnaHRUaW1lcnNDcmVhdGUiGAoWTG93ZXJSaWdodFRpbWVyc0Rl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 98) = "bGV0ZSIUChJMb3dlclJpZ2h0TWVzc2FnZXMihwIKFkxvd2VyUmlnaHRNZXNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 99) = "YWdlc0VkaXQSPgoGYWN0aW9uGAEgASgOMi4ucnYuYW5hbHl0aWNzLnVpLkxv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 100) = "d2VyUmlnaHRNZXNzYWdlc0VkaXQuQWN0aW9uIqwBCgZBY3Rpb24SEgoOQUNU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 101) = "SU9OX1VOS05PV04QABISCg5BRERfVEVYVF9UT0tFThABEhMKD0FERF9USU1F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 102) = "Ul9UT0tFThACEhQKEEFERF9DVVNUT01fVE9LRU4QAxINCglTRVRfVEhFTUUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 103) = "BBIMCghTRVRfVEVYVBAFEhgKFFNFVF9XRUJfTk9USUZJQ0FUSU9OEAYSGAoU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 104) = "U0VUX0RJU01JU1NfQkVIQVZJT1IQByKJAQoXTG93ZXJSaWdodE1lc3NhZ2Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 105) = "U3RhdGUSPQoFc3RhdGUYASABKA4yLi5ydi5hbmFseXRpY3MudWkuTG93ZXJS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 106) = "aWdodE1lc3NhZ2VzU3RhdGUuU3RhdGUiLwoFU3RhdGUSEQoNU1RBVEVfVU5L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 107) = "Tk9XThAAEggKBFNIT1cQARIJCgVDTEVBUhACIhoKGExvd2VyUmlnaHRNZXNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 108) = "YWdlc0NyZWF0ZSIaChhMb3dlclJpZ2h0TWVzc2FnZXNEZWxldGUiEQoPTG93";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 109) = "ZXJSaWdodFByb3BzIhsKGUxvd2VyUmlnaHRQcm9wc1RyYW5zaXRpb24iFwoV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 110) = "TG93ZXJSaWdodFByb3BzQ3JlYXRlIhcKFUxvd2VyUmlnaHRQcm9wc0RlbGV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 111) = "ZSKDAQoUTG93ZXJSaWdodFByb3BzU3RhdGUSOgoFc3RhdGUYASABKA4yKy5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 112) = "di5hbmFseXRpY3MudWkuTG93ZXJSaWdodFByb3BzU3RhdGUuU3RhdGUiLwoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 113) = "U3RhdGUSEQoNU1RBVEVfVU5LTk9XThAAEggKBFNIT1cQARIJCgVDTEVBUhAC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 114) = "IhEKD0xvd2VyUmlnaHRTdGFnZSIdChtMb3dlclJpZ2h0U3RhZ2VDaGFuZ2VM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 115) = "YXlvdXQiIQofTG93ZXJSaWdodFN0YWdlQ29uZmlndXJlU2NyZWVucyIcChpM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 116) = "b3dlclJpZ2h0U3RhZ2VFZGl0TGF5b3V0cyKRAQobTG93ZXJSaWdodFN0YWdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 117) = "TWVzc2FnZVN0YXRlEkEKBXN0YXRlGAEgASgOMjIucnYuYW5hbHl0aWNzLnVp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 118) = "Lkxvd2VyUmlnaHRTdGFnZU1lc3NhZ2VTdGF0ZS5TdGF0ZSIvCgVTdGF0ZRIR";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 119) = "Cg1TVEFURV9VTktOT1dOEAASCAoEU0hPVxABEgkKBUNMRUFSEAIiEgoQTG93";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 120) = "ZXJSaWdodE1hY3JvcyIZChdMb3dlclJpZ2h0TWFjcm9zVHJpZ2dlciIYChZM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 121) = "b3dlclJpZ2h0TWFjcm9zQ3JlYXRlIhgKFkxvd2VyUmlnaHRNYWNyb3NEZWxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 122) = "dGUiDwoNVGV4dEluc3BlY3RvciItChpUZXh0SW5zcGVjdG9yU2Nyb2xsaW5n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 123) = "VGV4dBIPCgdlbmFibGVkGAEgASgIItMBChdUZXh0SW5zcGVjdG9yRm9yZWdy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 124) = "b3VuZBJECglmaWxsX3R5cGUYASABKA4yMS5ydi5hbmFseXRpY3MudWkuVGV4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 125) = "dEluc3BlY3RvckZvcmVncm91bmQuRmlsbFR5cGUSNgoOc2VsZWN0aW9uX21v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 126) = "ZGUYAiABKA4yHi5ydi5hbmFseXRpY3MudWkuU2VsZWN0aW9uTW9kZSI6CghG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 127) = "aWxsVHlwZRIVChFGSUxMX1RZUEVfVU5LTk9XThAAEgkKBVNPTElEEAESDAoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 128) = "R1JBRElFTlQQAiJpChtUZXh0SW5zcGVjdG9yVW5kZXJsaW5lQ29sb3ISEgoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 129) = "aXNfZW5hYmxlZBgBIAEoCBI2Cg5zZWxlY3Rpb25fbW9kZRgCIAEoDjIeLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 130) = "LmFuYWx5dGljcy51aS5TZWxlY3Rpb25Nb2RlIt4BChxUZXh0SW5zcGVjdG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 131) = "QmFja2dyb3VuZENvbG9yEksKCmNvbG9yX3R5cGUYASABKA4yNy5ydi5hbmFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 132) = "eXRpY3MudWkuVGV4dEluc3BlY3RvckJhY2tncm91bmRDb2xvci5Db2xvclR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 133) = "cGUSNgoOc2VsZWN0aW9uX21vZGUYAiABKA4yHi5ydi5hbmFseXRpY3MudWku";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 134) = "U2VsZWN0aW9uTW9kZSI5CglDb2xvclR5cGUSFgoSQ09MT1JfVFlQRV9VTktO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 135) = "T1dOEAASCQoFQ0xFQVIQARIJCgVPVEhFUhACIo0CChpUZXh0SW5zcGVjdG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 136) = "TGluZVRyYW5zZm9ybRJRCg50cmFuc2Zvcm1fdHlwZRgBIAEoDjI5LnJ2LmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 137) = "YWx5dGljcy51aS5UZXh0SW5zcGVjdG9yTGluZVRyYW5zZm9ybS5UcmFuc2Zv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 138) = "cm1UeXBlIpsBCg1UcmFuc2Zvcm1UeXBlEhoKFlRSQU5TRk9STV9UWVBFX1VO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 139) = "S05PV04QABIICgROT05FEAESFwoTUkVNT1ZFX0xJTkVfUkVUVVJOUxACEhgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 140) = "FFJFUExBQ0VfTElORV9SRVRVUk5TEAMSFQoRT05FX1dPUkRfUEVSX0xJTkUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 141) = "BBIaChZPTkVfQ0hBUkFDVEVSX1BFUl9MSU5FEAUiEAoOU2hvd1NsaWRlTGFi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 142) = "ZWwiqwEKFFNob3dTbGlkZUxhYmVsQ2hhbmdlEhgKEG51bWJlcl9vZl9zbGlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 143) = "ZXMYASABKAUSPAoGc291cmNlGAIgASgOMiwucnYuYW5hbHl0aWNzLnVpLlNo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 144) = "b3dTbGlkZUxhYmVsQ2hhbmdlLlNvdXJjZSI7CgZTb3VyY2USEgoOU09VUkNF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 145) = "X1VOS05PV04QABIQCgxDT05URVhUX01FTlUQARILCgdQT1BPVkVSEAIiqwEK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 146) = "EkVkaXRvck92ZXJsYXlTaG93bhI6CgZzb3VyY2UYASABKA4yKi5ydi5hbmFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 147) = "eXRpY3MudWkuRWRpdG9yT3ZlcmxheVNob3duLlNvdXJjZSJZCgZTb3VyY2US";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 148) = "EgoOU09VUkNFX1VOS05PV04QABIQCgxET1VCTEVfQ0xJQ0sQARITCg9DT05U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 149) = "RVhUVUFMX01FTlUQAhIUChBQTFVTX0JVVFRPTl9NRU5VEAMiqQEKE0VkaXRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 150) = "ck92ZXJsYXlDbG9zZWQSOwoGc291cmNlGAEgASgOMisucnYuYW5hbHl0aWNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 151) = "LnVpLkVkaXRvck92ZXJsYXlDbG9zZWQuU291cmNlIlUKBlNvdXJjZRISCg5T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 152) = "T1VSQ0VfVU5LTk9XThAAEhUKEUNMSUNLX09GRl9FTEVNRU5UEAESDgoKRVND";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 153) = "QVBFX0tFWRACEhAKDENMT1NFX0JVVFRPThADIjQKDldoYXRzTmV3Vmlld2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 154) = "Eg8KB3ZlcnNpb24YASABKAkSEQoJdmlld190aW1lGAIgASgFIpkBCgtDbGVh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 155) = "ckdyb3VwcxIzCgZzb3VyY2UYASABKA4yIy5ydi5hbmFseXRpY3MudWkuQ2xl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 156) = "YXJHcm91cHMuU291cmNlIlUKBlNvdXJjZRISCg5TT1VSQ0VfVU5LTk9XThAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 157) = "EhQKEEFQUExJQ0FUSU9OX01FTlUQARIQCgxQUkVWSUVXX01FTlUQAhIPCgtB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 158) = "Q1RJT05fTUVOVRADIhMKEUNsZWFyR3JvdXBzQ3JlYXRlIhMKEUNsZWFyR3Jv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 159) = "dXBzRGVsZXRlIqcBChtDbGVhckdyb3Vwc0NoYW5nZVZpc2liaWxpdHkSSwoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 160) = "dmlzaWJpbGl0eRgBIAEoDjI3LnJ2LmFuYWx5dGljcy51aS5DbGVhckdyb3Vw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 161) = "c0NoYW5nZVZpc2liaWxpdHkuVmlzaWJpbGl0eSI7CgpWaXNpYmlsaXR5EhYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 162) = "ElZJU0lCSUxJVFlfVU5LTk9XThAAEgkKBVNIT1dOEAESCgoGSElEREVOEAIi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 163) = "qgEKFUNsZWFyR3JvdXBzQ2hhbmdlSWNvbhJCCglpY29uX3R5cGUYASABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 164) = "Ly5ydi5hbmFseXRpY3MudWkuQ2xlYXJHcm91cHNDaGFuZ2VJY29uLkljb25U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 165) = "eXBlEhEKCWlzX3RpbnRlZBgCIAEoCCI6CghJY29uVHlwZRIVChFJQ09OX1RZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 166) = "UEVfVU5LTk9XThAAEgsKB0RFRkFVTFQQARIKCgZDVVNUT00QAiIfCh1QcmV2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 167) = "aWV3QXJlYUNsZWFyR3JvdXBzVHJpZ2dlciIuCh1QcmV2aWV3QXJlYUNsZWFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 168) = "R3JvdXBzQ2hhbmdlZBINCgVjb3VudBgBIAEoBSLPAgoPUGxhY2Vob2xkZXJM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 169) = "aW5rEjgKCWxpbmtfdHlwZRgBIAEoDjIlLnJ2LmFuYWx5dGljcy51aS5QbGFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 170) = "ZWhvbGRlckxpbmsuVHlwZRI8CgtsaW5rX3NvdXJjZRgCIAEoDjInLnJ2LmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 171) = "YWx5dGljcy51aS5QbGFjZWhvbGRlckxpbmsuU291cmNlIlAKBFR5cGUSEAoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 172) = "VFlQRV9VTktOT1dOEAASEAoMUFJFU0VOVEFUSU9OEAESCQoFTUVESUEQAhIZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 173) = "ChVFWFRFUk5BTF9QUkVTRU5UQVRJT04QAyJyCgZTb3VyY2USEgoOU09VUkNF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 174) = "X1VOS05PV04QABIQCgxRVUlDS19TRUFSQ0gQARIRCg1JTVBPUlRfQlVUVE9O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 175) = "EAISEQoNQ1JFQVRFX0JVVFRPThADEg0KCURSQUdfRFJPUBAEEg0KCUFVVE9N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 176) = "QVRJQxAFIhMKEVBsYWNlaG9sZGVyVW5saW5rIpoBChJQbGFubmluZ0NlbnRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 177) = "ckxpdmUSQwoLd2luZG93X3R5cGUYASABKA4yLi5ydi5hbmFseXRpY3MudWku";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 178) = "UGxhbm5pbmdDZW50ZXJMaXZlLldpbmRvd1R5cGUiPwoKV2luZG93VHlwZRIX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 179) = "ChNXSU5ET1dfVFlQRV9VTktOT1dOEAASCgoGRE9DS0VEEAESDAoIRkxPQVRJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 180) = "TkcQAiIRCg9OZXR3b3JrR3JvdXBBZGQiFAoSTmV0d29ya0dyb3VwUmVtb3Zl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 181) = "IhMKEU5ldHdvcmtHcm91cExlYXZlIhEKD0NjbGlSZXBvcnRSZXNldCIRCg9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 182) = "Y2xpUmVwb3J0U2hvd24iyQEKB0NhcHR1cmUSLwoGc291cmNlGAEgASgOMh8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 183) = "cnYuYW5hbHl0aWNzLnVpLkNhcHR1cmUuU291cmNlIowBCgZTb3VyY2USEgoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 184) = "U09VUkNFX1VOS05PV04QABILCgdUT09MQkFSEAESEgoOQUNUSU9OX1BPUE9W";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 185) = "RVIQAhIaChZBQ1RJT05fQ09OVEVYVFVBTF9NRU5VEAMSDAoIQ0FMRU5EQVIQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 186) = "BBIUChBQUkVGRVJFTkNFU19SRVNJEAUSDQoJTUFJTl9NRU5VEAYibAoHV2Vs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 187) = "Y29tZRIvCgZzb3VyY2UYASABKA4yHy5ydi5hbmFseXRpY3MudWkuV2VsY29t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 188) = "ZS5Tb3VyY2UiMAoGU291cmNlEhAKDEZJUlNUX0xBVU5DSBAAEhQKEEFQUExJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 189) = "Q0FUSU9OX01FTlUQASIgCh5XZWxjb21lU2NyZWVuQ29uZmlndXJhdGlvbkhl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 190) = "bHAiHgocV2VsY29tZURvd25sb2FkU2FtcGxlQ29udGVudCISChBXZWxjb21l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 191) = "VXNlckdyb3VwIhIKEFdlbGNvbWVUdXRvcmlhbHMiFgoUV2VsY29tZUtub3ds";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 192) = "ZWRnZUJhc2UiDQoLV2VsY29tZUJsb2ciEgoQV2VsY29tZUluc3RhZ3JhbSIR";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 193) = "Cg9XZWxjb21lRmFjZWJvb2siEgoQV2VsY29tZU1pZ3JhdGlvbiJ+CgxUZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 194) = "UGF0dGVybnMSNAoGc291cmNlGAEgASgOMiQucnYuYW5hbHl0aWNzLnVpLlRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 195) = "c3RQYXR0ZXJucy5Tb3VyY2UiOAoGU291cmNlEhQKEEFQUExJQ0FUSU9OX01F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 196) = "TlUQABIYChRTQ1JFRU5fQ09ORklHVVJBVElPThABIiYKElNldHRpbmdzQ3Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 197) = "dG9tTG9nbxIQCghoYXNfbG9nbxgBIAEoCCKrAQoVV2luZG93ZWRPdXRwdXRD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 198) = "cmVhdGVkEkYKC3NjcmVlbl90eXBlGAEgASgOMjEucnYuYW5hbHl0aWNzLnVp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 199) = "LldpbmRvd2VkT3V0cHV0Q3JlYXRlZC5TY3JlZW5UeXBlEiMKG251bV9hY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 200) = "dmVfd2luZG93ZWRfb3V0cHV0cxgCIAEoBSIlCgpTY3JlZW5UeXBlEgwKCEFV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 201) = "RElFTkNFEAASCQoFU1RBR0UQASLHAQoUQWN0aXZhdGlvbkZsb3dPcGVuZWQS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 202) = "PAoGc291cmNlGAEgASgOMiwucnYuYW5hbHl0aWNzLnVpLkFjdGl2YXRpb25G";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 203) = "bG93T3BlbmVkLlNvdXJjZSJxCgZTb3VyY2USEgoOU09VUkNFX1VOS05PV04Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 204) = "ABIQCgxMQVVOQ0hfQUxFUlQQARIaChZTVEFUVVNfVE9PTEJBUl9QT1BPVkVS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 205) = "EAISDwoLUFJFRkVSRU5DRVMQAxIUChBDTE9VRF9PTkJPQVJESU5HEAQqRAoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 206) = "TG9jYXRpb24SFAoQTE9DQVRJT05fVU5LTk9XThAAEhAKDFBSRVNFTlRBVElP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 207) = "ThABEhAKDEJJQkxFX01PRFVMRRACKkIKDVNlbGVjdGlvbk1vZGUSGgoWU0VM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 208) = "RUNUSU9OX01PREVfVU5LTk9XThAAEgoKBk9CSkVDVBABEgkKBVJBTkdFEAJC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 209) = "R/gBAaoCMVByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray211<string>, string>(ref buffer, 210) = "bmFseXRpY3MuVUm6Ag1BbmFseXRpY3NfVUlfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray211<string>, string>(in buffer, 211))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[2]
		{
			typeof(Location),
			typeof(SelectionMode)
		}, null, new GeneratedClrTypeInfo[89]
		{
			new GeneratedClrTypeInfo(typeof(QuickSearchShown), QuickSearchShown.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(QuickSearchShown.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(QuickSearchSearch), QuickSearchSearch.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(QuickSearchSearch.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(QuickSearchOpenItems), QuickSearchOpenItems.Parser, new string[3] { "Source", "Style", "Count" }, null, new Type[2]
			{
				typeof(QuickSearchOpenItems.Types.Source),
				typeof(QuickSearchOpenItems.Types.Style)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(ToolbarThemeShown), ToolbarThemeShown.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ToolbarThemeApplication), ToolbarThemeApplication.Parser, new string[1] { "Target" }, null, new Type[1] { typeof(ToolbarThemeApplication.Types.Target) }, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewShow), MainViewShow.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewShow.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewPresentationEditor), MainViewPresentationEditor.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewPresentationEditor.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewReflowEditor), MainViewReflowEditor.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewReflowEditor.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewBible), MainViewBible.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewBible.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(BibleTrigger), BibleTrigger.Parser, new string[1] { "Location" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(BibleGenerateSlides), BibleGenerateSlides.Parser, new string[9] { "TranslationCount", "SlideCount", "VerseLocation", "ReferenceLocation", "ShowVerseNumbers", "BreakNewVerse", "DisplayTranslation", "PreserveFontColor", "ReferenceStyle" }, null, new Type[2]
			{
				typeof(BibleGenerateSlides.Types.TextBoxLocation),
				typeof(BibleGenerateSlides.Types.ReferenceType)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(BibleGenerateNext), BibleGenerateNext.Parser, new string[1] { "Location" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(BibleGeneratePrevious), BibleGeneratePrevious.Parser, new string[1] { "Location" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(BibleSaveSlides), BibleSaveSlides.Parser, new string[1] { "Destination" }, null, new Type[1] { typeof(BibleSaveSlides.Types.SlideDestination) }, null, null),
			new GeneratedClrTypeInfo(typeof(BibleLookup), BibleLookup.Parser, new string[1] { "Location" }, null, new Type[1] { typeof(BibleLookup.Types.Location) }, null, null),
			new GeneratedClrTypeInfo(typeof(BibleInstall), BibleInstall.Parser, new string[2] { "FreeInstalledCount", "PurchasedInstalledCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(BibleRemove), BibleRemove.Parser, new string[2] { "FreeInstalledCount", "PurchasedInstalledCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(BibleStartup), BibleStartup.Parser, new string[2] { "FreeInstalledCount", "PurchasedInstalledCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewMaskEditor), MainViewMaskEditor.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewMaskEditor.Types.MaskSource) }, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewStageEditor), MainViewStageEditor.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewStageEditor.Types.StageSource) }, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewThemeEditor), MainViewThemeEditor.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewThemeEditor.Types.ThemeSource) }, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewCopyrightEditor), MainViewCopyrightEditor.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewCopyrightEditor.Types.CopyrightSource) }, null, null),
			new GeneratedClrTypeInfo(typeof(MainViewPropsEditor), MainViewPropsEditor.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(MainViewPropsEditor.Types.PropsSource) }, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightTimers), LowerRightTimers.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightTimersCollapse), LowerRightTimersCollapse.Parser, new string[1] { "State" }, null, new Type[1] { typeof(LowerRightTimersCollapse.Types.State) }, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightTimersEdit), LowerRightTimersEdit.Parser, new string[1] { "Field" }, null, new Type[1] { typeof(LowerRightTimersEdit.Types.Field) }, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightTimersState), LowerRightTimersState.Parser, new string[1] { "State" }, null, new Type[1] { typeof(LowerRightTimersState.Types.State) }, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightTimersCreate), LowerRightTimersCreate.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightTimersDelete), LowerRightTimersDelete.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMessages), LowerRightMessages.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMessagesEdit), LowerRightMessagesEdit.Parser, new string[1] { "Action" }, null, new Type[1] { typeof(LowerRightMessagesEdit.Types.Action) }, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMessagesState), LowerRightMessagesState.Parser, new string[1] { "State" }, null, new Type[1] { typeof(LowerRightMessagesState.Types.State) }, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMessagesCreate), LowerRightMessagesCreate.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMessagesDelete), LowerRightMessagesDelete.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightProps), LowerRightProps.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightPropsTransition), LowerRightPropsTransition.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightPropsCreate), LowerRightPropsCreate.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightPropsDelete), LowerRightPropsDelete.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightPropsState), LowerRightPropsState.Parser, new string[1] { "State" }, null, new Type[1] { typeof(LowerRightPropsState.Types.State) }, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightStage), LowerRightStage.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightStageChangeLayout), LowerRightStageChangeLayout.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightStageConfigureScreens), LowerRightStageConfigureScreens.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightStageEditLayouts), LowerRightStageEditLayouts.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightStageMessageState), LowerRightStageMessageState.Parser, new string[1] { "State" }, null, new Type[1] { typeof(LowerRightStageMessageState.Types.State) }, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMacros), LowerRightMacros.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMacrosTrigger), LowerRightMacrosTrigger.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMacrosCreate), LowerRightMacrosCreate.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LowerRightMacrosDelete), LowerRightMacrosDelete.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TextInspector), TextInspector.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TextInspectorScrollingText), TextInspectorScrollingText.Parser, new string[1] { "Enabled" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TextInspectorForeground), TextInspectorForeground.Parser, new string[2] { "FillType", "SelectionMode" }, null, new Type[1] { typeof(TextInspectorForeground.Types.FillType) }, null, null),
			new GeneratedClrTypeInfo(typeof(TextInspectorUnderlineColor), TextInspectorUnderlineColor.Parser, new string[2] { "IsEnabled", "SelectionMode" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TextInspectorBackgroundColor), TextInspectorBackgroundColor.Parser, new string[2] { "ColorType", "SelectionMode" }, null, new Type[1] { typeof(TextInspectorBackgroundColor.Types.ColorType) }, null, null),
			new GeneratedClrTypeInfo(typeof(TextInspectorLineTransform), TextInspectorLineTransform.Parser, new string[1] { "TransformType" }, null, new Type[1] { typeof(TextInspectorLineTransform.Types.TransformType) }, null, null),
			new GeneratedClrTypeInfo(typeof(ShowSlideLabel), ShowSlideLabel.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ShowSlideLabelChange), ShowSlideLabelChange.Parser, new string[2] { "NumberOfSlides", "Source" }, null, new Type[1] { typeof(ShowSlideLabelChange.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(EditorOverlayShown), EditorOverlayShown.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(EditorOverlayShown.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(EditorOverlayClosed), EditorOverlayClosed.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(EditorOverlayClosed.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(WhatsNewViewed), WhatsNewViewed.Parser, new string[2] { "Version", "ViewTime" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ClearGroups), ClearGroups.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(ClearGroups.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(ClearGroupsCreate), ClearGroupsCreate.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ClearGroupsDelete), ClearGroupsDelete.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ClearGroupsChangeVisibility), ClearGroupsChangeVisibility.Parser, new string[1] { "Visibility" }, null, new Type[1] { typeof(ClearGroupsChangeVisibility.Types.Visibility) }, null, null),
			new GeneratedClrTypeInfo(typeof(ClearGroupsChangeIcon), ClearGroupsChangeIcon.Parser, new string[2] { "IconType", "IsTinted" }, null, new Type[1] { typeof(ClearGroupsChangeIcon.Types.IconType) }, null, null),
			new GeneratedClrTypeInfo(typeof(PreviewAreaClearGroupsTrigger), PreviewAreaClearGroupsTrigger.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PreviewAreaClearGroupsChanged), PreviewAreaClearGroupsChanged.Parser, new string[1] { "Count" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PlaceholderLink), PlaceholderLink.Parser, new string[2] { "LinkType", "LinkSource" }, null, new Type[2]
			{
				typeof(PlaceholderLink.Types.Type),
				typeof(PlaceholderLink.Types.Source)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(PlaceholderUnlink), PlaceholderUnlink.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PlanningCenterLive), PlanningCenterLive.Parser, new string[1] { "WindowType" }, null, new Type[1] { typeof(PlanningCenterLive.Types.WindowType) }, null, null),
			new GeneratedClrTypeInfo(typeof(NetworkGroupAdd), NetworkGroupAdd.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NetworkGroupRemove), NetworkGroupRemove.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NetworkGroupLeave), NetworkGroupLeave.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CcliReportReset), CcliReportReset.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CcliReportShown), CcliReportShown.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Capture), Capture.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(Capture.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(Welcome), Welcome.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(Welcome.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeScreenConfigurationHelp), WelcomeScreenConfigurationHelp.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeDownloadSampleContent), WelcomeDownloadSampleContent.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeUserGroup), WelcomeUserGroup.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeTutorials), WelcomeTutorials.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeKnowledgeBase), WelcomeKnowledgeBase.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeBlog), WelcomeBlog.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeInstagram), WelcomeInstagram.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeFacebook), WelcomeFacebook.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WelcomeMigration), WelcomeMigration.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TestPatterns), TestPatterns.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(TestPatterns.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(SettingsCustomLogo), SettingsCustomLogo.Parser, new string[1] { "HasLogo" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WindowedOutputCreated), WindowedOutputCreated.Parser, new string[2] { "ScreenType", "NumActiveWindowedOutputs" }, null, new Type[1] { typeof(WindowedOutputCreated.Types.ScreenType) }, null, null),
			new GeneratedClrTypeInfo(typeof(ActivationFlowOpened), ActivationFlowOpened.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(ActivationFlowOpened.Types.Source) }, null, null)
		}));
	}
}
