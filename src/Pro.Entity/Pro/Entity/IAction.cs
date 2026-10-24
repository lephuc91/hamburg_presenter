using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IAction : IEntity, IDisposable
{
	public class Types
	{
		public interface IAudienceLookType : IEntity, IDisposable
		{
			IComplexObservableProperty<ICollectionElementType> Identification { get; }
		}

		internal sealed class AudienceLookType : IAudienceLookType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> Identification_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> Identification => Identification_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMapOnInternalMapUpdate(_map);
			}

			public AudienceLookType()
				: this(new LoroMap())
			{
			}

			public AudienceLookType(LoroMap values)
			{
				_map = values;
				Identification_ = new ComplexObservableProperty<ICollectionElementType>("identification__1", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Identification_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Identification_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Identification_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IAudioInputType : IEntity, IDisposable
		{
			IObservableProperty<int> Index { get; }

			IObservableProperty<bool> OverrideMode { get; }

			IComplexObservableProperty<IAudioInput.Types.IBehaviorMode> BehaviorMode { get; }

			IObservableProperty<bool> OverrideVolume { get; }

			IObservableProperty<double> Volume { get; }
		}

		internal sealed class AudioInputType : IAudioInputType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private IntObservableProperty Index_;

			private BoolObservableProperty OverrideMode_;

			private ComplexObservableProperty<IAudioInput.Types.IBehaviorMode> BehaviorMode_;

			private BoolObservableProperty OverrideVolume_;

			private DoubleObservableProperty Volume_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<int> Index => Index_;

			public IObservableProperty<bool> OverrideMode => OverrideMode_;

			public IComplexObservableProperty<IAudioInput.Types.IBehaviorMode> BehaviorMode => BehaviorMode_;

			public IObservableProperty<bool> OverrideVolume => OverrideVolume_;

			public IObservableProperty<double> Volume => Volume_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Index_.UpdateMap(_map);
				OverrideMode_.UpdateMap(_map);
				BehaviorMode_.UpdateMap(_map);
				OverrideVolume_.UpdateMap(_map);
				Volume_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Index_.UpdateMapOnInternalMapUpdate(_map);
				OverrideMode_.UpdateMapOnInternalMapUpdate(_map);
				BehaviorMode_.UpdateMapOnInternalMapUpdate(_map);
				OverrideVolume_.UpdateMapOnInternalMapUpdate(_map);
				Volume_.UpdateMapOnInternalMapUpdate(_map);
			}

			public AudioInputType()
				: this(new LoroMap())
			{
			}

			public AudioInputType(LoroMap values)
			{
				_map = values;
				Index_ = new IntObservableProperty("index__1", LoroMap);
				OverrideMode_ = new BoolObservableProperty("override_mode__2", LoroMap);
				BehaviorMode_ = new ComplexObservableProperty<IAudioInput.Types.IBehaviorMode>("behavior_mode__3", LoroMap, new EntityFactory());
				OverrideVolume_ = new BoolObservableProperty("override_volume__4", LoroMap);
				Volume_ = new DoubleObservableProperty("volume__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Index_.WhenChangeHappens, OverrideMode_.WhenChangeHappens, BehaviorMode_.WhenChangeHappens, OverrideVolume_.WhenChangeHappens, Volume_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Index_.Dispose();
				OverrideMode_.Dispose();
				BehaviorMode_.Dispose();
				OverrideVolume_.Dispose();
				Volume_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Index_.OnDiff(path, diff);
				OverrideMode_.OnDiff(path, diff);
				BehaviorMode_.OnDiff(path, diff);
				OverrideVolume_.OnDiff(path, diff);
				Volume_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ICaptureType : IEntity, IDisposable
		{
			public class Types
			{
				public interface ICaptureStart : IEntity, IDisposable
				{
					IComplexObservableProperty<ICollectionElementType?> PresetIdentification { get; }
				}

				internal sealed class CaptureStart : ICaptureStart, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private OptionalComplexObservableProperty<ICollectionElementType> PresetIdentification_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<ICollectionElementType?> PresetIdentification => PresetIdentification_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						PresetIdentification_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						PresetIdentification_.UpdateMapOnInternalMapUpdate(_map);
					}

					public CaptureStart()
						: this(new LoroMap())
					{
					}

					public CaptureStart(LoroMap values)
					{
						_map = values;
						PresetIdentification_ = new OptionalComplexObservableProperty<ICollectionElementType>("preset_identification__1", LoroMap, new EntityFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(PresetIdentification_.WhenChangeHappens);
					}

					public void Dispose()
					{
						PresetIdentification_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						PresetIdentification_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ICaptureStop : IEntity, IDisposable
				{
					IObservableProperty<bool> ShowsAlertBeforeStopping { get; }
				}

				internal sealed class CaptureStop : ICaptureStop, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private BoolObservableProperty ShowsAlertBeforeStopping_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<bool> ShowsAlertBeforeStopping => ShowsAlertBeforeStopping_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						ShowsAlertBeforeStopping_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						ShowsAlertBeforeStopping_.UpdateMapOnInternalMapUpdate(_map);
					}

					public CaptureStop()
						: this(new LoroMap())
					{
					}

					public CaptureStop(LoroMap values)
					{
						_map = values;
						ShowsAlertBeforeStopping_ = new BoolObservableProperty("shows_alert_before_stopping__1", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(ShowsAlertBeforeStopping_.WhenChangeHappens);
					}

					public void Dispose()
					{
						ShowsAlertBeforeStopping_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						ShowsAlertBeforeStopping_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ICaptureAction : IEntity, IDisposable
				{
					public interface IStart : ICaptureAction, IEntity, IDisposable, IObservableProperty<ICaptureStart>
					{
					}

					public interface IStop : ICaptureAction, IEntity, IDisposable, IObservableProperty<ICaptureStop>
					{
					}

					internal class Start : IStart, ICaptureAction, IEntity, IDisposable, IObservableProperty<ICaptureStart>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ICaptureStart> _Start_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Start_.WhenChangeHappens;

						public IObservable<ICaptureStart> WhenValueChanges => _Start_.WhenValueChanges;

						public ICaptureStart Value => _Start_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Start_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Start_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "start__1".ToLoroValueLike());
							return loroMap;
						}

						public Start()
							: this(InitializeMap())
						{
						}

						public Start(LoroMap values)
						{
							_map = values;
							_Start_ = new ComplexObservableProperty<ICaptureStart>("start__1", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Start_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Start_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Start_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ICaptureStart value)
						{
							_Start_.Set(value);
						}
					}

					internal class Stop : IStop, ICaptureAction, IEntity, IDisposable, IObservableProperty<ICaptureStop>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ICaptureStop> _Stop_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Stop_.WhenChangeHappens;

						public IObservable<ICaptureStop> WhenValueChanges => _Stop_.WhenValueChanges;

						public ICaptureStop Value => _Stop_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Stop_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Stop_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "stop__2".ToLoroValueLike());
							return loroMap;
						}

						public Stop()
							: this(InitializeMap())
						{
						}

						public Stop(LoroMap values)
						{
							_map = values;
							_Stop_ = new ComplexObservableProperty<ICaptureStop>("stop__2", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Stop_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Stop_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Stop_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ICaptureStop value)
						{
							_Stop_.Set(value);
						}
					}
				}

				internal class CaptureActionFactory : IUnionValueFactory<ICaptureAction>
				{
					public string SelectionKey => "__tag";

					public ICaptureAction? CreateInstance(LoroMap map)
					{
						string text = map.Get("__tag").ToStringValue();
						if (!(text == "start__1"))
						{
							if (text == "stop__2")
							{
								return new ICaptureAction.Stop(map);
							}
							return null;
						}
						return new ICaptureAction.Start(map);
					}

					public ICaptureAction CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "start__1".ToLoroValueLike());
						return new ICaptureAction.Start(map);
					}
				}
			}

			IComplexObservableProperty<Types.ICaptureAction> CaptureAction { get; }
		}

		internal sealed class CaptureType : ICaptureType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private UnionObservableProperty<ICaptureType.Types.ICaptureAction> CaptureAction_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICaptureType.Types.ICaptureAction> CaptureAction => CaptureAction_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				CaptureAction_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				CaptureAction_.UpdateMapOnInternalMapUpdate(_map);
			}

			public CaptureType()
				: this(new LoroMap())
			{
			}

			public CaptureType(LoroMap values)
			{
				_map = values;
				CaptureAction_ = new UnionObservableProperty<ICaptureType.Types.ICaptureAction>("CaptureAction__union", LoroMap, new ICaptureType.Types.CaptureActionFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(CaptureAction_.WhenChangeHappens);
			}

			public void Dispose()
			{
				CaptureAction_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				CaptureAction_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IClearGroupType : IEntity, IDisposable
		{
			IComplexObservableProperty<ICollectionElementType> Identification { get; }
		}

		internal sealed class ClearGroupType : IClearGroupType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> Identification_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> Identification => Identification_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ClearGroupType()
				: this(new LoroMap())
			{
			}

			public ClearGroupType(LoroMap values)
			{
				_map = values;
				Identification_ = new ComplexObservableProperty<ICollectionElementType>("identification__1", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Identification_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Identification_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Identification_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public record ClearType(Types.ClearTargetLayer TargetLayer, ContentDestination ContentDestination)
		{
			public class Types
			{
				public enum ClearTargetLayer
				{
					All,
					Audio,
					Background,
					LiveVideo,
					Prop,
					Slide,
					Logo,
					Messages,
					AudioEffects
				}
			}

			public virtual bool Equals(ClearType? other)
			{
				if ((object)other != null && TargetLayer == other.TargetLayer)
				{
					return ContentDestination == other.ContentDestination;
				}
				return false;
			}

			public override int GetHashCode()
			{
				HashCode hashCode = default(HashCode);
				hashCode.Add(TargetLayer);
				hashCode.Add(ContentDestination);
				return hashCode.ToHashCode();
			}
		}

		internal static class ClearTypeExtension
		{
			internal static ClearType Deserialize(Dictionary<string, LoroValue> map)
			{
				return new ClearType(map.GetEnum<ClearType.Types.ClearTargetLayer>("target_layer__2"), map.GetEnum<ContentDestination>("content_destination__4"));
			}

			internal static ClearType CreateDefault()
			{
				return new ClearType(ClearType.Types.ClearTargetLayer.All, ContentDestination.Global);
			}

			public static LoroValue Serialize(ClearType instance)
			{
				LoroMap loroMap = new LoroMap();
				loroMap.Insert("target_layer__2", instance.TargetLayer.ToLoroValueLike());
				loroMap.Insert("content_destination__4", instance.ContentDestination.ToLoroValueLike());
				return loroMap.GetDeepValue();
			}
		}

		public interface ICommunicationType : IEntity, IDisposable
		{
			public class Types
			{
				public interface ICommand : IEntity, IDisposable
				{
					IObservableProperty<string> Name { get; }

					IObservableProperty<string> Value { get; }

					IObservableProperty<IntRange> ReplacementRange { get; }

					Pro.Entity.Collections.ICollection<string> PossibleValues { get; }
				}

				internal sealed class Command : ICommand, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private StringObservableProperty Name_;

					private StringObservableProperty Value_;

					private AtomicObservableProperty<IntRange> ReplacementRange_;

					private StringCollection PossibleValues_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string> Name => Name_;

					public IObservableProperty<string> Value => Value_;

					public IObservableProperty<IntRange> ReplacementRange => ReplacementRange_;

					public Pro.Entity.Collections.ICollection<string> PossibleValues => PossibleValues_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Name_.UpdateMap(_map);
						Value_.UpdateMap(_map);
						ReplacementRange_.UpdateMap(_map);
						PossibleValues_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Name_.UpdateMapOnInternalMapUpdate(_map);
						Value_.UpdateMapOnInternalMapUpdate(_map);
						ReplacementRange_.UpdateMapOnInternalMapUpdate(_map);
						PossibleValues_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Command()
						: this(new LoroMap())
					{
					}

					public Command(LoroMap values)
					{
						_map = values;
						Name_ = new StringObservableProperty("name__1", LoroMap);
						Value_ = new StringObservableProperty("value__2", LoroMap);
						ReplacementRange_ = new AtomicObservableProperty<IntRange>("replacement_range__3", LoroMap, IntRangeExtension.Deserialize, IntRangeExtension.Serialize);
						PossibleValues_ = new StringCollection(LoroMap, "possible_values__4");
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, Value_.WhenChangeHappens, ReplacementRange_.WhenChangeHappens, PossibleValues_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Name_.Dispose();
						Value_.Dispose();
						ReplacementRange_.Dispose();
						PossibleValues_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Name_.OnDiff(path, diff);
						Value_.OnDiff(path, diff);
						ReplacementRange_.OnDiff(path, diff);
						PossibleValues_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IMidiCommand : IEntity, IDisposable
				{
					public class Types
					{
						public enum State
						{
							On,
							Off
						}
					}

					IObservableProperty<Types.State> State { get; }

					IObservableProperty<uint> Channel { get; }

					IObservableProperty<uint> Note { get; }

					IObservableProperty<uint> Intensity { get; }
				}

				internal sealed class MidiCommand : IMidiCommand, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private EnumObservableProperty<IMidiCommand.Types.State> State_;

					private UintObservableProperty Channel_;

					private UintObservableProperty Note_;

					private UintObservableProperty Intensity_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<IMidiCommand.Types.State> State => State_;

					public IObservableProperty<uint> Channel => Channel_;

					public IObservableProperty<uint> Note => Note_;

					public IObservableProperty<uint> Intensity => Intensity_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						State_.UpdateMap(_map);
						Channel_.UpdateMap(_map);
						Note_.UpdateMap(_map);
						Intensity_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						State_.UpdateMapOnInternalMapUpdate(_map);
						Channel_.UpdateMapOnInternalMapUpdate(_map);
						Note_.UpdateMapOnInternalMapUpdate(_map);
						Intensity_.UpdateMapOnInternalMapUpdate(_map);
					}

					public MidiCommand()
						: this(new LoroMap())
					{
					}

					public MidiCommand(LoroMap values)
					{
						_map = values;
						State_ = new EnumObservableProperty<IMidiCommand.Types.State>("state__1", LoroMap);
						Channel_ = new UintObservableProperty("channel__2", LoroMap);
						Note_ = new UintObservableProperty("note__3", LoroMap);
						Intensity_ = new UintObservableProperty("intensity__4", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(State_.WhenChangeHappens, Channel_.WhenChangeHappens, Note_.WhenChangeHappens, Intensity_.WhenChangeHappens);
					}

					public void Dispose()
					{
						State_.Dispose();
						Channel_.Dispose();
						Note_.Dispose();
						Intensity_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						State_.OnDiff(path, diff);
						Channel_.OnDiff(path, diff);
						Note_.OnDiff(path, diff);
						Intensity_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ICommandTypeData : IEntity, IDisposable
				{
					public interface IMidiCommand : ICommandTypeData, IEntity, IDisposable, IObservableProperty<Types.IMidiCommand>
					{
					}

					internal class MidiCommand : IMidiCommand, ICommandTypeData, IEntity, IDisposable, IObservableProperty<Types.IMidiCommand>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<Types.IMidiCommand> _MidiCommand_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _MidiCommand_.WhenChangeHappens;

						public IObservable<Types.IMidiCommand> WhenValueChanges => _MidiCommand_.WhenValueChanges;

						public Types.IMidiCommand Value => _MidiCommand_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_MidiCommand_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_MidiCommand_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "midi_command__5".ToLoroValueLike());
							return loroMap;
						}

						public MidiCommand()
							: this(InitializeMap())
						{
						}

						public MidiCommand(LoroMap values)
						{
							_map = values;
							_MidiCommand_ = new ComplexObservableProperty<Types.IMidiCommand>("midi_command__5", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_MidiCommand_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_MidiCommand_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_MidiCommand_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(Types.IMidiCommand value)
						{
							_MidiCommand_.Set(value);
						}
					}
				}

				internal class CommandTypeDataFactory : IUnionValueFactory<ICommandTypeData>
				{
					public string SelectionKey => "__tag";

					public ICommandTypeData? CreateInstance(LoroMap map)
					{
						if (map.Get("__tag").ToStringValue() == "midi_command__5")
						{
							return new ICommandTypeData.MidiCommand(map);
						}
						return null;
					}

					public ICommandTypeData CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "midi_command__5".ToLoroValueLike());
						return new ICommandTypeData.MidiCommand(map);
					}
				}
			}

			IComplexObservableProperty<ICollectionElementType> DeviceIdentification { get; }

			IObservableProperty<string> Format { get; }

			IObservableProperty<string> Description { get; }

			IComplexCollection<Types.ICommand> Commands { get; }

			IComplexObservableProperty<Types.ICommandTypeData> CommandTypeData { get; }
		}

		internal sealed class CommunicationType : ICommunicationType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> DeviceIdentification_;

			private StringObservableProperty Format_;

			private StringObservableProperty Description_;

			private MapCollection<ICommunicationType.Types.ICommand> Commands_;

			private UnionObservableProperty<ICommunicationType.Types.ICommandTypeData> CommandTypeData_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> DeviceIdentification => DeviceIdentification_;

			public IObservableProperty<string> Format => Format_;

			public IObservableProperty<string> Description => Description_;

			public IComplexCollection<ICommunicationType.Types.ICommand> Commands => Commands_;

			public IComplexObservableProperty<ICommunicationType.Types.ICommandTypeData> CommandTypeData => CommandTypeData_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				DeviceIdentification_.UpdateMap(_map);
				Format_.UpdateMap(_map);
				Description_.UpdateMap(_map);
				Commands_.UpdateMap(_map);
				CommandTypeData_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				DeviceIdentification_.UpdateMapOnInternalMapUpdate(_map);
				Format_.UpdateMapOnInternalMapUpdate(_map);
				Description_.UpdateMapOnInternalMapUpdate(_map);
				Commands_.UpdateMapOnInternalMapUpdate(_map);
				CommandTypeData_.UpdateMapOnInternalMapUpdate(_map);
			}

			public CommunicationType()
				: this(new LoroMap())
			{
			}

			public CommunicationType(LoroMap values)
			{
				_map = values;
				DeviceIdentification_ = new ComplexObservableProperty<ICollectionElementType>("device_identification__1", LoroMap, new EntityFactory());
				Format_ = new StringObservableProperty("format__2", LoroMap);
				Description_ = new StringObservableProperty("description__3", LoroMap);
				Commands_ = new MapCollection<ICommunicationType.Types.ICommand>(LoroMap, "commands__4", new EntityFactory());
				CommandTypeData_ = new UnionObservableProperty<ICommunicationType.Types.ICommandTypeData>("CommandTypeData__union", LoroMap, new ICommunicationType.Types.CommandTypeDataFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(DeviceIdentification_.WhenChangeHappens, Format_.WhenChangeHappens, Description_.WhenChangeHappens, Commands_.WhenChangeHappens, CommandTypeData_.WhenChangeHappens);
			}

			public void Dispose()
			{
				DeviceIdentification_.Dispose();
				Format_.Dispose();
				Description_.Dispose();
				Commands_.Dispose();
				CommandTypeData_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				DeviceIdentification_.OnDiff(path, diff);
				Format_.OnDiff(path, diff);
				Description_.OnDiff(path, diff);
				Commands_.OnDiff(path, diff);
				CommandTypeData_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IDocumentType : IEntity, IDisposable
		{
			IObservableProperty<Guid?> SelectedArrangement { get; }

			IObservableProperty<ContentDestination> ContentDestination { get; }
		}

		internal sealed class DocumentType : IDocumentType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalGuidObservableProperty SelectedArrangement_;

			private EnumObservableProperty<ContentDestination> ContentDestination_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid?> SelectedArrangement => SelectedArrangement_;

			public IObservableProperty<ContentDestination> ContentDestination => ContentDestination_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				SelectedArrangement_.UpdateMap(_map);
				ContentDestination_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				SelectedArrangement_.UpdateMapOnInternalMapUpdate(_map);
				ContentDestination_.UpdateMapOnInternalMapUpdate(_map);
			}

			public DocumentType()
				: this(new LoroMap())
			{
			}

			public DocumentType(LoroMap values)
			{
				_map = values;
				SelectedArrangement_ = new OptionalGuidObservableProperty("selected_arrangement__2", LoroMap);
				ContentDestination_ = new EnumObservableProperty<ContentDestination>("content_destination__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = SelectedArrangement_.WhenChangeHappens.Merge(ContentDestination_.WhenChangeHappens);
			}

			public void Dispose()
			{
				SelectedArrangement_.Dispose();
				ContentDestination_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				SelectedArrangement_.OnDiff(path, diff);
				ContentDestination_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IExternalPresentationType : IEntity, IDisposable
		{
			IObservableProperty<Url> Url { get; }
		}

		internal sealed class ExternalPresentationType : IExternalPresentationType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private AtomicObservableProperty<Url> Url_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Url> Url => Url_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Url_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Url_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ExternalPresentationType()
				: this(new LoroMap())
			{
			}

			public ExternalPresentationType(LoroMap values)
			{
				_map = values;
				Url_ = new AtomicObservableProperty<Url>("url__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Url_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Url_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Url_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ILabel : IEntity, IDisposable
		{
			IObservableProperty<string?> Text { get; }

			IObservableProperty<Color?> Color { get; }
		}

		internal sealed class Label : ILabel, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalStringObservableProperty Text_;

			private OptionalAtomicObservableProperty<Color> Color_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string?> Text => Text_;

			public IObservableProperty<Color?> Color => Color_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Text_.UpdateMap(_map);
				Color_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Text_.UpdateMapOnInternalMapUpdate(_map);
				Color_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Label()
				: this(new LoroMap())
			{
			}

			public Label(LoroMap values)
			{
				_map = values;
				Text_ = new OptionalStringObservableProperty("text__2", LoroMap);
				Color_ = new OptionalAtomicObservableProperty<Color>("color__3", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Text_.WhenChangeHappens.Merge(Color_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Text_.Dispose();
				Color_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Text_.OnDiff(path, diff);
				Color_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMacroType : IEntity, IDisposable
		{
			IComplexObservableProperty<ICollectionElementType> Identification { get; }
		}

		internal sealed class MacroType : IMacroType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> Identification_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> Identification => Identification_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMapOnInternalMapUpdate(_map);
			}

			public MacroType()
				: this(new LoroMap())
			{
			}

			public MacroType(LoroMap values)
			{
				_map = values;
				Identification_ = new ComplexObservableProperty<ICollectionElementType>("identification__1", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Identification_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Identification_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Identification_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMaskType : IEntity, IDisposable
		{
			IComplexObservableProperty<ICollectionElementType> Identification { get; }
		}

		internal sealed class MaskType : IMaskType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> Identification_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> Identification => Identification_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMapOnInternalMapUpdate(_map);
			}

			public MaskType()
				: this(new LoroMap())
			{
			}

			public MaskType(LoroMap values)
			{
				_map = values;
				Identification_ = new ComplexObservableProperty<ICollectionElementType>("identification__3", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Identification_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Identification_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Identification_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMediaType : IEntity, IDisposable
		{
			public class Types
			{
				public interface IAudio : IEntity, IDisposable
				{
					public class Types
					{
						public enum MediaActionAudioType
						{
							Tune,
							Sound
						}
					}

					IObservableProperty<PlaybackBehavior> PlaybackBehavior { get; }

					IObservableProperty<double> LoopTime { get; }

					IObservableProperty<uint> TimesToLoop { get; }

					IObservableProperty<Types.MediaActionAudioType> AudioType { get; }
				}

				internal sealed class Audio : IAudio, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private EnumObservableProperty<PlaybackBehavior> PlaybackBehavior_;

					private DoubleObservableProperty LoopTime_;

					private UintObservableProperty TimesToLoop_;

					private EnumObservableProperty<IAudio.Types.MediaActionAudioType> AudioType_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<PlaybackBehavior> PlaybackBehavior => PlaybackBehavior_;

					public IObservableProperty<double> LoopTime => LoopTime_;

					public IObservableProperty<uint> TimesToLoop => TimesToLoop_;

					public IObservableProperty<IAudio.Types.MediaActionAudioType> AudioType => AudioType_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						PlaybackBehavior_.UpdateMap(_map);
						LoopTime_.UpdateMap(_map);
						TimesToLoop_.UpdateMap(_map);
						AudioType_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						PlaybackBehavior_.UpdateMapOnInternalMapUpdate(_map);
						LoopTime_.UpdateMapOnInternalMapUpdate(_map);
						TimesToLoop_.UpdateMapOnInternalMapUpdate(_map);
						AudioType_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Audio()
						: this(new LoroMap())
					{
					}

					public Audio(LoroMap values)
					{
						_map = values;
						PlaybackBehavior_ = new EnumObservableProperty<PlaybackBehavior>("playback_behavior__1", LoroMap);
						LoopTime_ = new DoubleObservableProperty("loop_time__2", LoroMap);
						TimesToLoop_ = new UintObservableProperty("times_to_loop__3", LoroMap);
						AudioType_ = new EnumObservableProperty<IAudio.Types.MediaActionAudioType>("audio_type__4", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(PlaybackBehavior_.WhenChangeHappens, LoopTime_.WhenChangeHappens, TimesToLoop_.WhenChangeHappens, AudioType_.WhenChangeHappens);
					}

					public void Dispose()
					{
						PlaybackBehavior_.Dispose();
						LoopTime_.Dispose();
						TimesToLoop_.Dispose();
						AudioType_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						PlaybackBehavior_.OnDiff(path, diff);
						LoopTime_.OnDiff(path, diff);
						TimesToLoop_.OnDiff(path, diff);
						AudioType_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IPlaybackMarker : IEntity, IDisposable
				{
					IObservableProperty<Guid> Uuid { get; }

					IObservableProperty<double> Time { get; }

					IObservableProperty<Color> Color { get; }

					IObservableProperty<string?> Name { get; }

					IComplexCollection<IAction> Actions { get; }
				}

				internal sealed class PlaybackMarker : IPlaybackMarker, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private GuidObservableProperty Uuid_;

					private DoubleObservableProperty Time_;

					private AtomicObservableProperty<Color> Color_;

					private OptionalStringObservableProperty Name_;

					private MapCollection<IAction> Actions_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Guid> Uuid => Uuid_;

					public IObservableProperty<double> Time => Time_;

					public IObservableProperty<Color> Color => Color_;

					public IObservableProperty<string?> Name => Name_;

					public IComplexCollection<IAction> Actions => Actions_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Uuid_.UpdateMap(_map);
						Time_.UpdateMap(_map);
						Color_.UpdateMap(_map);
						Name_.UpdateMap(_map);
						Actions_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Uuid_.UpdateMapOnInternalMapUpdate(_map);
						Time_.UpdateMapOnInternalMapUpdate(_map);
						Color_.UpdateMapOnInternalMapUpdate(_map);
						Name_.UpdateMapOnInternalMapUpdate(_map);
						Actions_.UpdateMapOnInternalMapUpdate(_map);
					}

					public PlaybackMarker()
						: this(new LoroMap())
					{
					}

					public PlaybackMarker(LoroMap values)
					{
						_map = values;
						Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
						Time_ = new DoubleObservableProperty("time__2", LoroMap);
						Color_ = new AtomicObservableProperty<Color>("color__3", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						Name_ = new OptionalStringObservableProperty("name__4", LoroMap);
						Actions_ = new MapCollection<IAction>(LoroMap, "actions__5", new EntityFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Time_.WhenChangeHappens, Color_.WhenChangeHappens, Name_.WhenChangeHappens, Actions_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Uuid_.Dispose();
						Time_.Dispose();
						Color_.Dispose();
						Name_.Dispose();
						Actions_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Uuid_.OnDiff(path, diff);
						Time_.OnDiff(path, diff);
						Color_.OnDiff(path, diff);
						Name_.OnDiff(path, diff);
						Actions_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum PlaybackBehavior
				{
					Stop,
					Loop,
					LoopForCount,
					LoopForTime
				}

				public interface IMediaType : IEntity, IDisposable
				{
					public interface IAudio : IMediaType, IEntity, IDisposable, IObservableProperty<Types.IAudio>
					{
					}

					internal class Audio : IAudio, IMediaType, IEntity, IDisposable, IObservableProperty<Types.IAudio>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<Types.IAudio> _Audio_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Audio_.WhenChangeHappens;

						public IObservable<Types.IAudio> WhenValueChanges => _Audio_.WhenValueChanges;

						public Types.IAudio Value => _Audio_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Audio_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Audio_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "audio__8".ToLoroValueLike());
							return loroMap;
						}

						public Audio()
							: this(InitializeMap())
						{
						}

						public Audio(LoroMap values)
						{
							_map = values;
							_Audio_ = new ComplexObservableProperty<Types.IAudio>("audio__8", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Audio_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Audio_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Audio_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(Types.IAudio value)
						{
							_Audio_.Set(value);
						}
					}
				}

				internal class MediaTypeFactory : IUnionValueFactory<IMediaType>
				{
					public string SelectionKey => "__tag";

					public IMediaType? CreateInstance(LoroMap map)
					{
						if (map.Get("__tag").ToStringValue() == "audio__8")
						{
							return new IMediaType.Audio(map);
						}
						return null;
					}

					public IMediaType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "audio__8".ToLoroValueLike());
						return new IMediaType.Audio(map);
					}
				}
			}

			IComplexObservableProperty<ITransition?> Transition { get; }

			IComplexObservableProperty<IMedia> Element { get; }

			IObservableProperty<LayerType> LayerType { get; }

			IComplexCollection<Types.IPlaybackMarker> Markers { get; }

			IComplexObservableProperty<Types.IMediaType> _MediaType { get; }
		}

		internal sealed class MediaType : IMediaType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalComplexObservableProperty<ITransition> Transition_;

			private ComplexObservableProperty<IMedia> Element_;

			private EnumObservableProperty<LayerType> LayerType_;

			private MapCollection<IMediaType.Types.IPlaybackMarker> Markers_;

			private UnionObservableProperty<IMediaType.Types.IMediaType> _MediaType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ITransition?> Transition => Transition_;

			public IComplexObservableProperty<IMedia> Element => Element_;

			public IObservableProperty<LayerType> LayerType => LayerType_;

			public IComplexCollection<IMediaType.Types.IPlaybackMarker> Markers => Markers_;

			public IComplexObservableProperty<IMediaType.Types.IMediaType> _MediaType => _MediaType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Transition_.UpdateMap(_map);
				Element_.UpdateMap(_map);
				LayerType_.UpdateMap(_map);
				Markers_.UpdateMap(_map);
				_MediaType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Transition_.UpdateMapOnInternalMapUpdate(_map);
				Element_.UpdateMapOnInternalMapUpdate(_map);
				LayerType_.UpdateMapOnInternalMapUpdate(_map);
				Markers_.UpdateMapOnInternalMapUpdate(_map);
				_MediaType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public MediaType()
				: this(new LoroMap())
			{
			}

			public MediaType(LoroMap values)
			{
				_map = values;
				Transition_ = new OptionalComplexObservableProperty<ITransition>("transition__3", LoroMap, new EntityFactory());
				Element_ = new ComplexObservableProperty<IMedia>("element__5", LoroMap, new EntityFactory());
				LayerType_ = new EnumObservableProperty<LayerType>("layer_type__10", LoroMap);
				Markers_ = new MapCollection<IMediaType.Types.IPlaybackMarker>(LoroMap, "markers__12", new EntityFactory());
				_MediaType_ = new UnionObservableProperty<IMediaType.Types.IMediaType>("MediaType__union", LoroMap, new IMediaType.Types.MediaTypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Transition_.WhenChangeHappens, Element_.WhenChangeHappens, LayerType_.WhenChangeHappens, Markers_.WhenChangeHappens, _MediaType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Transition_.Dispose();
				Element_.Dispose();
				LayerType_.Dispose();
				Markers_.Dispose();
				_MediaType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Transition_.OnDiff(path, diff);
				Element_.OnDiff(path, diff);
				LayerType_.OnDiff(path, diff);
				Markers_.OnDiff(path, diff);
				_MediaType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMessageType : IEntity, IDisposable
		{
			IComplexObservableProperty<ICollectionElementType> MessageIdentificaton { get; }

			IComplexCollection<IMessage.Types.ITokenValue> Content { get; }
		}

		internal sealed class MessageType : IMessageType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> MessageIdentificaton_;

			private MapCollection<IMessage.Types.ITokenValue> Content_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> MessageIdentificaton => MessageIdentificaton_;

			public IComplexCollection<IMessage.Types.ITokenValue> Content => Content_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				MessageIdentificaton_.UpdateMap(_map);
				Content_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				MessageIdentificaton_.UpdateMapOnInternalMapUpdate(_map);
				Content_.UpdateMapOnInternalMapUpdate(_map);
			}

			public MessageType()
				: this(new LoroMap())
			{
			}

			public MessageType(LoroMap values)
			{
				_map = values;
				MessageIdentificaton_ = new ComplexObservableProperty<ICollectionElementType>("message_identificaton__1", LoroMap, new EntityFactory());
				Content_ = new MapCollection<IMessage.Types.ITokenValue>(LoroMap, "content__3", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = MessageIdentificaton_.WhenChangeHappens.Merge(Content_.WhenChangeHappens);
			}

			public void Dispose()
			{
				MessageIdentificaton_.Dispose();
				Content_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				MessageIdentificaton_.OnDiff(path, diff);
				Content_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMultiScreenType : IEntity, IDisposable
		{
			IComplexObservableProperty<ICollectionElementType> Identification { get; }
		}

		internal sealed class MultiScreenType : IMultiScreenType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> Identification_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> Identification => Identification_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMapOnInternalMapUpdate(_map);
			}

			public MultiScreenType()
				: this(new LoroMap())
			{
			}

			public MultiScreenType(LoroMap values)
			{
				_map = values;
				Identification_ = new ComplexObservableProperty<ICollectionElementType>("identification__3", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Identification_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Identification_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Identification_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPlaylistItemType : IEntity, IDisposable
		{
			IObservableProperty<Guid?> PlaylistUuid { get; }

			IObservableProperty<string?> PlaylistName { get; }

			IObservableProperty<Guid?> ItemUuid { get; }

			IObservableProperty<string?> ItemName { get; }

			IObservableProperty<bool> SelectPlaylist { get; }

			IObservableProperty<bool> AlwaysRetrigger { get; }
		}

		internal sealed class PlaylistItemType : IPlaylistItemType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalGuidObservableProperty PlaylistUuid_;

			private OptionalStringObservableProperty PlaylistName_;

			private OptionalGuidObservableProperty ItemUuid_;

			private OptionalStringObservableProperty ItemName_;

			private BoolObservableProperty SelectPlaylist_;

			private BoolObservableProperty AlwaysRetrigger_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid?> PlaylistUuid => PlaylistUuid_;

			public IObservableProperty<string?> PlaylistName => PlaylistName_;

			public IObservableProperty<Guid?> ItemUuid => ItemUuid_;

			public IObservableProperty<string?> ItemName => ItemName_;

			public IObservableProperty<bool> SelectPlaylist => SelectPlaylist_;

			public IObservableProperty<bool> AlwaysRetrigger => AlwaysRetrigger_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				PlaylistUuid_.UpdateMap(_map);
				PlaylistName_.UpdateMap(_map);
				ItemUuid_.UpdateMap(_map);
				ItemName_.UpdateMap(_map);
				SelectPlaylist_.UpdateMap(_map);
				AlwaysRetrigger_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				PlaylistUuid_.UpdateMapOnInternalMapUpdate(_map);
				PlaylistName_.UpdateMapOnInternalMapUpdate(_map);
				ItemUuid_.UpdateMapOnInternalMapUpdate(_map);
				ItemName_.UpdateMapOnInternalMapUpdate(_map);
				SelectPlaylist_.UpdateMapOnInternalMapUpdate(_map);
				AlwaysRetrigger_.UpdateMapOnInternalMapUpdate(_map);
			}

			public PlaylistItemType()
				: this(new LoroMap())
			{
			}

			public PlaylistItemType(LoroMap values)
			{
				_map = values;
				PlaylistUuid_ = new OptionalGuidObservableProperty("playlist_uuid__1", LoroMap);
				PlaylistName_ = new OptionalStringObservableProperty("playlist_name__2", LoroMap);
				ItemUuid_ = new OptionalGuidObservableProperty("item_uuid__3", LoroMap);
				ItemName_ = new OptionalStringObservableProperty("item_name__4", LoroMap);
				SelectPlaylist_ = new BoolObservableProperty("select_playlist__5", LoroMap);
				AlwaysRetrigger_ = new BoolObservableProperty("always_retrigger__6", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(PlaylistUuid_.WhenChangeHappens, PlaylistName_.WhenChangeHappens, ItemUuid_.WhenChangeHappens, ItemName_.WhenChangeHappens, SelectPlaylist_.WhenChangeHappens, AlwaysRetrigger_.WhenChangeHappens);
			}

			public void Dispose()
			{
				PlaylistUuid_.Dispose();
				PlaylistName_.Dispose();
				ItemUuid_.Dispose();
				ItemName_.Dispose();
				SelectPlaylist_.Dispose();
				AlwaysRetrigger_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				PlaylistUuid_.OnDiff(path, diff);
				PlaylistName_.OnDiff(path, diff);
				ItemUuid_.OnDiff(path, diff);
				ItemName_.OnDiff(path, diff);
				SelectPlaylist_.OnDiff(path, diff);
				AlwaysRetrigger_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPropType : IEntity, IDisposable
		{
			public class Types
			{
				public interface IPropClear : IEntity, IDisposable
				{
				}

				internal sealed class PropClear : IPropClear, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public void UpdateMap(LoroMap value)
					{
						_map = value;
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
					}

					public PropClear()
						: this(new LoroMap())
					{
					}

					public PropClear(LoroMap values)
					{
						_map = values;
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge(Array.Empty<IObservable<Unit>>());
					}

					public void Dispose()
					{
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IPropTrigger : IEntity, IDisposable
				{
					IObservableProperty<bool> AutoClearEnabled { get; }

					IObservableProperty<bool> AutoClearFollowsPropDuration { get; }

					IObservableProperty<double> AutoClearDuration { get; }
				}

				internal sealed class PropTrigger : IPropTrigger, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private BoolObservableProperty AutoClearEnabled_;

					private BoolObservableProperty AutoClearFollowsPropDuration_;

					private DoubleObservableProperty AutoClearDuration_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<bool> AutoClearEnabled => AutoClearEnabled_;

					public IObservableProperty<bool> AutoClearFollowsPropDuration => AutoClearFollowsPropDuration_;

					public IObservableProperty<double> AutoClearDuration => AutoClearDuration_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						AutoClearEnabled_.UpdateMap(_map);
						AutoClearFollowsPropDuration_.UpdateMap(_map);
						AutoClearDuration_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						AutoClearEnabled_.UpdateMapOnInternalMapUpdate(_map);
						AutoClearFollowsPropDuration_.UpdateMapOnInternalMapUpdate(_map);
						AutoClearDuration_.UpdateMapOnInternalMapUpdate(_map);
					}

					public PropTrigger()
						: this(new LoroMap())
					{
					}

					public PropTrigger(LoroMap values)
					{
						_map = values;
						AutoClearEnabled_ = new BoolObservableProperty("auto_clear_enabled__1", LoroMap);
						AutoClearFollowsPropDuration_ = new BoolObservableProperty("auto_clear_follows_prop_duration__2", LoroMap);
						AutoClearDuration_ = new DoubleObservableProperty("auto_clear_duration__3", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(AutoClearEnabled_.WhenChangeHappens, AutoClearFollowsPropDuration_.WhenChangeHappens, AutoClearDuration_.WhenChangeHappens);
					}

					public void Dispose()
					{
						AutoClearEnabled_.Dispose();
						AutoClearFollowsPropDuration_.Dispose();
						AutoClearDuration_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						AutoClearEnabled_.OnDiff(path, diff);
						AutoClearFollowsPropDuration_.OnDiff(path, diff);
						AutoClearDuration_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITriggerType : IEntity, IDisposable
				{
					public interface ITrigger : ITriggerType, IEntity, IDisposable, IObservableProperty<IPropTrigger>
					{
					}

					public interface IClear : ITriggerType, IEntity, IDisposable, IObservableProperty<IPropClear>
					{
					}

					internal class Trigger : ITrigger, ITriggerType, IEntity, IDisposable, IObservableProperty<IPropTrigger>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IPropTrigger> _Trigger_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Trigger_.WhenChangeHappens;

						public IObservable<IPropTrigger> WhenValueChanges => _Trigger_.WhenValueChanges;

						public IPropTrigger Value => _Trigger_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Trigger_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Trigger_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "trigger__4".ToLoroValueLike());
							return loroMap;
						}

						public Trigger()
							: this(InitializeMap())
						{
						}

						public Trigger(LoroMap values)
						{
							_map = values;
							_Trigger_ = new ComplexObservableProperty<IPropTrigger>("trigger__4", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Trigger_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Trigger_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Trigger_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IPropTrigger value)
						{
							_Trigger_.Set(value);
						}
					}

					internal class Clear : IClear, ITriggerType, IEntity, IDisposable, IObservableProperty<IPropClear>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IPropClear> _Clear_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Clear_.WhenChangeHappens;

						public IObservable<IPropClear> WhenValueChanges => _Clear_.WhenValueChanges;

						public IPropClear Value => _Clear_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Clear_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Clear_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "clear__5".ToLoroValueLike());
							return loroMap;
						}

						public Clear()
							: this(InitializeMap())
						{
						}

						public Clear(LoroMap values)
						{
							_map = values;
							_Clear_ = new ComplexObservableProperty<IPropClear>("clear__5", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Clear_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Clear_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Clear_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IPropClear value)
						{
							_Clear_.Set(value);
						}
					}
				}

				internal class TriggerTypeFactory : IUnionValueFactory<ITriggerType>
				{
					public string SelectionKey => "__tag";

					public ITriggerType? CreateInstance(LoroMap map)
					{
						string text = map.Get("__tag").ToStringValue();
						if (!(text == "trigger__4"))
						{
							if (text == "clear__5")
							{
								return new ITriggerType.Clear(map);
							}
							return null;
						}
						return new ITriggerType.Trigger(map);
					}

					public ITriggerType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "trigger__4".ToLoroValueLike());
						return new ITriggerType.Trigger(map);
					}
				}
			}

			IComplexObservableProperty<ICollectionElementType> Identification { get; }

			IComplexObservableProperty<Types.ITriggerType> TriggerType { get; }
		}

		internal sealed class PropType : IPropType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> Identification_;

			private UnionObservableProperty<IPropType.Types.ITriggerType> TriggerType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> Identification => Identification_;

			public IComplexObservableProperty<IPropType.Types.ITriggerType> TriggerType => TriggerType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMap(_map);
				TriggerType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Identification_.UpdateMapOnInternalMapUpdate(_map);
				TriggerType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public PropType()
				: this(new LoroMap())
			{
			}

			public PropType(LoroMap values)
			{
				_map = values;
				Identification_ = new ComplexObservableProperty<ICollectionElementType>("identification__3", LoroMap, new EntityFactory());
				TriggerType_ = new UnionObservableProperty<IPropType.Types.ITriggerType>("TriggerType__union", LoroMap, new IPropType.Types.TriggerTypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Identification_.WhenChangeHappens.Merge(TriggerType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Identification_.Dispose();
				TriggerType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Identification_.OnDiff(path, diff);
				TriggerType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISlideDestinationType : IEntity, IDisposable
		{
			IObservableProperty<IStageLayoutType.Types.SlideTarget> SlideTarget { get; }
		}

		internal sealed class SlideDestinationType : ISlideDestinationType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IStageLayoutType.Types.SlideTarget> SlideTarget_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IStageLayoutType.Types.SlideTarget> SlideTarget => SlideTarget_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				SlideTarget_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				SlideTarget_.UpdateMapOnInternalMapUpdate(_map);
			}

			public SlideDestinationType()
				: this(new LoroMap())
			{
			}

			public SlideDestinationType(LoroMap values)
			{
				_map = values;
				SlideTarget_ = new EnumObservableProperty<IStageLayoutType.Types.SlideTarget>("slide_target__1", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(SlideTarget_.WhenChangeHappens);
			}

			public void Dispose()
			{
				SlideTarget_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				SlideTarget_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISlideType : IEntity, IDisposable
		{
			public class Types
			{
				public interface ISlide : IEntity, IDisposable
				{
					public interface IPresentation : ISlide, IEntity, IDisposable, IObservableProperty<IPresentationSlide>
					{
					}

					public interface IProp : ISlide, IEntity, IDisposable, IObservableProperty<IPropSlide>
					{
					}

					internal class Presentation : IPresentation, ISlide, IEntity, IDisposable, IObservableProperty<IPresentationSlide>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IPresentationSlide> _Presentation_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Presentation_.WhenChangeHappens;

						public IObservable<IPresentationSlide> WhenValueChanges => _Presentation_.WhenValueChanges;

						public IPresentationSlide Value => _Presentation_.Value;

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
							loroMap.Insert("__tag", "presentation__2".ToLoroValueLike());
							return loroMap;
						}

						public Presentation()
							: this(InitializeMap())
						{
						}

						public Presentation(LoroMap values)
						{
							_map = values;
							_Presentation_ = new ComplexObservableProperty<IPresentationSlide>("presentation__2", LoroMap, new EntityFactory());
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

						public void Set(IPresentationSlide value)
						{
							_Presentation_.Set(value);
						}
					}

					internal class Prop : IProp, ISlide, IEntity, IDisposable, IObservableProperty<IPropSlide>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IPropSlide> _Prop_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Prop_.WhenChangeHappens;

						public IObservable<IPropSlide> WhenValueChanges => _Prop_.WhenValueChanges;

						public IPropSlide Value => _Prop_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Prop_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Prop_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "prop__3".ToLoroValueLike());
							return loroMap;
						}

						public Prop()
							: this(InitializeMap())
						{
						}

						public Prop(LoroMap values)
						{
							_map = values;
							_Prop_ = new ComplexObservableProperty<IPropSlide>("prop__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Prop_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Prop_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Prop_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IPropSlide value)
						{
							_Prop_.Set(value);
						}
					}
				}

				internal class SlideFactory : IUnionValueFactory<ISlide>
				{
					public string SelectionKey => "__tag";

					public ISlide? CreateInstance(LoroMap map)
					{
						string text = map.Get("__tag").ToStringValue();
						if (!(text == "presentation__2"))
						{
							if (text == "prop__3")
							{
								return new ISlide.Prop(map);
							}
							return null;
						}
						return new ISlide.Presentation(map);
					}

					public ISlide CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "presentation__2".ToLoroValueLike());
						return new ISlide.Presentation(map);
					}
				}
			}

			IComplexObservableProperty<Types.ISlide> Slide { get; }
		}

		internal sealed class SlideType : ISlideType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private UnionObservableProperty<ISlideType.Types.ISlide> Slide_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ISlideType.Types.ISlide> Slide => Slide_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Slide_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Slide_.UpdateMapOnInternalMapUpdate(_map);
			}

			public SlideType()
				: this(new LoroMap())
			{
			}

			public SlideType(LoroMap values)
			{
				_map = values;
				Slide_ = new UnionObservableProperty<ISlideType.Types.ISlide>("Slide__union", LoroMap, new ISlideType.Types.SlideFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Slide_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Slide_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Slide_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IStageLayoutType : IEntity, IDisposable
		{
			public class Types
			{
				public enum SlideTarget
				{
					NoChange,
					StageOnly,
					All
				}
			}

			IComplexCollection<IStage.Types.IScreenAssignment> StageScreenAssignments { get; }

			IObservableProperty<Types.SlideTarget> SlideTarget { get; }
		}

		internal sealed class StageLayoutType : IStageLayoutType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<IStage.Types.IScreenAssignment> StageScreenAssignments_;

			private EnumObservableProperty<IStageLayoutType.Types.SlideTarget> SlideTarget_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<IStage.Types.IScreenAssignment> StageScreenAssignments => StageScreenAssignments_;

			public IObservableProperty<IStageLayoutType.Types.SlideTarget> SlideTarget => SlideTarget_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				StageScreenAssignments_.UpdateMap(_map);
				SlideTarget_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				StageScreenAssignments_.UpdateMapOnInternalMapUpdate(_map);
				SlideTarget_.UpdateMapOnInternalMapUpdate(_map);
			}

			public StageLayoutType()
				: this(new LoroMap())
			{
			}

			public StageLayoutType(LoroMap values)
			{
				_map = values;
				StageScreenAssignments_ = new MapCollection<IStage.Types.IScreenAssignment>(LoroMap, "stage_screen_assignments__4", new EntityFactory());
				SlideTarget_ = new EnumObservableProperty<IStageLayoutType.Types.SlideTarget>("slide_target__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = StageScreenAssignments_.WhenChangeHappens.Merge(SlideTarget_.WhenChangeHappens);
			}

			public void Dispose()
			{
				StageScreenAssignments_.Dispose();
				SlideTarget_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				StageScreenAssignments_.OnDiff(path, diff);
				SlideTarget_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ITimerType : IEntity, IDisposable
		{
			public class Types
			{
				public enum TimerAction
				{
					ActionStart,
					ActionStop,
					ActionReset,
					ActionResetAndStart,
					ActionStopAndReset,
					ActionIncrement
				}
			}

			IObservableProperty<Types.TimerAction> ActionType { get; }

			IComplexObservableProperty<ICollectionElementType> TimerIdentification { get; }

			IComplexObservableProperty<ITimer.Types.IConfiguration> TimerConfiguration { get; }

			IObservableProperty<double> IncrementAmount { get; }
		}

		internal sealed class TimerType : ITimerType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<ITimerType.Types.TimerAction> ActionType_;

			private ComplexObservableProperty<ICollectionElementType> TimerIdentification_;

			private ComplexObservableProperty<ITimer.Types.IConfiguration> TimerConfiguration_;

			private DoubleObservableProperty IncrementAmount_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<ITimerType.Types.TimerAction> ActionType => ActionType_;

			public IComplexObservableProperty<ICollectionElementType> TimerIdentification => TimerIdentification_;

			public IComplexObservableProperty<ITimer.Types.IConfiguration> TimerConfiguration => TimerConfiguration_;

			public IObservableProperty<double> IncrementAmount => IncrementAmount_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				ActionType_.UpdateMap(_map);
				TimerIdentification_.UpdateMap(_map);
				TimerConfiguration_.UpdateMap(_map);
				IncrementAmount_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				ActionType_.UpdateMapOnInternalMapUpdate(_map);
				TimerIdentification_.UpdateMapOnInternalMapUpdate(_map);
				TimerConfiguration_.UpdateMapOnInternalMapUpdate(_map);
				IncrementAmount_.UpdateMapOnInternalMapUpdate(_map);
			}

			public TimerType()
				: this(new LoroMap())
			{
			}

			public TimerType(LoroMap values)
			{
				_map = values;
				ActionType_ = new EnumObservableProperty<ITimerType.Types.TimerAction>("action_type__2", LoroMap);
				TimerIdentification_ = new ComplexObservableProperty<ICollectionElementType>("timer_identification__4", LoroMap, new EntityFactory());
				TimerConfiguration_ = new ComplexObservableProperty<ITimer.Types.IConfiguration>("timer_configuration__10", LoroMap, new EntityFactory());
				IncrementAmount_ = new DoubleObservableProperty("increment_amount__11", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(ActionType_.WhenChangeHappens, TimerIdentification_.WhenChangeHappens, TimerConfiguration_.WhenChangeHappens, IncrementAmount_.WhenChangeHappens);
			}

			public void Dispose()
			{
				ActionType_.Dispose();
				TimerIdentification_.Dispose();
				TimerConfiguration_.Dispose();
				IncrementAmount_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				ActionType_.OnDiff(path, diff);
				TimerIdentification_.OnDiff(path, diff);
				TimerConfiguration_.OnDiff(path, diff);
				IncrementAmount_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ITransportControlType : IEntity, IDisposable
		{
			public class Types
			{
				public interface IJumpToTime : IEntity, IDisposable
				{
					IObservableProperty<double> Time { get; }
				}

				internal sealed class JumpToTime : IJumpToTime, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private DoubleObservableProperty Time_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<double> Time => Time_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Time_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Time_.UpdateMapOnInternalMapUpdate(_map);
					}

					public JumpToTime()
						: this(new LoroMap())
					{
					}

					public JumpToTime(LoroMap values)
					{
						_map = values;
						Time_ = new DoubleObservableProperty("time__1", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Time_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Time_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Time_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IPause : IEntity, IDisposable
				{
				}

				internal sealed class Pause : IPause, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public void UpdateMap(LoroMap value)
					{
						_map = value;
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
					}

					public Pause()
						: this(new LoroMap())
					{
					}

					public Pause(LoroMap values)
					{
						_map = values;
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge(Array.Empty<IObservable<Unit>>());
					}

					public void Dispose()
					{
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IPlay : IEntity, IDisposable
				{
				}

				internal sealed class Play : IPlay, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public void UpdateMap(LoroMap value)
					{
						_map = value;
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
					}

					public Play()
						: this(new LoroMap())
					{
					}

					public Play(LoroMap values)
					{
						_map = values;
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge(Array.Empty<IObservable<Unit>>());
					}

					public void Dispose()
					{
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}
			}
		}

		internal sealed class TransportControlType : ITransportControlType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public void UpdateMap(LoroMap value)
			{
				_map = value;
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
			}

			public TransportControlType()
				: this(new LoroMap())
			{
			}

			public TransportControlType(LoroMap values)
			{
				_map = values;
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge(Array.Empty<IObservable<Unit>>());
			}

			public void Dispose()
			{
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public enum ActionType
		{
			Unknown = 0,
			StageLayout = 1,
			Media = 2,
			Timer = 3,
			Communication = 4,
			Clear = 5,
			Prop = 6,
			Mask = 7,
			Message = 8,
			SocialMedia = 9,
			Multiscreen = 10,
			PresentationSlide = 11,
			ForegroundMedia = 12,
			BackgroundMedia = 13,
			PresentationDocument = 14,
			PropSlide = 15,
			ExternalPresentation = 17,
			AudienceLook = 18,
			AudioInput = 19,
			AudioBinPlaylist = 20,
			MediaBinPlaylist = 21,
			SlideDestination = 22,
			Macro = 23,
			ClearGroup = 24,
			Capture = 25,
			LibraryPlaylist = 26
		}

		public enum ContentDestination
		{
			Global,
			Announcements
		}

		public enum LayerType
		{
			Background,
			Foreground,
			Fill,
			Input
		}

		public interface IActionTypeData : IEntity, IDisposable
		{
			public interface IPlaylistItem : IActionTypeData, IEntity, IDisposable, IObservableProperty<IPlaylistItemType>
			{
			}

			public interface IMedia : IActionTypeData, IEntity, IDisposable, IObservableProperty<IMediaType>
			{
			}

			public interface ISlide : IActionTypeData, IEntity, IDisposable, IObservableProperty<ISlideType>
			{
			}

			public interface ITimer : IActionTypeData, IEntity, IDisposable, IObservableProperty<ITimerType>
			{
			}

			public interface IClear : IActionTypeData, IEntity, IDisposable, IObservableProperty<ClearType>
			{
			}

			public interface IStage : IActionTypeData, IEntity, IDisposable, IObservableProperty<IStageLayoutType>
			{
			}

			public interface IProp : IActionTypeData, IEntity, IDisposable, IObservableProperty<IPropType>
			{
			}

			public interface IMask : IActionTypeData, IEntity, IDisposable, IObservableProperty<IMaskType>
			{
			}

			public interface IMessage : IActionTypeData, IEntity, IDisposable, IObservableProperty<IMessageType>
			{
			}

			public interface ICommunication : IActionTypeData, IEntity, IDisposable, IObservableProperty<ICommunicationType>
			{
			}

			public interface IMultiScreen : IActionTypeData, IEntity, IDisposable, IObservableProperty<IMultiScreenType>
			{
			}

			public interface IPresentationDocument : IActionTypeData, IEntity, IDisposable, IObservableProperty<IDocumentType>
			{
			}

			public interface IExternalPresentation : IActionTypeData, IEntity, IDisposable, IObservableProperty<IExternalPresentationType>
			{
			}

			public interface IAudienceLook : IActionTypeData, IEntity, IDisposable, IObservableProperty<IAudienceLookType>
			{
			}

			public interface IAudioInput : IActionTypeData, IEntity, IDisposable, IObservableProperty<IAudioInputType>
			{
			}

			public interface ISlideDestination : IActionTypeData, IEntity, IDisposable, IObservableProperty<ISlideDestinationType>
			{
			}

			public interface IMacro : IActionTypeData, IEntity, IDisposable, IObservableProperty<IMacroType>
			{
			}

			public interface IClearGroup : IActionTypeData, IEntity, IDisposable, IObservableProperty<IClearGroupType>
			{
			}

			public interface ICapture : IActionTypeData, IEntity, IDisposable, IObservableProperty<ICaptureType>
			{
			}

			internal class PlaylistItem : IPlaylistItem, IActionTypeData, IEntity, IDisposable, IObservableProperty<IPlaylistItemType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IPlaylistItemType> _PlaylistItem_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _PlaylistItem_.WhenChangeHappens;

				public IObservable<IPlaylistItemType> WhenValueChanges => _PlaylistItem_.WhenValueChanges;

				public IPlaylistItemType Value => _PlaylistItem_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_PlaylistItem_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_PlaylistItem_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "playlist_item__17".ToLoroValueLike());
					return loroMap;
				}

				public PlaylistItem()
					: this(InitializeMap())
				{
				}

				public PlaylistItem(LoroMap values)
				{
					_map = values;
					_PlaylistItem_ = new ComplexObservableProperty<IPlaylistItemType>("playlist_item__17", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_PlaylistItem_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_PlaylistItem_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_PlaylistItem_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IPlaylistItemType value)
				{
					_PlaylistItem_.Set(value);
				}
			}

			internal class Media : IMedia, IActionTypeData, IEntity, IDisposable, IObservableProperty<IMediaType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IMediaType> _Media_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Media_.WhenChangeHappens;

				public IObservable<IMediaType> WhenValueChanges => _Media_.WhenValueChanges;

				public IMediaType Value => _Media_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Media_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Media_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "media__20".ToLoroValueLike());
					return loroMap;
				}

				public Media()
					: this(InitializeMap())
				{
				}

				public Media(LoroMap values)
				{
					_map = values;
					_Media_ = new ComplexObservableProperty<IMediaType>("media__20", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Media_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Media_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Media_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IMediaType value)
				{
					_Media_.Set(value);
				}
			}

			internal class Slide : ISlide, IActionTypeData, IEntity, IDisposable, IObservableProperty<ISlideType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ISlideType> _Slide_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Slide_.WhenChangeHappens;

				public IObservable<ISlideType> WhenValueChanges => _Slide_.WhenValueChanges;

				public ISlideType Value => _Slide_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Slide_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Slide_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "slide__23".ToLoroValueLike());
					return loroMap;
				}

				public Slide()
					: this(InitializeMap())
				{
				}

				public Slide(LoroMap values)
				{
					_map = values;
					_Slide_ = new ComplexObservableProperty<ISlideType>("slide__23", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Slide_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Slide_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Slide_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ISlideType value)
				{
					_Slide_.Set(value);
				}
			}

			internal class Timer : ITimer, IActionTypeData, IEntity, IDisposable, IObservableProperty<ITimerType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ITimerType> _Timer_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Timer_.WhenChangeHappens;

				public IObservable<ITimerType> WhenValueChanges => _Timer_.WhenValueChanges;

				public ITimerType Value => _Timer_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Timer_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Timer_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "timer__25".ToLoroValueLike());
					return loroMap;
				}

				public Timer()
					: this(InitializeMap())
				{
				}

				public Timer(LoroMap values)
				{
					_map = values;
					_Timer_ = new ComplexObservableProperty<ITimerType>("timer__25", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Timer_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Timer_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Timer_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ITimerType value)
				{
					_Timer_.Set(value);
				}
			}

			internal class Clear : IClear, IActionTypeData, IEntity, IDisposable, IObservableProperty<ClearType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private CompositeDisposable _linkedDisposables = new CompositeDisposable();

				private AtomicObservableProperty<ClearType> _Clear_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Clear_.WhenChangeHappens;

				public IObservable<ClearType> WhenValueChanges => _Clear_.WhenValueChanges;

				public ClearType Value => _Clear_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Clear_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Clear_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "clear__26".ToLoroValueLike());
					return loroMap;
				}

				public Clear()
					: this(InitializeMap())
				{
				}

				public Clear(LoroMap values)
				{
					_map = values;
					_Clear_ = new AtomicObservableProperty<ClearType>("clear__26", LoroMap, ClearTypeExtension.Deserialize, ClearTypeExtension.Serialize);
				}

				public void Dispose()
				{
					_Clear_.Dispose();
					LoroMap.Dispose();
					_linkedDisposables.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Clear_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_linkedDisposables.Add(disposable);
				}

				public void Set(ClearType value)
				{
					_Clear_.Set(value);
				}
			}

			internal class Stage : IStage, IActionTypeData, IEntity, IDisposable, IObservableProperty<IStageLayoutType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IStageLayoutType> _Stage_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Stage_.WhenChangeHappens;

				public IObservable<IStageLayoutType> WhenValueChanges => _Stage_.WhenValueChanges;

				public IStageLayoutType Value => _Stage_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Stage_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Stage_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "stage__27".ToLoroValueLike());
					return loroMap;
				}

				public Stage()
					: this(InitializeMap())
				{
				}

				public Stage(LoroMap values)
				{
					_map = values;
					_Stage_ = new ComplexObservableProperty<IStageLayoutType>("stage__27", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Stage_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Stage_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Stage_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IStageLayoutType value)
				{
					_Stage_.Set(value);
				}
			}

			internal class Prop : IProp, IActionTypeData, IEntity, IDisposable, IObservableProperty<IPropType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IPropType> _Prop_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Prop_.WhenChangeHappens;

				public IObservable<IPropType> WhenValueChanges => _Prop_.WhenValueChanges;

				public IPropType Value => _Prop_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Prop_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Prop_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "prop__28".ToLoroValueLike());
					return loroMap;
				}

				public Prop()
					: this(InitializeMap())
				{
				}

				public Prop(LoroMap values)
				{
					_map = values;
					_Prop_ = new ComplexObservableProperty<IPropType>("prop__28", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Prop_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Prop_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Prop_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IPropType value)
				{
					_Prop_.Set(value);
				}
			}

			internal class Mask : IMask, IActionTypeData, IEntity, IDisposable, IObservableProperty<IMaskType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IMaskType> _Mask_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Mask_.WhenChangeHappens;

				public IObservable<IMaskType> WhenValueChanges => _Mask_.WhenValueChanges;

				public IMaskType Value => _Mask_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Mask_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Mask_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "mask__29".ToLoroValueLike());
					return loroMap;
				}

				public Mask()
					: this(InitializeMap())
				{
				}

				public Mask(LoroMap values)
				{
					_map = values;
					_Mask_ = new ComplexObservableProperty<IMaskType>("mask__29", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Mask_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Mask_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Mask_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IMaskType value)
				{
					_Mask_.Set(value);
				}
			}

			internal class Message : IMessage, IActionTypeData, IEntity, IDisposable, IObservableProperty<IMessageType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IMessageType> _Message_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Message_.WhenChangeHappens;

				public IObservable<IMessageType> WhenValueChanges => _Message_.WhenValueChanges;

				public IMessageType Value => _Message_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Message_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Message_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "message__30".ToLoroValueLike());
					return loroMap;
				}

				public Message()
					: this(InitializeMap())
				{
				}

				public Message(LoroMap values)
				{
					_map = values;
					_Message_ = new ComplexObservableProperty<IMessageType>("message__30", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Message_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Message_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Message_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IMessageType value)
				{
					_Message_.Set(value);
				}
			}

			internal class Communication : ICommunication, IActionTypeData, IEntity, IDisposable, IObservableProperty<ICommunicationType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICommunicationType> _Communication_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Communication_.WhenChangeHappens;

				public IObservable<ICommunicationType> WhenValueChanges => _Communication_.WhenValueChanges;

				public ICommunicationType Value => _Communication_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Communication_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Communication_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "communication__32".ToLoroValueLike());
					return loroMap;
				}

				public Communication()
					: this(InitializeMap())
				{
				}

				public Communication(LoroMap values)
				{
					_map = values;
					_Communication_ = new ComplexObservableProperty<ICommunicationType>("communication__32", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Communication_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Communication_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Communication_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICommunicationType value)
				{
					_Communication_.Set(value);
				}
			}

			internal class MultiScreen : IMultiScreen, IActionTypeData, IEntity, IDisposable, IObservableProperty<IMultiScreenType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IMultiScreenType> _MultiScreen_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _MultiScreen_.WhenChangeHappens;

				public IObservable<IMultiScreenType> WhenValueChanges => _MultiScreen_.WhenValueChanges;

				public IMultiScreenType Value => _MultiScreen_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_MultiScreen_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_MultiScreen_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "multi_screen__33".ToLoroValueLike());
					return loroMap;
				}

				public MultiScreen()
					: this(InitializeMap())
				{
				}

				public MultiScreen(LoroMap values)
				{
					_map = values;
					_MultiScreen_ = new ComplexObservableProperty<IMultiScreenType>("multi_screen__33", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_MultiScreen_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_MultiScreen_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_MultiScreen_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IMultiScreenType value)
				{
					_MultiScreen_.Set(value);
				}
			}

			internal class PresentationDocument : IPresentationDocument, IActionTypeData, IEntity, IDisposable, IObservableProperty<IDocumentType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IDocumentType> _PresentationDocument_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _PresentationDocument_.WhenChangeHappens;

				public IObservable<IDocumentType> WhenValueChanges => _PresentationDocument_.WhenValueChanges;

				public IDocumentType Value => _PresentationDocument_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_PresentationDocument_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_PresentationDocument_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "presentation_document__34".ToLoroValueLike());
					return loroMap;
				}

				public PresentationDocument()
					: this(InitializeMap())
				{
				}

				public PresentationDocument(LoroMap values)
				{
					_map = values;
					_PresentationDocument_ = new ComplexObservableProperty<IDocumentType>("presentation_document__34", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_PresentationDocument_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_PresentationDocument_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_PresentationDocument_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IDocumentType value)
				{
					_PresentationDocument_.Set(value);
				}
			}

			internal class ExternalPresentation : IExternalPresentation, IActionTypeData, IEntity, IDisposable, IObservableProperty<IExternalPresentationType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IExternalPresentationType> _ExternalPresentation_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _ExternalPresentation_.WhenChangeHappens;

				public IObservable<IExternalPresentationType> WhenValueChanges => _ExternalPresentation_.WhenValueChanges;

				public IExternalPresentationType Value => _ExternalPresentation_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_ExternalPresentation_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_ExternalPresentation_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "external_presentation__36".ToLoroValueLike());
					return loroMap;
				}

				public ExternalPresentation()
					: this(InitializeMap())
				{
				}

				public ExternalPresentation(LoroMap values)
				{
					_map = values;
					_ExternalPresentation_ = new ComplexObservableProperty<IExternalPresentationType>("external_presentation__36", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_ExternalPresentation_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_ExternalPresentation_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_ExternalPresentation_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IExternalPresentationType value)
				{
					_ExternalPresentation_.Set(value);
				}
			}

			internal class AudienceLook : IAudienceLook, IActionTypeData, IEntity, IDisposable, IObservableProperty<IAudienceLookType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IAudienceLookType> _AudienceLook_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _AudienceLook_.WhenChangeHappens;

				public IObservable<IAudienceLookType> WhenValueChanges => _AudienceLook_.WhenValueChanges;

				public IAudienceLookType Value => _AudienceLook_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_AudienceLook_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_AudienceLook_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "audience_look__37".ToLoroValueLike());
					return loroMap;
				}

				public AudienceLook()
					: this(InitializeMap())
				{
				}

				public AudienceLook(LoroMap values)
				{
					_map = values;
					_AudienceLook_ = new ComplexObservableProperty<IAudienceLookType>("audience_look__37", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_AudienceLook_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_AudienceLook_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_AudienceLook_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IAudienceLookType value)
				{
					_AudienceLook_.Set(value);
				}
			}

			internal class AudioInput : IAudioInput, IActionTypeData, IEntity, IDisposable, IObservableProperty<IAudioInputType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IAudioInputType> _AudioInput_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _AudioInput_.WhenChangeHappens;

				public IObservable<IAudioInputType> WhenValueChanges => _AudioInput_.WhenValueChanges;

				public IAudioInputType Value => _AudioInput_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_AudioInput_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_AudioInput_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "audio_input__38".ToLoroValueLike());
					return loroMap;
				}

				public AudioInput()
					: this(InitializeMap())
				{
				}

				public AudioInput(LoroMap values)
				{
					_map = values;
					_AudioInput_ = new ComplexObservableProperty<IAudioInputType>("audio_input__38", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_AudioInput_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_AudioInput_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_AudioInput_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IAudioInputType value)
				{
					_AudioInput_.Set(value);
				}
			}

			internal class SlideDestination : ISlideDestination, IActionTypeData, IEntity, IDisposable, IObservableProperty<ISlideDestinationType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ISlideDestinationType> _SlideDestination_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _SlideDestination_.WhenChangeHappens;

				public IObservable<ISlideDestinationType> WhenValueChanges => _SlideDestination_.WhenValueChanges;

				public ISlideDestinationType Value => _SlideDestination_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_SlideDestination_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_SlideDestination_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "slide_destination__39".ToLoroValueLike());
					return loroMap;
				}

				public SlideDestination()
					: this(InitializeMap())
				{
				}

				public SlideDestination(LoroMap values)
				{
					_map = values;
					_SlideDestination_ = new ComplexObservableProperty<ISlideDestinationType>("slide_destination__39", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_SlideDestination_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_SlideDestination_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_SlideDestination_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ISlideDestinationType value)
				{
					_SlideDestination_.Set(value);
				}
			}

			internal class Macro : IMacro, IActionTypeData, IEntity, IDisposable, IObservableProperty<IMacroType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IMacroType> _Macro_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Macro_.WhenChangeHappens;

				public IObservable<IMacroType> WhenValueChanges => _Macro_.WhenValueChanges;

				public IMacroType Value => _Macro_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Macro_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Macro_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "macro__40".ToLoroValueLike());
					return loroMap;
				}

				public Macro()
					: this(InitializeMap())
				{
				}

				public Macro(LoroMap values)
				{
					_map = values;
					_Macro_ = new ComplexObservableProperty<IMacroType>("macro__40", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Macro_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Macro_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Macro_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IMacroType value)
				{
					_Macro_.Set(value);
				}
			}

			internal class ClearGroup : IClearGroup, IActionTypeData, IEntity, IDisposable, IObservableProperty<IClearGroupType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IClearGroupType> _ClearGroup_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _ClearGroup_.WhenChangeHappens;

				public IObservable<IClearGroupType> WhenValueChanges => _ClearGroup_.WhenValueChanges;

				public IClearGroupType Value => _ClearGroup_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_ClearGroup_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_ClearGroup_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "clear_group__41".ToLoroValueLike());
					return loroMap;
				}

				public ClearGroup()
					: this(InitializeMap())
				{
				}

				public ClearGroup(LoroMap values)
				{
					_map = values;
					_ClearGroup_ = new ComplexObservableProperty<IClearGroupType>("clear_group__41", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_ClearGroup_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_ClearGroup_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_ClearGroup_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IClearGroupType value)
				{
					_ClearGroup_.Set(value);
				}
			}

			internal class Capture : ICapture, IActionTypeData, IEntity, IDisposable, IObservableProperty<ICaptureType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICaptureType> _Capture_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Capture_.WhenChangeHappens;

				public IObservable<ICaptureType> WhenValueChanges => _Capture_.WhenValueChanges;

				public ICaptureType Value => _Capture_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Capture_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Capture_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "capture__43".ToLoroValueLike());
					return loroMap;
				}

				public Capture()
					: this(InitializeMap())
				{
				}

				public Capture(LoroMap values)
				{
					_map = values;
					_Capture_ = new ComplexObservableProperty<ICaptureType>("capture__43", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Capture_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Capture_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Capture_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICaptureType value)
				{
					_Capture_.Set(value);
				}
			}
		}

		internal class ActionTypeDataFactory : IUnionValueFactory<IActionTypeData>
		{
			public string SelectionKey => "__tag";

			public IActionTypeData? CreateInstance(LoroMap map)
			{
				return map.Get("__tag").ToStringValue() switch
				{
					"playlist_item__17" => new IActionTypeData.PlaylistItem(map), 
					"media__20" => new IActionTypeData.Media(map), 
					"slide__23" => new IActionTypeData.Slide(map), 
					"timer__25" => new IActionTypeData.Timer(map), 
					"clear__26" => new IActionTypeData.Clear(map), 
					"stage__27" => new IActionTypeData.Stage(map), 
					"prop__28" => new IActionTypeData.Prop(map), 
					"mask__29" => new IActionTypeData.Mask(map), 
					"message__30" => new IActionTypeData.Message(map), 
					"communication__32" => new IActionTypeData.Communication(map), 
					"multi_screen__33" => new IActionTypeData.MultiScreen(map), 
					"presentation_document__34" => new IActionTypeData.PresentationDocument(map), 
					"external_presentation__36" => new IActionTypeData.ExternalPresentation(map), 
					"audience_look__37" => new IActionTypeData.AudienceLook(map), 
					"audio_input__38" => new IActionTypeData.AudioInput(map), 
					"slide_destination__39" => new IActionTypeData.SlideDestination(map), 
					"macro__40" => new IActionTypeData.Macro(map), 
					"clear_group__41" => new IActionTypeData.ClearGroup(map), 
					"capture__43" => new IActionTypeData.Capture(map), 
					_ => null, 
				};
			}

			public IActionTypeData CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "playlist_item__17".ToLoroValueLike());
				return new IActionTypeData.PlaylistItem(map);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> Name { get; }

	IComplexObservableProperty<Types.ILabel> Label { get; }

	IObservableProperty<double> DelayTime { get; }

	IObservableProperty<bool> IsEnabled { get; }

	IObservableProperty<double> Duration { get; }

	IObservableProperty<Types.ActionType> Type { get; }

	IComplexObservableProperty<Types.IActionTypeData> ActionTypeData { get; }
}
