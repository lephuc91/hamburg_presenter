using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.FeatureFlags;

public static class FeatureFlagsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static FeatureFlagsReflection()
	{
		_003C_003Ey__InlineArray10<string> buffer = default(_003C_003Ey__InlineArray10<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 0) = "ChNmZWF0dXJlLWZsYWdzLnByb3RvEg1mZWF0dXJlX2ZsYWdzIhAKDkNyZWF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 1) = "aW9uT3B0aW9uIiUKBEZsYWcSDAoEbmFtZRgBIAEoCRIPCgdlbmFibGVkGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 2) = "ASgIIi4KCEFsbEZsYWdzEiIKBWZsYWdzGAEgAygLMhMuZmVhdHVyZV9mbGFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 3) = "cy5GbGFnIrQBCgxOb3RpZmljYXRpb24SLAoJYWxsX2ZsYWdzGAEgASgLMhcu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 4) = "ZmVhdHVyZV9mbGFncy5BbGxGbGFnc0gAEk8KFHVuc3Vic2NyaWJlX2NvbXBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 5) = "ZXRlGAIgASgLMi8uZmVhdHVyZV9mbGFncy5Ob3RpZmljYXRpb24uVW5zdWJz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 6) = "Y3JpYmVDb21wbGV0ZUgAGhUKE1Vuc3Vic2NyaWJlQ29tcGxldGVCDgoMbm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 7) = "aWZpY2F0aW9uQkuqAjFQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 8) = "b0RhdGEuRmVhdHVyZUZsYWdzugIUUlZEYXRhX0ZlYXR1cmVGbGFnc19iBnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 9) = "b3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<string>, string>(in buffer, 10))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(CreationOption), CreationOption.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Flag), Flag.Parser, new string[2] { "Name", "Enabled" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(AllFlags), AllFlags.Parser, new string[1] { "Flags" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Notification), Notification.Parser, new string[2] { "AllFlags", "UnsubscribeComplete" }, new string[1] { "Notification" }, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Notification.Types.UnsubscribeComplete), Notification.Types.UnsubscribeComplete.Parser, null, null, null, null, null)
			})
		}));
	}
}
