using System;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PlaylistDocumentDoc : EntityDocumentBase, IPlaylistDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPlaylistDocument
{
	private readonly PlaylistDocument _entity;

	public IObservableProperty<IPlaylistDocument.Types.Type> Type => _entity.Type;

	public IComplexObservableProperty<IPlaylist> RootNode => _entity.RootNode;

	public IComplexObservableProperty<IPlaylist?> LiveVideoPlaylist => _entity.LiveVideoPlaylist;

	public PlaylistDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new PlaylistDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public PlaylistDocumentDoc(ulong peerId)
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
