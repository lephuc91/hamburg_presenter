using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PresentationDoc : EntityDocumentBase, IPresentationDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPresentation
{
	private readonly Presentation _entity;

	public IObservableProperty<Guid> Uuid => _entity.Uuid;

	public IObservableProperty<string> Name => _entity.Name;

	public IObservableProperty<string> Notes => _entity.Notes;

	public IComplexObservableProperty<IBackground?> Background => _entity.Background;

	public IObservableProperty<Url?> ChordChart => _entity.ChordChart;

	public IObservableProperty<Guid?> SelectedArrangement => _entity.SelectedArrangement;

	public IComplexCollection<IPresentation.Types.IArrangement> Arrangements => _entity.Arrangements;

	public IComplexCollection<IPresentation.Types.ICueGroup> CueGroups => _entity.CueGroups;

	public IKeyedCollection<Guid, ICue> Cues => _entity.Cues;

	public IComplexObservableProperty<IPresentation.Types.ICcli> Ccli => _entity.Ccli;

	public IComplexObservableProperty<IPresentation.Types.IBibleReference?> BibleReference => _entity.BibleReference;

	public IComplexObservableProperty<IPresentation.Types.ITimeline> Timeline => _entity.Timeline;

	public IComplexObservableProperty<ITransition?> Transition => _entity.Transition;

	public IObservableProperty<IAction.Types.ContentDestination> ContentDestination => _entity.ContentDestination;

	public IComplexObservableProperty<IPresentation.Types.IMultiTracksLicensing?> MultiTracksLicensing => _entity.MultiTracksLicensing;

	public IObservableProperty<string> MusicKey => _entity.MusicKey;

	public IComplexObservableProperty<IPresentation.Types.IMusic?> Music => _entity.Music;

	public IComplexObservableProperty<IPresentation.Types.ISlideShow?> SlideShow => _entity.SlideShow;

	public PresentationDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new Presentation(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public PresentationDoc(ulong peerId)
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
