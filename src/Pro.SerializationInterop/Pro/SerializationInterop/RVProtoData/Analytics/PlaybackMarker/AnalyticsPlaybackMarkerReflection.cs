using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.PlaybackMarker;

public static class AnalyticsPlaybackMarkerReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsPlaybackMarkerReflection()
	{
		_003C_003Ey__InlineArray7<string> buffer = default(_003C_003Ey__InlineArray7<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 0) = "Ch1hbmFseXRpY3NQbGF5YmFja01hcmtlci5wcm90bxIbcnYuYW5hbHl0aWNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 1) = "LnBsYXliYWNrbWFya2VyIokBCgxDcmVhdGVNYXJrZXISRAoIbG9jYXRpb24Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 2) = "ASABKA4yMi5ydi5hbmFseXRpY3MucGxheWJhY2ttYXJrZXIuQ3JlYXRlTWFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 3) = "a2VyLkxvY2F0aW9uIjMKCExvY2F0aW9uEg0KCUlOU1BFQ1RPUhAAEgsKB1NJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 4) = "REVCQVIQARILCgdVTktOT1dOEAJCX/gBAaoCPVByby5TZXJpYWxpemF0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 5) = "SW50ZXJvcC5SVlByb3RvRGF0YS5BbmFseXRpY3MuUGxheWJhY2tNYXJrZXK6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 6) = "AhlBbmFseXRpY3NfUGxheWJhY2tNYXJrZXJfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<string>, string>(in buffer, 7))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(CreateMarker), CreateMarker.Parser, new string[1] { "Location" }, null, new Type[1] { typeof(CreateMarker.Types.Location) }, null, null)
		}));
	}
}
