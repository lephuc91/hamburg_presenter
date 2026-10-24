using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1SizeReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1SizeReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChJwcm9BcGlWMVNpemUucHJvdG8SB3J2LmRhdGEiLAoLQVBJX3YxX1NpemUS" + "DQoFd2lkdGgYASABKA0SDgoGaGVpZ2h0GAIgASgNQjT4AQGqAiRQcm8uU2Vy" + "aWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90" + "bzM="), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Size), API_v1_Size.Parser, new string[2] { "Width", "Height" }, null, null, null, null)
		}));
	}
}
