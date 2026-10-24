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

public interface IPresentation : IEntity, IDisposable
{
	public class Types
	{
		public interface IArrangement : IEntity, IDisposable
		{
			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string?> Name { get; }

			ICollection<Guid> GroupIdentifiers { get; }
		}

		internal sealed class Arrangement : IArrangement, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private OptionalStringObservableProperty Name_;

			private GuidCollection GroupIdentifiers_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string?> Name => Name_;

			public ICollection<Guid> GroupIdentifiers => GroupIdentifiers_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				GroupIdentifiers_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				GroupIdentifiers_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Arrangement()
				: this(new LoroMap())
			{
			}

			public Arrangement(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new OptionalStringObservableProperty("name__2", LoroMap);
				GroupIdentifiers_ = new GuidCollection(LoroMap, "group_identifiers__3");
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, GroupIdentifiers_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				GroupIdentifiers_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				GroupIdentifiers_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IBibleReference : IEntity, IDisposable
		{
			IObservableProperty<uint> BookIndex { get; }

			IObservableProperty<string?> BookName { get; }

			IObservableProperty<IntRange> ChapterRange { get; }

			IObservableProperty<IntRange> VerseRange { get; }

			IObservableProperty<string?> TranslationName { get; }

			IObservableProperty<string?> TranslationInternalAbbreviation { get; }
		}

		internal sealed class BibleReference : IBibleReference, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private UintObservableProperty BookIndex_;

			private OptionalStringObservableProperty BookName_;

			private AtomicObservableProperty<IntRange> ChapterRange_;

			private AtomicObservableProperty<IntRange> VerseRange_;

			private OptionalStringObservableProperty TranslationName_;

			private OptionalStringObservableProperty TranslationInternalAbbreviation_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<uint> BookIndex => BookIndex_;

			public IObservableProperty<string?> BookName => BookName_;

			public IObservableProperty<IntRange> ChapterRange => ChapterRange_;

			public IObservableProperty<IntRange> VerseRange => VerseRange_;

			public IObservableProperty<string?> TranslationName => TranslationName_;

			public IObservableProperty<string?> TranslationInternalAbbreviation => TranslationInternalAbbreviation_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				BookIndex_.UpdateMap(_map);
				BookName_.UpdateMap(_map);
				ChapterRange_.UpdateMap(_map);
				VerseRange_.UpdateMap(_map);
				TranslationName_.UpdateMap(_map);
				TranslationInternalAbbreviation_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				BookIndex_.UpdateMapOnInternalMapUpdate(_map);
				BookName_.UpdateMapOnInternalMapUpdate(_map);
				ChapterRange_.UpdateMapOnInternalMapUpdate(_map);
				VerseRange_.UpdateMapOnInternalMapUpdate(_map);
				TranslationName_.UpdateMapOnInternalMapUpdate(_map);
				TranslationInternalAbbreviation_.UpdateMapOnInternalMapUpdate(_map);
			}

			public BibleReference()
				: this(new LoroMap())
			{
			}

			public BibleReference(LoroMap values)
			{
				_map = values;
				BookIndex_ = new UintObservableProperty("book_index__1", LoroMap);
				BookName_ = new OptionalStringObservableProperty("book_name__2", LoroMap);
				ChapterRange_ = new AtomicObservableProperty<IntRange>("chapter_range__3", LoroMap, IntRangeExtension.Deserialize, IntRangeExtension.Serialize);
				VerseRange_ = new AtomicObservableProperty<IntRange>("verse_range__4", LoroMap, IntRangeExtension.Deserialize, IntRangeExtension.Serialize);
				TranslationName_ = new OptionalStringObservableProperty("translation_name__5", LoroMap);
				TranslationInternalAbbreviation_ = new OptionalStringObservableProperty("translation_internal_abbreviation__7", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(BookIndex_.WhenChangeHappens, BookName_.WhenChangeHappens, ChapterRange_.WhenChangeHappens, VerseRange_.WhenChangeHappens, TranslationName_.WhenChangeHappens, TranslationInternalAbbreviation_.WhenChangeHappens);
			}

			public void Dispose()
			{
				BookIndex_.Dispose();
				BookName_.Dispose();
				ChapterRange_.Dispose();
				VerseRange_.Dispose();
				TranslationName_.Dispose();
				TranslationInternalAbbreviation_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				BookIndex_.OnDiff(path, diff);
				BookName_.OnDiff(path, diff);
				ChapterRange_.OnDiff(path, diff);
				VerseRange_.OnDiff(path, diff);
				TranslationName_.OnDiff(path, diff);
				TranslationInternalAbbreviation_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ICcli : IEntity, IDisposable
		{
			IObservableProperty<string?> Author { get; }

			IObservableProperty<string?> ArtistCredits { get; }

			IObservableProperty<string?> SongTitle { get; }

			IObservableProperty<string?> Publisher { get; }

			IObservableProperty<uint> CopyrightYear { get; }

			IObservableProperty<uint> SongNumber { get; }

			IObservableProperty<bool> Display { get; }

			IObservableProperty<string?> Album { get; }

			IObservableProperty<byte[]?> Artwork { get; }
		}

		internal sealed class Ccli : ICcli, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalStringObservableProperty Author_;

			private OptionalStringObservableProperty ArtistCredits_;

			private OptionalStringObservableProperty SongTitle_;

			private OptionalStringObservableProperty Publisher_;

			private UintObservableProperty CopyrightYear_;

			private UintObservableProperty SongNumber_;

			private BoolObservableProperty Display_;

			private OptionalStringObservableProperty Album_;

			private OptionalBytesObservableProperty Artwork_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string?> Author => Author_;

			public IObservableProperty<string?> ArtistCredits => ArtistCredits_;

			public IObservableProperty<string?> SongTitle => SongTitle_;

			public IObservableProperty<string?> Publisher => Publisher_;

			public IObservableProperty<uint> CopyrightYear => CopyrightYear_;

			public IObservableProperty<uint> SongNumber => SongNumber_;

			public IObservableProperty<bool> Display => Display_;

			public IObservableProperty<string?> Album => Album_;

			public IObservableProperty<byte[]?> Artwork => Artwork_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Author_.UpdateMap(_map);
				ArtistCredits_.UpdateMap(_map);
				SongTitle_.UpdateMap(_map);
				Publisher_.UpdateMap(_map);
				CopyrightYear_.UpdateMap(_map);
				SongNumber_.UpdateMap(_map);
				Display_.UpdateMap(_map);
				Album_.UpdateMap(_map);
				Artwork_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Author_.UpdateMapOnInternalMapUpdate(_map);
				ArtistCredits_.UpdateMapOnInternalMapUpdate(_map);
				SongTitle_.UpdateMapOnInternalMapUpdate(_map);
				Publisher_.UpdateMapOnInternalMapUpdate(_map);
				CopyrightYear_.UpdateMapOnInternalMapUpdate(_map);
				SongNumber_.UpdateMapOnInternalMapUpdate(_map);
				Display_.UpdateMapOnInternalMapUpdate(_map);
				Album_.UpdateMapOnInternalMapUpdate(_map);
				Artwork_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Ccli()
				: this(new LoroMap())
			{
			}

			public Ccli(LoroMap values)
			{
				_map = values;
				Author_ = new OptionalStringObservableProperty("author__1", LoroMap);
				ArtistCredits_ = new OptionalStringObservableProperty("artist_credits__2", LoroMap);
				SongTitle_ = new OptionalStringObservableProperty("song_title__3", LoroMap);
				Publisher_ = new OptionalStringObservableProperty("publisher__4", LoroMap);
				CopyrightYear_ = new UintObservableProperty("copyright_year__5", LoroMap);
				SongNumber_ = new UintObservableProperty("song_number__6", LoroMap);
				Display_ = new BoolObservableProperty("display__7", LoroMap);
				Album_ = new OptionalStringObservableProperty("album__8", LoroMap);
				Artwork_ = new OptionalBytesObservableProperty("artwork__9", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Author_.WhenChangeHappens, ArtistCredits_.WhenChangeHappens, SongTitle_.WhenChangeHappens, Publisher_.WhenChangeHappens, CopyrightYear_.WhenChangeHappens, SongNumber_.WhenChangeHappens, Display_.WhenChangeHappens, Album_.WhenChangeHappens, Artwork_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Author_.Dispose();
				ArtistCredits_.Dispose();
				SongTitle_.Dispose();
				Publisher_.Dispose();
				CopyrightYear_.Dispose();
				SongNumber_.Dispose();
				Display_.Dispose();
				Album_.Dispose();
				Artwork_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Author_.OnDiff(path, diff);
				ArtistCredits_.OnDiff(path, diff);
				SongTitle_.OnDiff(path, diff);
				Publisher_.OnDiff(path, diff);
				CopyrightYear_.OnDiff(path, diff);
				SongNumber_.OnDiff(path, diff);
				Display_.OnDiff(path, diff);
				Album_.OnDiff(path, diff);
				Artwork_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ICueGroup : IEntity, IDisposable
		{
			IComplexObservableProperty<IGroup> Group { get; }

			ICollection<Guid> CueIdentifiers { get; }
		}

		internal sealed class CueGroup : ICueGroup, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IGroup> Group_;

			private GuidCollection CueIdentifiers_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IGroup> Group => Group_;

			public ICollection<Guid> CueIdentifiers => CueIdentifiers_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Group_.UpdateMap(_map);
				CueIdentifiers_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Group_.UpdateMapOnInternalMapUpdate(_map);
				CueIdentifiers_.UpdateMapOnInternalMapUpdate(_map);
			}

			public CueGroup()
				: this(new LoroMap())
			{
			}

			public CueGroup(LoroMap values)
			{
				_map = values;
				Group_ = new ComplexObservableProperty<IGroup>("group__1", LoroMap, new EntityFactory());
				CueIdentifiers_ = new GuidCollection(LoroMap, "cue_identifiers__2");
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Group_.WhenChangeHappens.Merge(CueIdentifiers_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Group_.Dispose();
				CueIdentifiers_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Group_.OnDiff(path, diff);
				CueIdentifiers_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMultiTracksLicensing : IEntity, IDisposable
		{
			public class Types
			{
				public enum Subscription
				{
					ChartPro,
					SlidePro
				}
			}

			IObservableProperty<long> SongIdentifier { get; }

			IObservableProperty<string> CustomerIdentifier { get; }

			IObservableProperty<Timestamp> ExpirationDate { get; }

			IObservableProperty<Timestamp> LicenseExpiration { get; }

			IObservableProperty<Types.Subscription> Subscription { get; }
		}

		internal sealed class MultiTracksLicensing : IMultiTracksLicensing, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private LongObservableProperty SongIdentifier_;

			private StringObservableProperty CustomerIdentifier_;

			private AtomicObservableProperty<Timestamp> ExpirationDate_;

			private AtomicObservableProperty<Timestamp> LicenseExpiration_;

			private EnumObservableProperty<IMultiTracksLicensing.Types.Subscription> Subscription_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<long> SongIdentifier => SongIdentifier_;

			public IObservableProperty<string> CustomerIdentifier => CustomerIdentifier_;

			public IObservableProperty<Timestamp> ExpirationDate => ExpirationDate_;

			public IObservableProperty<Timestamp> LicenseExpiration => LicenseExpiration_;

			public IObservableProperty<IMultiTracksLicensing.Types.Subscription> Subscription => Subscription_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				SongIdentifier_.UpdateMap(_map);
				CustomerIdentifier_.UpdateMap(_map);
				ExpirationDate_.UpdateMap(_map);
				LicenseExpiration_.UpdateMap(_map);
				Subscription_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				SongIdentifier_.UpdateMapOnInternalMapUpdate(_map);
				CustomerIdentifier_.UpdateMapOnInternalMapUpdate(_map);
				ExpirationDate_.UpdateMapOnInternalMapUpdate(_map);
				LicenseExpiration_.UpdateMapOnInternalMapUpdate(_map);
				Subscription_.UpdateMapOnInternalMapUpdate(_map);
			}

			public MultiTracksLicensing()
				: this(new LoroMap())
			{
			}

			public MultiTracksLicensing(LoroMap values)
			{
				_map = values;
				SongIdentifier_ = new LongObservableProperty("song_identifier__1", LoroMap);
				CustomerIdentifier_ = new StringObservableProperty("customer_identifier__2", LoroMap);
				ExpirationDate_ = new AtomicObservableProperty<Timestamp>("expiration_date__3", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
				LicenseExpiration_ = new AtomicObservableProperty<Timestamp>("license_expiration__4", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
				Subscription_ = new EnumObservableProperty<IMultiTracksLicensing.Types.Subscription>("subscription__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(SongIdentifier_.WhenChangeHappens, CustomerIdentifier_.WhenChangeHappens, ExpirationDate_.WhenChangeHappens, LicenseExpiration_.WhenChangeHappens, Subscription_.WhenChangeHappens);
			}

			public void Dispose()
			{
				SongIdentifier_.Dispose();
				CustomerIdentifier_.Dispose();
				ExpirationDate_.Dispose();
				LicenseExpiration_.Dispose();
				Subscription_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				SongIdentifier_.OnDiff(path, diff);
				CustomerIdentifier_.OnDiff(path, diff);
				ExpirationDate_.OnDiff(path, diff);
				LicenseExpiration_.OnDiff(path, diff);
				Subscription_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMusic : IEntity, IDisposable
		{
			IObservableProperty<string> OriginalMusicKey { get; }

			IObservableProperty<string> UserMusicKey { get; }

			IComplexObservableProperty<IMusicKeyScale> Original { get; }

			IComplexObservableProperty<IMusicKeyScale> User { get; }
		}

		internal sealed class Music : IMusic, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty OriginalMusicKey_;

			private StringObservableProperty UserMusicKey_;

			private ComplexObservableProperty<IMusicKeyScale> Original_;

			private ComplexObservableProperty<IMusicKeyScale> User_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> OriginalMusicKey => OriginalMusicKey_;

			public IObservableProperty<string> UserMusicKey => UserMusicKey_;

			public IComplexObservableProperty<IMusicKeyScale> Original => Original_;

			public IComplexObservableProperty<IMusicKeyScale> User => User_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				OriginalMusicKey_.UpdateMap(_map);
				UserMusicKey_.UpdateMap(_map);
				Original_.UpdateMap(_map);
				User_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				OriginalMusicKey_.UpdateMapOnInternalMapUpdate(_map);
				UserMusicKey_.UpdateMapOnInternalMapUpdate(_map);
				Original_.UpdateMapOnInternalMapUpdate(_map);
				User_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Music()
				: this(new LoroMap())
			{
			}

			public Music(LoroMap values)
			{
				_map = values;
				OriginalMusicKey_ = new StringObservableProperty("original_music_key__1", LoroMap);
				UserMusicKey_ = new StringObservableProperty("user_music_key__2", LoroMap);
				Original_ = new ComplexObservableProperty<IMusicKeyScale>("original__3", LoroMap, new EntityFactory());
				User_ = new ComplexObservableProperty<IMusicKeyScale>("user__4", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(OriginalMusicKey_.WhenChangeHappens, UserMusicKey_.WhenChangeHappens, Original_.WhenChangeHappens, User_.WhenChangeHappens);
			}

			public void Dispose()
			{
				OriginalMusicKey_.Dispose();
				UserMusicKey_.Dispose();
				Original_.Dispose();
				User_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				OriginalMusicKey_.OnDiff(path, diff);
				UserMusicKey_.OnDiff(path, diff);
				Original_.OnDiff(path, diff);
				User_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ITimeline : IEntity, IDisposable
		{
			public class Types
			{
				public interface ICue : IEntity, IDisposable
				{
					public class Types
					{
						public interface ITriggerInfo : IEntity, IDisposable
						{
							public interface ICueId : ITriggerInfo, IEntity, IDisposable, IObservableProperty<Guid>
							{
							}

							public interface IAction : ITriggerInfo, IEntity, IDisposable, IObservableProperty<Pro.Entity.IAction>
							{
							}

							internal class CueId : ICueId, ITriggerInfo, IEntity, IDisposable, IObservableProperty<Guid>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private CompositeDisposable _linkedDisposables = new CompositeDisposable();

								private GuidObservableProperty _CueId_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _CueId_.WhenChangeHappens;

								public IObservable<Guid> WhenValueChanges => _CueId_.WhenValueChanges;

								public Guid Value => _CueId_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_CueId_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_CueId_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "cue_id__2".ToLoroValueLike());
									return loroMap;
								}

								public CueId()
									: this(InitializeMap())
								{
								}

								public CueId(LoroMap values)
								{
									_map = values;
									_CueId_ = new GuidObservableProperty("cue_id__2", LoroMap);
								}

								public void Dispose()
								{
									_CueId_.Dispose();
									LoroMap.Dispose();
									_linkedDisposables.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_CueId_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_linkedDisposables.Add(disposable);
								}

								public void Set(Guid value)
								{
									_CueId_.Set(value);
								}
							}

							internal class Action : IAction, ITriggerInfo, IEntity, IDisposable, IObservableProperty<Pro.Entity.IAction>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Pro.Entity.IAction> _Action_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _Action_.WhenChangeHappens;

								public IObservable<Pro.Entity.IAction> WhenValueChanges => _Action_.WhenValueChanges;

								public Pro.Entity.IAction Value => _Action_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_Action_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_Action_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "action__4".ToLoroValueLike());
									return loroMap;
								}

								public Action()
									: this(InitializeMap())
								{
								}

								public Action(LoroMap values)
								{
									_map = values;
									_Action_ = new ComplexObservableProperty<Pro.Entity.IAction>("action__4", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_Action_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_Action_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_Action_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Pro.Entity.IAction value)
								{
									_Action_.Set(value);
								}
							}
						}

						internal class TriggerInfoFactory : IUnionValueFactory<ITriggerInfo>
						{
							public string SelectionKey => "__tag";

							public ITriggerInfo? CreateInstance(LoroMap map)
							{
								string text = map.Get("__tag").ToStringValue();
								if (!(text == "cue_id__2"))
								{
									if (text == "action__4")
									{
										return new ITriggerInfo.Action(map);
									}
									return null;
								}
								return new ITriggerInfo.CueId(map);
							}

							public ITriggerInfo CreateDefault(LoroMap map)
							{
								map.Insert("__tag", "cue_id__2".ToLoroValueLike());
								return new ITriggerInfo.CueId(map);
							}
						}
					}

					IObservableProperty<double> TriggerTime { get; }

					IObservableProperty<string> Name { get; }

					IComplexObservableProperty<Types.ITriggerInfo> TriggerInfo { get; }
				}

				internal sealed class Cue : ICue, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private DoubleObservableProperty TriggerTime_;

					private StringObservableProperty Name_;

					private UnionObservableProperty<ICue.Types.ITriggerInfo> TriggerInfo_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<double> TriggerTime => TriggerTime_;

					public IObservableProperty<string> Name => Name_;

					public IComplexObservableProperty<ICue.Types.ITriggerInfo> TriggerInfo => TriggerInfo_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						TriggerTime_.UpdateMap(_map);
						Name_.UpdateMap(_map);
						TriggerInfo_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						TriggerTime_.UpdateMapOnInternalMapUpdate(_map);
						Name_.UpdateMapOnInternalMapUpdate(_map);
						TriggerInfo_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Cue()
						: this(new LoroMap())
					{
					}

					public Cue(LoroMap values)
					{
						_map = values;
						TriggerTime_ = new DoubleObservableProperty("trigger_time__1", LoroMap);
						Name_ = new StringObservableProperty("name__3", LoroMap);
						TriggerInfo_ = new UnionObservableProperty<ICue.Types.ITriggerInfo>("trigger_info__union", LoroMap, new ICue.Types.TriggerInfoFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(TriggerTime_.WhenChangeHappens, Name_.WhenChangeHappens, TriggerInfo_.WhenChangeHappens);
					}

					public void Dispose()
					{
						TriggerTime_.Dispose();
						Name_.Dispose();
						TriggerInfo_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						TriggerTime_.OnDiff(path, diff);
						Name_.OnDiff(path, diff);
						TriggerInfo_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}
			}

			IObservableProperty<double> Duration { get; }

			IObservableProperty<bool> Loop { get; }

			IObservableProperty<bool> TimecodeEnable { get; }

			IObservableProperty<double> TimecodeOffset { get; }

			IComplexCollection<Types.ICue> CuesV2 { get; }
		}

		internal sealed class Timeline : ITimeline, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty Duration_;

			private BoolObservableProperty Loop_;

			private BoolObservableProperty TimecodeEnable_;

			private DoubleObservableProperty TimecodeOffset_;

			private MapCollection<ITimeline.Types.ICue> CuesV2_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> Duration => Duration_;

			public IObservableProperty<bool> Loop => Loop_;

			public IObservableProperty<bool> TimecodeEnable => TimecodeEnable_;

			public IObservableProperty<double> TimecodeOffset => TimecodeOffset_;

			public IComplexCollection<ITimeline.Types.ICue> CuesV2 => CuesV2_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Duration_.UpdateMap(_map);
				Loop_.UpdateMap(_map);
				TimecodeEnable_.UpdateMap(_map);
				TimecodeOffset_.UpdateMap(_map);
				CuesV2_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Duration_.UpdateMapOnInternalMapUpdate(_map);
				Loop_.UpdateMapOnInternalMapUpdate(_map);
				TimecodeEnable_.UpdateMapOnInternalMapUpdate(_map);
				TimecodeOffset_.UpdateMapOnInternalMapUpdate(_map);
				CuesV2_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Timeline()
				: this(new LoroMap())
			{
			}

			public Timeline(LoroMap values)
			{
				_map = values;
				Duration_ = new DoubleObservableProperty("duration__5", LoroMap);
				Loop_ = new BoolObservableProperty("loop__6", LoroMap);
				TimecodeEnable_ = new BoolObservableProperty("timecode_enable__9", LoroMap);
				TimecodeOffset_ = new DoubleObservableProperty("timecode_offset__10", LoroMap);
				CuesV2_ = new MapCollection<ITimeline.Types.ICue>(LoroMap, "cues_v2__11", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Duration_.WhenChangeHappens, Loop_.WhenChangeHappens, TimecodeEnable_.WhenChangeHappens, TimecodeOffset_.WhenChangeHappens, CuesV2_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Duration_.Dispose();
				Loop_.Dispose();
				TimecodeEnable_.Dispose();
				TimecodeOffset_.Dispose();
				CuesV2_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Duration_.OnDiff(path, diff);
				Loop_.OnDiff(path, diff);
				TimecodeEnable_.OnDiff(path, diff);
				TimecodeOffset_.OnDiff(path, diff);
				CuesV2_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISlideShow : IEntity, IDisposable
		{
			public interface ISlideShowDuration : ISlideShow, IEntity, IDisposable, IObservableProperty<double>
			{
			}

			internal class SlideShowDuration : ISlideShowDuration, ISlideShow, IEntity, IDisposable, IObservableProperty<double>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private CompositeDisposable _linkedDisposables = new CompositeDisposable();

				private DoubleObservableProperty _SlideShowDuration_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _SlideShowDuration_.WhenChangeHappens;

				public IObservable<double> WhenValueChanges => _SlideShowDuration_.WhenValueChanges;

				public double Value => _SlideShowDuration_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_SlideShowDuration_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_SlideShowDuration_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "slide_show_duration__20".ToLoroValueLike());
					return loroMap;
				}

				public SlideShowDuration()
					: this(InitializeMap())
				{
				}

				public SlideShowDuration(LoroMap values)
				{
					_map = values;
					_SlideShowDuration_ = new DoubleObservableProperty("slide_show_duration__20", LoroMap);
				}

				public void Dispose()
				{
					_SlideShowDuration_.Dispose();
					LoroMap.Dispose();
					_linkedDisposables.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_SlideShowDuration_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_linkedDisposables.Add(disposable);
				}

				public void Set(double value)
				{
					_SlideShowDuration_.Set(value);
				}
			}
		}

		internal class SlideShowFactory : IUnionValueFactory<ISlideShow>
		{
			public string SelectionKey => "__tag";

			public ISlideShow? CreateInstance(LoroMap map)
			{
				if (map.Get("__tag").ToStringValue() == "slide_show_duration__20")
				{
					return new ISlideShow.SlideShowDuration(map);
				}
				return null;
			}

			public ISlideShow CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "slide_show_duration__20".ToLoroValueLike());
				return new ISlideShow.SlideShowDuration(map);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> Name { get; }

	IObservableProperty<string> Notes { get; }

	IComplexObservableProperty<IBackground?> Background { get; }

	IObservableProperty<Url?> ChordChart { get; }

	IObservableProperty<Guid?> SelectedArrangement { get; }

	IComplexCollection<Types.IArrangement> Arrangements { get; }

	IComplexCollection<Types.ICueGroup> CueGroups { get; }

	IKeyedCollection<Guid, ICue> Cues { get; }

	IComplexObservableProperty<Types.ICcli> Ccli { get; }

	IComplexObservableProperty<Types.IBibleReference?> BibleReference { get; }

	IComplexObservableProperty<Types.ITimeline> Timeline { get; }

	IComplexObservableProperty<ITransition?> Transition { get; }

	IObservableProperty<IAction.Types.ContentDestination> ContentDestination { get; }

	IComplexObservableProperty<Types.IMultiTracksLicensing?> MultiTracksLicensing { get; }

	IObservableProperty<string> MusicKey { get; }

	IComplexObservableProperty<Types.IMusic?> Music { get; }

	IComplexObservableProperty<Types.ISlideShow?> SlideShow { get; }
}
