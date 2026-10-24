using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Timecode;

public static class AnalyticsTimecodeReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsTimecodeReflection()
	{
		_003C_003Ey__InlineArray7<string> buffer = default(_003C_003Ey__InlineArray7<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 0) = "ChdhbmFseXRpY3NUaW1lY29kZS5wcm90bxIVcnYuYW5hbHl0aWNzLnRpbWVj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 1) = "b2RlIlgKB1N0YXJ0dXASGwoTaXNfaW5wdXRfY29uZmlndXJlZBgBIAEoCBIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 2) = "Cgppc19lbmFibGVkGAIgASgIEhwKFGlzX3BsYXlsaXN0X3NlbGVjdGVkGAMg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 3) = "ASgIIk4KCEFjdGl2YXRlEhsKE3BsYXlsaXN0X2l0ZW1fY291bnQYASABKAUS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 4) = "EQoJY3VlX2NvdW50GAIgASgFEhIKCmlzX3N0YXJ0dXAYAyABKAhCU/gBAaoC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 5) = "N1Byby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YS5BbmFseXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 6) = "Y3MuVGltZWNvZGW6AhNBbmFseXRpY3NfVGltZWNvZGVfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<string>, string>(in buffer, 7))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Startup), Startup.Parser, new string[3] { "IsInputConfigured", "IsEnabled", "IsPlaylistSelected" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Activate), Activate.Parser, new string[3] { "PlaylistItemCount", "CueCount", "IsStartup" }, null, null, null, null)
		}));
	}
}
