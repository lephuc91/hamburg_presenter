using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class UserFeedbackReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static UserFeedbackReflection()
	{
		_003C_003Ey__InlineArray21<string> buffer = default(_003C_003Ey__InlineArray21<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 0) = "ChJ1c2VyRmVlZGJhY2sucHJvdG8SB3J2LmRhdGEitgYKDFVzZXJGZWVkYmFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 1) = "axqlBgoTQXBwbGljYXRpb25NZXRhZGF0YRIbChNhcHBsaWNhdGlvbl92ZXJz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 2) = "aW9uGAEgASgJEhIKCm9zX3ZlcnNpb24YAiABKAkSXAoVYXBwbGljYXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 3) = "aW5zdGFuY2VzGAMgAygLMj0ucnYuZGF0YS5Vc2VyRmVlZGJhY2suQXBwbGlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 4) = "YXRpb25NZXRhZGF0YS5BcHBsaWNhdGlvbkluc3RhbmNlEmkKImJsYWNrbWFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 5) = "aWNfZGVza3RvcF92aWRlb19pbnN0YW5jZXMYBCADKAsyPS5ydi5kYXRhLlVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 6) = "ZXJGZWVkYmFjay5BcHBsaWNhdGlvbk1ldGFkYXRhLkFwcGxpY2F0aW9uSW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 7) = "dGFuY2USQQoHc2NyZWVucxgFIAMoCzIwLnJ2LmRhdGEuVXNlckZlZWRiYWNr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 8) = "LkFwcGxpY2F0aW9uTWV0YWRhdGEuU2NyZWVuEh8KF2NyYXNoX3JlcG9ydGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 9) = "Z19lbmFibGVkGAYgASgIEiMKG2FuYWx5dGljc19yZXBvcnRpbmdfZW5hYmxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 10) = "ZBgHIAEoCBIdChVlbmFibGVkX2ZlYXR1cmVfZmxhZ3MYCCADKAkSFwoPb3Jn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 11) = "YW5pemF0aW9uX2lkGAkgASgJGjQKE0FwcGxpY2F0aW9uSW5zdGFuY2USDAoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 12) = "cGF0aBgBIAEoCRIPCgd2ZXJzaW9uGAIgASgJGpwCCgZTY3JlZW4SDAoEbmFt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 13) = "ZRgBIAEoCRJPCgpyZXNvbHV0aW9uGAIgASgLMjsucnYuZGF0YS5Vc2VyRmVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 14) = "ZGJhY2suQXBwbGljYXRpb25NZXRhZGF0YS5TY3JlZW4uUmVzb2x1dGlvbhJD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 15) = "CgR0eXBlGAMgASgOMjUucnYuZGF0YS5Vc2VyRmVlZGJhY2suQXBwbGljYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 16) = "b25NZXRhZGF0YS5TY3JlZW4uVHlwZRITCgtvdXRwdXRfbmFtZRgEIAEoCRor";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 17) = "CgpSZXNvbHV0aW9uEg0KBXdpZHRoGAEgASgNEg4KBmhlaWdodBgCIAEoDSIs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 18) = "CgRUeXBlEgsKB1VOS05PV04QABIMCghBVURJRU5DRRABEgkKBVNUQUdFEAJC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 19) = "NPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 20) = "B1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray21<string>, string>(in buffer, 21))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(UserFeedback), UserFeedback.Parser, null, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(UserFeedback.Types.ApplicationMetadata), UserFeedback.Types.ApplicationMetadata.Parser, new string[9] { "ApplicationVersion", "OsVersion", "ApplicationInstances", "BlackmagicDesktopVideoInstances", "Screens", "CrashReportingEnabled", "AnalyticsReportingEnabled", "EnabledFeatureFlags", "OrganizationId" }, null, null, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(UserFeedback.Types.ApplicationMetadata.Types.ApplicationInstance), UserFeedback.Types.ApplicationMetadata.Types.ApplicationInstance.Parser, new string[2] { "Path", "Version" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(UserFeedback.Types.ApplicationMetadata.Types.Screen), UserFeedback.Types.ApplicationMetadata.Types.Screen.Parser, new string[4] { "Name", "Resolution", "Type", "OutputName" }, null, new Type[1] { typeof(UserFeedback.Types.ApplicationMetadata.Types.Screen.Types.Type) }, null, new GeneratedClrTypeInfo[1]
					{
						new GeneratedClrTypeInfo(typeof(UserFeedback.Types.ApplicationMetadata.Types.Screen.Types.Resolution), UserFeedback.Types.ApplicationMetadata.Types.Screen.Types.Resolution.Parser, new string[2] { "Width", "Height" }, null, null, null, null)
					})
				})
			})
		}));
	}
}
