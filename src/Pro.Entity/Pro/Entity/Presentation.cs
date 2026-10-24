using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.CrdtKeySerializers;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Presentation : IPresentation, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty Name_;

	private StringObservableProperty Notes_;

	private OptionalComplexObservableProperty<IBackground> Background_;

	private OptionalAtomicObservableProperty<Url> ChordChart_;

	private OptionalGuidObservableProperty SelectedArrangement_;

	private MapCollection<IPresentation.Types.IArrangement> Arrangements_;

	private MapCollection<IPresentation.Types.ICueGroup> CueGroups_;

	private KeyedMapCollection<Guid, ICue> Cues_;

	private ComplexObservableProperty<IPresentation.Types.ICcli> Ccli_;

	private OptionalComplexObservableProperty<IPresentation.Types.IBibleReference> BibleReference_;

	private ComplexObservableProperty<IPresentation.Types.ITimeline> Timeline_;

	private OptionalComplexObservableProperty<ITransition> Transition_;

	private EnumObservableProperty<IAction.Types.ContentDestination> ContentDestination_;

	private OptionalComplexObservableProperty<IPresentation.Types.IMultiTracksLicensing> MultiTracksLicensing_;

	private StringObservableProperty MusicKey_;

	private OptionalComplexObservableProperty<IPresentation.Types.IMusic> Music_;

	private OptionalUnionObservableProperty<IPresentation.Types.ISlideShow> SlideShow_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<string> Notes => Notes_;

	public IComplexObservableProperty<IBackground?> Background => Background_;

	public IObservableProperty<Url?> ChordChart => ChordChart_;

	public IObservableProperty<Guid?> SelectedArrangement => SelectedArrangement_;

	public IComplexCollection<IPresentation.Types.IArrangement> Arrangements => Arrangements_;

	public IComplexCollection<IPresentation.Types.ICueGroup> CueGroups => CueGroups_;

	public IKeyedCollection<Guid, ICue> Cues => Cues_;

	public IComplexObservableProperty<IPresentation.Types.ICcli> Ccli => Ccli_;

	public IComplexObservableProperty<IPresentation.Types.IBibleReference?> BibleReference => BibleReference_;

	public IComplexObservableProperty<IPresentation.Types.ITimeline> Timeline => Timeline_;

	public IComplexObservableProperty<ITransition?> Transition => Transition_;

	public IObservableProperty<IAction.Types.ContentDestination> ContentDestination => ContentDestination_;

	public IComplexObservableProperty<IPresentation.Types.IMultiTracksLicensing?> MultiTracksLicensing => MultiTracksLicensing_;

	public IObservableProperty<string> MusicKey => MusicKey_;

	public IComplexObservableProperty<IPresentation.Types.IMusic?> Music => Music_;

	public IComplexObservableProperty<IPresentation.Types.ISlideShow?> SlideShow => SlideShow_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		Notes_.UpdateMap(_map);
		Background_.UpdateMap(_map);
		ChordChart_.UpdateMap(_map);
		SelectedArrangement_.UpdateMap(_map);
		Arrangements_.UpdateMap(_map);
		CueGroups_.UpdateMap(_map);
		Cues_.UpdateMap(_map);
		Ccli_.UpdateMap(_map);
		BibleReference_.UpdateMap(_map);
		Timeline_.UpdateMap(_map);
		Transition_.UpdateMap(_map);
		ContentDestination_.UpdateMap(_map);
		MultiTracksLicensing_.UpdateMap(_map);
		MusicKey_.UpdateMap(_map);
		Music_.UpdateMap(_map);
		SlideShow_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		Notes_.UpdateMapOnInternalMapUpdate(_map);
		Background_.UpdateMapOnInternalMapUpdate(_map);
		ChordChart_.UpdateMapOnInternalMapUpdate(_map);
		SelectedArrangement_.UpdateMapOnInternalMapUpdate(_map);
		Arrangements_.UpdateMapOnInternalMapUpdate(_map);
		CueGroups_.UpdateMapOnInternalMapUpdate(_map);
		Cues_.UpdateMapOnInternalMapUpdate(_map);
		Ccli_.UpdateMapOnInternalMapUpdate(_map);
		BibleReference_.UpdateMapOnInternalMapUpdate(_map);
		Timeline_.UpdateMapOnInternalMapUpdate(_map);
		Transition_.UpdateMapOnInternalMapUpdate(_map);
		ContentDestination_.UpdateMapOnInternalMapUpdate(_map);
		MultiTracksLicensing_.UpdateMapOnInternalMapUpdate(_map);
		MusicKey_.UpdateMapOnInternalMapUpdate(_map);
		Music_.UpdateMapOnInternalMapUpdate(_map);
		SlideShow_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Presentation()
		: this(new LoroMap())
	{
	}

	public Presentation(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__2", LoroMap);
		Name_ = new StringObservableProperty("name__3", LoroMap);
		Notes_ = new StringObservableProperty("notes__7", LoroMap);
		Background_ = new OptionalComplexObservableProperty<IBackground>("background__8", LoroMap, new EntityFactory());
		ChordChart_ = new OptionalAtomicObservableProperty<Url>("chord_chart__9", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
		SelectedArrangement_ = new OptionalGuidObservableProperty("selected_arrangement__10", LoroMap);
		Arrangements_ = new MapCollection<IPresentation.Types.IArrangement>(LoroMap, "arrangements__11", new EntityFactory());
		CueGroups_ = new MapCollection<IPresentation.Types.ICueGroup>(LoroMap, "cue_groups__12", new EntityFactory());
		Cues_ = new KeyedMapCollection<Guid, ICue>(LoroMap, "cues__13", new EntityFactory(), new SystemGuidCrdtKeySerializer());
		Ccli_ = new ComplexObservableProperty<IPresentation.Types.ICcli>("ccli__14", LoroMap, new EntityFactory());
		BibleReference_ = new OptionalComplexObservableProperty<IPresentation.Types.IBibleReference>("bible_reference__15", LoroMap, new EntityFactory());
		Timeline_ = new ComplexObservableProperty<IPresentation.Types.ITimeline>("timeline__17", LoroMap, new EntityFactory());
		Transition_ = new OptionalComplexObservableProperty<ITransition>("transition__18", LoroMap, new EntityFactory());
		ContentDestination_ = new EnumObservableProperty<IAction.Types.ContentDestination>("content_destination__19", LoroMap);
		MultiTracksLicensing_ = new OptionalComplexObservableProperty<IPresentation.Types.IMultiTracksLicensing>("multi_tracks_licensing__21", LoroMap, new EntityFactory());
		MusicKey_ = new StringObservableProperty("music_key__22", LoroMap);
		Music_ = new OptionalComplexObservableProperty<IPresentation.Types.IMusic>("music__23", LoroMap, new EntityFactory());
		SlideShow_ = new OptionalUnionObservableProperty<IPresentation.Types.ISlideShow>("SlideShow__union", LoroMap, new IPresentation.Types.SlideShowFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Notes_.WhenChangeHappens, Background_.WhenChangeHappens, ChordChart_.WhenChangeHappens, SelectedArrangement_.WhenChangeHappens, Arrangements_.WhenChangeHappens, CueGroups_.WhenChangeHappens, Cues_.WhenChangeHappens, Ccli_.WhenChangeHappens, BibleReference_.WhenChangeHappens, Timeline_.WhenChangeHappens, Transition_.WhenChangeHappens, ContentDestination_.WhenChangeHappens, MultiTracksLicensing_.WhenChangeHappens, MusicKey_.WhenChangeHappens, Music_.WhenChangeHappens, SlideShow_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		Notes_.Dispose();
		Background_.Dispose();
		ChordChart_.Dispose();
		SelectedArrangement_.Dispose();
		Arrangements_.Dispose();
		CueGroups_.Dispose();
		Cues_.Dispose();
		Ccli_.Dispose();
		BibleReference_.Dispose();
		Timeline_.Dispose();
		Transition_.Dispose();
		ContentDestination_.Dispose();
		MultiTracksLicensing_.Dispose();
		MusicKey_.Dispose();
		Music_.Dispose();
		SlideShow_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		Notes_.OnDiff(path, diff);
		Background_.OnDiff(path, diff);
		ChordChart_.OnDiff(path, diff);
		SelectedArrangement_.OnDiff(path, diff);
		Arrangements_.OnDiff(path, diff);
		CueGroups_.OnDiff(path, diff);
		Cues_.OnDiff(path, diff);
		Ccli_.OnDiff(path, diff);
		BibleReference_.OnDiff(path, diff);
		Timeline_.OnDiff(path, diff);
		Transition_.OnDiff(path, diff);
		ContentDestination_.OnDiff(path, diff);
		MultiTracksLicensing_.OnDiff(path, diff);
		MusicKey_.OnDiff(path, diff);
		Music_.OnDiff(path, diff);
		SlideShow_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
