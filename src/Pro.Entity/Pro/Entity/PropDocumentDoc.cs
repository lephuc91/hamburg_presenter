using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PropDocumentDoc : EntityDocumentBase, IPropDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPropDocument
{
	private readonly PropDocument _entity;

	public IComplexObservableProperty<ITransition?> Transition => _entity.Transition;

	public IComplexCollection<IPropDocument.Types.IPropCollection> PropCollections => _entity.PropCollections;

	public PropDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new PropDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public PropDocumentDoc(ulong peerId)
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
