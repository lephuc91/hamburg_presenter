using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1TimerReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1TimerReflection()
	{
		_003C_003Ey__InlineArray97<string> buffer = default(_003C_003Ey__InlineArray97<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 0) = "ChNwcm9BcGlWMVRpbWVyLnByb3RvEgdydi5kYXRhGhhwcm9BcGlWMUlkZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 1) = "aWZpZXIucHJvdG8ipgMKEkFQSV92MV9UaW1lckZvcm1hdBJHCgRob3VyGAYg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 2) = "ASgOMjkucnYuZGF0YS5BUElfdjFfVGltZXJGb3JtYXQuQVBJX3YxX1RpbWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 3) = "VW5pdERpc3BsYXlGb3JtYXQSSQoGbWludXRlGAcgASgOMjkucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 4) = "UElfdjFfVGltZXJGb3JtYXQuQVBJX3YxX1RpbWVyVW5pdERpc3BsYXlGb3Jt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 5) = "YXQSSQoGc2Vjb25kGAggASgOMjkucnYuZGF0YS5BUElfdjFfVGltZXJGb3Jt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 6) = "YXQuQVBJX3YxX1RpbWVyVW5pdERpc3BsYXlGb3JtYXQSTgoLbWlsbGlzZWNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 7) = "bmQYCSABKA4yOS5ydi5kYXRhLkFQSV92MV9UaW1lckZvcm1hdC5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 8) = "VGltZXJVbml0RGlzcGxheUZvcm1hdCJhCh1BUElfdjFfVGltZXJVbml0RGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 9) = "cGxheUZvcm1hdBIICgRub25lEAASCQoFc2hvcnQQARIICgRsb25nEAISEAoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 10) = "cmVtb3ZlX3Nob3J0EAMSDwoLcmVtb3ZlX2xvbmcQBCJ0ChFBUElfdjFfVGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 11) = "ZXJWYWx1ZRImCgJpZBgBIAEoCzIaLnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 12) = "ZXISDAoEdGltZRgCIAEoCRIpCgVzdGF0ZRgDIAEoDjIaLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 13) = "X3YxX1RpbWVyU3RhdGUi2wQKDEFQSV92MV9UaW1lchImCgJpZBgBIAEoCzIa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 14) = "LnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZpZXISFgoOYWxsb3dzX292ZXJydW4Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 15) = "AiABKAgSQQoJY291bnRkb3duGAMgASgLMiwucnYuZGF0YS5BUElfdjFfVGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 16) = "ZXIuQVBJX3YxX1RpbWVyX0NvdW50ZG93bkgAElAKEmNvdW50X2Rvd25fdG9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 17) = "dGltZRgEIAEoCzIyLnJ2LmRhdGEuQVBJX3YxX1RpbWVyLkFQSV92MV9UaW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 18) = "cl9Db3VudGRvd25Ub1RpbWVIABI9CgdlbGFwc2VkGAUgASgLMioucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 19) = "YS5BUElfdjFfVGltZXIuQVBJX3YxX1RpbWVyX0VsYXBzZWRIABoqChZBUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 20) = "djFfVGltZXJfQ291bnRkb3duEhAKCGR1cmF0aW9uGAEgASgFGmwKHEFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 21) = "MV9UaW1lcl9Db3VudGRvd25Ub1RpbWUSEwoLdGltZV9vZl9kYXkYASABKAUS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 22) = "NwoGcGVyaW9kGAIgASgOMicucnYuZGF0YS5BUElfdjFfVGltZXIuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 23) = "X1RpbWVQZXJpb2QaUgoUQVBJX3YxX1RpbWVyX0VsYXBzZWQSEgoKc3RhcnRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 24) = "dGltZRgBIAEoBRIQCghlbmRfdGltZRgCIAEoBRIUCgxoYXNfZW5kX3RpbWUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 25) = "AyABKAgiMwoRQVBJX3YxX1RpbWVQZXJpb2QSBgoCYW0QABIGCgJwbRABEg4K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 26) = "CmlzXzI0X2hvdXIQAkIUChJUaW1lckNvbmZpZ3VyYXRpb24izQwKFEFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 27) = "MV9UaW1lcl9SZXF1ZXN0EjYKBnRpbWVycxgBIAEoCzIkLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 28) = "X3YxX1RpbWVyX1JlcXVlc3QuVGltZXJzSAASQQoMY3JlYXRlX3RpbWVyGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 29) = "ASgLMikucnYuZGF0YS5BUElfdjFfVGltZXJfUmVxdWVzdC5DcmVhdGVUaW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 30) = "ckgAEkMKDWN1cnJlbnRfdGltZXMYAyABKAsyKi5ydi5kYXRhLkFQSV92MV9U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 31) = "aW1lcl9SZXF1ZXN0LkN1cnJlbnRUaW1lc0gAElAKFGFsbF90aW1lcnNfb3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 32) = "cmF0aW9uGAQgASgLMjAucnYuZGF0YS5BUElfdjFfVGltZXJfUmVxdWVzdC5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 33) = "bGxUaW1lcnNPcGVyYXRpb25IABI7CglnZXRfdGltZXIYBSABKAsyJi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 34) = "YXRhLkFQSV92MV9UaW1lcl9SZXF1ZXN0LkdldFRpbWVySAASOwoJcHV0X3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 35) = "bWVyGAYgASgLMiYucnYuZGF0YS5BUElfdjFfVGltZXJfUmVxdWVzdC5QdXRU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 36) = "aW1lckgAEkEKDGRlbGV0ZV90aW1lchgHIAEoCzIpLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 37) = "X1RpbWVyX1JlcXVlc3QuRGVsZXRlVGltZXJIABJHCg90aW1lcl9vcGVyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 38) = "b24YCCABKAsyLC5ydi5kYXRhLkFQSV92MV9UaW1lcl9SZXF1ZXN0LlRpbWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 39) = "T3BlcmF0aW9uSAASTgoTcHV0X3RpbWVyX29wZXJhdGlvbhgJIAEoCzIvLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 40) = "LmRhdGEuQVBJX3YxX1RpbWVyX1JlcXVlc3QuUHV0VGltZXJPcGVyYXRpb25I";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 41) = "ABJHCg90aW1lcl9pbmNyZW1lbnQYCiABKAsyLC5ydi5kYXRhLkFQSV92MV9U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 42) = "aW1lcl9SZXF1ZXN0LlRpbWVySW5jcmVtZW50SAASPwoLc3lzdGVtX3RpbWUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 43) = "CyABKAsyKC5ydi5kYXRhLkFQSV92MV9UaW1lcl9SZXF1ZXN0LlN5c3RlbVRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 44) = "bWVIABJHCg92aWRlb19jb3VudGRvd24YDCABKAsyLC5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 45) = "MV9UaW1lcl9SZXF1ZXN0LlZpZGVvQ291bnRkb3duSAAaCAoGVGltZXJzGoEC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 46) = "CgtDcmVhdGVUaW1lchIMCgRuYW1lGAEgASgJEhYKDmFsbG93c19vdmVycnVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 47) = "GAIgASgIEj8KCWNvdW50ZG93bhgDIAEoCzIsLnJ2LmRhdGEuQVBJX3YxX1Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 48) = "bWVyLkFQSV92MV9UaW1lcl9Db3VudGRvd24STgoSY291bnRfZG93bl90b190";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 49) = "aW1lGAQgASgLMjIucnYuZGF0YS5BUElfdjFfVGltZXIuQVBJX3YxX1RpbWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 50) = "X0NvdW50ZG93blRvVGltZRI7CgdlbGFwc2VkGAUgASgLMioucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 51) = "UElfdjFfVGltZXIuQVBJX3YxX1RpbWVyX0VsYXBzZWQaDgoMQ3VycmVudFRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 52) = "bWVzGkcKEkFsbFRpbWVyc09wZXJhdGlvbhIxCglvcGVyYXRpb24YASABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 53) = "Hi5ydi5kYXRhLkFQSV92MV9UaW1lck9wZXJhdGlvbhoWCghHZXRUaW1lchIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 54) = "CgJpZBgBIAEoCRo8CghQdXRUaW1lchIKCgJpZBgBIAEoCRIkCgV0aW1lchgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 55) = "IAEoCzIVLnJ2LmRhdGEuQVBJX3YxX1RpbWVyGhkKC0RlbGV0ZVRpbWVyEgoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 56) = "AmlkGAEgASgJGk8KDlRpbWVyT3BlcmF0aW9uEgoKAmlkGAEgASgJEjEKCW9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 57) = "ZXJhdGlvbhgCIAEoDjIeLnJ2LmRhdGEuQVBJX3YxX1RpbWVyT3BlcmF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 58) = "GngKEVB1dFRpbWVyT3BlcmF0aW9uEgoKAmlkGAEgASgJEjEKCW9wZXJhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 59) = "bhgCIAEoDjIeLnJ2LmRhdGEuQVBJX3YxX1RpbWVyT3BlcmF0aW9uEiQKBXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 60) = "bWVyGAMgASgLMhUucnYuZGF0YS5BUElfdjFfVGltZXIaLAoOVGltZXJJbmNy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 61) = "ZW1lbnQSCgoCaWQYASABKAkSDgoGYW1vdW50GAIgASgBGgwKClN5c3RlbVRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 62) = "bWUaEAoOVmlkZW9Db3VudGRvd25CCQoHUmVxdWVzdCKwCgoVQVBJX3YxX1Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 63) = "bWVyX1Jlc3BvbnNlEjcKBnRpbWVycxgBIAEoCzIlLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 64) = "X1RpbWVyX1Jlc3BvbnNlLlRpbWVyc0gAEkIKDGNyZWF0ZV90aW1lchgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 65) = "CzIqLnJ2LmRhdGEuQVBJX3YxX1RpbWVyX1Jlc3BvbnNlLkNyZWF0ZVRpbWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 66) = "SAASRAoNY3VycmVudF90aW1lcxgDIAEoCzIrLnJ2LmRhdGEuQVBJX3YxX1Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 67) = "bWVyX1Jlc3BvbnNlLkN1cnJlbnRUaW1lc0gAElEKFGFsbF90aW1lcnNfb3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 68) = "cmF0aW9uGAQgASgLMjEucnYuZGF0YS5BUElfdjFfVGltZXJfUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 69) = "QWxsVGltZXJzT3BlcmF0aW9uSAASPAoJZ2V0X3RpbWVyGAUgASgLMicucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 70) = "ZGF0YS5BUElfdjFfVGltZXJfUmVzcG9uc2UuR2V0VGltZXJIABI8CglwdXRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 71) = "dGltZXIYBiABKAsyJy5ydi5kYXRhLkFQSV92MV9UaW1lcl9SZXNwb25zZS5Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 72) = "dXRUaW1lckgAEkIKDGRlbGV0ZV90aW1lchgHIAEoCzIqLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 73) = "X3YxX1RpbWVyX1Jlc3BvbnNlLkRlbGV0ZVRpbWVySAASSAoPdGltZXJfb3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 74) = "cmF0aW9uGAggASgLMi0ucnYuZGF0YS5BUElfdjFfVGltZXJfUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 75) = "VGltZXJPcGVyYXRpb25IABJPChNwdXRfdGltZXJfb3BlcmF0aW9uGAkgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 76) = "MjAucnYuZGF0YS5BUElfdjFfVGltZXJfUmVzcG9uc2UuUHV0VGltZXJPcGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 77) = "YXRpb25IABJICg90aW1lcl9pbmNyZW1lbnQYCiABKAsyLS5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 78) = "SV92MV9UaW1lcl9SZXNwb25zZS5UaW1lckluY3JlbWVudEgAEkAKC3N5c3Rl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 79) = "bV90aW1lGAsgASgLMikucnYuZGF0YS5BUElfdjFfVGltZXJfUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 80) = "U3lzdGVtVGltZUgAEkgKD3ZpZGVvX2NvdW50ZG93bhgMIAEoCzItLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 81) = "dGEuQVBJX3YxX1RpbWVyX1Jlc3BvbnNlLlZpZGVvQ291bnRkb3duSAAaLwoG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 82) = "VGltZXJzEiUKBnRpbWVycxgBIAMoCzIVLnJ2LmRhdGEuQVBJX3YxX1RpbWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 83) = "GjMKC0NyZWF0ZVRpbWVyEiQKBXRpbWVyGAEgASgLMhUucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 84) = "djFfVGltZXIaOgoMQ3VycmVudFRpbWVzEioKBnRpbWVycxgBIAMoCzIaLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 85) = "LmRhdGEuQVBJX3YxX1RpbWVyVmFsdWUaFAoSQWxsVGltZXJzT3BlcmF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 86) = "GjAKCEdldFRpbWVyEiQKBXRpbWVyGAEgASgLMhUucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 87) = "VGltZXIaMAoIUHV0VGltZXISJAoFdGltZXIYASABKAsyFS5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 88) = "SV92MV9UaW1lchoNCgtEZWxldGVUaW1lchoQCg5UaW1lck9wZXJhdGlvbho5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 89) = "ChFQdXRUaW1lck9wZXJhdGlvbhIkCgV0aW1lchgBIAEoCzIVLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 90) = "QVBJX3YxX1RpbWVyGhAKDlRpbWVySW5jcmVtZW50GhoKClN5c3RlbVRpbWUS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 91) = "DAoEdGltZRgBIAEoBBoeCg5WaWRlb0NvdW50ZG93bhIMCgR0aW1lGAEgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 92) = "QgoKCFJlc3BvbnNlKlkKEUFQSV92MV9UaW1lclN0YXRlEgsKB3N0b3BwZWQQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 93) = "ABILCgdydW5uaW5nEAESDAoIY29tcGxldGUQAhIPCgtvdmVycnVubmluZxAD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 94) = "EgsKB292ZXJyYW4QBCo3ChVBUElfdjFfVGltZXJPcGVyYXRpb24SCQoFc3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 95) = "cnQQABIICgRzdG9wEAESCQoFcmVzZXQQAkI0+AEBqgIkUHJvLlNlcmlhbGl6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray97<string>, string>(ref buffer, 96) = "YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray97<string>, string>(in buffer, 97))), new FileDescriptor[1] { ProApiV1IdentifierReflection.Descriptor }, new GeneratedClrTypeInfo(new Type[2]
		{
			typeof(API_v1_TimerState),
			typeof(API_v1_TimerOperation)
		}, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_TimerFormat), API_v1_TimerFormat.Parser, new string[4] { "Hour", "Minute", "Second", "Millisecond" }, null, new Type[1] { typeof(API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat) }, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_TimerValue), API_v1_TimerValue.Parser, new string[3] { "Id", "Time", "State" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Timer), API_v1_Timer.Parser, new string[5] { "Id", "AllowsOverrun", "Countdown", "CountDownToTime", "Elapsed" }, new string[1] { "TimerConfiguration" }, new Type[1] { typeof(API_v1_Timer.Types.API_v1_TimePeriod) }, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Timer.Types.API_v1_Timer_Countdown), API_v1_Timer.Types.API_v1_Timer_Countdown.Parser, new string[1] { "Duration" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer.Types.API_v1_Timer_CountdownToTime), API_v1_Timer.Types.API_v1_Timer_CountdownToTime.Parser, new string[2] { "TimeOfDay", "Period" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer.Types.API_v1_Timer_Elapsed), API_v1_Timer.Types.API_v1_Timer_Elapsed.Parser, new string[3] { "StartTime", "EndTime", "HasEndTime" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request), API_v1_Timer_Request.Parser, new string[12]
			{
				"Timers", "CreateTimer", "CurrentTimes", "AllTimersOperation", "GetTimer", "PutTimer", "DeleteTimer", "TimerOperation", "PutTimerOperation", "TimerIncrement",
				"SystemTime", "VideoCountdown"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[12]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.Timers), API_v1_Timer_Request.Types.Timers.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.CreateTimer), API_v1_Timer_Request.Types.CreateTimer.Parser, new string[5] { "Name", "AllowsOverrun", "Countdown", "CountDownToTime", "Elapsed" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.CurrentTimes), API_v1_Timer_Request.Types.CurrentTimes.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.AllTimersOperation), API_v1_Timer_Request.Types.AllTimersOperation.Parser, new string[1] { "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.GetTimer), API_v1_Timer_Request.Types.GetTimer.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.PutTimer), API_v1_Timer_Request.Types.PutTimer.Parser, new string[2] { "Id", "Timer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.DeleteTimer), API_v1_Timer_Request.Types.DeleteTimer.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.TimerOperation), API_v1_Timer_Request.Types.TimerOperation.Parser, new string[2] { "Id", "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.PutTimerOperation), API_v1_Timer_Request.Types.PutTimerOperation.Parser, new string[3] { "Id", "Operation", "Timer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.TimerIncrement), API_v1_Timer_Request.Types.TimerIncrement.Parser, new string[2] { "Id", "Amount" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.SystemTime), API_v1_Timer_Request.Types.SystemTime.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Request.Types.VideoCountdown), API_v1_Timer_Request.Types.VideoCountdown.Parser, null, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response), API_v1_Timer_Response.Parser, new string[12]
			{
				"Timers", "CreateTimer", "CurrentTimes", "AllTimersOperation", "GetTimer", "PutTimer", "DeleteTimer", "TimerOperation", "PutTimerOperation", "TimerIncrement",
				"SystemTime", "VideoCountdown"
			}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[12]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.Timers), API_v1_Timer_Response.Types.Timers.Parser, new string[1] { "Timers_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.CreateTimer), API_v1_Timer_Response.Types.CreateTimer.Parser, new string[1] { "Timer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.CurrentTimes), API_v1_Timer_Response.Types.CurrentTimes.Parser, new string[1] { "Timers" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.AllTimersOperation), API_v1_Timer_Response.Types.AllTimersOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.GetTimer), API_v1_Timer_Response.Types.GetTimer.Parser, new string[1] { "Timer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.PutTimer), API_v1_Timer_Response.Types.PutTimer.Parser, new string[1] { "Timer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.DeleteTimer), API_v1_Timer_Response.Types.DeleteTimer.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.TimerOperation), API_v1_Timer_Response.Types.TimerOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.PutTimerOperation), API_v1_Timer_Response.Types.PutTimerOperation.Parser, new string[1] { "Timer" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.TimerIncrement), API_v1_Timer_Response.Types.TimerIncrement.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.SystemTime), API_v1_Timer_Response.Types.SystemTime.Parser, new string[1] { "Time" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Timer_Response.Types.VideoCountdown), API_v1_Timer_Response.Types.VideoCountdown.Parser, new string[1] { "Time" }, null, null, null, null)
			})
		}));
	}
}
