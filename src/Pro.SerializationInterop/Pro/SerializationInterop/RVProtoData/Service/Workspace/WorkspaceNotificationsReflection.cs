using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace;

public static class WorkspaceNotificationsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static WorkspaceNotificationsReflection()
	{
		_003C_003Ey__InlineArray22<string> buffer = default(_003C_003Ey__InlineArray22<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 0) = "Ch13b3Jrc3BhY2Uubm90aWZpY2F0aW9ucy5wcm90bxIJd29ya3NwYWNlGh93";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 1) = "b3Jrc3BhY2UuZW50aXRpZXMucmVtb3RlLnByb3RvIpUGCgxOb3RpZmljYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 2) = "b24SQgoLdW5zdWJzY3JpYmUYASABKAsyKy53b3Jrc3BhY2UuTm90aWZpY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 3) = "aW9uLlVuc3Vic2NyaWJlQ29tcGxldGVIABI4Cgp3b3Jrc3BhY2VzGAIgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 4) = "MiIud29ya3NwYWNlLk5vdGlmaWNhdGlvbi5Xb3Jrc3BhY2VzSAASPgoNY29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 5) = "bGFib3JhdG9ycxgDIAEoCzIlLndvcmtzcGFjZS5Ob3RpZmljYXRpb24uQ29s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 6) = "bGFib3JhdG9yc0gAEjIKB3N5bmNpbmcYBCABKAsyHy53b3Jrc3BhY2UuTm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 7) = "aWZpY2F0aW9uLlN5bmNpbmdIABoVChNVbnN1YnNjcmliZUNvbXBsZXRlGr8C";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 8) = "CgpXb3Jrc3BhY2VzEkcKC2luaXRpYWxpemVkGAEgASgLMjAud29ya3NwYWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 9) = "Lk5vdGlmaWNhdGlvbi5Xb3Jrc3BhY2VzLldvcmtzcGFjZUxpc3RIABJJCg11";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 10) = "bmluaXRpYWxpemVkGAIgASgLMjAud29ya3NwYWNlLk5vdGlmaWNhdGlvbi5X";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 11) = "b3Jrc3BhY2VzLlVuaW5pdGlhbGl6ZWRIABI5CgVlcnJvchgDIAEoCzIoLndv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 12) = "cmtzcGFjZS5Ob3RpZmljYXRpb24uV29ya3NwYWNlcy5FcnJvckgAGj8KDVdv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 13) = "cmtzcGFjZUxpc3QSLgoKd29ya3NwYWNlcxgBIAMoCzIaLndvcmtzcGFjZS5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 14) = "ZW1vdGUuTWV0YWRhdGEaDwoNVW5pbml0aWFsaXplZBoHCgVFcnJvckIHCgVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 15) = "dGF0ZRofCg1Db2xsYWJvcmF0b3JzEg4KBm9ubGluZRgBIAMoCRqIAQoHU3lu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 16) = "Y2luZxI7CgZwYXVzZWQYASABKAsyJi53b3Jrc3BhY2UuTm90aWZpY2F0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 17) = "LlN5bmNpbmcuUGF1c2VkSACIAQEaNQoGUGF1c2VkEhYKDnVudGlsX3RpbWVf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 18) = "dXRjGAEgASgEEhMKC2F0X3RpbWVfdXRjGAIgASgEQgkKB19wYXVzZWRCDgoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 19) = "bm90aWZpY2F0aW9uQlWqAjZQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 20) = "cm90b0RhdGEuU2VydmljZS5Xb3Jrc3BhY2W6AhlSVkRhdGFfU2VydmljZV9X";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray22<string>, string>(ref buffer, 21) = "b3Jrc3BhY2VfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray22<string>, string>(in buffer, 22))), new FileDescriptor[1] { WorkspaceEntitiesRemoteReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Notification), Notification.Parser, new string[4] { "Unsubscribe", "Workspaces", "Collaborators", "Syncing" }, new string[1] { "Notification" }, null, null, new GeneratedClrTypeInfo[4]
			{
				new GeneratedClrTypeInfo(typeof(Notification.Types.UnsubscribeComplete), Notification.Types.UnsubscribeComplete.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Workspaces), Notification.Types.Workspaces.Parser, new string[3] { "Initialized", "Uninitialized", "Error" }, new string[1] { "State" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(Notification.Types.Workspaces.Types.WorkspaceList), Notification.Types.Workspaces.Types.WorkspaceList.Parser, new string[1] { "Workspaces" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Notification.Types.Workspaces.Types.Uninitialized), Notification.Types.Workspaces.Types.Uninitialized.Parser, null, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Notification.Types.Workspaces.Types.Error), Notification.Types.Workspaces.Types.Error.Parser, null, null, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Collaborators), Notification.Types.Collaborators.Parser, new string[1] { "Online" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Notification.Types.Syncing), Notification.Types.Syncing.Parser, new string[1] { "Paused" }, new string[1] { "Paused" }, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Notification.Types.Syncing.Types.Paused), Notification.Types.Syncing.Types.Paused.Parser, new string[2] { "UntilTimeUtc", "AtTimeUtc" }, null, null, null, null)
				})
			})
		}));
	}
}
