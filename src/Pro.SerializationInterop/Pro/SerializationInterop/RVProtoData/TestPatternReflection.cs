using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class TestPatternReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static TestPatternReflection()
	{
		_003C_003Ey__InlineArray110<string> buffer = default(_003C_003Ey__InlineArray110<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 0) = "ChF0ZXN0UGF0dGVybi5wcm90bxIHcnYuZGF0YRoLY29sb3IucHJvdG8aE2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 1) = "c3RvbU9wdGlvbnMucHJvdG8aCmZvbnQucHJvdG8aCnV1aWQucHJvdG8aCXVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 2) = "bC5wcm90byKQBQoLVGVzdFBhdHRlcm4SJwoEdHlwZRgBIAEoDjIZLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 3) = "dGEuVGVzdFBhdHRlcm4uVHlwZRI0CgpibGVuZF9ncmlkGAIgASgLMh4ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 4) = "ZGF0YS5UZXN0UGF0dGVybi5CbGVuZEdyaWRIABI4CgxjdXN0b21fY29sb3IY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 5) = "AyABKAsyIC5ydi5kYXRhLlRlc3RQYXR0ZXJuLkN1c3RvbUNvbG9ySAASOAoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 6) = "aW50ZW5zaXR5GAQgASgLMiMucnYuZGF0YS5UZXN0UGF0dGVybi5JbnRlbnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 7) = "dHlDb2xvckgAGnUKCUJsZW5kR3JpZBIRCglkcmF3X2dyaWQYASABKAgSFAoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 8) = "ZHJhd19jaXJjbGVzGAIgASgIEhIKCmRyYXdfbGluZXMYAyABKAgSFQoNaW52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 9) = "ZXJ0X2NvbG9ycxgEIAEoCBIUCgxncmlkX3NwYWNpbmcYBSABKAEaLAoLQ3Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 10) = "dG9tQ29sb3ISHQoFY29sb3IYASABKAsyDi5ydi5kYXRhLkNvbG9yGiMKDklu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 11) = "dGVuc2l0eUNvbG9yEhEKCWludGVuc2l0eRgBIAEoASLOAQoEVHlwZRIQCgxU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 12) = "WVBFX1VOS05PV04QABITCg9UWVBFX0JMRU5EX0dSSUQQARITCg9UWVBFX0NP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 13) = "TE9SX0JBUlMQAhIOCgpUWVBFX0ZPQ1VTEAMSEwoPVFlQRV9HUkFZX1NDQUxF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 14) = "EAQSFAoQVFlQRV9CTEFDS19DT0xPUhAFEhQKEFRZUEVfV0hJVEVfQ09MT1IQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 15) = "BhIVChFUWVBFX0NVU1RPTV9DT0xPUhAHEg0KCVRZUEVfVEVYVBAIEhMKD1RZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 16) = "UEVfVklERU9fU1lOQxAJQhMKEVBhdHRlcm5Qcm9wZXJ0aWVzIsoLChVUZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 17) = "UGF0dGVybkRlZmluaXRpb24SGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 18) = "RBIdChVuYW1lX2xvY2FsaXphdGlvbl9rZXkYAiABKAkSOwoKcHJvcGVydGll";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 19) = "cxgDIAMoCzInLnJ2LmRhdGEuVGVzdFBhdHRlcm5EZWZpbml0aW9uLlByb3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 20) = "cnR5EhsKE3Nob3dfZGVsYXlfc2V0dGluZ3MYBCABKAgSEgoKaXNfZGVmYXVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 21) = "dBgFIAEoCBprCg1Db2xvclByb3BlcnR5Eh0KBXZhbHVlGAEgASgLMg4ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 22) = "ZGF0YS5Db2xvchITCgthbGxvd19hbHBoYRgCIAEoCBImCg5kZWZhdWx0X2Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 23) = "bG9ycxgDIAMoCzIOLnJ2LmRhdGEuQ29sb3Ia9QEKDkRvdWJsZVByb3BlcnR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 24) = "Eg0KBXZhbHVlGAEgASgBEgsKA21pbhgCIAEoARILCgNtYXgYAyABKAESDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 25) = "c3RlcBgEIAEoARINCgV1bml0cxgFIAEoCRJICgh2aWV3VHlwZRgGIAEoDjI2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 26) = "LnJ2LmRhdGEuVGVzdFBhdHRlcm5EZWZpbml0aW9uLkRvdWJsZVByb3BlcnR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 27) = "LlZpZXdUeXBlIlMKCFZpZXdUeXBlEhUKEVZJRVdfVFlQRV9TVEVQUEVSEAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 28) = "FAoQVklFV19UWVBFX1NMSURFUhABEhoKFlZJRVdfVFlQRV9TUEVFRF9TTElE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 29) = "RVIQAhpFCgtJbnRQcm9wZXJ0eRINCgV2YWx1ZRgBIAEoBRILCgNtaW4YAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 30) = "KAUSCwoDbWF4GAMgASgFEg0KBXVuaXRzGAUgASgJGmQKDEJvb2xQcm9wZXJ0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 31) = "eRINCgV2YWx1ZRgBIAEoCBJFChRkZXBlbmRlbnRfcHJvcGVydGllcxgCIAMo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 32) = "CzInLnJ2LmRhdGEuVGVzdFBhdHRlcm5EZWZpbml0aW9uLlByb3BlcnR5GkUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 33) = "DlN0cmluZ1Byb3BlcnR5Eg0KBXZhbHVlGAEgASgJEhEKCW1pbl9jaGFycxgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 34) = "IAEoBRIRCgltYXhfY2hhcnMYAyABKAUaKwoMRm9udFByb3BlcnR5EhsKBGZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 35) = "bnQYASABKAsyDS5ydi5kYXRhLkZvbnQaSwoQU2VsZWN0b3JQcm9wZXJ0eRIW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 36) = "Cg5zZWxlY3RlZF9pbmRleBgBIAEoBRIfChd2YWx1ZV9sb2NhbGl6YXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 37) = "a2V5cxgCIAMoCRqzBAoIUHJvcGVydHkSHQoVbmFtZV9sb2NhbGl6YXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 38) = "a2V5GAEgASgJEkYKDmNvbG9yX3Byb3BlcnR5GAMgASgLMiwucnYuZGF0YS5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 39) = "ZXN0UGF0dGVybkRlZmluaXRpb24uQ29sb3JQcm9wZXJ0eUgAEkgKD2RvdWJs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 40) = "ZV9wcm9wZXJ0eRgEIAEoCzItLnJ2LmRhdGEuVGVzdFBhdHRlcm5EZWZpbml0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 41) = "aW9uLkRvdWJsZVByb3BlcnR5SAASQgoMaW50X3Byb3BlcnR5GAUgASgLMiou";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 42) = "cnYuZGF0YS5UZXN0UGF0dGVybkRlZmluaXRpb24uSW50UHJvcGVydHlIABJE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 43) = "Cg1ib29sX3Byb3BlcnR5GAYgASgLMisucnYuZGF0YS5UZXN0UGF0dGVybkRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 44) = "ZmluaXRpb24uQm9vbFByb3BlcnR5SAASSAoPc3RyaW5nX3Byb3BlcnR5GAcg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 45) = "ASgLMi0ucnYuZGF0YS5UZXN0UGF0dGVybkRlZmluaXRpb24uU3RyaW5nUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 46) = "cGVydHlIABJECg1mb250X3Byb3BlcnR5GAggASgLMisucnYuZGF0YS5UZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 47) = "UGF0dGVybkRlZmluaXRpb24uRm9udFByb3BlcnR5SAASTAoRc2VsZWN0b3Jf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 48) = "cHJvcGVydHkYCSABKAsyLy5ydi5kYXRhLlRlc3RQYXR0ZXJuRGVmaW5pdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 49) = "bi5TZWxlY3RvclByb3BlcnR5SABCDgoMUHJvcGVydHlUeXBlIoADChlUZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 50) = "UGF0dGVyblJlbmRlclNldHRpbmdzEi8KB3BhdHRlcm4YASABKAsyHi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 51) = "YXRhLlRlc3RQYXR0ZXJuRGVmaW5pdGlvbhITCgtzY3JlZW5fbmFtZRgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 52) = "CRI6CgdvdXRwdXRzGAQgAygLMikucnYuZGF0YS5UZXN0UGF0dGVyblJlbmRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 53) = "clNldHRpbmdzLk91dHB1dBIkCglsb2dvX3R5cGUYBSABKA4yES5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 54) = "LkxvZ29UeXBlEhEKCWxvZ29fZmlsZRgGIAEoCRIUCgxyZW5kZXJfd2lkdGgY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 55) = "ByABKAUSFQoNcmVuZGVyX2hlaWdodBgIIAEoBRIUCgxlbmFibGVfYXVkaW8Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 56) = "CSABKAgaXwoGT3V0cHV0EgkKAXgYASABKAUSCQoBeRgCIAEoBRINCgV3aWR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 57) = "aBgDIAEoBRIOCgZoZWlnaHQYBCABKAUSDAoEbmFtZRgFIAEoCRISCgpmcmFt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 58) = "ZV9yYXRlGAYgASgBSgQIAhADItcDChBUZXN0UGF0dGVyblN0YXRlEi8KB3Bh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 59) = "dHRlcm4YASABKAsyHi5ydi5kYXRhLlRlc3RQYXR0ZXJuRGVmaW5pdGlvbhIU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 60) = "CgxzaG93X3BhdHRlcm4YAiABKAgSQwoQZGlzcGxheV9sb2NhdGlvbhgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 61) = "DjIpLnJ2LmRhdGEuVGVzdFBhdHRlcm5TdGF0ZS5EaXNwbGF5TG9jYXRpb24S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 62) = "JgoPc3BlY2lmaWNfc2NyZWVuGAQgASgLMg0ucnYuZGF0YS5VVUlEEhgKEGlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 63) = "ZW50aWZ5X3NjcmVlbnMYBSABKAgSJAoJbG9nb190eXBlGAYgASgOMhEucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 64) = "ZGF0YS5Mb2dvVHlwZRIoChJ1c2VyX2xvZ29fbG9jYXRpb24YByABKAsyDC5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 65) = "di5kYXRhLlVSTCKkAQoPRGlzcGxheUxvY2F0aW9uEiAKHERJU1BMQVlfTE9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 66) = "QVRJT05fQUxMX1NDUkVFTlMQABIlCiFESVNQTEFZX0xPQ0FUSU9OX0FVRElF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 67) = "TkNFX1NDUkVFTlMQARIiCh5ESVNQTEFZX0xPQ0FUSU9OX1NUQUdFX1NDUkVF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 68) = "TlMQAhIkCiBESVNQTEFZX0xPQ0FUSU9OX1NQRUNJRklDX1NDUkVFThADIoEN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 69) = "ChNUZXN0UGF0dGVybkRvY3VtZW50EkYKBXN0YXRlGAEgASgLMjEucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 70) = "YS5UZXN0UGF0dGVybkRvY3VtZW50LlRlc3RQYXR0ZXJuU3RhdGVEYXRhQgSg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 71) = "hhkBEj4KCHBhdHRlcm5zGAIgAygLMiwucnYuZGF0YS5UZXN0UGF0dGVybkRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 72) = "Y3VtZW50LlRlc3RQYXR0ZXJuRGF0YRrZAgoUVGVzdFBhdHRlcm5TdGF0ZURh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 73) = "dGESLAoPdGVzdF9wYXR0ZXJuX2lkGAEgASgLMg0ucnYuZGF0YS5VVUlEQgSg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 74) = "hhkBEjAKInRlc3RfcGF0dGVybl9uYW1lX2xvY2FsaXphdGlvbl9rZXkYAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 75) = "KAlCBKiGGQESQwoQZGlzcGxheV9sb2NhdGlvbhgDIAEoDjIpLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 76) = "VGVzdFBhdHRlcm5TdGF0ZS5EaXNwbGF5TG9jYXRpb24SLAoPc3BlY2lmaWNf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 77) = "c2NyZWVuGAQgASgLMg0ucnYuZGF0YS5VVUlEQgSghhkBEhgKEGlkZW50aWZ5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 78) = "X3NjcmVlbnMYBSABKAgSJAoJbG9nb190eXBlGAYgASgOMhEucnYuZGF0YS5M";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 79) = "b2dvVHlwZRIuChJ1c2VyX2xvZ29fbG9jYXRpb24YByABKAsyDC5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 80) = "LlVSTEIEoIYZARqFCQoPVGVzdFBhdHRlcm5EYXRhEhsKBHV1aWQYASABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 81) = "DS5ydi5kYXRhLlVVSUQSHQoVbmFtZV9sb2NhbGl6YXRpb25fa2V5GAIgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 82) = "EkkKCnByb3BlcnRpZXMYAyADKAsyNS5ydi5kYXRhLlRlc3RQYXR0ZXJuRG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 83) = "dW1lbnQuVGVzdFBhdHRlcm5EYXRhLlByb3BlcnR5Gi4KDUNvbG9yUHJvcGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 84) = "dHkSHQoFdmFsdWUYASABKAsyDi5ydi5kYXRhLkNvbG9yGh8KDkRvdWJsZVBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 85) = "b3BlcnR5Eg0KBXZhbHVlGAEgASgBGhwKC0ludFByb3BlcnR5Eg0KBXZhbHVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 86) = "GAEgASgFGnIKDEJvb2xQcm9wZXJ0eRINCgV2YWx1ZRgBIAEoCBJTChRkZXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 87) = "bmRlbnRfcHJvcGVydGllcxgCIAMoCzI1LnJ2LmRhdGEuVGVzdFBhdHRlcm5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 88) = "b2N1bWVudC5UZXN0UGF0dGVybkRhdGEuUHJvcGVydHkaHwoOU3RyaW5nUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 89) = "cGVydHkSDQoFdmFsdWUYASABKAkaLAoMRm9udFByb3BlcnR5EhwKBXZhbHVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 90) = "GAEgASgLMg0ucnYuZGF0YS5Gb250GiEKEFNlbGVjdG9yUHJvcGVydHkSDQoF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 91) = "dmFsdWUYASABKAUalQUKCFByb3BlcnR5Eh0KFW5hbWVfbG9jYWxpemF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 92) = "X2tleRgBIAEoCRJUCg5jb2xvcl9wcm9wZXJ0eRgCIAEoCzI6LnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 93) = "VGVzdFBhdHRlcm5Eb2N1bWVudC5UZXN0UGF0dGVybkRhdGEuQ29sb3JQcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 94) = "ZXJ0eUgAElYKD2RvdWJsZV9wcm9wZXJ0eRgDIAEoCzI7LnJ2LmRhdGEuVGVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 95) = "dFBhdHRlcm5Eb2N1bWVudC5UZXN0UGF0dGVybkRhdGEuRG91YmxlUHJvcGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 96) = "dHlIABJQCgxpbnRfcHJvcGVydHkYBCABKAsyOC5ydi5kYXRhLlRlc3RQYXR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 97) = "ZXJuRG9jdW1lbnQuVGVzdFBhdHRlcm5EYXRhLkludFByb3BlcnR5SAASUgoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 98) = "Ym9vbF9wcm9wZXJ0eRgFIAEoCzI5LnJ2LmRhdGEuVGVzdFBhdHRlcm5Eb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 99) = "bWVudC5UZXN0UGF0dGVybkRhdGEuQm9vbFByb3BlcnR5SAASVgoPc3RyaW5n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 100) = "X3Byb3BlcnR5GAYgASgLMjsucnYuZGF0YS5UZXN0UGF0dGVybkRvY3VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 101) = "LlRlc3RQYXR0ZXJuRGF0YS5TdHJpbmdQcm9wZXJ0eUgAElIKDWZvbnRfcHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 102) = "cGVydHkYByABKAsyOS5ydi5kYXRhLlRlc3RQYXR0ZXJuRG9jdW1lbnQuVGVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 103) = "dFBhdHRlcm5EYXRhLkZvbnRQcm9wZXJ0eUgAEloKEXNlbGVjdG9yX3Byb3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 104) = "cnR5GAggASgLMj0ucnYuZGF0YS5UZXN0UGF0dGVybkRvY3VtZW50LlRlc3RQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 105) = "YXR0ZXJuRGF0YS5TZWxlY3RvclByb3BlcnR5SABCDgoMUHJvcGVydHlUeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 106) = "Kk4KCExvZ29UeXBlEhIKDkxPR09fVFlQRV9OT05FEAASGgoWTE9HT19UWVBF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 107) = "X1BST1BSRVNFTlRFUhABEhIKDkxPR09fVFlQRV9VU0VSEAJCNPgBAaoCJFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 108) = "by5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray110<string>, string>(ref buffer, 109) = "BnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray110<string>, string>(in buffer, 110))), new FileDescriptor[5]
		{
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			FontReflection.Descriptor,
			UuidReflection.Descriptor,
			UrlReflection.Descriptor
		}, new GeneratedClrTypeInfo(new Type[1] { typeof(LogoType) }, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(TestPattern), TestPattern.Parser, new string[4] { "Type", "BlendGrid", "CustomColor", "Intensity" }, new string[1] { "PatternProperties" }, new Type[1] { typeof(TestPattern.Types.Type) }, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(TestPattern.Types.BlendGrid), TestPattern.Types.BlendGrid.Parser, new string[5] { "DrawGrid", "DrawCircles", "DrawLines", "InvertColors", "GridSpacing" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPattern.Types.CustomColor), TestPattern.Types.CustomColor.Parser, new string[1] { "Color" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPattern.Types.IntensityColor), TestPattern.Types.IntensityColor.Parser, new string[1] { "Intensity" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(TestPatternDefinition), TestPatternDefinition.Parser, new string[5] { "Uuid", "NameLocalizationKey", "Properties", "ShowDelaySettings", "IsDefault" }, null, null, null, new GeneratedClrTypeInfo[8]
			{
				new GeneratedClrTypeInfo(typeof(TestPatternDefinition.Types.ColorProperty), TestPatternDefinition.Types.ColorProperty.Parser, new string[3] { "Value", "AllowAlpha", "DefaultColors" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternDefinition.Types.DoubleProperty), TestPatternDefinition.Types.DoubleProperty.Parser, new string[6] { "Value", "Min", "Max", "Step", "Units", "ViewType" }, null, new Type[1] { typeof(TestPatternDefinition.Types.DoubleProperty.Types.ViewType) }, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternDefinition.Types.IntProperty), TestPatternDefinition.Types.IntProperty.Parser, new string[4] { "Value", "Min", "Max", "Units" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternDefinition.Types.BoolProperty), TestPatternDefinition.Types.BoolProperty.Parser, new string[2] { "Value", "DependentProperties" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternDefinition.Types.StringProperty), TestPatternDefinition.Types.StringProperty.Parser, new string[3] { "Value", "MinChars", "MaxChars" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternDefinition.Types.FontProperty), TestPatternDefinition.Types.FontProperty.Parser, new string[1] { "Font" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternDefinition.Types.SelectorProperty), TestPatternDefinition.Types.SelectorProperty.Parser, new string[2] { "SelectedIndex", "ValueLocalizationKeys" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternDefinition.Types.Property), TestPatternDefinition.Types.Property.Parser, new string[8] { "NameLocalizationKey", "ColorProperty", "DoubleProperty", "IntProperty", "BoolProperty", "StringProperty", "FontProperty", "SelectorProperty" }, new string[1] { "PropertyType" }, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(TestPatternRenderSettings), TestPatternRenderSettings.Parser, new string[8] { "Pattern", "ScreenName", "Outputs", "LogoType", "LogoFile", "RenderWidth", "RenderHeight", "EnableAudio" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(TestPatternRenderSettings.Types.Output), TestPatternRenderSettings.Types.Output.Parser, new string[6] { "X", "Y", "Width", "Height", "Name", "FrameRate" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(TestPatternState), TestPatternState.Parser, new string[7] { "Pattern", "ShowPattern", "DisplayLocation", "SpecificScreen", "IdentifyScreens", "LogoType", "UserLogoLocation" }, null, new Type[1] { typeof(TestPatternState.Types.DisplayLocation) }, null, null),
			new GeneratedClrTypeInfo(typeof(TestPatternDocument), TestPatternDocument.Parser, new string[2] { "State", "Patterns" }, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternStateData), TestPatternDocument.Types.TestPatternStateData.Parser, new string[7] { "TestPatternId", "TestPatternNameLocalizationKey", "DisplayLocation", "SpecificScreen", "IdentifyScreens", "LogoType", "UserLogoLocation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData), TestPatternDocument.Types.TestPatternData.Parser, new string[3] { "Uuid", "NameLocalizationKey", "Properties" }, null, null, null, new GeneratedClrTypeInfo[8]
				{
					new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData.Types.ColorProperty), TestPatternDocument.Types.TestPatternData.Types.ColorProperty.Parser, new string[1] { "Value" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData.Types.DoubleProperty), TestPatternDocument.Types.TestPatternData.Types.DoubleProperty.Parser, new string[1] { "Value" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData.Types.IntProperty), TestPatternDocument.Types.TestPatternData.Types.IntProperty.Parser, new string[1] { "Value" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData.Types.BoolProperty), TestPatternDocument.Types.TestPatternData.Types.BoolProperty.Parser, new string[2] { "Value", "DependentProperties" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData.Types.StringProperty), TestPatternDocument.Types.TestPatternData.Types.StringProperty.Parser, new string[1] { "Value" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData.Types.FontProperty), TestPatternDocument.Types.TestPatternData.Types.FontProperty.Parser, new string[1] { "Value" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData.Types.SelectorProperty), TestPatternDocument.Types.TestPatternData.Types.SelectorProperty.Parser, new string[1] { "Value" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(TestPatternDocument.Types.TestPatternData.Types.Property), TestPatternDocument.Types.TestPatternData.Types.Property.Parser, new string[8] { "NameLocalizationKey", "ColorProperty", "DoubleProperty", "IntProperty", "BoolProperty", "StringProperty", "FontProperty", "SelectorProperty" }, new string[1] { "PropertyType" }, null, null, null)
				})
			})
		}));
	}
}
