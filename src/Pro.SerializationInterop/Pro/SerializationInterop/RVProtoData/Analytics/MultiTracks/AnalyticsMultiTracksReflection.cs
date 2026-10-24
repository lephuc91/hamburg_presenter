using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;

public static class AnalyticsMultiTracksReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsMultiTracksReflection()
	{
		_003C_003Ey__InlineArray12<string> buffer = default(_003C_003Ey__InlineArray12<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 0) = "ChphbmFseXRpY3NNdWx0aVRyYWNrcy5wcm90bxIYcnYuYW5hbHl0aWNzLm11";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 1) = "bHRpdHJhY2tzInwKB1N0YXJ0dXASMwoJY2hhcnRfcHJvGAEgASgOMiAucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 2) = "YW5hbHl0aWNzLm11bHRpdHJhY2tzLlN0YXR1cxI8ChJwcm9wcmVzZW50ZXJf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 3) = "YWRkb24YAiABKA4yIC5ydi5hbmFseXRpY3MubXVsdGl0cmFja3MuU3RhdHVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 4) = "IqUBCgZJbXBvcnQSMwoJY2hhcnRfcHJvGAEgASgOMiAucnYuYW5hbHl0aWNz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 5) = "Lm11bHRpdHJhY2tzLlN0YXR1cxI8ChJwcm9wcmVzZW50ZXJfYWRkb24YAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 6) = "KA4yIC5ydi5hbmFseXRpY3MubXVsdGl0cmFja3MuU3RhdHVzEhkKEWNoYXJ0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 7) = "c19hdXRvbWF0aW9uGAMgASgIEg0KBWxpbmVzGAQgASgFKjEKBlN0YXR1cxIM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 8) = "CghESVNBQkxFRBAAEg0KCUNBTkNFTExFRBABEgoKBkFDVElWRRACQln4AQGq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 9) = "AjpQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGEuQW5hbHl0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 10) = "aWNzLk11bHRpVHJhY2tzugIWQW5hbHl0aWNzX011bHRpVHJhY2tzX2IGcHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 11) = "dG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray12<string>, string>(in buffer, 12))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[1] { typeof(Status) }, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Startup), Startup.Parser, new string[2] { "ChartPro", "PropresenterAddon" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Import), Import.Parser, new string[4] { "ChartPro", "PropresenterAddon", "ChartsAutomation", "Lines" }, null, null, null, null)
		}));
	}
}
