using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ILibrary : IEntity, IDisposable
{
	public class Types
	{
		public interface ILibraryArray : IEntity, IDisposable
		{
			IComplexCollection<ILibrary> Libraries { get; }
		}

		internal sealed class LibraryArray : ILibraryArray, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<ILibrary> Libraries_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<ILibrary> Libraries => Libraries_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Libraries_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Libraries_.UpdateMapOnInternalMapUpdate(_map);
			}

			public LibraryArray()
				: this(new LoroMap())
			{
			}

			public LibraryArray(LoroMap values)
			{
				_map = values;
				Libraries_ = new MapCollection<ILibrary>(LoroMap, "libraries__1", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Libraries_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Libraries_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Libraries_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ILibraryItems : IEntity, IDisposable
		{
			IComplexCollection<ILibraryItem> Items { get; }
		}

		internal sealed class LibraryItems : ILibraryItems, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<ILibraryItem> Items_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<ILibraryItem> Items => Items_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Items_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Items_.UpdateMapOnInternalMapUpdate(_map);
			}

			public LibraryItems()
				: this(new LoroMap())
			{
			}

			public LibraryItems(LoroMap values)
			{
				_map = values;
				Items_ = new MapCollection<ILibraryItem>(LoroMap, "items__1", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Items_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Items_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Items_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IChildType : IEntity, IDisposable
		{
			public interface ILibraryChildren : IChildType, IEntity, IDisposable, IObservableProperty<ILibraryArray>
			{
			}

			public interface ILibraryItems : IChildType, IEntity, IDisposable, IObservableProperty<Types.ILibraryItems>
			{
			}

			internal class LibraryChildren : ILibraryChildren, IChildType, IEntity, IDisposable, IObservableProperty<ILibraryArray>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ILibraryArray> _LibraryChildren_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _LibraryChildren_.WhenChangeHappens;

				public IObservable<ILibraryArray> WhenValueChanges => _LibraryChildren_.WhenValueChanges;

				public ILibraryArray Value => _LibraryChildren_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_LibraryChildren_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_LibraryChildren_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "libraryChildren__2".ToLoroValueLike());
					return loroMap;
				}

				public LibraryChildren()
					: this(InitializeMap())
				{
				}

				public LibraryChildren(LoroMap values)
				{
					_map = values;
					_LibraryChildren_ = new ComplexObservableProperty<ILibraryArray>("libraryChildren__2", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_LibraryChildren_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_LibraryChildren_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_LibraryChildren_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ILibraryArray value)
				{
					_LibraryChildren_.Set(value);
				}
			}

			internal class LibraryItems : ILibraryItems, IChildType, IEntity, IDisposable, IObservableProperty<Types.ILibraryItems>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<Types.ILibraryItems> _LibraryItems_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _LibraryItems_.WhenChangeHappens;

				public IObservable<Types.ILibraryItems> WhenValueChanges => _LibraryItems_.WhenValueChanges;

				public Types.ILibraryItems Value => _LibraryItems_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_LibraryItems_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_LibraryItems_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "libraryItems__3".ToLoroValueLike());
					return loroMap;
				}

				public LibraryItems()
					: this(InitializeMap())
				{
				}

				public LibraryItems(LoroMap values)
				{
					_map = values;
					_LibraryItems_ = new ComplexObservableProperty<Types.ILibraryItems>("libraryItems__3", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_LibraryItems_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_LibraryItems_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_LibraryItems_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(Types.ILibraryItems value)
				{
					_LibraryItems_.Set(value);
				}
			}
		}

		internal class ChildTypeFactory : IUnionValueFactory<IChildType>
		{
			public string SelectionKey => "__tag";

			public IChildType? CreateInstance(LoroMap map)
			{
				string text = map.Get("__tag").ToStringValue();
				if (!(text == "libraryChildren__2"))
				{
					if (text == "libraryItems__3")
					{
						return new IChildType.LibraryItems(map);
					}
					return null;
				}
				return new IChildType.LibraryChildren(map);
			}

			public IChildType CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "libraryChildren__2".ToLoroValueLike());
				return new IChildType.LibraryChildren(map);
			}
		}
	}

	IObservableProperty<Url> Url { get; }

	IComplexObservableProperty<Types.IChildType> ChildType { get; }
}
