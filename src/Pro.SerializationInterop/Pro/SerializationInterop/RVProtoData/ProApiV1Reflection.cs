using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1Reflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1Reflection()
	{
		_003C_003Ey__InlineArray85<string> buffer = default(_003C_003Ey__InlineArray85<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 0) = "Cg5wcm9BcGlWMS5wcm90bxIHcnYuZGF0YRoacHJvQXBpVjFBbm5vdW5jZW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 1) = "bnQucHJvdG8aE3Byb0FwaVYxQXVkaW8ucHJvdG8aFXByb0FwaVYxQ2FwdHVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 2) = "ZS5wcm90bxoTcHJvQXBpVjFDbGVhci5wcm90bxobcHJvQXBpVjFFcnJvclJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 3) = "c3BvbnNlLnByb3RvGhRwcm9BcGlWMUdyb3Vwcy5wcm90bxoScHJvQXBpVjFM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 4) = "aW5rLnByb3RvGhVwcm9BcGlWMUxpYnJhcnkucHJvdG8aE3Byb0FwaVYxTG9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 5) = "a3MucHJvdG8aE3Byb0FwaVYxTWFjcm8ucHJvdG8aE3Byb0FwaVYxTWFza3Mu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 6) = "cHJvdG8aE3Byb0FwaVYxTWVkaWEucHJvdG8aFXByb0FwaVYxTWVzc2FnZS5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 7) = "cm90bxobcHJvQXBpVjFNaXNjZWxsYW5lb3VzLnByb3RvGhZwcm9BcGlWMVBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 8) = "YXlsaXN0LnByb3RvGhVwcm9BcGlWMVByZXJvbGwucHJvdG8aGnByb0FwaVYx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 9) = "UHJlc2VudGF0aW9uLnByb3RvGhJwcm9BcGlWMVByb3AucHJvdG8aE3Byb0Fw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 10) = "aVYxU3RhZ2UucHJvdG8aFHByb0FwaVYxU3RhdHVzLnByb3RvGhNwcm9BcGlW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 11) = "MVRoZW1lLnByb3RvGhNwcm9BcGlWMVRpbWVyLnByb3RvGhdwcm9BcGlWMVRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 12) = "YW5zcG9ydC5wcm90bxoVcHJvQXBpVjFUcmlnZ2VyLnByb3RvGhlwcm9BcGlW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 13) = "MVZpZGVvSW5wdXRzLnByb3RvItEYCg1OZXR3b3JrQVBJX3YxEi8KBmFjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 14) = "bhgBIAEoCzIdLnJ2LmRhdGEuTmV0d29ya0FQSV92MS5BY3Rpb25IABqDGAoG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 15) = "QWN0aW9uEjYKDWF1ZGlvX3JlcXVlc3QYASABKAsyHS5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 16) = "MV9BdWRpb19SZXF1ZXN0SAASOgoPY2FwdHVyZV9yZXF1ZXN0GAIgASgLMh8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 17) = "cnYuZGF0YS5BUElfdjFfQ2FwdHVyZV9SZXF1ZXN0SAASOQoQY2xlYXJpbmdf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 18) = "cmVxdWVzdBgDIAEoCzIdLnJ2LmRhdGEuQVBJX3YxX0NsZWFyX1JlcXVlc3RI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 19) = "ABI4Cg5ncm91cHNfcmVxdWVzdBgEIAEoCzIeLnJ2LmRhdGEuQVBJX3YxX0dy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 20) = "b3Vwc19SZXF1ZXN0SAASNAoMbGlua19yZXF1ZXN0GAUgASgLMhwucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 21) = "YS5BUElfdjFfTGlua19SZXF1ZXN0SAASOgoPbGlicmFyeV9yZXF1ZXN0GAYg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 22) = "ASgLMh8ucnYuZGF0YS5BUElfdjFfTGlicmFyeV9SZXF1ZXN0SAASNgoNbG9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 23) = "a3NfcmVxdWVzdBgHIAEoCzIdLnJ2LmRhdGEuQVBJX3YxX0xvb2tzX1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 24) = "c3RIABI2Cg1tYWNyb19yZXF1ZXN0GAggASgLMh0ucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 25) = "TWFjcm9fUmVxdWVzdEgAEjYKDW1hc2tzX3JlcXVlc3QYCSABKAsyHS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 26) = "YXRhLkFQSV92MV9NYXNrc19SZXF1ZXN0SAASNgoNbWVkaWFfcmVxdWVzdBgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 27) = "IAEoCzIdLnJ2LmRhdGEuQVBJX3YxX01lZGlhX1JlcXVlc3RIABI6Cg9tZXNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 28) = "YWdlX3JlcXVlc3QYCyABKAsyHy5ydi5kYXRhLkFQSV92MV9NZXNzYWdlX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 29) = "cXVlc3RIABJGChVtaXNjZWxsYW5lb3VzX3JlcXVlc3QYDCABKAsyJS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 30) = "YXRhLkFQSV92MV9NaXNjZWxsYW5lb3VzX1JlcXVlc3RIABI8ChBwbGF5bGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 31) = "dF9yZXF1ZXN0GA0gASgLMiAucnYuZGF0YS5BUElfdjFfUGxheWxpc3RfUmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 32) = "dWVzdEgAEjoKD3ByZXJvbGxfcmVxdWVzdBgOIAEoCzIfLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 33) = "X3YxX1ByZXJvbGxfUmVxdWVzdEgAEkQKFHByZXNlbnRhdGlvbl9yZXF1ZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 34) = "GA8gASgLMiQucnYuZGF0YS5BUElfdjFfUHJlc2VudGF0aW9uX1JlcXVlc3RI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 35) = "ABI0Cgxwcm9wX3JlcXVlc3QYECABKAsyHC5ydi5kYXRhLkFQSV92MV9Qcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 36) = "X1JlcXVlc3RIABI2Cg1zdGFnZV9yZXF1ZXN0GBEgASgLMh0ucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 37) = "UElfdjFfU3RhZ2VfUmVxdWVzdEgAEjgKDnN0YXR1c19yZXF1ZXN0GBIgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 38) = "Mh4ucnYuZGF0YS5BUElfdjFfU3RhdHVzX1JlcXVlc3RIABI2Cg10aGVtZV9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 39) = "ZXF1ZXN0GBMgASgLMh0ucnYuZGF0YS5BUElfdjFfVGhlbWVfUmVxdWVzdEgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 40) = "EjYKDXRpbWVyX3JlcXVlc3QYFCABKAsyHS5ydi5kYXRhLkFQSV92MV9UaW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 41) = "cl9SZXF1ZXN0SAASPgoRdHJhbnNwb3J0X3JlcXVlc3QYFSABKAsyIS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 42) = "YXRhLkFQSV92MV9UcmFuc3BvcnRfUmVxdWVzdEgAEjoKD3RyaWdnZXJfcmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 43) = "dWVzdBgWIAEoCzIfLnJ2LmRhdGEuQVBJX3YxX1RyaWdnZXJfUmVxdWVzdEgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 44) = "EkQKFHZpZGVvX2lucHV0c19yZXF1ZXN0GBcgASgLMiQucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 45) = "djFfVmlkZW9fSW5wdXRzX1JlcXVlc3RIABJEChRhbm5vdW5jZW1lbnRfcmVx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 46) = "dWVzdBgYIAEoCzIkLnJ2LmRhdGEuQVBJX3YxX0Fubm91bmNlbWVudF9SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 47) = "ZXN0SAASOAoOYXVkaW9fcmVzcG9uc2UYZSABKAsyHi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 48) = "MV9BdWRpb19SZXNwb25zZUgBEjwKEGNhcHR1cmVfcmVzcG9uc2UYZiABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 49) = "IC5ydi5kYXRhLkFQSV92MV9DYXB0dXJlX1Jlc3BvbnNlSAESOwoRY2xlYXJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 50) = "bmdfcmVzcG9uc2UYZyABKAsyHi5ydi5kYXRhLkFQSV92MV9DbGVhcl9SZXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 51) = "b25zZUgBEjoKD2dyb3Vwc19yZXNwb25zZRhoIAEoCzIfLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 52) = "X3YxX0dyb3Vwc19SZXNwb25zZUgBEjYKDWxpbmtfcmVzcG9uc2UYaSABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 53) = "HS5ydi5kYXRhLkFQSV92MV9MaW5rX1Jlc3BvbnNlSAESPAoQbGlicmFyeV9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 54) = "ZXNwb25zZRhqIAEoCzIgLnJ2LmRhdGEuQVBJX3YxX0xpYnJhcnlfUmVzcG9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 55) = "c2VIARI4Cg5sb29rc19yZXNwb25zZRhrIAEoCzIeLnJ2LmRhdGEuQVBJX3Yx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 56) = "X0xvb2tzX1Jlc3BvbnNlSAESOAoObWFjcm9fcmVzcG9uc2UYbCABKAsyHi5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 57) = "di5kYXRhLkFQSV92MV9NYWNyb19SZXNwb25zZUgBEjgKDm1hc2tzX3Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 58) = "bnNlGG0gASgLMh4ucnYuZGF0YS5BUElfdjFfTWFza3NfUmVzcG9uc2VIARI4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 59) = "Cg5tZWRpYV9yZXNwb25zZRhuIAEoCzIeLnJ2LmRhdGEuQVBJX3YxX01lZGlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 60) = "X1Jlc3BvbnNlSAESPAoQbWVzc2FnZV9yZXNwb25zZRhvIAEoCzIgLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 61) = "dGEuQVBJX3YxX01lc3NhZ2VfUmVzcG9uc2VIARJIChZtaXNjZWxsYW5lb3Vz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 62) = "X3Jlc3BvbnNlGHAgASgLMiYucnYuZGF0YS5BUElfdjFfTWlzY2VsbGFuZW91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 63) = "c19SZXNwb25zZUgBEj4KEXBsYXlsaXN0X3Jlc3BvbnNlGHEgASgLMiEucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 64) = "ZGF0YS5BUElfdjFfUGxheWxpc3RfUmVzcG9uc2VIARI8ChBwcmVyb2xsX3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 65) = "c3BvbnNlGHIgASgLMiAucnYuZGF0YS5BUElfdjFfUHJlcm9sbF9SZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 66) = "ZUgBEkYKFXByZXNlbnRhdGlvbl9yZXNwb25zZRhzIAEoCzIlLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 67) = "QVBJX3YxX1ByZXNlbnRhdGlvbl9SZXNwb25zZUgBEjYKDXByb3BfcmVzcG9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 68) = "c2UYdCABKAsyHS5ydi5kYXRhLkFQSV92MV9Qcm9wX1Jlc3BvbnNlSAESOAoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 69) = "c3RhZ2VfcmVzcG9uc2UYdSABKAsyHi5ydi5kYXRhLkFQSV92MV9TdGFnZV9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 70) = "ZXNwb25zZUgBEjoKD3N0YXR1c19yZXNwb25zZRh2IAEoCzIfLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 71) = "QVBJX3YxX1N0YXR1c19SZXNwb25zZUgBEjgKDnRoZW1lX3Jlc3BvbnNlGHcg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 72) = "ASgLMh4ucnYuZGF0YS5BUElfdjFfVGhlbWVfUmVzcG9uc2VIARI4Cg50aW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 73) = "cl9yZXNwb25zZRh4IAEoCzIeLnJ2LmRhdGEuQVBJX3YxX1RpbWVyX1Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 74) = "bnNlSAESQAoSdHJhbnNwb3J0X3Jlc3BvbnNlGHkgASgLMiIucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 75) = "UElfdjFfVHJhbnNwb3J0X1Jlc3BvbnNlSAESPAoQdHJpZ2dlcl9yZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 76) = "ZRh6IAEoCzIgLnJ2LmRhdGEuQVBJX3YxX1RyaWdnZXJfUmVzcG9uc2VIARJG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 77) = "ChV2aWRlb19pbnB1dHNfcmVzcG9uc2UYeyABKAsyJS5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 78) = "MV9WaWRlb19JbnB1dHNfUmVzcG9uc2VIARJGChVhbm5vdW5jZW1lbnRfcmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 79) = "cG9uc2UYfCABKAsyJS5ydi5kYXRhLkFQSV92MV9Bbm5vdW5jZW1lbnRfUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 80) = "cG9uc2VIARI5Cg5lcnJvcl9yZXNwb25zZRjIASABKAsyHi5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 81) = "SV92MV9FcnJvcl9SZXNwb25zZUgBEhwKEXVwZGF0ZV9pZGVudGlmaWVyGMkB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 82) = "IAEoCUgCQgkKB1JlcXVlc3RCCgoIUmVzcG9uc2VCGwoZU3RyZWFtaW5nVXBk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 83) = "YXRlSWRlbnRpZmllckIJCgdDb21tYW5kQjT4AQGqAiRQcm8uU2VyaWFsaXph";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray85<string>, string>(ref buffer, 84) = "dGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray85<string>, string>(in buffer, 85))), new FileDescriptor[25]
		{
			ProApiV1AnnouncementReflection.Descriptor,
			ProApiV1AudioReflection.Descriptor,
			ProApiV1CaptureReflection.Descriptor,
			ProApiV1ClearReflection.Descriptor,
			ProApiV1ErrorResponseReflection.Descriptor,
			ProApiV1GroupsReflection.Descriptor,
			ProApiV1LinkReflection.Descriptor,
			ProApiV1LibraryReflection.Descriptor,
			ProApiV1LooksReflection.Descriptor,
			ProApiV1MacroReflection.Descriptor,
			ProApiV1MasksReflection.Descriptor,
			ProApiV1MediaReflection.Descriptor,
			ProApiV1MessageReflection.Descriptor,
			ProApiV1MiscellaneousReflection.Descriptor,
			ProApiV1PlaylistReflection.Descriptor,
			ProApiV1PrerollReflection.Descriptor,
			ProApiV1PresentationReflection.Descriptor,
			ProApiV1PropReflection.Descriptor,
			ProApiV1StageReflection.Descriptor,
			ProApiV1StatusReflection.Descriptor,
			ProApiV1ThemeReflection.Descriptor,
			ProApiV1TimerReflection.Descriptor,
			ProApiV1TransportReflection.Descriptor,
			ProApiV1TriggerReflection.Descriptor,
			ProApiV1VideoInputsReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(NetworkAPI_v1), NetworkAPI_v1.Parser, new string[1] { "Action" }, new string[1] { "Command" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(NetworkAPI_v1.Types.Action), NetworkAPI_v1.Types.Action.Parser, new string[50]
				{
					"AudioRequest", "CaptureRequest", "ClearingRequest", "GroupsRequest", "LinkRequest", "LibraryRequest", "LooksRequest", "MacroRequest", "MasksRequest", "MediaRequest",
					"MessageRequest", "MiscellaneousRequest", "PlaylistRequest", "PrerollRequest", "PresentationRequest", "PropRequest", "StageRequest", "StatusRequest", "ThemeRequest", "TimerRequest",
					"TransportRequest", "TriggerRequest", "VideoInputsRequest", "AnnouncementRequest", "AudioResponse", "CaptureResponse", "ClearingResponse", "GroupsResponse", "LinkResponse", "LibraryResponse",
					"LooksResponse", "MacroResponse", "MasksResponse", "MediaResponse", "MessageResponse", "MiscellaneousResponse", "PlaylistResponse", "PrerollResponse", "PresentationResponse", "PropResponse",
					"StageResponse", "StatusResponse", "ThemeResponse", "TimerResponse", "TransportResponse", "TriggerResponse", "VideoInputsResponse", "AnnouncementResponse", "ErrorResponse", "UpdateIdentifier"
				}, new string[3] { "Request", "Response", "StreamingUpdateIdentifier" }, null, null, null)
			})
		}));
	}
}
