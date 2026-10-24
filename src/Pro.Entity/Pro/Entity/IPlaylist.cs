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

public interface IPlaylist : IEntity, IDisposable
{
	public class Types
	{
		public interface IFolderDirectory : IEntity, IDisposable
		{
			public class Types
			{
				public enum ImportBehavior
				{
					Background,
					Foreground
				}
			}

			IObservableProperty<Url> SmartDirectory { get; }

			IObservableProperty<Types.ImportBehavior> ImportBehavior { get; }
		}

		internal sealed class FolderDirectory : IFolderDirectory, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private AtomicObservableProperty<Url> SmartDirectory_;

			private EnumObservableProperty<IFolderDirectory.Types.ImportBehavior> ImportBehavior_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Url> SmartDirectory => SmartDirectory_;

			public IObservableProperty<IFolderDirectory.Types.ImportBehavior> ImportBehavior => ImportBehavior_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				SmartDirectory_.UpdateMap(_map);
				ImportBehavior_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				SmartDirectory_.UpdateMapOnInternalMapUpdate(_map);
				ImportBehavior_.UpdateMapOnInternalMapUpdate(_map);
			}

			public FolderDirectory()
				: this(new LoroMap())
			{
			}

			public FolderDirectory(LoroMap values)
			{
				_map = values;
				SmartDirectory_ = new AtomicObservableProperty<Url>("smart_directory__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
				ImportBehavior_ = new EnumObservableProperty<IFolderDirectory.Types.ImportBehavior>("import_behavior__2", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = SmartDirectory_.WhenChangeHappens.Merge(ImportBehavior_.WhenChangeHappens);
			}

			public void Dispose()
			{
				SmartDirectory_.Dispose();
				ImportBehavior_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				SmartDirectory_.OnDiff(path, diff);
				ImportBehavior_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPlaylistArray : IEntity, IDisposable
		{
			IComplexCollection<IPlaylist> Playlists { get; }
		}

		internal sealed class PlaylistArray : IPlaylistArray, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<IPlaylist> Playlists_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<IPlaylist> Playlists => Playlists_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Playlists_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Playlists_.UpdateMapOnInternalMapUpdate(_map);
			}

			public PlaylistArray()
				: this(new LoroMap())
			{
			}

			public PlaylistArray(LoroMap values)
			{
				_map = values;
				Playlists_ = new MapCollection<IPlaylist>(LoroMap, "playlists__1", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Playlists_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Playlists_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Playlists_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPlaylistItems : IEntity, IDisposable
		{
			IComplexCollection<IPlaylistItem> Items { get; }
		}

		internal sealed class PlaylistItems : IPlaylistItems, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<IPlaylistItem> Items_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<IPlaylistItem> Items => Items_;

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

			public PlaylistItems()
				: this(new LoroMap())
			{
			}

			public PlaylistItems(LoroMap values)
			{
				_map = values;
				Items_ = new MapCollection<IPlaylistItem>(LoroMap, "items__1", new EntityFactory());
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

		public interface IChildrenType : IEntity, IDisposable
		{
			public interface IPlaylists : IChildrenType, IEntity, IDisposable, IObservableProperty<IPlaylistArray>
			{
			}

			public interface IItems : IChildrenType, IEntity, IDisposable, IObservableProperty<IPlaylistItems>
			{
			}

			internal class Playlists : IPlaylists, IChildrenType, IEntity, IDisposable, IObservableProperty<IPlaylistArray>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IPlaylistArray> _Playlists_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Playlists_.WhenChangeHappens;

				public IObservable<IPlaylistArray> WhenValueChanges => _Playlists_.WhenValueChanges;

				public IPlaylistArray Value => _Playlists_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Playlists_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Playlists_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "playlists__12".ToLoroValueLike());
					return loroMap;
				}

				public Playlists()
					: this(InitializeMap())
				{
				}

				public Playlists(LoroMap values)
				{
					_map = values;
					_Playlists_ = new ComplexObservableProperty<IPlaylistArray>("playlists__12", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Playlists_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Playlists_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Playlists_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IPlaylistArray value)
				{
					_Playlists_.Set(value);
				}
			}

			internal class Items : IItems, IChildrenType, IEntity, IDisposable, IObservableProperty<IPlaylistItems>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IPlaylistItems> _Items_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Items_.WhenChangeHappens;

				public IObservable<IPlaylistItems> WhenValueChanges => _Items_.WhenValueChanges;

				public IPlaylistItems Value => _Items_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Items_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Items_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "items__13".ToLoroValueLike());
					return loroMap;
				}

				public Items()
					: this(InitializeMap())
				{
				}

				public Items(LoroMap values)
				{
					_map = values;
					_Items_ = new ComplexObservableProperty<IPlaylistItems>("items__13", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Items_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Items_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Items_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IPlaylistItems value)
				{
					_Items_.Set(value);
				}
			}
		}

		public interface ILinkData : IEntity, IDisposable
		{
			public interface ISmartDirectory : ILinkData, IEntity, IDisposable, IObservableProperty<IFolderDirectory>
			{
			}

			public interface IPcoPlan : ILinkData, IEntity, IDisposable, IObservableProperty<IPlanningCenterPlan>
			{
			}

			internal class SmartDirectory : ISmartDirectory, ILinkData, IEntity, IDisposable, IObservableProperty<IFolderDirectory>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IFolderDirectory> _SmartDirectory_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _SmartDirectory_.WhenChangeHappens;

				public IObservable<IFolderDirectory> WhenValueChanges => _SmartDirectory_.WhenValueChanges;

				public IFolderDirectory Value => _SmartDirectory_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_SmartDirectory_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_SmartDirectory_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "smart_directory__14".ToLoroValueLike());
					return loroMap;
				}

				public SmartDirectory()
					: this(InitializeMap())
				{
				}

				public SmartDirectory(LoroMap values)
				{
					_map = values;
					_SmartDirectory_ = new ComplexObservableProperty<IFolderDirectory>("smart_directory__14", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_SmartDirectory_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_SmartDirectory_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_SmartDirectory_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IFolderDirectory value)
				{
					_SmartDirectory_.Set(value);
				}
			}

			internal class PcoPlan : IPcoPlan, ILinkData, IEntity, IDisposable, IObservableProperty<IPlanningCenterPlan>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IPlanningCenterPlan> _PcoPlan_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _PcoPlan_.WhenChangeHappens;

				public IObservable<IPlanningCenterPlan> WhenValueChanges => _PcoPlan_.WhenValueChanges;

				public IPlanningCenterPlan Value => _PcoPlan_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_PcoPlan_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_PcoPlan_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "pco_plan__15".ToLoroValueLike());
					return loroMap;
				}

				public PcoPlan()
					: this(InitializeMap())
				{
				}

				public PcoPlan(LoroMap values)
				{
					_map = values;
					_PcoPlan_ = new ComplexObservableProperty<IPlanningCenterPlan>("pco_plan__15", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_PcoPlan_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_PcoPlan_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_PcoPlan_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IPlanningCenterPlan value)
				{
					_PcoPlan_.Set(value);
				}
			}
		}

		internal class ChildrenTypeFactory : IUnionValueFactory<IChildrenType>
		{
			public string SelectionKey => "__tag";

			public IChildrenType? CreateInstance(LoroMap map)
			{
				string text = map.Get("__tag").ToStringValue();
				if (!(text == "playlists__12"))
				{
					if (text == "items__13")
					{
						return new IChildrenType.Items(map);
					}
					return null;
				}
				return new IChildrenType.Playlists(map);
			}

			public IChildrenType CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "playlists__12".ToLoroValueLike());
				return new IChildrenType.Playlists(map);
			}
		}

		internal class LinkDataFactory : IUnionValueFactory<ILinkData>
		{
			public string SelectionKey => "__tag";

			public ILinkData? CreateInstance(LoroMap map)
			{
				string text = map.Get("__tag").ToStringValue();
				if (!(text == "smart_directory__14"))
				{
					if (text == "pco_plan__15")
					{
						return new ILinkData.PcoPlan(map);
					}
					return null;
				}
				return new ILinkData.SmartDirectory(map);
			}

			public ILinkData CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "smart_directory__14".ToLoroValueLike());
				return new ILinkData.SmartDirectory(map);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> Name { get; }

	IObservableProperty<bool> Expanded { get; }

	IComplexObservableProperty<Types.IChildrenType> ChildrenType { get; }

	IComplexObservableProperty<Types.ILinkData> LinkData { get; }
}
