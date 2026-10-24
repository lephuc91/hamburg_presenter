using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class UrlReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static UrlReflection()
	{
		_003C_003Ey__InlineArray27<string> buffer = default(_003C_003Ey__InlineArray27<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 0) = "Cgl1cmwucHJvdG8SB3J2LmRhdGEaE2N1c3RvbU9wdGlvbnMucHJvdG8imQgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 1) = "A1VSTBIZCg9hYnNvbHV0ZV9zdHJpbmcYASABKAlIABIXCg1yZWxhdGl2ZV9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 2) = "YXRoGAIgASgJSAASJwoIcGxhdGZvcm0YAyABKA4yFS5ydi5kYXRhLlVSTC5Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 3) = "bGF0Zm9ybRIvCgVsb2NhbBgEIAEoCzIeLnJ2LmRhdGEuVVJMLkxvY2FsUmVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 4) = "YXRpdmVQYXRoSAESNQoIZXh0ZXJuYWwYBSABKAsyIS5ydi5kYXRhLlVSTC5F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 5) = "eHRlcm5hbFJlbGF0aXZlUGF0aEgBGoEDChFMb2NhbFJlbGF0aXZlUGF0aBIx";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 6) = "CgRyb290GAEgASgOMiMucnYuZGF0YS5VUkwuTG9jYWxSZWxhdGl2ZVBhdGgu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 7) = "Um9vdBIMCgRwYXRoGAIgASgJIqQCCgRSb290EhAKDFJPT1RfVU5LTk9XThAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 8) = "EhQKEFJPT1RfQk9PVF9WT0xVTUUQARISCg5ST09UX1VTRVJfSE9NRRACEhcK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 9) = "E1JPT1RfVVNFUl9ET0NVTUVOVFMQAxIXChNST09UX1VTRVJfRE9XTkxPQURT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 10) = "EAQSEwoPUk9PVF9VU0VSX01VU0lDEAUSFgoSUk9PVF9VU0VSX1BJQ1RVUkVT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 11) = "EAYSFAoQUk9PVF9VU0VSX1ZJREVPUxAHEhUKEVJPT1RfVVNFUl9ERVNLVE9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 12) = "EAsSGQoVUk9PVF9VU0VSX0FQUF9TVVBQT1JUEAgSDwoLUk9PVF9TSEFSRUQQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 13) = "CRINCglST09UX1NIT1cQChIZChVST09UX0NVUlJFTlRfUkVTT1VSQ0UQDDoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 14) = "gIAZARrHAgoURXh0ZXJuYWxSZWxhdGl2ZVBhdGgSRAoFbWFjb3MYASABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 15) = "NS5ydi5kYXRhLlVSTC5FeHRlcm5hbFJlbGF0aXZlUGF0aC5NYWNPU0V4dGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 16) = "bmFsVm9sdW1lEkQKBXdpbjMyGAIgASgLMjUucnYuZGF0YS5VUkwuRXh0ZXJu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 17) = "YWxSZWxhdGl2ZVBhdGguV2luMzJFeHRlcm5hbFZvbHVtZRIMCgRwYXRoGAMg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 18) = "ASgJGjAKE01hY09TRXh0ZXJuYWxWb2x1bWUSEwoLdm9sdW1lX25hbWUYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 19) = "KAk6BICAGQEaXQoTV2luMzJFeHRlcm5hbFZvbHVtZRIUCgxkcml2ZV9sZXR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 20) = "ZXIYASABKAkSEwoLdm9sdW1lX25hbWUYAiABKAkSFQoNbmV0d29ya19zaGFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 21) = "ZRgDIAEoCDoEgIAZAToEgIAZASJaCghQbGF0Zm9ybRIUChBQTEFURk9STV9V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 22) = "TktOT1dOEAASEgoOUExBVEZPUk1fTUFDT1MQARISCg5QTEFURk9STV9XSU4z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 23) = "MhACEhAKDFBMQVRGT1JNX1dFQhADOgSAgBkBQgkKB1N0b3JhZ2VCEgoQUmVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 24) = "YXRpdmVGaWxlUGF0aCIiCgRVUkxzEhoKBHVybHMYASADKAsyDC5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 25) = "LlVSTEI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 26) = "YXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray27<string>, string>(in buffer, 27))), new FileDescriptor[1] { CustomOptionsReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(URL), URL.Parser, new string[5] { "AbsoluteString", "RelativePath", "Platform", "Local", "External" }, new string[2] { "Storage", "RelativeFilePath" }, new Type[1] { typeof(URL.Types.Platform) }, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(URL.Types.LocalRelativePath), URL.Types.LocalRelativePath.Parser, new string[2] { "Root", "Path" }, null, new Type[1] { typeof(URL.Types.LocalRelativePath.Types.Root) }, null, null),
				new GeneratedClrTypeInfo(typeof(URL.Types.ExternalRelativePath), URL.Types.ExternalRelativePath.Parser, new string[3] { "Macos", "Win32", "Path" }, null, null, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(URL.Types.ExternalRelativePath.Types.MacOSExternalVolume), URL.Types.ExternalRelativePath.Types.MacOSExternalVolume.Parser, new string[1] { "VolumeName" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(URL.Types.ExternalRelativePath.Types.Win32ExternalVolume), URL.Types.ExternalRelativePath.Types.Win32ExternalVolume.Parser, new string[3] { "DriveLetter", "VolumeName", "NetworkShare" }, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(URLs), URLs.Parser, new string[1] { "Urls" }, null, null, null, null)
		}));
	}
}
