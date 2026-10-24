using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1MediaPlaylistItemReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1MediaPlaylistItemReflection()
	{
		_003C_003Ey__InlineArray9<string> buffer = default(_003C_003Ey__InlineArray9<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 0) = "Ch9wcm9BcGlWMU1lZGlhUGxheWxpc3RJdGVtLnByb3RvEgdydi5kYXRhGhhw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 1) = "cm9BcGlWMUlkZW50aWZpZXIucHJvdG8i8wEKGEFQSV92MV9NZWRpYVBsYXls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 2) = "aXN0SXRlbRImCgJpZBgBIAEoCzIaLnJ2LmRhdGEuQVBJX3YxX0lkZW50aWZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 3) = "ZXISTAoEdHlwZRgCIAEoDjI+LnJ2LmRhdGEuQVBJX3YxX01lZGlhUGxheWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 4) = "c3RJdGVtLkFQSV92MV9NZWRpYVBsYXlsaXN0SXRlbVR5cGUSDgoGYXJ0aXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 5) = "GAMgASgJEhAKCGR1cmF0aW9uGAQgASgNIj8KHEFQSV92MV9NZWRpYVBsYXls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 6) = "aXN0SXRlbVR5cGUSCQoFYXVkaW8QABIJCgVpbWFnZRABEgkKBXZpZGVvEAJC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 7) = "NPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 8) = "B1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<string>, string>(in buffer, 9))), new FileDescriptor[1] { ProApiV1IdentifierReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_MediaPlaylistItem), API_v1_MediaPlaylistItem.Parser, new string[4] { "Id", "Type", "Artist", "Duration" }, null, new Type[1] { typeof(API_v1_MediaPlaylistItem.Types.API_v1_MediaPlaylistItemType) }, null, null)
		}));
	}
}
