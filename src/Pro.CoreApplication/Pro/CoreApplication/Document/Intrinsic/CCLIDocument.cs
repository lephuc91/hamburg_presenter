using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Intrinsic;

public record CCLIDocument : IntrinsicDocument
{
	public CCLIDocument(byte[] Data, Guid Id)
		: base(Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Ccli, Data, Id)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out byte[] Data, out Guid Id)
	{
		Data = base.Data;
		Id = base.Id;
	}
}
