using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class IntRangeReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static IntRangeReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("Cg5pbnRSYW5nZS5wcm90bxIHcnYuZGF0YRoTY3VzdG9tT3B0aW9ucy5wcm90" + "byIsCghJbnRSYW5nZRINCgVzdGFydBgBIAEoBRILCgNlbmQYAiABKAU6BICA" + "GQFCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0" + "YboCB1JWRGF0YV9iBnByb3RvMw=="), new FileDescriptor[1] { CustomOptionsReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(IntRange), IntRange.Parser, new string[2] { "Start", "End" }, null, null, null, null)
		}));
	}
}
