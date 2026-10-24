using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.ProContent;

public static class AnalyticsProContentReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsProContentReflection()
	{
		_003C_003Ey__InlineArray5<string> buffer = default(_003C_003Ey__InlineArray5<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 0) = "ChlhbmFseXRpY3NQcm9Db250ZW50LnByb3RvEhdydi5hbmFseXRpY3MucHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 1) = "Y29udGVudCIOCgxNZWRpYUJpblZpZXciCgoIRG93bmxvYWQiDwoNRG93bmxv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 2) = "YWRSZXRyeUJX+AEBqgI5UHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 3) = "dG9EYXRhLkFuYWx5dGljcy5Qcm9Db250ZW50ugIVQW5hbHl0aWNzX1Byb0Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 4) = "bnRlbnRfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<string>, string>(in buffer, 5))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[3]
		{
			new GeneratedClrTypeInfo(typeof(MediaBinView), MediaBinView.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Download), Download.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DownloadRetry), DownloadRetry.Parser, null, null, null, null, null)
		}));
	}
}
