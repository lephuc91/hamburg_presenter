using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class KeyMappingDocumentDoc : EntityDocumentBase, IKeyMappingDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IKeyMappingDocument
{
	private readonly KeyMappingDocument _entity;

	public IComplexCollection<IKeyMapping> Keymappings => _entity.Keymappings;

	public IComplexCollection<IKeyMapping> MacosKeymappings => _entity.MacosKeymappings;

	public IComplexCollection<IKeyMapping> WindowsKeymappings => _entity.WindowsKeymappings;

	public KeyMappingDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new KeyMappingDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public KeyMappingDocumentDoc(ulong peerId)
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
