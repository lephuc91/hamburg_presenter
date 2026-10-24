using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IPlanningCenterPlan : IEntity, IDisposable
{
	public class Types
	{
		public interface IPlanItem : IEntity, IDisposable
		{
			public class Types
			{
				public interface IAttachment : IEntity, IDisposable
				{
					IObservableProperty<string> Name { get; }

					IObservableProperty<Url?> Url { get; }

					IObservableProperty<Timestamp> CreatedDate { get; }

					IObservableProperty<Url?> LinkedPath { get; }

					IObservableProperty<uint> PcoIdNum { get; }

					IObservableProperty<bool> NeedsUpdate { get; }

					IObservableProperty<Timestamp> UpdateDate { get; }

					IObservableProperty<string> PcoIdStr { get; }
				}

				internal sealed class Attachment : IAttachment, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private StringObservableProperty Name_;

					private OptionalAtomicObservableProperty<Url> Url_;

					private AtomicObservableProperty<Timestamp> CreatedDate_;

					private OptionalAtomicObservableProperty<Url> LinkedPath_;

					private UintObservableProperty PcoIdNum_;

					private BoolObservableProperty NeedsUpdate_;

					private AtomicObservableProperty<Timestamp> UpdateDate_;

					private StringObservableProperty PcoIdStr_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string> Name => Name_;

					public IObservableProperty<Url?> Url => Url_;

					public IObservableProperty<Timestamp> CreatedDate => CreatedDate_;

					public IObservableProperty<Url?> LinkedPath => LinkedPath_;

					public IObservableProperty<uint> PcoIdNum => PcoIdNum_;

					public IObservableProperty<bool> NeedsUpdate => NeedsUpdate_;

					public IObservableProperty<Timestamp> UpdateDate => UpdateDate_;

					public IObservableProperty<string> PcoIdStr => PcoIdStr_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Name_.UpdateMap(_map);
						Url_.UpdateMap(_map);
						CreatedDate_.UpdateMap(_map);
						LinkedPath_.UpdateMap(_map);
						PcoIdNum_.UpdateMap(_map);
						NeedsUpdate_.UpdateMap(_map);
						UpdateDate_.UpdateMap(_map);
						PcoIdStr_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Name_.UpdateMapOnInternalMapUpdate(_map);
						Url_.UpdateMapOnInternalMapUpdate(_map);
						CreatedDate_.UpdateMapOnInternalMapUpdate(_map);
						LinkedPath_.UpdateMapOnInternalMapUpdate(_map);
						PcoIdNum_.UpdateMapOnInternalMapUpdate(_map);
						NeedsUpdate_.UpdateMapOnInternalMapUpdate(_map);
						UpdateDate_.UpdateMapOnInternalMapUpdate(_map);
						PcoIdStr_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Attachment()
						: this(new LoroMap())
					{
					}

					public Attachment(LoroMap values)
					{
						_map = values;
						Name_ = new StringObservableProperty("name__1", LoroMap);
						Url_ = new OptionalAtomicObservableProperty<Url>("url__2", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
						CreatedDate_ = new AtomicObservableProperty<Timestamp>("created_date__3", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
						LinkedPath_ = new OptionalAtomicObservableProperty<Url>("linked_path__4", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
						PcoIdNum_ = new UintObservableProperty("pco_id_num__5", LoroMap);
						NeedsUpdate_ = new BoolObservableProperty("needs_update__6", LoroMap);
						UpdateDate_ = new AtomicObservableProperty<Timestamp>("update_date__7", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
						PcoIdStr_ = new StringObservableProperty("pco_id_str__8", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, Url_.WhenChangeHappens, CreatedDate_.WhenChangeHappens, LinkedPath_.WhenChangeHappens, PcoIdNum_.WhenChangeHappens, NeedsUpdate_.WhenChangeHappens, UpdateDate_.WhenChangeHappens, PcoIdStr_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Name_.Dispose();
						Url_.Dispose();
						CreatedDate_.Dispose();
						LinkedPath_.Dispose();
						PcoIdNum_.Dispose();
						NeedsUpdate_.Dispose();
						UpdateDate_.Dispose();
						PcoIdStr_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Name_.OnDiff(path, diff);
						Url_.OnDiff(path, diff);
						CreatedDate_.OnDiff(path, diff);
						LinkedPath_.OnDiff(path, diff);
						PcoIdNum_.OnDiff(path, diff);
						NeedsUpdate_.OnDiff(path, diff);
						UpdateDate_.OnDiff(path, diff);
						PcoIdStr_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ISongItem : IEntity, IDisposable
				{
					public class Types
					{
						public interface ISequence : IEntity, IDisposable
						{
							IObservableProperty<uint> PcoIdNum { get; }

							IObservableProperty<string> Name { get; }

							ICollection<string> GroupNames { get; }

							IObservableProperty<string> PcoIdStr { get; }
						}

						internal sealed class Sequence : ISequence, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private UintObservableProperty PcoIdNum_;

							private StringObservableProperty Name_;

							private StringCollection GroupNames_;

							private StringObservableProperty PcoIdStr_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<uint> PcoIdNum => PcoIdNum_;

							public IObservableProperty<string> Name => Name_;

							public ICollection<string> GroupNames => GroupNames_;

							public IObservableProperty<string> PcoIdStr => PcoIdStr_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								PcoIdNum_.UpdateMap(_map);
								Name_.UpdateMap(_map);
								GroupNames_.UpdateMap(_map);
								PcoIdStr_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								PcoIdNum_.UpdateMapOnInternalMapUpdate(_map);
								Name_.UpdateMapOnInternalMapUpdate(_map);
								GroupNames_.UpdateMapOnInternalMapUpdate(_map);
								PcoIdStr_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Sequence()
								: this(new LoroMap())
							{
							}

							public Sequence(LoroMap values)
							{
								_map = values;
								PcoIdNum_ = new UintObservableProperty("pco_id_num__1", LoroMap);
								Name_ = new StringObservableProperty("name__2", LoroMap);
								GroupNames_ = new StringCollection(LoroMap, "group_names__3");
								PcoIdStr_ = new StringObservableProperty("pco_id_str__4", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(PcoIdNum_.WhenChangeHappens, Name_.WhenChangeHappens, GroupNames_.WhenChangeHappens, PcoIdStr_.WhenChangeHappens);
							}

							public void Dispose()
							{
								PcoIdNum_.Dispose();
								Name_.Dispose();
								GroupNames_.Dispose();
								PcoIdStr_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								PcoIdNum_.OnDiff(path, diff);
								Name_.OnDiff(path, diff);
								GroupNames_.OnDiff(path, diff);
								PcoIdStr_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}
					}

					IObservableProperty<uint> PcoIdNum { get; }

					IObservableProperty<uint> ArrangementIdNum { get; }

					IComplexObservableProperty<IPresentation.Types.ICcli?> Ccli { get; }

					IComplexObservableProperty<Types.ISequence?> Sequence { get; }

					IObservableProperty<string> PcoIdStr { get; }

					IObservableProperty<string> ArrangementIdStr { get; }
				}

				internal sealed class SongItem : ISongItem, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UintObservableProperty PcoIdNum_;

					private UintObservableProperty ArrangementIdNum_;

					private OptionalComplexObservableProperty<IPresentation.Types.ICcli> Ccli_;

					private OptionalComplexObservableProperty<ISongItem.Types.ISequence> Sequence_;

					private StringObservableProperty PcoIdStr_;

					private StringObservableProperty ArrangementIdStr_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<uint> PcoIdNum => PcoIdNum_;

					public IObservableProperty<uint> ArrangementIdNum => ArrangementIdNum_;

					public IComplexObservableProperty<IPresentation.Types.ICcli?> Ccli => Ccli_;

					public IComplexObservableProperty<ISongItem.Types.ISequence?> Sequence => Sequence_;

					public IObservableProperty<string> PcoIdStr => PcoIdStr_;

					public IObservableProperty<string> ArrangementIdStr => ArrangementIdStr_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						PcoIdNum_.UpdateMap(_map);
						ArrangementIdNum_.UpdateMap(_map);
						Ccli_.UpdateMap(_map);
						Sequence_.UpdateMap(_map);
						PcoIdStr_.UpdateMap(_map);
						ArrangementIdStr_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						PcoIdNum_.UpdateMapOnInternalMapUpdate(_map);
						ArrangementIdNum_.UpdateMapOnInternalMapUpdate(_map);
						Ccli_.UpdateMapOnInternalMapUpdate(_map);
						Sequence_.UpdateMapOnInternalMapUpdate(_map);
						PcoIdStr_.UpdateMapOnInternalMapUpdate(_map);
						ArrangementIdStr_.UpdateMapOnInternalMapUpdate(_map);
					}

					public SongItem()
						: this(new LoroMap())
					{
					}

					public SongItem(LoroMap values)
					{
						_map = values;
						PcoIdNum_ = new UintObservableProperty("pco_id_num__1", LoroMap);
						ArrangementIdNum_ = new UintObservableProperty("arrangement_id_num__2", LoroMap);
						Ccli_ = new OptionalComplexObservableProperty<IPresentation.Types.ICcli>("ccli__3", LoroMap, new EntityFactory());
						Sequence_ = new OptionalComplexObservableProperty<ISongItem.Types.ISequence>("sequence__4", LoroMap, new EntityFactory());
						PcoIdStr_ = new StringObservableProperty("pco_id_str__5", LoroMap);
						ArrangementIdStr_ = new StringObservableProperty("arrangement_id_str__6", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(PcoIdNum_.WhenChangeHappens, ArrangementIdNum_.WhenChangeHappens, Ccli_.WhenChangeHappens, Sequence_.WhenChangeHappens, PcoIdStr_.WhenChangeHappens, ArrangementIdStr_.WhenChangeHappens);
					}

					public void Dispose()
					{
						PcoIdNum_.Dispose();
						ArrangementIdNum_.Dispose();
						Ccli_.Dispose();
						Sequence_.Dispose();
						PcoIdStr_.Dispose();
						ArrangementIdStr_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						PcoIdNum_.OnDiff(path, diff);
						ArrangementIdNum_.OnDiff(path, diff);
						Ccli_.OnDiff(path, diff);
						Sequence_.OnDiff(path, diff);
						PcoIdStr_.OnDiff(path, diff);
						ArrangementIdStr_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum PlanItemType
				{
					Item,
					Song,
					Media,
					Header
				}
			}

			IObservableProperty<Types.PlanItemType> ItemType { get; }

			IObservableProperty<uint> PcoIdNum { get; }

			IObservableProperty<uint> ServiceIdNum { get; }

			IObservableProperty<uint> ParentIdNum { get; }

			IObservableProperty<string> Name { get; }

			IComplexCollection<Types.IAttachment> Attachments { get; }

			IObservableProperty<Timestamp> UpdateDate { get; }

			IComplexObservableProperty<Types.ISongItem?> LinkedSong { get; }

			IObservableProperty<string> PcoIdStr { get; }

			IObservableProperty<string> ServiceIdStr { get; }

			IObservableProperty<string> ParentIdStr { get; }
		}

		internal sealed class PlanItem : IPlanItem, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IPlanItem.Types.PlanItemType> ItemType_;

			private UintObservableProperty PcoIdNum_;

			private UintObservableProperty ServiceIdNum_;

			private UintObservableProperty ParentIdNum_;

			private StringObservableProperty Name_;

			private MapCollection<IPlanItem.Types.IAttachment> Attachments_;

			private AtomicObservableProperty<Timestamp> UpdateDate_;

			private OptionalComplexObservableProperty<IPlanItem.Types.ISongItem> LinkedSong_;

			private StringObservableProperty PcoIdStr_;

			private StringObservableProperty ServiceIdStr_;

			private StringObservableProperty ParentIdStr_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IPlanItem.Types.PlanItemType> ItemType => ItemType_;

			public IObservableProperty<uint> PcoIdNum => PcoIdNum_;

			public IObservableProperty<uint> ServiceIdNum => ServiceIdNum_;

			public IObservableProperty<uint> ParentIdNum => ParentIdNum_;

			public IObservableProperty<string> Name => Name_;

			public IComplexCollection<IPlanItem.Types.IAttachment> Attachments => Attachments_;

			public IObservableProperty<Timestamp> UpdateDate => UpdateDate_;

			public IComplexObservableProperty<IPlanItem.Types.ISongItem?> LinkedSong => LinkedSong_;

			public IObservableProperty<string> PcoIdStr => PcoIdStr_;

			public IObservableProperty<string> ServiceIdStr => ServiceIdStr_;

			public IObservableProperty<string> ParentIdStr => ParentIdStr_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				ItemType_.UpdateMap(_map);
				PcoIdNum_.UpdateMap(_map);
				ServiceIdNum_.UpdateMap(_map);
				ParentIdNum_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Attachments_.UpdateMap(_map);
				UpdateDate_.UpdateMap(_map);
				LinkedSong_.UpdateMap(_map);
				PcoIdStr_.UpdateMap(_map);
				ServiceIdStr_.UpdateMap(_map);
				ParentIdStr_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				ItemType_.UpdateMapOnInternalMapUpdate(_map);
				PcoIdNum_.UpdateMapOnInternalMapUpdate(_map);
				ServiceIdNum_.UpdateMapOnInternalMapUpdate(_map);
				ParentIdNum_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Attachments_.UpdateMapOnInternalMapUpdate(_map);
				UpdateDate_.UpdateMapOnInternalMapUpdate(_map);
				LinkedSong_.UpdateMapOnInternalMapUpdate(_map);
				PcoIdStr_.UpdateMapOnInternalMapUpdate(_map);
				ServiceIdStr_.UpdateMapOnInternalMapUpdate(_map);
				ParentIdStr_.UpdateMapOnInternalMapUpdate(_map);
			}

			public PlanItem()
				: this(new LoroMap())
			{
			}

			public PlanItem(LoroMap values)
			{
				_map = values;
				ItemType_ = new EnumObservableProperty<IPlanItem.Types.PlanItemType>("item_type__1", LoroMap);
				PcoIdNum_ = new UintObservableProperty("pco_id_num__2", LoroMap);
				ServiceIdNum_ = new UintObservableProperty("service_id_num__3", LoroMap);
				ParentIdNum_ = new UintObservableProperty("parent_id_num__4", LoroMap);
				Name_ = new StringObservableProperty("name__5", LoroMap);
				Attachments_ = new MapCollection<IPlanItem.Types.IAttachment>(LoroMap, "attachments__6", new EntityFactory());
				UpdateDate_ = new AtomicObservableProperty<Timestamp>("update_date__7", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
				LinkedSong_ = new OptionalComplexObservableProperty<IPlanItem.Types.ISongItem>("linked_song__8", LoroMap, new EntityFactory());
				PcoIdStr_ = new StringObservableProperty("pco_id_str__9", LoroMap);
				ServiceIdStr_ = new StringObservableProperty("service_id_str__10", LoroMap);
				ParentIdStr_ = new StringObservableProperty("parent_id_str__11", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(ItemType_.WhenChangeHappens, PcoIdNum_.WhenChangeHappens, ServiceIdNum_.WhenChangeHappens, ParentIdNum_.WhenChangeHappens, Name_.WhenChangeHappens, Attachments_.WhenChangeHappens, UpdateDate_.WhenChangeHappens, LinkedSong_.WhenChangeHappens, PcoIdStr_.WhenChangeHappens, ServiceIdStr_.WhenChangeHappens, ParentIdStr_.WhenChangeHappens);
			}

			public void Dispose()
			{
				ItemType_.Dispose();
				PcoIdNum_.Dispose();
				ServiceIdNum_.Dispose();
				ParentIdNum_.Dispose();
				Name_.Dispose();
				Attachments_.Dispose();
				UpdateDate_.Dispose();
				LinkedSong_.Dispose();
				PcoIdStr_.Dispose();
				ServiceIdStr_.Dispose();
				ParentIdStr_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				ItemType_.OnDiff(path, diff);
				PcoIdNum_.OnDiff(path, diff);
				ServiceIdNum_.OnDiff(path, diff);
				ParentIdNum_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Attachments_.OnDiff(path, diff);
				UpdateDate_.OnDiff(path, diff);
				LinkedSong_.OnDiff(path, diff);
				PcoIdStr_.OnDiff(path, diff);
				ServiceIdStr_.OnDiff(path, diff);
				ParentIdStr_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IObservableProperty<uint> PlanIdNum { get; }

	IObservableProperty<uint> ParentIdNum { get; }

	IObservableProperty<string> SeriesTitle { get; }

	IObservableProperty<string> PlanTitle { get; }

	IObservableProperty<string> DateList { get; }

	IObservableProperty<Timestamp> CreatedDate { get; }

	IObservableProperty<Timestamp> UpdateDate { get; }

	IObservableProperty<Timestamp> LastUpdateCheckDate { get; }

	IObservableProperty<string> PlanIdStr { get; }

	IObservableProperty<string> ParentIdStr { get; }
}
