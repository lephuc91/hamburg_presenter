using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class UuidReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static UuidReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Cgp1dWlkLnByb3RvEgdydi5kYXRhGhNjdXN0b21PcHRpb25zLnByb3RvIhwK" + "BFVVSUQSDgoGc3RyaW5nGAEgASgJOgSAgBkBQjT4AQGqAiRQcm8uU2VyaWFs" + "aXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM="), new FileDescriptor[1] { CustomOptionsReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(UUID), UUID.Parser, new string[1] { "String" }, null, null, null, null)
		}));
	}
}
