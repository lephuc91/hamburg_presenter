using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1IdentifierReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1IdentifierReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Chhwcm9BcGlWMUlkZW50aWZpZXIucHJvdG8SB3J2LmRhdGEiPgoRQVBJX3Yx" + "X0lkZW50aWZpZXISDAoEdXVpZBgBIAEoCRIMCgRuYW1lGAIgASgJEg0KBWlu" + "ZGV4GAMgASgNQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQ" + "cm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM="), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Identifier), API_v1_Identifier.Parser, new string[3] { "Uuid", "Name", "Index" }, null, null, null, null)
		}));
	}
}
