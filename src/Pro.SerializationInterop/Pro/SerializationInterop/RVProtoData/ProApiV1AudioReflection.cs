using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1AudioReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1AudioReflection()
	{
		_003C_003Ey__InlineArray88<string> buffer = default(_003C_003Ey__InlineArray88<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 0) = "ChNwcm9BcGlWMUF1ZGlvLnByb3RvEgdydi5kYXRhGhhwcm9BcGlWMUlkZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 1) = "aWZpZXIucHJvdG8aH3Byb0FwaVYxTWVkaWFQbGF5bGlzdEl0ZW0ucHJvdG8a";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 2) = "FnByb0FwaVYxUGxheWxpc3QucHJvdG8i1A0KFEFQSV92MV9BdWRpb19SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 3) = "ZXN0EjwKCXBsYXlsaXN0cxgBIAEoCzInLnJ2LmRhdGEuQVBJX3YxX0F1ZGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 4) = "X1JlcXVlc3QuUGxheWxpc3RzSAASOgoIcGxheWxpc3QYAiABKAsyJi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 5) = "YXRhLkFQSV92MV9BdWRpb19SZXF1ZXN0LlBsYXlsaXN0SAASSQoQcGxheWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 6) = "c3RfdXBkYXRlcxgDIAEoCzItLnJ2LmRhdGEuQVBJX3YxX0F1ZGlvX1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 7) = "c3QuUGxheWxpc3RVcGRhdGVzSAASRgoQcGxheWxpc3RfZm9jdXNlZBgEIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 8) = "CzIqLnJ2LmRhdGEuQVBJX3YxX0F1ZGlvX1JlcXVlc3QuRW1wdHlNZXNzYWdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 9) = "SAASRQoPcGxheWxpc3RfYWN0aXZlGAUgASgLMioucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 10) = "QXVkaW9fUmVxdWVzdC5FbXB0eU1lc3NhZ2VIABJJChNwbGF5bGlzdF9uZXh0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 11) = "X2ZvY3VzGAYgASgLMioucnYuZGF0YS5BUElfdjFfQXVkaW9fUmVxdWVzdC5F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 12) = "bXB0eU1lc3NhZ2VIABJNChdwbGF5bGlzdF9wcmV2aW91c19mb2N1cxgHIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 13) = "CzIqLnJ2LmRhdGEuQVBJX3YxX0F1ZGlvX1JlcXVlc3QuRW1wdHlNZXNzYWdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 14) = "SAASSwoVcGxheWxpc3RfYWN0aXZlX2ZvY3VzGAggASgLMioucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 15) = "UElfdjFfQXVkaW9fUmVxdWVzdC5FbXB0eU1lc3NhZ2VIABJMChFwbGF5bGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 16) = "dF9pZF9mb2N1cxgJIAEoCzIvLnJ2LmRhdGEuQVBJX3YxX0F1ZGlvX1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 17) = "c3QuSWRlbnRpZmllck1lc3NhZ2VIABJOChhwbGF5bGlzdF9mb2N1c2VkX3Ry";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 18) = "aWdnZXIYCiABKAsyKi5ydi5kYXRhLkFQSV92MV9BdWRpb19SZXF1ZXN0LkVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 19) = "cHR5TWVzc2FnZUgAEk0KF3BsYXlsaXN0X2FjdGl2ZV90cmlnZ2VyGAsgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 20) = "MioucnYuZGF0YS5BUElfdjFfQXVkaW9fUmVxdWVzdC5FbXB0eU1lc3NhZ2VI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 21) = "ABJOChNwbGF5bGlzdF9pZF90cmlnZ2VyGAwgASgLMi8ucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 22) = "djFfQXVkaW9fUmVxdWVzdC5JZGVudGlmaWVyTWVzc2FnZUgAElMKHXBsYXls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 23) = "aXN0X2ZvY3VzZWRfbmV4dF90cmlnZ2VyGA0gASgLMioucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 24) = "djFfQXVkaW9fUmVxdWVzdC5FbXB0eU1lc3NhZ2VIABJXCiFwbGF5bGlzdF9m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 25) = "b2N1c2VkX3ByZXZpb3VzX3RyaWdnZXIYDiABKAsyKi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 26) = "MV9BdWRpb19SZXF1ZXN0LkVtcHR5TWVzc2FnZUgAElYKG3BsYXlsaXN0X2Zv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 27) = "Y3VzZWRfaWRfdHJpZ2dlchgPIAEoCzIvLnJ2LmRhdGEuQVBJX3YxX0F1ZGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 28) = "X1JlcXVlc3QuSWRlbnRpZmllck1lc3NhZ2VIABJSChxwbGF5bGlzdF9hY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 29) = "dmVfbmV4dF90cmlnZ2VyGBAgASgLMioucnYuZGF0YS5BUElfdjFfQXVkaW9f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 30) = "UmVxdWVzdC5FbXB0eU1lc3NhZ2VIABJWCiBwbGF5bGlzdF9hY3RpdmVfcHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 31) = "dmlvdXNfdHJpZ2dlchgRIAEoCzIqLnJ2LmRhdGEuQVBJX3YxX0F1ZGlvX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 32) = "cXVlc3QuRW1wdHlNZXNzYWdlSAASVQoacGxheWxpc3RfYWN0aXZlX2lkX3Ry";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 33) = "aWdnZXIYEiABKAsyLy5ydi5kYXRhLkFQSV92MV9BdWRpb19SZXF1ZXN0Lklk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 34) = "ZW50aWZpZXJNZXNzYWdlSAASUwoYcGxheWxpc3RfaWRfbmV4dF90cmlnZ2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 35) = "GBMgASgLMi8ucnYuZGF0YS5BUElfdjFfQXVkaW9fUmVxdWVzdC5JZGVudGlm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 36) = "aWVyTWVzc2FnZUgAElcKHHBsYXlsaXN0X2lkX3ByZXZpb3VzX3RyaWdnZXIY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 37) = "FCABKAsyLy5ydi5kYXRhLkFQSV92MV9BdWRpb19SZXF1ZXN0LklkZW50aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 38) = "ZXJNZXNzYWdlSAAaCwoJUGxheWxpc3RzGiUKCFBsYXlsaXN0EgoKAmlkGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 39) = "ASgJEg0KBXN0YXJ0GAIgASgNGh0KD1BsYXlsaXN0VXBkYXRlcxIKCgJpZBgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 40) = "IAEoCRoOCgxFbXB0eU1lc3NhZ2UaHwoRSWRlbnRpZmllck1lc3NhZ2USCgoC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 41) = "aWQYASABKAlCCQoHUmVxdWVzdCLRDwoVQVBJX3YxX0F1ZGlvX1Jlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 42) = "Ej0KCXBsYXlsaXN0cxgBIAEoCzIoLnJ2LmRhdGEuQVBJX3YxX0F1ZGlvX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 43) = "c3BvbnNlLlBsYXlsaXN0c0gAEjsKCHBsYXlsaXN0GAIgASgLMicucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 44) = "YS5BUElfdjFfQXVkaW9fUmVzcG9uc2UuUGxheWxpc3RIABI/CgZ1cGRhdGUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 45) = "AyABKAsyLS5ydi5kYXRhLkFQSV92MV9BdWRpb19SZXNwb25zZS5QbGF5bGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 46) = "dFVwZGF0ZUgAEkoKEHBsYXlsaXN0X2ZvY3VzZWQYBCABKAsyLi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 47) = "LkFQSV92MV9BdWRpb19SZXNwb25zZS5Gb2N1c2VkUGxheWxpc3RIABJICg9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 48) = "bGF5bGlzdF9hY3RpdmUYBSABKAsyLS5ydi5kYXRhLkFQSV92MV9BdWRpb19S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 49) = "ZXNwb25zZS5BY3RpdmVQbGF5bGlzdEgAEkoKE3BsYXlsaXN0X25leHRfZm9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 50) = "dXMYBiABKAsyKy5ydi5kYXRhLkFQSV92MV9BdWRpb19SZXNwb25zZS5FbXB0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 51) = "eU1lc3NhZ2VIABJOChdwbGF5bGlzdF9wcmV2aW91c19mb2N1cxgHIAEoCzIr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 52) = "LnJ2LmRhdGEuQVBJX3YxX0F1ZGlvX1Jlc3BvbnNlLkVtcHR5TWVzc2FnZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 53) = "EkwKFXBsYXlsaXN0X2FjdGl2ZV9mb2N1cxgIIAEoCzIrLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 54) = "X3YxX0F1ZGlvX1Jlc3BvbnNlLkVtcHR5TWVzc2FnZUgAEkgKEXBsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 55) = "X2lkX2ZvY3VzGAkgASgLMisucnYuZGF0YS5BUElfdjFfQXVkaW9fUmVzcG9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 56) = "c2UuRW1wdHlNZXNzYWdlSAASTwoYcGxheWxpc3RfZm9jdXNlZF90cmlnZ2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 57) = "GAogASgLMisucnYuZGF0YS5BUElfdjFfQXVkaW9fUmVzcG9uc2UuRW1wdHlN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 58) = "ZXNzYWdlSAASTgoXcGxheWxpc3RfYWN0aXZlX3RyaWdnZXIYCyABKAsyKy5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 59) = "di5kYXRhLkFQSV92MV9BdWRpb19SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 60) = "ChNwbGF5bGlzdF9pZF90cmlnZ2VyGAwgASgLMisucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 61) = "QXVkaW9fUmVzcG9uc2UuRW1wdHlNZXNzYWdlSAASVAodcGxheWxpc3RfZm9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 62) = "dXNlZF9uZXh0X3RyaWdnZXIYDSABKAsyKy5ydi5kYXRhLkFQSV92MV9BdWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 63) = "b19SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJYCiFwbGF5bGlzdF9mb2N1c2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 64) = "X3ByZXZpb3VzX3RyaWdnZXIYDiABKAsyKy5ydi5kYXRhLkFQSV92MV9BdWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 65) = "b19SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJSChtwbGF5bGlzdF9mb2N1c2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 66) = "X2lkX3RyaWdnZXIYDyABKAsyKy5ydi5kYXRhLkFQSV92MV9BdWRpb19SZXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 67) = "b25zZS5FbXB0eU1lc3NhZ2VIABJTChxwbGF5bGlzdF9hY3RpdmVfbmV4dF90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 68) = "cmlnZ2VyGBAgASgLMisucnYuZGF0YS5BUElfdjFfQXVkaW9fUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 69) = "RW1wdHlNZXNzYWdlSAASVwogcGxheWxpc3RfYWN0aXZlX3ByZXZpb3VzX3Ry";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 70) = "aWdnZXIYESABKAsyKy5ydi5kYXRhLkFQSV92MV9BdWRpb19SZXNwb25zZS5F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 71) = "bXB0eU1lc3NhZ2VIABJRChpwbGF5bGlzdF9hY3RpdmVfaWRfdHJpZ2dlchgS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 72) = "IAEoCzIrLnJ2LmRhdGEuQVBJX3YxX0F1ZGlvX1Jlc3BvbnNlLkVtcHR5TWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 73) = "c2FnZUgAEk8KGHBsYXlsaXN0X2lkX25leHRfdHJpZ2dlchgTIAEoCzIrLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 74) = "LmRhdGEuQVBJX3YxX0F1ZGlvX1Jlc3BvbnNlLkVtcHR5TWVzc2FnZUgAElMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 75) = "HHBsYXlsaXN0X2lkX3ByZXZpb3VzX3RyaWdnZXIYFCABKAsyKy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 76) = "LkFQSV92MV9BdWRpb19SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABo4CglQbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 77) = "bGlzdHMSKwoJcGxheWxpc3RzGAEgAygLMhgucnYuZGF0YS5BUElfdjFfUGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 78) = "eWxpc3QaZAoIUGxheWxpc3QSJgoCaWQYASABKAsyGi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 79) = "MV9JZGVudGlmaWVyEjAKBWl0ZW1zGAIgAygLMiEucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 80) = "TWVkaWFQbGF5bGlzdEl0ZW0aOAoOUGxheWxpc3RVcGRhdGUSJgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 81) = "KAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyGg4KDEVtcHR5TWVzc2Fn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 82) = "ZRo5Cg9Gb2N1c2VkUGxheWxpc3QSJgoCaWQYASABKAsyGi5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 83) = "SV92MV9JZGVudGlmaWVyGmgKDkFjdGl2ZVBsYXlsaXN0EiwKCHBsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 84) = "GAEgASgLMhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmllchIoCgRpdGVtGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 85) = "ASgLMhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmllckIKCghSZXNwb25zZUI0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 86) = "+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray88<string>, string>(ref buffer, 87) = "UlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray88<string>, string>(in buffer, 88))), new FileDescriptor[3]
		{
			ProApiV1IdentifierReflection.Descriptor,
			ProApiV1MediaPlaylistItemReflection.Descriptor,
			ProApiV1PlaylistReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Audio_Request), API_v1_Audio_Request.Parser, new string[20]
			{
				"Playlists", "Playlist", "PlaylistUpdates", "PlaylistFocused", "PlaylistActive", "PlaylistNextFocus", "PlaylistPreviousFocus", "PlaylistActiveFocus", "PlaylistIdFocus", "PlaylistFocusedTrigger",
				"PlaylistActiveTrigger", "PlaylistIdTrigger", "PlaylistFocusedNextTrigger", "PlaylistFocusedPreviousTrigger", "PlaylistFocusedIdTrigger", "PlaylistActiveNextTrigger", "PlaylistActivePreviousTrigger", "PlaylistActiveIdTrigger", "PlaylistIdNextTrigger", "PlaylistIdPreviousTrigger"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[5]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Request.Types.Playlists), API_v1_Audio_Request.Types.Playlists.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Request.Types.Playlist), API_v1_Audio_Request.Types.Playlist.Parser, new string[2] { "Id", "Start" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Request.Types.PlaylistUpdates), API_v1_Audio_Request.Types.PlaylistUpdates.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Request.Types.EmptyMessage), API_v1_Audio_Request.Types.EmptyMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Request.Types.IdentifierMessage), API_v1_Audio_Request.Types.IdentifierMessage.Parser, new string[1] { "Id" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Audio_Response), API_v1_Audio_Response.Parser, new string[20]
			{
				"Playlists", "Playlist", "Update", "PlaylistFocused", "PlaylistActive", "PlaylistNextFocus", "PlaylistPreviousFocus", "PlaylistActiveFocus", "PlaylistIdFocus", "PlaylistFocusedTrigger",
				"PlaylistActiveTrigger", "PlaylistIdTrigger", "PlaylistFocusedNextTrigger", "PlaylistFocusedPreviousTrigger", "PlaylistFocusedIdTrigger", "PlaylistActiveNextTrigger", "PlaylistActivePreviousTrigger", "PlaylistActiveIdTrigger", "PlaylistIdNextTrigger", "PlaylistIdPreviousTrigger"
			}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[6]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Response.Types.Playlists), API_v1_Audio_Response.Types.Playlists.Parser, new string[1] { "Playlists_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Response.Types.Playlist), API_v1_Audio_Response.Types.Playlist.Parser, new string[2] { "Id", "Items" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Response.Types.PlaylistUpdate), API_v1_Audio_Response.Types.PlaylistUpdate.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Response.Types.EmptyMessage), API_v1_Audio_Response.Types.EmptyMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Response.Types.FocusedPlaylist), API_v1_Audio_Response.Types.FocusedPlaylist.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Audio_Response.Types.ActivePlaylist), API_v1_Audio_Response.Types.ActivePlaylist.Parser, new string[2] { "Playlist", "Item" }, null, null, null, null)
			})
		}));
	}
}
