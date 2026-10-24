using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProscreenReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProscreenReflection()
	{
		_003C_003Ey__InlineArray29<string> buffer = default(_003C_003Ey__InlineArray29<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 0) = "Cg9wcm9zY3JlZW4ucHJvdG8SB3J2LmRhdGEaC2NvbG9yLnByb3RvGhJncmFw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 1) = "aGljc0RhdGEucHJvdG8aDXNjcmVlbnMucHJvdG8aCnV1aWQucHJvdG8i4gYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 2) = "ElByb1ByZXNlbnRlclNjcmVlbhIMCgRuYW1lGAEgASgJEjsKC3NjcmVlbl90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 3) = "eXBlGAIgASgOMiYucnYuZGF0YS5Qcm9QcmVzZW50ZXJTY3JlZW4uU2NyZWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 4) = "VHlwZRJLChJhcnJhbmdlbWVudF9zaW5nbGUYAyABKAsyLS5ydi5kYXRhLlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 5) = "b1ByZXNlbnRlclNjcmVlbi5TaW5nbGVBcnJhbmdlbWVudEgAEk8KFGFycmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 6) = "Z2VtZW50X2NvbWJpbmVkGAQgASgLMi8ucnYuZGF0YS5Qcm9QcmVzZW50ZXJT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 7) = "Y3JlZW4uQ29tYmluZWRBcnJhbmdlbWVudEgAElIKFmFycmFuZ2VtZW50X2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 8) = "Z2VfYmxlbmQYBSABKAsyMC5ydi5kYXRhLlByb1ByZXNlbnRlclNjcmVlbi5F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 9) = "ZGdlQmxlbmRBcnJhbmdlbWVudEgAEigKEGJhY2tncm91bmRfY29sb3IYBiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 10) = "KAsyDi5ydi5kYXRhLkNvbG9yEhsKBHV1aWQYByABKAsyDS5ydi5kYXRhLlVV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 11) = "SUQSIAoYYmFja2dyb3VuZF9jb2xvcl9lbmFibGVkGAggASgIEhsKEXJlbmRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 12) = "cmluZ19lbmFibGVkGAkgASgISAEaNQoRU2luZ2xlQXJyYW5nZW1lbnQSIAoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 13) = "c2NyZWVucxgBIAMoCzIPLnJ2LmRhdGEuU2NyZWVuGlYKE0NvbWJpbmVkQXJy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 14) = "YW5nZW1lbnQSIAoHc2NyZWVucxgBIAMoCzIPLnJ2LmRhdGEuU2NyZWVuEgwK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 15) = "BHJvd3MYAiABKA0SDwoHY29sdW1ucxgDIAEoDRp3ChRFZGdlQmxlbmRBcnJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 16) = "bmdlbWVudBIUCgxzY3JlZW5fY291bnQYASABKA0SIAoHc2NyZWVucxgCIAMo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 17) = "CzIPLnJ2LmRhdGEuU2NyZWVuEicKC2VkZ2VfYmxlbmRzGAMgAygLMhIucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 18) = "ZGF0YS5FZGdlQmxlbmQiVgoKU2NyZWVuVHlwZRIXChNTQ1JFRU5fVFlQRV9V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 19) = "TktOT1dOEAASGAoUU0NSRUVOX1RZUEVfQVVESUVOQ0UQARIVChFTQ1JFRU5f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 20) = "VFlQRV9TVEFHRRACQg0KC0FycmFuZ2VtZW50QhoKGFJlbmRlcmluZ0VuYWJs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 21) = "ZWRPcHRpb25hbCL7AQoXQ2xvdWRQcm9QcmVzZW50ZXJTY3JlZW4SDAoEbmFt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 22) = "ZRgBIAEoCRI7CgtzY3JlZW5fdHlwZRgCIAEoDjImLnJ2LmRhdGEuUHJvUHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 23) = "c2VudGVyU2NyZWVuLlNjcmVlblR5cGUSGwoEdXVpZBgGIAEoCzINLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 24) = "dGEuVVVJRBIkCgRzaXplGAcgASgLMhYucnYuZGF0YS5HcmFwaGljcy5TaXpl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 25) = "SgQIAxAESgQIBBAFSgQIBRAGUhJhcnJhbmdlbWVudF9zaW5nbGVSFGFycmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 26) = "Z2VtZW50X2NvbWJpbmVkUhZhcnJhbmdlbWVudF9lZGdlX2JsZW5kQjT4AQGq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 27) = "AiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray29<string>, string>(ref buffer, 28) = "dGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray29<string>, string>(in buffer, 29))), new FileDescriptor[4]
		{
			ColorReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			ScreensReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(ProPresenterScreen), ProPresenterScreen.Parser, new string[9] { "Name", "ScreenType", "ArrangementSingle", "ArrangementCombined", "ArrangementEdgeBlend", "BackgroundColor", "Uuid", "BackgroundColorEnabled", "RenderingEnabled" }, new string[2] { "Arrangement", "RenderingEnabledOptional" }, new Type[1] { typeof(ProPresenterScreen.Types.ScreenType) }, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(ProPresenterScreen.Types.SingleArrangement), ProPresenterScreen.Types.SingleArrangement.Parser, new string[1] { "Screens" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ProPresenterScreen.Types.CombinedArrangement), ProPresenterScreen.Types.CombinedArrangement.Parser, new string[3] { "Screens", "Rows", "Columns" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(ProPresenterScreen.Types.EdgeBlendArrangement), ProPresenterScreen.Types.EdgeBlendArrangement.Parser, new string[3] { "ScreenCount", "Screens", "EdgeBlends" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(CloudProPresenterScreen), CloudProPresenterScreen.Parser, new string[4] { "Name", "ScreenType", "Uuid", "Size" }, null, null, null, null)
		}));
	}
}
