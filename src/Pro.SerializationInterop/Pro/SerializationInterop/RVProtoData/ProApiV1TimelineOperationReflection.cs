using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1TimelineOperationReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1TimelineOperationReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Ch9wcm9BcGlWMVRpbWVsaW5lT3BlcmF0aW9uLnByb3RvEgdydi5kYXRhKjsK" + "GEFQSV92MV9UaW1lbGluZU9wZXJhdGlvbhIICgRwbGF5EAASCQoFcGF1c2UQ" + "ARIKCgZyZXdpbmQQAkI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w" + "LlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z"), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[1] { typeof(API_v1_TimelineOperation) }, null, null));
	}
}
