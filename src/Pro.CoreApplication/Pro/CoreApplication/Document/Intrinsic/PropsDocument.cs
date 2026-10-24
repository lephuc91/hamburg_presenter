using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Intrinsic;

public record PropsDocument : IntrinsicDocument
{
	public PropsDocument(byte[] Data, Guid Id)
		: base(Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Props, Data, Id)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out byte[] Data, out Guid Id)
	{
		Data = base.Data;
		Id = base.Id;
	}
}
