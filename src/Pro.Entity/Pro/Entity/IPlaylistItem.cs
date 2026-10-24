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

public interface IPlaylistItem : IEntity, IDisposable
{
	public class Types
	{
		public interface IHeader : IEntity, IDisposable
		{
			IObservableProperty<Color> Color { get; }

			IComplexCollection<IAction> Actions { get; }
		}

		internal sealed class Header : IHeader, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private AtomicObservableProperty<Color> Color_;

			private MapCollection<IAction> Actions_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Color> Color => Color_;

			public IComplexCollection<IAction> Actions => Actions_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Color_.UpdateMap(_map);
				Actions_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Color_.UpdateMapOnInternalMapUpdate(_map);
				Actions_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Header()
				: this(new LoroMap())
			{
			}

			public Header(LoroMap values)
			{
				_map = values;
				Color_ = new AtomicObservableProperty<Color>("color__1", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				Actions_ = new MapCollection<IAction>(LoroMap, "actions__2", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Color_.WhenChangeHappens.Merge(Actions_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Color_.Dispose();
				Actions_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Color_.OnDiff(path, diff);
				Actions_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPlaceholder : IEntity, IDisposable
		{
			IComplexObservableProperty<IPlaylistItem?> LinkedData { get; }
		}

		internal sealed class Placeholder : IPlaceholder, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalComplexObservableProperty<IPlaylistItem> LinkedData_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IPlaylistItem?> LinkedData => LinkedData_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				LinkedData_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				LinkedData_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Placeholder()
				: this(new LoroMap())
			{
			}

			public Placeholder(LoroMap values)
			{
				_map = values;
				LinkedData_ = new OptionalComplexObservableProperty<IPlaylistItem>("linked_data__1", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(LinkedData_.WhenChangeHappens);
			}

			public void Dispose()
			{
				LinkedData_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				LinkedData_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPlanningCenter : IEntity, IDisposable
		{
			IComplexObservableProperty<IPlanningCenterPlan.Types.IPlanItem> Item { get; }

			IComplexObservableProperty<IPlaylistItem?> LinkedData { get; }
		}

		internal sealed class PlanningCenter : IPlanningCenter, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IPlanningCenterPlan.Types.IPlanItem> Item_;

			private OptionalComplexObservableProperty<IPlaylistItem> LinkedData_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IPlanningCenterPlan.Types.IPlanItem> Item => Item_;

			public IComplexObservableProperty<IPlaylistItem?> LinkedData => LinkedData_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Item_.UpdateMap(_map);
				LinkedData_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Item_.UpdateMapOnInternalMapUpdate(_map);
				LinkedData_.UpdateMapOnInternalMapUpdate(_map);
			}

			public PlanningCenter()
				: this(new LoroMap())
			{
			}

			public PlanningCenter(LoroMap values)
			{
				_map = values;
				Item_ = new ComplexObservableProperty<IPlanningCenterPlan.Types.IPlanItem>("item__1", LoroMap, new EntityFactory());
				LinkedData_ = new OptionalComplexObservableProperty<IPlaylistItem>("linked_data__2", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Item_.WhenChangeHappens.Merge(LinkedData_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Item_.Dispose();
				LinkedData_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Item_.OnDiff(path, diff);
				LinkedData_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPresentation : IEntity, IDisposable
		{
			IObservableProperty<Url> DocumentPath { get; }

			IObservableProperty<Guid?> Arrangement { get; }

			IObservableProperty<IAction.Types.ContentDestination> ContentDestination { get; }

			IComplexObservableProperty<IMusicKeyScale?> UserMusicKey { get; }

			IObservableProperty<string> ArrangementName { get; }
		}

		internal sealed class Presentation : IPresentation, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private AtomicObservableProperty<Url> DocumentPath_;

			private OptionalGuidObservableProperty Arrangement_;

			private EnumObservableProperty<IAction.Types.ContentDestination> ContentDestination_;

			private OptionalComplexObservableProperty<IMusicKeyScale> UserMusicKey_;

			private StringObservableProperty ArrangementName_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Url> DocumentPath => DocumentPath_;

			public IObservableProperty<Guid?> Arrangement => Arrangement_;

			public IObservableProperty<IAction.Types.ContentDestination> ContentDestination => ContentDestination_;

			public IComplexObservableProperty<IMusicKeyScale?> UserMusicKey => UserMusicKey_;

			public IObservableProperty<string> ArrangementName => ArrangementName_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				DocumentPath_.UpdateMap(_map);
				Arrangement_.UpdateMap(_map);
				ContentDestination_.UpdateMap(_map);
				UserMusicKey_.UpdateMap(_map);
				ArrangementName_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				DocumentPath_.UpdateMapOnInternalMapUpdate(_map);
				Arrangement_.UpdateMapOnInternalMapUpdate(_map);
				ContentDestination_.UpdateMapOnInternalMapUpdate(_map);
				UserMusicKey_.UpdateMapOnInternalMapUpdate(_map);
				ArrangementName_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Presentation()
				: this(new LoroMap())
			{
			}

			public Presentation(LoroMap values)
			{
				_map = values;
				DocumentPath_ = new AtomicObservableProperty<Url>("document_path__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
				Arrangement_ = new OptionalGuidObservableProperty("arrangement__2", LoroMap);
				ContentDestination_ = new EnumObservableProperty<IAction.Types.ContentDestination>("content_destination__3", LoroMap);
				UserMusicKey_ = new OptionalComplexObservableProperty<IMusicKeyScale>("user_music_key__4", LoroMap, new EntityFactory());
				ArrangementName_ = new StringObservableProperty("arrangement_name__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(DocumentPath_.WhenChangeHappens, Arrangement_.WhenChangeHappens, ContentDestination_.WhenChangeHappens, UserMusicKey_.WhenChangeHappens, ArrangementName_.WhenChangeHappens);
			}

			public void Dispose()
			{
				DocumentPath_.Dispose();
				Arrangement_.Dispose();
				ContentDestination_.Dispose();
				UserMusicKey_.Dispose();
				ArrangementName_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				DocumentPath_.OnDiff(path, diff);
				Arrangement_.OnDiff(path, diff);
				ContentDestination_.OnDiff(path, diff);
				UserMusicKey_.OnDiff(path, diff);
				ArrangementName_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IItemType : IEntity, IDisposable
		{
			public interface IHeader : IItemType, IEntity, IDisposable, IObservableProperty<Types.IHeader>
			{
			}

			public interface IPresentation : IItemType, IEntity, IDisposable, IObservableProperty<Types.IPresentation>
			{
			}

			public interface ICue : IItemType, IEntity, IDisposable, IObservableProperty<Pro.Entity.ICue>
			{
			}

			public interface IPlanningCenter : IItemType, IEntity, IDisposable, IObservableProperty<Types.IPlanningCenter>
			{
			}

			public interface IPlaceholder : IItemType, IEntity, IDisposable, IObservableProperty<Types.IPlaceholder>
			{
			}

			internal class Header : IHeader, IItemType, IEntity, IDisposable, IObservableProperty<Types.IHeader>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<Types.IHeader> _Header_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Header_.WhenChangeHappens;

				public IObservable<Types.IHeader> WhenValueChanges => _Header_.WhenValueChanges;

				public Types.IHeader Value => _Header_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Header_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Header_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "header__3".ToLoroValueLike());
					return loroMap;
				}

				public Header()
					: this(InitializeMap())
				{
				}

				public Header(LoroMap values)
				{
					_map = values;
					_Header_ = new ComplexObservableProperty<Types.IHeader>("header__3", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Header_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Header_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Header_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(Types.IHeader value)
				{
					_Header_.Set(value);
				}
			}

			internal class Presentation : IPresentation, IItemType, IEntity, IDisposable, IObservableProperty<Types.IPresentation>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<Types.IPresentation> _Presentation_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Presentation_.WhenChangeHappens;

				public IObservable<Types.IPresentation> WhenValueChanges => _Presentation_.WhenValueChanges;

				public Types.IPresentation Value => _Presentation_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Presentation_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Presentation_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "presentation__4".ToLoroValueLike());
					return loroMap;
				}

				public Presentation()
					: this(InitializeMap())
				{
				}

				public Presentation(LoroMap values)
				{
					_map = values;
					_Presentation_ = new ComplexObservableProperty<Types.IPresentation>("presentation__4", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Presentation_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Presentation_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Presentation_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(Types.IPresentation value)
				{
					_Presentation_.Set(value);
				}
			}

			internal class Cue : ICue, IItemType, IEntity, IDisposable, IObservableProperty<Pro.Entity.ICue>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<Pro.Entity.ICue> _Cue_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Cue_.WhenChangeHappens;

				public IObservable<Pro.Entity.ICue> WhenValueChanges => _Cue_.WhenValueChanges;

				public Pro.Entity.ICue Value => _Cue_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Cue_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Cue_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "cue__5".ToLoroValueLike());
					return loroMap;
				}

				public Cue()
					: this(InitializeMap())
				{
				}

				public Cue(LoroMap values)
				{
					_map = values;
					_Cue_ = new ComplexObservableProperty<Pro.Entity.ICue>("cue__5", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Cue_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Cue_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Cue_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(Pro.Entity.ICue value)
				{
					_Cue_.Set(value);
				}
			}

			internal class PlanningCenter : IPlanningCenter, IItemType, IEntity, IDisposable, IObservableProperty<Types.IPlanningCenter>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<Types.IPlanningCenter> _PlanningCenter_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _PlanningCenter_.WhenChangeHappens;

				public IObservable<Types.IPlanningCenter> WhenValueChanges => _PlanningCenter_.WhenValueChanges;

				public Types.IPlanningCenter Value => _PlanningCenter_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_PlanningCenter_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_PlanningCenter_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "planning_center__6".ToLoroValueLike());
					return loroMap;
				}

				public PlanningCenter()
					: this(InitializeMap())
				{
				}

				public PlanningCenter(LoroMap values)
				{
					_map = values;
					_PlanningCenter_ = new ComplexObservableProperty<Types.IPlanningCenter>("planning_center__6", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_PlanningCenter_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_PlanningCenter_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_PlanningCenter_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(Types.IPlanningCenter value)
				{
					_PlanningCenter_.Set(value);
				}
			}

			internal class Placeholder : IPlaceholder, IItemType, IEntity, IDisposable, IObservableProperty<Types.IPlaceholder>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<Types.IPlaceholder> _Placeholder_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Placeholder_.WhenChangeHappens;

				public IObservable<Types.IPlaceholder> WhenValueChanges => _Placeholder_.WhenValueChanges;

				public Types.IPlaceholder Value => _Placeholder_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Placeholder_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Placeholder_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "placeholder__8".ToLoroValueLike());
					return loroMap;
				}

				public Placeholder()
					: this(InitializeMap())
				{
				}

				public Placeholder(LoroMap values)
				{
					_map = values;
					_Placeholder_ = new ComplexObservableProperty<Types.IPlaceholder>("placeholder__8", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Placeholder_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Placeholder_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Placeholder_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(Types.IPlaceholder value)
				{
					_Placeholder_.Set(value);
				}
			}
		}

		internal class ItemTypeFactory : IUnionValueFactory<IItemType>
		{
			public string SelectionKey => "__tag";

			public IItemType? CreateInstance(LoroMap map)
			{
				return map.Get("__tag").ToStringValue() switch
				{
					"header__3" => new IItemType.Header(map), 
					"presentation__4" => new IItemType.Presentation(map), 
					"cue__5" => new IItemType.Cue(map), 
					"planning_center__6" => new IItemType.PlanningCenter(map), 
					"placeholder__8" => new IItemType.Placeholder(map), 
					_ => null, 
				};
			}

			public IItemType CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "header__3".ToLoroValueLike());
				return new IItemType.Header(map);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> Name { get; }

	ICollection<Guid> Tags { get; }

	IObservableProperty<bool> IsHidden { get; }

	IComplexObservableProperty<Types.IItemType> ItemType { get; }
}
