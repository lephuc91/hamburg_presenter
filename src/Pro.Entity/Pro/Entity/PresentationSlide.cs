using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PresentationSlide : IPresentationSlide, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private ComplexObservableProperty<ISlide> BaseSlide_;

	private OptionalComplexObservableProperty<IPresentationSlide.Types.INotes> Notes_;

	private MapCollection<IAlignmentGuide> TemplateGuidelines_;

	private OptionalAtomicObservableProperty<Url> ChordChart_;

	private OptionalComplexObservableProperty<ITransition> Transition_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexObservableProperty<ISlide> BaseSlide => BaseSlide_;

	public IComplexObservableProperty<IPresentationSlide.Types.INotes?> Notes => Notes_;

	public IComplexCollection<IAlignmentGuide> TemplateGuidelines => TemplateGuidelines_;

	public IObservableProperty<Url?> ChordChart => ChordChart_;

	public IComplexObservableProperty<ITransition?> Transition => Transition_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		BaseSlide_.UpdateMap(_map);
		Notes_.UpdateMap(_map);
		TemplateGuidelines_.UpdateMap(_map);
		ChordChart_.UpdateMap(_map);
		Transition_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		BaseSlide_.UpdateMapOnInternalMapUpdate(_map);
		Notes_.UpdateMapOnInternalMapUpdate(_map);
		TemplateGuidelines_.UpdateMapOnInternalMapUpdate(_map);
		ChordChart_.UpdateMapOnInternalMapUpdate(_map);
		Transition_.UpdateMapOnInternalMapUpdate(_map);
	}

	public PresentationSlide()
		: this(new LoroMap())
	{
	}

	public PresentationSlide(LoroMap values)
	{
		_map = values;
		BaseSlide_ = new ComplexObservableProperty<ISlide>("base_slide__1", LoroMap, new EntityFactory());
		Notes_ = new OptionalComplexObservableProperty<IPresentationSlide.Types.INotes>("notes__2", LoroMap, new EntityFactory());
		TemplateGuidelines_ = new MapCollection<IAlignmentGuide>(LoroMap, "template_guidelines__3", new EntityFactory());
		ChordChart_ = new OptionalAtomicObservableProperty<Url>("chord_chart__4", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
		Transition_ = new OptionalComplexObservableProperty<ITransition>("transition__5", LoroMap, new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(BaseSlide_.WhenChangeHappens, Notes_.WhenChangeHappens, TemplateGuidelines_.WhenChangeHappens, ChordChart_.WhenChangeHappens, Transition_.WhenChangeHappens);
	}

	public void Dispose()
	{
		BaseSlide_.Dispose();
		Notes_.Dispose();
		TemplateGuidelines_.Dispose();
		ChordChart_.Dispose();
		Transition_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		BaseSlide_.OnDiff(path, diff);
		Notes_.OnDiff(path, diff);
		TemplateGuidelines_.OnDiff(path, diff);
		ChordChart_.OnDiff(path, diff);
		Transition_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
