using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class PropSlideReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PropSlideReflection()
	{
		_003C_003Ey__InlineArray7<string> buffer = default(_003C_003Ey__InlineArray7<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 0) = "Cg9wcm9wU2xpZGUucHJvdG8SB3J2LmRhdGEaE2N1c3RvbU9wdGlvbnMucHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 1) = "dG8aC3NsaWRlLnByb3RvGg1lZmZlY3RzLnByb3RvIpcBCglQcm9wU2xpZGUS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 2) = "IgoKYmFzZV9zbGlkZRgBIAEoCzIOLnJ2LmRhdGEuU2xpZGUSLQoKdHJhbnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 3) = "dGlvbhgCIAEoCzITLnJ2LmRhdGEuVHJhbnNpdGlvbkIEoIYZARIaChJhdXRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 4) = "X2NsZWFyX2VuYWJsZWQYAyABKAgSGwoTYXV0b19jbGVhcl9kdXJhdGlvbhgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 5) = "IAEoAUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 6) = "YXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<string>, string>(in buffer, 7))), new FileDescriptor[3]
		{
			CustomOptionsReflection.Descriptor,
			SlideReflection.Descriptor,
			EffectsReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(PropSlide), PropSlide.Parser, new string[4] { "BaseSlide", "Transition", "AutoClearEnabled", "AutoClearDuration" }, null, null, null, null)
		}));
	}
}
