using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CalendarDoc : EntityDocumentBase, ICalendarDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ICalendar
{
	private readonly Calendar _entity;

	public IComplexCollection<ICalendar.Types.IEvent> Events => _entity.Events;

	public IObservableProperty<bool> Active => _entity.Active;

	public CalendarDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new Calendar(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public CalendarDoc(ulong peerId)
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
