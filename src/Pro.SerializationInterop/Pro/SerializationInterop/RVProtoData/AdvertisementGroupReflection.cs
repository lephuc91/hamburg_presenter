using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class AdvertisementGroupReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AdvertisementGroupReflection()
	{
		_003C_003Ey__InlineArray6<string> buffer = default(_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = "ChhhZHZlcnRpc2VtZW50R3JvdXAucHJvdG8SB3J2LmRhdGEaCXVybC5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "bxoKdXVpZC5wcm90byKBAQoSQWR2ZXJ0aXNlbWVudEdyb3VwEhsKBHV1aWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "ASABKAsyDS5ydi5kYXRhLlVVSUQSDAoEbmFtZRgCIAEoCRIZCgN1cmwYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "KAsyDC5ydi5kYXRhLlVSTBITCgtzdGFydF9pbmRleBgEIAEoBRIQCghkdXJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "dGlvbhgFIAEoAUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "UHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<string>, string>(in buffer, 6))), new FileDescriptor[2]
		{
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(AdvertisementGroup), AdvertisementGroup.Parser, new string[5] { "Uuid", "Name", "Url", "StartIndex", "Duration" }, null, null, null, null)
		}));
	}
}
