using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class TestPatternDocument : ITestPatternDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private OptionalComplexObservableProperty<ITestPatternDocument.Types.ITestPatternStateData> State_;

	private MapCollection<ITestPatternDocument.Types.ITestPatternData> Patterns_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexObservableProperty<ITestPatternDocument.Types.ITestPatternStateData?> State => State_;

	public IComplexCollection<ITestPatternDocument.Types.ITestPatternData> Patterns => Patterns_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		State_.UpdateMap(_map);
		Patterns_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		State_.UpdateMapOnInternalMapUpdate(_map);
		Patterns_.UpdateMapOnInternalMapUpdate(_map);
	}

	public TestPatternDocument()
		: this(new LoroMap())
	{
	}

	public TestPatternDocument(LoroMap values)
	{
		_map = values;
		State_ = new OptionalComplexObservableProperty<ITestPatternDocument.Types.ITestPatternStateData>("state__1", LoroMap, new EntityFactory());
		Patterns_ = new MapCollection<ITestPatternDocument.Types.ITestPatternData>(LoroMap, "patterns__2", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = State_.WhenChangeHappens.Merge(Patterns_.WhenChangeHappens);
	}

	public void Dispose()
	{
		State_.Dispose();
		Patterns_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		State_.OnDiff(path, diff);
		Patterns_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
