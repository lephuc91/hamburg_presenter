using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1MacroReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1MacroReflection()
	{
		_003C_003Ey__InlineArray78<string> buffer = default(_003C_003Ey__InlineArray78<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 0) = "ChNwcm9BcGlWMU1hY3JvLnByb3RvEgdydi5kYXRhGhNwcm9BcGlWMUNvbG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 1) = "LnByb3RvGhhwcm9BcGlWMUlkZW50aWZpZXIucHJvdG8ingEKDEFQSV92MV9N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 2) = "YWNybxImCgJpZBgBIAEoCzIaLnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZpZXIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 3) = "JAoFY29sb3IYAiABKAsyFS5ydi5kYXRhLkFQSV92MV9Db2xvchISCgppbWFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 4) = "ZV90eXBlGAMgASgJEiwKB2FjdGlvbnMYBCADKAsyGy5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 5) = "MV9NYWNyb0FjdGlvbiIiChJBUElfdjFfTWFjcm9BY3Rpb24SDAoEdHlwZRgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 6) = "IAEoCSJoChdBUElfdjFfTWFjcm9fQ29sbGVjdGlvbhImCgJpZBgBIAEoCzIa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 7) = "LnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZpZXISJQoGbWFjcm9zGAIgAygLMhUu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 8) = "cnYuZGF0YS5BUElfdjFfTWFjcm8ijQsKFEFQSV92MV9NYWNyb19SZXF1ZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 9) = "EjYKBm1hY3JvcxgBIAEoCzIkLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 10) = "c3QuTWFjcm9zSAASOwoJZ2V0X21hY3JvGAIgASgLMiYucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 11) = "djFfTWFjcm9fUmVxdWVzdC5HZXRNYWNyb0gAEjsKCXB1dF9tYWNybxgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 12) = "CzImLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1JlcXVlc3QuUHV0TWFjcm9IABJB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 13) = "CgxkZWxldGVfbWFjcm8YBCABKAsyKS5ydi5kYXRhLkFQSV92MV9NYWNyb19S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 14) = "ZXF1ZXN0LkRlbGV0ZU1hY3JvSAASQwoNdHJpZ2dlcl9tYWNybxgFIAEoCzIq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 15) = "LnJ2LmRhdGEuQVBJX3YxX01hY3JvX1JlcXVlc3QuVHJpZ2dlck1hY3JvSAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 16) = "SwoRbWFjcm9fY29sbGVjdGlvbnMYBiABKAsyLi5ydi5kYXRhLkFQSV92MV9N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 17) = "YWNyb19SZXF1ZXN0Lk1hY3JvQ29sbGVjdGlvbnNIABJQChRnZXRfbWFjcm9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 18) = "Y29sbGVjdGlvbhgHIAEoCzIwLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 19) = "c3QuR2V0TWFjcm9Db2xsZWN0aW9uSAASVAoWcG9zdF9tYWNyb19jb2xsZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 20) = "aW9ucxgIIAEoCzIyLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1JlcXVlc3QuUG9z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 21) = "dE1hY3JvQ29sbGVjdGlvbnNIABJQChRwdXRfbWFjcm9fY29sbGVjdGlvbhgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 22) = "IAEoCzIwLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1JlcXVlc3QuUHV0TWFjcm9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 23) = "b2xsZWN0aW9uSAASVgoXZGVsZXRlX21hY3JvX2NvbGxlY3Rpb24YCiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 24) = "My5ydi5kYXRhLkFQSV92MV9NYWNyb19SZXF1ZXN0LkRlbGV0ZU1hY3JvQ29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 25) = "bGVjdGlvbkgAEj0KCm1hY3JvX2ljb24YCyABKAsyJy5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 26) = "MV9NYWNyb19SZXF1ZXN0Lk1hY3JvSWNvbkgAEkQKDnB1dF9tYWNyb19pY29u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 27) = "GAwgASgLMioucnYuZGF0YS5BUElfdjFfTWFjcm9fUmVxdWVzdC5QdXRNYWNy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 28) = "b0ljb25IABoICgZNYWNyb3MaFgoIR2V0TWFjcm8SCgoCaWQYASABKAkacwoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 29) = "UHV0TWFjcm8SCgoCaWQYASABKAkSEwoLbmFtZV9jaGFuZ2UYAiABKAkSKwoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 30) = "Y29sb3JfY2hhbmdlGAMgASgLMhUucnYuZGF0YS5BUElfdjFfQ29sb3ISGQoR";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 31) = "aW1hZ2VfdHlwZV9jaGFuZ2UYBCABKAkaGQoLRGVsZXRlTWFjcm8SCgoCaWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 32) = "ASABKAkaGgoMVHJpZ2dlck1hY3JvEgoKAmlkGAEgASgJGhIKEE1hY3JvQ29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 33) = "bGVjdGlvbnMaIAoSR2V0TWFjcm9Db2xsZWN0aW9uEgoKAmlkGAEgASgJGiQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 34) = "FFBvc3RNYWNyb0NvbGxlY3Rpb25zEgwKBG5hbWUYASABKAkaUwoSUHV0TWFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 35) = "cm9Db2xsZWN0aW9uEgoKAmlkGAEgASgJEjEKB2NoYW5nZXMYAiABKAsyIC5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 36) = "di5kYXRhLkFQSV92MV9NYWNyb19Db2xsZWN0aW9uGiMKFURlbGV0ZU1hY3Jv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 37) = "Q29sbGVjdGlvbhIKCgJpZBgBIAEoCRooCglNYWNyb0ljb24SCgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 38) = "KAkSDwoHcXVhbGl0eRgCIAEoBRo+CgxQdXRNYWNyb0ljb24SCgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 39) = "KAkSFAoMY29udGVudF90eXBlGAIgASgJEgwKBGljb24YAyABKAxCCQoHUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 40) = "dWVzdCLGDAoVQVBJX3YxX01hY3JvX1Jlc3BvbnNlEjcKBm1hY3JvcxgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 41) = "CzIlLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1Jlc3BvbnNlLk1hY3Jvc0gAEjwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 42) = "CWdldF9tYWNybxgCIAEoCzInLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 43) = "bnNlLkdldE1hY3JvSAASPAoJcHV0X21hY3JvGAMgASgLMicucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 44) = "UElfdjFfTWFjcm9fUmVzcG9uc2UuUHV0TWFjcm9IABJCCgxkZWxldGVfbWFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 45) = "cm8YBCABKAsyKi5ydi5kYXRhLkFQSV92MV9NYWNyb19SZXNwb25zZS5EZWxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 46) = "dGVNYWNyb0gAEkQKDXRyaWdnZXJfbWFjcm8YBSABKAsyKy5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 47) = "SV92MV9NYWNyb19SZXNwb25zZS5UcmlnZ2VyTWFjcm9IABJMChFtYWNyb19j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 48) = "b2xsZWN0aW9ucxgGIAEoCzIvLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 49) = "bnNlLk1hY3JvQ29sbGVjdGlvbnNIABJRChRnZXRfbWFjcm9fY29sbGVjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 50) = "bhgHIAEoCzIxLnJ2LmRhdGEuQVBJX3YxX01hY3JvX1Jlc3BvbnNlLkdldE1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 51) = "Y3JvQ29sbGVjdGlvbkgAElUKFnBvc3RfbWFjcm9fY29sbGVjdGlvbnMYCCAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 52) = "KAsyMy5ydi5kYXRhLkFQSV92MV9NYWNyb19SZXNwb25zZS5Qb3N0TWFjcm9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 53) = "b2xsZWN0aW9uc0gAElEKFHB1dF9tYWNyb19jb2xsZWN0aW9uGAkgASgLMjEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 54) = "cnYuZGF0YS5BUElfdjFfTWFjcm9fUmVzcG9uc2UuUHV0TWFjcm9Db2xsZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 55) = "aW9uSAASVwoXZGVsZXRlX21hY3JvX2NvbGxlY3Rpb24YCiABKAsyNC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 56) = "YXRhLkFQSV92MV9NYWNyb19SZXNwb25zZS5EZWxldGVNYWNyb0NvbGxlY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 57) = "b25IABI+CgptYWNyb19pY29uGAsgASgLMigucnYuZGF0YS5BUElfdjFfTWFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 58) = "cm9fUmVzcG9uc2UuTWFjcm9JY29uSAASRQoOcHV0X21hY3JvX2ljb24YDCAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 59) = "KAsyKy5ydi5kYXRhLkFQSV92MV9NYWNyb19SZXNwb25zZS5QdXRNYWNyb0lj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 60) = "b25IABovCgZNYWNyb3MSJQoGbWFjcm9zGAEgAygLMhUucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 61) = "djFfTWFjcm8aMAoIR2V0TWFjcm8SJAoFbWFjcm8YASABKAsyFS5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 62) = "LkFQSV92MV9NYWNybxowCghQdXRNYWNybxIkCgVtYWNybxgBIAEoCzIVLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 63) = "LmRhdGEuQVBJX3YxX01hY3JvGg0KC0RlbGV0ZU1hY3JvGg4KDFRyaWdnZXJN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 64) = "YWNybxqwAQoQTWFjcm9Db2xsZWN0aW9ucxJWChFtYWNyb19jb2xsZWN0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 65) = "cxgBIAEoCzI7LnJ2LmRhdGEuQVBJX3YxX01hY3JvX1Jlc3BvbnNlLk1hY3Jv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 66) = "Q29sbGVjdGlvbnMuQ29sbGVjdGlvbnMaRAoLQ29sbGVjdGlvbnMSNQoLY29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 67) = "bGVjdGlvbnMYASADKAsyIC5ydi5kYXRhLkFQSV92MV9NYWNyb19Db2xsZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 68) = "aW9uGlAKEkdldE1hY3JvQ29sbGVjdGlvbhI6ChBtYWNyb19jb2xsZWN0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 69) = "GAEgASgLMiAucnYuZGF0YS5BUElfdjFfTWFjcm9fQ29sbGVjdGlvbhpSChRQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 70) = "b3N0TWFjcm9Db2xsZWN0aW9ucxI6ChBtYWNyb19jb2xsZWN0aW9uGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 71) = "MiAucnYuZGF0YS5BUElfdjFfTWFjcm9fQ29sbGVjdGlvbhpQChJQdXRNYWNy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 72) = "b0NvbGxlY3Rpb24SOgoQbWFjcm9fY29sbGVjdGlvbhgBIAEoCzIgLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 73) = "dGEuQVBJX3YxX01hY3JvX0NvbGxlY3Rpb24aFwoVRGVsZXRlTWFjcm9Db2xs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 74) = "ZWN0aW9uGi8KCU1hY3JvSWNvbhIUCgxjb250ZW50X3R5cGUYASABKAkSDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 75) = "aWNvbhgCIAEoDBoOCgxQdXRNYWNyb0ljb25CCgoIUmVzcG9uc2VCNPgBAaoC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 76) = "JFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray78<string>, string>(ref buffer, 77) = "YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray78<string>, string>(in buffer, 78))), new FileDescriptor[2]
		{
			ProApiV1ColorReflection.Descriptor,
			ProApiV1IdentifierReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Macro), API_v1_Macro.Parser, new string[4] { "Id", "Color", "ImageType", "Actions" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_MacroAction), API_v1_MacroAction.Parser, new string[1] { "Type" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Macro_Collection), API_v1_Macro_Collection.Parser, new string[2] { "Id", "Macros" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request), API_v1_Macro_Request.Parser, new string[12]
			{
				"Macros", "GetMacro", "PutMacro", "DeleteMacro", "TriggerMacro", "MacroCollections", "GetMacroCollection", "PostMacroCollections", "PutMacroCollection", "DeleteMacroCollection",
				"MacroIcon", "PutMacroIcon"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[12]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.Macros), API_v1_Macro_Request.Types.Macros.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.GetMacro), API_v1_Macro_Request.Types.GetMacro.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.PutMacro), API_v1_Macro_Request.Types.PutMacro.Parser, new string[4] { "Id", "NameChange", "ColorChange", "ImageTypeChange" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.DeleteMacro), API_v1_Macro_Request.Types.DeleteMacro.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.TriggerMacro), API_v1_Macro_Request.Types.TriggerMacro.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.MacroCollections), API_v1_Macro_Request.Types.MacroCollections.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.GetMacroCollection), API_v1_Macro_Request.Types.GetMacroCollection.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.PostMacroCollections), API_v1_Macro_Request.Types.PostMacroCollections.Parser, new string[1] { "Name" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.PutMacroCollection), API_v1_Macro_Request.Types.PutMacroCollection.Parser, new string[2] { "Id", "Changes" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.DeleteMacroCollection), API_v1_Macro_Request.Types.DeleteMacroCollection.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.MacroIcon), API_v1_Macro_Request.Types.MacroIcon.Parser, new string[2] { "Id", "Quality" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Request.Types.PutMacroIcon), API_v1_Macro_Request.Types.PutMacroIcon.Parser, new string[3] { "Id", "ContentType", "Icon" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response), API_v1_Macro_Response.Parser, new string[12]
			{
				"Macros", "GetMacro", "PutMacro", "DeleteMacro", "TriggerMacro", "MacroCollections", "GetMacroCollection", "PostMacroCollections", "PutMacroCollection", "DeleteMacroCollection",
				"MacroIcon", "PutMacroIcon"
			}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[12]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.Macros), API_v1_Macro_Response.Types.Macros.Parser, new string[1] { "Macros_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.GetMacro), API_v1_Macro_Response.Types.GetMacro.Parser, new string[1] { "Macro" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.PutMacro), API_v1_Macro_Response.Types.PutMacro.Parser, new string[1] { "Macro" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.DeleteMacro), API_v1_Macro_Response.Types.DeleteMacro.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.TriggerMacro), API_v1_Macro_Response.Types.TriggerMacro.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.MacroCollections), API_v1_Macro_Response.Types.MacroCollections.Parser, new string[1] { "MacroCollections_" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.MacroCollections.Types.Collections), API_v1_Macro_Response.Types.MacroCollections.Types.Collections.Parser, new string[1] { "Collections_" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.GetMacroCollection), API_v1_Macro_Response.Types.GetMacroCollection.Parser, new string[1] { "MacroCollection" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.PostMacroCollections), API_v1_Macro_Response.Types.PostMacroCollections.Parser, new string[1] { "MacroCollection" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.PutMacroCollection), API_v1_Macro_Response.Types.PutMacroCollection.Parser, new string[1] { "MacroCollection" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.DeleteMacroCollection), API_v1_Macro_Response.Types.DeleteMacroCollection.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.MacroIcon), API_v1_Macro_Response.Types.MacroIcon.Parser, new string[2] { "ContentType", "Icon" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Macro_Response.Types.PutMacroIcon), API_v1_Macro_Response.Types.PutMacroIcon.Parser, null, null, null, null, null)
			})
		}));
	}
}
