using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace;

public static class WorkspaceBootstrapReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static WorkspaceBootstrapReflection()
	{
		_003C_003Ey__InlineArray5<string> buffer = default(_003C_003Ey__InlineArray5<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 0) = "Chl3b3Jrc3BhY2UuYm9vdHN0cmFwLnByb3RvEgl3b3Jrc3BhY2UiQgoOQ3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 1) = "YXRpb25PcHRpb24SHAoPbWluX3Byb192ZXJzaW9uGAEgASgJSACIAQFCEgoQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 2) = "X21pbl9wcm9fdmVyc2lvbkJVqgI2UHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 3) = "LlJWUHJvdG9EYXRhLlNlcnZpY2UuV29ya3NwYWNlugIZUlZEYXRhX1NlcnZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 4) = "Y2VfV29ya3NwYWNlX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<string>, string>(in buffer, 5))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(CreationOption), CreationOption.Parser, new string[1] { "MinProVersion" }, new string[1] { "MinProVersion" }, null, null, null)
		}));
	}
}
