using System;
using System.Reactive.Subjects;
using Pro.Loro;

namespace Pro.Entity.Document;

public class Document : Subscriber, IDocument, ICanExportSnapshot, IDisposable
{
	private readonly IDisposable _subscription;

	private readonly SubjectBase<(ICanExportSnapshot, bool)> _changeSubject = new Subject<(ICanExportSnapshot, bool)>();

	internal LoroDoc Doc { get; }

	public IObservable<(ICanExportSnapshot, bool)> WhenChangeHappened => _changeSubject;

	public Document(LoroDoc doc, ulong peerId)
	{
		doc.SetPeerId(peerId);
		Doc = doc;
		_subscription = Doc.SubscribeRoot(this);
	}

	public virtual void OnDiff(DiffEvent diff)
	{
		_changeSubject.OnNext((this, diff.triggeredBy == EventTriggerKind.Local));
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_subscription.Dispose();
			_changeSubject.Dispose();
			Doc.Dispose();
		}
	}

	public void Import(byte[] data)
	{
		Doc.Import(data);
	}

	public byte[] ExportFullSnapshot()
	{
		return Doc.ExportSnapshot();
	}

	public byte[] ExportUpdateFromVersionVector(byte[] versionVector)
	{
		return Doc.ExportUpdates(VersionVector.Decode(versionVector));
	}

	public byte[] GetVersionVector()
	{
		return Doc.StateVv().Encode();
	}
}
