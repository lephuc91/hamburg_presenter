using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Document;

public static class DocumentBootstrapReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static DocumentBootstrapReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Chhkb2N1bWVudC5ib290c3RyYXAucHJvdG8SCGRvY3VtZW50IhAKDkNyZWF0" + "aW9uT3B0aW9uQlOqAjVQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90" + "b0RhdGEuU2VydmljZS5Eb2N1bWVudLoCGFJWRGF0YV9TZXJ2aWNlX0RvY3Vt" + "ZW50X2IGcHJvdG8z"), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(CreationOption), CreationOption.Parser, null, null, null, null, null)
		}));
	}
}
