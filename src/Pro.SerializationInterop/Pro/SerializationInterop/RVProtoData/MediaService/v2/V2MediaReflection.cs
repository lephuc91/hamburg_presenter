using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Pro.SerializationInterop.RVProtoData.MediaService.v2;

public static class V2MediaReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static V2MediaReflection()
	{
		_003C_003Ey__InlineArray79<string> buffer = default(_003C_003Ey__InlineArray79<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 0) = "Cg52Mi1tZWRpYS5wcm90bxIIbWVkaWEudjIaFnYyLWhlbHBlci1jb21tb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 1) = "cHJvdG8iwAQKDE5vdGlmaWNhdGlvbhI7Cg9tZWRpYV9yZWZlcmVuY2UYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 2) = "KAsyIC5oZWxwZXIuY29tbW9uLnYyLk1lZGlhUmVmZXJlbmNlSAASSgoUdW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 3) = "dWJzY3JpYmVfY29tcGxldGUYAiABKAsyKi5tZWRpYS52Mi5Ob3RpZmljYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 4) = "b24uVW5zdWJzY3JpYmVDb21wbGV0ZUgAEjUKCWNvbm5lY3RlZBgDIAEoCzIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 5) = "Lm1lZGlhLnYyLk5vdGlmaWNhdGlvbi5Db25uZWN0ZWRIABI7CgxkaXNjb25u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 6) = "ZWN0ZWQYBCABKAsyIy5tZWRpYS52Mi5Ob3RpZmljYXRpb24uRGlzY29ubmVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 7) = "dGVkSAASOwoMdW5yZXNwb25zaXZlGAUgASgLMiMubWVkaWEudjIuTm90aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 8) = "Y2F0aW9uLlVucmVzcG9uc2l2ZUgAEjkKDmFzc2V0X2ltcG9ydGVkGAYgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 9) = "Mh8uaGVscGVyLmNvbW1vbi52Mi5Bc3NldEltcG9ydGVkSAAaFQoTVW5zdWJz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 10) = "Y3JpYmVDb21wbGV0ZRoOCgxEaXNjb25uZWN0ZWQaNwoJQ29ubmVjdGVkEioK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 11) = "B3ZlcnNpb24YASABKAsyGS5oZWxwZXIuY29tbW9uLnYyLlZlcnNpb24aSwoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 12) = "VW5yZXNwb25zaXZlEioKB3JlcXVlc3QYASABKAsyGS5tZWRpYS52Mi5SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 13) = "ZXN0RW52ZWxvcGUSDwoHc2Vjb25kcxgCIAEoDUIOCgxub3RpZmljYXRpb24i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 14) = "lgoKD1JlcXVlc3RFbnZlbG9wZRJGChVjaGFuZ2Vfc2hvd19kaXJlY3RvcnkY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 15) = "ASABKAsyJS5oZWxwZXIuY29tbW9uLnYyLkNoYW5nZVNob3dEaXJlY3RvcnlI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 16) = "ABJKChNnZXRfbWVkaWFfcmVmZXJlbmNlGAIgASgLMisubWVkaWEudjIuUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 17) = "dWVzdEVudmVsb3BlLkdldE1lZGlhUmVmZXJlbmNlSAASQgoTYWRkX21lZGlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 18) = "X3JlZmVyZW5jZRgDIAEoCzIjLmhlbHBlci5jb21tb24udjIuQWRkTWVkaWFS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 19) = "ZWZlcmVuY2VIABJOChlkdXBsaWNhdGVfbWVkaWFfcmVmZXJlbmNlGAQgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 20) = "MikuaGVscGVyLmNvbW1vbi52Mi5EdXBsaWNhdGVNZWRpYVJlZmVyZW5jZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 21) = "EkUKFGFwcGx5X3RyYW5zZm9ybWF0aW9uGAUgASgLMiUuaGVscGVyLmNvbW1v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 22) = "bi52Mi5BcHBseVRyYW5zZm9ybWF0aW9uSAASSQoWcmVtb3ZlX21lZGlhX3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 23) = "ZmVyZW5jZRgGIAEoCzInLmhlbHBlci5jb21tb24udjIuUmVtb3ZlTWVkaWFS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 24) = "ZWZlcmVuY2VzSAASSgoXdHJpZ2dlcl9tZWRpYV9yZWZlcmVuY2UYByABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 25) = "Jy5oZWxwZXIuY29tbW9uLnYyLlRyaWdnZXJNZWRpYVJlZmVyZW5jZUgAEiYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 26) = "BHBpbmcYCCABKAsyFi5oZWxwZXIuY29tbW9uLnYyLlBpbmdIABI/ChF1cGRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 27) = "dGVfd29ya3NwYWNlcxgJIAEoCzIiLmhlbHBlci5jb21tb24udjIuVXBkYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 28) = "V29ya3NwYWNlc0gAEjEKCnBhdXNlX3N5bmMYCiABKAsyGy5oZWxwZXIuY29t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 29) = "bW9uLnYyLlBhdXNlU3luY0gAEjMKC3Jlc3VtZV9zeW5jGAsgASgLMhwuaGVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 30) = "cGVyLmNvbW1vbi52Mi5SZXN1bWVTeW5jSAASNQoMdXBkYXRlX3ByZWZzGAwg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 31) = "ASgLMh0uaGVscGVyLmNvbW1vbi52Mi5VcGRhdGVQcmVmc0gAEkgKFnVwZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 32) = "ZV9zbWFydF9wbGF5bGlzdHMYDSABKAsyJi5oZWxwZXIuY29tbW9uLnYyLlVw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 33) = "ZGF0ZVNtYXJ0UGxheWxpc3RzSAASTQoZYWRkX3Byb19jb250ZW50X3JlZmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 34) = "ZW5jZRgOIAEoCzIoLmhlbHBlci5jb21tb24udjIuQWRkUHJvQ29udGVudFJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 35) = "ZmVyZW5jZUgAEj8KDW1hcmtfYXNfY2xvdWQYDyABKAsyJi5oZWxwZXIuY29t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 36) = "bW9uLnYyLk1hcmtXb3Jrc3BhY2VBc0Nsb3VkSAASPwoNbWFya19hc19sb2Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 37) = "bBgQIAEoCzImLmhlbHBlci5jb21tb24udjIuTWFya1dvcmtzcGFjZUFzTG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 38) = "YWxIABI9ChByZW1vdmVfY29udGFpbmVyGBEgASgLMiEuaGVscGVyLmNvbW1v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 39) = "bi52Mi5SZW1vdmVDb250YWluZXJIABJIChZpbXBvcnRfdW5tYW5hZ2VkX21l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 40) = "ZGlhGBIgASgLMiYuaGVscGVyLmNvbW1vbi52Mi5JbXBvcnRVbm1hbmFnZWRN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 41) = "ZWRpYUgAGkYKEUdldE1lZGlhUmVmZXJlbmNlEjEKAmlkGAEgASgLMiUuaGVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 42) = "cGVyLmNvbW1vbi52Mi5SZWZlcmVuY2VJZGVudGlmaWVyQgkKB3JlcXVlc3Qi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 43) = "0AsKEFJlc3BvbnNlRW52ZWxvcGUSMQoCb2sYASABKAsyIy5tZWRpYS52Mi5S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 44) = "ZXNwb25zZUVudmVsb3BlLlJlc3BvbnNlSAASLwoFZXJyb3IYAiABKAsyHi5o";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 45) = "ZWxwZXIuY29tbW9uLnYyLlJlcXVlc3RFcnJvckgAGh0KG0NoYW5nZVNob3dE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 46) = "aXJlY3RvcnlSZXNwb25zZRpMChlHZXRNZWRpYVJlZmVyZW5jZVJlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 47) = "Ei8KBXN0YXRlGAEgASgLMiAuaGVscGVyLmNvbW1vbi52Mi5NZWRpYVJlZmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 48) = "ZW5jZRrgCQoIUmVzcG9uc2USSAoGY2hhbmdlGAEgASgLMjYubWVkaWEudjIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 49) = "UmVzcG9uc2VFbnZlbG9wZS5DaGFuZ2VTaG93RGlyZWN0b3J5UmVzcG9uc2VI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 50) = "ABJDCgNnZXQYAiABKAsyNC5tZWRpYS52Mi5SZXNwb25zZUVudmVsb3BlLkdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 51) = "dE1lZGlhUmVmZXJlbmNlUmVzcG9uc2VIABI6CgNhZGQYAyABKAsyKy5oZWxw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 52) = "ZXIuY29tbW9uLnYyLkFkZE1lZGlhUmVmZXJlbmNlUmVzcG9uc2VIABJGCglk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 53) = "dXBsaWNhdGUYBCABKAsyMS5oZWxwZXIuY29tbW9uLnYyLkR1cGxpY2F0ZU1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 54) = "ZGlhUmVmZXJlbmNlUmVzcG9uc2VIABI+CgVhcHBseRgFIAEoCzItLmhlbHBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 55) = "ci5jb21tb24udjIuQXBwbHlUcmFuc2Zvcm1hdGlvblJlc3BvbnNlSAASQAoG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 56) = "cmVtb3ZlGAYgASgLMi4uaGVscGVyLmNvbW1vbi52Mi5SZW1vdmVNZWRpYVJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 57) = "ZmVyZW5jZVJlc3BvbnNlSAASQgoHdHJpZ2dlchgHIAEoCzIvLmhlbHBlci5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 58) = "b21tb24udjIuVHJpZ2dlck1lZGlhUmVmZXJlbmNlUmVzcG9uc2VIABImCgRw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 59) = "b25nGAggASgLMhYuaGVscGVyLmNvbW1vbi52Mi5Qb25nSAASPAoGdXBkYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 60) = "GAkgASgLMiouaGVscGVyLmNvbW1vbi52Mi5VcGRhdGVXb3Jrc3BhY2VzUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 61) = "cG9uc2VIABI5CgpwYXVzZV9zeW5jGAogASgLMiMuaGVscGVyLmNvbW1vbi52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 62) = "Mi5QYXVzZVN5bmNSZXNwb25zZUgAEjsKC3Jlc3VtZV9zeW5jGAsgASgLMiQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 63) = "aGVscGVyLmNvbW1vbi52Mi5SZXN1bWVTeW5jUmVzcG9uc2VIABI9Cgx1cGRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 64) = "dGVfcHJlZnMYDCABKAsyJS5oZWxwZXIuY29tbW9uLnYyLlVwZGF0ZVByZWZz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 65) = "UmVzcG9uc2VIABJQChZ1cGRhdGVfc21hcnRfcGxheWxpc3RzGA0gASgLMi4u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 66) = "aGVscGVyLmNvbW1vbi52Mi5VcGRhdGVTbWFydFBsYXlsaXN0c1Jlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 67) = "SAASVQoZYWRkX3Byb19jb250ZW50X3JlZmVyZW5jZRgOIAEoCzIwLmhlbHBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 68) = "ci5jb21tb24udjIuQWRkUHJvQ29udGVudFJlZmVyZW5jZVJlc3BvbnNlSAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 69) = "RwoNbWFya19hc19jbG91ZBgPIAEoCzIuLmhlbHBlci5jb21tb24udjIuTWFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 70) = "a1dvcmtzcGFjZUFzQ2xvdWRSZXNwb25zZUgAEkcKDW1hcmtfYXNfbG9jYWwY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 71) = "ECABKAsyLi5oZWxwZXIuY29tbW9uLnYyLk1hcmtXb3Jrc3BhY2VBc0xvY2Fs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 72) = "UmVzcG9uc2VIABJFChByZW1vdmVfY29udGFpbmVyGBEgASgLMikuaGVscGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 73) = "LmNvbW1vbi52Mi5SZW1vdmVDb250YWluZXJSZXNwb25zZUgAElAKFmltcG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 74) = "dF91bm1hbmFnZWRfbWVkaWEYEiABKAsyLi5oZWxwZXIuY29tbW9uLnYyLklt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 75) = "cG9ydFVubWFuYWdlZE1lZGlhUmVzcG9uc2VIAEIKCghyZXNwb25zZUIICgZy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 76) = "ZXN1bHRCUaoCNFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 77) = "YS5NZWRpYVNlcnZpY2UudjK6AhdSVkRhdGFfTWVkaWFTZXJ2aWNlX3YyX2IG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray79<string>, string>(ref buffer, 78) = "cHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray79<string>, string>(in buffer, 79))), new FileDescriptor[1] { V2HelperCommonReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[3]
		{
			new GeneratedClrTypeInfo(typeof(Notification), Notification.Parser, new string[6] { "MediaReference", "UnsubscribeComplete", "Connected", "Disconnected", "Unresponsive", "AssetImported" }, new string[1] { "Notification" }, null, null, new GeneratedClrTypeInfo[4]
			{
				new GeneratedClrTypeInfo(typeof(Notification.Types.UnsubscribeComplete), Notification.Types.UnsubscribeComplete.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Disconnected), Notification.Types.Disconnected.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Connected), Notification.Types.Connected.Parser, new string[1] { "Version" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Unresponsive), Notification.Types.Unresponsive.Parser, new string[2] { "Request", "Seconds" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(RequestEnvelope), RequestEnvelope.Parser, new string[18]
			{
				"ChangeShowDirectory", "GetMediaReference", "AddMediaReference", "DuplicateMediaReference", "ApplyTransformation", "RemoveMediaReference", "TriggerMediaReference", "Ping", "UpdateWorkspaces", "PauseSync",
				"ResumeSync", "UpdatePrefs", "UpdateSmartPlaylists", "AddProContentReference", "MarkAsCloud", "MarkAsLocal", "RemoveContainer", "ImportUnmanagedMedia"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(RequestEnvelope.Types.GetMediaReference), RequestEnvelope.Types.GetMediaReference.Parser, new string[1] { "Id" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(ResponseEnvelope), ResponseEnvelope.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.ChangeShowDirectoryResponse), ResponseEnvelope.Types.ChangeShowDirectoryResponse.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.GetMediaReferenceResponse), ResponseEnvelope.Types.GetMediaReferenceResponse.Parser, new string[1] { "State" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ResponseEnvelope.Types.Response), ResponseEnvelope.Types.Response.Parser, new string[18]
				{
					"Change", "Get", "Add", "Duplicate", "Apply", "Remove", "Trigger", "Pong", "Update", "PauseSync",
					"ResumeSync", "UpdatePrefs", "UpdateSmartPlaylists", "AddProContentReference", "MarkAsCloud", "MarkAsLocal", "RemoveContainer", "ImportUnmanagedMedia"
				}, new string[1] { "Response" }, null, null, null)
			})
		}));
	}
}
