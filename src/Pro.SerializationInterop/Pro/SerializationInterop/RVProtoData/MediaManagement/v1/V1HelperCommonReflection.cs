using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

public static class V1HelperCommonReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static V1HelperCommonReflection()
	{
		_003C_003Ey__InlineArray89<string> buffer = default(_003C_003Ey__InlineArray89<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 0) = "ChZ2MS1oZWxwZXItY29tbW9uLnByb3RvEhBoZWxwZXIuY29tbW9uLnYxGg1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 1) = "ZmZlY3RzLnByb3RvGg9hbHBoYVR5cGUucHJvdG8imQEKElByb2R1Y3RJbmZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 2) = "cm1hdGlvbhIUCgxwcm9kdWN0X25hbWUYASABKAkSFQoNbWFqb3JfdmVyc2lv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 3) = "bhgCIAEoCRIVCg1taW5vcl92ZXJzaW9uGAMgASgJEhUKDXBhdGNoX3ZlcnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 4) = "b24YBCABKAkSFAoMYnVpbGRfbnVtYmVyGAUgASgJEhIKCmJ1aWxkX2RhdGUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 5) = "BiABKAMiNgoHVmVyc2lvbhINCgVtYWpvchgBIAEoBRINCgVtaW5vchgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 6) = "BRINCgVwYXRjaBgDIAEoBSJgCg5DcmVhdGlvbk9wdGlvbhIWCg5zaG93X2Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 7) = "cmVjdG9yeRgBIAEoCRIOCgRuYW1lGAIgASgJSAASEQoHc2Vjb25kcxgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 8) = "DUgBQggKBlNvY2tldEIJCgd0aW1lb3V0IoQGChJNZWRpYVJlZmVyZW5jZUlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 9) = "Zm8SQgoKbWVkaWFfaW5mbxgBIAEoCzIuLmhlbHBlci5jb21tb24udjEuTWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 10) = "aWFSZWZlcmVuY2VJbmZvLk1lZGlhSW5mbxJKCg50aHVtYm5haWxfaW5mbxgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 11) = "IAEoCzIyLmhlbHBlci5jb21tb24udjEuTWVkaWFSZWZlcmVuY2VJbmZvLlRo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 12) = "dW1ibmFpbEluZm8avwQKCU1lZGlhSW5mbxILCgN1cmwYASABKAkSDQoFd2lk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 13) = "dGgYAiABKA0SDgoGaGVpZ2h0GAMgASgNEgsKA2ZwcxgEIAEoAhIQCghkdXJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 14) = "dGlvbhgFIAEoAhIaChJudW1fYXVkaW9fY2hhbm5lbHMYBiABKA0SDQoFY29k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 15) = "ZWMYByABKAkSDgoGYXJ0aXN0GAggASgJEg0KBXRpdGxlGAkgASgJEhAKCHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 16) = "dGF0aW9uGAogASgFElAKDGNvbnRlbnRfdHlwZRgLIAEoDjI6LmhlbHBlci5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 17) = "b21tb24udjEuTWVkaWFSZWZlcmVuY2VJbmZvLk1lZGlhSW5mby5Db250ZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 18) = "VHlwZRIZChFoYXNfYWxwaGFfY2hhbm5lbBgMIAEoCBIaChJzdXBwb3J0c19o";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 19) = "d19kZWNvZGUYDSABKAgSUAoMY29sb3JfZm9ybWF0GA4gASgOMjouaGVscGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 20) = "LmNvbW1vbi52MS5NZWRpYVJlZmVyZW5jZUluZm8uTWVkaWFJbmZvLkNvbG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 21) = "Rm9ybWF0Im8KC0NvbnRlbnRUeXBlEhgKFENPTlRFTlRfVFlQRV9VTktOT1dO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 22) = "EAASFgoSQ09OVEVOVF9UWVBFX0FVRElPEAESFgoSQ09OVEVOVF9UWVBFX0lN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 23) = "QUdFEAISFgoSQ09OVEVOVF9UWVBFX1ZJREVPEAMiPwoLQ29sb3JGb3JtYXQS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 24) = "BwoDU0RSEAASEwoPSERSX1JFQzIxMDBfSExHEAESEgoOSERSX1JFQzIxMDBf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 25) = "UFEQAhocCg1UaHVtYm5haWxJbmZvEgsKA3VybBgBIAEoCSKuBAoMUmVxdWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 26) = "dEVycm9yEjYKBGNvZGUYASABKA4yKC5oZWxwZXIuY29tbW9uLnYxLlJlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 27) = "c3RFcnJvci5FcnJvckNvZGUSEwoLZGVzY3JpcHRpb24YAiABKAki0AMKCUVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 28) = "cm9yQ29kZRILCgdVTktOT1dOEAASHQoYQ0FOVF9DUkVBVEVfTUVESUFfRk9M";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 29) = "REVSEMkBEhwKF0NBTlRfQ1JFQVRFX01FVEFfRk9MREVSEMoBEiIKHUNBTlRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 30) = "Q1JFQVRFX1RIVU1CTkFJTFNfRk9MREVSEMsBEiEKHENBTlRfREVMRVRFX0FD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 31) = "VElWRV9XT1JLU1BBQ0UQzAESGwoWU0VSVklDRV9JTlRFUk5BTF9FUlJPUhCs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 32) = "AhIcChdTRVJWSUNFX0hBTkRTSEFLRV9FUlJPUhCtAhIdChhTRVJWSUNFX1ZF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 33) = "UlNJT05fTUlTTUFUQ0gQrgISHgoZU0VSVklDRV9DQU5UX1NFTkRfUkVRVUVT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 34) = "VBCvAhIdChhTRVJWSUNFX01JU1NJTkdfUkVTUE9OU0UQsAISEAoLQkFEX1JF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 35) = "UVVFU1QQkAMSEQoMSU5WQUxJRF9VVUlEEJEDEhQKD0lOVkFMSURfUkVRVUVT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 36) = "VBCSAxIOCglOT1RfRk9VTkQQlAMSDQoIQ09ORkxJQ1QQmQMSEwoOSU5URVJO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 37) = "QUxfRVJST1IQ9AMSFAoPTk9UX0lNUExFTUVOVEVEEPUDEhQKD0dFTkVSQVRP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 38) = "Ul9FUlJPUhD2AyLHAwoOTWVkaWFSZWZlcmVuY2USDAoEdXVpZBgBIAEoCRI3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 39) = "CgdzdWNjZXNzGAIgASgLMiQuaGVscGVyLmNvbW1vbi52MS5NZWRpYVJlZmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 40) = "ZW5jZUluZm9IABI3CgVlcnJvchgDIAEoCzImLmhlbHBlci5jb21tb24udjEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 41) = "TWVkaWFSZWZlcmVuY2UuRXJyb3JIABI9Cghwcm9ncmVzcxgEIAEoCzIpLmhl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 42) = "bHBlci5jb21tb24udjEuTWVkaWFSZWZlcmVuY2UuUHJvZ3Jlc3NIABI7Cgdk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 43) = "ZWxldGVkGAUgASgLMiguaGVscGVyLmNvbW1vbi52MS5NZWRpYVJlZmVyZW5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 44) = "ZS5EZWxldGVkSAAaCgoIUHJvZ3Jlc3MaCQoHRGVsZXRlZBqYAQoFRXJyb3IS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 45) = "PgoEY29kZRgBIAEoDjIwLmhlbHBlci5jb21tb24udjEuTWVkaWFSZWZlcmVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 46) = "Y2UuRXJyb3IuRXJyb3JDb2RlEhMKC2Rlc2NyaXB0aW9uGAIgASgJIjoKCUVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 47) = "cm9yQ29kZRISCg5JTlRFUk5BTF9FUlJPUhAAEhkKFVNOQVBTSE9UX0ZBSUxF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 48) = "RF9FUlJPUhABQgcKBXN0YXRlIq0CChBHZW5lcmF0aW9uU3RhdHVzEjcKBGlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 49) = "bGUYASABKAsyJy5oZWxwZXIuY29tbW9uLnYxLkdlbmVyYXRpb25TdGF0dXMu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 50) = "SWRsZUgAEkMKCnByb2Nlc3NpbmcYAiABKAsyLS5oZWxwZXIuY29tbW9uLnYx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 51) = "LkdlbmVyYXRpb25TdGF0dXMuUHJvY2Vzc2luZ0gAEjsKBnBhdXNlZBgDIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 52) = "CzIpLmhlbHBlci5jb21tb24udjEuR2VuZXJhdGlvblN0YXR1cy5QYXVzZWRI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 53) = "ABoGCgRJZGxlGioKClByb2Nlc3NpbmcSDQoFY291bnQYASABKA0SDQoFdG90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 54) = "YWwYAiABKA0aIAoGUGF1c2VkEhYKDnVudGlsX3RpbWVfdXRjGAEgASgEQggK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 55) = "BnN0YXR1cyIjChNDaGFuZ2VTaG93RGlyZWN0b3J5EgwKBHBhdGgYASABKAki";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 56) = "GQoJV29ya3NwYWNlEgwKBHBhdGgYASABKAkiQwoQVXBkYXRlV29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 57) = "cxIvCgp3b3Jrc3BhY2VzGAEgAygLMhsuaGVscGVyLmNvbW1vbi52MS5Xb3Jr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 58) = "c3BhY2UiKQoPUGF1c2VHZW5lcmF0aW9uEhYKDnVudGlsX3RpbWVfdXRjGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 59) = "ASgEIhIKEFJlc3VtZUdlbmVyYXRpb24ilgEKEUFkZE1lZGlhUmVmZXJlbmNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 60) = "EgwKBHV1aWQYASABKAkSCwoDdXJsGAIgASgJEiwKCHByaW9yaXR5GAMgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 61) = "MhouaGVscGVyLmNvbW1vbi52MS5Qcmlvcml0eRI4Cg50cmFuc2Zvcm1hdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 62) = "bhgEIAEoCzIgLmhlbHBlci5jb21tb24udjEuVHJhbnNmb3JtYXRpb24ibwoX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 63) = "RHVwbGljYXRlTWVkaWFSZWZlcmVuY2USEwoLc291cmNlX3V1aWQYASABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 64) = "EQoJZGVzdF91dWlkGAIgASgJEiwKCHByaW9yaXR5GAMgASgOMhouaGVscGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 65) = "LmNvbW1vbi52MS5Qcmlvcml0eSLMAgoOVHJhbnNmb3JtYXRpb24SIAoHZWZm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 66) = "ZWN0cxgBIAMoCzIPLnJ2LmRhdGEuRWZmZWN0EhAKCHBvc2l0aW9uGAIgASgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 67) = "EhAKCHJvdGF0aW9uGAMgASgFEg0KBXdpZHRoGAQgASgNEg4KBmhlaWdodBgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 68) = "IAEoDRISCgppbnNldHNfdG9wGAYgASgCEhMKC2luc2V0c19sZWZ0GAcgASgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 69) = "EhQKDGluc2V0c19yaWdodBgIIAEoAhIVCg1pbnNldHNfYm90dG9tGAkgASgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 70) = "EhkKEWZsaXBfaG9yaXpvbnRhbGx5GAogASgIEhcKD2ZsaXBfdmVydGljYWxs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 71) = "eRgLIAEoCBImCgphbHBoYV90eXBlGAwgASgOMhIucnYuZGF0YS5BbHBoYVR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 72) = "cGUSIwobdXNlX2RlZmF1bHRfbmF0aXZlX3JvdGF0aW9uGA0gASgIIosBChNB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 73) = "cHBseVRyYW5zZm9ybWF0aW9uEgwKBHV1aWQYASABKAkSOAoOdHJhbnNmb3Jt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 74) = "YXRpb24YAiABKAsyIC5oZWxwZXIuY29tbW9uLnYxLlRyYW5zZm9ybWF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 75) = "EiwKCHByaW9yaXR5GAMgASgOMhouaGVscGVyLmNvbW1vbi52MS5Qcmlvcml0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 76) = "eSI6ChVSZW1vdmVNZWRpYVJlZmVyZW5jZXMSDAoEdXVpZBgBIAMoCRITCgtw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 77) = "dXJnZV9hc3NldBgCIAEoCCIlChVUcmlnZ2VyTWVkaWFSZWZlcmVuY2USDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 78) = "dXVpZBgBIAMoCSISCgRQaW5nEgoKAmlkGAEgASgFIhsKGUFkZE1lZGlhUmVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 79) = "ZXJlbmNlUmVzcG9uc2UiIQofRHVwbGljYXRlTWVkaWFSZWZlcmVuY2VSZXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 80) = "b25zZSIdChtBcHBseVRyYW5zZm9ybWF0aW9uUmVzcG9uc2UiHgocUmVtb3Zl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 81) = "TWVkaWFSZWZlcmVuY2VSZXNwb25zZSIfCh1UcmlnZ2VyTWVkaWFSZWZlcmVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 82) = "Y2VSZXNwb25zZSIaChhVcGRhdGVXb3Jrc3BhY2VzUmVzcG9uc2UiGQoXUGF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 83) = "c2VHZW5lcmF0aW9uUmVzcG9uc2UiGgoYUmVzdW1lR2VuZXJhdGlvblJlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 84) = "bnNlIhUKE1VwZGF0ZVByZWZzUmVzcG9uc2UiEgoEUG9uZxIKCgJpZBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 85) = "BSotCghQcmlvcml0eRIOCgpCYWNrZ3JvdW5kEAASEQoNVXNlckluaXRpYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 86) = "ZBABQleqAjdQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 87) = "TWVkaWFNYW5hZ2VtZW50LnYxugIaUlZEYXRhX01lZGlhTWFuYWdlbWVudF92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray89<string>, string>(ref buffer, 88) = "MV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray89<string>, string>(in buffer, 89))), new FileDescriptor[2]
		{
			EffectsReflection.Descriptor,
			AlphaTypeReflection.Descriptor
		}, new GeneratedClrTypeInfo(new Type[1] { typeof(Priority) }, null, new GeneratedClrTypeInfo[29]
		{
			new GeneratedClrTypeInfo(typeof(ProductInformation), ProductInformation.Parser, new string[6] { "ProductName", "MajorVersion", "MinorVersion", "PatchVersion", "BuildNumber", "BuildDate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Version), Version.Parser, new string[3] { "Major", "Minor", "Patch" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CreationOption), CreationOption.Parser, new string[3] { "ShowDirectory", "Name", "Seconds" }, new string[2] { "Socket", "Timeout" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(MediaReferenceInfo), MediaReferenceInfo.Parser, new string[2] { "MediaInfo", "ThumbnailInfo" }, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(MediaReferenceInfo.Types.MediaInfo), MediaReferenceInfo.Types.MediaInfo.Parser, new string[14]
				{
					"Url", "Width", "Height", "Fps", "Duration", "NumAudioChannels", "Codec", "Artist", "Title", "Rotation",
					"ContentType", "HasAlphaChannel", "SupportsHwDecode", "ColorFormat"
				}, null, new Type[2]
				{
					typeof(MediaReferenceInfo.Types.MediaInfo.Types.ContentType),
					typeof(MediaReferenceInfo.Types.MediaInfo.Types.ColorFormat)
				}, null, null),
				new GeneratedClrTypeInfo(typeof(MediaReferenceInfo.Types.ThumbnailInfo), MediaReferenceInfo.Types.ThumbnailInfo.Parser, new string[1] { "Url" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(RequestError), RequestError.Parser, new string[2] { "Code", "Description" }, null, new Type[1] { typeof(RequestError.Types.ErrorCode) }, null, null),
			new GeneratedClrTypeInfo(typeof(MediaReference), MediaReference.Parser, new string[5] { "Uuid", "Success", "Error", "Progress", "Deleted" }, new string[1] { "State" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(MediaReference.Types.Progress), MediaReference.Types.Progress.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(MediaReference.Types.Deleted), MediaReference.Types.Deleted.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(MediaReference.Types.Error), MediaReference.Types.Error.Parser, new string[2] { "Code", "Description" }, null, new Type[1] { typeof(MediaReference.Types.Error.Types.ErrorCode) }, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(GenerationStatus), GenerationStatus.Parser, new string[3] { "Idle", "Processing", "Paused" }, new string[1] { "Status" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(GenerationStatus.Types.Idle), GenerationStatus.Types.Idle.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(GenerationStatus.Types.Processing), GenerationStatus.Types.Processing.Parser, new string[2] { "Count", "Total" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(GenerationStatus.Types.Paused), GenerationStatus.Types.Paused.Parser, new string[1] { "UntilTimeUtc" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(ChangeShowDirectory), ChangeShowDirectory.Parser, new string[1] { "Path" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Workspace), Workspace.Parser, new string[1] { "Path" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdateWorkspaces), UpdateWorkspaces.Parser, new string[1] { "Workspaces" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PauseGeneration), PauseGeneration.Parser, new string[1] { "UntilTimeUtc" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ResumeGeneration), ResumeGeneration.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AddMediaReference), AddMediaReference.Parser, new string[4] { "Uuid", "Url", "Priority", "Transformation" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DuplicateMediaReference), DuplicateMediaReference.Parser, new string[3] { "SourceUuid", "DestUuid", "Priority" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Transformation), Transformation.Parser, new string[13]
			{
				"Effects", "Position", "Rotation", "Width", "Height", "InsetsTop", "InsetsLeft", "InsetsRight", "InsetsBottom", "FlipHorizontally",
				"FlipVertically", "AlphaType", "UseDefaultNativeRotation"
			}, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ApplyTransformation), ApplyTransformation.Parser, new string[3] { "Uuid", "Transformation", "Priority" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RemoveMediaReferences), RemoveMediaReferences.Parser, new string[2] { "Uuid", "PurgeAsset" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TriggerMediaReference), TriggerMediaReference.Parser, new string[1] { "Uuid" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Ping), Ping.Parser, new string[1] { "Id" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AddMediaReferenceResponse), AddMediaReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DuplicateMediaReferenceResponse), DuplicateMediaReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ApplyTransformationResponse), ApplyTransformationResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RemoveMediaReferenceResponse), RemoveMediaReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TriggerMediaReferenceResponse), TriggerMediaReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdateWorkspacesResponse), UpdateWorkspacesResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PauseGenerationResponse), PauseGenerationResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ResumeGenerationResponse), ResumeGenerationResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdatePrefsResponse), UpdatePrefsResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Pong), Pong.Parser, new string[1] { "Id" }, null, null, null, null)
		}));
	}
}
