using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class MacrosDocumentDoc : EntityDocumentBase, IMacrosDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IMacrosDocument
{
	private readonly MacrosDocument _entity;

	public IComplexCollection<IMacrosDocument.Types.IMacroCollection> MacroCollections => _entity.MacroCollections;

	public MacrosDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new MacrosDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public MacrosDocumentDoc(ulong peerId)
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
