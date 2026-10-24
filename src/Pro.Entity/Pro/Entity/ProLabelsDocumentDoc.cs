using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProLabelsDocumentDoc : EntityDocumentBase, IProLabelsDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IProLabelsDocument
{
	private readonly ProLabelsDocument _entity;

	public IComplexCollection<IAction.Types.ILabel> Labels => _entity.Labels;

	public ProLabelsDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new ProLabelsDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public ProLabelsDocumentDoc(ulong peerId)
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
