using System;
using System.Runtime.CompilerServices;
using Pro.CoreApplication.Document.CollectionDocument;

namespace Pro.CoreApplication.Document.Presentation;

public record RemotePresentationDocument : RemoteCollectionDocument<PresentationCollectionSelector>
{
	public RemotePresentationDocument(string Path, Guid Id)
		: base(Path, Id)
	{
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected RemotePresentationDocument(RemotePresentationDocument original)
		: base((RemoteCollectionDocument<PresentationCollectionSelector>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out string Path, out Guid Id)
	{
		Path = base.Path;
		Id = base.Id;
	}
}
