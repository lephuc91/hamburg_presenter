using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class Rv2DReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static Rv2DReflection()
	{
		_003C_003Ey__InlineArray40<string> buffer = default(_003C_003Ey__InlineArray40<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 0) = "CgpydjJkLnByb3RvEgdydi5kYXRhGgxhY3Rpb24ucHJvdG8aC2NvbG9yLnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 1) = "b3RvGgljdWUucHJvdG8aEmdyYXBoaWNzRGF0YS5wcm90bxoTbXVzaWNLZXlT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 2) = "Y2FsZS5wcm90bxoNcHJvQ29yZS5wcm90bxoLc2xpZGUucHJvdG8ixQEKFUlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 3) = "ZW50aWZpY2F0aW9uT3ZlcmxheRITCgtzY3JlZW5fbmFtZRgDIAEoCRI2Cgdv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 4) = "dXRwdXRzGAEgAygLMiUucnYuZGF0YS5JZGVudGlmaWNhdGlvbk92ZXJsYXku";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 5) = "T3V0cHV0Gl8KBk91dHB1dBIJCgF4GAEgASgFEgkKAXkYAiABKAUSDQoFd2lk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 6) = "dGgYAyABKAUSDgoGaGVpZ2h0GAQgASgFEgwKBG5hbWUYBSABKAkSEgoKZnJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 7) = "bWVfcmF0ZRgGIAEoASLyAQoaTGF5ZXJJZGVudGlmaWNhdGlvbk92ZXJsYXkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 8) = "OAoFbGF5ZXIYASABKA4yKS5ydi5kYXRhLkxheWVySWRlbnRpZmljYXRpb25P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 9) = "dmVybGF5LkxheWVyEhIKCmxheWVyX25hbWUYAiABKAkihQEKBUxheWVyEhUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 10) = "EUxBWUVSX1ZJREVPX0lOUFVUEAASDwoLTEFZRVJfTUVESUEQARIWChJMQVlF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 11) = "Ul9QUkVTRU5UQVRJT04QAhIXChNMQVlFUl9BTk5PVU5DRU1FTlRTEAMSDwoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 12) = "TEFZRVJfUFJPUFMQBBISCg5MQVlFUl9NRVNTQUdFUxAFIr4FCgtSZW5kZXJM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 13) = "YXllchIzCgljb21wb3NpdGUYASABKAsyHi5ydi5kYXRhLlJlbmRlckxheWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 14) = "LkNvbXBvc2l0ZUgAEh8KBW1lZGlhGAIgASgLMg4ucnYuZGF0YS5NZWRpYUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 15) = "EjQKB2N1dF9vdXQYAyABKAsyIS5ydi5kYXRhLkdyYXBoaWNzLlRleHQuQ3V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 16) = "T3V0RmlsbEgAEj8KEWJhY2tncm91bmRfZWZmZWN0GAQgASgLMiIucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 17) = "YS5HcmFwaGljcy5CYWNrZ3JvdW5kRWZmZWN0SAASRQoNb3V0cHV0X3NjcmVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 18) = "bhgFIAEoCzIsLnJ2LmRhdGEuU2xpZGUuRWxlbWVudC5EYXRhTGluay5PdXRw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 19) = "dXRTY3JlZW5IABIzCglzY3JvbGxpbmcYBiABKAsyHi5ydi5kYXRhLlJlbmRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 20) = "ckxheWVyLlNjcm9sbGluZ0gAEkEKC3NsaWRlX2ltYWdlGAcgASgLMioucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 21) = "ZGF0YS5TbGlkZS5FbGVtZW50LkRhdGFMaW5rLlNsaWRlSW1hZ2VIABI0CgR6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 22) = "b25lGAggASgLMiQucnYuZGF0YS5TbGlkZS5FbGVtZW50LkRhdGFMaW5rLlpv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 23) = "bmVIABImCgZib3VuZHMYCSABKAsyFi5ydi5kYXRhLkdyYXBoaWNzLlJlY3QS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 24) = "NQoJZmxpcF9tb2RlGAogASgOMiIucnYuZGF0YS5HcmFwaGljcy5FbGVtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 25) = "LkZsaXBNb2RlEhAKCHJvdGF0aW9uGAsgASgBEhMKC2J1aWxkX2luZGV4GAwg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 26) = "ASgFEhEKCWJ1aWxkX291dBgNIAEoCBIXCg9idWlsZF9vdXRfaW5kZXgYDiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 27) = "KAUaCwoJQ29tcG9zaXRlGiEKCVNjcm9sbGluZxIUCgxzZWdtZW50X3NpemUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 28) = "ASABKAVCCwoJTGF5ZXJUeXBlIvUBCgxTbGlkZUVsZW1lbnQSJwoHZWxlbWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 29) = "dBgBIAEoCzIWLnJ2LmRhdGEuU2xpZGUuRWxlbWVudBITCgtidWlsZF9pbmRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 30) = "eBgCIAEoBRIoCghiYXNlX2tleRgDIAEoCzIWLnJ2LmRhdGEuTXVzaWNLZXlT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 31) = "Y2FsZRIqCgp0YXJnZXRfa2V5GAQgASgLMhYucnYuZGF0YS5NdXNpY0tleVNj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 32) = "YWxlEjcKB2Nvb2tpZXMYBSADKAsyJi5ydi5kYXRhLldlYkZpbGxUb2tlbkFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 33) = "ZENvb2tpZXMuQ29va2llEhgKEGZvcl9zdGFnZV9sYXlvdXQYBiABKAgidgoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 34) = "U2xpZGVQcmV2aWV3EhkKA2N1ZRgBIAEoCzIMLnJ2LmRhdGEuQ3VlEicKB2Vs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 35) = "ZW1lbnQYAiABKAsyFi5ydi5kYXRhLlNsaWRlLkVsZW1lbnQSIgoKYmFja2dy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 36) = "b3VuZBgDIAEoCzIOLnJ2LmRhdGEuQ29sb3IiTgoMTWVkaWFQcmV2aWV3Eh8K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 37) = "BmFjdGlvbhgBIAEoCzIPLnJ2LmRhdGEuQWN0aW9uEh0KBW1lZGlhGAIgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 38) = "Mg4ucnYuZGF0YS5NZWRpYUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray40<string>, string>(ref buffer, 39) = "cm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray40<string>, string>(in buffer, 40))), new FileDescriptor[7]
		{
			ActionReflection.Descriptor,
			ColorReflection.Descriptor,
			CueReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			MusicKeyScaleReflection.Descriptor,
			ProCoreReflection.Descriptor,
			SlideReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[6]
		{
			new GeneratedClrTypeInfo(typeof(IdentificationOverlay), IdentificationOverlay.Parser, new string[2] { "ScreenName", "Outputs" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(IdentificationOverlay.Types.Output), IdentificationOverlay.Types.Output.Parser, new string[6] { "X", "Y", "Width", "Height", "Name", "FrameRate" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(LayerIdentificationOverlay), LayerIdentificationOverlay.Parser, new string[2] { "Layer", "LayerName" }, null, new Type[1] { typeof(LayerIdentificationOverlay.Types.Layer) }, null, null),
			new GeneratedClrTypeInfo(typeof(RenderLayer), RenderLayer.Parser, new string[14]
			{
				"Composite", "Media", "CutOut", "BackgroundEffect", "OutputScreen", "Scrolling", "SlideImage", "Zone", "Bounds", "FlipMode",
				"Rotation", "BuildIndex", "BuildOut", "BuildOutIndex"
			}, new string[1] { "LayerType" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(RenderLayer.Types.Composite), RenderLayer.Types.Composite.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(RenderLayer.Types.Scrolling), RenderLayer.Types.Scrolling.Parser, new string[1] { "SegmentSize" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(SlideElement), SlideElement.Parser, new string[6] { "Element", "BuildIndex", "BaseKey", "TargetKey", "Cookies", "ForStageLayout" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SlidePreview), SlidePreview.Parser, new string[3] { "Cue", "Element", "Background" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(MediaPreview), MediaPreview.Parser, new string[2] { "Action", "Media" }, null, null, null, null)
		}));
	}
}
