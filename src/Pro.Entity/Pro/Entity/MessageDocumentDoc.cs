using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class MessageDocumentDoc : EntityDocumentBase, IMessageDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IMessageDocument
{
	private readonly MessageDocument _entity;

	public IComplexCollection<IMessage> Messages => _entity.Messages;

	public MessageDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new MessageDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public MessageDocumentDoc(ulong peerId)
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
