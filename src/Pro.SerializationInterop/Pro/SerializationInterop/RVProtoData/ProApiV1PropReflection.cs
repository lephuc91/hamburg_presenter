using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1PropReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1PropReflection()
	{
		_003C_003Ey__InlineArray85<string> buffer = default(_003C_003Ey__InlineArray85<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 0) = "ChJwcm9BcGlWMVByb3AucHJvdG8SB3J2LmRhdGEaGHByb0FwaVYxSWRlbnRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 1) = "Zmllci5wcm90byJBChFBUElfdjFfVHJhbnNpdGlvbhIMCgR1dWlkGAEgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 2) = "EgwKBG5hbWUYAiABKAkSEAoIZHVyYXRpb24YAyABKAEitQEKD0FQSV92MV9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 3) = "cm9wRGF0YRImCgJpZBgBIAEoCzIaLnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 4) = "ZXISEQoJaXNfYWN0aXZlGAIgASgIEhoKEmF1dG9fY2xlYXJfZW5hYmxlZBgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 5) = "IAEoCBIbChNhdXRvX2NsZWFyX2R1cmF0aW9uGAQgASgBEi4KCnRyYW5zaXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 6) = "b24YBSABKAsyGi5ydi5kYXRhLkFQSV92MV9UcmFuc2l0aW9uIoUBChVBUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 7) = "djFfUHJvcENvbGxlY3Rpb24SJgoCaWQYASABKAsyGi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 8) = "MV9JZGVudGlmaWVyEicKBXByb3BzGAIgAygLMhgucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 9) = "UHJvcERhdGESGwoTc2luZ2xlX3Byb3BfZW5hYmxlZBgDIAEoCCLMDAoTQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 10) = "X3YxX1Byb3BfUmVxdWVzdBIzCgVwcm9wcxgBIAEoCzIiLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 11) = "X3YxX1Byb3BfUmVxdWVzdC5Qcm9wc0gAEjgKCGdldF9wcm9wGAIgASgLMiQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 12) = "cnYuZGF0YS5BUElfdjFfUHJvcF9SZXF1ZXN0LkdldFByb3BIABI4CghwdXRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 13) = "cHJvcBgDIAEoCzIkLnJ2LmRhdGEuQVBJX3YxX1Byb3BfUmVxdWVzdC5QdXRQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 14) = "cm9wSAASPgoLZGVsZXRlX3Byb3AYBCABKAsyJy5ydi5kYXRhLkFQSV92MV9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 15) = "cm9wX1JlcXVlc3QuRGVsZXRlUHJvcEgAEkAKDHRyaWdnZXJfcHJvcBgFIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 16) = "CzIoLnJ2LmRhdGEuQVBJX3YxX1Byb3BfUmVxdWVzdC5UcmlnZ2VyUHJvcEgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 17) = "EjwKCmNsZWFyX3Byb3AYBiABKAsyJi5ydi5kYXRhLkFQSV92MV9Qcm9wX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 18) = "cXVlc3QuQ2xlYXJQcm9wSAASQgoNZ2V0X3RodW1ibmFpbBgHIAEoCzIpLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 19) = "LmRhdGEuQVBJX3YxX1Byb3BfUmVxdWVzdC5HZXRUaHVtYm5haWxIABJPChRn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 20) = "ZXRfcHJvcF9jb2xsZWN0aW9ucxgIIAEoCzIvLnJ2LmRhdGEuQVBJX3YxX1By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 21) = "b3BfUmVxdWVzdC5HZXRQcm9wQ29sbGVjdGlvbnNIABJNChNnZXRfcHJvcF9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 22) = "b2xsZWN0aW9uGAkgASgLMi4ucnYuZGF0YS5BUElfdjFfUHJvcF9SZXF1ZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 23) = "LkdldFByb3BDb2xsZWN0aW9uSAASUQoVcG9zdF9wcm9wX2NvbGxlY3Rpb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 24) = "GAogASgLMjAucnYuZGF0YS5BUElfdjFfUHJvcF9SZXF1ZXN0LlBvc3RQcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 25) = "Q29sbGVjdGlvbnNIABJNChNwdXRfcHJvcF9jb2xsZWN0aW9uGAsgASgLMi4u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 26) = "cnYuZGF0YS5BUElfdjFfUHJvcF9SZXF1ZXN0LlB1dFByb3BDb2xsZWN0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 27) = "SAASUwoWZGVsZXRlX3Byb3BfY29sbGVjdGlvbhgMIAEoCzIxLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 28) = "QVBJX3YxX1Byb3BfUmVxdWVzdC5EZWxldGVQcm9wQ29sbGVjdGlvbkgAEjwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 29) = "CnBhdXNlX3Byb3AYDSABKAsyJi5ydi5kYXRhLkFQSV92MV9Qcm9wX1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 30) = "c3QuUGF1c2VQcm9wSAASPgoLcmVzdW1lX3Byb3AYDiABKAsyJy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 31) = "LkFQSV92MV9Qcm9wX1JlcXVlc3QuUmVzdW1lUHJvcEgAGgcKBVByb3BzGhUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 32) = "B0dldFByb3ASCgoCaWQYASABKAkaxwEKB1B1dFByb3ASCgoCaWQYASABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 33) = "EwoLbmFtZV9jaGFuZ2UYAiABKAkSTwoRYXV0b19jbGVhcl9jaGFuZ2UYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 34) = "KAsyNC5ydi5kYXRhLkFQSV92MV9Qcm9wX1JlcXVlc3QuUHV0UHJvcC5BdXRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 35) = "Q2xlYXJDaGFuZ2UaSgoPQXV0b0NsZWFyQ2hhbmdlEhoKEmF1dG9fY2xlYXJf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 36) = "ZW5hYmxlZBgBIAEoCBIbChNhdXRvX2NsZWFyX2R1cmF0aW9uGAIgASgBGhgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 37) = "CkRlbGV0ZVByb3ASCgoCaWQYASABKAkaGQoLVHJpZ2dlclByb3ASCgoCaWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 38) = "ASABKAkaFwoJQ2xlYXJQcm9wEgoKAmlkGAEgASgJGhcKCVBhdXNlUHJvcBIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 39) = "CgJpZBgBIAEoCRoYCgpSZXN1bWVQcm9wEgoKAmlkGAEgASgJGisKDEdldFRo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 40) = "dW1ibmFpbBIKCgJpZBgBIAEoCRIPCgdxdWFsaXR5GAIgASgFGhQKEkdldFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 41) = "b3BDb2xsZWN0aW9ucxofChFHZXRQcm9wQ29sbGVjdGlvbhIKCgJpZBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 42) = "CRojChNQb3N0UHJvcENvbGxlY3Rpb25zEgwKBG5hbWUYASABKAkaUAoRUHV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 43) = "UHJvcENvbGxlY3Rpb24SCgoCaWQYASABKAkSLwoHY2hhbmdlcxgCIAEoCzIe";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 44) = "LnJ2LmRhdGEuQVBJX3YxX1Byb3BDb2xsZWN0aW9uGiIKFERlbGV0ZVByb3BD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 45) = "b2xsZWN0aW9uEgoKAmlkGAEgASgJQgkKB1JlcXVlc3QipA0KFEFQSV92MV9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 46) = "cm9wX1Jlc3BvbnNlEjQKBXByb3BzGAEgASgLMiMucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 47) = "UHJvcF9SZXNwb25zZS5Qcm9wc0gAEjkKCGdldF9wcm9wGAIgASgLMiUucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 48) = "ZGF0YS5BUElfdjFfUHJvcF9SZXNwb25zZS5HZXRQcm9wSAASOQoIcHV0X3By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 49) = "b3AYAyABKAsyJS5ydi5kYXRhLkFQSV92MV9Qcm9wX1Jlc3BvbnNlLlB1dFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 50) = "b3BIABI/CgtkZWxldGVfcHJvcBgEIAEoCzIoLnJ2LmRhdGEuQVBJX3YxX1By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 51) = "b3BfUmVzcG9uc2UuRGVsZXRlUHJvcEgAEkEKDHRyaWdnZXJfcHJvcBgFIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 52) = "CzIpLnJ2LmRhdGEuQVBJX3YxX1Byb3BfUmVzcG9uc2UuVHJpZ2dlclByb3BI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 53) = "ABI9CgpjbGVhcl9wcm9wGAYgASgLMicucnYuZGF0YS5BUElfdjFfUHJvcF9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 54) = "ZXNwb25zZS5DbGVhclByb3BIABJDCg1nZXRfdGh1bWJuYWlsGAcgASgLMiou";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 55) = "cnYuZGF0YS5BUElfdjFfUHJvcF9SZXNwb25zZS5HZXRUaHVtYm5haWxIABJQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 56) = "ChRnZXRfcHJvcF9jb2xsZWN0aW9ucxgIIAEoCzIwLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 57) = "X1Byb3BfUmVzcG9uc2UuR2V0UHJvcENvbGxlY3Rpb25zSAASTgoTZ2V0X3By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 58) = "b3BfY29sbGVjdGlvbhgJIAEoCzIvLnJ2LmRhdGEuQVBJX3YxX1Byb3BfUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 59) = "cG9uc2UuR2V0UHJvcENvbGxlY3Rpb25IABJSChVwb3N0X3Byb3BfY29sbGVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 60) = "dGlvbnMYCiABKAsyMS5ydi5kYXRhLkFQSV92MV9Qcm9wX1Jlc3BvbnNlLlBv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 61) = "c3RQcm9wQ29sbGVjdGlvbnNIABJOChNwdXRfcHJvcF9jb2xsZWN0aW9uGAsg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 62) = "ASgLMi8ucnYuZGF0YS5BUElfdjFfUHJvcF9SZXNwb25zZS5QdXRQcm9wQ29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 63) = "bGVjdGlvbkgAElQKFmRlbGV0ZV9wcm9wX2NvbGxlY3Rpb24YDCABKAsyMi5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 64) = "di5kYXRhLkFQSV92MV9Qcm9wX1Jlc3BvbnNlLkRlbGV0ZVByb3BDb2xsZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 65) = "aW9uSAASPQoKcGF1c2VfcHJvcBgNIAEoCzInLnJ2LmRhdGEuQVBJX3YxX1By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 66) = "b3BfUmVzcG9uc2UuUGF1c2VQcm9wSAASPwoLcmVzdW1lX3Byb3AYDiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 67) = "KC5ydi5kYXRhLkFQSV92MV9Qcm9wX1Jlc3BvbnNlLlJlc3VtZVByb3BIABow";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 68) = "CgVQcm9wcxInCgVwcm9wcxgBIAMoCzIYLnJ2LmRhdGEuQVBJX3YxX1Byb3BE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 69) = "YXRhGjEKB0dldFByb3ASJgoEcHJvcBgBIAEoCzIYLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 70) = "X1Byb3BEYXRhGjEKB1B1dFByb3ASJgoEcHJvcBgBIAEoCzIYLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 71) = "QVBJX3YxX1Byb3BEYXRhGgwKCkRlbGV0ZVByb3AaDQoLVHJpZ2dlclByb3Aa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 72) = "CwoJQ2xlYXJQcm9wGgsKCVBhdXNlUHJvcBoMCgpSZXN1bWVQcm9wGhwKDEdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 73) = "dFRodW1ibmFpbBIMCgRkYXRhGAEgASgMGrABChJHZXRQcm9wQ29sbGVjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 74) = "bnMSVgoQcHJvcF9jb2xsZWN0aW9ucxgBIAEoCzI8LnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 75) = "X1Byb3BfUmVzcG9uc2UuR2V0UHJvcENvbGxlY3Rpb25zLkNvbGxlY3Rpb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 76) = "GkIKC0NvbGxlY3Rpb25zEjMKC2NvbGxlY3Rpb25zGAEgAygLMh4ucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 77) = "YS5BUElfdjFfUHJvcENvbGxlY3Rpb24aTAoRR2V0UHJvcENvbGxlY3Rpb24S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 78) = "NwoPcHJvcF9jb2xsZWN0aW9uGAEgASgLMh4ucnYuZGF0YS5BUElfdjFfUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 79) = "cENvbGxlY3Rpb24aTgoTUG9zdFByb3BDb2xsZWN0aW9ucxI3Cg9wcm9wX2Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 80) = "bGxlY3Rpb24YASABKAsyHi5ydi5kYXRhLkFQSV92MV9Qcm9wQ29sbGVjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 81) = "bhpMChFQdXRQcm9wQ29sbGVjdGlvbhI3Cg9wcm9wX2NvbGxlY3Rpb24YASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 82) = "KAsyHi5ydi5kYXRhLkFQSV92MV9Qcm9wQ29sbGVjdGlvbhoWChREZWxldGVQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 83) = "cm9wQ29sbGVjdGlvbkIKCghSZXNwb25zZUI0+AEBqgIkUHJvLlNlcmlhbGl6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 84) = "YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray85<string>, string>(in buffer, 85))), new FileDescriptor[1] { ProApiV1IdentifierReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Transition), API_v1_Transition.Parser, new string[3] { "Uuid", "Name", "Duration" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_PropData), API_v1_PropData.Parser, new string[5] { "Id", "IsActive", "AutoClearEnabled", "AutoClearDuration", "Transition" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_PropCollection), API_v1_PropCollection.Parser, new string[3] { "Id", "Props", "SinglePropEnabled" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request), API_v1_Prop_Request.Parser, new string[14]
			{
				"Props", "GetProp", "PutProp", "DeleteProp", "TriggerProp", "ClearProp", "GetThumbnail", "GetPropCollections", "GetPropCollection", "PostPropCollections",
				"PutPropCollection", "DeletePropCollection", "PauseProp", "ResumeProp"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[14]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.Props), API_v1_Prop_Request.Types.Props.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.GetProp), API_v1_Prop_Request.Types.GetProp.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.PutProp), API_v1_Prop_Request.Types.PutProp.Parser, new string[3] { "Id", "NameChange", "AutoClearChange" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.PutProp.Types.AutoClearChange), API_v1_Prop_Request.Types.PutProp.Types.AutoClearChange.Parser, new string[2] { "AutoClearEnabled", "AutoClearDuration" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.DeleteProp), API_v1_Prop_Request.Types.DeleteProp.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.TriggerProp), API_v1_Prop_Request.Types.TriggerProp.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.ClearProp), API_v1_Prop_Request.Types.ClearProp.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.PauseProp), API_v1_Prop_Request.Types.PauseProp.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.ResumeProp), API_v1_Prop_Request.Types.ResumeProp.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.GetThumbnail), API_v1_Prop_Request.Types.GetThumbnail.Parser, new string[2] { "Id", "Quality" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.GetPropCollections), API_v1_Prop_Request.Types.GetPropCollections.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.GetPropCollection), API_v1_Prop_Request.Types.GetPropCollection.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.PostPropCollections), API_v1_Prop_Request.Types.PostPropCollections.Parser, new string[1] { "Name" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.PutPropCollection), API_v1_Prop_Request.Types.PutPropCollection.Parser, new string[2] { "Id", "Changes" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Request.Types.DeletePropCollection), API_v1_Prop_Request.Types.DeletePropCollection.Parser, new string[1] { "Id" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response), API_v1_Prop_Response.Parser, new string[14]
			{
				"Props", "GetProp", "PutProp", "DeleteProp", "TriggerProp", "ClearProp", "GetThumbnail", "GetPropCollections", "GetPropCollection", "PostPropCollections",
				"PutPropCollection", "DeletePropCollection", "PauseProp", "ResumeProp"
			}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[14]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.Props), API_v1_Prop_Response.Types.Props.Parser, new string[1] { "Props_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.GetProp), API_v1_Prop_Response.Types.GetProp.Parser, new string[1] { "Prop" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.PutProp), API_v1_Prop_Response.Types.PutProp.Parser, new string[1] { "Prop" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.DeleteProp), API_v1_Prop_Response.Types.DeleteProp.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.TriggerProp), API_v1_Prop_Response.Types.TriggerProp.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.ClearProp), API_v1_Prop_Response.Types.ClearProp.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.PauseProp), API_v1_Prop_Response.Types.PauseProp.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.ResumeProp), API_v1_Prop_Response.Types.ResumeProp.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.GetThumbnail), API_v1_Prop_Response.Types.GetThumbnail.Parser, new string[1] { "Data" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.GetPropCollections), API_v1_Prop_Response.Types.GetPropCollections.Parser, new string[1] { "PropCollections" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.GetPropCollections.Types.Collections), API_v1_Prop_Response.Types.GetPropCollections.Types.Collections.Parser, new string[1] { "Collections_" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.GetPropCollection), API_v1_Prop_Response.Types.GetPropCollection.Parser, new string[1] { "PropCollection" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.PostPropCollections), API_v1_Prop_Response.Types.PostPropCollections.Parser, new string[1] { "PropCollection" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.PutPropCollection), API_v1_Prop_Response.Types.PutPropCollection.Parser, new string[1] { "PropCollection" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Prop_Response.Types.DeletePropCollection), API_v1_Prop_Response.Types.DeletePropCollection.Parser, null, null, null, null, null)
			})
		}));
	}
}
