using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Import;

public static class AnalyticsImportReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsImportReflection()
	{
		_003C_003Ey__InlineArray12<string> buffer = default(_003C_003Ey__InlineArray12<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 0) = "ChVhbmFseXRpY3NJbXBvcnQucHJvdG8SE3J2LmFuYWx5dGljcy5pbXBvcnQa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 1) = "GmFuYWx5dGljc011bHRpVHJhY2tzLnByb3RvItACCgpTb25nU2VsZWN0EikK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 2) = "IXRlbXBsYXRlX3NsaWRlX3RleHRfZWxlbWVudF9jb3VudBgBIAEoBRIcChRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 3) = "bXBvcnRfaW50b19wbGF5bGlzdBgCIAEoCBJFCg5saW5lX2RlbGltaXRlchgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 4) = "IAEoDjItLnJ2LmFuYWx5dGljcy5pbXBvcnQuU29uZ1NlbGVjdC5MaW5lRGVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 5) = "aW1pdGVyEhwKFGxpbmVfZGVsaW1pdGVyX2NvdW50GAQgASgFEhoKEmRpZF9v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 6) = "cGVuX2VkaXRfdmlldxgFIAEoCBI1CgttdWx0aXRyYWNrcxgGIAEoCzIgLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 7) = "LmFuYWx5dGljcy5tdWx0aXRyYWNrcy5JbXBvcnQiQQoNTGluZURlbGltaXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 8) = "chILCgdVTktOT1dOEAASDgoKTElORV9CUkVBSxABEhMKD1BBUkFHUkFQSF9C";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 9) = "UkVBSxACQk/4AQGqAjVQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 10) = "b0RhdGEuQW5hbHl0aWNzLkltcG9ydLoCEUFuYWx5dGljc19JbXBvcnRfYgZw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 11) = "cm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray12<string>, string>(in buffer, 12))), new FileDescriptor[1] { AnalyticsMultiTracksReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(SongSelect), SongSelect.Parser, new string[6] { "TemplateSlideTextElementCount", "ImportIntoPlaylist", "LineDelimiter", "LineDelimiterCount", "DidOpenEditView", "Multitracks" }, null, new Type[1] { typeof(SongSelect.Types.LineDelimiter) }, null, null)
		}));
	}
}
