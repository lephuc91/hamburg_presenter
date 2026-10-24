using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ITestPatternRenderSettings : IEntity, IDisposable
{
	public class Types
	{
		public interface IOutput : IEntity, IDisposable
		{
			IObservableProperty<int> X { get; }

			IObservableProperty<int> Y { get; }

			IObservableProperty<int> Width { get; }

			IObservableProperty<int> Height { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<double> FrameRate { get; }
		}

		internal sealed class Output : IOutput, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private IntObservableProperty X_;

			private IntObservableProperty Y_;

			private IntObservableProperty Width_;

			private IntObservableProperty Height_;

			private StringObservableProperty Name_;

			private DoubleObservableProperty FrameRate_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<int> X => X_;

			public IObservableProperty<int> Y => Y_;

			public IObservableProperty<int> Width => Width_;

			public IObservableProperty<int> Height => Height_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<double> FrameRate => FrameRate_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				X_.UpdateMap(_map);
				Y_.UpdateMap(_map);
				Width_.UpdateMap(_map);
				Height_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				FrameRate_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				X_.UpdateMapOnInternalMapUpdate(_map);
				Y_.UpdateMapOnInternalMapUpdate(_map);
				Width_.UpdateMapOnInternalMapUpdate(_map);
				Height_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				FrameRate_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Output()
				: this(new LoroMap())
			{
			}

			public Output(LoroMap values)
			{
				_map = values;
				X_ = new IntObservableProperty("x__1", LoroMap);
				Y_ = new IntObservableProperty("y__2", LoroMap);
				Width_ = new IntObservableProperty("width__3", LoroMap);
				Height_ = new IntObservableProperty("height__4", LoroMap);
				Name_ = new StringObservableProperty("name__5", LoroMap);
				FrameRate_ = new DoubleObservableProperty("frame_rate__6", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(X_.WhenChangeHappens, Y_.WhenChangeHappens, Width_.WhenChangeHappens, Height_.WhenChangeHappens, Name_.WhenChangeHappens, FrameRate_.WhenChangeHappens);
			}

			public void Dispose()
			{
				X_.Dispose();
				Y_.Dispose();
				Width_.Dispose();
				Height_.Dispose();
				Name_.Dispose();
				FrameRate_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				X_.OnDiff(path, diff);
				Y_.OnDiff(path, diff);
				Width_.OnDiff(path, diff);
				Height_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				FrameRate_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
