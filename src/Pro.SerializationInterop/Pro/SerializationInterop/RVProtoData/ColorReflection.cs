using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class ColorReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ColorReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Cgtjb2xvci5wcm90bxIHcnYuZGF0YRoTY3VzdG9tT3B0aW9ucy5wcm90byJG" + "CgVDb2xvchILCgNyZWQYASABKAISDQoFZ3JlZW4YAiABKAISDAoEYmx1ZRgD" + "IAEoAhINCgVhbHBoYRgEIAEoAjoEgIAZAUI0+AEBqgIkUHJvLlNlcmlhbGl6" + "YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z"), new FileDescriptor[1] { CustomOptionsReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Color), Color.Parser, new string[4] { "Red", "Green", "Blue", "Alpha" }, null, null, null, null)
		}));
	}
}
