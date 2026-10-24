using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProCoreFeatureFlagsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProCoreFeatureFlagsReflection()
	{
		_003C_003Ey__InlineArray11<string> buffer = default(_003C_003Ey__InlineArray11<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 0) = "Chlwcm9Db3JlRmVhdHVyZUZsYWdzLnByb3RvEgdydi5kYXRhIuoCChRSZXNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 1) = "bHZlZEZlYXR1cmVGbGFncxIlCh1jb250ZW50X3N0b3JlX3N0YWdpbmdfZW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 2) = "YmxlZBgBIAEoCBIkChxzdGFnaW5nX2FwaV9lbmRwb2ludF9lbmFibGVkGAgg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 3) = "ASgIEiMKG3Byb19jb250ZW50X3N0YWdpbmdfZW5hYmxlZBgKIAEoCBIgChhj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 4) = "b3JlX25ldHdvcmthcGlfcGxheWxpc3QYCyABKAgSJAocY29yZV9uZXR3b3Jr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 5) = "YXBpX3ByZXNlbnRhdGlvbhgMIAEoCBIYChBjb3JlX2NsaWVudF9zeW5jGA8g";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 6) = "ASgIEh0KFWhkcl9yZW5kZXJpbmdfZW5hYmxlZBgRIAEoCBIjChtzZXJ2ZXJf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 7) = "ZHJpdmVuX2ZlYXR1cmVfZmxhZ3MYEiABKAhKBAgCEANKBAgDEARKBAgEEAVK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 8) = "BAgFEAZKBAgGEAdKBAgHEAhKBAgJEApKBAgNEA5KBAgOEA9KBAgQEBFCNPgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 9) = "AaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray11<string>, string>(ref buffer, 10) = "RGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray11<string>, string>(in buffer, 11))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(ResolvedFeatureFlags), ResolvedFeatureFlags.Parser, new string[8] { "ContentStoreStagingEnabled", "StagingApiEndpointEnabled", "ProContentStagingEnabled", "CoreNetworkapiPlaylist", "CoreNetworkapiPresentation", "CoreClientSync", "HdrRenderingEnabled", "ServerDrivenFeatureFlags" }, null, null, null, null)
		}));
	}
}
