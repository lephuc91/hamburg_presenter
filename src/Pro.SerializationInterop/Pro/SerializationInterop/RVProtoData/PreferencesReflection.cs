using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class PreferencesReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PreferencesReflection()
	{
		_003C_003Ey__InlineArray95<string> buffer = default(_003C_003Ey__InlineArray95<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 0) = "ChFwcmVmZXJlbmNlcy5wcm90bxIHcnYuZGF0YRoMYWN0aW9uLnByb3RvGglj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 1) = "dWUucHJvdG8aEmdyYXBoaWNzRGF0YS5wcm90bxoMZ3JvdXBzLnByb3RvGgxs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 2) = "YWJlbHMucHJvdG8aFHByb0Nsb2NrU291cmNlLnByb3RvGgl1cmwucHJvdG8i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 3) = "zx8KC1ByZWZlcmVuY2VzEi0KB2dlbmVyYWwYASABKAsyHC5ydi5kYXRhLlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 4) = "ZWZlcmVuY2VzLkdlbmVyYWwSLQoHc2NyZWVucxgCIAEoCzIcLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 5) = "UHJlZmVyZW5jZXMuU2NyZWVucxIrCgZpbXBvcnQYAyABKAsyGy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 6) = "LlByZWZlcmVuY2VzLkltcG9ydBIrCgZncm91cHMYBCABKAsyGy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 7) = "LlByZWZlcmVuY2VzLkdyb3VwcxItCgduZXR3b3JrGAUgASgLMhwucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 8) = "YS5QcmVmZXJlbmNlcy5OZXR3b3JrEicKBHN5bmMYBiABKAsyGS5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 9) = "LlByZWZlcmVuY2VzLlN5bmMSLwoIYWR2YW5jZWQYByABKAsyHS5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 10) = "LlByZWZlcmVuY2VzLkFkdmFuY2VkEi0KB3VwZGF0ZXMYCCABKAsyHC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 11) = "YXRhLlByZWZlcmVuY2VzLlVwZGF0ZXMafwoHR2VuZXJhbBIlCh1ob3VzZV9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 12) = "Zl93b3JzaGlwX2ludGVncmF0aW9ucxgBIAEoCBIVCg1jcmFzaF9yZXBvcnRz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 13) = "GAIgASgIEhEKCWFuYWx5dGljcxgDIAEoCBIRCglsb2dvX3BhdGgYBCABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 14) = "EAoIbGFuZ3VhZ2UYBSABKAkagAIKB1NjcmVlbnMSGAoQZW5hYmxlX2F0X2xh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 15) = "dW5jaBgBIAEoCBIeChZzaG93X3BlcmZvcm1hbmNlX3N0YXRzGAIgASgIEiAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 16) = "GGlnbm9yZV9iYWNrZ3JvdW5kX2NvbG9ycxgDIAEoCBItCgxjbG9ja19zb3Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 17) = "Y2UYBCABKAsyFy5ydi5kYXRhLlByb0Nsb2NrU291cmNlEiMKG3Nob3dfa2V5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 18) = "bm90ZV9hbmRfcG93ZXJwb2ludBgFIAEoCBImCh5kaXNhYmxlX2JsYWNrbWFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 19) = "aWNfc3luY19ncm91cHMYBiABKAgSHQoVdXNlX2RpcmVjdHhfcmVuZGVyaW5n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 20) = "GAcgASgIGtIJCgZJbXBvcnQSOAoSZm9yZWdyb3VuZF9zY2FsaW5nGAEgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 21) = "MhwucnYuZGF0YS5NZWRpYS5TY2FsZUJlaGF2aW9yEh0KFWZvcmVncm91bmRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 22) = "aXNfYmx1cnJlZBgGIAEoCBI4ChJiYWNrZ3JvdW5kX3NjYWxpbmcYAiABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 23) = "HC5ydi5kYXRhLk1lZGlhLlNjYWxlQmVoYXZpb3ISHQoVYmFja2dyb3VuZF9p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 24) = "c19ibHVycmVkGAcgASgIEjAKBWltYWdlGAMgASgLMiEucnYuZGF0YS5QcmVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 25) = "ZXJlbmNlcy5JbXBvcnQuSW1hZ2USMAoFdmlkZW8YBCABKAsyIS5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 26) = "LlByZWZlcmVuY2VzLkltcG9ydC5WaWRlbxIwCgVhdWRpbxgFIAEoCzIhLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 27) = "LmRhdGEuUHJlZmVyZW5jZXMuSW1wb3J0LkF1ZGlvGuYDCgVJbWFnZRItCgps";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 28) = "YXllcl90eXBlGAEgASgOMhkucnYuZGF0YS5BY3Rpb24uTGF5ZXJUeXBlEjwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 29) = "CGR1cmF0aW9uGAIgASgLMioucnYuZGF0YS5QcmVmZXJlbmNlcy5JbXBvcnQu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 30) = "SW1hZ2UuRHVyYXRpb24SOAoNbmV4dF9iZWhhdmlvchgDIAEoDjIhLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 31) = "dGEuQ3VlLkNvbXBsZXRpb25UYXJnZXRUeXBlGrUCCghEdXJhdGlvbhI/CgRu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 32) = "b25lGAEgASgLMi8ucnYuZGF0YS5QcmVmZXJlbmNlcy5JbXBvcnQuSW1hZ2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 33) = "RHVyYXRpb24uTm9uZUgAEj8KBHRpbWUYAiABKAsyLy5ydi5kYXRhLlByZWZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 34) = "cmVuY2VzLkltcG9ydC5JbWFnZS5EdXJhdGlvbi5UaW1lSAASQwoGcmFuZG9t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 35) = "GAMgASgLMjEucnYuZGF0YS5QcmVmZXJlbmNlcy5JbXBvcnQuSW1hZ2UuRHVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 36) = "YXRpb24uUmFuZG9tSAAaBgoETm9uZRoUCgRUaW1lEgwKBHRpbWUYASABKAEa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 37) = "NAoGUmFuZG9tEhQKDG1pbmltdW1fdGltZRgBIAEoARIUCgxtYXhpbXVtX3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 38) = "bWUYAiABKAFCDgoMRHVyYXRpb25UeXBlGoICCgVWaWRlbxItCgpsYXllcl90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 39) = "eXBlGAEgASgOMhkucnYuZGF0YS5BY3Rpb24uTGF5ZXJUeXBlEk4KEXBsYXli";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 40) = "YWNrX2JlaGF2aW9yGAIgASgOMjMucnYuZGF0YS5NZWRpYS5UcmFuc3BvcnRQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 41) = "cm9wZXJ0aWVzLlBsYXliYWNrQmVoYXZpb3ISQAoMZW5kX2JlaGF2aW9yGAMg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 42) = "ASgOMioucnYuZGF0YS5NZWRpYS5WaWRlb1Byb3BlcnRpZXMuRW5kQmVoYXZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 43) = "b3ISOAoNbmV4dF9iZWhhdmlvchgEIAEoDjIhLnJ2LmRhdGEuQ3VlLkNvbXBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 44) = "ZXRpb25UYXJnZXRUeXBlGpEBCgVBdWRpbxJOChFwbGF5YmFja19iZWhhdmlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 45) = "chgBIAEoDjIzLnJ2LmRhdGEuTWVkaWEuVHJhbnNwb3J0UHJvcGVydGllcy5Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 46) = "bGF5YmFja0JlaGF2aW9yEjgKDW5leHRfYmVoYXZpb3IYAiABKA4yIS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 47) = "YXRhLkN1ZS5Db21wbGV0aW9uVGFyZ2V0VHlwZRpgCgZHcm91cHMSKgoGZ3Jv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 48) = "dXBzGAEgASgLMhoucnYuZGF0YS5Qcm9Hcm91cHNEb2N1bWVudBIqCgZsYWJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 49) = "bHMYAiABKAsyGi5ydi5kYXRhLlByb0xhYmVsc0RvY3VtZW50GtUECgdOZXR3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 50) = "b3JrEjUKB25ldHdvcmsYASABKAsyJC5ydi5kYXRhLlByZWZlcmVuY2VzLk5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 51) = "dHdvcmsuTmV0d29yaxI1CgdyZW1vdGVzGAIgASgLMiQucnYuZGF0YS5QcmVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 52) = "ZXJlbmNlcy5OZXR3b3JrLlJlbW90ZXMSLwoEbGluaxgDIAEoCzIhLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 53) = "dGEuUHJlZmVyZW5jZXMuTmV0d29yay5MaW5rGjUKB05ldHdvcmsSDgoGZW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 54) = "YmxlGAEgASgIEgwKBG5hbWUYAiABKAkSDAoEcG9ydBgDIAEoDRrHAgoHUmVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 55) = "b3RlcxJCCgpwcm9fcmVtb3RlGAEgASgLMi4ucnYuZGF0YS5QcmVmZXJlbmNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 56) = "cy5OZXR3b3JrLlJlbW90ZXMuUHJvUmVtb3RlEkAKCXN0YWdlX2FwcBgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 57) = "CzItLnJ2LmRhdGEuUHJlZmVyZW5jZXMuTmV0d29yay5SZW1vdGVzLlN0YWdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 58) = "QXBwGocBCglQcm9SZW1vdGUSDgoGZW5hYmxlGAEgASgIEhkKEWVuYWJsZV9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 59) = "b250cm9sbGVyGAIgASgIEhsKE2NvbnRyb2xsZXJfcGFzc3dvcmQYAyABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 60) = "FwoPZW5hYmxlX29ic2VydmVyGAQgASgIEhkKEW9ic2VydmVyX3Bhc3N3b3Jk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 61) = "GAUgASgJGiwKCFN0YWdlQXBwEg4KBmVuYWJsZRgBIAEoCBIQCghwYXNzd29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 62) = "ZBgCIAEoCRoqCgRMaW5rEg4KBmVuYWJsZRgBIAEoCBISCgpsaW5rX2dyb3Vw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 63) = "GAIgASgJGqoCCgRTeW5jEhIKCnJlcG9zaXRvcnkYASABKAkSGQoRaW5jbHVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 64) = "ZV9saWJyYXJpZXMYAiABKAgSFQoNaW5jbHVkZV9tZWRpYRgDIAEoCBIZChFp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 65) = "bmNsdWRlX3BsYXlsaXN0cxgEIAEoCBIWCg5pbmNsdWRlX3RoZW1lcxgFIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 66) = "CBIdChVpbmNsdWRlX3N1cHBvcnRfZmlsZXMYBiABKAgSOgoJZGlyZWN0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 67) = "GAcgASgOMicucnYuZGF0YS5QcmVmZXJlbmNlcy5TeW5jLlN5bmNEaXJlY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 68) = "b24SIQoZcmVwbGFjZV9kZXN0aW5hdGlvbl9maWxlcxgIIAEoCCIrCg1TeW5j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 69) = "RGlyZWN0aW9uEg0KCVNZTkNfRE9XThAAEgsKB1NZTkNfVVAQARqBBwoIQWR2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 70) = "YW5jZWQSGwoTc3VwcHJlc3NfYXV0b19zdGFydBgBIAEoCBJfChtwcmVzZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 71) = "YXRpb25fYXVkaW9fYmVoYXZpb3IYAiABKA4yOi5ydi5kYXRhLlByZWZlcmVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 72) = "Y2VzLkFkdmFuY2VkLkF1ZGlvRm9yZWdyb3VuZE1lZGlhQmVoYXZpb3ISYAoc";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 73) = "YW5ub3VuY2VtZW50c19hdWRpb19iZWhhdmlvchgDIAEoDjI6LnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 74) = "UHJlZmVyZW5jZXMuQWR2YW5jZWQuQXVkaW9Gb3JlZ3JvdW5kTWVkaWFCZWhh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 75) = "dmlvchJBCg1uZGlfZGlzY292ZXJ5GAQgASgLMioucnYuZGF0YS5QcmVmZXJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 76) = "bmNlcy5BZHZhbmNlZC5ORElEaXNjb3ZlcnkSGgoSc3VwcG9ydF9maWxlc19w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 77) = "YXRoGAUgASgJEiIKGm1hbmFnZV9tZWRpYV9hdXRvbWF0aWNhbGx5GAYgASgI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 78) = "Ej8KDHNlYXJjaF9wYXRocxgHIAEoCzIpLnJ2LmRhdGEuUHJlZmVyZW5jZXMu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 79) = "QWR2YW5jZWQuU2VhcmNoUGF0aHMaYQoMTkRJRGlzY292ZXJ5EhoKEnNob3df";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 80) = "bG9jYWxfc291cmNlcxgBIAEoCBIWCg5yZWNlaXZlX2dyb3VwcxgCIAEoCRId";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 81) = "ChVhZGRpdGlvbmFsX3NlYXJjaF9pcHMYAyABKAka1QEKC1NlYXJjaFBhdGhz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 82) = "EhwKFGF1dG9tYXRpY2FsbHlfcmVsaW5rGAEgASgIEj0KBXBhdGhzGAIgAygL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 83) = "Mi4ucnYuZGF0YS5QcmVmZXJlbmNlcy5BZHZhbmNlZC5TZWFyY2hQYXRocy5Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 84) = "YXRoGmkKBFBhdGgSDgoGZW5hYmxlGAEgASgIEgwKBG5hbWUYAiABKAkSDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 85) = "cGF0aBgDIAEoCRI1Cgh1cmxfcm9vdBgEIAEoDjIjLnJ2LmRhdGEuVVJMLkxv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 86) = "Y2FsUmVsYXRpdmVQYXRoLlJvb3QilQEKHEF1ZGlvRm9yZWdyb3VuZE1lZGlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 87) = "QmVoYXZpb3ISGwoXSUdOT1JFX0ZPUkVHUk9VTkRfTUVESUEQABIXChNDTEVB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 88) = "Ul9GT1JfQUxMX01FRElBEAESEgoOQ0xFQVJfSUZfQVVESU8QAhIXChNQQVVT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 89) = "RV9GT1JfQUxMX01FRElBEAMSEgoOUEFVU0VfSUZfQVVESU8QBBqLAQoHVXBk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 90) = "YXRlcxIdChVub3RpZnlfd2hlbl9hdmFpbGFibGUYASABKAgSPAoOdXBkYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 91) = "X2NoYW5uZWwYAiABKA4yJC5ydi5kYXRhLlByZWZlcmVuY2VzLlVwZGF0ZXMu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 92) = "Q2hhbm5lbCIjCgdDaGFubmVsEg4KCnByb2R1Y3Rpb24QABIICgRiZXRhEAFC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 93) = "NPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 94) = "B1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray95<string>, string>(in buffer, 95))), new FileDescriptor[7]
		{
			ActionReflection.Descriptor,
			CueReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			GroupsReflection.Descriptor,
			LabelsReflection.Descriptor,
			ProClockSourceReflection.Descriptor,
			UrlReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Preferences), Preferences.Parser, new string[8] { "General", "Screens", "Import", "Groups", "Network", "Sync", "Advanced", "Updates" }, null, null, null, new GeneratedClrTypeInfo[8]
			{
				new GeneratedClrTypeInfo(typeof(Preferences.Types.General), Preferences.Types.General.Parser, new string[5] { "HouseOfWorshipIntegrations", "CrashReports", "Analytics", "LogoPath", "Language" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Preferences.Types.Screens), Preferences.Types.Screens.Parser, new string[7] { "EnableAtLaunch", "ShowPerformanceStats", "IgnoreBackgroundColors", "ClockSource", "ShowKeynoteAndPowerpoint", "DisableBlackmagicSyncGroups", "UseDirectxRendering" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Preferences.Types.Import), Preferences.Types.Import.Parser, new string[7] { "ForegroundScaling", "ForegroundIsBlurred", "BackgroundScaling", "BackgroundIsBlurred", "Image", "Video", "Audio" }, null, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(Preferences.Types.Import.Types.Image), Preferences.Types.Import.Types.Image.Parser, new string[3] { "LayerType", "Duration", "NextBehavior" }, null, null, null, new GeneratedClrTypeInfo[1]
					{
						new GeneratedClrTypeInfo(typeof(Preferences.Types.Import.Types.Image.Types.Duration), Preferences.Types.Import.Types.Image.Types.Duration.Parser, new string[3] { "None", "Time", "Random" }, new string[1] { "DurationType" }, null, null, new GeneratedClrTypeInfo[3]
						{
							new GeneratedClrTypeInfo(typeof(Preferences.Types.Import.Types.Image.Types.Duration.Types.None), Preferences.Types.Import.Types.Image.Types.Duration.Types.None.Parser, null, null, null, null, null),
							new GeneratedClrTypeInfo(typeof(Preferences.Types.Import.Types.Image.Types.Duration.Types.Time), Preferences.Types.Import.Types.Image.Types.Duration.Types.Time.Parser, new string[1] { "Time_" }, null, null, null, null),
							new GeneratedClrTypeInfo(typeof(Preferences.Types.Import.Types.Image.Types.Duration.Types.Random), Preferences.Types.Import.Types.Image.Types.Duration.Types.Random.Parser, new string[2] { "MinimumTime", "MaximumTime" }, null, null, null, null)
						})
					}),
					new GeneratedClrTypeInfo(typeof(Preferences.Types.Import.Types.Video), Preferences.Types.Import.Types.Video.Parser, new string[4] { "LayerType", "PlaybackBehavior", "EndBehavior", "NextBehavior" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Preferences.Types.Import.Types.Audio), Preferences.Types.Import.Types.Audio.Parser, new string[2] { "PlaybackBehavior", "NextBehavior" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Preferences.Types.Groups), Preferences.Types.Groups.Parser, new string[2] { "Groups_", "Labels" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Preferences.Types.Network), Preferences.Types.Network.Parser, new string[3] { "Network_", "Remotes", "Link" }, null, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(Preferences.Types.Network.Types.Network), Preferences.Types.Network.Types.Network.Parser, new string[3] { "Enable", "Name", "Port" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Preferences.Types.Network.Types.Remotes), Preferences.Types.Network.Types.Remotes.Parser, new string[2] { "ProRemote", "StageApp" }, null, null, null, new GeneratedClrTypeInfo[2]
					{
						new GeneratedClrTypeInfo(typeof(Preferences.Types.Network.Types.Remotes.Types.ProRemote), Preferences.Types.Network.Types.Remotes.Types.ProRemote.Parser, new string[5] { "Enable", "EnableController", "ControllerPassword", "EnableObserver", "ObserverPassword" }, null, null, null, null),
						new GeneratedClrTypeInfo(typeof(Preferences.Types.Network.Types.Remotes.Types.StageApp), Preferences.Types.Network.Types.Remotes.Types.StageApp.Parser, new string[2] { "Enable", "Password" }, null, null, null, null)
					}),
					new GeneratedClrTypeInfo(typeof(Preferences.Types.Network.Types.Link), Preferences.Types.Network.Types.Link.Parser, new string[2] { "Enable", "LinkGroup" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Preferences.Types.Sync), Preferences.Types.Sync.Parser, new string[8] { "Repository", "IncludeLibraries", "IncludeMedia", "IncludePlaylists", "IncludeThemes", "IncludeSupportFiles", "Direction", "ReplaceDestinationFiles" }, null, new Type[1] { typeof(Preferences.Types.Sync.Types.SyncDirection) }, null, null),
				new GeneratedClrTypeInfo(typeof(Preferences.Types.Advanced), Preferences.Types.Advanced.Parser, new string[7] { "SuppressAutoStart", "PresentationAudioBehavior", "AnnouncementsAudioBehavior", "NdiDiscovery", "SupportFilesPath", "ManageMediaAutomatically", "SearchPaths" }, null, new Type[1] { typeof(Preferences.Types.Advanced.Types.AudioForegroundMediaBehavior) }, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(Preferences.Types.Advanced.Types.NDIDiscovery), Preferences.Types.Advanced.Types.NDIDiscovery.Parser, new string[3] { "ShowLocalSources", "ReceiveGroups", "AdditionalSearchIps" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Preferences.Types.Advanced.Types.SearchPaths), Preferences.Types.Advanced.Types.SearchPaths.Parser, new string[2] { "AutomaticallyRelink", "Paths" }, null, null, null, new GeneratedClrTypeInfo[1]
					{
						new GeneratedClrTypeInfo(typeof(Preferences.Types.Advanced.Types.SearchPaths.Types.Path), Preferences.Types.Advanced.Types.SearchPaths.Types.Path.Parser, new string[4] { "Enable", "Name", "Path_", "UrlRoot" }, null, null, null, null)
					})
				}),
				new GeneratedClrTypeInfo(typeof(Preferences.Types.Updates), Preferences.Types.Updates.Parser, new string[2] { "NotifyWhenAvailable", "UpdateChannel" }, null, new Type[1] { typeof(Preferences.Types.Updates.Types.Channel) }, null, null)
			})
		}));
	}
}
