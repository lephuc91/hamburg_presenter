using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

public static class WorkspaceEntitiesRemoteReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static WorkspaceEntitiesRemoteReflection()
	{
		_003C_003Ey__InlineArray9<string> buffer = default(_003C_003Ey__InlineArray9<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 0) = "Ch93b3Jrc3BhY2UuZW50aXRpZXMucmVtb3RlLnByb3RvEhB3b3Jrc3BhY2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 1) = "cmVtb3RlGhdkb2N1bWVudC5lbnRpdGllcy5wcm90byJrCghNZXRhZGF0YRIM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 2) = "CgR1dWlkGAEgASgJEhMKC3Byb192ZXJzaW9uGAIgASgJEgwKBG5hbWUYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 3) = "KAkSDAoEc2l6ZRgKIAEoBBIPCgdjcmVhdGVkGAsgASgEEg8KB3VwZGF0ZWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 4) = "DCABKAQiYwoJV29ya3NwYWNlEiwKCG1ldGFkYXRhGAEgASgLMhoud29ya3Nw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 5) = "YWNlLnJlbW90ZS5NZXRhZGF0YRIoCglkb2N1bWVudHMYAiABKAsyFS5kb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 6) = "bWVudC5Eb2N1bWVudFNldEJjqgI9UHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 7) = "LlJWUHJvdG9EYXRhLlNlcnZpY2UuV29ya3NwYWNlLlJlbW90ZboCIFJWRGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 8) = "YV9TZXJ2aWNlX1dvcmtzcGFjZV9SZW1vdGVfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<string>, string>(in buffer, 9))), new FileDescriptor[1] { DocumentEntitiesReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Metadata), Metadata.Parser, new string[6] { "Uuid", "ProVersion", "Name", "Size", "Created", "Updated" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Workspace), Workspace.Parser, new string[2] { "Metadata", "Documents" }, null, null, null, null)
		}));
	}
}
