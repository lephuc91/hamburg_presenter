using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Intrinsic;

public record LibraryDataDocument : IntrinsicDocument
{
	public LibraryDataDocument(byte[] Data, Guid Id)
		: base(Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.LibraryData, Data, Id)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out byte[] Data, out Guid Id)
	{
		Data = base.Data;
		Id = base.Id;
	}
}
