using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ICommunicationDeviceOption : IEntity, IDisposable
{
	public class Types
	{
		public interface IOesProMode : IEntity, IDisposable
		{
			IObservableProperty<bool> Enable { get; }
		}

		internal sealed class OesProMode : IOesProMode, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private BoolObservableProperty Enable_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<bool> Enable => Enable_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Enable_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Enable_.UpdateMapOnInternalMapUpdate(_map);
			}

			public OesProMode()
				: this(new LoroMap())
			{
			}

			public OesProMode(LoroMap values)
			{
				_map = values;
				Enable_ = new BoolObservableProperty("enable__1", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Enable_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Enable_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Enable_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IOptionType : IEntity, IDisposable
		{
			public interface IOesProMode : IOptionType, IEntity, IDisposable, IObservableProperty<Types.IOesProMode>
			{
			}

			internal class OesProMode : IOesProMode, IOptionType, IEntity, IDisposable, IObservableProperty<Types.IOesProMode>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<Types.IOesProMode> _OesProMode_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _OesProMode_.WhenChangeHappens;

				public IObservable<Types.IOesProMode> WhenValueChanges => _OesProMode_.WhenValueChanges;

				public Types.IOesProMode Value => _OesProMode_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_OesProMode_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_OesProMode_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "oes_pro_mode__1".ToLoroValueLike());
					return loroMap;
				}

				public OesProMode()
					: this(InitializeMap())
				{
				}

				public OesProMode(LoroMap values)
				{
					_map = values;
					_OesProMode_ = new ComplexObservableProperty<Types.IOesProMode>("oes_pro_mode__1", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_OesProMode_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_OesProMode_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_OesProMode_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(Types.IOesProMode value)
				{
					_OesProMode_.Set(value);
				}
			}
		}

		internal class OptionTypeFactory : IUnionValueFactory<IOptionType>
		{
			public string SelectionKey => "__tag";

			public IOptionType? CreateInstance(LoroMap map)
			{
				if (map.Get("__tag").ToStringValue() == "oes_pro_mode__1")
				{
					return new IOptionType.OesProMode(map);
				}
				return null;
			}

			public IOptionType CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "oes_pro_mode__1".ToLoroValueLike());
				return new IOptionType.OesProMode(map);
			}
		}
	}

	IComplexObservableProperty<Types.IOptionType> OptionType { get; }
}
