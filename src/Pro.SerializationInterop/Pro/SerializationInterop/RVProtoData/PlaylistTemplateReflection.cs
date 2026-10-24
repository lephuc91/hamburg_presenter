using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class PlaylistTemplateReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PlaylistTemplateReflection()
	{
		_003C_003Ey__InlineArray6<string> buffer = default(_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = "ChZwbGF5bGlzdFRlbXBsYXRlLnByb3RvEgdydi5kYXRhGg5wbGF5bGlzdC5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "cm90byKSAQoQUGxheWxpc3RUZW1wbGF0ZRI1Cgl0ZW1wbGF0ZXMYASADKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "Ii5ydi5kYXRhLlBsYXlsaXN0VGVtcGxhdGUuVGVtcGxhdGUaRwoIVGVtcGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "dGUSDAoEbmFtZRgBIAEoCRItCg5wbGF5bGlzdF9pdGVtcxgCIAMoCzIVLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "LmRhdGEuUGxheWxpc3RJdGVtQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbklu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "dGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<string>, string>(in buffer, 6))), new FileDescriptor[1] { PlaylistReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(PlaylistTemplate), PlaylistTemplate.Parser, new string[1] { "Templates" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(PlaylistTemplate.Types.Template), PlaylistTemplate.Types.Template.Parser, new string[2] { "Name", "PlaylistItems" }, null, null, null, null)
			})
		}));
	}
}
