using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class TestPatternDocumentDoc : EntityDocumentBase, ITestPatternDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ITestPatternDocument
{
	private readonly TestPatternDocument _entity;

	public IComplexObservableProperty<ITestPatternDocument.Types.ITestPatternStateData?> State => _entity.State;

	public IComplexCollection<ITestPatternDocument.Types.ITestPatternData> Patterns => _entity.Patterns;

	public TestPatternDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new TestPatternDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public TestPatternDocumentDoc(ulong peerId)
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
