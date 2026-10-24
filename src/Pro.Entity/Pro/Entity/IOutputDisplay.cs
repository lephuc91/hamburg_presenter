using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IOutputDisplay : IEntity, IDisposable
{
	public class Types
	{
		public interface IBlackmagic : IEntity, IDisposable
		{
			public class Types
			{
				public enum KeyMode
				{
					Internal,
					External
				}
			}

			IObservableProperty<bool> Enabled { get; }

			IObservableProperty<Types.KeyMode> KeyMode { get; }

			IObservableProperty<double> BlendValue { get; }
		}

		internal sealed class Blackmagic : IBlackmagic, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private BoolObservableProperty Enabled_;

			private EnumObservableProperty<IBlackmagic.Types.KeyMode> KeyMode_;

			private DoubleObservableProperty BlendValue_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<bool> Enabled => Enabled_;

			public IObservableProperty<IBlackmagic.Types.KeyMode> KeyMode => KeyMode_;

			public IObservableProperty<double> BlendValue => BlendValue_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Enabled_.UpdateMap(_map);
				KeyMode_.UpdateMap(_map);
				BlendValue_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Enabled_.UpdateMapOnInternalMapUpdate(_map);
				KeyMode_.UpdateMapOnInternalMapUpdate(_map);
				BlendValue_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Blackmagic()
				: this(new LoroMap())
			{
			}

			public Blackmagic(LoroMap values)
			{
				_map = values;
				Enabled_ = new BoolObservableProperty("enabled__1", LoroMap);
				KeyMode_ = new EnumObservableProperty<IBlackmagic.Types.KeyMode>("key_mode__2", LoroMap);
				BlendValue_ = new DoubleObservableProperty("blend_value__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Enabled_.WhenChangeHappens, KeyMode_.WhenChangeHappens, BlendValue_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Enabled_.Dispose();
				KeyMode_.Dispose();
				BlendValue_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Enabled_.OnDiff(path, diff);
				KeyMode_.OnDiff(path, diff);
				BlendValue_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public enum RenderFormat
		{
			Sdr,
			Rec2100Pq,
			Rec2100Hlg
		}

		public enum Type
		{
			Unknown,
			Screen,
			Card,
			Ndi,
			Syphon,
			Custom
		}

		public interface IHardwareOptions : IEntity, IDisposable
		{
			public interface IBlackmagic : IHardwareOptions, IEntity, IDisposable, IObservableProperty<Types.IBlackmagic>
			{
			}

			internal class Blackmagic : IBlackmagic, IHardwareOptions, IEntity, IDisposable, IObservableProperty<Types.IBlackmagic>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<Types.IBlackmagic> _Blackmagic_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Blackmagic_.WhenChangeHappens;

				public IObservable<Types.IBlackmagic> WhenValueChanges => _Blackmagic_.WhenValueChanges;

				public Types.IBlackmagic Value => _Blackmagic_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Blackmagic_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Blackmagic_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "blackmagic__11".ToLoroValueLike());
					return loroMap;
				}

				public Blackmagic()
					: this(InitializeMap())
				{
				}

				public Blackmagic(LoroMap values)
				{
					_map = values;
					_Blackmagic_ = new ComplexObservableProperty<Types.IBlackmagic>("blackmagic__11", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Blackmagic_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Blackmagic_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Blackmagic_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(Types.IBlackmagic value)
				{
					_Blackmagic_.Set(value);
				}
			}
		}

		internal class HardwareOptionsFactory : IUnionValueFactory<IHardwareOptions>
		{
			public string SelectionKey => "__tag";

			public IHardwareOptions? CreateInstance(LoroMap map)
			{
				if (map.Get("__tag").ToStringValue() == "blackmagic__11")
				{
					return new IHardwareOptions.Blackmagic(map);
				}
				return null;
			}

			public IHardwareOptions CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "blackmagic__11".ToLoroValueLike());
				return new IHardwareOptions.Blackmagic(map);
			}
		}
	}

	IObservableProperty<string> Name { get; }

	IObservableProperty<string> Model { get; }

	IObservableProperty<string> Serial { get; }

	IObservableProperty<string> DeviceName { get; }

	IObservableProperty<string> Vendor { get; }

	IObservableProperty<uint> ModeIndex { get; }

	IObservableProperty<IGraphics.Types.Rect> Bounds { get; }

	IObservableProperty<Types.Type> Type { get; }

	IComplexObservableProperty<IDisplayMode> Mode { get; }

	IObservableProperty<string> RenderId { get; }

	IObservableProperty<int> VideoDelay { get; }

	IObservableProperty<Types.RenderFormat> RenderFormat { get; }

	IObservableProperty<int> HdrMaxNitsOffset { get; }

	IComplexObservableProperty<Types.IHardwareOptions> HardwareOptions { get; }
}
