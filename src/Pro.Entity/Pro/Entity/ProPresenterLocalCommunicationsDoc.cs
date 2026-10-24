using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProPresenterLocalCommunicationsDoc : EntityDocumentBase, IProPresenterLocalCommunicationsDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IProPresenterLocalCommunications
{
	private readonly ProPresenterLocalCommunications _entity;

	public IComplexCollection<ICommunicationDeviceLocal> Devices => _entity.Devices;

	public ProPresenterLocalCommunicationsDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new ProPresenterLocalCommunications(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public ProPresenterLocalCommunicationsDoc(ulong peerId)
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
