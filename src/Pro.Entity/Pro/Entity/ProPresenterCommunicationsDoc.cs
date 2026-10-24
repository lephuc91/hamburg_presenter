using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProPresenterCommunicationsDoc : EntityDocumentBase, IProPresenterCommunicationsDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IProPresenterCommunications
{
	private readonly ProPresenterCommunications _entity;

	public IComplexCollection<ICommunicationDeviceCloud> Devices => _entity.Devices;

	public ProPresenterCommunicationsDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new ProPresenterCommunications(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public ProPresenterCommunicationsDoc(ulong peerId)
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
