using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class EdgeBlend : IEdgeBlend, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private DoubleObservableProperty Radius_;

	private DoubleObservableProperty Intensity_;

	private EnumObservableProperty<IEdgeBlend.Types.Mode> Mode_;

	private ComplexObservableProperty<IEdgeBlend.Types.IScreen> FirstScreen_;

	private ComplexObservableProperty<IEdgeBlend.Types.IScreen> SecondScreen_;

	private ComplexObservableProperty<IEdgeBlend.Types.IScreen> LeftScreen_;

	private ComplexObservableProperty<IEdgeBlend.Types.IScreen> RightScreen_;

	private ComplexObservableProperty<IEdgeBlend.Types.IScreen> TopScreen_;

	private ComplexObservableProperty<IEdgeBlend.Types.IScreen> BottomScreen_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<double> Radius => Radius_;

	public IObservableProperty<double> Intensity => Intensity_;

	public IObservableProperty<IEdgeBlend.Types.Mode> Mode => Mode_;

	public IComplexObservableProperty<IEdgeBlend.Types.IScreen> FirstScreen => FirstScreen_;

	public IComplexObservableProperty<IEdgeBlend.Types.IScreen> SecondScreen => SecondScreen_;

	public IComplexObservableProperty<IEdgeBlend.Types.IScreen> LeftScreen => LeftScreen_;

	public IComplexObservableProperty<IEdgeBlend.Types.IScreen> RightScreen => RightScreen_;

	public IComplexObservableProperty<IEdgeBlend.Types.IScreen> TopScreen => TopScreen_;

	public IComplexObservableProperty<IEdgeBlend.Types.IScreen> BottomScreen => BottomScreen_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Radius_.UpdateMap(_map);
		Intensity_.UpdateMap(_map);
		Mode_.UpdateMap(_map);
		FirstScreen_.UpdateMap(_map);
		SecondScreen_.UpdateMap(_map);
		LeftScreen_.UpdateMap(_map);
		RightScreen_.UpdateMap(_map);
		TopScreen_.UpdateMap(_map);
		BottomScreen_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Radius_.UpdateMapOnInternalMapUpdate(_map);
		Intensity_.UpdateMapOnInternalMapUpdate(_map);
		Mode_.UpdateMapOnInternalMapUpdate(_map);
		FirstScreen_.UpdateMapOnInternalMapUpdate(_map);
		SecondScreen_.UpdateMapOnInternalMapUpdate(_map);
		LeftScreen_.UpdateMapOnInternalMapUpdate(_map);
		RightScreen_.UpdateMapOnInternalMapUpdate(_map);
		TopScreen_.UpdateMapOnInternalMapUpdate(_map);
		BottomScreen_.UpdateMapOnInternalMapUpdate(_map);
	}

	public EdgeBlend()
		: this(new LoroMap())
	{
	}

	public EdgeBlend(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Radius_ = new DoubleObservableProperty("radius__2", LoroMap);
		Intensity_ = new DoubleObservableProperty("intensity__3", LoroMap);
		Mode_ = new EnumObservableProperty<IEdgeBlend.Types.Mode>("mode__4", LoroMap);
		FirstScreen_ = new ComplexObservableProperty<IEdgeBlend.Types.IScreen>("first_screen__5", LoroMap, new EntityFactory());
		SecondScreen_ = new ComplexObservableProperty<IEdgeBlend.Types.IScreen>("second_screen__6", LoroMap, new EntityFactory());
		LeftScreen_ = new ComplexObservableProperty<IEdgeBlend.Types.IScreen>("left_screen__7", LoroMap, new EntityFactory());
		RightScreen_ = new ComplexObservableProperty<IEdgeBlend.Types.IScreen>("right_screen__8", LoroMap, new EntityFactory());
		TopScreen_ = new ComplexObservableProperty<IEdgeBlend.Types.IScreen>("top_screen__9", LoroMap, new EntityFactory());
		BottomScreen_ = new ComplexObservableProperty<IEdgeBlend.Types.IScreen>("bottom_screen__10", LoroMap, new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Radius_.WhenChangeHappens, Intensity_.WhenChangeHappens, Mode_.WhenChangeHappens, FirstScreen_.WhenChangeHappens, SecondScreen_.WhenChangeHappens, LeftScreen_.WhenChangeHappens, RightScreen_.WhenChangeHappens, TopScreen_.WhenChangeHappens, BottomScreen_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Radius_.Dispose();
		Intensity_.Dispose();
		Mode_.Dispose();
		FirstScreen_.Dispose();
		SecondScreen_.Dispose();
		LeftScreen_.Dispose();
		RightScreen_.Dispose();
		TopScreen_.Dispose();
		BottomScreen_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Radius_.OnDiff(path, diff);
		Intensity_.OnDiff(path, diff);
		Mode_.OnDiff(path, diff);
		FirstScreen_.OnDiff(path, diff);
		SecondScreen_.OnDiff(path, diff);
		LeftScreen_.OnDiff(path, diff);
		RightScreen_.OnDiff(path, diff);
		TopScreen_.OnDiff(path, diff);
		BottomScreen_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
