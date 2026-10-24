using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProMaskReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProMaskReflection()
	{
		_003C_003Ey__InlineArray5<string> buffer = default(_003C_003Ey__InlineArray5<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 0) = "Cg1wcm9NYXNrLnByb3RvEgdydi5kYXRhGgtzbGlkZS5wcm90byI7CgdQcm9N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 1) = "YXNrEiIKCmJhc2Vfc2xpZGUYASABKAsyDi5ydi5kYXRhLlNsaWRlEgwKBG5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 2) = "bWUYAiABKAkiNgoOTWFza0NvbGxlY3Rpb24SJAoKY29sbGVjdGlvbhgBIAMo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 3) = "CzIQLnJ2LmRhdGEuUHJvTWFza0I0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25J";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 4) = "bnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<string>, string>(in buffer, 5))), new FileDescriptor[1] { SlideReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(ProMask), ProMask.Parser, new string[2] { "BaseSlide", "Name" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MaskCollection), MaskCollection.Parser, new string[1] { "Collection" }, null, null, null, null)
		}));
	}
}
