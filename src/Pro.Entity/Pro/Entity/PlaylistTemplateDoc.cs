using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PlaylistTemplateDoc : EntityDocumentBase, IPlaylistTemplateDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPlaylistTemplate
{
	private readonly PlaylistTemplate _entity;

	public IComplexCollection<IPlaylistTemplate.Types.ITemplate> Templates => _entity.Templates;

	public PlaylistTemplateDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new PlaylistTemplate(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public PlaylistTemplateDoc(ulong peerId)
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
