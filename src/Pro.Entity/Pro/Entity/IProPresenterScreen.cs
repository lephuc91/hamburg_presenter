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

public interface IProPresenterScreen : IEntity, IDisposable
{
	public class Types
	{
		public interface ICombinedArrangement : IEntity, IDisposable
		{
			IComplexCollection<IScreen> Screens { get; }

			IObservableProperty<uint> Rows { get; }

			IObservableProperty<uint> Columns { get; }
		}

		internal sealed class CombinedArrangement : ICombinedArrangement, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<IScreen> Screens_;

			private UintObservableProperty Rows_;

			private UintObservableProperty Columns_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<IScreen> Screens => Screens_;

			public IObservableProperty<uint> Rows => Rows_;

			public IObservableProperty<uint> Columns => Columns_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Screens_.UpdateMap(_map);
				Rows_.UpdateMap(_map);
				Columns_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Screens_.UpdateMapOnInternalMapUpdate(_map);
				Rows_.UpdateMapOnInternalMapUpdate(_map);
				Columns_.UpdateMapOnInternalMapUpdate(_map);
			}

			public CombinedArrangement()
				: this(new LoroMap())
			{
			}

			public CombinedArrangement(LoroMap values)
			{
				_map = values;
				Screens_ = new MapCollection<IScreen>(LoroMap, "screens__1", new EntityFactory());
				Rows_ = new UintObservableProperty("rows__2", LoroMap);
				Columns_ = new UintObservableProperty("columns__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Screens_.WhenChangeHappens, Rows_.WhenChangeHappens, Columns_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Screens_.Dispose();
				Rows_.Dispose();
				Columns_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Screens_.OnDiff(path, diff);
				Rows_.OnDiff(path, diff);
				Columns_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IEdgeBlendArrangement : IEntity, IDisposable
		{
			IObservableProperty<uint> ScreenCount { get; }

			IComplexCollection<IScreen> Screens { get; }

			IComplexCollection<IEdgeBlend> EdgeBlends { get; }
		}

		internal sealed class EdgeBlendArrangement : IEdgeBlendArrangement, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private UintObservableProperty ScreenCount_;

			private MapCollection<IScreen> Screens_;

			private MapCollection<IEdgeBlend> EdgeBlends_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<uint> ScreenCount => ScreenCount_;

			public IComplexCollection<IScreen> Screens => Screens_;

			public IComplexCollection<IEdgeBlend> EdgeBlends => EdgeBlends_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				ScreenCount_.UpdateMap(_map);
				Screens_.UpdateMap(_map);
				EdgeBlends_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				ScreenCount_.UpdateMapOnInternalMapUpdate(_map);
				Screens_.UpdateMapOnInternalMapUpdate(_map);
				EdgeBlends_.UpdateMapOnInternalMapUpdate(_map);
			}

			public EdgeBlendArrangement()
				: this(new LoroMap())
			{
			}

			public EdgeBlendArrangement(LoroMap values)
			{
				_map = values;
				ScreenCount_ = new UintObservableProperty("screen_count__1", LoroMap);
				Screens_ = new MapCollection<IScreen>(LoroMap, "screens__2", new EntityFactory());
				EdgeBlends_ = new MapCollection<IEdgeBlend>(LoroMap, "edge_blends__3", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(ScreenCount_.WhenChangeHappens, Screens_.WhenChangeHappens, EdgeBlends_.WhenChangeHappens);
			}

			public void Dispose()
			{
				ScreenCount_.Dispose();
				Screens_.Dispose();
				EdgeBlends_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				ScreenCount_.OnDiff(path, diff);
				Screens_.OnDiff(path, diff);
				EdgeBlends_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISingleArrangement : IEntity, IDisposable
		{
			IComplexCollection<IScreen> Screens { get; }
		}

		internal sealed class SingleArrangement : ISingleArrangement, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<IScreen> Screens_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<IScreen> Screens => Screens_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Screens_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Screens_.UpdateMapOnInternalMapUpdate(_map);
			}

			public SingleArrangement()
				: this(new LoroMap())
			{
			}

			public SingleArrangement(LoroMap values)
			{
				_map = values;
				Screens_ = new MapCollection<IScreen>(LoroMap, "screens__1", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Screens_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Screens_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Screens_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public enum ScreenType
		{
			Unknown,
			Audience,
			Stage
		}

		public interface IArrangement : IEntity, IDisposable
		{
			public interface IArrangementSingle : IArrangement, IEntity, IDisposable, IObservableProperty<ISingleArrangement>
			{
			}

			public interface IArrangementCombined : IArrangement, IEntity, IDisposable, IObservableProperty<ICombinedArrangement>
			{
			}

			public interface IArrangementEdgeBlend : IArrangement, IEntity, IDisposable, IObservableProperty<IEdgeBlendArrangement>
			{
			}

			internal class ArrangementSingle : IArrangementSingle, IArrangement, IEntity, IDisposable, IObservableProperty<ISingleArrangement>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ISingleArrangement> _ArrangementSingle_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _ArrangementSingle_.WhenChangeHappens;

				public IObservable<ISingleArrangement> WhenValueChanges => _ArrangementSingle_.WhenValueChanges;

				public ISingleArrangement Value => _ArrangementSingle_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_ArrangementSingle_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_ArrangementSingle_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "arrangement_single__3".ToLoroValueLike());
					return loroMap;
				}

				public ArrangementSingle()
					: this(InitializeMap())
				{
				}

				public ArrangementSingle(LoroMap values)
				{
					_map = values;
					_ArrangementSingle_ = new ComplexObservableProperty<ISingleArrangement>("arrangement_single__3", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_ArrangementSingle_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_ArrangementSingle_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_ArrangementSingle_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ISingleArrangement value)
				{
					_ArrangementSingle_.Set(value);
				}
			}

			internal class ArrangementCombined : IArrangementCombined, IArrangement, IEntity, IDisposable, IObservableProperty<ICombinedArrangement>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICombinedArrangement> _ArrangementCombined_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _ArrangementCombined_.WhenChangeHappens;

				public IObservable<ICombinedArrangement> WhenValueChanges => _ArrangementCombined_.WhenValueChanges;

				public ICombinedArrangement Value => _ArrangementCombined_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_ArrangementCombined_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_ArrangementCombined_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "arrangement_combined__4".ToLoroValueLike());
					return loroMap;
				}

				public ArrangementCombined()
					: this(InitializeMap())
				{
				}

				public ArrangementCombined(LoroMap values)
				{
					_map = values;
					_ArrangementCombined_ = new ComplexObservableProperty<ICombinedArrangement>("arrangement_combined__4", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_ArrangementCombined_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_ArrangementCombined_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_ArrangementCombined_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICombinedArrangement value)
				{
					_ArrangementCombined_.Set(value);
				}
			}

			internal class ArrangementEdgeBlend : IArrangementEdgeBlend, IArrangement, IEntity, IDisposable, IObservableProperty<IEdgeBlendArrangement>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IEdgeBlendArrangement> _ArrangementEdgeBlend_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _ArrangementEdgeBlend_.WhenChangeHappens;

				public IObservable<IEdgeBlendArrangement> WhenValueChanges => _ArrangementEdgeBlend_.WhenValueChanges;

				public IEdgeBlendArrangement Value => _ArrangementEdgeBlend_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_ArrangementEdgeBlend_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_ArrangementEdgeBlend_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "arrangement_edge_blend__5".ToLoroValueLike());
					return loroMap;
				}

				public ArrangementEdgeBlend()
					: this(InitializeMap())
				{
				}

				public ArrangementEdgeBlend(LoroMap values)
				{
					_map = values;
					_ArrangementEdgeBlend_ = new ComplexObservableProperty<IEdgeBlendArrangement>("arrangement_edge_blend__5", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_ArrangementEdgeBlend_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_ArrangementEdgeBlend_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_ArrangementEdgeBlend_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IEdgeBlendArrangement value)
				{
					_ArrangementEdgeBlend_.Set(value);
				}
			}
		}

		public interface IRenderingEnabledOptional : IEntity, IDisposable
		{
			public interface IRenderingEnabled : IRenderingEnabledOptional, IEntity, IDisposable, IObservableProperty<bool>
			{
			}

			internal class RenderingEnabled : IRenderingEnabled, IRenderingEnabledOptional, IEntity, IDisposable, IObservableProperty<bool>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private CompositeDisposable _linkedDisposables = new CompositeDisposable();

				private BoolObservableProperty _RenderingEnabled_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _RenderingEnabled_.WhenChangeHappens;

				public IObservable<bool> WhenValueChanges => _RenderingEnabled_.WhenValueChanges;

				public bool Value => _RenderingEnabled_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_RenderingEnabled_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_RenderingEnabled_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "rendering_enabled__9".ToLoroValueLike());
					return loroMap;
				}

				public RenderingEnabled()
					: this(InitializeMap())
				{
				}

				public RenderingEnabled(LoroMap values)
				{
					_map = values;
					_RenderingEnabled_ = new BoolObservableProperty("rendering_enabled__9", LoroMap);
				}

				public void Dispose()
				{
					_RenderingEnabled_.Dispose();
					LoroMap.Dispose();
					_linkedDisposables.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_RenderingEnabled_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_linkedDisposables.Add(disposable);
				}

				public void Set(bool value)
				{
					_RenderingEnabled_.Set(value);
				}
			}
		}

		internal class ArrangementFactory : IUnionValueFactory<IArrangement>
		{
			public string SelectionKey => "__tag";

			public IArrangement? CreateInstance(LoroMap map)
			{
				return map.Get("__tag").ToStringValue() switch
				{
					"arrangement_single__3" => new IArrangement.ArrangementSingle(map), 
					"arrangement_combined__4" => new IArrangement.ArrangementCombined(map), 
					"arrangement_edge_blend__5" => new IArrangement.ArrangementEdgeBlend(map), 
					_ => null, 
				};
			}

			public IArrangement CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "arrangement_single__3".ToLoroValueLike());
				return new IArrangement.ArrangementSingle(map);
			}
		}

		internal class RenderingEnabledOptionalFactory : IUnionValueFactory<IRenderingEnabledOptional>
		{
			public string SelectionKey => "__tag";

			public IRenderingEnabledOptional? CreateInstance(LoroMap map)
			{
				if (map.Get("__tag").ToStringValue() == "rendering_enabled__9")
				{
					return new IRenderingEnabledOptional.RenderingEnabled(map);
				}
				return null;
			}

			public IRenderingEnabledOptional CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "rendering_enabled__9".ToLoroValueLike());
				return new IRenderingEnabledOptional.RenderingEnabled(map);
			}
		}
	}

	IObservableProperty<string> Name { get; }

	IObservableProperty<Types.ScreenType> ScreenType { get; }

	IObservableProperty<Color> BackgroundColor { get; }

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<bool> BackgroundColorEnabled { get; }

	IComplexObservableProperty<Types.IArrangement> Arrangement { get; }

	IComplexObservableProperty<Types.IRenderingEnabledOptional> RenderingEnabledOptional { get; }
}
