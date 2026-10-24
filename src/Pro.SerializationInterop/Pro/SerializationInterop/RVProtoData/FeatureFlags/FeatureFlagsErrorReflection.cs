using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.FeatureFlags;

public static class FeatureFlagsErrorReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static FeatureFlagsErrorReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChlmZWF0dXJlLWZsYWdzLWVycm9yLnByb3RvEg1mZWF0dXJlX2ZsYWdzIiYK" + "BUVycm9yEgwKBGNvZGUYASABKAUSDwoHbWVzc2FnZRgCIAEoCUJLqgIxUHJv" + "LlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhLkZlYXR1cmVGbGFn" + "c7oCFFJWRGF0YV9GZWF0dXJlRmxhZ3NfYgZwcm90bzM="), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Error), Error.Parser, new string[2] { "Code", "Message" }, null, null, null, null)
		}));
	}
}
