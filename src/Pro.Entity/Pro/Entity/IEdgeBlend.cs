using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IEdgeBlend : IEntity, IDisposable
{
	public class Types
	{
		public interface IScreen : IEntity, IDisposable
		{
			public class Types
			{
				public enum Edge
				{
					Unknown,
					Left,
					Right,
					Top,
					Bottom
				}
			}

			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<Types.Edge> Edge { get; }

			IObservableProperty<double> Gamma { get; }

			IObservableProperty<double> BlackLevel { get; }

			IObservableProperty<Mode> Mode { get; }

			IObservableProperty<double> Radius { get; }

			IObservableProperty<double> Intensity { get; }
		}

		internal sealed class Screen : IScreen, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private EnumObservableProperty<IScreen.Types.Edge> Edge_;

			private DoubleObservableProperty Gamma_;

			private DoubleObservableProperty BlackLevel_;

			private EnumObservableProperty<Mode> Mode_;

			private DoubleObservableProperty Radius_;

			private DoubleObservableProperty Intensity_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<IScreen.Types.Edge> Edge => Edge_;

			public IObservableProperty<double> Gamma => Gamma_;

			public IObservableProperty<double> BlackLevel => BlackLevel_;

			public IObservableProperty<Mode> Mode => Mode_;

			public IObservableProperty<double> Radius => Radius_;

			public IObservableProperty<double> Intensity => Intensity_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Edge_.UpdateMap(_map);
				Gamma_.UpdateMap(_map);
				BlackLevel_.UpdateMap(_map);
				Mode_.UpdateMap(_map);
				Radius_.UpdateMap(_map);
				Intensity_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Edge_.UpdateMapOnInternalMapUpdate(_map);
				Gamma_.UpdateMapOnInternalMapUpdate(_map);
				BlackLevel_.UpdateMapOnInternalMapUpdate(_map);
				Mode_.UpdateMapOnInternalMapUpdate(_map);
				Radius_.UpdateMapOnInternalMapUpdate(_map);
				Intensity_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Screen()
				: this(new LoroMap())
			{
			}

			public Screen(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Edge_ = new EnumObservableProperty<IScreen.Types.Edge>("edge__2", LoroMap);
				Gamma_ = new DoubleObservableProperty("gamma__3", LoroMap);
				BlackLevel_ = new DoubleObservableProperty("black_level__4", LoroMap);
				Mode_ = new EnumObservableProperty<Mode>("mode__5", LoroMap);
				Radius_ = new DoubleObservableProperty("radius__6", LoroMap);
				Intensity_ = new DoubleObservableProperty("intensity__7", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Edge_.WhenChangeHappens, Gamma_.WhenChangeHappens, BlackLevel_.WhenChangeHappens, Mode_.WhenChangeHappens, Radius_.WhenChangeHappens, Intensity_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Edge_.Dispose();
				Gamma_.Dispose();
				BlackLevel_.Dispose();
				Mode_.Dispose();
				Radius_.Dispose();
				Intensity_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Edge_.OnDiff(path, diff);
				Gamma_.OnDiff(path, diff);
				BlackLevel_.OnDiff(path, diff);
				Mode_.OnDiff(path, diff);
				Radius_.OnDiff(path, diff);
				Intensity_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public enum Mode
		{
			Linear,
			Cubic,
			Quadratic
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<double> Radius { get; }

	IObservableProperty<double> Intensity { get; }

	IObservableProperty<Types.Mode> Mode { get; }

	IComplexObservableProperty<Types.IScreen> FirstScreen { get; }

	IComplexObservableProperty<Types.IScreen> SecondScreen { get; }

	IComplexObservableProperty<Types.IScreen> LeftScreen { get; }

	IComplexObservableProperty<Types.IScreen> RightScreen { get; }

	IComplexObservableProperty<Types.IScreen> TopScreen { get; }

	IComplexObservableProperty<Types.IScreen> BottomScreen { get; }
}
