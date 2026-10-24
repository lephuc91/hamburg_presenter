using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class PropresenterReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PropresenterReflection()
	{
		_003C_003Ey__InlineArray14<string> buffer = default(_003C_003Ey__InlineArray14<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 0) = "ChJwcm9wcmVzZW50ZXIucHJvdG8SB3J2LmRhdGEaDGFjdGlvbi5wcm90bxoV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 1) = "YXBwbGljYXRpb25JbmZvLnByb3RvGhNjdXN0b21PcHRpb25zLnByb3RvGg5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 2) = "bGF5bGlzdC5wcm90byKHAwoQUGxheWxpc3REb2N1bWVudBI4ChBhcHBsaWNh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 3) = "dGlvbl9pbmZvGAEgASgLMhgucnYuZGF0YS5BcHBsaWNhdGlvbkluZm9CBKiG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 4) = "GQESLAoEdHlwZRgCIAEoDjIeLnJ2LmRhdGEuUGxheWxpc3REb2N1bWVudC5U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 5) = "eXBlEiQKCXJvb3Rfbm9kZRgDIAEoCzIRLnJ2LmRhdGEuUGxheWxpc3QSKQoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 6) = "dGFncxgEIAMoCzIVLnJ2LmRhdGEuUGxheWxpc3QuVGFnQgSohhkBEjQKE2xp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 7) = "dmVfdmlkZW9fcGxheWxpc3QYBSABKAsyES5ydi5kYXRhLlBsYXlsaXN0QgSg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 8) = "hhkBEjMKEmRvd25sb2Fkc19wbGF5bGlzdBgGIAEoCzIRLnJ2LmRhdGEuUGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 9) = "eWxpc3RCBKiGGQEiTwoEVHlwZRIQCgxUWVBFX1VOS05PV04QABIVChFUWVBF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 10) = "X1BSRVNFTlRBVElPThABEg4KClRZUEVfTUVESUEQAhIOCgpUWVBFX0FVRElP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 11) = "EAMiPwoQU2V0dGluZ3NEb2N1bWVudBIlCgZsYWJlbHMYAiADKAsyFS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 12) = "YXRhLkFjdGlvbi5MYWJlbEoECAEQAkI0+AEBqgIkUHJvLlNlcmlhbGl6YXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 13) = "b25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray14<string>, string>(in buffer, 14))), new FileDescriptor[4]
		{
			ActionReflection.Descriptor,
			ApplicationInfoReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			PlaylistReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(PlaylistDocument), PlaylistDocument.Parser, new string[6] { "ApplicationInfo", "Type", "RootNode", "Tags", "LiveVideoPlaylist", "DownloadsPlaylist" }, null, new Type[1] { typeof(PlaylistDocument.Types.Type) }, null, null),
			new GeneratedClrTypeInfo(typeof(SettingsDocument), SettingsDocument.Parser, new string[1] { "Labels" }, null, null, null, null)
		}));
	}
}
