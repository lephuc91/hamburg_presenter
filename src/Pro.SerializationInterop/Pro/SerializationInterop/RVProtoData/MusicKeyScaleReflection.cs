using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class MusicKeyScaleReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static MusicKeyScaleReflection()
	{
		_003C_003Ey__InlineArray17<string> buffer = default(_003C_003Ey__InlineArray17<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 0) = "ChNtdXNpY0tleVNjYWxlLnByb3RvEgdydi5kYXRhIvYECg1NdXNpY0tleVNj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 1) = "YWxlEjIKCW11c2ljX2tleRgBIAEoDjIfLnJ2LmRhdGEuTXVzaWNLZXlTY2Fs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 2) = "ZS5NdXNpY0tleRI2CgttdXNpY19zY2FsZRgCIAEoDjIhLnJ2LmRhdGEuTXVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 3) = "aWNLZXlTY2FsZS5NdXNpY1NjYWxlIrwDCghNdXNpY0tleRIUChBNVVNJQ19L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 4) = "RVlfQV9GTEFUEAASDwoLTVVTSUNfS0VZX0EQARIVChFNVVNJQ19LRVlfQV9T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 5) = "SEFSUBACEhQKEE1VU0lDX0tFWV9CX0ZMQVQQAxIPCgtNVVNJQ19LRVlfQhAE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 6) = "EhUKEU1VU0lDX0tFWV9CX1NIQVJQEAUSFAoQTVVTSUNfS0VZX0NfRkxBVBAG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 7) = "Eg8KC01VU0lDX0tFWV9DEAcSFQoRTVVTSUNfS0VZX0NfU0hBUlAQCBIUChBN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 8) = "VVNJQ19LRVlfRF9GTEFUEAkSDwoLTVVTSUNfS0VZX0QQChIVChFNVVNJQ19L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 9) = "RVlfRF9TSEFSUBALEhQKEE1VU0lDX0tFWV9FX0ZMQVQQDBIPCgtNVVNJQ19L";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 10) = "RVlfRRANEhUKEU1VU0lDX0tFWV9FX1NIQVJQEA4SFAoQTVVTSUNfS0VZX0Zf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 11) = "RkxBVBAPEg8KC01VU0lDX0tFWV9GEBASFQoRTVVTSUNfS0VZX0ZfU0hBUlAQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 12) = "ERIUChBNVVNJQ19LRVlfR19GTEFUEBISDwoLTVVTSUNfS0VZX0cQExIVChFN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 13) = "VVNJQ19LRVlfR19TSEFSUBAUIjoKCk11c2ljU2NhbGUSFQoRTVVTSUNfU0NB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 14) = "TEVfTUFKT1IQABIVChFNVVNJQ19TQ0FMRV9NSU5PUhABQjT4AQGqAiRQcm8u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 15) = "U2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray17<string>, string>(ref buffer, 16) = "cm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray17<string>, string>(in buffer, 17))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(MusicKeyScale), MusicKeyScale.Parser, new string[2] { "MusicKey", "MusicScale" }, null, new Type[2]
			{
				typeof(MusicKeyScale.Types.MusicKey),
				typeof(MusicKeyScale.Types.MusicScale)
			}, null, null)
		}));
	}
}
