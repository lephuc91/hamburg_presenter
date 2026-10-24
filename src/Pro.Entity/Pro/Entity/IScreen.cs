using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IScreen : IEntity, IDisposable
{
	public class Types
	{
		public interface IAlphaSettings : IEntity, IDisposable
		{
			public class Types
			{
				public interface IAlphaDevice : IEntity, IDisposable
				{
					IComplexObservableProperty<IOutputDisplay> Display { get; }

					IObservableProperty<IGraphics.Types.Rect> SubscreenUnitRect { get; }
				}

				internal sealed class AlphaDevice : IAlphaDevice, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private ComplexObservableProperty<IOutputDisplay> Display_;

					private AtomicObservableProperty<IGraphics.Types.Rect> SubscreenUnitRect_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<IOutputDisplay> Display => Display_;

					public IObservableProperty<IGraphics.Types.Rect> SubscreenUnitRect => SubscreenUnitRect_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Display_.UpdateMap(_map);
						SubscreenUnitRect_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Display_.UpdateMapOnInternalMapUpdate(_map);
						SubscreenUnitRect_.UpdateMapOnInternalMapUpdate(_map);
					}

					public AlphaDevice()
						: this(new LoroMap())
					{
					}

					public AlphaDevice(LoroMap values)
					{
						_map = values;
						Display_ = new ComplexObservableProperty<IOutputDisplay>("display__1", LoroMap, new EntityFactory());
						SubscreenUnitRect_ = new AtomicObservableProperty<IGraphics.Types.Rect>("subscreen_unit_rect__2", LoroMap, IGraphics.Types.RectExtension.Deserialize, IGraphics.Types.RectExtension.Serialize);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Display_.WhenChangeHappens.Merge(SubscreenUnitRect_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Display_.Dispose();
						SubscreenUnitRect_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Display_.OnDiff(path, diff);
						SubscreenUnitRect_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum Mode
				{
					Unknown,
					Disabled,
					Premultiplied,
					Straight
				}
			}

			IObservableProperty<Types.Mode> Mode { get; }

			IComplexObservableProperty<Types.IAlphaDevice?> AlphaDevice { get; }
		}

		internal sealed class AlphaSettings : IAlphaSettings, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IAlphaSettings.Types.Mode> Mode_;

			private OptionalComplexObservableProperty<IAlphaSettings.Types.IAlphaDevice> AlphaDevice_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IAlphaSettings.Types.Mode> Mode => Mode_;

			public IComplexObservableProperty<IAlphaSettings.Types.IAlphaDevice?> AlphaDevice => AlphaDevice_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Mode_.UpdateMap(_map);
				AlphaDevice_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Mode_.UpdateMapOnInternalMapUpdate(_map);
				AlphaDevice_.UpdateMapOnInternalMapUpdate(_map);
			}

			public AlphaSettings()
				: this(new LoroMap())
			{
			}

			public AlphaSettings(LoroMap values)
			{
				_map = values;
				Mode_ = new EnumObservableProperty<IAlphaSettings.Types.Mode>("mode__1", LoroMap);
				AlphaDevice_ = new OptionalComplexObservableProperty<IAlphaSettings.Types.IAlphaDevice>("alpha_device__2", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Mode_.WhenChangeHappens.Merge(AlphaDevice_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Mode_.Dispose();
				AlphaDevice_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Mode_.OnDiff(path, diff);
				AlphaDevice_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IBlendCompensation : IEntity, IDisposable
		{
			IObservableProperty<double> BlackLevel { get; }
		}

		internal sealed class BlendCompensation : IBlendCompensation, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty BlackLevel_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> BlackLevel => BlackLevel_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				BlackLevel_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				BlackLevel_.UpdateMapOnInternalMapUpdate(_map);
			}

			public BlendCompensation()
				: this(new LoroMap())
			{
			}

			public BlendCompensation(LoroMap values)
			{
				_map = values;
				BlackLevel_ = new DoubleObservableProperty("black_level__1", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(BlackLevel_.WhenChangeHappens);
			}

			public void Dispose()
			{
				BlackLevel_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				BlackLevel_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IColorAdjustment : IEntity, IDisposable
		{
			IObservableProperty<double> Gamma { get; }

			IObservableProperty<double> BlackLevel { get; }

			IObservableProperty<double> RedLevel { get; }

			IObservableProperty<double> GreenLevel { get; }

			IObservableProperty<double> BlueLevel { get; }
		}

		internal sealed class ColorAdjustment : IColorAdjustment, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty Gamma_;

			private DoubleObservableProperty BlackLevel_;

			private DoubleObservableProperty RedLevel_;

			private DoubleObservableProperty GreenLevel_;

			private DoubleObservableProperty BlueLevel_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> Gamma => Gamma_;

			public IObservableProperty<double> BlackLevel => BlackLevel_;

			public IObservableProperty<double> RedLevel => RedLevel_;

			public IObservableProperty<double> GreenLevel => GreenLevel_;

			public IObservableProperty<double> BlueLevel => BlueLevel_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Gamma_.UpdateMap(_map);
				BlackLevel_.UpdateMap(_map);
				RedLevel_.UpdateMap(_map);
				GreenLevel_.UpdateMap(_map);
				BlueLevel_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Gamma_.UpdateMapOnInternalMapUpdate(_map);
				BlackLevel_.UpdateMapOnInternalMapUpdate(_map);
				RedLevel_.UpdateMapOnInternalMapUpdate(_map);
				GreenLevel_.UpdateMapOnInternalMapUpdate(_map);
				BlueLevel_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ColorAdjustment()
				: this(new LoroMap())
			{
			}

			public ColorAdjustment(LoroMap values)
			{
				_map = values;
				Gamma_ = new DoubleObservableProperty("gamma__1", LoroMap);
				BlackLevel_ = new DoubleObservableProperty("black_level__2", LoroMap);
				RedLevel_ = new DoubleObservableProperty("red_level__3", LoroMap);
				GreenLevel_ = new DoubleObservableProperty("green_level__4", LoroMap);
				BlueLevel_ = new DoubleObservableProperty("blue_level__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Gamma_.WhenChangeHappens, BlackLevel_.WhenChangeHappens, RedLevel_.WhenChangeHappens, GreenLevel_.WhenChangeHappens, BlueLevel_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Gamma_.Dispose();
				BlackLevel_.Dispose();
				RedLevel_.Dispose();
				GreenLevel_.Dispose();
				BlueLevel_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Gamma_.OnDiff(path, diff);
				BlackLevel_.OnDiff(path, diff);
				RedLevel_.OnDiff(path, diff);
				GreenLevel_.OnDiff(path, diff);
				BlueLevel_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> Name { get; }

	IObservableProperty<Color> Color { get; }

	IObservableProperty<IGraphics.Types.Rect> Bounds { get; }

	IObservableProperty<bool> AspectRatioLocked { get; }

	IObservableProperty<bool> OutputBoundsAspectRatioLocked { get; }

	IObservableProperty<bool> CornerPinningEnabled { get; }

	IObservableProperty<IGraphics.Types.Rect> SubscreenUnitRect { get; }

	IObservableProperty<double> Rotation { get; }

	IObservableProperty<double> Gamma { get; }

	IObservableProperty<double> BlackLevel { get; }

	IObservableProperty<uint> BlendedEdges { get; }

	IComplexObservableProperty<ICornerValues> CornerValues { get; }

	IComplexObservableProperty<IOutputDisplay?> OutputDisplay { get; }

	IComplexObservableProperty<Types.IColorAdjustment> ColorAdjustment { get; }

	IComplexObservableProperty<Types.IBlendCompensation> BlendCompensation { get; }

	IComplexObservableProperty<Types.IAlphaSettings> AlphaSettings { get; }
}
