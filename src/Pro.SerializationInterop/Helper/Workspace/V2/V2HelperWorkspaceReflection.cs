using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Helper.Workspace.V2;

public static class V2HelperWorkspaceReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static V2HelperWorkspaceReflection()
	{
		_003C_003Ey__InlineArray100<string> buffer = default(_003C_003Ey__InlineArray100<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 0) = "Chl2Mi1oZWxwZXItd29ya3NwYWNlLnByb3RvEhNoZWxwZXIud29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 1) = "LnYyGhZ2Mi1oZWxwZXItY29tbW9uLnByb3RvIocBCgpTeW5jU3RhdHVzEjgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 2) = "BnBhdXNlZBgBIAEoCzImLmhlbHBlci53b3Jrc3BhY2UudjIuU3luY1N0YXR1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 3) = "cy5QYXVzZWRIABo1CgZQYXVzZWQSFgoOdW50aWxfdGltZV91dGMYASABKAQS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 4) = "EwoLYXRfdGltZV91dGMYAiABKARCCAoGc3RhdHVzIs4BCgxOb3RpZmljYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 5) = "b24SOwoPbWVkaWFfcmVmZXJlbmNlGAEgASgLMiAuaGVscGVyLmNvbW1vbi52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 6) = "Mi5NZWRpYVJlZmVyZW5jZUgAEjkKDmFzc2V0X2ltcG9ydGVkGAIgASgLMh8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 7) = "aGVscGVyLmNvbW1vbi52Mi5Bc3NldEltcG9ydGVkSAASNgoLc3luY19zdGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 8) = "dXMYAyABKAsyHy5oZWxwZXIud29ya3NwYWNlLnYyLlN5bmNTdGF0dXNIAEIO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 9) = "Cgxub3RpZmljYXRpb24i2w8KD1JlcXVlc3RFbnZlbG9wZRI7CgZoZWFkZXIY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 10) = "ASABKAsyKy5oZWxwZXIud29ya3NwYWNlLnYyLlJlcXVlc3RFbnZlbG9wZS5I";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 11) = "ZWFkZXISOwoFc3RhcnQYAiABKAsyKi5oZWxwZXIud29ya3NwYWNlLnYyLlJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 12) = "cXVlc3RFbnZlbG9wZS5TdGFydEgAEkYKFWNoYW5nZV9zaG93X2RpcmVjdG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 13) = "eRgDIAEoCzIlLmhlbHBlci5jb21tb24udjIuQ2hhbmdlU2hvd0RpcmVjdG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 14) = "eUgAEjIKA2FkZBgEIAEoCzIjLmhlbHBlci5jb21tb24udjIuQWRkTWVkaWFS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 15) = "ZWZlcmVuY2VIABI+CglkdXBsaWNhdGUYBSABKAsyKS5oZWxwZXIuY29tbW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 16) = "LnYyLkR1cGxpY2F0ZU1lZGlhUmVmZXJlbmNlSAASNgoFYXBwbHkYBiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 17) = "JS5oZWxwZXIuY29tbW9uLnYyLkFwcGx5VHJhbnNmb3JtYXRpb25IABI5CgZy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 18) = "ZW1vdmUYByABKAsyJy5oZWxwZXIuY29tbW9uLnYyLlJlbW92ZU1lZGlhUmVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 19) = "ZXJlbmNlc0gAEjoKB3RyaWdnZXIYCCABKAsyJy5oZWxwZXIuY29tbW9uLnYy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 20) = "LlRyaWdnZXJNZWRpYVJlZmVyZW5jZUgAEiYKBHBpbmcYCSABKAsyFi5oZWxw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 21) = "ZXIuY29tbW9uLnYyLlBpbmdIABI/ChF1cGRhdGVfd29ya3NwYWNlcxgKIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 22) = "CzIiLmhlbHBlci5jb21tb24udjIuVXBkYXRlV29ya3NwYWNlc0gAEjEKCnBh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 23) = "dXNlX3N5bmMYDCABKAsyGy5oZWxwZXIuY29tbW9uLnYyLlBhdXNlU3luY0gA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 24) = "EjMKC3Jlc3VtZV9zeW5jGA0gASgLMhwuaGVscGVyLmNvbW1vbi52Mi5SZXN1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 25) = "bWVTeW5jSAASNQoMdXBkYXRlX3ByZWZzGA4gASgLMh0uaGVscGVyLmNvbW1v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 26) = "bi52Mi5VcGRhdGVQcmVmc0gAEkgKFnVwZGF0ZV9zbWFydF9wbGF5bGlzdHMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 27) = "DyABKAsyJi5oZWxwZXIuY29tbW9uLnYyLlVwZGF0ZVNtYXJ0UGxheWxpc3Rz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 28) = "SAASTQoZYWRkX3Byb19jb250ZW50X3JlZmVyZW5jZRgQIAEoCzIoLmhlbHBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 29) = "ci5jb21tb24udjIuQWRkUHJvQ29udGVudFJlZmVyZW5jZUgAEj8KDW1hcmtf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 30) = "YXNfY2xvdWQYESABKAsyJi5oZWxwZXIuY29tbW9uLnYyLk1hcmtXb3Jrc3Bh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 31) = "Y2VBc0Nsb3VkSAASPwoNbWFya19hc19sb2NhbBgSIAEoCzImLmhlbHBlci5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 32) = "b21tb24udjIuTWFya1dvcmtzcGFjZUFzTG9jYWxIABI9ChByZW1vdmVfY29u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 33) = "dGFpbmVyGBMgASgLMiEuaGVscGVyLmNvbW1vbi52Mi5SZW1vdmVDb250YWlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 34) = "ZXJIABJPChB1cGRhdGVfd2ViX3Rva2VuGBQgASgLMjMuaGVscGVyLndvcmtz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 35) = "cGFjZS52Mi5SZXF1ZXN0RW52ZWxvcGUuVXBkYXRlV2ViVG9rZW5IABJIChZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 36) = "bXBvcnRfdW5tYW5hZ2VkX21lZGlhGBUgASgLMiYuaGVscGVyLmNvbW1vbi52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 37) = "Mi5JbXBvcnRVbm1hbmFnZWRNZWRpYUgAGpQCCgVTdGFydBI6Cgxwcm9kdWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 38) = "X2luZm8YASABKAsyJC5oZWxwZXIuY29tbW9uLnYyLlByb2R1Y3RJbmZvcm1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 39) = "dGlvbhIWCg5zaG93X2RpcmVjdG9yeRgCIAEoCRIyCgtwcmVmZXJlbmNlcxgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 40) = "IAEoCzIdLmhlbHBlci5jb21tb24udjIuUHJlZmVyZW5jZXMSNQoNZmVhdHVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 41) = "ZV9mbGFncxgEIAEoCzIeLmhlbHBlci5jb21tb24udjIuRmVhdHVyZUZsYWdz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 42) = "EhkKDHdvcmtzcGFjZV9pZBgFIAEoCUgAiAEBEhQKB3BlZXJfaWQYBiABKARI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 43) = "AYgBAUIPCg1fd29ya3NwYWNlX2lkQgoKCF9wZWVyX2lkGhQKBkhlYWRlchIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 44) = "CgJpZBgBIAEoCRorCgdDaGFubmVsEgwKBG5hbWUYASABKAkSEgoKcGVybWlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 45) = "c2lvbhgCIAEoCRpTChFSZW1vdGVDaGFubmVsSW5mbxI+CghjaGFubmVscxgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 46) = "IAMoCzIsLmhlbHBlci53b3Jrc3BhY2UudjIuUmVxdWVzdEVudmVsb3BlLkNo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 47) = "YW5uZWwaMwoNVG9rZW5NZXRhZGF0YRIOCgZhY2Nlc3MYASABKAkSEgoKZXhw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 48) = "aXJlc19hdBgCIAEoBBr2AQoOVXBkYXRlV2ViVG9rZW4SRgoFdG9rZW4YASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 49) = "KAsyMi5oZWxwZXIud29ya3NwYWNlLnYyLlJlcXVlc3RFbnZlbG9wZS5Ub2tl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 50) = "bk1ldGFkYXRhSACIAQESFAoMcHVibnViX3Rva2VuGAIgASgJEhsKDmFjdGl2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 51) = "YXRpb25fa2V5GAMgASgJSAGIAQESTAoMY2hhbm5lbF9pbmZvGAQgASgLMjYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 52) = "aGVscGVyLndvcmtzcGFjZS52Mi5SZXF1ZXN0RW52ZWxvcGUuUmVtb3RlQ2hh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 53) = "bm5lbEluZm9CCAoGX3Rva2VuQhEKD19hY3RpdmF0aW9uX2tleUIJCgdyZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 54) = "ZXN0Ip8OChBSZXNwb25zZUVudmVsb3BlEjwKBmhlYWRlchgBIAEoCzIsLmhl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 55) = "bHBlci53b3Jrc3BhY2UudjIuUmVzcG9uc2VFbnZlbG9wZS5IZWFkZXISPAoC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 56) = "b2sYAiABKAsyLi5oZWxwZXIud29ya3NwYWNlLnYyLlJlc3BvbnNlRW52ZWxv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 57) = "cGUuUmVzcG9uc2VIABIvCgVlcnJvchgDIAEoCzIeLmhlbHBlci5jb21tb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 58) = "djIuUmVxdWVzdEVycm9ySAAaFAoGSGVhZGVyEgoKAmlkGAEgASgJGr0MCghS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 59) = "ZXNwb25zZRJNCgVzdGFydBgBIAEoCzI8LmhlbHBlci53b3Jrc3BhY2UudjIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 60) = "UmVzcG9uc2VFbnZlbG9wZS5SZXNwb25zZS5TdGFydFJlc3BvbnNlSAASawoV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 61) = "Y2hhbmdlX3Nob3dfZGlyZWN0b3J5GAIgASgLMkouaGVscGVyLndvcmtzcGFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 62) = "ZS52Mi5SZXNwb25zZUVudmVsb3BlLlJlc3BvbnNlLkNoYW5nZVNob3dEaXJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 63) = "Y3RvcnlSZXNwb25zZUgAEjoKA2FkZBgDIAEoCzIrLmhlbHBlci5jb21tb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 64) = "djIuQWRkTWVkaWFSZWZlcmVuY2VSZXNwb25zZUgAEkYKCWR1cGxpY2F0ZRgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 65) = "IAEoCzIxLmhlbHBlci5jb21tb24udjIuRHVwbGljYXRlTWVkaWFSZWZlcmVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 66) = "Y2VSZXNwb25zZUgAEj4KBWFwcGx5GAUgASgLMi0uaGVscGVyLmNvbW1vbi52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 67) = "Mi5BcHBseVRyYW5zZm9ybWF0aW9uUmVzcG9uc2VIABJACgZyZW1vdmUYBiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 68) = "KAsyLi5oZWxwZXIuY29tbW9uLnYyLlJlbW92ZU1lZGlhUmVmZXJlbmNlUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 69) = "cG9uc2VIABJCCgd0cmlnZ2VyGAcgASgLMi8uaGVscGVyLmNvbW1vbi52Mi5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 70) = "cmlnZ2VyTWVkaWFSZWZlcmVuY2VSZXNwb25zZUgAEiYKBHBvbmcYCCABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 71) = "Fi5oZWxwZXIuY29tbW9uLnYyLlBvbmdIABJHChF1cGRhdGVfd29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 72) = "cxgJIAEoCzIqLmhlbHBlci5jb21tb24udjIuVXBkYXRlV29ya3NwYWNlc1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 73) = "c3BvbnNlSAASOQoKcGF1c2Vfc3luYxgLIAEoCzIjLmhlbHBlci5jb21tb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 74) = "djIuUGF1c2VTeW5jUmVzcG9uc2VIABI7CgtyZXN1bWVfc3luYxgMIAEoCzIk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 75) = "LmhlbHBlci5jb21tb24udjIuUmVzdW1lU3luY1Jlc3BvbnNlSAASPQoMdXBk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 76) = "YXRlX3ByZWZzGA0gASgLMiUuaGVscGVyLmNvbW1vbi52Mi5VcGRhdGVQcmVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 77) = "c1Jlc3BvbnNlSAASUAoWdXBkYXRlX3NtYXJ0X3BsYXlsaXN0cxgOIAEoCzIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 78) = "LmhlbHBlci5jb21tb24udjIuVXBkYXRlU21hcnRQbGF5bGlzdHNSZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 79) = "ZUgAElUKGWFkZF9wcm9fY29udGVudF9yZWZlcmVuY2UYDyABKAsyMC5oZWxw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 80) = "ZXIuY29tbW9uLnYyLkFkZFByb0NvbnRlbnRSZWZlcmVuY2VSZXNwb25zZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 81) = "EkcKDW1hcmtfYXNfY2xvdWQYECABKAsyLi5oZWxwZXIuY29tbW9uLnYyLk1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 82) = "cmtXb3Jrc3BhY2VBc0Nsb3VkUmVzcG9uc2VIABJHCg1tYXJrX2FzX2xvY2Fs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 83) = "GBEgASgLMi4uaGVscGVyLmNvbW1vbi52Mi5NYXJrV29ya3NwYWNlQXNMb2Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 84) = "bFJlc3BvbnNlSAASRQoQcmVtb3ZlX2NvbnRhaW5lchgSIAEoCzIpLmhlbHBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 85) = "ci5jb21tb24udjIuUmVtb3ZlQ29udGFpbmVyUmVzcG9uc2VIABJhChB1cGRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 86) = "dGVfd2ViX3Rva2VuGBMgASgLMkUuaGVscGVyLndvcmtzcGFjZS52Mi5SZXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 87) = "b25zZUVudmVsb3BlLlJlc3BvbnNlLlVwZGF0ZVdlYlRva2VuUmVzcG9uc2VI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 88) = "ABJQChZpbXBvcnRfdW5tYW5hZ2VkX21lZGlhGBQgASgLMi4uaGVscGVyLmNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 89) = "bW1vbi52Mi5JbXBvcnRVbm1hbmFnZWRNZWRpYVJlc3BvbnNlSAAaSwoNU3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 90) = "cnRSZXNwb25zZRI6ChBtZWRpYV9yZWZlcmVuY2VzGAEgAygLMiAuaGVscGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 91) = "LmNvbW1vbi52Mi5NZWRpYVJlZmVyZW5jZRpZChtDaGFuZ2VTaG93RGlyZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 92) = "b3J5UmVzcG9uc2USOgoQbWVkaWFfcmVmZXJlbmNlcxgBIAMoCzIgLmhlbHBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 93) = "ci5jb21tb24udjIuTWVkaWFSZWZlcmVuY2UaGAoWVXBkYXRlV2ViVG9rZW5S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 94) = "ZXNwb25zZUIKCghyZXNwb25zZUIICgZyZXN1bHQiUwoNQ2xpZW50TWVzc2Fn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 95) = "ZRI3CgdyZXF1ZXN0GAEgASgLMiQuaGVscGVyLndvcmtzcGFjZS52Mi5SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 96) = "ZXN0RW52ZWxvcGVIAEIJCgdwYXlsb2FkIpABCg1TZXJ2ZXJNZXNzYWdlEjkK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 97) = "CHJlc3BvbnNlGAEgASgLMiUuaGVscGVyLndvcmtzcGFjZS52Mi5SZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 98) = "ZUVudmVsb3BlSAASOQoMbm90aWZpY2F0aW9uGAIgASgLMiEuaGVscGVyLndv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray100<string>, string>(ref buffer, 99) = "cmtzcGFjZS52Mi5Ob3RpZmljYXRpb25IAEIJCgdwYXlsb2FkYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray100<string>, string>(in buffer, 100))), new FileDescriptor[1] { V2HelperCommonReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[6]
		{
			new GeneratedClrTypeInfo(typeof(SyncStatus), SyncStatus.Parser, new string[1] { "Paused" }, new string[1] { "Status" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(SyncStatus.Types.Paused), SyncStatus.Types.Paused.Parser, new string[2] { "UntilTimeUtc", "AtTimeUtc" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(Notification), Notification.Parser, new string[3] { "MediaReference", "AssetImported", "SyncStatus" }, new string[1] { "Notification" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(RequestEnvelope), RequestEnvelope.Parser, new string[20]
			{
				"Header", "Start", "ChangeShowDirectory", "Add", "Duplicate", "Apply", "Remove", "Trigger", "Ping", "UpdateWorkspaces",
				"PauseSync", "ResumeSync", "UpdatePrefs", "UpdateSmartPlaylists", "AddProContentReference", "MarkAsCloud", "MarkAsLocal", "RemoveContainer", "UpdateWebToken", "ImportUnmanagedMedia"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[6]
			{
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.Start), RequestEnvelope.Types.Start.Parser, new string[6] { "ProductInfo", "ShowDirectory", "Preferences", "FeatureFlags", "WorkspaceId", "PeerId" }, new string[2] { "WorkspaceId", "PeerId" }, null, null, null),
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.Header), RequestEnvelope.Types.Header.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.Channel), RequestEnvelope.Types.Channel.Parser, new string[2] { "Name", "Permission" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.RemoteChannelInfo), RequestEnvelope.Types.RemoteChannelInfo.Parser, new string[1] { "Channels" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.TokenMetadata), RequestEnvelope.Types.TokenMetadata.Parser, new string[2] { "Access", "ExpiresAt" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.UpdateWebToken), RequestEnvelope.Types.UpdateWebToken.Parser, new string[4] { "Token", "PubnubToken", "ActivationKey", "ChannelInfo" }, new string[2] { "Token", "ActivationKey" }, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(ResponseEnvelope), ResponseEnvelope.Parser, new string[3] { "Header", "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Header), ResponseEnvelope.Types.Header.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response), ResponseEnvelope.Types.Response.Parser, new string[19]
				{
					"Start", "ChangeShowDirectory", "Add", "Duplicate", "Apply", "Remove", "Trigger", "Pong", "UpdateWorkspaces", "PauseSync",
					"ResumeSync", "UpdatePrefs", "UpdateSmartPlaylists", "AddProContentReference", "MarkAsCloud", "MarkAsLocal", "RemoveContainer", "UpdateWebToken", "ImportUnmanagedMedia"
				}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response.Types.StartResponse), ResponseEnvelope.Types.Response.Types.StartResponse.Parser, new string[1] { "MediaReferences" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response.Types.ChangeShowDirectoryResponse), ResponseEnvelope.Types.Response.Types.ChangeShowDirectoryResponse.Parser, new string[1] { "MediaReferences" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response.Types.UpdateWebTokenResponse), ResponseEnvelope.Types.Response.Types.UpdateWebTokenResponse.Parser, null, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(ClientMessage), ClientMessage.Parser, new string[1] { "Request" }, new string[1] { "Payload" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(ServerMessage), ServerMessage.Parser, new string[2] { "Response", "Notification" }, new string[1] { "Payload" }, null, null, null)
		}));
	}
}
