using System;
using Google.Protobuf.Reflection;

namespace Rv.Analytics.Powerpoint;

public static class AnalyticsPowerPointReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsPowerPointReflection()
	{
		_003C_003Ey__InlineArray8<string> buffer = default(_003C_003Ey__InlineArray8<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 0) = "ChlhbmFseXRpY3NQb3dlclBvaW50LnByb3RvEhdydi5hbmFseXRpY3MucG93";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 1) = "ZXJwb2ludCJ8ChBJbXBvcnRQb3dlclBvaW50EjEKBHR5cGUYASABKA4yIy5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 2) = "di5hbmFseXRpY3MucG93ZXJwb2ludC5JbXBvcnRUeXBlEjUKBmZvcm1hdBgC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 3) = "IAEoDjIlLnJ2LmFuYWx5dGljcy5wb3dlcnBvaW50LkltcG9ydEZvcm1hdCpZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 4) = "CgpJbXBvcnRUeXBlEhQKEFNMSURFU19BU19JTUFHRVMQABINCglURVhUX09O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 5) = "TFkQARITCg9URVhUX0FORF9JTUFHRVMQAhIRCg1DT1JFX09QRU5fWE1MEAMq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 6) = "LQoMSW1wb3J0Rm9ybWF0EgoKBlVOS09XThAAEgcKA1BQVBABEggKBFBQVFgQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray8<string>, string>(ref buffer, 7) = "AkIb+AEBugIVQW5hbHl0aWNzX1Bvd2VyUG9pbnRfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray8<string>, string>(in buffer, 8))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[2]
		{
			typeof(ImportType),
			typeof(ImportFormat)
		}, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(ImportPowerPoint), ImportPowerPoint.Parser, new string[2] { "Type", "Format" }, null, null, null, null)
		}));
	}
}
