using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class PsbWorkspaceReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PsbWorkspaceReflection()
	{
		_003C_003Ey__InlineArray14<string> buffer = default(_003C_003Ey__InlineArray14<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 0) = "ChJwc2JXb3Jrc3BhY2UucHJvdG8SB3J2LmRhdGEaGGFkdmVydGlzZW1lbnRH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 1) = "cm91cC5wcm90bxoSZGlnaXRhbEF1ZGlvLnByb3RvGgtpbnB1dC5wcm90bxoP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 2) = "cHJvc2NyZWVuLnByb3RvGg9yZWNvcmRpbmcucHJvdG8aCnpvbmUucHJvdG8i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 3) = "jwMKFlByb1Njb3JlYm9hcmRXb3Jrc3BhY2USMAoLcHJvX3NjcmVlbnMYASAD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 4) = "KAsyGy5ydi5kYXRhLlByb1ByZXNlbnRlclNjcmVlbhIoCgt2aWRlb0lucHV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 5) = "cxgCIAMoCzITLnJ2LmRhdGEuVmlkZW9JbnB1dBI8Cg9yZWNvcmRfc2V0dGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 6) = "Z3MYAyABKAsyIy5ydi5kYXRhLlJlY29yZGluZy5TZXR0aW5nc0RvY3VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 7) = "EjgKE2RpZ2l0YWxfYXVkaW9fc2V0dXAYBCABKAsyGy5ydi5kYXRhLkRpZ2l0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 8) = "YWxBdWRpby5TZXR1cBIpCgxhdWRpb19pbnB1dHMYBSADKAsyEy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 9) = "LkF1ZGlvSW5wdXQSIwobYXVkaW9faW5wdXRfdHJhbnNpdGlvbl90aW1lGAYg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 10) = "ASgBEhwKBXpvbmVzGAcgAygLMg0ucnYuZGF0YS5ab25lEjMKDmFkdmVydGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 11) = "ZW1lbnRzGAggAygLMhsucnYuZGF0YS5BZHZlcnRpc2VtZW50R3JvdXBCNPgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 12) = "AaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray14<string>, string>(ref buffer, 13) = "RGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray14<string>, string>(in buffer, 14))), new FileDescriptor[6]
		{
			AdvertisementGroupReflection.Descriptor,
			DigitalAudioReflection.Descriptor,
			InputReflection.Descriptor,
			ProscreenReflection.Descriptor,
			RecordingReflection.Descriptor,
			ZoneReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(ProScoreboardWorkspace), ProScoreboardWorkspace.Parser, new string[8] { "ProScreens", "VideoInputs", "RecordSettings", "DigitalAudioSetup", "AudioInputs", "AudioInputTransitionTime", "Zones", "Advertisements" }, null, null, null, null)
		}));
	}
}
