using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace.Local;

public static class WorkspaceEntitiesLocalReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static WorkspaceEntitiesLocalReflection()
	{
		_003C_003Ey__InlineArray9<string> buffer = default(_003C_003Ey__InlineArray9<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 0) = "Ch53b3Jrc3BhY2UuZW50aXRpZXMubG9jYWwucHJvdG8SD3dvcmtzcGFjZS5s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 1) = "b2NhbBoXZG9jdW1lbnQuZW50aXRpZXMucHJvdG8iVwoITWV0YWRhdGESEQoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 2) = "dXVpZBgBIAEoCUgAiAEBEhMKC3Byb192ZXJzaW9uGAIgASgJEgwKBG5hbWUY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 3) = "AyABKAkSDAoEcGF0aBgEIAEoCUIHCgVfdXVpZCJiCglXb3Jrc3BhY2USKwoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 4) = "bWV0YWRhdGEYASABKAsyGS53b3Jrc3BhY2UubG9jYWwuTWV0YWRhdGESKAoJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 5) = "ZG9jdW1lbnRzGAIgASgLMhUuZG9jdW1lbnQuRG9jdW1lbnRTZXRCYaoCPFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 6) = "by5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YS5TZXJ2aWNlLldv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 7) = "cmtzcGFjZS5Mb2NhbLoCH1JWRGF0YV9TZXJ2aWNlX1dvcmtzcGFjZV9Mb2Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 8) = "bF9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<string>, string>(in buffer, 9))), new FileDescriptor[1] { DocumentEntitiesReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Metadata), Metadata.Parser, new string[4] { "Uuid", "ProVersion", "Name", "Path" }, new string[1] { "Uuid" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(Workspace), Workspace.Parser, new string[2] { "Metadata", "Documents" }, null, null, null, null)
		}));
	}
}
