using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class LabelsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static LabelsReflection()
	{
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("CgxsYWJlbHMucHJvdG8SB3J2LmRhdGEaDGFjdGlvbi5wcm90byI6ChFQcm9M" + "YWJlbHNEb2N1bWVudBIlCgZsYWJlbHMYASADKAsyFS5ydi5kYXRhLkFjdGlv" + "bi5MYWJlbEI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJv" + "dG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z"), new FileDescriptor[1] { ActionReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(ProLabelsDocument), ProLabelsDocument.Parser, new string[1] { "Labels" }, null, null, null, null)
		}));
	}
}
