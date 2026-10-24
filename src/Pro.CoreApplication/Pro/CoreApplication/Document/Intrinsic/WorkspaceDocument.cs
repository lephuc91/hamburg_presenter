using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Intrinsic;

public record WorkspaceDocument : IntrinsicDocument
{
	public WorkspaceDocument(byte[] Data, Guid Id)
		: base(Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Workspace, Data, Id)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out byte[] Data, out Guid Id)
	{
		Data = base.Data;
		Id = base.Id;
	}
}
