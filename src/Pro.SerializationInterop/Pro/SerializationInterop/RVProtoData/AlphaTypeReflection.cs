using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class AlphaTypeReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AlphaTypeReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Cg9hbHBoYVR5cGUucHJvdG8SB3J2LmRhdGEqWgoJQWxwaGFUeXBlEhYKEkFM" + "UEhBX1RZUEVfVU5LTk9XThAAEhcKE0FMUEhBX1RZUEVfU1RSQUlHSFQQARIc" + "ChhBTFBIQV9UWVBFX1BSRU1VTFRJUExJRUQQAkI0+AEBqgIkUHJvLlNlcmlh" + "bGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z"), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[1] { typeof(AlphaType) }, null, null));
	}
}
