using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

public static class AnalyticsTrackedEventsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsTrackedEventsReflection()
	{
		_003C_003Ey__InlineArray161<string> buffer = default(_003C_003Ey__InlineArray161<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 0) = "ChxhbmFseXRpY3NUcmFja2VkRXZlbnRzLnByb3RvEhpydi5hbmFseXRpY3Mu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 1) = "dHJhY2tlZGV2ZW50cyIOCgxHZW5lcmljRXZlbnQiqAQKEUFwcGxpY2F0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 2) = "TGF1bmNoEhMKC2hhcmR3YXJlX2lkGAEgASgJEkYKB2NoYW5uZWwYAiABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 3) = "NS5ydi5hbmFseXRpY3MudHJhY2tlZGV2ZW50cy5BcHBsaWNhdGlvbkxhdW5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 4) = "aC5DaGFubmVsEkgKCHBsYXRmb3JtGAMgASgOMjYucnYuYW5hbHl0aWNzLnRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 5) = "YWNrZWRldmVudHMuQXBwbGljYXRpb25MYXVuY2guUGxhdGZvcm0SEwoLYXBw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 6) = "X3ZlcnNpb24YBCABKAkSEgoKb3NfdmVyc2lvbhgFIAEoCRIUCgxidWlsZF9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 7) = "dW1iZXIYBiABKAkSEAoIbG9jYXRpb24YByABKAkSEAoIbGFuZ3VhZ2UYCCAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 8) = "KAkSFgoOaGFyZHdhcmVfbW9kZWwYCSABKAkSFwoPcGh5c2ljYWxfbWVtb3J5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 9) = "GAogASgEEhgKEHZpZGVvX2NvbnRyb2xsZXIYCyABKAkSHAoUdmlkZW9fY29u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 10) = "dHJvbGxlcl9yYW0YDCABKAQSIgoaYmxhY2ttYWdpY19kZXNrdG9wX3ZlcnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 11) = "b24YDSABKAkSHQoVZW5hYmxlZF9mZWF0dXJlX2ZsYWdzGA4gAygJEhcKD29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 12) = "Z2FuaXphdGlvbl9pZBgPIAEoCSIgCgdDaGFubmVsEggKBEJFVEEQABILCgdS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 13) = "RUxFQVNFEAEiIgoIUGxhdGZvcm0SCwoHV0lORE9XUxAAEgkKBU1BQ09TEAEi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 14) = "lgEKE1ZpZGVvSW5wdXRUcmlnZ2VyZWQSUQoMYXVkaW9fc291cmNlGAEgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 15) = "MjsucnYuYW5hbHl0aWNzLnRyYWNrZWRldmVudHMuVmlkZW9JbnB1dFRyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 16) = "ZXJlZC5BdWRpb1NvdXJjZSIsCgtBdWRpb1NvdXJjZRIICgROT05FEAASCAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 17) = "U0VMRhABEgkKBU9USEVSEAIiJAoTVmlkZW9JbnB1dEN1c3RvbU1hcBINCgV2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 18) = "YWx1ZRgBIAEoCCIoChFWaWRlb0lucHV0U3RhcnRVcBITCgtpbnB1dF9jb3Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 19) = "dBgBIAEoDSKbAQoZVmlkZW9JbnB1dFRodW1ibmFpbFVwZGF0ZRJOCgR0eXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 20) = "GAEgASgOMkAucnYuYW5hbHl0aWNzLnRyYWNrZWRldmVudHMuVmlkZW9JbnB1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 21) = "dFRodW1ibmFpbFVwZGF0ZS5VcGRhdGVUeXBlIi4KClVwZGF0ZVR5cGUSCwoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 22) = "Q0FQVFVSRRAAEggKBERJU0sQARIJCgVSRVNFVBACIi0KFkF1ZGlvSW5wdXRB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 23) = "dXRvT25DaGFuZ2USEwoLaW5wdXRfY291bnQYASABKA0iKgoZQXVkaW9TZXR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 24) = "aW5nc1NkaU5kaUFjdGl2ZRINCgV2YWx1ZRgBIAEoCCInChZBdWRpb1NldHRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 25) = "bmdzQ3VzdG9tTWFwEg0KBXZhbHVlGAEgASgIIqABChdBdWRpb0lucHV0TW9k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 26) = "ZVNlbGVjdGlvbhJPCgltb2RlX3R5cGUYASABKA4yPC5ydi5hbmFseXRpY3Mu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 27) = "dHJhY2tlZGV2ZW50cy5BdWRpb0lucHV0TW9kZVNlbGVjdGlvbi5Nb2RlVHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 28) = "ZSI0CghNb2RlVHlwZRIGCgJPThAAEgcKA09GRhABEgsKB0FVVE9PRkYQAhIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 29) = "CgZBVVRPT04QAyIuChdBdWRpb0lucHV0QXV0b09uU3RhcnR1cBITCgtpbnB1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 30) = "dF9jb3VudBgBIAEoDSItChhBdWRpb1NldHRpbmdzU2RpTmRpU3RhdGUSEQoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 31) = "YnVzX2NvdW50GAEgASgNIpoBChFBdWRpb0lucHV0U3RhcnRVcBIZChF0b3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 32) = "bF9pbnB1dF9jb3VudBgBIAEoDRIWCg5vbl9pbnB1dF9jb3VudBgCIAEoDRIX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 33) = "Cg9vZmZfaW5wdXRfY291bnQYAyABKA0SGwoTYXV0b19vbl9pbnB1dF9jb3Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 34) = "dBgEIAEoDRIcChRhdXRvX29mZl9pbnB1dF9jb3VudBgFIAEoDSIlCgxDdWVU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 35) = "cmlnZ2VyZWQSFQoNdHJpZ2dlcl9kZWxheRgBIAEoASKDAQoUSW5wdXRBdWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 36) = "b01vbml0b3JpbmcSSAoEdHlwZRgBIAEoDjI6LnJ2LmFuYWx5dGljcy50cmFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 37) = "a2VkZXZlbnRzLklucHV0QXVkaW9Nb25pdG9yaW5nLklucHV0VHlwZSIhCglJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 38) = "bnB1dFR5cGUSCQoFQVVESU8QABIJCgVWSURFTxABIg0KC1Jlc2lTdGFydFVw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 39) = "IoMBCg9SZXNpTG9naW5DaGFuZ2USRQoFc3RhdGUYASABKA4yNi5ydi5hbmFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 40) = "eXRpY3MudHJhY2tlZGV2ZW50cy5SZXNpTG9naW5DaGFuZ2UuTG9naW5TdGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 41) = "ZSIpCgpMb2dpblN0YXRlEgwKCExPR0dFRElOEAASDQoJTE9HR0VET1VUEAEi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 42) = "mAEKEVJlbW90ZVN0cmVhbVN0YXJ0EkkKBnJlc3VsdBgBIAEoDjI5LnJ2LmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 43) = "YWx5dGljcy50cmFja2VkZXZlbnRzLlJlbW90ZVN0cmVhbVN0YXJ0LlN0YXJ0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 44) = "UmVzdWx0IjgKC1N0YXJ0UmVzdWx0EgsKB1NVQ0NFU1MQABIKCgZGQUlMRUQQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 45) = "ARIQCgxVU0VSQ0FOQ0VMRUQQAiIjChBSZW1vdGVTdHJlYW1TdG9wEg8KB3N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 46) = "Y2Nlc3MYASABKAgi4wEKEFN0YXJ0Q2FwdHVyZURpc2sSMAoFY29kZWMYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 47) = "KA4yIS5ydi5hbmFseXRpY3MudHJhY2tlZGV2ZW50cy5Db2RlYxIYChByZXNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 48) = "bHV0aW9uX3dpZHRoGAIgASgNEhkKEXJlc29sdXRpb25faGVpZ2h0GAMgASgN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 49) = "EjkKCmZyYW1lX3JhdGUYBCABKA4yJS5ydi5hbmFseXRpY3MudHJhY2tlZGV2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 50) = "ZW50cy5GcmFtZVJhdGUSFgoOc3RyZWFtX3N0YXJ0ZWQYBSABKAgSFQoNdmlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 51) = "ZW9fYml0cmF0ZRgGIAEoDSLjAQoQU3RhcnRDYXB0dXJlUnRtcBIwCgVjb2Rl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 52) = "YxgBIAEoDjIhLnJ2LmFuYWx5dGljcy50cmFja2VkZXZlbnRzLkNvZGVjEhgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 53) = "EHJlc29sdXRpb25fd2lkdGgYAiABKA0SGQoRcmVzb2x1dGlvbl9oZWlnaHQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 54) = "AyABKA0SOQoKZnJhbWVfcmF0ZRgEIAEoDjIlLnJ2LmFuYWx5dGljcy50cmFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 55) = "a2VkZXZlbnRzLkZyYW1lUmF0ZRIWCg5zdHJlYW1fc3RhcnRlZBgFIAEoCBIV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 56) = "Cg12aWRlb19iaXRyYXRlGAYgASgNIuMBChBTdGFydENhcHR1cmVSZXNpEjAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 57) = "BWNvZGVjGAEgASgOMiEucnYuYW5hbHl0aWNzLnRyYWNrZWRldmVudHMuQ29k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 58) = "ZWMSGAoQcmVzb2x1dGlvbl93aWR0aBgCIAEoDRIZChFyZXNvbHV0aW9uX2hl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 59) = "aWdodBgDIAEoDRI5CgpmcmFtZV9yYXRlGAQgASgOMiUucnYuYW5hbHl0aWNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 60) = "LnRyYWNrZWRldmVudHMuRnJhbWVSYXRlEhYKDnN0cmVhbV9zdGFydGVkGAUg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 61) = "ASgIEhUKDXZpZGVvX2JpdHJhdGUYBiABKA0iVwoLU3RvcENhcHR1cmUSEAoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 62) = "ZHVyYXRpb24YASABKAESFgoOZHJvcHBlZF9mcmFtZXMYAiABKAUSHgoWcGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 63) = "Y2VudF9kcm9wcGVkX2ZyYW1lcxgDIAEoASLrAgoFUHJpbnQSFgoOZG9jdW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 64) = "bnRfY291bnQYASABKA0SOQoEbW9kZRgCIAEoDjIrLnJ2LmFuYWx5dGljcy50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 65) = "cmFja2VkZXZlbnRzLlByaW50LlByaW50TW9kZRIYChBpbmNsdWRlX21ldGFk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 66) = "YXRhGAMgASgIEiIKGmluY2x1ZGVfcHJlc2VudGF0aW9uX25vdGVzGAQgASgI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 67) = "EhsKE2luY2x1ZGVfY3VycmVudERhdGUYBSABKAgSHAoUaW5jbHVkZV9zbGlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 68) = "ZV9sYWJlbHMYBiABKAgSGwoTaW5jbHVkZV9zbGlkZV9ub3RlcxgHIAEoCBIf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 69) = "ChdpbmNsdWRlX2Rpc2FibGVkX3NsaWRlcxgIIAEoCBIWCg5udW1iZXJfY29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 70) = "dW1ucxgJIAEoDRIXCg9wcmludF90b19kZXZpY2UYCiABKAkiJwoJUHJpbnRN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 71) = "b2RlEg0KCVRIVU1CTkFJTBAAEgsKB09VVExJTkUQASJICgZEZXZpY2USEAoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 72) = "cHJvdG9jb2wYASABKAkSEwoLZGV2aWNlX25hbWUYAiABKAkSFwoPZGV2aWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 73) = "X3Byb3RvY29sGAMgASgJIsoBCglEb3duZ3JhZGUSUAoRZnJvbV92ZXJzaW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 74) = "X3R5cGUYASABKA4yNS5ydi5hbmFseXRpY3MudHJhY2tlZGV2ZW50cy5Eb3du";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 75) = "Z3JhZGUuRnJvbVZlcnNpb25UeXBlImsKD0Zyb21WZXJzaW9uVHlwZRIdChlG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 76) = "Uk9NX1ZFUlNJT05fVFlQRV9VTktOT1dOEAASGgoWRlJPTV9WRVJTSU9OX1RZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 77) = "UEVfQkVUQRABEh0KGUZST01fVkVSU0lPTl9UWVBFX1JFTEVBU0UQAiKYAQoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 78) = "Q0NMSVJlcG9ydBI9CgZhY3Rpb24YASABKA4yLS5ydi5hbmFseXRpY3MudHJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 79) = "Y2tlZGV2ZW50cy5DQ0xJUmVwb3J0LkFjdGlvbiJLCgZBY3Rpb24SGAoUUkVQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 80) = "T1JUX1dJTkRPV19PUEVORUQQABISCg5SRVBPUlRfQ0xFQVJFRBABEhMKD1JF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 81) = "UE9SVF9FWFBPUlRFRBACIiwKEFRyYW5zaXRpb25XaW5kb3cSGAoQZHVyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 82) = "b25fc2Vjb25kcxgBIAEoDSKsBgoRRWRpdG9yT2JqZWN0QWRkZWQSYAoVZnJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 83) = "bV9pbnNlcnRpb25fc291cmNlGAEgASgOMkEucnYuYW5hbHl0aWNzLnRyYWNr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 84) = "ZWRldmVudHMuRWRpdG9yT2JqZWN0QWRkZWQuRnJvbUluc2VydGlvblNvdXJj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 85) = "ZRJRCg1pbnNlcnRlZF90eXBlGAIgASgOMjoucnYuYW5hbHl0aWNzLnRyYWNr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 86) = "ZWRldmVudHMuRWRpdG9yT2JqZWN0QWRkZWQuSW5zZXJ0ZWRUeXBlImkKE0Zy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 87) = "b21JbnNlcnRpb25Tb3VyY2USEgoORURJVE9SX1RPT0xCQVIQABIUChBFRElU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 88) = "T1JfTUFJTl9NRU5VEAESEQoNRURJVE9SX0hPVEtFWRACEhUKEUVESVRPUl9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 89) = "T1BZX1BBU1RFEAMi9gMKDEluc2VydGVkVHlwZRIPCgtFRElUT1JfVEVYVBAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 90) = "EhAKDEVESVRPUl9TSEFQRRABEhcKE0VESVRPUl9DVVNUT01fU0hBUEUQAhIQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 91) = "CgxFRElUT1JfTUVESUEQAxIWChJFRElUT1JfVklERU9fSU5QVVQQBBIOCgpF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 92) = "RElUT1JfV0VCEAUSGAoURURJVE9SX0NVUlJFTlRfU0xJREUQBhIVChFFRElU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 93) = "T1JfTkVYVF9TTElERRAHEhkKFUVESVRPUl9TQ1JFRU5fUFJFVklFVxAIEhAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 94) = "DEVESVRPUl9USU1FUhAJEhcKE0VESVRPUl9TWVNURU1fQ0xPQ0sQChIaChZF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 95) = "RElUT1JfVklERU9fQ09VTlRET1dOEAsSGgoWRURJVE9SX0FVRElPX0NPVU5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 96) = "RE9XThAMEhoKFkVESVRPUl9QTEFZQkFDS19NQVJLRVIQDRIWChJFRElUT1Jf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 97) = "Q0hPUkRfQ0hBUlQQDhIYChRFRElUT1JfU1RBR0VfTUVTU0FHRRAPEh8KG0VE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 98) = "SVRPUl9QTEFOTklOR19DRU5URVJfTElWRRAQEhMKD0VESVRPUl9USU1FQ09E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 99) = "RRAREhAKDEVESVRPUl9HUk9VUBASEhAKDEVESVRPUl9MQUJFTBATEhkKFUVE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 100) = "SVRPUl9DQVBUVVJFX1NUQVRVUxAUIq8BChBEYXRhSWREdXBsaWNhdGVkEkMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 101) = "BFR5cGUYASABKA4yNS5ydi5hbmFseXRpY3MudHJhY2tlZGV2ZW50cy5EYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 102) = "SWREdXBsaWNhdGVkLkRhdGFUeXBlEhkKEW51bWJlcl9kdXBsaWNhdGVzGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 103) = "ASgFIjsKCERhdGFUeXBlEhoKFkRBVEFfVFlQRV9QUkVTRU5UQVRJT04QABIT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 104) = "Cg9EQVRBX1RZUEVfTUVESUEQASKMAgoJRm9yY2VRdWl0EjwKBnJlYXNvbhgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 105) = "IAEoDjIsLnJ2LmFuYWx5dGljcy50cmFja2VkZXZlbnRzLkZvcmNlUXVpdC5S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 106) = "ZWFzb24iwAEKBlJlYXNvbhILCgdVTktOT1dOEAASDgoKSE9TVFNfRklMRRAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 107) = "EhQKEFNZU1RFTV9USU1FX1NLRVcQAhIVChFJTlZBTElEX1dBVEVSTUFSSxAD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 108) = "EhQKEFBJUkFURURfU09GVFdBUkUQBBIVChFNRVRBTF9VTkFWQUlMQUJMRRAF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 109) = "Eh0KGVVCSVFVSVRZX0RPV05MT0FEX0FCT1JURUQQBhIgChxDT1JFX1JVU1Rf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 110) = "Q09OVFJPTExFUl9GQUlMVVJFEAciOwoQTWVkaWFDbGVhbnVwU2l6ZRInCh9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 111) = "eXRlc19vZl9tZWRpYV9maWxlc19jbGVhbmVkX3VwGAEgASgEIpABCgpOZXR3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 112) = "b3JrQXBwEjwKBmFwcF9pZBgBIAEoDjIsLnJ2LmFuYWx5dGljcy50cmFja2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 113) = "ZXZlbnRzLk5ldHdvcmtBcHAuQXBwSUQSEQoJZGV2aWNlX2lkGAIgASgJIjEK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 114) = "BUFwcElEEgsKB1VOS05PV04QABINCglQUk9SRU1PVEUQARIMCghQUk9TVEFH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 115) = "RRACIlUKE0xvY2FsV29ya3NwYWNlU3RhdHMSGAoQdG90YWxfd29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 116) = "cxgBIAEoBRIkChxudW1iZXJfb2Zfd29ya3NwYWNlX3N3aXRjaGVzGAIgASgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 117) = "IqcBCg9Gb250UmVwbGFjZW1lbnQSQgoGc291cmNlGAEgASgOMjIucnYuYW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 118) = "bHl0aWNzLnRyYWNrZWRldmVudHMuRm9udFJlcGxhY2VtZW50LlNvdXJjZRIU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 119) = "CgxtaXNzaW5nX2ZvbnQYAiABKAkSGAoQcmVwbGFjZW1lbnRfZm9udBgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 120) = "CSIgCgZTb3VyY2USCgoGSU1QT1JUEAASCgoGQkFOTkVSEAEijgEKG1RyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 121) = "ZXJFeHRlcm5hbFByZXNlbnRhdGlvbhJKCgR0eXBlGAEgASgOMjwucnYuYW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 122) = "bHl0aWNzLnRyYWNrZWRldmVudHMuVHJpZ2dlckV4dGVybmFsUHJlc2VudGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 123) = "aW9uLlR5cGUiIwoEVHlwZRIOCgpQT1dFUlBPSU5UEAASCwoHS0VZTk9URRAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 124) = "IrYBChFXb3Jrc3BhY2VDcmVhdGlvbhJECgZzb3VyY2UYASABKA4yNC5ydi5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 125) = "bmFseXRpY3MudHJhY2tlZGV2ZW50cy5Xb3Jrc3BhY2VDcmVhdGlvbi5Tb3Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 126) = "Y2USGAoQZHVyYXRpb25fc2Vjb25kcxgCIAEoBCJBCgZTb3VyY2USFAoQQ0xP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 127) = "VURfT05CT0FSRElORxAAEhMKD1VTRVJfT05CT0FSRElORxABEgwKCFNFVFRJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 128) = "TkdTEAIi1QEKEkF2YWlsYWJsZVdvcmtzcGFjZRJKCgR0eXBlGAEgASgOMjwu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 129) = "cnYuYW5hbHl0aWNzLnRyYWNrZWRldmVudHMuQXZhaWxhYmxlV29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 130) = "LldvcmtzcGFjZVR5cGUSFQoNc2l6ZV9pbl9ieXRlcxgCIAEoBBISCgppc19j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 131) = "dXJyZW50GAMgASgIIkgKDVdvcmtzcGFjZVR5cGUSCQoFTE9DQUwQABIWChJD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 132) = "TE9VRF9VTkRPV05MT0FERUQQARIUChBDTE9VRF9ET1dOTE9BREVEEAIixQIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 133) = "FU9uYm9hcmRpbmdGbG93T3V0Y29tZRJZCg9vbmJvYXJkaW5nX3R5cGUYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 134) = "KA4yQC5ydi5hbmFseXRpY3MudHJhY2tlZGV2ZW50cy5PbmJvYXJkaW5nRmxv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 135) = "d091dGNvbWUuT25ib2FyZGluZ1R5cGUSSAoGcmVzdWx0GAIgASgOMjgucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 136) = "YW5hbHl0aWNzLnRyYWNrZWRldmVudHMuT25ib2FyZGluZ0Zsb3dPdXRjb21l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 137) = "LlJlc3VsdCIwCg5PbmJvYXJkaW5nVHlwZRIQCgxORVdfVE9fQ0xPVUQQABIM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 138) = "CghORVdfVVNFUhABIlUKBlJlc3VsdBIQCgxTS0lQX0ZPUl9OT1cQABIXChND";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 139) = "T05USU5VRV9XSVRIX0xPQ0FMEAESEAoMQ1JFQVRFX0NMT1VEEAISDgoKSk9J";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 140) = "Tl9DTE9VRBADIiMKD1N5bmNpbmdVbnBhdXNlZBIQCghkdXJhdGlvbhgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 141) = "BCKdAwodVXNlcldvcmtzcGFjZVRyZWVNb2RpZmljYXRpb24SUAoGYnVja2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 142) = "GAEgASgOMkAucnYuYW5hbHl0aWNzLnRyYWNrZWRldmVudHMuVXNlcldvcmtz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 143) = "cGFjZVRyZWVNb2RpZmljYXRpb24uQnVja2V0ElYKCW9wZXJhdGlvbhgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 144) = "DjJDLnJ2LmFuYWx5dGljcy50cmFja2VkZXZlbnRzLlVzZXJXb3Jrc3BhY2VU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 145) = "cmVlTW9kaWZpY2F0aW9uLk9wZXJhdGlvbiKPAQoGQnVja2V0EgkKBU9USEVS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 146) = "EAASDQoJTElCUkFSSUVTEAESCgoGVEhFTUVTEAISDQoJUExBWUxJU1RTEAMS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 147) = "FgoSUExBWUxJU1RfVEVNUExBVEVTEAQSEQoNQ09ORklHVVJBVElPThAFEgkK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 148) = "BU1FRElBEAYSCwoHUFJFU0VUUxAHEg0KCURPV05MT0FEUxAIIkAKCU9wZXJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 149) = "dGlvbhIMCghNT0RJRklFRBAAEgsKB0NSRUFURUQQARILCgdSRU5BTUVEEAIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 150) = "CwoHUkVNT1ZFRBADKvABCgVDb2RlYxIICgRIMjY0EAASEAoMSDI2NFNPRlRX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 151) = "QVJFEAESCAoESDI2NRACEhAKDEgyNjVTT0ZUV0FSRRADEhIKDlBST1JFUzQy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 152) = "MlBST1hZEAQSDwoLUFJPUkVTNDIyTFQQBRINCglQUk9SRVM0MjIQBhIPCgtQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 153) = "Uk9SRVM0MjJIURAHEg4KClBST1JFUzQ0NDQQCBIQCgxQUk9SRVM0NDQ0WFEQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 154) = "CRIHCgNIQVAQChIMCghIQVBBTFBIQRALEgkKBU5PVENIEAwSDQoJQVVUT01B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 155) = "VElDEA0SCAoESEFQURAOEg0KCUhBUFFBTFBIQRAPKnQKCUZyYW1lUmF0ZRIP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 156) = "CgtVTlNQRUNJRklFRBAAEgoKBl8yNEZQUxABEgoKBl8yNUZQUxACEgwKCF8y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 157) = "OTk3RlBTEAMSCgoGXzMwRlBTEAQSCgoGXzUwRlBTEAUSDAoIXzU5OTRGUFMQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 158) = "BhIKCgZfNjBGUFMQB0Jd+AEBqgI8UHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 159) = "LlJWUHJvdG9EYXRhLkFuYWx5dGljcy5UcmFja2VkRXZlbnRzugIYQW5hbHl0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray161<string>, string>(ref buffer, 160) = "aWNzX1RyYWNrZWRFdmVudHNfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray161<string>, string>(in buffer, 161))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[2]
		{
			typeof(Codec),
			typeof(FrameRate)
		}, null, new GeneratedClrTypeInfo[41]
		{
			new GeneratedClrTypeInfo(typeof(GenericEvent), GenericEvent.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ApplicationLaunch), ApplicationLaunch.Parser, new string[15]
			{
				"HardwareId", "Channel", "Platform", "AppVersion", "OsVersion", "BuildNumber", "Location", "Language", "HardwareModel", "PhysicalMemory",
				"VideoController", "VideoControllerRam", "BlackmagicDesktopVersion", "EnabledFeatureFlags", "OrganizationId"
			}, null, new Type[2]
			{
				typeof(ApplicationLaunch.Types.Channel),
				typeof(ApplicationLaunch.Types.Platform)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(VideoInputTriggered), VideoInputTriggered.Parser, new string[1] { "AudioSource" }, null, new Type[1] { typeof(VideoInputTriggered.Types.AudioSource) }, null, null),
			new GeneratedClrTypeInfo(typeof(VideoInputCustomMap), VideoInputCustomMap.Parser, new string[1] { "Value" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(VideoInputStartUp), VideoInputStartUp.Parser, new string[1] { "InputCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(VideoInputThumbnailUpdate), VideoInputThumbnailUpdate.Parser, new string[1] { "Type" }, null, new Type[1] { typeof(VideoInputThumbnailUpdate.Types.UpdateType) }, null, null),
			new GeneratedClrTypeInfo(typeof(AudioInputAutoOnChange), AudioInputAutoOnChange.Parser, new string[1] { "InputCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AudioSettingsSdiNdiActive), AudioSettingsSdiNdiActive.Parser, new string[1] { "Value" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AudioSettingsCustomMap), AudioSettingsCustomMap.Parser, new string[1] { "Value" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AudioInputModeSelection), AudioInputModeSelection.Parser, new string[1] { "ModeType" }, null, new Type[1] { typeof(AudioInputModeSelection.Types.ModeType) }, null, null),
			new GeneratedClrTypeInfo(typeof(AudioInputAutoOnStartup), AudioInputAutoOnStartup.Parser, new string[1] { "InputCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AudioSettingsSdiNdiState), AudioSettingsSdiNdiState.Parser, new string[1] { "BusCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AudioInputStartUp), AudioInputStartUp.Parser, new string[5] { "TotalInputCount", "OnInputCount", "OffInputCount", "AutoOnInputCount", "AutoOffInputCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CueTriggered), CueTriggered.Parser, new string[1] { "TriggerDelay" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(InputAudioMonitoring), InputAudioMonitoring.Parser, new string[1] { "Type" }, null, new Type[1] { typeof(InputAudioMonitoring.Types.InputType) }, null, null),
			new GeneratedClrTypeInfo(typeof(ResiStartUp), ResiStartUp.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ResiLoginChange), ResiLoginChange.Parser, new string[1] { "State" }, null, new Type[1] { typeof(ResiLoginChange.Types.LoginState) }, null, null),
			new GeneratedClrTypeInfo(typeof(RemoteStreamStart), RemoteStreamStart.Parser, new string[1] { "Result" }, null, new Type[1] { typeof(RemoteStreamStart.Types.StartResult) }, null, null),
			new GeneratedClrTypeInfo(typeof(RemoteStreamStop), RemoteStreamStop.Parser, new string[1] { "Success" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(StartCaptureDisk), StartCaptureDisk.Parser, new string[6] { "Codec", "ResolutionWidth", "ResolutionHeight", "FrameRate", "StreamStarted", "VideoBitrate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(StartCaptureRtmp), StartCaptureRtmp.Parser, new string[6] { "Codec", "ResolutionWidth", "ResolutionHeight", "FrameRate", "StreamStarted", "VideoBitrate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(StartCaptureResi), StartCaptureResi.Parser, new string[6] { "Codec", "ResolutionWidth", "ResolutionHeight", "FrameRate", "StreamStarted", "VideoBitrate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(StopCapture), StopCapture.Parser, new string[3] { "Duration", "DroppedFrames", "PercentDroppedFrames" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Print), Print.Parser, new string[10] { "DocumentCount", "Mode", "IncludeMetadata", "IncludePresentationNotes", "IncludeCurrentDate", "IncludeSlideLabels", "IncludeSlideNotes", "IncludeDisabledSlides", "NumberColumns", "PrintToDevice" }, null, new Type[1] { typeof(Print.Types.PrintMode) }, null, null),
			new GeneratedClrTypeInfo(typeof(Device), Device.Parser, new string[3] { "Protocol", "DeviceName", "DeviceProtocol" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Downgrade), Downgrade.Parser, new string[1] { "FromVersionType" }, null, new Type[1] { typeof(Downgrade.Types.FromVersionType) }, null, null),
			new GeneratedClrTypeInfo(typeof(CCLIReport), CCLIReport.Parser, new string[1] { "Action" }, null, new Type[1] { typeof(CCLIReport.Types.Action) }, null, null),
			new GeneratedClrTypeInfo(typeof(TransitionWindow), TransitionWindow.Parser, new string[1] { "DurationSeconds" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(EditorObjectAdded), EditorObjectAdded.Parser, new string[2] { "FromInsertionSource", "InsertedType" }, null, new Type[2]
			{
				typeof(EditorObjectAdded.Types.FromInsertionSource),
				typeof(EditorObjectAdded.Types.InsertedType)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(DataIdDuplicated), DataIdDuplicated.Parser, new string[2] { "Type", "NumberDuplicates" }, null, new Type[1] { typeof(DataIdDuplicated.Types.DataType) }, null, null),
			new GeneratedClrTypeInfo(typeof(ForceQuit), ForceQuit.Parser, new string[1] { "Reason" }, null, new Type[1] { typeof(ForceQuit.Types.Reason) }, null, null),
			new GeneratedClrTypeInfo(typeof(MediaCleanupSize), MediaCleanupSize.Parser, new string[1] { "BytesOfMediaFilesCleanedUp" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NetworkApp), NetworkApp.Parser, new string[2] { "AppId", "DeviceId" }, null, new Type[1] { typeof(NetworkApp.Types.AppID) }, null, null),
			new GeneratedClrTypeInfo(typeof(LocalWorkspaceStats), LocalWorkspaceStats.Parser, new string[2] { "TotalWorkspaces", "NumberOfWorkspaceSwitches" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(FontReplacement), FontReplacement.Parser, new string[3] { "Source", "MissingFont", "ReplacementFont" }, null, new Type[1] { typeof(FontReplacement.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(TriggerExternalPresentation), TriggerExternalPresentation.Parser, new string[1] { "Type" }, null, new Type[1] { typeof(TriggerExternalPresentation.Types.Type) }, null, null),
			new GeneratedClrTypeInfo(typeof(WorkspaceCreation), WorkspaceCreation.Parser, new string[2] { "Source", "DurationSeconds" }, null, new Type[1] { typeof(WorkspaceCreation.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(AvailableWorkspace), AvailableWorkspace.Parser, new string[3] { "Type", "SizeInBytes", "IsCurrent" }, null, new Type[1] { typeof(AvailableWorkspace.Types.WorkspaceType) }, null, null),
			new GeneratedClrTypeInfo(typeof(OnboardingFlowOutcome), OnboardingFlowOutcome.Parser, new string[2] { "OnboardingType", "Result" }, null, new Type[2]
			{
				typeof(OnboardingFlowOutcome.Types.OnboardingType),
				typeof(OnboardingFlowOutcome.Types.Result)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(SyncingUnpaused), SyncingUnpaused.Parser, new string[1] { "Duration" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UserWorkspaceTreeModification), UserWorkspaceTreeModification.Parser, new string[2] { "Bucket", "Operation" }, null, new Type[2]
			{
				typeof(UserWorkspaceTreeModification.Types.Bucket),
				typeof(UserWorkspaceTreeModification.Types.Operation)
			}, null, null)
		}));
	}
}
