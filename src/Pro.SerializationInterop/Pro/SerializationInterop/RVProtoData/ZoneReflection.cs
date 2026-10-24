using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ZoneReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ZoneReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Cgp6b25lLnByb3RvEgdydi5kYXRhGgp1dWlkLnByb3RvIkQKBFpvbmUSGwoE" + "dXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBIMCgRuYW1lGAIgASgJEhEKCWhl" + "eF9jb2xvchgDIAEoCUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w" + "LlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z"), new FileDescriptor[1] { UuidReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Zone), Zone.Parser, new string[3] { "Uuid", "Name", "HexColor" }, null, null, null, null)
		}));
	}
}
