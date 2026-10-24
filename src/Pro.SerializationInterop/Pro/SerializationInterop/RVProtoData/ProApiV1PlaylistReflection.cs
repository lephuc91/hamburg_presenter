using System;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1PlaylistReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1PlaylistReflection()
	{
		_003C_003Ey__InlineArray225<string> buffer = default(_003C_003Ey__InlineArray225<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 0) = "ChZwcm9BcGlWMVBsYXlsaXN0LnByb3RvEgdydi5kYXRhGh5nb29nbGUvcHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 1) = "dG9idWYvd3JhcHBlcnMucHJvdG8aE3Byb0FwaVYxQ29sb3IucHJvdG8aGXBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 2) = "b0FwaVYxQ29udGVudFR5cGUucHJvdG8aGHByb0FwaVYxSWRlbnRpZmllci5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 3) = "cm90bxomcHJvQXBpVjFQcmVzZW50YXRpb25QbGF5bGlzdEl0ZW0ucHJvdG8a";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 4) = "GnByb0FwaVYxUHJlc2VudGF0aW9uLnByb3RvGh9wcm9BcGlWMVRpbWVsaW5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 5) = "T3BlcmF0aW9uLnByb3RvItEBCg9BUElfdjFfUGxheWxpc3QSJgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 6) = "KAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyEjoKBHR5cGUYAiABKA4y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 7) = "LC5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdC5BUElfdjFfUGxheWxpc3RUeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 8) = "EioKCGNoaWxkcmVuGAMgAygLMhgucnYuZGF0YS5BUElfdjFfUGxheWxpc3Qi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 9) = "LgoTQVBJX3YxX1BsYXlsaXN0VHlwZRIJCgVncm91cBAAEgwKCHBsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 10) = "EAEipQEKFkFQSV92MV9QbGF5bGlzdEFuZEl0ZW0SLAoIcGxheWxpc3QYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 11) = "KAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyEigKBGl0ZW0YAiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 12) = "Gi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyEjMKDXBsYXlsaXN0X2l0ZW0Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 13) = "AyABKAsyHC5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdEl0ZW0iiQQKE0FQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 14) = "MV9QbGF5bGlzdEl0ZW0SJgoCaWQYASABKAsyGi5ydi5kYXRhLkFQSV92MV9J";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 15) = "ZGVudGlmaWVyEkIKBHR5cGUYAiABKA4yNC5ydi5kYXRhLkFQSV92MV9QbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 16) = "bGlzdEl0ZW0uQVBJX3YxX1BsYXlsaXN0SXRlbVR5cGUSEQoJaXNfaGlkZGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 17) = "GAMgASgIEg4KBmlzX3BjbxgEIAEoCBIrCgxoZWFkZXJfY29sb3IYBSABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 18) = "FS5ydi5kYXRhLkFQSV92MV9Db2xvchIuCghkdXJhdGlvbhgGIAEoCzIcLmdv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 19) = "b2dsZS5wcm90b2J1Zi5VSW50MzJWYWx1ZRJDChFwcmVzZW50YXRpb25faW5m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 20) = "bxgHIAEoCzIoLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0UHJlc2VudGF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 21) = "SXRlbRITCgt0YXJnZXRfdXVpZBgIIAEoCRI9CgtkZXN0aW5hdGlvbhgJIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 22) = "DjIoLnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbi5EZXN0aW5hdGlvbiJt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 23) = "ChdBUElfdjFfUGxheWxpc3RJdGVtVHlwZRIQCgxwcmVzZW50YXRpb24QABIP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 24) = "CgtwbGFjZWhvbGRlchABEgoKBmhlYWRlchACEgkKBW1lZGlhEAMSCQoFYXVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 25) = "aW8QBBINCglsaXZldmlkZW8QBSKFIwoXQVBJX3YxX1BsYXlsaXN0X1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 26) = "c3QSPwoJcGxheWxpc3RzGAEgASgLMioucnYuZGF0YS5BUElfdjFfUGxheWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 27) = "c3RfUmVxdWVzdC5QbGF5bGlzdHNIABJKCg9jcmVhdGVfcGxheWxpc3QYAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 28) = "KAsyLy5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXF1ZXN0LkNyZWF0ZVBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 29) = "YXlsaXN0SAASRAoMZ2V0X3BsYXlsaXN0GAMgASgLMiwucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 30) = "djFfUGxheWxpc3RfUmVxdWVzdC5HZXRQbGF5bGlzdEgAEkQKDHB1dF9wbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 31) = "bGlzdBgEIAEoCzIsLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0X1JlcXVlc3Qu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 32) = "UHV0UGxheWxpc3RIABJGCg1wb3N0X3BsYXlsaXN0GAUgASgLMi0ucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 33) = "YS5BUElfdjFfUGxheWxpc3RfUmVxdWVzdC5Qb3N0UGxheWxpc3RIABJRChNn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 34) = "ZXRfYWN0aXZlX3BsYXlsaXN0GAYgASgLMjIucnYuZGF0YS5BUElfdjFfUGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 35) = "eWxpc3RfUmVxdWVzdC5HZXRBY3RpdmVQbGF5bGlzdEgAEkUKB2ZvY3VzZWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 36) = "ByABKAsyMi5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXF1ZXN0LkdldEFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 37) = "dGl2ZVBsYXlsaXN0SAASQwoKbmV4dF9mb2N1cxgIIAEoCzItLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 38) = "QVBJX3YxX1BsYXlsaXN0X1JlcXVlc3QuRW1wdHlNZXNzYWdlSAASRwoOcHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 39) = "dmlvdXNfZm9jdXMYCSABKAsyLS5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 40) = "ZXF1ZXN0LkVtcHR5TWVzc2FnZUgAElIKGWFjdGl2ZV9wcmVzZW50YXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 41) = "Zm9jdXMYCiABKAsyLS5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXF1ZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 42) = "LkVtcHR5TWVzc2FnZUgAElIKGWFjdGl2ZV9hbm5vdW5jZW1lbnRfZm9jdXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 43) = "CyABKAsyLS5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXF1ZXN0LkVtcHR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 44) = "TWVzc2FnZUgAEkgKD2ZvY3VzZWRfdHJpZ2dlchgMIAEoCzItLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 45) = "QVBJX3YxX1BsYXlsaXN0X1JlcXVlc3QuRW1wdHlNZXNzYWdlSAASVAobYWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 46) = "aXZlX3ByZXNlbnRhdGlvbl90cmlnZ2VyGA0gASgLMi0ucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 47) = "djFfUGxheWxpc3RfUmVxdWVzdC5FbXB0eU1lc3NhZ2VIABJUChthY3RpdmVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 48) = "YW5ub3VuY2VtZW50X3RyaWdnZXIYDiABKAsyLS5ydi5kYXRhLkFQSV92MV9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 49) = "bGF5bGlzdF9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgAEk0KFGZvY3VzZWRfbmV4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 50) = "dF90cmlnZ2VyGA8gASgLMi0ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 51) = "dWVzdC5FbXB0eU1lc3NhZ2VIABJRChhmb2N1c2VkX3ByZXZpb3VzX3RyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 52) = "ZXIYECABKAsyLS5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXF1ZXN0LkVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 53) = "cHR5TWVzc2FnZUgAElkKIGFjdGl2ZV9wcmVzZW50YXRpb25fbmV4dF90cmln";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 54) = "Z2VyGBEgASgLMi0ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVxdWVzdC5F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 55) = "bXB0eU1lc3NhZ2VIABJZCiBhY3RpdmVfYW5ub3VuY2VtZW50X25leHRfdHJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 56) = "Z2dlchgSIAEoCzItLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0X1JlcXVlc3Qu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 57) = "RW1wdHlNZXNzYWdlSAASXQokYWN0aXZlX3ByZXNlbnRhdGlvbl9wcmV2aW91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 58) = "c190cmlnZ2VyGBMgASgLMi0ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 59) = "dWVzdC5FbXB0eU1lc3NhZ2VIABJdCiRhY3RpdmVfYW5ub3VuY2VtZW50X3By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 60) = "ZXZpb3VzX3RyaWdnZXIYFCABKAsyLS5ydi5kYXRhLkFQSV92MV9QbGF5bGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 61) = "dF9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgAEj4KCGlkX2ZvY3VzGBUgASgLMiou";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 62) = "cnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVxdWVzdC5JZE1lc3NhZ2VIABJA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 63) = "CgppZF90cmlnZ2VyGBYgASgLMioucnYuZGF0YS5BUElfdjFfUGxheWxpc3Rf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 64) = "UmVxdWVzdC5JZE1lc3NhZ2VIABJFCg9pZF9uZXh0X3RyaWdnZXIYFyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 65) = "Ki5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXF1ZXN0LklkTWVzc2FnZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 66) = "EkkKE2lkX3ByZXZpb3VzX3RyaWdnZXIYGCABKAsyKi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 67) = "MV9QbGF5bGlzdF9SZXF1ZXN0LklkTWVzc2FnZUgAEk4KFWZvY3VzZWRfaW5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 68) = "ZXhfdHJpZ2dlchgZIAEoCzItLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0X1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 69) = "cXVlc3QuSW5kZXhNZXNzYWdlSAASWgohYWN0aXZlX3ByZXNlbnRhdGlvbl9p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 70) = "bmRleF90cmlnZ2VyGBogASgLMi0ucnYuZGF0YS5BUElfdjFfUGxheWxpc3Rf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 71) = "UmVxdWVzdC5JbmRleE1lc3NhZ2VIABJaCiFhY3RpdmVfYW5ub3VuY2VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 72) = "X2luZGV4X3RyaWdnZXIYGyABKAsyLS5ydi5kYXRhLkFQSV92MV9QbGF5bGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 73) = "dF9SZXF1ZXN0LkluZGV4TWVzc2FnZUgAEkAKCmlkX3VwZGF0ZXMYHCABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 74) = "Ki5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXF1ZXN0LklkTWVzc2FnZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 75) = "ElMKHWFjdGl2ZV9wcmVzZW50YXRpb25fdGh1bWJuYWlsGB0gASgLMioucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 76) = "ZGF0YS5BUElfdjFfUGxheWxpc3RfUmVxdWVzdC5UaHVtYm5haWxIABJTCh1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 77) = "Y3RpdmVfYW5ub3VuY2VtZW50X3RodW1ibmFpbBgeIAEoCzIqLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 78) = "QVBJX3YxX1BsYXlsaXN0X1JlcXVlc3QuVGh1bWJuYWlsSAASRQoMZm9jdXNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 79) = "ZF9uZXh0GB8gASgLMi0ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVxdWVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 80) = "dC5FbXB0eU1lc3NhZ2VIABJJChBmb2N1c2VkX3ByZXZpb3VzGCAgASgLMi0u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 81) = "cnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVxdWVzdC5FbXB0eU1lc3NhZ2VI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 82) = "ABJECgxpZF90aHVtYm5haWwYISABKAsyLC5ydi5kYXRhLkFQSV92MV9QbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 83) = "bGlzdF9SZXF1ZXN0LklkVGh1bWJuYWlsSAASUAoSdGltZWxpbmVfb3BlcmF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 84) = "aW9uGCIgASgLMjIucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVxdWVzdC5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 85) = "aW1lbGluZU9wZXJhdGlvbkgAEnsKL2FjdGl2ZV9wbGF5bGlzdF9wcmVzZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 86) = "YXRpb25fdGltZWxpbmVfb3BlcmF0aW9uGCMgASgLMkAucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 87) = "djFfUGxheWxpc3RfUmVxdWVzdC5BY3RpdmVQbGF5bGlzdFRpbWVsaW5lT3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 88) = "cmF0aW9uSAASewovYWN0aXZlX3BsYXlsaXN0X2Fubm91bmNlbWVudF90aW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 89) = "bGluZV9vcGVyYXRpb24YJCABKAsyQC5ydi5kYXRhLkFQSV92MV9QbGF5bGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 90) = "dF9SZXF1ZXN0LkFjdGl2ZVBsYXlsaXN0VGltZWxpbmVPcGVyYXRpb25IABJw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 91) = "CiNmb2N1c2VkX3BsYXlsaXN0X3RpbWVsaW5lX29wZXJhdGlvbhglIAEoCzJB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 92) = "LnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0X1JlcXVlc3QuRm9jdXNlZFBsYXls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 93) = "aXN0VGltZWxpbmVPcGVyYXRpb25IABJ1CixhY3RpdmVfcGxheWxpc3RfcHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 94) = "c2VudGF0aW9uX3RpbWVsaW5lX3N0YXR1cxgmIAEoCzI9LnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 95) = "X3YxX1BsYXlsaXN0X1JlcXVlc3QuQWN0aXZlUGxheWxpc3RUaW1lbGluZVN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 96) = "YXR1c0gAEnUKLGFjdGl2ZV9wbGF5bGlzdF9hbm5vdW5jZW1lbnRfdGltZWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 97) = "bmVfc3RhdHVzGCcgASgLMj0ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 98) = "dWVzdC5BY3RpdmVQbGF5bGlzdFRpbWVsaW5lU3RhdHVzSAASagogZm9jdXNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 99) = "ZF9wbGF5bGlzdF90aW1lbGluZV9zdGF0dXMYKCABKAsyPi5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 100) = "SV92MV9QbGF5bGlzdF9SZXF1ZXN0LkZvY3VzZWRQbGF5bGlzdFRpbWVsaW5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 101) = "U3RhdHVzSAAaCwoJUGxheWxpc3RzGloKDkNyZWF0ZVBsYXlsaXN0EgwKBG5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 102) = "bWUYASABKAkSOgoEdHlwZRgCIAEoDjIsLnJ2LmRhdGEuQVBJX3YxX1BsYXls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 103) = "aXN0LkFQSV92MV9QbGF5bGlzdFR5cGUaEwoRR2V0QWN0aXZlUGxheWxpc3Qa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 104) = "GQoLR2V0UGxheWxpc3QSCgoCaWQYASABKAkaRgoLUHV0UGxheWxpc3QSCgoC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 105) = "aWQYASABKAkSKwoFaXRlbXMYAiADKAsyHC5ydi5kYXRhLkFQSV92MV9QbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 106) = "bGlzdEl0ZW0aZAoMUG9zdFBsYXlsaXN0EgoKAmlkGAEgASgJEgwKBG5hbWUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 107) = "AiABKAkSOgoEdHlwZRgDIAEoDjIsLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 108) = "LkFQSV92MV9QbGF5bGlzdFR5cGUacQoJVGh1bWJuYWlsEg0KBWluZGV4GAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 109) = "ASgNEhEKCWN1ZV9pbmRleBgCIAEoDRIPCgdxdWFsaXR5GAMgASgFEjEKDGNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 110) = "bnRlbnRfdHlwZRgEIAEoDjIbLnJ2LmRhdGEuQVBJX3YxX0NvbnRlbnRUeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 111) = "Gn8KC0lkVGh1bWJuYWlsEgoKAmlkGAEgASgJEg0KBWluZGV4GAIgASgNEhEK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 112) = "CWN1ZV9pbmRleBgDIAEoDRIPCgdxdWFsaXR5GAQgASgFEjEKDGNvbnRlbnRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 113) = "dHlwZRgFIAEoDjIbLnJ2LmRhdGEuQVBJX3YxX0NvbnRlbnRUeXBlGg4KDEVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 114) = "cHR5TWVzc2FnZRoXCglJZE1lc3NhZ2USCgoCaWQYASABKAkaMAoMSW5kZXhN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 115) = "ZXNzYWdlEg0KBWluZGV4GAEgASgNEhEKCWN1ZV9pbmRleBgCIAEoDRpkChFU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 116) = "aW1lbGluZU9wZXJhdGlvbhIKCgJpZBgBIAEoCRINCgVpbmRleBgCIAEoDRI0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 117) = "CglvcGVyYXRpb24YAyABKA4yIS5ydi5kYXRhLkFQSV92MV9UaW1lbGluZU9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 118) = "ZXJhdGlvbhpmCh9BY3RpdmVQbGF5bGlzdFRpbWVsaW5lT3BlcmF0aW9uEg0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 119) = "BWluZGV4GAEgASgNEjQKCW9wZXJhdGlvbhgCIAEoDjIhLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 120) = "X3YxX1RpbWVsaW5lT3BlcmF0aW9uGmcKIEZvY3VzZWRQbGF5bGlzdFRpbWVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 121) = "aW5lT3BlcmF0aW9uEg0KBWluZGV4GAEgASgNEjQKCW9wZXJhdGlvbhgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 122) = "DjIhLnJ2LmRhdGEuQVBJX3YxX1RpbWVsaW5lT3BlcmF0aW9uGi0KHEFjdGl2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 123) = "ZVBsYXlsaXN0VGltZWxpbmVTdGF0dXMSDQoFaW5kZXgYASABKA0aLgodRm9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 124) = "dXNlZFBsYXlsaXN0VGltZWxpbmVTdGF0dXMSDQoFaW5kZXgYASABKA1CCQoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 125) = "UmVxdWVzdCKwIgoYQVBJX3YxX1BsYXlsaXN0X1Jlc3BvbnNlEkAKCXBsYXls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 126) = "aXN0cxgBIAEoCzIrLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0X1Jlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 127) = "LlBsYXlsaXN0c0gAEksKD2NyZWF0ZV9wbGF5bGlzdBgCIAEoCzIwLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 128) = "dGEuQVBJX3YxX1BsYXlsaXN0X1Jlc3BvbnNlLkNyZWF0ZVBsYXlsaXN0SAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 129) = "RQoMZ2V0X3BsYXlsaXN0GAMgASgLMi0ucnYuZGF0YS5BUElfdjFfUGxheWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 130) = "c3RfUmVzcG9uc2UuR2V0UGxheWxpc3RIABJFCgxwdXRfcGxheWxpc3QYBCAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 131) = "KAsyLS5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXNwb25zZS5QdXRQbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 132) = "bGlzdEgAEkcKDXBvc3RfcGxheWxpc3QYBSABKAsyLi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 133) = "MV9QbGF5bGlzdF9SZXNwb25zZS5Qb3N0UGxheWxpc3RIABJSChNnZXRfYWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 134) = "aXZlX3BsYXlsaXN0GAYgASgLMjMucnYuZGF0YS5BUElfdjFfUGxheWxpc3Rf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 135) = "UmVzcG9uc2UuR2V0QWN0aXZlUGxheWxpc3RIABJHCgdmb2N1c2VkGAcgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 136) = "MjQucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVzcG9uc2UuR2V0Rm9jdXNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 137) = "ZFBsYXlsaXN0SAASRAoKbmV4dF9mb2N1cxgIIAEoCzIuLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 138) = "X3YxX1BsYXlsaXN0X1Jlc3BvbnNlLkVtcHR5TWVzc2FnZUgAEkgKDnByZXZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 139) = "b3VzX2ZvY3VzGAkgASgLMi4ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 140) = "cG9uc2UuRW1wdHlNZXNzYWdlSAASUwoZYWN0aXZlX3ByZXNlbnRhdGlvbl9m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 141) = "b2N1cxgKIAEoCzIuLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0X1Jlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 142) = "LkVtcHR5TWVzc2FnZUgAElMKGWFjdGl2ZV9hbm5vdW5jZW1lbnRfZm9jdXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 143) = "CyABKAsyLi5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXNwb25zZS5FbXB0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 144) = "eU1lc3NhZ2VIABJJCg9mb2N1c2VkX3RyaWdnZXIYDCABKAsyLi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 145) = "LkFQSV92MV9QbGF5bGlzdF9SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJVChth";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 146) = "Y3RpdmVfcHJlc2VudGF0aW9uX3RyaWdnZXIYDSABKAsyLi5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 147) = "SV92MV9QbGF5bGlzdF9SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJVChthY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 148) = "dmVfYW5ub3VuY2VtZW50X3RyaWdnZXIYDiABKAsyLi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 149) = "MV9QbGF5bGlzdF9SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJOChRmb2N1c2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 150) = "X25leHRfdHJpZ2dlchgPIAEoCzIuLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 151) = "X1Jlc3BvbnNlLkVtcHR5TWVzc2FnZUgAElIKGGZvY3VzZWRfcHJldmlvdXNf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 152) = "dHJpZ2dlchgQIAEoCzIuLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0X1Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 153) = "bnNlLkVtcHR5TWVzc2FnZUgAEloKIGFjdGl2ZV9wcmVzZW50YXRpb25fbmV4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 154) = "dF90cmlnZ2VyGBEgASgLMi4ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 155) = "cG9uc2UuRW1wdHlNZXNzYWdlSAASWgogYWN0aXZlX2Fubm91bmNlbWVudF9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 156) = "ZXh0X3RyaWdnZXIYEiABKAsyLi5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 157) = "ZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJeCiRhY3RpdmVfcHJlc2VudGF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 158) = "X3ByZXZpb3VzX3RyaWdnZXIYEyABKAsyLi5ydi5kYXRhLkFQSV92MV9QbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 159) = "bGlzdF9SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJeCiRhY3RpdmVfYW5ub3Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 160) = "Y2VtZW50X3ByZXZpb3VzX3RyaWdnZXIYFCABKAsyLi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 161) = "MV9QbGF5bGlzdF9SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJCCghpZF9mb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 162) = "cxgVIAEoCzIuLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0X1Jlc3BvbnNlLkVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 163) = "cHR5TWVzc2FnZUgAEkQKCmlkX3RyaWdnZXIYFiABKAsyLi5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 164) = "SV92MV9QbGF5bGlzdF9SZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJJCg9pZF9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 165) = "ZXh0X3RyaWdnZXIYFyABKAsyLi5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 166) = "ZXNwb25zZS5FbXB0eU1lc3NhZ2VIABJNChNpZF9wcmV2aW91c190cmlnZ2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 167) = "GBggASgLMi4ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVzcG9uc2UuRW1w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 168) = "dHlNZXNzYWdlSAASTwoVZm9jdXNlZF9pbmRleF90cmlnZ2VyGBkgASgLMi4u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 169) = "cnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVzcG9uc2UuRW1wdHlNZXNzYWdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 170) = "SAASWwohYWN0aXZlX3ByZXNlbnRhdGlvbl9pbmRleF90cmlnZ2VyGBogASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 171) = "Mi4ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVzcG9uc2UuRW1wdHlNZXNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 172) = "YWdlSAASWwohYWN0aXZlX2Fubm91bmNlbWVudF9pbmRleF90cmlnZ2VyGBsg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 173) = "ASgLMi4ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVzcG9uc2UuRW1wdHlN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 174) = "ZXNzYWdlSAASRAoKaWRfdXBkYXRlcxgcIAEoCzIuLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 175) = "X1BsYXlsaXN0X1Jlc3BvbnNlLkVtcHR5TWVzc2FnZUgAElQKHWFjdGl2ZV9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 176) = "cmVzZW50YXRpb25fdGh1bWJuYWlsGB0gASgLMisucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 177) = "UGxheWxpc3RfUmVzcG9uc2UuVGh1bWJuYWlsSAASVAodYWN0aXZlX2Fubm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 178) = "bmNlbWVudF90aHVtYm5haWwYHiABKAsyKy5ydi5kYXRhLkFQSV92MV9QbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 179) = "bGlzdF9SZXNwb25zZS5UaHVtYm5haWxIABJRCgxmb2N1c2VkX25leHQYHyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 180) = "KAsyOS5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXNwb25zZS5HZXRQcm94";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 181) = "aW1hbFBsYXlsaXN0SXRlbUgAElUKEGZvY3VzZWRfcHJldmlvdXMYICABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 182) = "OS5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXNwb25zZS5HZXRQcm94aW1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 183) = "bFBsYXlsaXN0SXRlbUgAEkMKDGlkX3RodW1ibmFpbBghIAEoCzIrLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 184) = "dGEuQVBJX3YxX1BsYXlsaXN0X1Jlc3BvbnNlLlRodW1ibmFpbEgAElEKEnRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 185) = "bWVsaW5lX29wZXJhdGlvbhgiIAEoCzIzLnJ2LmRhdGEuQVBJX3YxX1BsYXls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 186) = "aXN0X1Jlc3BvbnNlLlRpbWVsaW5lT3BlcmF0aW9uSAASfAovYWN0aXZlX3Bs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 187) = "YXlsaXN0X3ByZXNlbnRhdGlvbl90aW1lbGluZV9vcGVyYXRpb24YIyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 188) = "QS5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXNwb25zZS5BY3RpdmVQbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 189) = "bGlzdFRpbWVsaW5lT3BlcmF0aW9uSAASfAovYWN0aXZlX3BsYXlsaXN0X2Fu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 190) = "bm91bmNlbWVudF90aW1lbGluZV9vcGVyYXRpb24YJCABKAsyQS5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 191) = "LkFQSV92MV9QbGF5bGlzdF9SZXNwb25zZS5BY3RpdmVQbGF5bGlzdFRpbWVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 192) = "aW5lT3BlcmF0aW9uSAAScQojZm9jdXNlZF9wbGF5bGlzdF90aW1lbGluZV9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 193) = "cGVyYXRpb24YJSABKAsyQi5ydi5kYXRhLkFQSV92MV9QbGF5bGlzdF9SZXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 194) = "b25zZS5Gb2N1c2VkUGxheWxpc3RUaW1lbGluZU9wZXJhdGlvbkgAEnYKLGFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 195) = "dGl2ZV9wbGF5bGlzdF9wcmVzZW50YXRpb25fdGltZWxpbmVfc3RhdHVzGCYg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 196) = "ASgLMj4ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVzcG9uc2UuQWN0aXZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 197) = "UGxheWxpc3RUaW1lbGluZVN0YXR1c0gAEnYKLGFjdGl2ZV9wbGF5bGlzdF9h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 198) = "bm5vdW5jZW1lbnRfdGltZWxpbmVfc3RhdHVzGCcgASgLMj4ucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 199) = "UElfdjFfUGxheWxpc3RfUmVzcG9uc2UuQWN0aXZlUGxheWxpc3RUaW1lbGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 200) = "ZVN0YXR1c0gAEmsKIGZvY3VzZWRfcGxheWxpc3RfdGltZWxpbmVfc3RhdHVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 201) = "GCggASgLMj8ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVzcG9uc2UuRm9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 202) = "dXNlZFBsYXlsaXN0VGltZWxpbmVTdGF0dXNIABo4CglQbGF5bGlzdHMSKwoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 203) = "cGxheWxpc3RzGAEgAygLMhgucnYuZGF0YS5BUElfdjFfUGxheWxpc3QaPAoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 204) = "Q3JlYXRlUGxheWxpc3QSKgoIcGxheWxpc3QYASABKAsyGC5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 205) = "SV92MV9QbGF5bGlzdBqCAQoRR2V0QWN0aXZlUGxheWxpc3QSNQoMcHJlc2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 206) = "dGF0aW9uGAEgASgLMh8ucnYuZGF0YS5BUElfdjFfUGxheWxpc3RBbmRJdGVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 207) = "EjYKDWFubm91bmNlbWVudHMYAiABKAsyHy5ydi5kYXRhLkFQSV92MV9QbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 208) = "bGlzdEFuZEl0ZW0aYgoLR2V0UGxheWxpc3QSJgoCaWQYASABKAsyGi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 209) = "YXRhLkFQSV92MV9JZGVudGlmaWVyEisKBWl0ZW1zGAIgAygLMhwucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 210) = "YS5BUElfdjFfUGxheWxpc3RJdGVtGg0KC1B1dFBsYXlsaXN0GjoKDFBvc3RQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 211) = "bGF5bGlzdBIqCghwbGF5bGlzdBgBIAEoCzIYLnJ2LmRhdGEuQVBJX3YxX1Bs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 212) = "YXlsaXN0GkcKEkdldEZvY3VzZWRQbGF5bGlzdBIxCghwbGF5bGlzdBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 213) = "CzIfLnJ2LmRhdGEuQVBJX3YxX1BsYXlsaXN0QW5kSXRlbRpDChdHZXRQcm94";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 214) = "aW1hbFBsYXlsaXN0SXRlbRIoCgRpdGVtGAEgASgLMhoucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 215) = "djFfSWRlbnRpZmllchpMCglUaHVtYm5haWwSDAoEZGF0YRgBIAEoDBIxCgxj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 216) = "b250ZW50X3R5cGUYAiABKA4yGy5ydi5kYXRhLkFQSV92MV9Db250ZW50VHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 217) = "ZRoOCgxFbXB0eU1lc3NhZ2UaEwoRVGltZWxpbmVPcGVyYXRpb24aIQofQWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 218) = "aXZlUGxheWxpc3RUaW1lbGluZU9wZXJhdGlvbhoiCiBGb2N1c2VkUGxheWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 219) = "c3RUaW1lbGluZU9wZXJhdGlvbhpIChxBY3RpdmVQbGF5bGlzdFRpbWVsaW5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 220) = "U3RhdHVzEhIKCmlzX3J1bm5pbmcYASABKAgSFAoMY3VycmVudF90aW1lGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 221) = "ASgBGkkKHUZvY3VzZWRQbGF5bGlzdFRpbWVsaW5lU3RhdHVzEhIKCmlzX3J1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 222) = "bm5pbmcYASABKAgSFAoMY3VycmVudF90aW1lGAIgASgBQgoKCFJlc3BvbnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 223) = "QjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray225<string>, string>(ref buffer, 224) = "AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray225<string>, string>(in buffer, 225))), new FileDescriptor[7]
		{
			WrappersReflection.Descriptor,
			ProApiV1ColorReflection.Descriptor,
			ProApiV1ContentTypeReflection.Descriptor,
			ProApiV1IdentifierReflection.Descriptor,
			ProApiV1PresentationPlaylistItemReflection.Descriptor,
			ProApiV1PresentationReflection.Descriptor,
			ProApiV1TimelineOperationReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Playlist), API_v1_Playlist.Parser, new string[3] { "Id", "Type", "Children" }, null, new System.Type[1] { typeof(API_v1_Playlist.Types.API_v1_PlaylistType) }, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_PlaylistAndItem), API_v1_PlaylistAndItem.Parser, new string[3] { "Playlist", "Item", "PlaylistItem" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_PlaylistItem), API_v1_PlaylistItem.Parser, new string[9] { "Id", "Type", "IsHidden", "IsPco", "HeaderColor", "Duration", "PresentationInfo", "TargetUuid", "Destination" }, null, new System.Type[1] { typeof(API_v1_PlaylistItem.Types.API_v1_PlaylistItemType) }, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request), API_v1_Playlist_Request.Parser, new string[40]
			{
				"Playlists", "CreatePlaylist", "GetPlaylist", "PutPlaylist", "PostPlaylist", "GetActivePlaylist", "Focused", "NextFocus", "PreviousFocus", "ActivePresentationFocus",
				"ActiveAnnouncementFocus", "FocusedTrigger", "ActivePresentationTrigger", "ActiveAnnouncementTrigger", "FocusedNextTrigger", "FocusedPreviousTrigger", "ActivePresentationNextTrigger", "ActiveAnnouncementNextTrigger", "ActivePresentationPreviousTrigger", "ActiveAnnouncementPreviousTrigger",
				"IdFocus", "IdTrigger", "IdNextTrigger", "IdPreviousTrigger", "FocusedIndexTrigger", "ActivePresentationIndexTrigger", "ActiveAnnouncementIndexTrigger", "IdUpdates", "ActivePresentationThumbnail", "ActiveAnnouncementThumbnail",
				"FocusedNext", "FocusedPrevious", "IdThumbnail", "TimelineOperation", "ActivePlaylistPresentationTimelineOperation", "ActivePlaylistAnnouncementTimelineOperation", "FocusedPlaylistTimelineOperation", "ActivePlaylistPresentationTimelineStatus", "ActivePlaylistAnnouncementTimelineStatus", "FocusedPlaylistTimelineStatus"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[16]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.Playlists), API_v1_Playlist_Request.Types.Playlists.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.CreatePlaylist), API_v1_Playlist_Request.Types.CreatePlaylist.Parser, new string[2] { "Name", "Type" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.GetActivePlaylist), API_v1_Playlist_Request.Types.GetActivePlaylist.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.GetPlaylist), API_v1_Playlist_Request.Types.GetPlaylist.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.PutPlaylist), API_v1_Playlist_Request.Types.PutPlaylist.Parser, new string[2] { "Id", "Items" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.PostPlaylist), API_v1_Playlist_Request.Types.PostPlaylist.Parser, new string[3] { "Id", "Name", "Type" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.Thumbnail), API_v1_Playlist_Request.Types.Thumbnail.Parser, new string[4] { "Index", "CueIndex", "Quality", "ContentType" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.IdThumbnail), API_v1_Playlist_Request.Types.IdThumbnail.Parser, new string[5] { "Id", "Index", "CueIndex", "Quality", "ContentType" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.EmptyMessage), API_v1_Playlist_Request.Types.EmptyMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.IdMessage), API_v1_Playlist_Request.Types.IdMessage.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.IndexMessage), API_v1_Playlist_Request.Types.IndexMessage.Parser, new string[2] { "Index", "CueIndex" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.TimelineOperation), API_v1_Playlist_Request.Types.TimelineOperation.Parser, new string[3] { "Id", "Index", "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.ActivePlaylistTimelineOperation), API_v1_Playlist_Request.Types.ActivePlaylistTimelineOperation.Parser, new string[2] { "Index", "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.FocusedPlaylistTimelineOperation), API_v1_Playlist_Request.Types.FocusedPlaylistTimelineOperation.Parser, new string[2] { "Index", "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.ActivePlaylistTimelineStatus), API_v1_Playlist_Request.Types.ActivePlaylistTimelineStatus.Parser, new string[1] { "Index" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Request.Types.FocusedPlaylistTimelineStatus), API_v1_Playlist_Request.Types.FocusedPlaylistTimelineStatus.Parser, new string[1] { "Index" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response), API_v1_Playlist_Response.Parser, new string[40]
			{
				"Playlists", "CreatePlaylist", "GetPlaylist", "PutPlaylist", "PostPlaylist", "GetActivePlaylist", "Focused", "NextFocus", "PreviousFocus", "ActivePresentationFocus",
				"ActiveAnnouncementFocus", "FocusedTrigger", "ActivePresentationTrigger", "ActiveAnnouncementTrigger", "FocusedNextTrigger", "FocusedPreviousTrigger", "ActivePresentationNextTrigger", "ActiveAnnouncementNextTrigger", "ActivePresentationPreviousTrigger", "ActiveAnnouncementPreviousTrigger",
				"IdFocus", "IdTrigger", "IdNextTrigger", "IdPreviousTrigger", "FocusedIndexTrigger", "ActivePresentationIndexTrigger", "ActiveAnnouncementIndexTrigger", "IdUpdates", "ActivePresentationThumbnail", "ActiveAnnouncementThumbnail",
				"FocusedNext", "FocusedPrevious", "IdThumbnail", "TimelineOperation", "ActivePlaylistPresentationTimelineOperation", "ActivePlaylistAnnouncementTimelineOperation", "FocusedPlaylistTimelineOperation", "ActivePlaylistPresentationTimelineStatus", "ActivePlaylistAnnouncementTimelineStatus", "FocusedPlaylistTimelineStatus"
			}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[15]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.Playlists), API_v1_Playlist_Response.Types.Playlists.Parser, new string[1] { "Playlists_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.CreatePlaylist), API_v1_Playlist_Response.Types.CreatePlaylist.Parser, new string[1] { "Playlist" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.GetActivePlaylist), API_v1_Playlist_Response.Types.GetActivePlaylist.Parser, new string[2] { "Presentation", "Announcements" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.GetPlaylist), API_v1_Playlist_Response.Types.GetPlaylist.Parser, new string[2] { "Id", "Items" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.PutPlaylist), API_v1_Playlist_Response.Types.PutPlaylist.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.PostPlaylist), API_v1_Playlist_Response.Types.PostPlaylist.Parser, new string[1] { "Playlist" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.GetFocusedPlaylist), API_v1_Playlist_Response.Types.GetFocusedPlaylist.Parser, new string[1] { "Playlist" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.GetProximalPlaylistItem), API_v1_Playlist_Response.Types.GetProximalPlaylistItem.Parser, new string[1] { "Item" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.Thumbnail), API_v1_Playlist_Response.Types.Thumbnail.Parser, new string[2] { "Data", "ContentType" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.EmptyMessage), API_v1_Playlist_Response.Types.EmptyMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.TimelineOperation), API_v1_Playlist_Response.Types.TimelineOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.ActivePlaylistTimelineOperation), API_v1_Playlist_Response.Types.ActivePlaylistTimelineOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.FocusedPlaylistTimelineOperation), API_v1_Playlist_Response.Types.FocusedPlaylistTimelineOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.ActivePlaylistTimelineStatus), API_v1_Playlist_Response.Types.ActivePlaylistTimelineStatus.Parser, new string[2] { "IsRunning", "CurrentTime" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Playlist_Response.Types.FocusedPlaylistTimelineStatus), API_v1_Playlist_Response.Types.FocusedPlaylistTimelineStatus.Parser, new string[2] { "IsRunning", "CurrentTime" }, null, null, null, null)
			})
		}));
	}
}
