using System;
using System.Runtime.CompilerServices;
using Pro.CoreApplication.Document.CollectionDocument;

namespace Pro.CoreApplication.Document.Theme;

public record RemoteThemeDocument : RemoteCollectionDocument<ThemeCollectionSelector>
{
	public RemoteThemeDocument(string Path, Guid Id)
		: base(Path, Id)
	{
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected RemoteThemeDocument(RemoteThemeDocument original)
		: base((RemoteCollectionDocument<ThemeCollectionSelector>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out string Path, out Guid Id)
	{
		Path = base.Path;
		Id = base.Id;
	}
}
