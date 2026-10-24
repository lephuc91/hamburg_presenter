using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class TimersDocumentDoc : EntityDocumentBase, ITimersDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ITimersDocument
{
	private readonly TimersDocument _entity;

	public IComplexCollection<ITimer> Timers => _entity.Timers;

	public TimersDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new TimersDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public TimersDocumentDoc(ulong peerId)
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
