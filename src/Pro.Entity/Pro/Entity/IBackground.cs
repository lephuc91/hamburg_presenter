using System;
using System.Reactive;
using System.Reactive.Disposables;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IBackground : IEntity, IDisposable
{
	public class Types
	{
		public interface IFill : IEntity, IDisposable
		{
			public interface IColor : IFill, IEntity, IDisposable, IObservableProperty<Pro.Entity.Color>
			{
			}

			public interface IGradient : IFill, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IGradient>
			{
			}

			internal class Color : IColor, IFill, IEntity, IDisposable, IObservableProperty<Pro.Entity.Color>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private CompositeDisposable _linkedDisposables = new CompositeDisposable();

				private AtomicObservableProperty<Pro.Entity.Color> _Color_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Color_.WhenChangeHappens;

				public IObservable<Pro.Entity.Color> WhenValueChanges => _Color_.WhenValueChanges;

				public Pro.Entity.Color Value => _Color_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Color_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Color_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "color__1".ToLoroValueLike());
					return loroMap;
				}

				public Color()
					: this(InitializeMap())
				{
				}

				public Color(LoroMap values)
				{
					_map = values;
					_Color_ = new AtomicObservableProperty<Pro.Entity.Color>("color__1", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				}

				public void Dispose()
				{
					_Color_.Dispose();
					LoroMap.Dispose();
					_linkedDisposables.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Color_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_linkedDisposables.Add(disposable);
				}

				public void Set(Pro.Entity.Color value)
				{
					_Color_.Set(value);
				}
			}

			internal class Gradient : IGradient, IFill, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IGradient>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IGraphics.Types.IGradient> _Gradient_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Gradient_.WhenChangeHappens;

				public IObservable<IGraphics.Types.IGradient> WhenValueChanges => _Gradient_.WhenValueChanges;

				public IGraphics.Types.IGradient Value => _Gradient_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Gradient_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Gradient_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "gradient__2".ToLoroValueLike());
					return loroMap;
				}

				public Gradient()
					: this(InitializeMap())
				{
				}

				public Gradient(LoroMap values)
				{
					_map = values;
					_Gradient_ = new ComplexObservableProperty<IGraphics.Types.IGradient>("gradient__2", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Gradient_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Gradient_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Gradient_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IGraphics.Types.IGradient value)
				{
					_Gradient_.Set(value);
				}
			}
		}

		internal class FillFactory : IUnionValueFactory<IFill>
		{
			public string SelectionKey => "__tag";

			public IFill? CreateInstance(LoroMap map)
			{
				string text = map.Get("__tag").ToStringValue();
				if (!(text == "color__1"))
				{
					if (text == "gradient__2")
					{
						return new IFill.Gradient(map);
					}
					return null;
				}
				return new IFill.Color(map);
			}

			public IFill CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "color__1".ToLoroValueLike());
				return new IFill.Color(map);
			}
		}
	}

	IObservableProperty<bool> IsEnabled { get; }

	IComplexObservableProperty<Types.IFill> Fill { get; }
}
