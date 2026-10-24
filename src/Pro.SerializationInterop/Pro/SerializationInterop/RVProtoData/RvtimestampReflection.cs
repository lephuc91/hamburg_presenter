using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class RvtimestampReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static RvtimestampReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChFydnRpbWVzdGFtcC5wcm90bxIHcnYuZGF0YRoTY3VzdG9tT3B0aW9ucy5w" + "cm90byIxCglUaW1lc3RhbXASDwoHc2Vjb25kcxgBIAEoAxINCgVuYW5vcxgC" + "IAEoBToEgIAZAUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJW" + "UHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z"), new FileDescriptor[1] { CustomOptionsReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Timestamp), Timestamp.Parser, new string[2] { "Seconds", "Nanos" }, null, null, null, null)
		}));
	}
}
