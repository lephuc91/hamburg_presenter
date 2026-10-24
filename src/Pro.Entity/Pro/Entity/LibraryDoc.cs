using System;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class LibraryDoc : EntityDocumentBase, ILibraryDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ILibrary
{
	private readonly Library _entity;

	public IObservableProperty<Url> Url => _entity.Url;

	public IComplexObservableProperty<ILibrary.Types.IChildType> ChildType => _entity.ChildType;

	public LibraryDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new Library(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public LibraryDoc(ulong peerId)
		: this(new LoroDoc(), peerId)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			_entity.Dispose();
		}
	}

	public override void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		_entity.OnDiff(path, diff);
	}

	public override void RegisterLinkedDisposable(IDisposable disposable)
	{
		_entity.RegisterLinkedDisposable(disposable);
	}
}
