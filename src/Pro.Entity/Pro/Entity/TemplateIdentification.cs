using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class TemplateIdentification : ITemplateIdentification, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private OptionalGuidObservableProperty Uuid_;

	private StringObservableProperty Name_;

	private GuidObservableProperty SlideUuid_;

	private StringObservableProperty SlideName_;

	private UintObservableProperty SlideIndex_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid?> Uuid => Uuid_;

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<Guid> SlideUuid => SlideUuid_;

	public IObservableProperty<string> SlideName => SlideName_;

	public IObservableProperty<uint> SlideIndex => SlideIndex_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		SlideUuid_.UpdateMap(_map);
		SlideName_.UpdateMap(_map);
		SlideIndex_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		SlideUuid_.UpdateMapOnInternalMapUpdate(_map);
		SlideName_.UpdateMapOnInternalMapUpdate(_map);
		SlideIndex_.UpdateMapOnInternalMapUpdate(_map);
	}

	public TemplateIdentification()
		: this(new LoroMap())
	{
	}

	public TemplateIdentification(LoroMap values)
	{
		_map = values;
		Uuid_ = new OptionalGuidObservableProperty("uuid__1", LoroMap);
		Name_ = new StringObservableProperty("name__2", LoroMap);
		SlideUuid_ = new GuidObservableProperty("slide_uuid__3", LoroMap);
		SlideName_ = new StringObservableProperty("slide_name__4", LoroMap);
		SlideIndex_ = new UintObservableProperty("slide_index__5", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, SlideUuid_.WhenChangeHappens, SlideName_.WhenChangeHappens, SlideIndex_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		SlideUuid_.Dispose();
		SlideName_.Dispose();
		SlideIndex_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		SlideUuid_.OnDiff(path, diff);
		SlideName_.OnDiff(path, diff);
		SlideIndex_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
