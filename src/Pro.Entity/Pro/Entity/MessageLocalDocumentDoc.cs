using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class MessageLocalDocumentDoc : EntityDocumentBase, IMessageLocalDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IMessageLocalDocument
{
	private readonly MessageLocalDocument _entity;

	public IComplexCollection<ILocalMessage> Messages => _entity.Messages;

	public MessageLocalDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new MessageLocalDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public MessageLocalDocumentDoc(ulong peerId)
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
