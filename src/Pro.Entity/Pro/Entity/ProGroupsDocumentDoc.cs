using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProGroupsDocumentDoc : EntityDocumentBase, IProGroupsDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IProGroupsDocument
{
	private readonly ProGroupsDocument _entity;

	public IComplexCollection<IGroup> Groups => _entity.Groups;

	public ProGroupsDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new ProGroupsDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public ProGroupsDocumentDoc(ulong peerId)
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
