using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue;

public static class AnalyticsTriggerCueReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsTriggerCueReflection()
	{
		_003C_003Ey__InlineArray36<string> buffer = default(_003C_003Ey__InlineArray36<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 0) = "ChlhbmFseXRpY3NUcmlnZ2VyQ3VlLnByb3RvEhhydi5hbmFseXRpY3MudHJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 1) = "Z2dlci5jdWUivAIKBVNsaWRlEhQKDG9iamVjdF9jb3VudBgBIAEoBRIeChZz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 2) = "Y3JvbGxpbmdfb2JqZWN0X2NvdW50GAIgASgFEiIKGmJhY2tncm91bmRfZnhf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 3) = "b2JqZWN0X2NvdW50GAMgASgFEhQKDGFjdGlvbl9jb3VudBgEIAEoBRITCgto";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 4) = "YXNfdGV4dF9meBgFIAEoCBIkChxtZWRpYV90ZXh0X2ZpbGxfb2JqZWN0X2Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 5) = "dW50GAYgASgFEiYKHmN1dF9vdXRfdGV4dF9maWxsX29iamVjdF9jb3VudBgH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 6) = "IAEoBRIuCiZiYWNrZ3JvdW5kX2JsdXJfdGV4dF9maWxsX29iamVjdF9jb3Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 7) = "dBgIIAEoBRIwCihiYWNrZ3JvdW5kX2ludmVydF90ZXh0X2ZpbGxfb2JqZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 8) = "X2NvdW50GAkgASgFIl0KFFNsaWRlRmlsZUZlZWRFbGVtZW50EkUKEWRlc3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 9) = "bmF0aW9uX2xheWVyGAEgASgOMioucnYuYW5hbHl0aWNzLnRyaWdnZXIuY3Vl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 10) = "LkRlc3RpbmF0aW9uTGF5ZXIiiAIKE1NsaWRlUnNzRmVlZEVsZW1lbnQSRgoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 11) = "Y29udGVudBgBIAEoDjI1LnJ2LmFuYWx5dGljcy50cmlnZ2VyLmN1ZS5TbGlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 12) = "ZVJzc0ZlZWRFbGVtZW50LkNvbnRlbnQSHAoUaXNfZGVsaW1pdGVyX2VuYWJs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 13) = "ZWQYAiABKAgSRQoRZGVzdGluYXRpb25fbGF5ZXIYAyABKA4yKi5ydi5hbmFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 14) = "eXRpY3MudHJpZ2dlci5jdWUuRGVzdGluYXRpb25MYXllciJECgdDb250ZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 15) = "EhMKD0NPTlRFTlRfVU5LTk9XThAAEgkKBVRJVExFEAESGQoVVElUTEVfQU5E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 16) = "X0RFU0NSSVBUSU9OEAIi5QQKGVNsaWRlU2Nyb2xsaW5nVGV4dEVsZW1lbnQS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 17) = "UAoJZGlyZWN0aW9uGAEgASgOMj0ucnYuYW5hbHl0aWNzLnRyaWdnZXIuY3Vl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 18) = "LlNsaWRlU2Nyb2xsaW5nVGV4dEVsZW1lbnQuRGlyZWN0aW9uElkKDnN0YXJ0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 19) = "X3Bvc2l0aW9uGAIgASgOMkEucnYuYW5hbHl0aWNzLnRyaWdnZXIuY3VlLlNs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 20) = "aWRlU2Nyb2xsaW5nVGV4dEVsZW1lbnQuU3RhcnRQb3NpdGlvbhIZChFpc19y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 21) = "ZXBlYXRfZW5hYmxlZBgDIAEoCBJICgVzcGVlZBgEIAEoDjI5LnJ2LmFuYWx5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 22) = "dGljcy50cmlnZ2VyLmN1ZS5TbGlkZVNjcm9sbGluZ1RleHRFbGVtZW50LlNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 23) = "ZWVkEkUKEWRlc3RpbmF0aW9uX2xheWVyGAUgASgOMioucnYuYW5hbHl0aWNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 24) = "LnRyaWdnZXIuY3VlLkRlc3RpbmF0aW9uTGF5ZXIiSQoJRGlyZWN0aW9uEhUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 25) = "EURJUkVDVElPTl9VTktOT1dOEAASCAoETEVGVBABEgkKBVJJR0hUEAISBgoC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 26) = "VVAQAxIICgRET1dOEAQiSgoNU3RhcnRQb3NpdGlvbhIaChZTVEFSVF9QT1NJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 27) = "VElPTl9VTktOT1dOEAASDQoJQVVUT01BVElDEAESDgoKT0ZGX1NDUkVFThAC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 28) = "IlgKBVNwZWVkEhEKDVNQRUVEX1VOS05PV04QABINCglWRVJZX1NMT1cQARII";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 29) = "CgRTTE9XEAISCgoGTUVESVVNEAMSCAoERkFTVBAEEg0KCVZFUllfRkFTVBAF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 30) = "KoMBChBEZXN0aW5hdGlvbkxheWVyEh0KGURFU1RJTkFUSU9OX0xBWUVSX1VO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 31) = "S05PV04QABIQCgxBTk5PVU5DRU1FTlQQARIQCgxQUkVTRU5UQVRJT04QAhIJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 32) = "CgVTVEFHRRADEgkKBVBST1BTEAQSDAoITUVTU0FHRVMQBRIICgRNQVNLEAZC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 33) = "WPgBAaoCOlByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 34) = "bmFseXRpY3MuVHJpZ2dlci5DdWW6AhVBbmFseXRpY3NfVHJnZ2VyX0N1ZV9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 35) = "BnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray36<string>, string>(in buffer, 36))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[1] { typeof(DestinationLayer) }, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(Slide), Slide.Parser, new string[9] { "ObjectCount", "ScrollingObjectCount", "BackgroundFxObjectCount", "ActionCount", "HasTextFx", "MediaTextFillObjectCount", "CutOutTextFillObjectCount", "BackgroundBlurTextFillObjectCount", "BackgroundInvertTextFillObjectCount" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SlideFileFeedElement), SlideFileFeedElement.Parser, new string[1] { "DestinationLayer" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(SlideRssFeedElement), SlideRssFeedElement.Parser, new string[3] { "Content", "IsDelimiterEnabled", "DestinationLayer" }, null, new Type[1] { typeof(SlideRssFeedElement.Types.Content) }, null, null),
			new GeneratedClrTypeInfo(typeof(SlideScrollingTextElement), SlideScrollingTextElement.Parser, new string[5] { "Direction", "StartPosition", "IsRepeatEnabled", "Speed", "DestinationLayer" }, null, new Type[3]
			{
				typeof(SlideScrollingTextElement.Types.Direction),
				typeof(SlideScrollingTextElement.Types.StartPosition),
				typeof(SlideScrollingTextElement.Types.Speed)
			}, null, null)
		}));
	}
}
