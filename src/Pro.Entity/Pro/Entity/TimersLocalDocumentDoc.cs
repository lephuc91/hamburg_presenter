using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class TimersLocalDocumentDoc : EntityDocumentBase, ITimersLocalDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ITimersLocalDocument
{
	private readonly TimersLocalDocument _entity;

	public IComplexCollection<ILocalTimer> Timers => _entity.Timers;

	public TimersLocalDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new TimersLocalDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public TimersLocalDocumentDoc(ulong peerId)
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
