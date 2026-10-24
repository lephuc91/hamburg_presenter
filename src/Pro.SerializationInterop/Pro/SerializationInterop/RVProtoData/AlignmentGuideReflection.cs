using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class AlignmentGuideReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AlignmentGuideReflection()
	{
		_003C_003Ey__InlineArray8<string> buffer = default(_003C_003Ey__InlineArray8<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 0) = "ChRhbGlnbm1lbnRHdWlkZS5wcm90bxIHcnYuZGF0YRoKdXVpZC5wcm90byLk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 1) = "AQoOQWxpZ25tZW50R3VpZGUSGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 2) = "RBJBCgtvcmllbnRhdGlvbhgCIAEoDjIsLnJ2LmRhdGEuQWxpZ25tZW50R3Vp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 3) = "ZGUuR3VpZGVsaW5lT3JpZW50YXRpb24SEAoIbG9jYXRpb24YAyABKAEiYAoU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 4) = "R3VpZGVsaW5lT3JpZW50YXRpb24SJAogR1VJREVMSU5FX09SSUVOVEFUSU9O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 5) = "X0hPUklaT05UQUwQABIiCh5HVUlERUxJTkVfT1JJRU5UQVRJT05fVkVSVElD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 6) = "QUwQAUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 7) = "YXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray8<string>, string>(in buffer, 8))), new FileDescriptor[1] { UuidReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(AlignmentGuide), AlignmentGuide.Parser, new string[3] { "Uuid", "Orientation", "Location" }, null, new Type[1] { typeof(AlignmentGuide.Types.GuidelineOrientation) }, null, null)
		}));
	}
}
