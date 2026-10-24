using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Extensions;
using Pro.SerializationInterop.RVProtoData.Service.Document;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

namespace Pro.CoreApplication.Workspace;

public record RemoteWorkspaceDocuments : RemoteWorkspace
{
	public IDocument[] Documents { get; init; }

	public RemoteWorkspaceDocuments(Guid Id, string MinimumVersion, string Name, ulong WorkspaceSizeInBytes, DateTimeOffset CreatedDate, DateTimeOffset UpdatedDate, IDocument[] Documents)
	{
		this.Documents = Documents;
		base._002Ector(Id, MinimumVersion, Name, WorkspaceSizeInBytes, CreatedDate, UpdatedDate);
	}

	public static RemoteWorkspaceDocuments FromProto(Metadata proto, DocumentSet protoDocuments)
	{
		return new RemoteWorkspaceDocuments(proto.Uuid.ToGuidOrEmpty(), proto.ProVersion, proto.Name, proto.Size, DateTimeOffset.FromUnixTimeMilliseconds((long)proto.Created), DateTimeOffset.FromUnixTimeMilliseconds((long)proto.Updated), protoDocuments.ToDocuments().ToArray());
	}

	[CompilerGenerated]
	public void Deconstruct(out Guid Id, out string MinimumVersion, out string Name, out ulong WorkspaceSizeInBytes, out DateTimeOffset CreatedDate, out DateTimeOffset UpdatedDate, out IDocument[] Documents)
	{
		Id = base.Id;
		MinimumVersion = base.MinimumVersion;
		Name = base.Name;
		WorkspaceSizeInBytes = base.WorkspaceSizeInBytes;
		CreatedDate = base.CreatedDate;
		UpdatedDate = base.UpdatedDate;
		Documents = this.Documents;
	}
}
