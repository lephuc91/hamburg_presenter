using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

public static class V2HelperCommonReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static V2HelperCommonReflection()
	{
		_003C_003Ey__InlineArray152<string> buffer = default(_003C_003Ey__InlineArray152<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 0) = "ChZ2Mi1oZWxwZXItY29tbW9uLnByb3RvEhBoZWxwZXIuY29tbW9uLnYyGg1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 1) = "ZmZlY3RzLnByb3RvGg9hbHBoYVR5cGUucHJvdG8imQEKElByb2R1Y3RJbmZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 2) = "cm1hdGlvbhIUCgxwcm9kdWN0X25hbWUYASABKAkSFQoNbWFqb3JfdmVyc2lv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 3) = "bhgCIAEoCRIVCg1taW5vcl92ZXJzaW9uGAMgASgJEhUKDXBhdGNoX3ZlcnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 4) = "b24YBCABKAkSFAoMYnVpbGRfbnVtYmVyGAUgASgJEhIKCmJ1aWxkX2RhdGUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 5) = "BiABKAMiHQoMRmVhdHVyZUZsYWdzEg0KBWZsYWdzGAEgAygJIjIKD1Byb0Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 6) = "bnRlbnRUb2tlbhIOCgZhY2Nlc3MYASABKAkSDwoHcmVmcmVzaBgCIAEoCSI2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 7) = "CgdWZXJzaW9uEg0KBW1ham9yGAEgASgFEg0KBW1pbm9yGAIgASgFEg0KBXBh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 8) = "dGNoGAMgASgFIjwKC1ByZWZlcmVuY2VzEhQKDG1hbmFnZV9tZWRpYRgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 9) = "CBIXCg9zaGFyZV9hbmFseXRpY3MYAiABKAgi4gEKDkNyZWF0aW9uT3B0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 10) = "EhYKDnNob3dfZGlyZWN0b3J5GAEgASgJEg4KBG5hbWUYAiABKAlIABIRCgdz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 11) = "ZWNvbmRzGAMgASgNSAESMgoLcHJlZmVyZW5jZXMYBCABKAsyHS5oZWxwZXIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 12) = "Y29tbW9uLnYyLlByZWZlcmVuY2VzEhkKDHdvcmtzcGFjZV9pZBgFIAEoCUgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 13) = "iAEBEhQKB3BlZXJfaWQYBiABKARIA4gBAUIICgZTb2NrZXRCCQoHdGltZW91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 14) = "dEIPCg1fd29ya3NwYWNlX2lkQgoKCF9wZWVyX2lkIsgJChJNZWRpYVJlZmVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 15) = "ZW5jZUluZm8SQgoKbWVkaWFfaW5mbxgBIAEoCzIuLmhlbHBlci5jb21tb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 16) = "djIuTWVkaWFSZWZlcmVuY2VJbmZvLk1lZGlhSW5mbxJKCg50aHVtYm5haWxf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 17) = "aW5mbxgCIAEoCzIyLmhlbHBlci5jb21tb24udjIuTWVkaWFSZWZlcmVuY2VJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 18) = "bmZvLlRodW1ibmFpbEluZm8arwIKDEF2YWlsYWJpbGl0eRJICgVyZWFkeRgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 19) = "IAEoCzI3LmhlbHBlci5jb21tb24udjIuTWVkaWFSZWZlcmVuY2VJbmZvLkF2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 20) = "YWlsYWJpbGl0eS5SZWFkeUgAEkwKB21pc3NpbmcYAiABKAsyOS5oZWxwZXIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 21) = "Y29tbW9uLnYyLk1lZGlhUmVmZXJlbmNlSW5mby5BdmFpbGFiaWxpdHkuTWlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 22) = "c2luZ0gAElQKC2Rvd25sb2FkaW5nGAMgASgLMj0uaGVscGVyLmNvbW1vbi52";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 23) = "Mi5NZWRpYVJlZmVyZW5jZUluZm8uQXZhaWxhYmlsaXR5LkRvd25sb2FkaW5n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 24) = "SAAaBwoFUmVhZHkaCQoHTWlzc2luZxoNCgtEb3dubG9hZGluZ0IOCgxhdmFp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 25) = "bGFiaWxpdHkaiAUKCU1lZGlhSW5mbxILCgN1cmwYASABKAkSDQoFd2lkdGgY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 26) = "AiABKA0SDgoGaGVpZ2h0GAMgASgNEgsKA2ZwcxgEIAEoAhIQCghkdXJhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 27) = "bhgFIAEoAhIaChJudW1fYXVkaW9fY2hhbm5lbHMYBiABKA0SDQoFY29kZWMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 28) = "ByABKAkSDgoGYXJ0aXN0GAggASgJEg0KBXRpdGxlGAkgASgJEhAKCHJvdGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 29) = "aW9uGAogASgFElAKDGNvbnRlbnRfdHlwZRgLIAEoDjI6LmhlbHBlci5jb21t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 30) = "b24udjIuTWVkaWFSZWZlcmVuY2VJbmZvLk1lZGlhSW5mby5Db250ZW50VHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 31) = "ZRIZChFoYXNfYWxwaGFfY2hhbm5lbBgMIAEoCBIaChJzdXBwb3J0c19od19k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 32) = "ZWNvZGUYDSABKAgSUAoMY29sb3JfZm9ybWF0GA4gASgOMjouaGVscGVyLmNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 33) = "bW1vbi52Mi5NZWRpYVJlZmVyZW5jZUluZm8uTWVkaWFJbmZvLkNvbG9yRm9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 34) = "bWF0EkcKDGF2YWlsYWJpbGl0eRgPIAEoCzIxLmhlbHBlci5jb21tb24udjIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 35) = "TWVkaWFSZWZlcmVuY2VJbmZvLkF2YWlsYWJpbGl0eSJvCgtDb250ZW50VHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 36) = "ZRIYChRDT05URU5UX1RZUEVfVU5LTk9XThAAEhYKEkNPTlRFTlRfVFlQRV9B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 37) = "VURJTxABEhYKEkNPTlRFTlRfVFlQRV9JTUFHRRACEhYKEkNPTlRFTlRfVFlQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 38) = "RV9WSURFTxADIj8KC0NvbG9yRm9ybWF0EgcKA1NEUhAAEhMKD0hEUl9SRUMy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 39) = "MTAwX0hMRxABEhIKDkhEUl9SRUMyMTAwX1BREAIaZQoNVGh1bWJuYWlsSW5m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 40) = "bxILCgN1cmwYASABKAkSRwoMYXZhaWxhYmlsaXR5GAIgASgLMjEuaGVscGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 41) = "LmNvbW1vbi52Mi5NZWRpYVJlZmVyZW5jZUluZm8uQXZhaWxhYmlsaXR5Iq4E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 42) = "CgxSZXF1ZXN0RXJyb3ISNgoEY29kZRgBIAEoDjIoLmhlbHBlci5jb21tb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 43) = "djIuUmVxdWVzdEVycm9yLkVycm9yQ29kZRITCgtkZXNjcmlwdGlvbhgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 44) = "CSLQAwoJRXJyb3JDb2RlEgsKB1VOS05PV04QABIdChhDQU5UX0NSRUFURV9N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 45) = "RURJQV9GT0xERVIQyQESHAoXQ0FOVF9DUkVBVEVfTUVUQV9GT0xERVIQygES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 46) = "IgodQ0FOVF9DUkVBVEVfVEhVTUJOQUlMU19GT0xERVIQywESIQocQ0FOVF9E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 47) = "RUxFVEVfQUNUSVZFX1dPUktTUEFDRRDMARIbChZTRVJWSUNFX0lOVEVSTkFM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 48) = "X0VSUk9SEKwCEhwKF1NFUlZJQ0VfSEFORFNIQUtFX0VSUk9SEK0CEh0KGFNF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 49) = "UlZJQ0VfVkVSU0lPTl9NSVNNQVRDSBCuAhIeChlTRVJWSUNFX0NBTlRfU0VO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 50) = "RF9SRVFVRVNUEK8CEh0KGFNFUlZJQ0VfTUlTU0lOR19SRVNQT05TRRCwAhIQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 51) = "CgtCQURfUkVRVUVTVBCQAxIRCgxJTlZBTElEX1VVSUQQkQMSFAoPSU5WQUxJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 52) = "RF9SRVFVRVNUEJIDEg4KCU5PVF9GT1VORBCUAxINCghDT05GTElDVBCZAxIT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 53) = "Cg5JTlRFUk5BTF9FUlJPUhD0AxIUCg9OT1RfSU1QTEVNRU5URUQQ9QMSFAoP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 54) = "R0VORVJBVE9SX0VSUk9SEPYDIjkKE1JlZmVyZW5jZUlkZW50aWZpZXISDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 55) = "dXVpZBgBIAEoCRIUCgxjb250YWluZXJfaWQYAiABKAki1AQKDk1lZGlhUmVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 56) = "ZXJlbmNlEjEKAmlkGAEgASgLMiUuaGVscGVyLmNvbW1vbi52Mi5SZWZlcmVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 57) = "Y2VJZGVudGlmaWVyEjcKB3N1Y2Nlc3MYAiABKAsyJC5oZWxwZXIuY29tbW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 58) = "LnYyLk1lZGlhUmVmZXJlbmNlSW5mb0gAEjcKBWVycm9yGAMgASgLMiYuaGVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 59) = "cGVyLmNvbW1vbi52Mi5NZWRpYVJlZmVyZW5jZS5FcnJvckgAEj0KCHByb2dy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 60) = "ZXNzGAQgASgLMikuaGVscGVyLmNvbW1vbi52Mi5NZWRpYVJlZmVyZW5jZS5Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 61) = "cm9ncmVzc0gAEjsKB2RlbGV0ZWQYBSABKAsyKC5oZWxwZXIuY29tbW9uLnYy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 62) = "Lk1lZGlhUmVmZXJlbmNlLkRlbGV0ZWRIABJNCgtkb3dubG9hZGluZxgGIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 63) = "CzI2LmhlbHBlci5jb21tb24udjIuTWVkaWFSZWZlcmVuY2UuUHJvQ29udGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 64) = "dERvd25sb2FkaW5nSAAaCgoIUHJvZ3Jlc3MaCQoHRGVsZXRlZBoXChVQcm9D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 65) = "b250ZW50RG93bmxvYWRpbmcamAEKBUVycm9yEj4KBGNvZGUYASABKA4yMC5o";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 66) = "ZWxwZXIuY29tbW9uLnYyLk1lZGlhUmVmZXJlbmNlLkVycm9yLkVycm9yQ29k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 67) = "ZRITCgtkZXNjcmlwdGlvbhgCIAEoCSI6CglFcnJvckNvZGUSEgoOSU5URVJO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 68) = "QUxfRVJST1IQABIZChVTTkFQU0hPVF9GQUlMRURfRVJST1IQAUIHCgVzdGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 69) = "ZSLGAwoNQXNzZXRJbXBvcnRlZBIxCgJpZBgBIAEoCzIlLmhlbHBlci5jb21t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 70) = "b24udjIuUmVmZXJlbmNlSWRlbnRpZmllchI6CgdzdWNjZXNzGAIgASgLMicu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 71) = "aGVscGVyLmNvbW1vbi52Mi5Bc3NldEltcG9ydGVkLlN1Y2Nlc3NIABI2CgVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 72) = "cnJvchgDIAEoDjIlLmhlbHBlci5jb21tb24udjIuQXNzZXRJbXBvcnRlZC5F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 73) = "cnJvckgAGhYKB1N1Y2Nlc3MSCwoDdXJsGAEgASgJIuwBCgVFcnJvchIfChtJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 74) = "TVBPUlRfUkVTVUxUX1VOS05PV05fRVJST1IQABIlCiFJTVBPUlRfUkVTVUxU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 75) = "X0lOVkFMSURfSU1QT1JUX1BBVEgQARIoCiRJTVBPUlRfUkVTVUxUX1JFQURf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 76) = "UEVSTUlTU0lPTl9ERU5JRUQQAhIpCiVJTVBPUlRfUkVTVUxUX1dSSVRFX1BF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 77) = "Uk1JU1NJT05fREVOSUVEEAMSHgoaSU1QT1JUX1JFU1VMVF9GVUxMX1NUT1JB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 78) = "R0UQBBImCiJJTVBPUlRfUkVTVUxUX1JFQURfT05MWV9GSUxFU1lTVEVNEAVC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 79) = "BwoFc3RhdGUiTwoTQ2hhbmdlU2hvd0RpcmVjdG9yeRIMCgRwYXRoGAEgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 80) = "EhkKDHdvcmtzcGFjZV9pZBgCIAEoCUgAiAEBQg8KDV93b3Jrc3BhY2VfaWQi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 81) = "MQoJV29ya3NwYWNlEgwKBHBhdGgYASABKAkSDwoCaWQYAiABKAlIAIgBAUIF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 82) = "CgNfaWQiQwoQVXBkYXRlV29ya3NwYWNlcxIvCgp3b3Jrc3BhY2VzGAEgAygL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 83) = "MhsuaGVscGVyLmNvbW1vbi52Mi5Xb3Jrc3BhY2UiIwoJUGF1c2VTeW5jEhYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 84) = "DnVudGlsX3RpbWVfdXRjGAEgASgEIgwKClJlc3VtZVN5bmMilwIKEUFkZE1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 85) = "ZGlhUmVmZXJlbmNlEjEKAmlkGAEgASgLMiUuaGVscGVyLmNvbW1vbi52Mi5S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 86) = "ZWZlcmVuY2VJZGVudGlmaWVyEgsKA3VybBgCIAEoCRIsCghwcmlvcml0eRgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 87) = "IAEoDjIaLmhlbHBlci5jb21tb24udjIuUHJpb3JpdHkSOAoOdHJhbnNmb3Jt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 88) = "YXRpb24YBCABKAsyIC5oZWxwZXIuY29tbW9uLnYyLlRyYW5zZm9ybWF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 89) = "EhkKDG1hbmFnZV9tZWRpYRgFIAEoCEgAiAEBEhsKDnVzZXJfaW5pdGlhdGVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 90) = "GAYgASgISAGIAQFCDwoNX21hbmFnZV9tZWRpYUIRCg9fdXNlcl9pbml0aWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 91) = "ZWQikQMKGVByb0NvbnRlbnREb3dubG9hZERldGFpbHMSGAoQYXNzZXRfaWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 92) = "bnRpZmllchgBIAEoCRIUCgxkaXNwbGF5X25hbWUYAiABKAkSFQoNcmVsYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 93) = "dmVfcGF0aBgDIAEoCRIUCgxkb3dubG9hZF91cmwYBCABKAkSFQoNdGh1bWJu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 94) = "YWlsX3VybBgFIAEoCRJJCgphc3NldF90eXBlGAYgASgOMjUuaGVscGVyLmNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 95) = "bW1vbi52Mi5Qcm9Db250ZW50RG93bmxvYWREZXRhaWxzLkFzc2V0VHlwZSK0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 96) = "AQoJQXNzZXRUeXBlEhoKFkFTU0VUX1RZUEVfVU5TUEVDSUZJRUQQABITCg9B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 97) = "U1NFVF9UWVBFX0xPT1AQARIYChRBU1NFVF9UWVBFX0NPVU5URE9XThACEhQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 98) = "EEFTU0VUX1RZUEVfSU1BR0UQAxIbChdBU1NFVF9UWVBFX01PVElPTl9USVRM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 99) = "RRAEEhMKD0FTU0VUX1RZUEVfUEFDSxAFEhQKEEFTU0VUX1RZUEVfVEhFTUUQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 100) = "BiKqAgoWQWRkUHJvQ29udGVudFJlZmVyZW5jZRIxCgJpZBgBIAEoCzIlLmhl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 101) = "bHBlci5jb21tb24udjIuUmVmZXJlbmNlSWRlbnRpZmllchJFChBkb3dubG9h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 102) = "ZF9kZXRhaWxzGAIgASgLMisuaGVscGVyLmNvbW1vbi52Mi5Qcm9Db250ZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 103) = "RG93bmxvYWREZXRhaWxzEjgKDnRyYW5zZm9ybWF0aW9uGAMgASgLMiAuaGVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 104) = "cGVyLmNvbW1vbi52Mi5UcmFuc2Zvcm1hdGlvbhIsCghwcmlvcml0eRgEIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 105) = "DjIaLmhlbHBlci5jb21tb24udjIuUHJpb3JpdHkSGwoOdXNlcl9pbml0aWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 106) = "ZWQYBSABKAhIAIgBAUIRCg9fdXNlcl9pbml0aWF0ZWQi5gEKF0R1cGxpY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 107) = "ZU1lZGlhUmVmZXJlbmNlEjUKBnNyY19pZBgBIAEoCzIlLmhlbHBlci5jb21t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 108) = "b24udjIuUmVmZXJlbmNlSWRlbnRpZmllchI2CgdkZXN0X2lkGAIgASgLMiUu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 109) = "aGVscGVyLmNvbW1vbi52Mi5SZWZlcmVuY2VJZGVudGlmaWVyEiwKCHByaW9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 110) = "aXR5GAMgASgOMhouaGVscGVyLmNvbW1vbi52Mi5Qcmlvcml0eRIbCg51c2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 111) = "X2luaXRpYXRlZBgEIAEoCEgAiAEBQhEKD191c2VyX2luaXRpYXRlZCLMAgoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 112) = "VHJhbnNmb3JtYXRpb24SIAoHZWZmZWN0cxgBIAMoCzIPLnJ2LmRhdGEuRWZm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 113) = "ZWN0EhAKCHBvc2l0aW9uGAIgASgCEhAKCHJvdGF0aW9uGAMgASgFEg0KBXdp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 114) = "ZHRoGAQgASgNEg4KBmhlaWdodBgFIAEoDRISCgppbnNldHNfdG9wGAYgASgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 115) = "EhMKC2luc2V0c19sZWZ0GAcgASgCEhQKDGluc2V0c19yaWdodBgIIAEoAhIV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 116) = "Cg1pbnNldHNfYm90dG9tGAkgASgCEhkKEWZsaXBfaG9yaXpvbnRhbGx5GAog";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 117) = "ASgIEhcKD2ZsaXBfdmVydGljYWxseRgLIAEoCBImCgphbHBoYV90eXBlGAwg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 118) = "ASgOMhIucnYuZGF0YS5BbHBoYVR5cGUSIwobdXNlX2RlZmF1bHRfbmF0aXZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 119) = "X3JvdGF0aW9uGA0gASgIIuABChNBcHBseVRyYW5zZm9ybWF0aW9uEjEKAmlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 120) = "GAEgASgLMiUuaGVscGVyLmNvbW1vbi52Mi5SZWZlcmVuY2VJZGVudGlmaWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 121) = "EjgKDnRyYW5zZm9ybWF0aW9uGAIgASgLMiAuaGVscGVyLmNvbW1vbi52Mi5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 122) = "cmFuc2Zvcm1hdGlvbhIsCghwcmlvcml0eRgDIAEoDjIaLmhlbHBlci5jb21t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 123) = "b24udjIuUHJpb3JpdHkSGwoOdXNlcl9pbml0aWF0ZWQYBCABKAhIAIgBAUIR";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 124) = "Cg9fdXNlcl9pbml0aWF0ZWQipQEKFVJlbW92ZU1lZGlhUmVmZXJlbmNlcxIx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 125) = "CgJpZBgBIAMoCzIlLmhlbHBlci5jb21tb24udjIuUmVmZXJlbmNlSWRlbnRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 126) = "ZmllchITCgtwdXJnZV9hc3NldBgCIAEoCBIUCgxkZWxldGVfYXNzZXQYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 127) = "KAgSGwoOdXNlcl9pbml0aWF0ZWQYBCABKAhIAIgBAUIRCg9fdXNlcl9pbml0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 128) = "aWF0ZWQiSgoVVHJpZ2dlck1lZGlhUmVmZXJlbmNlEjEKAmlkGAEgAygLMiUu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 129) = "aGVscGVyLmNvbW1vbi52Mi5SZWZlcmVuY2VJZGVudGlmaWVyIh0KDVNtYXJ0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 130) = "UGxheWxpc3QSDAoEcGF0aBgBIAEoCSJKChRVcGRhdGVTbWFydFBsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 131) = "cxIyCglwbGF5bGlzdHMYASADKAsyHy5oZWxwZXIuY29tbW9uLnYyLlNtYXJ0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 132) = "UGxheWxpc3QiQQoLVXBkYXRlUHJlZnMSMgoLcHJlZmVyZW5jZXMYASABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 133) = "HS5oZWxwZXIuY29tbW9uLnYyLlByZWZlcmVuY2VzIiQKFE1hcmtXb3Jrc3Bh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 134) = "Y2VBc0Nsb3VkEgwKBHV1aWQYASABKAkiFgoUTWFya1dvcmtzcGFjZUFzTG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 135) = "YWwiVwoPUmVtb3ZlQ29udGFpbmVyEhQKDGNvbnRhaW5lcl9pZBgBIAMoCRIb";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 136) = "Cg51c2VyX2luaXRpYXRlZBgCIAEoCEgAiAEBQhEKD191c2VyX2luaXRpYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 137) = "ZCIWChRJbXBvcnRVbm1hbmFnZWRNZWRpYSISCgRQaW5nEgoKAmlkGAEgASgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 138) = "IhsKGUFkZE1lZGlhUmVmZXJlbmNlUmVzcG9uc2UiIQofRHVwbGljYXRlTWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 139) = "aWFSZWZlcmVuY2VSZXNwb25zZSIdChtBcHBseVRyYW5zZm9ybWF0aW9uUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 140) = "cG9uc2UiHgocUmVtb3ZlTWVkaWFSZWZlcmVuY2VSZXNwb25zZSIfCh1Ucmln";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 141) = "Z2VyTWVkaWFSZWZlcmVuY2VSZXNwb25zZSIaChhVcGRhdGVXb3Jrc3BhY2Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 142) = "UmVzcG9uc2UiEwoRUGF1c2VTeW5jUmVzcG9uc2UiFAoSUmVzdW1lU3luY1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 143) = "c3BvbnNlIh4KHFVwZGF0ZVNtYXJ0UGxheWxpc3RzUmVzcG9uc2UiFQoTVXBk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 144) = "YXRlUHJlZnNSZXNwb25zZSIeChxNYXJrV29ya3NwYWNlQXNDbG91ZFJlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 145) = "bnNlIh4KHE1hcmtXb3Jrc3BhY2VBc0xvY2FsUmVzcG9uc2UiIAoeQWRkUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 146) = "Q29udGVudFJlZmVyZW5jZVJlc3BvbnNlIhkKF1JlbW92ZUNvbnRhaW5lclJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 147) = "c3BvbnNlIh4KHEltcG9ydFVubWFuYWdlZE1lZGlhUmVzcG9uc2UiEgoEUG9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 148) = "ZxIKCgJpZBgBIAEoBSotCghQcmlvcml0eRIOCgpCYWNrZ3JvdW5kEAASEQoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 149) = "VXNlckluaXRpYXRlZBABQleqAjdQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 150) = "UlZQcm90b0RhdGEuTWVkaWFNYW5hZ2VtZW50LnYyugIaUlZEYXRhX01lZGlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray152<string>, string>(ref buffer, 151) = "TWFuYWdlbWVudF92Ml9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray152<string>, string>(in buffer, 152))), new FileDescriptor[2]
		{
			EffectsReflection.Descriptor,
			AlphaTypeReflection.Descriptor
		}, new GeneratedClrTypeInfo(new Type[1] { typeof(Priority) }, null, new GeneratedClrTypeInfo[48]
		{
			new GeneratedClrTypeInfo(typeof(ProductInformation), ProductInformation.Parser, new string[6] { "ProductName", "MajorVersion", "MinorVersion", "PatchVersion", "BuildNumber", "BuildDate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(FeatureFlags), FeatureFlags.Parser, new string[1] { "Flags" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ProContentToken), ProContentToken.Parser, new string[2] { "Access", "Refresh" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Version), Version.Parser, new string[3] { "Major", "Minor", "Patch" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Preferences), Preferences.Parser, new string[2] { "ManageMedia", "ShareAnalytics" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CreationOption), CreationOption.Parser, new string[6] { "ShowDirectory", "Name", "Seconds", "Preferences", "WorkspaceId", "PeerId" }, new string[4] { "Socket", "Timeout", "WorkspaceId", "PeerId" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(MediaReferenceInfo), MediaReferenceInfo.Parser, new string[2] { "MediaInfo", "ThumbnailInfo" }, null, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(MediaReferenceInfo.Types.Availability), MediaReferenceInfo.Types.Availability.Parser, new string[3] { "Ready", "Missing", "Downloading" }, new string[1] { "Availability" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(MediaReferenceInfo.Types.Availability.Types.Ready), MediaReferenceInfo.Types.Availability.Types.Ready.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(MediaReferenceInfo.Types.Availability.Types.Missing), MediaReferenceInfo.Types.Availability.Types.Missing.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(MediaReferenceInfo.Types.Availability.Types.Downloading), MediaReferenceInfo.Types.Availability.Types.Downloading.Parser, null, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(MediaReferenceInfo.Types.MediaInfo), MediaReferenceInfo.Types.MediaInfo.Parser, new string[15]
				{
					"Url", "Width", "Height", "Fps", "Duration", "NumAudioChannels", "Codec", "Artist", "Title", "Rotation",
					"ContentType", "HasAlphaChannel", "SupportsHwDecode", "ColorFormat", "Availability"
				}, null, new Type[2]
				{
					typeof(MediaReferenceInfo.Types.MediaInfo.Types.ContentType),
					typeof(MediaReferenceInfo.Types.MediaInfo.Types.ColorFormat)
				}, null, null),
				new GeneratedClrTypeInfo(typeof(MediaReferenceInfo.Types.ThumbnailInfo), MediaReferenceInfo.Types.ThumbnailInfo.Parser, new string[2] { "Url", "Availability" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(RequestError), RequestError.Parser, new string[2] { "Code", "Description" }, null, new Type[1] { typeof(RequestError.Types.ErrorCode) }, null, null),
			new GeneratedClrTypeInfo(typeof(ReferenceIdentifier), ReferenceIdentifier.Parser, new string[2] { "Uuid", "ContainerId" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MediaReference), MediaReference.Parser, new string[6] { "Id", "Success", "Error", "Progress", "Deleted", "Downloading" }, new string[1] { "State" }, null, null, new GeneratedClrTypeInfo[4]
			{
				new GeneratedClrTypeInfo(typeof(MediaReference.Types.Progress), MediaReference.Types.Progress.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(MediaReference.Types.Deleted), MediaReference.Types.Deleted.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(MediaReference.Types.ProContentDownloading), MediaReference.Types.ProContentDownloading.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(MediaReference.Types.Error), MediaReference.Types.Error.Parser, new string[2] { "Code", "Description" }, null, new Type[1] { typeof(MediaReference.Types.Error.Types.ErrorCode) }, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(AssetImported), AssetImported.Parser, new string[3] { "Id", "Success", "Error" }, new string[1] { "State" }, new Type[1] { typeof(AssetImported.Types.Error) }, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(AssetImported.Types.Success), AssetImported.Types.Success.Parser, new string[1] { "Url" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(ChangeShowDirectory), ChangeShowDirectory.Parser, new string[2] { "Path", "WorkspaceId" }, new string[1] { "WorkspaceId" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(Workspace), Workspace.Parser, new string[2] { "Path", "Id" }, new string[1] { "Id" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdateWorkspaces), UpdateWorkspaces.Parser, new string[1] { "Workspaces" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PauseSync), PauseSync.Parser, new string[1] { "UntilTimeUtc" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ResumeSync), ResumeSync.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AddMediaReference), AddMediaReference.Parser, new string[6] { "Id", "Url", "Priority", "Transformation", "ManageMedia", "UserInitiated" }, new string[2] { "ManageMedia", "UserInitiated" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(ProContentDownloadDetails), ProContentDownloadDetails.Parser, new string[6] { "AssetIdentifier", "DisplayName", "RelativePath", "DownloadUrl", "ThumbnailUrl", "AssetType" }, null, new Type[1] { typeof(ProContentDownloadDetails.Types.AssetType) }, null, null),
			new GeneratedClrTypeInfo(typeof(AddProContentReference), AddProContentReference.Parser, new string[5] { "Id", "DownloadDetails", "Transformation", "Priority", "UserInitiated" }, new string[1] { "UserInitiated" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(DuplicateMediaReference), DuplicateMediaReference.Parser, new string[4] { "SrcId", "DestId", "Priority", "UserInitiated" }, new string[1] { "UserInitiated" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(Transformation), Transformation.Parser, new string[13]
			{
				"Effects", "Position", "Rotation", "Width", "Height", "InsetsTop", "InsetsLeft", "InsetsRight", "InsetsBottom", "FlipHorizontally",
				"FlipVertically", "AlphaType", "UseDefaultNativeRotation"
			}, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ApplyTransformation), ApplyTransformation.Parser, new string[4] { "Id", "Transformation", "Priority", "UserInitiated" }, new string[1] { "UserInitiated" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(RemoveMediaReferences), RemoveMediaReferences.Parser, new string[4] { "Id", "PurgeAsset", "DeleteAsset", "UserInitiated" }, new string[1] { "UserInitiated" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(TriggerMediaReference), TriggerMediaReference.Parser, new string[1] { "Id" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SmartPlaylist), SmartPlaylist.Parser, new string[1] { "Path" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdateSmartPlaylists), UpdateSmartPlaylists.Parser, new string[1] { "Playlists" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdatePrefs), UpdatePrefs.Parser, new string[1] { "Preferences" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MarkWorkspaceAsCloud), MarkWorkspaceAsCloud.Parser, new string[1] { "Uuid" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MarkWorkspaceAsLocal), MarkWorkspaceAsLocal.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RemoveContainer), RemoveContainer.Parser, new string[2] { "ContainerId", "UserInitiated" }, new string[1] { "UserInitiated" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(ImportUnmanagedMedia), ImportUnmanagedMedia.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Ping), Ping.Parser, new string[1] { "Id" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AddMediaReferenceResponse), AddMediaReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DuplicateMediaReferenceResponse), DuplicateMediaReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ApplyTransformationResponse), ApplyTransformationResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RemoveMediaReferenceResponse), RemoveMediaReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TriggerMediaReferenceResponse), TriggerMediaReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdateWorkspacesResponse), UpdateWorkspacesResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PauseSyncResponse), PauseSyncResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ResumeSyncResponse), ResumeSyncResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdateSmartPlaylistsResponse), UpdateSmartPlaylistsResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UpdatePrefsResponse), UpdatePrefsResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MarkWorkspaceAsCloudResponse), MarkWorkspaceAsCloudResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MarkWorkspaceAsLocalResponse), MarkWorkspaceAsLocalResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AddProContentReferenceResponse), AddProContentReferenceResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RemoveContainerResponse), RemoveContainerResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ImportUnmanagedMediaResponse), ImportUnmanagedMediaResponse.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Pong), Pong.Parser, new string[1] { "Id" }, null, null, null, null)
		}));
	}
}
