using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1ContentTypeReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1ContentTypeReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Chlwcm9BcGlWMUNvbnRlbnRUeXBlLnByb3RvEgdydi5kYXRhKicKEkFQSV92" + "MV9Db250ZW50VHlwZRIHCgNQTkcQABIICgRKUEVHEAFCNPgBAaoCJFByby5T" + "ZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9iBnBy" + "b3RvMw=="), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[1] { typeof(API_v1_ContentType) }, null, null));
	}
}
