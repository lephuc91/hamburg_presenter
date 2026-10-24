using System;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CcliDocumentDoc : EntityDocumentBase, ICcliDocumentDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ICcliDocument
{
	private readonly CcliDocument _entity;

	public IObservableProperty<bool> EnableCcliDisplay => _entity.EnableCcliDisplay;

	public IObservableProperty<string> CcliLicense => _entity.CcliLicense;

	public IObservableProperty<ICcliDocument.Types.DisplayType> DisplayType => _entity.DisplayType;

	public IComplexObservableProperty<ITemplate.Types.ISlide> Template => _entity.Template;

	public IComplexObservableProperty<ICopyrightLayout> Layout => _entity.Layout;

	public CcliDocumentDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new CcliDocument(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public CcliDocumentDoc(ulong peerId)
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
