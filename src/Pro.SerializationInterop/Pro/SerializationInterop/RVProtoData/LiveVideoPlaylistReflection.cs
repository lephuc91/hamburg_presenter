using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class LiveVideoPlaylistReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static LiveVideoPlaylistReflection()
	{
		_003C_003Ey__InlineArray6<string> buffer = default(_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = "ChdsaXZlVmlkZW9QbGF5bGlzdC5wcm90bxIHcnYuZGF0YRoMYWN0aW9uLnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "b3RvGgp1dWlkLnByb3RvIn4KEUxpdmVWaWRlb1BsYXlsaXN0EiAKB2FjdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "bnMYASADKAsyDy5ydi5kYXRhLkFjdGlvbhIqChN0YXJnZXRlZF9sYXllcl9V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "VUlEGAIgASgLMg0ucnYuZGF0YS5VVUlEEhsKBHV1aWQYAyABKAsyDS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "YXRhLlVVSURCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "b3RvRGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<string>, string>(in buffer, 6))), new FileDescriptor[2]
		{
			ActionReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(LiveVideoPlaylist), LiveVideoPlaylist.Parser, new string[3] { "Actions", "TargetedLayerUUID", "Uuid" }, null, null, null, null)
		}));
	}
}
