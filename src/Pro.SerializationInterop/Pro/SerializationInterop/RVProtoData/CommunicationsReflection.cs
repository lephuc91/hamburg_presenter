using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class CommunicationsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static CommunicationsReflection()
	{
		_003C_003Ey__InlineArray95<string> buffer = default(_003C_003Ey__InlineArray95<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 0) = "ChRjb21tdW5pY2F0aW9ucy5wcm90bxIHcnYuZGF0YRoTY3VzdG9tT3B0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 1) = "cy5wcm90bxoOaW50UmFuZ2UucHJvdG8aCnV1aWQucHJvdG8i7BUKE0NvbW11";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 2) = "bmljYXRpb25EZXZpY2USGQoCaWQYASABKAsyDS5ydi5kYXRhLlVVSUQSDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 3) = "bmFtZRgCIAEoCRI8CgtkZXZpY2VfdHlwZRgDIAEoDjInLnJ2LmRhdGEuQ29t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 4) = "bXVuaWNhdGlvbkRldmljZS5EZXZpY2VUeXBlEjcKCGJlaGF2aW9yGAQgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 5) = "MiUucnYuZGF0YS5Db21tdW5pY2F0aW9uRGV2aWNlLkJlaGF2aW9yEhEKCWNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 6) = "bm5lY3RlZBgFIAEoCBIWCg5hdXRvX3JlY29ubmVjdBgGIAEoCBI9CgZzZXJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 7) = "YWwYByABKAsyKy5ydi5kYXRhLkNvbW11bmljYXRpb25EZXZpY2UuU2VyaWFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 8) = "SGFyZHdhcmVIABI/Cgt0Y3BfbmV0d29yaxgIIAEoCzIoLnJ2LmRhdGEuQ29t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 9) = "bXVuaWNhdGlvbkRldmljZS5UQ1BIYXJkd2FyZUgAEj8KC3VkcF9uZXR3b3Jr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 10) = "GAkgASgLMigucnYuZGF0YS5Db21tdW5pY2F0aW9uRGV2aWNlLlVEUEhhcmR3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 11) = "YXJlSAASPQoGYXJ0bmV0GAogASgLMisucnYuZGF0YS5Db21tdW5pY2F0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 12) = "RGV2aWNlLkFydG5ldEhhcmR3YXJlSAASOQoEbWlkaRgLIAEoCzIpLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 13) = "dGEuQ29tbXVuaWNhdGlvbkRldmljZS5NSURJSGFyZHdhcmVIABIzCgdvcHRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 14) = "b25zGAwgAygLMiIucnYuZGF0YS5Db21tdW5pY2F0aW9uRGV2aWNlT3B0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 15) = "Gv8HCg5TZXJpYWxIYXJkd2FyZRIUCgxpbnRlcmZhY2VfaWQYASABKAkSDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 16) = "bmFtZRgCIAEoCRJACgVzcGVlZBgDIAEoDjIxLnJ2LmRhdGEuQ29tbXVuaWNh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 17) = "dGlvbkRldmljZS5TZXJpYWxIYXJkd2FyZS5TcGVlZBJHCglkYXRhX2JpdHMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 18) = "BCABKA4yNC5ydi5kYXRhLkNvbW11bmljYXRpb25EZXZpY2UuU2VyaWFsSGFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 19) = "ZHdhcmUuRGF0YUJpdHMSQgoGcGFyaXR5GAUgASgOMjIucnYuZGF0YS5Db21t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 20) = "dW5pY2F0aW9uRGV2aWNlLlNlcmlhbEhhcmR3YXJlLlBhcml0eRJHCglzdG9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 21) = "X2JpdHMYBiABKA4yNC5ydi5kYXRhLkNvbW11bmljYXRpb25EZXZpY2UuU2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 22) = "aWFsSGFyZHdhcmUuU3RvcEJpdHMSPgoEaGZjaRgHIAEoDjIwLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 23) = "Q29tbXVuaWNhdGlvbkRldmljZS5TZXJpYWxIYXJkd2FyZS5IRkNJEj4KBGhm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 24) = "Y28YCCABKA4yMC5ydi5kYXRhLkNvbW11bmljYXRpb25EZXZpY2UuU2VyaWFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 25) = "SGFyZHdhcmUuSEZDTyKCAgoFU3BlZWQSDgoKU1BFRURfMTIwMBAAEg4KClNQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 26) = "RUVEXzE4MDAQARIOCgpTUEVFRF8yNDAwEAISDgoKU1BFRURfNDgwMBADEg4K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 27) = "ClNQRUVEXzcyMDAQBBIOCgpTUEVFRF85NjAwEAUSDwoLU1BFRURfMTQ0MDAQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 28) = "BxIPCgtTUEVFRF8xOTIwMBAIEg8KC1NQRUVEXzI4ODAwEAkSDwoLU1BFRURf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 29) = "Mzg0MDAQChIPCgtTUEVFRF81NzYwMBALEg8KC1NQRUVEXzYyNTAwEAwSDwoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 30) = "U1BFRURfNzY4MDAQDRIQCgxTUEVFRF8xMTUyMDAQDhIQCgxTUEVFRF8yMzA0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 31) = "MDAQDyJOCghEYXRhQml0cxIPCgtEQVRBX0JJVFNfNRAAEg8KC0RBVEFfQklU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 32) = "U182EAESDwoLREFUQV9CSVRTXzcQAhIPCgtEQVRBX0JJVFNfOBADIjoKBlBh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 33) = "cml0eRIPCgtQQVJJVFlfTk9ORRAAEg4KClBBUklUWV9PREQQARIPCgtQQVJJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 34) = "VFlfRVZFThACIiwKCFN0b3BCaXRzEg8KC1NUT1BfQklUU18xEAASDwoLU1RP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 35) = "UF9CSVRTXzIQASIxCgRIRkNJEg0KCUhGQ0lfTk9ORRAAEgwKCEhGQ0lfUlRT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 36) = "EAESDAoISEZDSV9EVFIQAiI/CgRIRkNPEg0KCUhGQ09fTk9ORRAAEgwKCEhG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 37) = "Q09fQ1RTEAESDAoISEZDT19EU1IQAhIMCghIRkNPX0NBUhADGr4BCgtUQ1BI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 38) = "YXJkd2FyZRIUCgxpbnRlcmZhY2VfaWQYASABKAkSDAoEbmFtZRgCIAEoCRIP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 39) = "CgdhZGRyZXNzGAMgASgJEgwKBHBvcnQYBCABKA0SOwoEbW9kZRgFIAEoDjIt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 40) = "LnJ2LmRhdGEuQ29tbXVuaWNhdGlvbkRldmljZS5UQ1BIYXJkd2FyZS5Nb2Rl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 41) = "Ii8KBE1vZGUSEwoPTU9ERV9DT05ORUNUX1RPEAASEgoOTU9ERV9BQ0NFUFRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 42) = "T04QARrnAQoLVURQSGFyZHdhcmUSFAoMaW50ZXJmYWNlX2lkGAEgASgJEgwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 43) = "BG5hbWUYAiABKAkSDwoHYWRkcmVzcxgDIAEoCRIMCgRwb3J0GAQgASgNEjsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 44) = "BG1vZGUYBSABKA4yLS5ydi5kYXRhLkNvbW11bmljYXRpb25EZXZpY2UuVURQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 45) = "SGFyZHdhcmUuTW9kZSJYCgRNb2RlEhAKDE1PREVfQ09OTkVDVBAAEg8KC01P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 46) = "REVfTElTVEVOEAESGQoVTU9ERV9NVUxUSUNBU1RfTElTVEVOEAISEgoOTU9E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 47) = "RV9CUk9BRENBU1QQAxoQCg5BcnRuZXRIYXJkd2FyZRoOCgxNSURJSGFyZHdh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 48) = "cmUigAUKCkRldmljZVR5cGUSEwoPREVWSUNFX1RZUEVfRE1YEAASFAoQREVW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 49) = "SUNFX1RZUEVfTUlESRABEhMKD0RFVklDRV9UWVBFX0FNUBACEhQKEERFVklD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 50) = "RV9UWVBFX0NJVFAQAxIcChhERVZJQ0VfVFlQRV9HTE9CQUxfQ0FDSEUQBBIW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 51) = "ChJERVZJQ0VfVFlQRV9HVkcxMDAQBRIYChRERVZJQ0VfVFlQRV9ST1NTVEFM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 52) = "SxAGEhgKFERFVklDRV9UWVBFX1NPTllfQlZTEAcSGAoUREVWSUNFX1RZUEVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 53) = "U09OWV9CVlcQCBIUChBERVZJQ0VfVFlQRV9WRENQEAkSIQodREVWSUNFX1RZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 54) = "UEVfQUxMX0FNRVJJQ0FOXzgwMDAQChIhCh1ERVZJQ0VfVFlQRV9BTExfQU1F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 55) = "UklDQU5fOTAwMBALEhoKFkRFVklDRV9UWVBFX0RBS1RST05JQ1MQDBIdChlE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 56) = "RVZJQ0VfVFlQRV9EQUtUUk9OSUNTX1RWEA0SHAoYREVWSUNFX1RZUEVfRUxF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 57) = "Q1RST19NRUNIEA4SFwoTREVWSUNFX1RZUEVfRVZFUlNBThAPEh4KGkRFVklD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 58) = "RV9UWVBFX0ZBSVJfUExBWV9NUDcwEBASFgoSREVWSUNFX1RZUEVfSEFSUklT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 59) = "EBESFAoQREVWSUNFX1RZUEVfSlVHUxASEhMKD0RFVklDRV9UWVBFX09FUxAT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 60) = "EhkKFURFVklDRV9UWVBFX1NDT1JFQklSRBAUEhgKFERFVklDRV9UWVBFX1ND";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 61) = "T1JFQk9UEBUSFwoTREVWSUNFX1RZUEVfU1RBTEtFUhAWEhkKFURFVklDRV9U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 62) = "WVBFX1NUQVRfQ1JFVxAXIjgKCEJlaGF2aW9yEhcKE0JFSEFWSU9SX0NPTlRS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 63) = "T0xMRVIQABITCg9CRUhBVklPUl9ERVZJQ0UQAUIOCgxIYXJkd2FyZVR5cGUi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 64) = "ugEKGENvbW11bmljYXRpb25EZXZpY2VDbG91ZBIZCgJpZBgBIAEoCzINLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 65) = "LmRhdGEuVVVJRBIMCgRuYW1lGAIgASgJEjwKC2RldmljZV90eXBlGAMgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 66) = "MicucnYuZGF0YS5Db21tdW5pY2F0aW9uRGV2aWNlLkRldmljZVR5cGUSNwoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 67) = "YmVoYXZpb3IYBCABKA4yJS5ydi5kYXRhLkNvbW11bmljYXRpb25EZXZpY2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 68) = "QmVoYXZpb3IinAQKGENvbW11bmljYXRpb25EZXZpY2VMb2NhbBIZCgJpZBgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 69) = "IAEoCzINLnJ2LmRhdGEuVVVJRBIRCgljb25uZWN0ZWQYAiABKAgSFgoOYXV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 70) = "b19yZWNvbm5lY3QYAyABKAgSGQoLYnVuZGxlX25hbWUYBCABKAlCBKCGGQES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 71) = "HwoRYnVuZGxlX2lkZW50aWZpZXIYBSABKAlCBKCGGQESPQoGc2VyaWFsGAYg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 72) = "ASgLMisucnYuZGF0YS5Db21tdW5pY2F0aW9uRGV2aWNlLlNlcmlhbEhhcmR3";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 73) = "YXJlSAASPwoLdGNwX25ldHdvcmsYByABKAsyKC5ydi5kYXRhLkNvbW11bmlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 74) = "YXRpb25EZXZpY2UuVENQSGFyZHdhcmVIABI/Cgt1ZHBfbmV0d29yaxgIIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 75) = "CzIoLnJ2LmRhdGEuQ29tbXVuaWNhdGlvbkRldmljZS5VRFBIYXJkd2FyZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 76) = "Ej0KBmFydG5ldBgJIAEoCzIrLnJ2LmRhdGEuQ29tbXVuaWNhdGlvbkRldmlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 77) = "ZS5BcnRuZXRIYXJkd2FyZUgAEjkKBG1pZGkYCiABKAsyKS5ydi5kYXRhLkNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 78) = "bW11bmljYXRpb25EZXZpY2UuTUlESUhhcmR3YXJlSAASMwoHb3B0aW9ucxgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 79) = "IAMoCzIiLnJ2LmRhdGEuQ29tbXVuaWNhdGlvbkRldmljZU9wdGlvbkIOCgxI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 80) = "YXJkd2FyZVR5cGUiUAoaUHJvUHJlc2VudGVyQ29tbXVuaWNhdGlvbnMSMgoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 81) = "ZGV2aWNlcxgBIAMoCzIhLnJ2LmRhdGEuQ29tbXVuaWNhdGlvbkRldmljZUNs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 82) = "b3VkIlUKH1Byb1ByZXNlbnRlckxvY2FsQ29tbXVuaWNhdGlvbnMSMgoHZGV2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 83) = "aWNlcxgBIAMoCzIhLnJ2LmRhdGEuQ29tbXVuaWNhdGlvbkRldmljZUxvY2Fs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 84) = "IvkBChRDb21tdW5pY2F0aW9uQ29tbWFuZBIMCgRuYW1lGAEgASgJEhMKC2Rl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 85) = "c2NyaXB0aW9uGAIgASgJEg4KBmZvcm1hdBgDIAEoCRI8CgpwYXJhbWV0ZXJz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 86) = "GAQgAygLMigucnYuZGF0YS5Db21tdW5pY2F0aW9uQ29tbWFuZC5QYXJhbWV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 87) = "ZXJzGnAKClBhcmFtZXRlcnMSDAoEbmFtZRgBIAEoCRIsChFyZXBsYWNlbWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 88) = "dF9yYW5nZRgCIAEoCzIRLnJ2LmRhdGEuSW50UmFuZ2USFwoPcG9zc2libGVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 89) = "dmFsdWVzGAMgAygJEg0KBXZhbHVlGAQgASgJIo4BChlDb21tdW5pY2F0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 90) = "RGV2aWNlT3B0aW9uEkUKDG9lc19wcm9fbW9kZRgBIAEoCzItLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 91) = "Q29tbXVuaWNhdGlvbkRldmljZU9wdGlvbi5PRVNQcm9Nb2RlSAAaHAoKT0VT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 92) = "UHJvTW9kZRIOCgZlbmFibGUYASABKAhCDAoKT3B0aW9uVHlwZUI0+AEBqgIk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 93) = "UHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray95<string>, string>(ref buffer, 94) = "X2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray95<string>, string>(in buffer, 95))), new FileDescriptor[3]
		{
			CustomOptionsReflection.Descriptor,
			IntRangeReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[7]
		{
			new GeneratedClrTypeInfo(typeof(CommunicationDevice), CommunicationDevice.Parser, new string[12]
			{
				"Id", "Name", "DeviceType", "Behavior", "Connected", "AutoReconnect", "Serial", "TcpNetwork", "UdpNetwork", "Artnet",
				"Midi", "Options"
			}, new string[1] { "HardwareType" }, new Type[2]
			{
				typeof(CommunicationDevice.Types.DeviceType),
				typeof(CommunicationDevice.Types.Behavior)
			}, null, new GeneratedClrTypeInfo[5]
			{
				new GeneratedClrTypeInfo(typeof(CommunicationDevice.Types.SerialHardware), CommunicationDevice.Types.SerialHardware.Parser, new string[8] { "InterfaceId", "Name", "Speed", "DataBits", "Parity", "StopBits", "Hfci", "Hfco" }, null, new Type[6]
				{
					typeof(CommunicationDevice.Types.SerialHardware.Types.Speed),
					typeof(CommunicationDevice.Types.SerialHardware.Types.DataBits),
					typeof(CommunicationDevice.Types.SerialHardware.Types.Parity),
					typeof(CommunicationDevice.Types.SerialHardware.Types.StopBits),
					typeof(CommunicationDevice.Types.SerialHardware.Types.HFCI),
					typeof(CommunicationDevice.Types.SerialHardware.Types.HFCO)
				}, null, null),
				new GeneratedClrTypeInfo(typeof(CommunicationDevice.Types.TCPHardware), CommunicationDevice.Types.TCPHardware.Parser, new string[5] { "InterfaceId", "Name", "Address", "Port", "Mode" }, null, new Type[1] { typeof(CommunicationDevice.Types.TCPHardware.Types.Mode) }, null, null),
				new GeneratedClrTypeInfo(typeof(CommunicationDevice.Types.UDPHardware), CommunicationDevice.Types.UDPHardware.Parser, new string[5] { "InterfaceId", "Name", "Address", "Port", "Mode" }, null, new Type[1] { typeof(CommunicationDevice.Types.UDPHardware.Types.Mode) }, null, null),
				new GeneratedClrTypeInfo(typeof(CommunicationDevice.Types.ArtnetHardware), CommunicationDevice.Types.ArtnetHardware.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(CommunicationDevice.Types.MIDIHardware), CommunicationDevice.Types.MIDIHardware.Parser, null, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(CommunicationDeviceCloud), CommunicationDeviceCloud.Parser, new string[4] { "Id", "Name", "DeviceType", "Behavior" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CommunicationDeviceLocal), CommunicationDeviceLocal.Parser, new string[11]
			{
				"Id", "Connected", "AutoReconnect", "BundleName", "BundleIdentifier", "Serial", "TcpNetwork", "UdpNetwork", "Artnet", "Midi",
				"Options"
			}, new string[1] { "HardwareType" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(ProPresenterCommunications), ProPresenterCommunications.Parser, new string[1] { "Devices" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ProPresenterLocalCommunications), ProPresenterLocalCommunications.Parser, new string[1] { "Devices" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CommunicationCommand), CommunicationCommand.Parser, new string[4] { "Name", "Description", "Format", "Parameters" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(CommunicationCommand.Types.Parameters), CommunicationCommand.Types.Parameters.Parser, new string[4] { "Name", "ReplacementRange", "PossibleValues", "Value" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(CommunicationDeviceOption), CommunicationDeviceOption.Parser, new string[1] { "OesProMode" }, new string[1] { "OptionType" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(CommunicationDeviceOption.Types.OESProMode), CommunicationDeviceOption.Types.OESProMode.Parser, new string[1] { "Enable" }, null, null, null, null)
			})
		}));
	}
}
