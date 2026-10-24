using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.TextDoc;

public static class TextdocReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static TextdocReflection()
	{
		_003C_003Ey__InlineArray146<string> buffer = default(_003C_003Ey__InlineArray146<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 0) = "Cg10ZXh0ZG9jLnByb3RvEgd0ZXh0ZG9jIsMyCghEb2N1bWVudBI9ChFkb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 1) = "bWVudF9zZXR0aW5ncxgBIAEoCzIiLnRleHRkb2MuRG9jdW1lbnQuRG9jdW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 2) = "bnRTZXR0aW5ncxJBChNkb2N1bWVudF9hdHRyaWJ1dGVzGAIgASgLMiQudGV4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 3) = "dGRvYy5Eb2N1bWVudC5Eb2N1bWVudEF0dHJpYnV0ZXMSNQoNbGlzdF9zZXR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 4) = "aW5ncxgDIAMoCzIeLnRleHRkb2MuRG9jdW1lbnQuTGlzdFNldHRpbmdzEjcK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 5) = "DnRhYmxlX3NldHRpbmdzGAQgASgLMh8udGV4dGRvYy5Eb2N1bWVudC5UYWJs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 6) = "ZVNldHRpbmdzEi8KCnBhcmFncmFwaHMYBSADKAsyGy50ZXh0ZG9jLkRvY3Vt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 7) = "ZW50LlBhcmFncmFwaBINCgV3aWR0aBgGIAEoARIOCgZoZWlnaHQYByABKAEa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 8) = "QAoFQ29sb3ISCwoDcmVkGAEgASgBEg0KBWdyZWVuGAIgASgBEgwKBGJsdWUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 9) = "AyABKAESDQoFYWxwaGEYBCABKAEapAgKEERvY3VtZW50U2V0dGluZ3MSRwoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 10) = "YWxpZ25tZW50GAEgASgOMjQudGV4dGRvYy5Eb2N1bWVudC5Eb2N1bWVudFNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 11) = "dHRpbmdzLkRvY3VtZW50QWxpZ25tZW50EkMKCXRyYW5zZm9ybRgCIAEoDjIw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 12) = "LnRleHRkb2MuRG9jdW1lbnQuRG9jdW1lbnRTZXR0aW5ncy5UZXh0VHJhbnNm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 13) = "b3JtEhEKCWRlbGltaXRlchgDIAEoCRJACgpzY2FsZV9tb2RlGAQgASgOMiwu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 14) = "dGV4dGRvYy5Eb2N1bWVudC5Eb2N1bWVudFNldHRpbmdzLlNjYWxlTW9kZRIU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 15) = "CgxsYXlvdXRfd2lkdGgYBSABKAESOwoHbWFyZ2lucxgGIAEoCzIqLnRleHRk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 16) = "b2MuRG9jdW1lbnQuRG9jdW1lbnRTZXR0aW5ncy5NYXJnaW5zEjkKBnNoYWRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 17) = "dxgHIAEoCzIpLnRleHRkb2MuRG9jdW1lbnQuRG9jdW1lbnRTZXR0aW5ncy5T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 18) = "aGFkb3cSHAoUaGFzX2V4cGxpY2l0X21hcmdpbnMYCCABKAgaQwoHTWFyZ2lu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 19) = "cxIMCgRsZWZ0GAEgASgBEgsKA3RvcBgCIAEoARINCgVyaWdodBgDIAEoARIO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 20) = "CgZib3R0b20YBCABKAEahgEKBlNoYWRvdxIPCgdlbmFibGVkGAEgASgIEhMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 21) = "C2JsdXJfcmFkaXVzGAIgASgBEg8KB29wYWNpdHkYAyABKAESJgoFY29sb3IY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 22) = "BCABKAsyFy50ZXh0ZG9jLkRvY3VtZW50LkNvbG9yEg0KBWFuZ2xlGAUgASgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 23) = "Eg4KBm9mZnNldBgGIAEoASJqChFEb2N1bWVudEFsaWdubWVudBIZChVEb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 24) = "bWVudEFsaWdubWVudF9Ub3AQABIcChhEb2N1bWVudEFsaWdubWVudF9NaWRk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 25) = "bGUQARIcChhEb2N1bWVudEFsaWdubWVudF9Cb3R0b20QAiLBAQoNVGV4dFRy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 26) = "YW5zZm9ybRIWChJUZXh0VHJhbnNmb3JtX05vbmUQABIjCh9UZXh0VHJhbnNm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 27) = "b3JtX1JlbW92ZUxpbmVSZXR1cm5zEAESJAogVGV4dFRyYW5zZm9ybV9SZXBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 28) = "YWNlTGluZVJldHVybnMQAhIjCh9UZXh0VHJhbnNmb3JtX1NpbmdsZVdvcmRQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 29) = "ZXJMaW5lEAMSKAokVGV4dFRyYW5zZm9ybV9TaW5nbGVDaGFyYWN0ZXJQZXJM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 30) = "aW5lEAQiggEKCVNjYWxlTW9kZRISCg5TY2FsZU1vZGVfTm9uZRAAEiMKH1Nj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 31) = "YWxlTW9kZV9BZGp1c3RDb250YWluZXJIZWlnaHQQARIQCgxTY2FsZU1vZGVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 32) = "VXAQAhISCg5TY2FsZU1vZGVfRG93bhADEhYKElNjYWxlTW9kZV9VcE9yRG93";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 33) = "bhAEGv4JCg1MZXZlbFNldHRpbmdzEj8KC2ZvbGxvd190eXBlGAEgASgOMiou";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 34) = "dGV4dGRvYy5Eb2N1bWVudC5MZXZlbFNldHRpbmdzLkZvbGxvd1R5cGUSSQoQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 35) = "bnVtYmVyaW5nX3NjaGVtZRgCIAEoDjIvLnRleHRkb2MuRG9jdW1lbnQuTGV2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 36) = "ZWxTZXR0aW5ncy5OdW1iZXJpbmdTY2hlbWUSPwoLYnVsbGV0X3R5cGUYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 37) = "KA4yKi50ZXh0ZG9jLkRvY3VtZW50LkxldmVsU2V0dGluZ3MuQnVsbGV0VHlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 38) = "ZRIRCglpc19idWxsZXQYBCABKAgSDgoGcHJlZml4GAUgASgJEg4KBnN1ZmZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 39) = "eBgGIAEoCRIYChBudW1iZXJpbmdfZm9ybWF0GAcgASgJEhQKDHN0YXJ0X251";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 40) = "bWJlchgIIAEoBRITCgtsZXZlbF9pbmRleBgJIAEoBSJOCgpGb2xsb3dUeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 41) = "EhYKEkZvbGxvd1R5cGVfTm90aGluZxAAEhQKEEZvbGxvd1R5cGVfU3BhY2UQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 42) = "ARISCg5Gb2xsb3dUeXBlX1RhYhACIs8DCg9OdW1iZXJpbmdTY2hlbWUSGgoW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 43) = "TnVtYmVyaW5nU2NoZW1lX0FyYWJpYxAAEikKJU51bWJlcmluZ1NjaGVtZV9B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 44) = "cmFiaWNXaXRoTGVhZGluZ1plcm8QARIhCh1OdW1iZXJpbmdTY2hlbWVfT3Jk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 45) = "aW5hbE51bWJlchACEikKJU51bWJlcmluZ1NjaGVtZV9VcHBlcmNhc2VSb21h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 46) = "bk51bWVyYWwQAxIpCiVOdW1iZXJpbmdTY2hlbWVfTG93ZXJjYXNlUm9tYW5O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 47) = "dW1lcmFsEAQSIwofTnVtYmVyaW5nU2NoZW1lX1VwcGVyY2FzZUxldHRlchAF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 48) = "EiMKH051bWJlcmluZ1NjaGVtZV9Mb3dlcmNhc2VMZXR0ZXIQBhIsCihOdW1i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 49) = "ZXJpbmdTY2hlbWVfTG93ZXJjYXNlUnVzc2lhbkFscGhhYmV0EAcSLAooTnVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 50) = "YmVyaW5nU2NoZW1lX1VwcGVyY2FzZVJ1c3NpYW5BbHBoYWJldBAIEioKJk51";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 51) = "bWJlcmluZ1NjaGVtZV9Mb3dlcmNhc2VHcmVla051bWVyYWxzEAkSKgomTnVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 52) = "YmVyaW5nU2NoZW1lX1VwcGVyY2FzZUdyZWVrTnVtZXJhbHMQCiKFAwoKQnVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 53) = "bGV0VHlwZRITCg9CdWxsZXRUeXBlX0Rhc2gQABIZChVCdWxsZXRUeXBlX0h5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 54) = "cGhlbkRhc2gQARIaChZCdWxsZXRUeXBlX1NtYWxsQ2lyY2xlEAISFQoRQnVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 55) = "bGV0VHlwZV9DaXJjbGUQAxIeChpCdWxsZXRUeXBlX1NtYWxsT3BlbkNpcmNs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 56) = "ZRAEEhkKFUJ1bGxldFR5cGVfT3BlbkNpcmNsZRAFEhoKFkJ1bGxldFR5cGVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 57) = "U21hbGxTcXVhcmUQBhIVChFCdWxsZXRUeXBlX1NxdWFyZRAHEh4KGkJ1bGxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 58) = "dFR5cGVfU21hbGxPcGVuU3F1YXJlEAgSGQoVQnVsbGV0VHlwZV9PcGVuU3F1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 59) = "YXJlEAkSGAoUQnVsbGV0VHlwZV9DaGVja21hcmsQChIdChlCdWxsZXRUeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 60) = "X0hlYXZ5Q2hlY2ttYXJrEAsSFgoSQnVsbGV0VHlwZV9EaWFtb25kEAwSGgoW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 61) = "QnVsbGV0VHlwZV9PcGVuRGlhbW9uZBANGkcKDExpc3RTZXR0aW5ncxI3Cg5s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 62) = "ZXZlbF9zZXR0aW5ncxgBIAMoCzIfLnRleHRkb2MuRG9jdW1lbnQuTGV2ZWxT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 63) = "ZXR0aW5ncxoPCg1UYWJsZVNldHRpbmdzGkgKB1RhYlN0b3ASEAoIcG9zaXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 64) = "b24YASABKAESKwoEdHlwZRgCIAEoDjIdLnRleHRkb2MuRG9jdW1lbnQuVGFi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 65) = "U3RvcFR5cGUaxQQKEVBhcmFncmFwaFNldHRpbmdzEjcKCWFsaWdubWVudBgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 66) = "IAEoDjIkLnRleHRkb2MuRG9jdW1lbnQuUGFyYWdyYXBoQWxpZ25tZW50EjcK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 67) = "DHNwYWNpbmdfbW9kZRgCIAEoDjIhLnRleHRkb2MuRG9jdW1lbnQuTGluZVNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 68) = "YWNpbmdNb2RlEhQKDGxpbmVfc3BhY2luZxgDIAEoARIfChdhZGRpdGlvbmFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 69) = "X2xpbmVfc3BhY2luZxgEIAEoARIYChBiZWZvcmVfcGFyYWdyYXBoGAUgASgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 70) = "EhcKD2FmdGVyX3BhcmFncmFwaBgGIAEoARITCgtsZWZ0X2luZGVudBgHIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 71) = "ARIUCgxyaWdodF9pbmRlbnQYCCABKAESPAoRcmlnaHRfaW5kZW50X21vZGUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 72) = "CSABKA4yIS50ZXh0ZG9jLkRvY3VtZW50LlJpZ2h0SW5kZW50TW9kZRIZChFm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 73) = "aXJzdF9saW5lX2luZGVudBgKIAEoARISCgpsaXN0X2luZGV4GAsgASgFEhMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 74) = "C2xldmVsX2luZGV4GAwgASgFEi0KDGJ1bGxldF9jb2xvchgNIAEoCzIXLnRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 75) = "eHRkb2MuRG9jdW1lbnQuQ29sb3ISFAoMYnVsbGV0X3NjYWxlGA4gASgBEiwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 76) = "CXRhYl9zdG9wcxgPIAMoCzIZLnRleHRkb2MuRG9jdW1lbnQuVGFiU3RvcBIa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 77) = "ChJsaXN0X292ZXJyaWRlX3RleHQYECABKAkSGAoQZGVmYXVsdF90YWJfc3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 78) = "cBgRIAEoARqrAgoIRm9udEluZm8SGgoSc3lzdGVtX2ZhbWlseV9uYW1lGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 79) = "ASgJEhgKEHN5c3RlbV9mYWNlX25hbWUYAiABKAkSGwoTZGlzcGxheV9mYW1p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 80) = "bHlfbmFtZRgDIAEoCRIZChFkaXNwbGF5X2ZhY2VfbmFtZRgEIAEoCRIRCglm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 81) = "dWxsX25hbWUYBSABKAkSFwoPcG9zdHNjcmlwdF9uYW1lGAYgASgJEiIKGmFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 82) = "dGVybmF0ZV9wb3N0c2NyaXB0X25hbWVzGAcgAygJEg4KBndlaWdodBgIIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 83) = "DRINCgV3aWR0aBgJIAEoDRIRCglpc19pdGFsaWMYCiABKAgSFQoNdmFyaWFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 84) = "dF9pbmRleBgLIAEoDRIYChBvdGhlcl9wcm9wZXJ0aWVzGAwgAygJGjMKCVNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 85) = "bGlkRmlsbBImCgVjb2xvchgBIAEoCzIXLnRleHRkb2MuRG9jdW1lbnQuQ29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 86) = "b3IaagoMR3JhZGllbnRGaWxsEg0KBWFuZ2xlGAEgASgBEiIKGnN0cmV0Y2hf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 87) = "dG9fZG9jdW1lbnRfYm91bmRzGAIgASgIEicKBmNvbG9ycxgDIAMoCzIXLnRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 88) = "eHRkb2MuRG9jdW1lbnQuQ29sb3IaDAoKQ3V0T3V0RmlsbBoHCgVNZWRpYRpl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 89) = "CglNZWRpYUZpbGwSDAoEdXVpZBgBIAEoCRIiChpzdHJldGNoX3RvX2RvY3Vt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 90) = "ZW50X2JvdW5kcxgCIAEoCBImCgVtZWRpYRgDIAEoCzIXLnRleHRkb2MuRG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 91) = "dW1lbnQuTWVkaWEaNgoSQmFja2dyb3VuZEJsdXJGaWxsEgwKBGJsdXIYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 92) = "KAESEgoKc2F0dXJhdGlvbhgCIAEoARoWChRCYWNrZ3JvdW5kSW52ZXJ0Rmls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 93) = "bBq8CwoLUnVuU2V0dGluZ3MSKAoEZm9udBgBIAEoCzIaLnRleHRkb2MuRG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 94) = "dW1lbnQuRm9udEluZm8SFgoOY2hhcmFjdGVyX3NpemUYAiABKAESTAoTY2hh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 95) = "cmFjdGVyX3NpemVfbW9kZRgDIAEoDjIvLnRleHRkb2MuRG9jdW1lbnQuUnVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 96) = "U2V0dGluZ3MuQ2hhcmFjdGVyU2l6ZU1vZGUSGQoRY2hhcmFjdGVyX3NwYWNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 97) = "bmcYBCABKAESFAoMc2NyaXB0X2xldmVsGAUgASgFEjkKCXRleHRfZmlsbBgG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 98) = "IAEoCzImLnRleHRkb2MuRG9jdW1lbnQuUnVuU2V0dGluZ3MuVGV4dEZpbGwS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 99) = "MAoPaGlnaGxpZ2h0X2NvbG9yGAcgASgLMhcudGV4dGRvYy5Eb2N1bWVudC5D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 100) = "b2xvchI0CgZzdHJva2UYCCABKAsyJC50ZXh0ZG9jLkRvY3VtZW50LlJ1blNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 101) = "dHRpbmdzLlN0cm9rZRIRCgl1bmRlcmxpbmUYCSABKAgSMAoPdW5kZXJsaW5l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 102) = "X2NvbG9yGAogASgLMhcudGV4dGRvYy5Eb2N1bWVudC5Db2xvchIWCg5zdHJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 103) = "a2VfdGhyb3VnaBgLIAEoCBJNChNjYXBpdGFsaXphdGlvbl90eXBlGAwgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 104) = "MjAudGV4dGRvYy5Eb2N1bWVudC5SdW5TZXR0aW5ncy5DYXBpdGFsaXphdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 105) = "blR5cGUSFwoPdGFidWxhcl9udW1iZXJzGA0gASgIEhsKE3ByZXNlcnZlX2Zp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 106) = "bGxfY29sb3IYDiABKAgSDwoHa2VybmluZxgPIAEoCBIRCglsaWdhdHVyZXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 107) = "ECABKAgSGQoRZm9udF9zY2FsZV9mYWN0b3IYESABKAEa9wIKCFRleHRGaWxs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 108) = "EjEKCnNvbGlkX2ZpbGwYASABKAsyGy50ZXh0ZG9jLkRvY3VtZW50LlNvbGlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 109) = "RmlsbEgAEjcKDWdyYWRpZW50X2ZpbGwYAiABKAsyHi50ZXh0ZG9jLkRvY3Vt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 110) = "ZW50LkdyYWRpZW50RmlsbEgAEjQKDGN1dF9vdXRfZmlsbBgDIAEoCzIcLnRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 111) = "eHRkb2MuRG9jdW1lbnQuQ3V0T3V0RmlsbEgAEjEKCm1lZGlhX2ZpbGwYBCAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 112) = "KAsyGy50ZXh0ZG9jLkRvY3VtZW50Lk1lZGlhRmlsbEgAEkQKFGJhY2tncm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 113) = "bmRfYmx1cl9maWxsGAUgASgLMiQudGV4dGRvYy5Eb2N1bWVudC5CYWNrZ3Jv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 114) = "dW5kQmx1ckZpbGxIABJIChZiYWNrZ3JvdW5kX2ludmVydF9maWxsGAYgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 115) = "MiYudGV4dGRvYy5Eb2N1bWVudC5CYWNrZ3JvdW5kSW52ZXJ0RmlsbEgAQgYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 116) = "BGZpbGwaQwoGU3Ryb2tlEhEKCXRoaWNrbmVzcxgBIAEoARImCgVjb2xvchgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 117) = "IAEoCzIXLnRleHRkb2MuRG9jdW1lbnQuQ29sb3IijAEKEUNoYXJhY3RlclNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 118) = "emVNb2RlEhwKGENoYXJhY3RlclNpemVNb2RlX05vcm1hbBAAEiwKKENoYXJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 119) = "Y3RlclNpemVNb2RlX1NjYWxlZEJ5RG9jdW1lbnRIZWlnaHQQARIrCidDaGFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 120) = "YWN0ZXJTaXplTW9kZV9TY2FsZWRCeURvY3VtZW50V2lkdGgQAiLZAQoSQ2Fw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 121) = "aXRhbGl6YXRpb25UeXBlEhsKF0NhcGl0YWxpemF0aW9uVHlwZV9Ob25lEAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 122) = "HgoaQ2FwaXRhbGl6YXRpb25UeXBlX0FsbENhcHMQARIgChxDYXBpdGFsaXph";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 123) = "dGlvblR5cGVfTG93ZXJDYXNlEAISIAocQ2FwaXRhbGl6YXRpb25UeXBlX1Nt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 124) = "YWxsQ2FwcxADEiAKHENhcGl0YWxpemF0aW9uVHlwZV9UaXRsZUNhc2UQBBIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 125) = "ChxDYXBpdGFsaXphdGlvblR5cGVfU3RhcnRDYXNlEAUaSAoDUnVuEjMKDHJ1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 126) = "bl9zZXR0aW5ncxgBIAEoCzIdLnRleHRkb2MuRG9jdW1lbnQuUnVuU2V0dGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 127) = "Z3MSDAoEdGV4dBgCIAEoCRquAQoJUGFyYWdyYXBoEj8KEnBhcmFncmFwaF9z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 128) = "ZXR0aW5ncxgBIAEoCzIjLnRleHRkb2MuRG9jdW1lbnQuUGFyYWdyYXBoU2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 129) = "dGluZ3MSIwoEcnVucxgCIAMoCzIVLnRleHRkb2MuRG9jdW1lbnQuUnVuEjsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 130) = "FGRlZmF1bHRfcnVuX3NldHRpbmdzGAMgASgLMh0udGV4dGRvYy5Eb2N1bWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 131) = "dC5SdW5TZXR0aW5ncxqKAQoSRG9jdW1lbnRBdHRyaWJ1dGVzEj8KEnBhcmFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 132) = "cmFwaF9zZXR0aW5ncxgBIAEoCzIjLnRleHRkb2MuRG9jdW1lbnQuUGFyYWdy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 133) = "YXBoU2V0dGluZ3MSMwoMcnVuX3NldHRpbmdzGAIgASgLMh0udGV4dGRvYy5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 134) = "b2N1bWVudC5SdW5TZXR0aW5ncyKQAQoSUGFyYWdyYXBoQWxpZ25tZW50EhsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 135) = "F1BhcmFncmFwaEFsaWdubWVudF9MZWZ0EAASHQoZUGFyYWdyYXBoQWxpZ25t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 136) = "ZW50X0NlbnRlchABEhwKGFBhcmFncmFwaEFsaWdubWVudF9SaWdodBACEiAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 137) = "HFBhcmFncmFwaEFsaWdubWVudF9KdXN0aWZpZWQQAyJrCg9MaW5lU3BhY2lu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 138) = "Z01vZGUSHAoYTGluZVNwYWNpbmdNb2RlX0Fic29sdXRlEAASHAoYTGluZVNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 139) = "YWNpbmdNb2RlX1JlbGF0aXZlEAESHAoYTGluZVNwYWNpbmdNb2RlX011bHRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 140) = "cGxlEAIiTgoPUmlnaHRJbmRlbnRNb2RlEh0KGVJpZ2h0SW5kZW50TW9kZV9G";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 141) = "cm9tUmlnaHQQABIcChhSaWdodEluZGVudE1vZGVfRnJvbUxlZnQQASJrCgtU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 142) = "YWJTdG9wVHlwZRIUChBUYWJTdG9wVHlwZV9MZWZ0EAASFQoRVGFiU3RvcFR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 143) = "cGVfUmlnaHQQARIWChJUYWJTdG9wVHlwZV9DZW50ZXIQAhIXChNUYWJTdG9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 144) = "VHlwZV9EZWNpbWFsEANCQaoCLFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray146<string>, string>(ref buffer, 145) = "VlByb3RvRGF0YS5UZXh0RG9jugIPUlZEYXRhX1RleHREb2NfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray146<string>, string>(in buffer, 146))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Document), Document.Parser, new string[7] { "DocumentSettings", "DocumentAttributes", "ListSettings", "TableSettings", "Paragraphs", "Width", "Height" }, null, new Type[4]
			{
				typeof(Document.Types.ParagraphAlignment),
				typeof(Document.Types.LineSpacingMode),
				typeof(Document.Types.RightIndentMode),
				typeof(Document.Types.TabStopType)
			}, null, new GeneratedClrTypeInfo[19]
			{
				new GeneratedClrTypeInfo(typeof(Document.Types.Color), Document.Types.Color.Parser, new string[4] { "Red", "Green", "Blue", "Alpha" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.DocumentSettings), Document.Types.DocumentSettings.Parser, new string[8] { "Alignment", "Transform", "Delimiter", "ScaleMode", "LayoutWidth", "Margins", "Shadow", "HasExplicitMargins" }, null, new Type[3]
				{
					typeof(Document.Types.DocumentSettings.Types.DocumentAlignment),
					typeof(Document.Types.DocumentSettings.Types.TextTransform),
					typeof(Document.Types.DocumentSettings.Types.ScaleMode)
				}, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(Document.Types.DocumentSettings.Types.Margins), Document.Types.DocumentSettings.Types.Margins.Parser, new string[4] { "Left", "Top", "Right", "Bottom" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Document.Types.DocumentSettings.Types.Shadow), Document.Types.DocumentSettings.Types.Shadow.Parser, new string[6] { "Enabled", "BlurRadius", "Opacity", "Color", "Angle", "Offset" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Document.Types.LevelSettings), Document.Types.LevelSettings.Parser, new string[9] { "FollowType", "NumberingScheme", "BulletType", "IsBullet", "Prefix", "Suffix", "NumberingFormat", "StartNumber", "LevelIndex" }, null, new Type[3]
				{
					typeof(Document.Types.LevelSettings.Types.FollowType),
					typeof(Document.Types.LevelSettings.Types.NumberingScheme),
					typeof(Document.Types.LevelSettings.Types.BulletType)
				}, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.ListSettings), Document.Types.ListSettings.Parser, new string[1] { "LevelSettings" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.TableSettings), Document.Types.TableSettings.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.TabStop), Document.Types.TabStop.Parser, new string[2] { "Position", "Type" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.ParagraphSettings), Document.Types.ParagraphSettings.Parser, new string[17]
				{
					"Alignment", "SpacingMode", "LineSpacing", "AdditionalLineSpacing", "BeforeParagraph", "AfterParagraph", "LeftIndent", "RightIndent", "RightIndentMode", "FirstLineIndent",
					"ListIndex", "LevelIndex", "BulletColor", "BulletScale", "TabStops", "ListOverrideText", "DefaultTabStop"
				}, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.FontInfo), Document.Types.FontInfo.Parser, new string[12]
				{
					"SystemFamilyName", "SystemFaceName", "DisplayFamilyName", "DisplayFaceName", "FullName", "PostscriptName", "AlternatePostscriptNames", "Weight", "Width", "IsItalic",
					"VariantIndex", "OtherProperties"
				}, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.SolidFill), Document.Types.SolidFill.Parser, new string[1] { "Color" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.GradientFill), Document.Types.GradientFill.Parser, new string[3] { "Angle", "StretchToDocumentBounds", "Colors" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.CutOutFill), Document.Types.CutOutFill.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.Media), Document.Types.Media.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.MediaFill), Document.Types.MediaFill.Parser, new string[3] { "Uuid", "StretchToDocumentBounds", "Media" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.BackgroundBlurFill), Document.Types.BackgroundBlurFill.Parser, new string[2] { "Blur", "Saturation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.BackgroundInvertFill), Document.Types.BackgroundInvertFill.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.RunSettings), Document.Types.RunSettings.Parser, new string[17]
				{
					"Font", "CharacterSize", "CharacterSizeMode", "CharacterSpacing", "ScriptLevel", "TextFill", "HighlightColor", "Stroke", "Underline", "UnderlineColor",
					"StrikeThrough", "CapitalizationType", "TabularNumbers", "PreserveFillColor", "Kerning", "Ligatures", "FontScaleFactor"
				}, null, new Type[2]
				{
					typeof(Document.Types.RunSettings.Types.CharacterSizeMode),
					typeof(Document.Types.RunSettings.Types.CapitalizationType)
				}, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(Document.Types.RunSettings.Types.TextFill), Document.Types.RunSettings.Types.TextFill.Parser, new string[6] { "SolidFill", "GradientFill", "CutOutFill", "MediaFill", "BackgroundBlurFill", "BackgroundInvertFill" }, new string[1] { "Fill" }, null, null, null),
					new GeneratedClrTypeInfo(typeof(Document.Types.RunSettings.Types.Stroke), Document.Types.RunSettings.Types.Stroke.Parser, new string[2] { "Thickness", "Color" }, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Document.Types.Run), Document.Types.Run.Parser, new string[2] { "RunSettings", "Text" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.Paragraph), Document.Types.Paragraph.Parser, new string[3] { "ParagraphSettings", "Runs", "DefaultRunSettings" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Document.Types.DocumentAttributes), Document.Types.DocumentAttributes.Parser, new string[2] { "ParagraphSettings", "RunSettings" }, null, null, null, null)
			})
		}));
	}
}
