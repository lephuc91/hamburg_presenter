using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.PPTImport;

public static class PptparamsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PptparamsReflection()
	{
		_003C_003Ey__InlineArray6<string> buffer = default(_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = "Cg9wcHRwYXJhbXMucHJvdG8SCXBwdGltcG9ydCKHAQoPUFBUSW1wb3J0UGFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "YW1zEhEKCXBwdHhfcGF0aBgBIAEoCRIaChJyZXN1bHRfZm9sZGVyX3BhdGgY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "AiABKAkSEwoLc2xpZGVfd2lkdGgYAyABKA0SFAoMc2xpZGVfaGVpZ2h0GAQg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "ASgNEhoKEmlnbm9yZV9iYWNrZ3JvdW5kcxgFIAEoCEJFqgIuUHJvLlNlcmlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "bGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhLlBQVEltcG9ydLoCEVJWRGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "YV9QUFRJbXBvcnRfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<string>, string>(in buffer, 6))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(PPTImportParams), PPTImportParams.Parser, new string[5] { "PptxPath", "ResultFolderPath", "SlideWidth", "SlideHeight", "IgnoreBackgrounds" }, null, null, null, null)
		}));
	}
}
