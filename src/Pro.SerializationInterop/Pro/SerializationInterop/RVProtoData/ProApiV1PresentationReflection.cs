using System;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1PresentationReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1PresentationReflection()
	{
		_003C_003Ey__InlineArray139<string> buffer = default(_003C_003Ey__InlineArray139<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 0) = "Chpwcm9BcGlWMVByZXNlbnRhdGlvbi5wcm90bxIHcnYuZGF0YRoeZ29vZ2xl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 1) = "L3Byb3RvYnVmL3dyYXBwZXJzLnByb3RvGhNwcm9BcGlWMUNvbG9yLnByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 2) = "Ghlwcm9BcGlWMUNvbnRlbnRUeXBlLnByb3RvGhhwcm9BcGlWMUlkZW50aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 3) = "ZXIucHJvdG8aEnByb0FwaVYxU2l6ZS5wcm90bxofcHJvQXBpVjFUaW1lbGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 4) = "ZU9wZXJhdGlvbi5wcm90bxoKdXVpZC5wcm90byKDAQoRQVBJX3YxX1NsaWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 5) = "SW5kZXgSDQoFaW5kZXgYASABKA0SMwoPcHJlc2VudGF0aW9uX2lkGAIgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 6) = "MhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmllchISCgp0b3RhbF9jdWVzGAMg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 7) = "ASgNEhYKDnJlbWFpbmluZ19jdWVzGAQgASgNIoUGChNBUElfdjFfUHJlc2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 8) = "dGF0aW9uEiYKAmlkGAEgASgLMhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmll";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 9) = "chI3CgZncm91cHMYAiADKAsyJy5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 10) = "b24uU2xpZGVHcm91cBIUCgxoYXNfdGltZWxpbmUYAyABKAgSGQoRcHJlc2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 11) = "dGF0aW9uX3BhdGgYBCABKAkSPQoLZGVzdGluYXRpb24YBSABKA4yKC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 12) = "YXRhLkFQSV92MV9QcmVzZW50YXRpb24uRGVzdGluYXRpb24SPgoMYXJyYW5n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 13) = "ZW1lbnRzGAYgAygLMigucnYuZGF0YS5BUElfdjFfUHJlc2VudGF0aW9uLkFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 14) = "cmFuZ2VtZW50EhsKE2N1cnJlbnRfYXJyYW5nZW1lbnQYByABKAkSDAoEdHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 15) = "ZRgIIAEoCRIVCg1pc19hdXRob3JpemVkGAkgASgIEhIKCnRvdGFsX2N1ZXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 16) = "CiABKA0a9wEKClNsaWRlR3JvdXASDAoEbmFtZRgBIAEoCRIkCgVjb2xvchgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 17) = "IAEoCzIVLnJ2LmRhdGEuQVBJX3YxX0NvbG9yEj0KBnNsaWRlcxgDIAMoCzIt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 18) = "LnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbi5TbGlkZUdyb3VwLlNsaWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 19) = "EgwKBHV1aWQYBCABKAkaaAoFU2xpZGUSDwoHZW5hYmxlZBgBIAEoCBINCgVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 20) = "b3RlcxgCIAEoCRIMCgR0ZXh0GAMgASgJEg0KBWxhYmVsGAUgASgJEiIKBHNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 21) = "emUYBiABKAsyFC5ydi5kYXRhLkFQSV92MV9TaXplGlkKC0FycmFuZ2VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 22) = "EiYKAmlkGAEgASgLMhoucnYuZGF0YS5BUElfdjFfSWRlbnRpZmllchIOCgZn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 23) = "cm91cHMYAiADKAkSEgoKdG90YWxfY3VlcxgDIAEoDSIyCgtEZXN0aW5hdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 24) = "bhIQCgxwcmVzZW50YXRpb24QABIRCg1hbm5vdW5jZW1lbnRzEAEi/hUKG0FQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 25) = "SV92MV9QcmVzZW50YXRpb25fUmVxdWVzdBI9CgZhY3RpdmUYASABKAsyKy5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 26) = "di5kYXRhLkFQSV92MV9QcmVzZW50YXRpb25fUmVxdWVzdC5BY3RpdmVIABJE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 27) = "Cgdmb2N1c2VkGAIgASgLMjEucnYuZGF0YS5BUElfdjFfUHJlc2VudGF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 28) = "X1JlcXVlc3QuRW1wdHlNZXNzYWdlSAASRgoLc2xpZGVfaW5kZXgYAyABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 29) = "Ly5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRpb25fUmVxdWVzdC5TbGlkZUlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 30) = "ZGV4SAASRgoLY2hvcmRfY2hhcnQYBCABKAsyLy5ydi5kYXRhLkFQSV92MV9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 31) = "cmVzZW50YXRpb25fUmVxdWVzdC5DaG9yZENoYXJ0SAASVQoTY2hvcmRfY2hh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 32) = "cnRfdXBkYXRlcxgFIAEoCzI2LnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 33) = "bl9SZXF1ZXN0LkNob3JkQ2hhcnRVcGRhdGVzSAASSQoMcHJlc2VudGF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 34) = "GAYgASgLMjEucnYuZGF0YS5BUElfdjFfUHJlc2VudGF0aW9uX1JlcXVlc3Qu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 35) = "UHJlc2VudGF0aW9uSAASVgoTZGVsZXRlX3ByZXNlbnRhdGlvbhgHIAEoCzI3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 36) = "LnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXF1ZXN0LkRlbGV0ZVBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 37) = "ZXNlbnRhdGlvbkgAElQKEnRpbWVsaW5lX29wZXJhdGlvbhgIIAEoCzI2LnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 38) = "LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXF1ZXN0LlRpbWVsaW5lT3Bl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 39) = "cmF0aW9uSAASegomYWN0aXZlX3ByZXNlbnRhdGlvbl90aW1lbGluZV9vcGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 40) = "YXRpb24YCSABKAsySC5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRpb25fUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 41) = "dWVzdC5BY3RpdmVQcmVzZW50YXRpb25UaW1lbGluZU9wZXJhdGlvbkgAEnwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 42) = "J2ZvY3VzZWRfcHJlc2VudGF0aW9uX3RpbWVsaW5lX29wZXJhdGlvbhgKIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 43) = "CzJJLnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXF1ZXN0LkZvY3Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 44) = "ZWRQcmVzZW50YXRpb25UaW1lbGluZU9wZXJhdGlvbkgAEnQKI2FjdGl2ZV9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 45) = "cmVzZW50YXRpb25fdGltZWxpbmVfc3RhdHVzGAsgASgLMkUucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 46) = "UElfdjFfUHJlc2VudGF0aW9uX1JlcXVlc3QuQWN0aXZlUHJlc2VudGF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 47) = "VGltZWxpbmVTdGF0dXNIABJ2CiRmb2N1c2VkX3ByZXNlbnRhdGlvbl90aW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 48) = "bGluZV9zdGF0dXMYDCABKAsyRi5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 49) = "b25fUmVxdWVzdC5Gb2N1c2VkUHJlc2VudGF0aW9uVGltZWxpbmVTdGF0dXNI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 50) = "ABJDCgl0aHVtYm5haWwYDSABKAsyLi5ydi5kYXRhLkFQSV92MV9QcmVzZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 51) = "YXRpb25fUmVxdWVzdC5UaHVtYm5haWxIABJCCgVmb2N1cxgOIAEoCzIxLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 52) = "LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXF1ZXN0LkZvY3VzTWVzc2Fn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 53) = "ZUgAEkYKB3RyaWdnZXIYDyABKAsyMy5ydi5kYXRhLkFQSV92MV9QcmVzZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 54) = "YXRpb25fUmVxdWVzdC5UcmlnZ2VyTWVzc2FnZUgAGggKBkFjdGl2ZRoMCgpT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 55) = "bGlkZUluZGV4Gh0KCkNob3JkQ2hhcnQSDwoHcXVhbGl0eRgBIAEoBRoTChFD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 56) = "aG9yZENoYXJ0VXBkYXRlcxorCgxQcmVzZW50YXRpb24SGwoEdXVpZBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 57) = "CzINLnJ2LmRhdGEuVVVJRBoxChJEZWxldGVQcmVzZW50YXRpb24SGwoEdXVp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 58) = "ZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBpmChFUaW1lbGluZU9wZXJhdGlvbhIb";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 59) = "CgR1dWlkGAEgASgLMg0ucnYuZGF0YS5VVUlEEjQKCW9wZXJhdGlvbhgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 60) = "DjIhLnJ2LmRhdGEuQVBJX3YxX1RpbWVsaW5lT3BlcmF0aW9uGlsKI0FjdGl2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 61) = "ZVByZXNlbnRhdGlvblRpbWVsaW5lT3BlcmF0aW9uEjQKCW9wZXJhdGlvbhgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 62) = "IAEoDjIhLnJ2LmRhdGEuQVBJX3YxX1RpbWVsaW5lT3BlcmF0aW9uGlwKJEZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 63) = "Y3VzZWRQcmVzZW50YXRpb25UaW1lbGluZU9wZXJhdGlvbhI0CglvcGVyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 64) = "b24YASABKA4yIS5ydi5kYXRhLkFQSV92MV9UaW1lbGluZU9wZXJhdGlvbhoi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 65) = "CiBBY3RpdmVQcmVzZW50YXRpb25UaW1lbGluZVN0YXR1cxojCiFGb2N1c2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 66) = "UHJlc2VudGF0aW9uVGltZWxpbmVTdGF0dXMafwoJVGh1bWJuYWlsEhsKBHV1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 67) = "aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSEQoJY3VlX2luZGV4GAIgASgNEg8K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 68) = "B3F1YWxpdHkYAyABKAUSMQoMY29udGVudF90eXBlGAQgASgOMhsucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 69) = "YS5BUElfdjFfQ29udGVudFR5cGUaDgoMRW1wdHlNZXNzYWdlGv0BCgxGb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 70) = "c01lc3NhZ2USQQoEbmV4dBgBIAEoCzIxLnJ2LmRhdGEuQVBJX3YxX1ByZXNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 71) = "bnRhdGlvbl9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgAEkUKCHByZXZpb3VzGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 72) = "ASgLMjEucnYuZGF0YS5BUElfdjFfUHJlc2VudGF0aW9uX1JlcXVlc3QuRW1w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 73) = "dHlNZXNzYWdlSAASQwoGYWN0aXZlGAMgASgLMjEucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 74) = "UHJlc2VudGF0aW9uX1JlcXVlc3QuRW1wdHlNZXNzYWdlSAASDgoEdXVpZBgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 75) = "IAEoCUgAQg4KDFByZXNlbnRhdGlvbhqMBAoOVHJpZ2dlck1lc3NhZ2USRAoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 76) = "Zm9jdXNlZBgBIAEoCzIxLnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 77) = "ZXF1ZXN0LkVtcHR5TWVzc2FnZUgAEkMKBmFjdGl2ZRgCIAEoCzIxLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 78) = "dGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 79) = "EiwKBHV1aWQYAyABKAsyHC5nb29nbGUucHJvdG9idWYuU3RyaW5nVmFsdWVI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 80) = "ABJCCgVmaXJzdBgEIAEoCzIxLnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 81) = "bl9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgBEkEKBG5leHQYBSABKAsyMS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 82) = "YXRhLkFQSV92MV9QcmVzZW50YXRpb25fUmVxdWVzdC5FbXB0eU1lc3NhZ2VI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 83) = "ARJFCghwcmV2aW91cxgGIAEoCzIxLnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 84) = "dGlvbl9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgBEi0KBWluZGV4GAcgASgLMhwu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 85) = "Z29vZ2xlLnByb3RvYnVmLlVJbnQzMlZhbHVlSAESLQoFZ3JvdXAYCCABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 86) = "HC5nb29nbGUucHJvdG9idWYuU3RyaW5nVmFsdWVIAUIOCgxQcmVzZW50YXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 87) = "b25CBQoDQ3VlQgkKB1JlcXVlc3QiwBEKHEFQSV92MV9QcmVzZW50YXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 88) = "UmVzcG9uc2USPgoGYWN0aXZlGAEgASgLMiwucnYuZGF0YS5BUElfdjFfUHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 89) = "c2VudGF0aW9uX1Jlc3BvbnNlLkFjdGl2ZUgAEkcKC3NsaWRlX2luZGV4GAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 90) = "ASgLMjAucnYuZGF0YS5BUElfdjFfUHJlc2VudGF0aW9uX1Jlc3BvbnNlLlNs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 91) = "aWRlSW5kZXhIABJHCgtjaG9yZF9jaGFydBgDIAEoCzIwLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 92) = "X3YxX1ByZXNlbnRhdGlvbl9SZXNwb25zZS5DaG9yZENoYXJ0SAASVQoSY2hv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 93) = "cmRfY2hhcnRfdXBkYXRlGAQgASgLMjcucnYuZGF0YS5BUElfdjFfUHJlc2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 94) = "dGF0aW9uX1Jlc3BvbnNlLkNob3JkQ2hhcnRVcGRhdGVzSAASSgoMcHJlc2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 95) = "dGF0aW9uGAUgASgLMjIucnYuZGF0YS5BUElfdjFfUHJlc2VudGF0aW9uX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 96) = "c3BvbnNlLlByZXNlbnRhdGlvbkgAElcKE2RlbGV0ZV9wcmVzZW50YXRpb24Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 97) = "BiABKAsyOC5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRpb25fUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 98) = "RGVsZXRlUHJlc2VudGF0aW9uSAASWQoUdHJpZ2dlcl9wcmVzZW50YXRpb24Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 99) = "ByABKAsyOS5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRpb25fUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 100) = "VHJpZ2dlclByZXNlbnRhdGlvbkgAEkcKC3RyaWdnZXJfY3VlGAggASgLMjAu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 101) = "cnYuZGF0YS5BUElfdjFfUHJlc2VudGF0aW9uX1Jlc3BvbnNlLlRyaWdnZXJD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 102) = "dWVIABJVChJ0aW1lbGluZV9vcGVyYXRpb24YCSABKAsyNy5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 103) = "SV92MV9QcmVzZW50YXRpb25fUmVzcG9uc2UuVGltZWxpbmVPcGVyYXRpb25I";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 104) = "ABJ7CiZhY3RpdmVfcHJlc2VudGF0aW9uX3RpbWVsaW5lX29wZXJhdGlvbhgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 105) = "IAEoCzJJLnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXNwb25zZS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 106) = "Y3RpdmVQcmVzZW50YXRpb25UaW1lbGluZU9wZXJhdGlvbkgAEn0KJ2ZvY3Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 107) = "ZWRfcHJlc2VudGF0aW9uX3RpbWVsaW5lX29wZXJhdGlvbhgLIAEoCzJKLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 108) = "LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXNwb25zZS5Gb2N1c2VkUHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 109) = "c2VudGF0aW9uVGltZWxpbmVPcGVyYXRpb25IABJ1CiNhY3RpdmVfcHJlc2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 110) = "dGF0aW9uX3RpbWVsaW5lX3N0YXR1cxgMIAEoCzJGLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 111) = "X1ByZXNlbnRhdGlvbl9SZXNwb25zZS5BY3RpdmVQcmVzZW50YXRpb25UaW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 112) = "bGluZVN0YXR1c0gAEncKJGZvY3VzZWRfcHJlc2VudGF0aW9uX3RpbWVsaW5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 113) = "X3N0YXR1cxgNIAEoCzJHLnJ2LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 114) = "ZXNwb25zZS5Gb2N1c2VkUHJlc2VudGF0aW9uVGltZWxpbmVTdGF0dXNIABJE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 115) = "Cgl0aHVtYm5haWwYDiABKAsyLy5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 116) = "b25fUmVzcG9uc2UuVGh1bWJuYWlsSAASQAoHZm9jdXNlZBgPIAEoCzItLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 117) = "LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXNwb25zZS5Gb2N1c2VkSAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 118) = "QwoFZm9jdXMYECABKAsyMi5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 119) = "UmVzcG9uc2UuRW1wdHlNZXNzYWdlSAASRQoHdHJpZ2dlchgRIAEoCzIyLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 120) = "LmRhdGEuQVBJX3YxX1ByZXNlbnRhdGlvbl9SZXNwb25zZS5FbXB0eU1lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 121) = "Z2VIABo8CgZBY3RpdmUSMgoMcHJlc2VudGF0aW9uGAEgASgLMhwucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 122) = "YS5BUElfdjFfUHJlc2VudGF0aW9uGkQKClNsaWRlSW5kZXgSNgoScHJlc2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 123) = "dGF0aW9uX2luZGV4GAEgASgLMhoucnYuZGF0YS5BUElfdjFfU2xpZGVJbmRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 124) = "eBohCgpDaG9yZENoYXJ0EhMKC2Nob3JkX2NoYXJ0GAEgASgMGhMKEUNob3Jk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 125) = "Q2hhcnRVcGRhdGVzGkIKDFByZXNlbnRhdGlvbhIyCgxwcmVzZW50YXRpb24Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 126) = "ASABKAsyHC5ydi5kYXRhLkFQSV92MV9QcmVzZW50YXRpb24aFAoSRGVsZXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 127) = "UHJlc2VudGF0aW9uGhUKE1RyaWdnZXJQcmVzZW50YXRpb24aDAoKVHJpZ2dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 128) = "ckN1ZRoTChFUaW1lbGluZU9wZXJhdGlvbholCiNBY3RpdmVQcmVzZW50YXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 129) = "b25UaW1lbGluZU9wZXJhdGlvbhomCiRGb2N1c2VkUHJlc2VudGF0aW9uVGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 130) = "ZWxpbmVPcGVyYXRpb24aTAogQWN0aXZlUHJlc2VudGF0aW9uVGltZWxpbmVT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 131) = "dGF0dXMSEgoKaXNfcnVubmluZxgBIAEoCBIUCgxjdXJyZW50X3RpbWUYAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 132) = "KAEaTQohRm9jdXNlZFByZXNlbnRhdGlvblRpbWVsaW5lU3RhdHVzEhIKCmlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 133) = "X3J1bm5pbmcYASABKAgSFAoMY3VycmVudF90aW1lGAIgASgBGkwKCVRodW1i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 134) = "bmFpbBIMCgRkYXRhGAEgASgMEjEKDGNvbnRlbnRfdHlwZRgCIAEoDjIbLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 135) = "LmRhdGEuQVBJX3YxX0NvbnRlbnRUeXBlGjEKB0ZvY3VzZWQSJgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 136) = "KAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyGg4KDEVtcHR5TWVzc2Fn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 137) = "ZUIKCghSZXNwb25zZUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray139<string>, string>(ref buffer, 138) = "LlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray139<string>, string>(in buffer, 139))), new FileDescriptor[7]
		{
			WrappersReflection.Descriptor,
			ProApiV1ColorReflection.Descriptor,
			ProApiV1ContentTypeReflection.Descriptor,
			ProApiV1IdentifierReflection.Descriptor,
			ProApiV1SizeReflection.Descriptor,
			ProApiV1TimelineOperationReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_SlideIndex), API_v1_SlideIndex.Parser, new string[4] { "Index", "PresentationId", "TotalCues", "RemainingCues" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(API_v1_Presentation), API_v1_Presentation.Parser, new string[10] { "Id", "Groups", "HasTimeline", "PresentationPath", "Destination", "Arrangements", "CurrentArrangement", "Type", "IsAuthorized", "TotalCues" }, null, new System.Type[1] { typeof(API_v1_Presentation.Types.Destination) }, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation.Types.SlideGroup), API_v1_Presentation.Types.SlideGroup.Parser, new string[4] { "Name", "Color", "Slides", "Uuid" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(API_v1_Presentation.Types.SlideGroup.Types.Slide), API_v1_Presentation.Types.SlideGroup.Types.Slide.Parser, new string[5] { "Enabled", "Notes", "Text", "Label", "Size" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation.Types.Arrangement), API_v1_Presentation.Types.Arrangement.Parser, new string[3] { "Id", "Groups", "TotalCues" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request), API_v1_Presentation_Request.Parser, new string[15]
			{
				"Active", "Focused", "SlideIndex", "ChordChart", "ChordChartUpdates", "Presentation", "DeletePresentation", "TimelineOperation", "ActivePresentationTimelineOperation", "FocusedPresentationTimelineOperation",
				"ActivePresentationTimelineStatus", "FocusedPresentationTimelineStatus", "Thumbnail", "Focus", "Trigger"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[15]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.Active), API_v1_Presentation_Request.Types.Active.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.SlideIndex), API_v1_Presentation_Request.Types.SlideIndex.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.ChordChart), API_v1_Presentation_Request.Types.ChordChart.Parser, new string[1] { "Quality" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.ChordChartUpdates), API_v1_Presentation_Request.Types.ChordChartUpdates.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.Presentation), API_v1_Presentation_Request.Types.Presentation.Parser, new string[1] { "Uuid" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.DeletePresentation), API_v1_Presentation_Request.Types.DeletePresentation.Parser, new string[1] { "Uuid" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.TimelineOperation), API_v1_Presentation_Request.Types.TimelineOperation.Parser, new string[2] { "Uuid", "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.ActivePresentationTimelineOperation), API_v1_Presentation_Request.Types.ActivePresentationTimelineOperation.Parser, new string[1] { "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.FocusedPresentationTimelineOperation), API_v1_Presentation_Request.Types.FocusedPresentationTimelineOperation.Parser, new string[1] { "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.ActivePresentationTimelineStatus), API_v1_Presentation_Request.Types.ActivePresentationTimelineStatus.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.FocusedPresentationTimelineStatus), API_v1_Presentation_Request.Types.FocusedPresentationTimelineStatus.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.Thumbnail), API_v1_Presentation_Request.Types.Thumbnail.Parser, new string[4] { "Uuid", "CueIndex", "Quality", "ContentType" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.EmptyMessage), API_v1_Presentation_Request.Types.EmptyMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.FocusMessage), API_v1_Presentation_Request.Types.FocusMessage.Parser, new string[4] { "Next", "Previous", "Active", "Uuid" }, new string[1] { "Presentation" }, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Request.Types.TriggerMessage), API_v1_Presentation_Request.Types.TriggerMessage.Parser, new string[8] { "Focused", "Active", "Uuid", "First", "Next", "Previous", "Index", "Group" }, new string[2] { "Presentation", "Cue" }, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response), API_v1_Presentation_Response.Parser, new string[17]
			{
				"Active", "SlideIndex", "ChordChart", "ChordChartUpdate", "Presentation", "DeletePresentation", "TriggerPresentation", "TriggerCue", "TimelineOperation", "ActivePresentationTimelineOperation",
				"FocusedPresentationTimelineOperation", "ActivePresentationTimelineStatus", "FocusedPresentationTimelineStatus", "Thumbnail", "Focused", "Focus", "Trigger"
			}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[16]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.Active), API_v1_Presentation_Response.Types.Active.Parser, new string[1] { "Presentation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.SlideIndex), API_v1_Presentation_Response.Types.SlideIndex.Parser, new string[1] { "PresentationIndex" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.ChordChart), API_v1_Presentation_Response.Types.ChordChart.Parser, new string[1] { "ChordChart_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.ChordChartUpdates), API_v1_Presentation_Response.Types.ChordChartUpdates.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.Presentation), API_v1_Presentation_Response.Types.Presentation.Parser, new string[1] { "Presentation_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.DeletePresentation), API_v1_Presentation_Response.Types.DeletePresentation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.TriggerPresentation), API_v1_Presentation_Response.Types.TriggerPresentation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.TriggerCue), API_v1_Presentation_Response.Types.TriggerCue.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.TimelineOperation), API_v1_Presentation_Response.Types.TimelineOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.ActivePresentationTimelineOperation), API_v1_Presentation_Response.Types.ActivePresentationTimelineOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.FocusedPresentationTimelineOperation), API_v1_Presentation_Response.Types.FocusedPresentationTimelineOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.ActivePresentationTimelineStatus), API_v1_Presentation_Response.Types.ActivePresentationTimelineStatus.Parser, new string[2] { "IsRunning", "CurrentTime" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.FocusedPresentationTimelineStatus), API_v1_Presentation_Response.Types.FocusedPresentationTimelineStatus.Parser, new string[2] { "IsRunning", "CurrentTime" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.Thumbnail), API_v1_Presentation_Response.Types.Thumbnail.Parser, new string[2] { "Data", "ContentType" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.Focused), API_v1_Presentation_Response.Types.Focused.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Presentation_Response.Types.EmptyMessage), API_v1_Presentation_Response.Types.EmptyMessage.Parser, null, null, null, null, null)
			})
		}));
	}
}
