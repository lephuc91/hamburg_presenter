using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public static class RegistrationReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static RegistrationReflection()
	{
		_003C_003Ey__InlineArray241<string> buffer = default(_003C_003Ey__InlineArray241<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 0) = "ChJyZWdpc3RyYXRpb24ucHJvdG8SEXJlZ2lzdHJhdGlvbi5jb3JlIu0KCgdS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 1) = "ZXF1ZXN0Ei8KCHJlZ2lzdGVyGAEgASgLMhsucmVnaXN0cmF0aW9uLmNvcmUu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 2) = "UmVnaXN0ZXJIABIzCgp1bnJlZ2lzdGVyGAIgASgLMh0ucmVnaXN0cmF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 3) = "LmNvcmUuVW5yZWdpc3RlckgAEj0KEGNoYW5nZV9zZWF0X3R5cGUYAyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 4) = "IS5yZWdpc3RyYXRpb24uY29yZS5DaGFuZ2VTZWF0VHlwZUgAEjIKCmdldF9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 5) = "aWJsZXMYBCABKAsyHC5yZWdpc3RyYXRpb24uY29yZS5HZXRCaWJsZXNIABI6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 6) = "Cg5hY3RpdmF0ZV9iaWJsZRgFIAEoCzIgLnJlZ2lzdHJhdGlvbi5jb3JlLkFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 7) = "dGl2YXRlQmlibGVIABI+ChBkZWFjdGl2YXRlX2JpYmxlGAYgASgLMiIucmVn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 8) = "aXN0cmF0aW9uLmNvcmUuRGVhY3RpdmF0ZUJpYmxlSAASOgoOZG93bmxvYWRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 9) = "YmlibGUYByABKAsyIC5yZWdpc3RyYXRpb24uY29yZS5Eb3dubG9hZEJpYmxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 10) = "SAASQAoRcmVnaXN0cmF0aW9uX2RhdGEYCCABKAsyIy5yZWdpc3RyYXRpb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 11) = "Y29yZS5SZWdpc3RyYXRpb25EYXRhSAASRAoTcHJvZHVjdF9pbmZvcm1hdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 12) = "bhgJIAEoCzIlLnJlZ2lzdHJhdGlvbi5jb3JlLlByb2R1Y3RJbmZvcm1hdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 13) = "bkgAEkgKFmdldF91cGdyYWRlc19hdmFpbGFibGUYCiABKAsyJi5yZWdpc3Ry";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 14) = "YXRpb24uY29yZS5HZXRBdmFpbGFibGVWZXJzaW9uSAASRQoUZG93bmxvYWRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 15) = "bmV3X3ZlcnNpb24YCyABKAsyJS5yZWdpc3RyYXRpb24uY29yZS5Eb3dubG9h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 16) = "ZE5ld1ZlcnNpb25IABItCgdyZWZyZXNoGAwgASgLMhoucmVnaXN0cmF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 17) = "LmNvcmUuUmVmcmVzaEgAEjgKDWFjdGl2YXRlX2xpbmsYDSABKAsyHy5yZWdp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 18) = "c3RyYXRpb24uY29yZS5BY3RpdmF0ZUxpbmtIABI2Cgx1cGRhdGVfdG9rZW4Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 19) = "DiABKAsyHi5yZWdpc3RyYXRpb24uY29yZS5VcGRhdGVUb2tlbkgAEjkKDm9s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 20) = "ZF90b2tlbl9kYXRhGA8gASgLMh8ucmVnaXN0cmF0aW9uLmNvcmUuT2xkVG9r";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 21) = "ZW5EYXRhSAASLQoHc2lnbm91dBgQIAEoCzIaLnJlZ2lzdHJhdGlvbi5jb3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 22) = "LlNpZ25vdXRIABI/ChFnZXRfYWN0aXZhdGVfY29kZRgRIAEoCzIiLnJlZ2lz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 23) = "dHJhdGlvbi5jb3JlLkdldEFjdGl2YXRlQ29kZUgAEkAKEW5vdGlmaWNhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 24) = "bl9kYXRhGBIgASgLMiMucmVnaXN0cmF0aW9uLmNvcmUuTm90aWZpY2F0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 25) = "RGF0YUgAEkkKFW1hcmtOb3RpZmljYXRpb25zUmVhZBgTIAEoCzIoLnJlZ2lz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 26) = "dHJhdGlvbi5jb3JlLk1hcmtOb3RpZmljYXRpb25zUmVhZEgAEj8KEWdldF9s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 27) = "aWNlbnNlX3N0YXRlGBQgASgLMiIucmVnaXN0cmF0aW9uLmNvcmUuR2V0TGlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 28) = "ZW5zZVN0YXRlSAASTAoYcmVmcmVzaF91c2VyX2F1dGhfdG9rZW5zGBUgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 29) = "MigucmVnaXN0cmF0aW9uLmNvcmUuUmVmcmVzaFVzZXJBdXRoVG9rZW5zSAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 30) = "RQoUcmVmcmVzaF9hY2Nlc3NfdG9rZW4YFiABKAsyJS5yZWdpc3RyYXRpb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 31) = "Y29yZS5SZWZyZXNoQWNjZXNzVG9rZW5IAEIJCgdyZXF1ZXN0IoYKCghDYWxs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 32) = "YmFjaxI4Cg1zZXRfd2F0ZXJtYXJrGAEgASgLMh8ucmVnaXN0cmF0aW9uLmNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 33) = "cmUuU2V0V2F0ZXJtYXJrSAASSwoXYmlibGVfZG93bmxvYWRfcHJvZ3Jlc3MY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 34) = "AiABKAsyKC5yZWdpc3RyYXRpb24uY29yZS5CaWJsZURvd25sb2FkUHJvZ3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 35) = "c3NIABIwCgloYXJkX2V4aXQYAyABKAsyGy5yZWdpc3RyYXRpb24uY29yZS5I";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 36) = "YXJkRXhpdEgAEkkKFnJlYWRfcmVnaXN0cmF0aW9uX2RhdGEYBCABKAsyJy5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 37) = "ZWdpc3RyYXRpb24uY29yZS5SZWFkUmVnaXN0cmF0aW9uRGF0YUgAEksKF3dy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 38) = "aXRlX3JlZ2lzdHJhdGlvbl9kYXRhGAUgASgLMigucmVnaXN0cmF0aW9uLmNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 39) = "cmUuV3JpdGVSZWdpc3RyYXRpb25EYXRhSAASSwoXZ2V0X3Byb2R1Y3RfaW5m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 40) = "b3JtYXRpb24YBiABKAsyKC5yZWdpc3RyYXRpb24uY29yZS5HZXRQcm9kdWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 41) = "SW5mb3JtYXRpb25IABIlCgNsb2cYByABKAsyFi5yZWdpc3RyYXRpb24uY29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 42) = "ZS5Mb2dIABJCChJ1cGdyYWRlc19hdmFpbGFibGUYCCABKAsyJC5yZWdpc3Ry";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 43) = "YXRpb24uY29yZS5VcGdyYWRlc0F2YWlsYWJsZUgAEkAKEWRvd25sb2FkX3By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 44) = "b2dyZXNzGAkgASgLMiMucmVnaXN0cmF0aW9uLmNvcmUuRG93bmxvYWRQcm9n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 45) = "cmVzc0gAEisKBmFsZXJ0cxgKIAEoCzIZLnJlZ2lzdHJhdGlvbi5jb3JlLkFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 46) = "ZXJ0c0gAEkkKFnNob3dfZXhwaXJhdGlvbl9kaWFsb2cYCyABKAsyJy5yZWdp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 47) = "c3RyYXRpb24uY29yZS5TaG93RXhwaXJhdGlvbkRpYWxvZ0gAEjkKDnJlYWRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 48) = "b2xkX3Rva2VuGAwgASgLMh8ucmVnaXN0cmF0aW9uLmNvcmUuUmVhZE9sZFRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 49) = "a2VuSAASSAoVdmVyaWZpY2F0aW9uX2NvbXBsZXRlGA0gASgLMicucmVnaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 50) = "cmF0aW9uLmNvcmUuVmVyaWZpY2F0aW9uQ29tcGxldGVIABI7Cg9zZXRfY2xp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 51) = "ZW50X2luZm8YDiABKAsyIC5yZWdpc3RyYXRpb24uY29yZS5TZXRDbGllbnRJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 52) = "bmZvSAASTQoaZ2V0X2FjdGl2YXRlX2NvZGVfY29tcGxldGUYDyABKAsyJy5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 53) = "ZWdpc3RyYXRpb24uY29yZS5BY3RpdmF0ZUNvZGVDb21wbGV0ZUgAEkkKFnJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 54) = "YWRfbm90aWZpY2F0aW9uX2RhdGEYECABKAsyJy5yZWdpc3RyYXRpb24uY29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 55) = "ZS5SZWFkTm90aWZpY2F0aW9uRGF0YUgAEksKF3dyaXRlX25vdGlmaWNhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 56) = "bl9kYXRhGBEgASgLMigucmVnaXN0cmF0aW9uLmNvcmUuV3JpdGVOb3RpZmlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 57) = "YXRpb25EYXRhSAASSAoVbm90aWZpY2F0aW9uX2NhbGxiYWNrGBIgASgLMicu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 58) = "cmVnaXN0cmF0aW9uLmNvcmUuTm90aWZpY2F0aW9uQ2FsbGJhY2tIABI4Cg1s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 59) = "aWNlbnNlX3N0YXRlGBMgASgLMh8ucmVnaXN0cmF0aW9uLmNvcmUuTGljZW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 60) = "ZVN0YXRlSABCCgoIY2FsbGJhY2sisAEKCFJlZ2lzdGVyEhEKCXVzZXJfbmFt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 61) = "ZRgBIAEoCRIYChByZWdpc3RyYXRpb25fa2V5GAIgASgJEhQKDGRpc3BsYXlf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 62) = "bmFtZRgDIAEoCRIuCglzZWF0X3R5cGUYBCABKA4yGy5yZWdpc3RyYXRpb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 63) = "Y29yZS5TZWF0VHlwZRIxCgdjaGFubmVsGAUgASgOMiAucmVnaXN0cmF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 64) = "LmNvcmUuVXBkYXRlQ2hhbm5lbCIiCgxBY3RpdmF0ZUxpbmsSEgoKaWRlbnRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 65) = "ZmllchgBIAEoCSIMCgpVbnJlZ2lzdGVyIgkKB1NpZ25vdXQicwoOQ2hhbmdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 66) = "U2VhdFR5cGUSLgoJc2VhdF90eXBlGAEgASgOMhsucmVnaXN0cmF0aW9uLmNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 67) = "cmUuU2VhdFR5cGUSMQoHY2hhbm5lbBgCIAEoDjIgLnJlZ2lzdHJhdGlvbi5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 68) = "b3JlLlVwZGF0ZUNoYW5uZWwiCwoJR2V0QmlibGVzIiEKDUFjdGl2YXRlQmli";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 69) = "bGUSEAoIYmlibGVfaWQYASABKAkiIwoPRGVhY3RpdmF0ZUJpYmxlEhAKCGJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 70) = "YmxlX2lkGAEgASgJIjMKDURvd25sb2FkQmlibGUSEAoIYmlibGVfaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 71) = "KAkSEAoIZmlsZW5hbWUYAiABKAkiUwoQUmVnaXN0cmF0aW9uRGF0YRIMCgRk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 72) = "YXRhGAEgASgMEjEKB2NoYW5uZWwYAiABKA4yIC5yZWdpc3RyYXRpb24uY29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 73) = "ZS5VcGRhdGVDaGFubmVsIpkBChJQcm9kdWN0SW5mb3JtYXRpb24SFAoMcHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 74) = "ZHVjdF9uYW1lGAEgASgJEhUKDW1ham9yX3ZlcnNpb24YAiABKAkSFQoNbWlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 75) = "b3JfdmVyc2lvbhgDIAEoCRIVCg1wYXRjaF92ZXJzaW9uGAQgASgJEhQKDGJ1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 76) = "aWxkX251bWJlchgFIAEoCRISCgpidWlsZF9kYXRlGAYgASgDImUKE0dldEF2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 77) = "YWlsYWJsZVZlcnNpb24SFQoNaW5jbHVkZV9ub3RlcxgBIAEoCBIPCgdjaGFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 78) = "bmVsGAIgASgJEg4KBmZvcm1hdBgDIAEoCRIWCg51c2VyX2luaXRpYXRlZBgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 79) = "IAEoCCIzChJEb3dubG9hZE5ld1ZlcnNpb24SCwoDdXJsGAEgASgJEhAKCGZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 80) = "bGVuYW1lGAIgASgJIjwKB1JlZnJlc2gSMQoHY2hhbm5lbBgBIAEoDjIgLnJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 81) = "Z2lzdHJhdGlvbi5jb3JlLlVwZGF0ZUNoYW5uZWwiRwoLVXBkYXRlVG9rZW4S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 82) = "OAoOdG9rZW5fbWV0YWRhdGEYASABKAsyIC5yZWdpc3RyYXRpb24uY29yZS5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 83) = "b2tlbk1ldGFkYXRhInMKDE9sZFRva2VuRGF0YRIyCgZzdGF0dXMYASABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 84) = "Ii5yZWdpc3RyYXRpb24uY29yZS5SZWFkVG9rZW5TdGF0dXMSLwoFdG9rZW4Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 85) = "AiABKAsyIC5yZWdpc3RyYXRpb24uY29yZS5Ub2tlbk1ldGFkYXRhIkEKBVRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 86) = "a2VuEjgKDnRva2VuX21ldGFkYXRhGAEgASgLMiAucmVnaXN0cmF0aW9uLmNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 87) = "cmUuVG9rZW5NZXRhZGF0YSJECg9HZXRBY3RpdmF0ZUNvZGUSFgoOc2VhdF9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 88) = "dWNrZXRfaWQYASABKAkSGQoRb3JnYW5pemF0aW9uX3V1aWQYAiABKAkiIAoQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 89) = "Tm90aWZpY2F0aW9uRGF0YRIMCgRkYXRhGAEgASgMIiMKFU1hcmtOb3RpZmlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 90) = "YXRpb25zUmVhZBIKCgJpZBgBIAMoCSIRCg9HZXRMaWNlbnNlU3RhdGUiFwoV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 91) = "UmVmcmVzaFVzZXJBdXRoVG9rZW5zIhQKElJlZnJlc2hBY2Nlc3NUb2tlbiI6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 92) = "CgxTZXRXYXRlcm1hcmsSFQoNaXNfcmVnaXN0ZXJlZBgBIAEoCBITCgthY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 93) = "dmVfc2VhdBgCIAEoCCLVAQoWQ2hhbmdlU2VhdFR5cGVDb21wbGV0ZRIpCgZy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 94) = "ZXN1bHQYASABKA4yGS5yZWdpc3RyYXRpb24uY29yZS5TdGF0dXMSMQoPYXZh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 95) = "aWxhYmxlX3NlYXRzGAIgASgLMhgucmVnaXN0cmF0aW9uLmNvcmUuU2VhdHMS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 96) = "LQoLdG90YWxfc2VhdHMYAyABKAsyGC5yZWdpc3RyYXRpb24uY29yZS5TZWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 97) = "cxIuCglzZWF0X3R5cGUYBCABKA4yGy5yZWdpc3RyYXRpb24uY29yZS5TZWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 98) = "VHlwZSLfAQoVQmlibGVEb3dubG9hZFByb2dyZXNzEikKBnN0YXR1cxgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 99) = "DjIZLnJlZ2lzdHJhdGlvbi5jb3JlLlN0YXR1cxIQCghjb21wbGV0ZRgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 100) = "CBIQCghwcm9ncmVzcxgDIAEoAhIQCghiaWJsZV9pZBgEIAEoCRIRCglmaWxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 101) = "X25hbWUYBSABKAkSFQoNZG93bmxvYWRfbGluaxgGIAEoCRI7CgxjbGllbnRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 102) = "YWxlcnQYByABKA4yJS5yZWdpc3RyYXRpb24uY29yZS5DbGllbnRBbGVydE1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 103) = "c3NhZ2UiZwoISGFyZEV4aXQSMgoGcmVhc29uGAEgASgOMiIucmVnaXN0cmF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 104) = "aW9uLmNvcmUuSGFyZEV4aXQuUmVhc29uIicKBlJlYXNvbhINCglIb3N0c0Zp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 105) = "bGUQABIOCgpTeXN0ZW1UaW1lEAEiPwoUUmVhZFJlZ2lzdHJhdGlvbkRhdGES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 106) = "EwoLZmluZ2VycHJpbnQYASABKAkSEgoKaWRlbnRpZmllchgCIAEoCSIOCgxS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 107) = "ZWFkT2xkVG9rZW4iJQoVV3JpdGVSZWdpc3RyYXRpb25EYXRhEgwKBGRhdGEY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 108) = "ASABKAwiFwoVR2V0UHJvZHVjdEluZm9ybWF0aW9uInkKA0xvZxIrCgVsZXZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 109) = "bBgBIAEoDjIcLnJlZ2lzdHJhdGlvbi5jb3JlLkxvZy5MZXZlbBIPCgdtZXNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 110) = "YWdlGAIgASgJIjQKBUxldmVsEgkKBURlYnVnEAASCAoESW5mbxABEgsKB1dh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 111) = "cm5pbmcQAhIJCgVFcnJvchADIoMCChFVcGdyYWRlc0F2YWlsYWJsZRIpCgZz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 112) = "dGF0dXMYASABKA4yGS5yZWdpc3RyYXRpb24uY29yZS5TdGF0dXMSIAoYaXNf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 113) = "bm9uX3Byb2R1Y3Rpb25fYWN0aXZlGAIgASgIEhYKDmFjdGl2ZV9jaGFubmVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 114) = "GAMgASgJEhUKDXJlbGVhc2Vfbm90ZXMYBCABKAkSNQoIdXBncmFkZXMYBSAD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 115) = "KAsyIy5yZWdpc3RyYXRpb24uY29yZS5CdWlsZEluZm9ybWF0aW9uEjsKDGNs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 116) = "aWVudF9hbGVydBgGIAEoDjIlLnJlZ2lzdHJhdGlvbi5jb3JlLkNsaWVudEFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 117) = "ZXJ0TWVzc2FnZSKeAQoQRG93bmxvYWRQcm9ncmVzcxIpCgZzdGF0dXMYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 118) = "KA4yGS5yZWdpc3RyYXRpb24uY29yZS5TdGF0dXMSEAoIY29tcGxldGUYAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 119) = "KAgSEAoIcHJvZ3Jlc3MYAyABKAISOwoMY2xpZW50X2FsZXJ0GAQgASgOMiUu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 120) = "cmVnaXN0cmF0aW9uLmNvcmUuQ2xpZW50QWxlcnRNZXNzYWdlIjIKBkFsZXJ0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 121) = "cxIoCgZhbGVydHMYASADKAsyGC5yZWdpc3RyYXRpb24uY29yZS5BbGVydCIk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 122) = "ChRTaG93RXhwaXJhdGlvbkRpYWxvZxIMCgRkYXlzGAEgASgFIsoDChRWZXJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 123) = "ZmljYXRpb25Db21wbGV0ZRIpCgZyZXN1bHQYASABKA4yGS5yZWdpc3RyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 124) = "b24uY29yZS5TdGF0dXMSLwoHbGljZW5zZRgCIAEoCzIeLnJlZ2lzdHJhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 125) = "bi5jb3JlLkxpY2Vuc2VJbmZvEikKBmJpYmxlcxgDIAEoCzIZLnJlZ2lzdHJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 126) = "dGlvbi5jb3JlLkJpYmxlcxIvCgV0b2tlbhgEIAEoCzIgLnJlZ2lzdHJhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 127) = "bi5jb3JlLlRva2VuTWV0YWRhdGESPgoRc3Vic2NyaXB0aW9uX2luZm8YBSAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 128) = "KAsyIy5yZWdpc3RyYXRpb24uY29yZS5TdWJzY3JpcHRpb25JbmZvEjMKBWFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 129) = "ZXJ0GAYgASgOMiQucmVnaXN0cmF0aW9uLmNvcmUuUG9wdXBBbGVydE1lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 130) = "Z2USMAoGYmFubmVyGAcgASgOMiAucmVnaXN0cmF0aW9uLmNvcmUuQmFubmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 131) = "TWVzc2FnZRI7CgxjbGllbnRfYWxlcnQYCCABKA4yJS5yZWdpc3RyYXRpb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 132) = "Y29yZS5DbGllbnRBbGVydE1lc3NhZ2USFgoOZnVsbHlfbGF1bmNoZWQYCSAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 133) = "KAgiOQoNU2V0Q2xpZW50SW5mbxIRCgljbGllbnRfaWQYASABKAUSFQoNY2xp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 134) = "ZW50X3NlY3JldBgCIAEoCSKJAgoUQWN0aXZhdGVDb2RlQ29tcGxldGUSPgoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 135) = "ZXJyb3IYASABKAsyLS5yZWdpc3RyYXRpb24uY29yZS5BY3RpdmF0ZUNvZGVD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 136) = "b21wbGV0ZS5FcnJvckgAEkIKB3N1Y2Nlc3MYAiABKAsyLy5yZWdpc3RyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 137) = "b24uY29yZS5BY3RpdmF0ZUNvZGVDb21wbGV0ZS5TdWNjZXNzSAAaKwoFRXJy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 138) = "b3ISDQoFZXJyb3IYASABKAkSEwoLZGVzY3JpcHRpb24YAiABKAkaNgoHU3Vj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 139) = "Y2VzcxIXCg9hY3RpdmF0aW9uX2NvZGUYAiABKAkSEgoKZXhwaXJhdGlvbhgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 140) = "IAEoA0IICgZzdGF0dXMiFgoUUmVhZE5vdGlmaWNhdGlvbkRhdGEiJQoVV3Jp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 141) = "dGVOb3RpZmljYXRpb25EYXRhEgwKBGRhdGEYASABKAwiTgoUTm90aWZpY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 142) = "aW9uQ2FsbGJhY2sSNgoNbm90aWZpY2F0aW9ucxgCIAMoCzIfLnJlZ2lzdHJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 143) = "dGlvbi5jb3JlLk5vdGlmaWNhdGlvbiJkCgxMaWNlbnNlU3RhdGUSEwoLaGFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 144) = "ZHdhcmVfaWQYASABKAkSEwoLZmluZ2VycHJpbnQYAiABKAkSFQoNaXNfcmVn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 145) = "aXN0ZXJlZBgDIAEoCBITCgthY3RpdmVfc2VhdBgEIAEoCCIoCgVTZWF0cxIN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 146) = "CgViYXNpYxgBIAEoBRIQCghhZHZhbmNlZBgCIAEoBSIwChdTdXBwbGVtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 147) = "YWxJbmZvcm1hdGlvbhIVCg1kb3dubG9hZF9saW5rGAEgASgJIvEBCgVCaWJs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 148) = "ZRIKCgJpZBgBIAEoCRIMCgRuYW1lGAIgASgJEhAKCGxhbmd1YWdlGAMgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 149) = "EhEKCXB1Ymxpc2hlchgEIAEoCRIRCgljb3B5cmlnaHQYBSABKAkSHAoUZGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 150) = "cGxheV9hYmJyZXZpYXRpb24YBiABKAkSHQoVaW50ZXJuYWxfYWJicmV2aWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 151) = "aW9uGAcgASgJEg8KB3ZlcnNpb24YCCABKAkSOgoEaW5mbxgJIAEoCzIqLnJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 152) = "Z2lzdHJhdGlvbi5jb3JlLlN1cHBsZW1lbnRhbEluZm9ybWF0aW9uSABCDAoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 153) = "YWRkaXRpb25hbCJ2Cg5QdXJjaGFzZWRCaWJsZRIqCghtZXRhZGF0YRgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 154) = "CzIYLnJlZ2lzdHJhdGlvbi5jb3JlLkJpYmxlEjgKDmxpY2Vuc2luZ19pbmZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 155) = "GAIgASgLMiAucmVnaXN0cmF0aW9uLmNvcmUuTGljZW5zaW5nSW5mbyK/AQoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 156) = "TGljZW5zZUluZm8SPgoRcmVnaXN0cmF0aW9uX2luZm8YASABKAsyIy5yZWdp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 157) = "c3RyYXRpb24uY29yZS5SZWdpc3RyYXRpb25JbmZvEjEKD2F2YWlsYWJsZV9z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 158) = "ZWF0cxgCIAEoCzIYLnJlZ2lzdHJhdGlvbi5jb3JlLlNlYXRzEi0KC3RvdGFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 159) = "X3NlYXRzGAMgASgLMhgucmVnaXN0cmF0aW9uLmNvcmUuU2VhdHMSDgoGbGVn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 160) = "YWN5GAQgASgIIpYBCg1MaWNlbnNpbmdJbmZvEhgKEGF2YWlsYWJsZV9jb3Bp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 161) = "ZXMYASABKAUSFAoMdG90YWxfY29waWVzGAIgASgFEhkKEWlzX2FjdGl2ZV9s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 162) = "b2NhbGx5GAMgASgIEjoKE290aGVyX2FjdGl2ZV9jb3BpZXMYBCADKAsyHS5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 163) = "ZWdpc3RyYXRpb24uY29yZS5BY3RpdmVDb3B5IjQKCkFjdGl2ZUNvcHkSFAoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 164) = "ZGlzcGxheV9uYW1lGAEgASgJEhAKCGhvc3RuYW1lGAIgASgJIvADChBSZWdp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 165) = "c3RyYXRpb25JbmZvEhEKCXVzZXJfbmFtZRgBIAEoCRITCgtkaXNwbGF5X2tl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 166) = "eRgCIAEoCRIUCgxkaXNwbGF5X25hbWUYAyABKAkSFwoPZXhwaXJhdGlvbl9k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 167) = "YXRlGAQgASgDEhYKDmFjdGl2YXRpb25fa2V5GAUgASgJEjQKDGxpY2Vuc2Vf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 168) = "dHlwZRgGIAEoDjIeLnJlZ2lzdHJhdGlvbi5jb3JlLkxpY2Vuc2VUeXBlEhkK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 169) = "EXJlZ2lzdHJhdGlvbl9kYXRlGAcgASgDEi4KCXNlYXRfdHlwZRgIIAEoDjIb";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 170) = "LnJlZ2lzdHJhdGlvbi5jb3JlLlNlYXRUeXBlEiUKHWxhdGVzdF9hdmFpbGFi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 171) = "bGVfYnVpbGRfbnVtYmVyGAkgASgNEiAKGGxhdGVzdF9hdmFpbGFibGVfdmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 172) = "c2lvbhgKIAEoCRIsCiRoYXNfd29yc2hpcF9ob3VzZV9tZWRpYV9zdWJzY3Jp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 173) = "cHRpb24YCyABKAgSIwobbWFpbnRlbmFuY2VfZXhwaXJhdGlvbl9kYXRlGAwg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 174) = "ASgDEjAKKG5vbl9leHRlbmRlZF9tYWludGVuYW5jZV9leHBpcmF0aW9uX2Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 175) = "dGUYDSABKAMSHgoWaXNfYXV0b19yZW5ld2FsX2FjdGl2ZRgOIAEoCCLnAQoQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 176) = "QnVpbGRJbmZvcm1hdGlvbhIUCgxidWlsZF9udW1iZXIYASABKAUSDwoHdmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 177) = "c2lvbhgCIAEoCRIWCg5taW5fb3NfdmVyc2lvbhgDIAEoCRIUCgxyZWxlYXNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 178) = "X2RhdGUYBCABKAMSGQoRcmVnaXN0cmF0aW9uX2RhdGUYBSABKAMSFQoNZG93";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 179) = "bmxvYWRfc2l6ZRgGIAEoAxIUCgxkb3dubG9hZF91cmwYByABKAkSDwoHY2hh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 180) = "bm5lbBgIIAEoCRIPCgdpc19iZXRhGAkgASgIEhQKDGlzX2F2YWlsYWJsZRgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 181) = "IAEoCCKUAQoFQWxlcnQSMAoKYWxlcnRfdHlwZRgBIAEoDjIcLnJlZ2lzdHJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 182) = "dGlvbi5jb3JlLkFsZXJ0VHlwZRINCgV0aXRsZRgCIAEoCRI5Cgxjb250ZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 183) = "X3R5cGUYAyABKA4yIy5yZWdpc3RyYXRpb24uY29yZS5BbGVydENvbnRlbnRU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 184) = "eXBlEg8KB2NvbnRlbnQYBCABKAkiUAoNVG9rZW5NZXRhZGF0YRIUCgxhY2Nl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 185) = "c3NfdG9rZW4YASABKAkSFQoNcmVmcmVzaF90b2tlbhgCIAEoCRISCgpleHBp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 186) = "cmVzX2F0GAMgASgDIp8BChBTdWJzY3JpcHRpb25JbmZvEhkKEW9yZ2FuaXph";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 187) = "dGlvbl9uYW1lGAEgASgJEkkKF3Byb2NvbnRlbnRfbGljZW5zZV90eXBlGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 188) = "ASgOMigucmVnaXN0cmF0aW9uLmNvcmUuUHJvQ29udGVudExpY2Vuc2VUeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 189) = "EiUKHXByb2NvbnRlbnRfbGljZW5zZV9leHBpcmF0aW9uGAMgASgDIicKDERv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 190) = "d25sb2FkTGluaxIKCgJpZBgBIAEoCRILCgN1cmwYAiABKAkidAoGQmlibGVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 191) = "Ei0KC2ZyZWVfYmlibGVzGAEgAygLMhgucmVnaXN0cmF0aW9uLmNvcmUuQmli";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 192) = "bGUSOwoQcHVyY2hhc2VkX2JpYmxlcxgCIAMoCzIhLnJlZ2lzdHJhdGlvbi5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 193) = "b3JlLlB1cmNoYXNlZEJpYmxlIpgBCgxOb3RpZmljYXRpb24SCgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 194) = "KAkSDgoGaGVhZGVyGAIgASgJEgwKBGJvZHkYAyABKAkSCwoDdXJsGAQgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 195) = "EhgKEHVybF9kaXNwbGF5X3RleHQYBSABKAkSEgoKY3JlYXRlZF9hdBgGIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 196) = "BBISCgpleHBpcmVzX2F0GAcgASgEEg8KB2lzX3JlYWQYCCABKAgiRwoNTm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 197) = "aWZpY2F0aW9ucxI2Cg1ub3RpZmljYXRpb25zGAEgAygLMh8ucmVnaXN0cmF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 198) = "aW9uLmNvcmUuTm90aWZpY2F0aW9uImEKFU5vdGlmaWNhdGlvbkRhdGFTdG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 199) = "ZRI2Cg1ub3RpZmljYXRpb25zGAEgAygLMh8ucmVnaXN0cmF0aW9uLmNvcmUu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 200) = "Tm90aWZpY2F0aW9uEhAKCHJlYWRfaWRzGAIgAygJKpQDCgZTdGF0dXMSCwoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 201) = "U3VjY2VzcxAAEhIKDkV4cGlyZWRMaWNlbnNlEAESFgoSRGVhY3RpdmF0ZWRM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 202) = "aWNlbnNlEAISEwoPRGlzYWJsZWRMaWNlbnNlEAMSCwoHTm9TZWF0cxAEEgwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 203) = "CE5vQ29waWVzEAUSEgoOTWlzc2luZ0xpY2Vuc2UQBhITCg9UaW1lRGlzY3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 204) = "cGFuY3kQBxIQCgxCaWJsZU1pc3NpbmcQCBIVChFCaWJsZU5vdFB1cmNoYXNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 205) = "ZBAJEhoKFkJpYmxlQWN0aXZhdGlvbk1pc3NpbmcQChIUChBCaWJsZURlYWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 206) = "aXZhdGVkEAsSEAoMTmV0d29ya0Vycm9yEAwSCwoHSU9FcnJvchANEhIKDk5v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 207) = "dEluaXRpYWxpemVkEA4SEAoMVG9rZW5FeHBpcmVkEA8SEAoMVG9rZW5JbnZh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 208) = "bGlkEBASGQoVQWN0aXZhdGlvbkNvZGVFeHBpcmVkEBESGQoVQWN0aXZhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 209) = "bkNvZGVJbnZhbGlkEBISEAoMVW5rbm93bkVycm9yEBMqMQoIU2VhdFR5cGUS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 210) = "DAoISW5hY3RpdmUQABIJCgVCYXNpYxABEgwKCEFkdmFuY2VkEAIqPgoLTGlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 211) = "ZW5zZVR5cGUSCQoFVHJpYWwQABIKCgZSZW50YWwQARIMCghTdGFuZGFyZBAC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 212) = "EgoKBkNhbXB1cxADKikKDVVwZGF0ZUNoYW5uZWwSCAoEQmV0YRAAEg4KClBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 213) = "b2R1Y3Rpb24QASovCglBbGVydFR5cGUSCAoESW5mbxAAEgsKB0ZlYXR1cmUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 214) = "ARILCgdXYXJuaW5nEAIqUQoQQWxlcnRDb250ZW50VHlwZRIPCgtDb250ZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 215) = "VHlwZRAAEggKBFRleHQQARIQCgxJbnRlcm5hbExpbmsQAhIQCgxFeHRlcm5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 216) = "bExpbmsQAyo8Cg9SZWFkVG9rZW5TdGF0dXMSFAoQUmVhZFRva2VuU3VjY2Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 217) = "cxAAEhMKD1Rva2VuTm90UHJlc2VudBABKi4KFVByb0NvbnRlbnRMaWNlbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 218) = "VHlwZRIICgRGcmVlEAASCwoHUHJlbWl1bRABKqECChFQb3B1cEFsZXJ0TWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 219) = "c2FnZRIQCgxOb1BvcHVwQWxlcnQQABIRCg1TZWF0QWN0aXZhdGVkEAESEwoP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 220) = "Tm9TZWF0QWN0aXZhdGVkEAISFgoSTm9MaWNlbnNlQWN0aXZhdGVkEAMSJAog";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 221) = "TGVnYWN5TGljZW5zZVByb0NvbnRlbnRBY3RpdmF0ZWQQBBIcChhGaXJzdExh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 222) = "dW5jaExlZ2FjeUxpY2Vuc2UQBRISCg5GdWxseVNpZ25lZE91dBAGEi4KKkZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 223) = "cnN0TGF1bmNoU2lnbmVkSW5Ob1N1YnNjcmlwdGlvbk5vTGljZW5zZRAHEjIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 224) = "LkZpcnN0TGF1bmNoU2lnbmVkSW5Ob1N1YnNjcmlwdGlvbkxlZ2FjeUxpY2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 225) = "c2UQCCo3Cg1CYW5uZXJNZXNzYWdlEgwKCE5vQmFubmVyEAASGAoUQWN0aXZh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 226) = "dGVQcm9QcmVzZW50ZXIQASqpBAoSQ2xpZW50QWxlcnRNZXNzYWdlEgsKB05v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 227) = "QWxlcnQQABIYChRFeHBpcmVkTGljZW5zZUxlZ2FjeRABEhcKE0V4cGlyZWRT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 228) = "dWJzY3JpcHRpb24QAhISCg5JbnZhbGlkTGljZW5zZRADEhEKDU5vU2VhdHNM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 229) = "ZWdhY3kQBBIXChNOb1NlYXRzU3Vic2NyaXB0aW9uEAUSHwobU2VhdERlYWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 230) = "aXZhdGVkU3Vic2NyaXB0aW9uEAYSGAoUVGltZURpc2NyZXBhbmN5QWxlcnQQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 231) = "BxINCglOb05ldHdvcmsQCBIRCg1Ob0JpYmxlQ29waWVzEAkSFQoRQmlibGVN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 232) = "aXNzaW5nQWxlcnQQChIbChdCaWJsZU5vdFB1cmNoYXNlZExlZ2FjeRALEiEK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 233) = "HUJpYmxlTm90UHVyY2hhc2VkU3Vic2NyaXB0aW9uEAwSJQohVW5zdWNjZXNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 234) = "ZnVsQmlibGVBY3RpdmF0aW9uTGVnYWN5EA0SKwonVW5zdWNjZXNzZnVsQmli";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 235) = "bGVBY3RpdmF0aW9uU3Vic2NyaXB0aW9uEA4SEAoMSU9FcnJvckFsZXJ0EA8S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 236) = "FAoQQ29kZUV4cGlyZWRBbGVydBAQEhQKEENvZGVJbnZhbGlkQWxlcnQQERIa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 237) = "ChZVbnN1Y2Nlc3NmdWxBY3RpdmF0aW9uEBISHwobRGV2aWNlU2lnbmVkT3V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 238) = "U3Vic2NyaXB0aW9uEBMSEAoMVW5rbm93bkFsZXJ0EBRCS6oCMVByby5TZXJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 239) = "YWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YS5SZWdpc3RyYXRpb266AhRS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray241<string>, string>(ref buffer, 240) = "VkRhdGFfUmVnaXN0cmF0aW9uX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray241<string>, string>(in buffer, 241))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[11]
		{
			typeof(Status),
			typeof(SeatType),
			typeof(LicenseType),
			typeof(UpdateChannel),
			typeof(AlertType),
			typeof(AlertContentType),
			typeof(ReadTokenStatus),
			typeof(ProContentLicenseType),
			typeof(PopupAlertMessage),
			typeof(BannerMessage),
			typeof(ClientAlertMessage)
		}, null, new GeneratedClrTypeInfo[62]
		{
			new GeneratedClrTypeInfo(typeof(Request), Request.Parser, new string[22]
			{
				"Register", "Unregister", "ChangeSeatType", "GetBibles", "ActivateBible", "DeactivateBible", "DownloadBible", "RegistrationData", "ProductInformation", "GetUpgradesAvailable",
				"DownloadNewVersion", "Refresh", "ActivateLink", "UpdateToken", "OldTokenData", "Signout", "GetActivateCode", "NotificationData", "MarkNotificationsRead", "GetLicenseState",
				"RefreshUserAuthTokens", "RefreshAccessToken"
			}, new string[1] { "Request" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(Callback), Callback.Parser, new string[19]
			{
				"SetWatermark", "BibleDownloadProgress", "HardExit", "ReadRegistrationData", "WriteRegistrationData", "GetProductInformation", "Log", "UpgradesAvailable", "DownloadProgress", "Alerts",
				"ShowExpirationDialog", "ReadOldToken", "VerificationComplete", "SetClientInfo", "GetActivateCodeComplete", "ReadNotificationData", "WriteNotificationData", "NotificationCallback", "LicenseState"
			}, new string[1] { "Callback" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(Register), Register.Parser, new string[5] { "UserName", "RegistrationKey", "DisplayName", "SeatType", "Channel" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActivateLink), ActivateLink.Parser, new string[1] { "Identifier" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Unregister), Unregister.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Signout), Signout.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ChangeSeatType), ChangeSeatType.Parser, new string[2] { "SeatType", "Channel" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(GetBibles), GetBibles.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActivateBible), ActivateBible.Parser, new string[1] { "BibleId" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DeactivateBible), DeactivateBible.Parser, new string[1] { "BibleId" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DownloadBible), DownloadBible.Parser, new string[2] { "BibleId", "Filename" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RegistrationData), RegistrationData.Parser, new string[2] { "Data", "Channel" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ProductInformation), ProductInformation.Parser, new string[6] { "ProductName", "MajorVersion", "MinorVersion", "PatchVersion", "BuildNumber", "BuildDate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(GetAvailableVersion), GetAvailableVersion.Parser, new string[4] { "IncludeNotes", "Channel", "Format", "UserInitiated" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DownloadNewVersion), DownloadNewVersion.Parser, new string[2] { "Url", "Filename" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Refresh), Refresh.Parser, new string[1] { "Channel" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdateToken), UpdateToken.Parser, new string[1] { "TokenMetadata" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(OldTokenData), OldTokenData.Parser, new string[2] { "Status", "Token" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Token), Token.Parser, new string[1] { "TokenMetadata" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(GetActivateCode), GetActivateCode.Parser, new string[2] { "SeatBucketId", "OrganizationUuid" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NotificationData), NotificationData.Parser, new string[1] { "Data" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MarkNotificationsRead), MarkNotificationsRead.Parser, new string[1] { "Id" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(GetLicenseState), GetLicenseState.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RefreshUserAuthTokens), RefreshUserAuthTokens.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RefreshAccessToken), RefreshAccessToken.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SetWatermark), SetWatermark.Parser, new string[2] { "IsRegistered", "ActiveSeat" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ChangeSeatTypeComplete), ChangeSeatTypeComplete.Parser, new string[4] { "Result", "AvailableSeats", "TotalSeats", "SeatType" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(BibleDownloadProgress), BibleDownloadProgress.Parser, new string[7] { "Status", "Complete", "Progress", "BibleId", "FileName", "DownloadLink", "ClientAlert" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(HardExit), HardExit.Parser, new string[1] { "Reason" }, null, new Type[1] { typeof(HardExit.Types.Reason) }, null, null),
			new GeneratedClrTypeInfo(typeof(ReadRegistrationData), ReadRegistrationData.Parser, new string[2] { "Fingerprint", "Identifier" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ReadOldToken), ReadOldToken.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WriteRegistrationData), WriteRegistrationData.Parser, new string[1] { "Data" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(GetProductInformation), GetProductInformation.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Log), Log.Parser, new string[2] { "Level", "Message" }, null, new Type[1] { typeof(Log.Types.Level) }, null, null),
			new GeneratedClrTypeInfo(typeof(UpgradesAvailable), UpgradesAvailable.Parser, new string[6] { "Status", "IsNonProductionActive", "ActiveChannel", "ReleaseNotes", "Upgrades", "ClientAlert" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DownloadProgress), DownloadProgress.Parser, new string[4] { "Status", "Complete", "Progress", "ClientAlert" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Alerts), Alerts.Parser, new string[1] { "Alerts_" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ShowExpirationDialog), ShowExpirationDialog.Parser, new string[1] { "Days" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(VerificationComplete), VerificationComplete.Parser, new string[9] { "Result", "License", "Bibles", "Token", "SubscriptionInfo", "Alert", "Banner", "ClientAlert", "FullyLaunched" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SetClientInfo), SetClientInfo.Parser, new string[2] { "ClientId", "ClientSecret" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActivateCodeComplete), ActivateCodeComplete.Parser, new string[2] { "Error", "Success" }, new string[1] { "Status" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(ActivateCodeComplete.Types.Error), ActivateCodeComplete.Types.Error.Parser, new string[2] { "Error_", "Description" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ActivateCodeComplete.Types.Success), ActivateCodeComplete.Types.Success.Parser, new string[2] { "ActivationCode", "Expiration" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(ReadNotificationData), ReadNotificationData.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(WriteNotificationData), WriteNotificationData.Parser, new string[1] { "Data" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NotificationCallback), NotificationCallback.Parser, new string[1] { "Notifications" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LicenseState), LicenseState.Parser, new string[4] { "HardwareId", "Fingerprint", "IsRegistered", "ActiveSeat" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Seats), Seats.Parser, new string[2] { "Basic", "Advanced" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SupplementalInformation), SupplementalInformation.Parser, new string[1] { "DownloadLink" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Bible), Bible.Parser, new string[9] { "Id", "Name", "Language", "Publisher", "Copyright", "DisplayAbbreviation", "InternalAbbreviation", "Version", "Info" }, new string[1] { "Additional" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(PurchasedBible), PurchasedBible.Parser, new string[2] { "Metadata", "LicensingInfo" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LicenseInfo), LicenseInfo.Parser, new string[4] { "RegistrationInfo", "AvailableSeats", "TotalSeats", "Legacy" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LicensingInfo), LicensingInfo.Parser, new string[4] { "AvailableCopies", "TotalCopies", "IsActiveLocally", "OtherActiveCopies" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ActiveCopy), ActiveCopy.Parser, new string[2] { "DisplayName", "Hostname" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RegistrationInfo), RegistrationInfo.Parser, new string[14]
			{
				"UserName", "DisplayKey", "DisplayName", "ExpirationDate", "ActivationKey", "LicenseType", "RegistrationDate", "SeatType", "LatestAvailableBuildNumber", "LatestAvailableVersion",
				"HasWorshipHouseMediaSubscription", "MaintenanceExpirationDate", "NonExtendedMaintenanceExpirationDate", "IsAutoRenewalActive"
			}, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(BuildInformation), BuildInformation.Parser, new string[10] { "BuildNumber", "Version", "MinOsVersion", "ReleaseDate", "RegistrationDate", "DownloadSize", "DownloadUrl", "Channel", "IsBeta", "IsAvailable" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Alert), Alert.Parser, new string[4] { "AlertType", "Title", "ContentType", "Content" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TokenMetadata), TokenMetadata.Parser, new string[3] { "AccessToken", "RefreshToken", "ExpiresAt" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SubscriptionInfo), SubscriptionInfo.Parser, new string[3] { "OrganizationName", "ProcontentLicenseType", "ProcontentLicenseExpiration" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DownloadLink), DownloadLink.Parser, new string[2] { "Id", "Url" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Bibles), Bibles.Parser, new string[2] { "FreeBibles", "PurchasedBibles" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Notification), Notification.Parser, new string[8] { "Id", "Header", "Body", "Url", "UrlDisplayText", "CreatedAt", "ExpiresAt", "IsRead" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Notifications), Notifications.Parser, new string[1] { "Notifications_" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NotificationDataStore), NotificationDataStore.Parser, new string[2] { "Notifications", "ReadIds" }, null, null, null, null)
		}));
	}
}
