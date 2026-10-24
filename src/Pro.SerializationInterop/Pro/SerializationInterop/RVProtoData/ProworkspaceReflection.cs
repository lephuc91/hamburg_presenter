using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProworkspaceReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProworkspaceReflection()
	{
		_003C_003Ey__InlineArray33<string> buffer = default(_003C_003Ey__InlineArray33<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 0) = "ChJwcm93b3Jrc3BhY2UucHJvdG8SB3J2LmRhdGEaC2F1ZGlvLnByb3RvGhNj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 1) = "dXN0b21PcHRpb25zLnByb3RvGhJkaWdpdGFsQXVkaW8ucHJvdG8aC2lucHV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 2) = "LnByb3RvGhVwcm9BdWRpZW5jZUxvb2sucHJvdG8aD3Byb3NjcmVlbi5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 3) = "bxoNcHJvTWFzay5wcm90bxoPcmVjb3JkaW5nLnByb3RvGgtzdGFnZS5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 4) = "byLXBgoVUHJvUHJlc2VudGVyV29ya3NwYWNlEjYKC3Byb19zY3JlZW5zGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 5) = "AygLMhsucnYuZGF0YS5Qcm9QcmVzZW50ZXJTY3JlZW5CBKiGGQESMAoOYXVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 6) = "aWVuY2VfbG9va3MYAiADKAsyGC5ydi5kYXRhLlByb0F1ZGllbmNlTG9vaxI6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 7) = "ChJsaXZlX2F1ZGllbmNlX2xvb2sYAyABKAsyGC5ydi5kYXRhLlByb0F1ZGll";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 8) = "bmNlTG9va0IEqIYZARIfCgVtYXNrcxgEIAMoCzIQLnJ2LmRhdGEuUHJvTWFz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 9) = "axIuCgt2aWRlb0lucHV0cxgFIAMoCzITLnJ2LmRhdGEuVmlkZW9JbnB1dEIE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 10) = "qIYZARJEChVzdGFnZV9sYXlvdXRfbWFwcGluZ3MYBiADKAsyHy5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 11) = "LlN0YWdlLlNjcmVlbkFzc2lnbm1lbnRCBKiGGQESOwoOYXVkaW9fc2V0dGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 12) = "Z3MYByABKAsyHy5ydi5kYXRhLkF1ZGlvLlNldHRpbmdzRG9jdW1lbnRCAhgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 13) = "EiEKFXNlbGVjdGVkX2xpYnJhcnlfbmFtZRgIIAEoCUICGAESQgoPcmVjb3Jk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 14) = "X3NldHRpbmdzGAkgASgLMiMucnYuZGF0YS5SZWNvcmRpbmcuU2V0dGluZ3NE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 15) = "b2N1bWVudEIEoIYZARI+ChNkaWdpdGFsX2F1ZGlvX3NldHVwGAogASgLMhsu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 16) = "cnYuZGF0YS5EaWdpdGFsQXVkaW8uU2V0dXBCBKiGGQESLwoMYXVkaW9faW5w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 17) = "dXRzGAsgAygLMhMucnYuZGF0YS5BdWRpb0lucHV0QgSohhkBEiMKG2F1ZGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 18) = "X2lucHV0X3RyYW5zaXRpb25fdGltZRgMIAEoARI+ChRjbG91ZF9vdXRwdXRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 19) = "c2NyZWVucxgNIAMoCzIgLnJ2LmRhdGEuQ2xvdWRQcm9QcmVzZW50ZXJTY3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 20) = "ZW4SNAoSY2xvdWRfdmlkZW9faW5wdXRzGA4gAygLMhgucnYuZGF0YS5DbG91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 21) = "ZFZpZGVvSW5wdXQSNAoSY2xvdWRfYXVkaW9faW5wdXRzGA8gAygLMhgucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 22) = "ZGF0YS5DbG91ZEF1ZGlvSW5wdXQSGwoTYXVkaW9fY2hhbm5lbF9jb3VudBgQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 23) = "IAEoDSLaAgoaUHJvUHJlc2VudGVyTG9jYWxXb3Jrc3BhY2USPgoTZGlnaXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 24) = "bF9hdWRpb19zZXR1cBgBIAEoCzIbLnJ2LmRhdGEuRGlnaXRhbEF1ZGlvLlNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 25) = "dHVwQgSghhkBEjAKC3Byb19zY3JlZW5zGAIgAygLMhsucnYuZGF0YS5Qcm9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 26) = "cmVzZW50ZXJTY3JlZW4SKQoMdmlkZW9faW5wdXRzGAMgAygLMhMucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 27) = "YS5WaWRlb0lucHV0EikKDGF1ZGlvX2lucHV0cxgEIAMoCzITLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 28) = "QXVkaW9JbnB1dBI0ChJsaXZlX2F1ZGllbmNlX2xvb2sYBSABKAsyGC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 29) = "YXRhLlByb0F1ZGllbmNlTG9vaxI+ChVzdGFnZV9sYXlvdXRfbWFwcGluZ3MY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 30) = "BiADKAsyHy5ydi5kYXRhLlN0YWdlLlNjcmVlbkFzc2lnbm1lbnRCNPgBAaoC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 31) = "JFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray33<string>, string>(ref buffer, 32) = "YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray33<string>, string>(in buffer, 33))), new FileDescriptor[9]
		{
			AudioReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			DigitalAudioReflection.Descriptor,
			InputReflection.Descriptor,
			ProAudienceLookReflection.Descriptor,
			ProscreenReflection.Descriptor,
			ProMaskReflection.Descriptor,
			RecordingReflection.Descriptor,
			StageReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(ProPresenterWorkspace), ProPresenterWorkspace.Parser, new string[16]
			{
				"ProScreens", "AudienceLooks", "LiveAudienceLook", "Masks", "VideoInputs", "StageLayoutMappings", "AudioSettings", "SelectedLibraryName", "RecordSettings", "DigitalAudioSetup",
				"AudioInputs", "AudioInputTransitionTime", "CloudOutputScreens", "CloudVideoInputs", "CloudAudioInputs", "AudioChannelCount"
			}, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ProPresenterLocalWorkspace), ProPresenterLocalWorkspace.Parser, new string[6] { "DigitalAudioSetup", "ProScreens", "VideoInputs", "AudioInputs", "LiveAudienceLook", "StageLayoutMappings" }, null, null, null, null)
		}));
	}
}
