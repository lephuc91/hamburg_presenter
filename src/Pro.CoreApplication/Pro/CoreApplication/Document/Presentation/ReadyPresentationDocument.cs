using System;
using System.Runtime.CompilerServices;
using Pro.CoreApplication.Document.CollectionDocument;

namespace Pro.CoreApplication.Document.Presentation;

public record ReadyPresentationDocument : ReadyCollectionDocument<PresentationCollectionSelector>
{
	public ReadyPresentationDocument(string Path, Guid Id, byte[] Data)
		: base(Path, Id, Data)
	{
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected ReadyPresentationDocument(ReadyPresentationDocument original)
		: base((ReadyCollectionDocument<PresentationCollectionSelector>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out string Path, out Guid Id, out byte[] Data)
	{
		Path = base.Path;
		Id = base.Id;
		Data = base.Data;
	}
}
