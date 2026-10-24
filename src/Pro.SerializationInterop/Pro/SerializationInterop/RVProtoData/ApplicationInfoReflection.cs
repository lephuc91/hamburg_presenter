using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ApplicationInfoReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ApplicationInfoReflection()
	{
		_003C_003Ey__InlineArray13<string> buffer = default(_003C_003Ey__InlineArray13<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 0) = "ChVhcHBsaWNhdGlvbkluZm8ucHJvdG8SB3J2LmRhdGEaDXZlcnNpb24ucHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 1) = "dG8ixAMKD0FwcGxpY2F0aW9uSW5mbxIzCghwbGF0Zm9ybRgBIAEoDjIhLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 2) = "LmRhdGEuQXBwbGljYXRpb25JbmZvLlBsYXRmb3JtEioKEHBsYXRmb3JtX3Zl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 3) = "cnNpb24YAiABKAsyEC5ydi5kYXRhLlZlcnNpb24SOQoLYXBwbGljYXRpb24Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 4) = "AyABKA4yJC5ydi5kYXRhLkFwcGxpY2F0aW9uSW5mby5BcHBsaWNhdGlvbhIt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 5) = "ChNhcHBsaWNhdGlvbl92ZXJzaW9uGAQgASgLMhAucnYuZGF0YS5WZXJzaW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 6) = "IkwKCFBsYXRmb3JtEhYKElBMQVRGT1JNX1VOREVGSU5FRBAAEhIKDlBMQVRG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 7) = "T1JNX01BQ09TEAESFAoQUExBVEZPUk1fV0lORE9XUxACIpcBCgtBcHBsaWNh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 8) = "dGlvbhIZChVBUFBMSUNBVElPTl9VTkRFRklORUQQABIcChhBUFBMSUNBVElP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 9) = "Tl9QUk9QUkVTRU5URVIQARITCg9BUFBMSUNBVElPTl9QVlAQAhIeChpBUFBM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 10) = "SUNBVElPTl9QUk9WSURFT1NFUlZFUhADEhoKFkFQUExJQ0FUSU9OX1NDT1JF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 11) = "Qk9BUkQQBEI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 12) = "dG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray13<string>, string>(in buffer, 13))), new FileDescriptor[1] { VersionReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(ApplicationInfo), ApplicationInfo.Parser, new string[4] { "Platform", "PlatformVersion", "Application", "ApplicationVersion" }, null, new Type[2]
			{
				typeof(ApplicationInfo.Types.Platform),
				typeof(ApplicationInfo.Types.Application)
			}, null, null)
		}));
	}
}
