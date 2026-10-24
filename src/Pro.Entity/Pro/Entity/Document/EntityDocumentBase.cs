using System;
using System.Runtime.InteropServices;
using Pro.Loro;

namespace Pro.Entity.Document;

internal abstract class EntityDocumentBase : Document, Subscriber, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IDiffReceiver
{
	protected EntityDocumentBase(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
	}

	public override void OnDiff(DiffEvent diff)
	{
		base.OnDiff(diff);
		foreach (ContainerDiff @event in diff.events)
		{
			Span<PathItem> span = CollectionsMarshal.AsSpan(@event.path);
			if (span.Length > 0 && span[0].index is Pro.Loro.Index.Key { key: "root" })
			{
				OnDiff(span.Slice(1), @event.diff);
			}
		}
	}

	public abstract void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff);

	public abstract void RegisterLinkedDisposable(IDisposable disposable);
}
