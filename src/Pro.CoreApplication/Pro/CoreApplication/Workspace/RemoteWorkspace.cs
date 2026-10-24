using System;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

namespace Pro.CoreApplication.Workspace;

public record RemoteWorkspace(Guid Id, string MinimumVersion, string Name, ulong WorkspaceSizeInBytes, DateTimeOffset CreatedDate, DateTimeOffset UpdatedDate)
{
	internal static RemoteWorkspace FromProto(Metadata proto)
	{
		return new RemoteWorkspace(proto.Uuid.ToGuidOrEmpty(), proto.ProVersion, proto.Name, proto.Size, DateTimeOffset.FromUnixTimeMilliseconds((long)proto.Created), DateTimeOffset.FromUnixTimeMilliseconds((long)proto.Updated));
	}
}
