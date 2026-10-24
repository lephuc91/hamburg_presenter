using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ITestPattern : IEntity, IDisposable
{
	public class Types
	{
		public interface IBlendGrid : IEntity, IDisposable
		{
			IObservableProperty<bool> DrawGrid { get; }

			IObservableProperty<bool> DrawCircles { get; }

			IObservableProperty<bool> DrawLines { get; }

			IObservableProperty<bool> InvertColors { get; }

			IObservableProperty<double> GridSpacing { get; }
		}

		internal sealed class BlendGrid : IBlendGrid, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private BoolObservableProperty DrawGrid_;

			private BoolObservableProperty DrawCircles_;

			private BoolObservableProperty DrawLines_;

			private BoolObservableProperty InvertColors_;

			private DoubleObservableProperty GridSpacing_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<bool> DrawGrid => DrawGrid_;

			public IObservableProperty<bool> DrawCircles => DrawCircles_;

			public IObservableProperty<bool> DrawLines => DrawLines_;

			public IObservableProperty<bool> InvertColors => InvertColors_;

			public IObservableProperty<double> GridSpacing => GridSpacing_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				DrawGrid_.UpdateMap(_map);
				DrawCircles_.UpdateMap(_map);
				DrawLines_.UpdateMap(_map);
				InvertColors_.UpdateMap(_map);
				GridSpacing_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				DrawGrid_.UpdateMapOnInternalMapUpdate(_map);
				DrawCircles_.UpdateMapOnInternalMapUpdate(_map);
				DrawLines_.UpdateMapOnInternalMapUpdate(_map);
				InvertColors_.UpdateMapOnInternalMapUpdate(_map);
				GridSpacing_.UpdateMapOnInternalMapUpdate(_map);
			}

			public BlendGrid()
				: this(new LoroMap())
			{
			}

			public BlendGrid(LoroMap values)
			{
				_map = values;
				DrawGrid_ = new BoolObservableProperty("draw_grid__1", LoroMap);
				DrawCircles_ = new BoolObservableProperty("draw_circles__2", LoroMap);
				DrawLines_ = new BoolObservableProperty("draw_lines__3", LoroMap);
				InvertColors_ = new BoolObservableProperty("invert_colors__4", LoroMap);
				GridSpacing_ = new DoubleObservableProperty("grid_spacing__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(DrawGrid_.WhenChangeHappens, DrawCircles_.WhenChangeHappens, DrawLines_.WhenChangeHappens, InvertColors_.WhenChangeHappens, GridSpacing_.WhenChangeHappens);
			}

			public void Dispose()
			{
				DrawGrid_.Dispose();
				DrawCircles_.Dispose();
				DrawLines_.Dispose();
				InvertColors_.Dispose();
				GridSpacing_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				DrawGrid_.OnDiff(path, diff);
				DrawCircles_.OnDiff(path, diff);
				DrawLines_.OnDiff(path, diff);
				InvertColors_.OnDiff(path, diff);
				GridSpacing_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ICustomColor : IEntity, IDisposable
		{
			IObservableProperty<Color> Color { get; }
		}

		internal sealed class CustomColor : ICustomColor, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private AtomicObservableProperty<Color> Color_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Color> Color => Color_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Color_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Color_.UpdateMapOnInternalMapUpdate(_map);
			}

			public CustomColor()
				: this(new LoroMap())
			{
			}

			public CustomColor(LoroMap values)
			{
				_map = values;
				Color_ = new AtomicObservableProperty<Color>("color__1", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Color_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Color_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Color_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IIntensityColor : IEntity, IDisposable
		{
			IObservableProperty<double> Intensity { get; }
		}

		internal sealed class IntensityColor : IIntensityColor, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty Intensity_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> Intensity => Intensity_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Intensity_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Intensity_.UpdateMapOnInternalMapUpdate(_map);
			}

			public IntensityColor()
				: this(new LoroMap())
			{
			}

			public IntensityColor(LoroMap values)
			{
				_map = values;
				Intensity_ = new DoubleObservableProperty("intensity__1", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Intensity_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Intensity_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Intensity_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
