using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1ColorReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1ColorReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChNwcm9BcGlWMUNvbG9yLnByb3RvEgdydi5kYXRhIkcKDEFQSV92MV9Db2xv" + "chILCgNyZWQYASABKAESDQoFZ3JlZW4YAiABKAESDAoEYmx1ZRgDIAEoARIN" + "CgVhbHBoYRgEIAEoAUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w" + "LlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z"), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Color), API_v1_Color.Parser, new string[4] { "Red", "Green", "Blue", "Alpha" }, null, null, null, null)
		}));
	}
}
