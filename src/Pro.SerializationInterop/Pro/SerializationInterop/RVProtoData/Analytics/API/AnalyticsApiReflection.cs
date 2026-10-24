using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.API;

public static class AnalyticsApiReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsApiReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChJhbmFseXRpY3NBcGkucHJvdG8SEHJ2LmFuYWx5dGljcy5hcGkiEQoPTWVz" + "c2FnZVJlY2VpdmVkQkn4AQGqAjJQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au" + "UlZQcm90b0RhdGEuQW5hbHl0aWNzLkFQSboCDkFuYWx5dGljc19BUElfYgZw" + "cm90bzM="), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(MessageReceived), MessageReceived.Parser, null, null, null, null, null)
		}));
	}
}
