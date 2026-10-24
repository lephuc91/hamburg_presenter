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

public interface ISlide : IEntity, IDisposable
{
	public class Types
	{
		public interface IElement : IEntity, IDisposable
		{
			public class Types
			{
				public interface IBuild : IEntity, IDisposable
				{
					public class Types
					{
						public enum Start
						{
							OnClick,
							WithPrevious,
							AfterPrevious,
							WithSlide
						}
					}

					IObservableProperty<Guid> Uuid { get; }

					IObservableProperty<Guid> ElementUuid { get; }

					IObservableProperty<Types.Start> Start { get; }

					IObservableProperty<double> DelayTime { get; }

					IComplexObservableProperty<ITransition> Transition { get; }
				}

				internal sealed class Build : IBuild, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private GuidObservableProperty Uuid_;

					private GuidObservableProperty ElementUuid_;

					private EnumObservableProperty<IBuild.Types.Start> Start_;

					private DoubleObservableProperty DelayTime_;

					private ComplexObservableProperty<ITransition> Transition_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Guid> Uuid => Uuid_;

					public IObservableProperty<Guid> ElementUuid => ElementUuid_;

					public IObservableProperty<IBuild.Types.Start> Start => Start_;

					public IObservableProperty<double> DelayTime => DelayTime_;

					public IComplexObservableProperty<ITransition> Transition => Transition_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Uuid_.UpdateMap(_map);
						ElementUuid_.UpdateMap(_map);
						Start_.UpdateMap(_map);
						DelayTime_.UpdateMap(_map);
						Transition_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Uuid_.UpdateMapOnInternalMapUpdate(_map);
						ElementUuid_.UpdateMapOnInternalMapUpdate(_map);
						Start_.UpdateMapOnInternalMapUpdate(_map);
						DelayTime_.UpdateMapOnInternalMapUpdate(_map);
						Transition_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Build()
						: this(new LoroMap())
					{
					}

					public Build(LoroMap values)
					{
						_map = values;
						Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
						ElementUuid_ = new GuidObservableProperty("elementUUID__2", LoroMap);
						Start_ = new EnumObservableProperty<IBuild.Types.Start>("start__3", LoroMap);
						DelayTime_ = new DoubleObservableProperty("delayTime__4", LoroMap);
						Transition_ = new ComplexObservableProperty<ITransition>("transition__5", LoroMap, new EntityFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, ElementUuid_.WhenChangeHappens, Start_.WhenChangeHappens, DelayTime_.WhenChangeHappens, Transition_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Uuid_.Dispose();
						ElementUuid_.Dispose();
						Start_.Dispose();
						DelayTime_.Dispose();
						Transition_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Uuid_.OnDiff(path, diff);
						ElementUuid_.OnDiff(path, diff);
						Start_.OnDiff(path, diff);
						DelayTime_.OnDiff(path, diff);
						Transition_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IChildBuild : IEntity, IDisposable
				{
					IObservableProperty<Guid> Uuid { get; }

					IObservableProperty<IBuild.Types.Start> Start { get; }

					IObservableProperty<double> DelayTime { get; }

					IObservableProperty<uint> Index { get; }
				}

				internal sealed class ChildBuild : IChildBuild, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private GuidObservableProperty Uuid_;

					private EnumObservableProperty<IBuild.Types.Start> Start_;

					private DoubleObservableProperty DelayTime_;

					private UintObservableProperty Index_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Guid> Uuid => Uuid_;

					public IObservableProperty<IBuild.Types.Start> Start => Start_;

					public IObservableProperty<double> DelayTime => DelayTime_;

					public IObservableProperty<uint> Index => Index_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Uuid_.UpdateMap(_map);
						Start_.UpdateMap(_map);
						DelayTime_.UpdateMap(_map);
						Index_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Uuid_.UpdateMapOnInternalMapUpdate(_map);
						Start_.UpdateMapOnInternalMapUpdate(_map);
						DelayTime_.UpdateMapOnInternalMapUpdate(_map);
						Index_.UpdateMapOnInternalMapUpdate(_map);
					}

					public ChildBuild()
						: this(new LoroMap())
					{
					}

					public ChildBuild(LoroMap values)
					{
						_map = values;
						Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
						Start_ = new EnumObservableProperty<IBuild.Types.Start>("start__2", LoroMap);
						DelayTime_ = new DoubleObservableProperty("delayTime__3", LoroMap);
						Index_ = new UintObservableProperty("index__4", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Start_.WhenChangeHappens, DelayTime_.WhenChangeHappens, Index_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Uuid_.Dispose();
						Start_.Dispose();
						DelayTime_.Dispose();
						Index_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Uuid_.OnDiff(path, diff);
						Start_.OnDiff(path, diff);
						DelayTime_.OnDiff(path, diff);
						Index_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IDataLink : IEntity, IDisposable
				{
					public class Types
					{
						public interface IAlternateElementFill : IEntity, IDisposable
						{
							IObservableProperty<Guid?> OtherElementUuid { get; }

							IObservableProperty<string?> OtherElementName { get; }
						}

						internal sealed class AlternateElementFill : IAlternateElementFill, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private OptionalGuidObservableProperty OtherElementUuid_;

							private OptionalStringObservableProperty OtherElementName_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<Guid?> OtherElementUuid => OtherElementUuid_;

							public IObservableProperty<string?> OtherElementName => OtherElementName_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								OtherElementUuid_.UpdateMap(_map);
								OtherElementName_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								OtherElementUuid_.UpdateMapOnInternalMapUpdate(_map);
								OtherElementName_.UpdateMapOnInternalMapUpdate(_map);
							}

							public AlternateElementFill()
								: this(new LoroMap())
							{
							}

							public AlternateElementFill(LoroMap values)
							{
								_map = values;
								OtherElementUuid_ = new OptionalGuidObservableProperty("other_element_uuid__1", LoroMap);
								OtherElementName_ = new OptionalStringObservableProperty("other_element_name__2", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = OtherElementUuid_.WhenChangeHappens.Merge(OtherElementName_.WhenChangeHappens);
							}

							public void Dispose()
							{
								OtherElementUuid_.Dispose();
								OtherElementName_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								OtherElementUuid_.OnDiff(path, diff);
								OtherElementName_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IAlternateElementText : IEntity, IDisposable
						{
							public class Types
							{
								public enum TextTransformOption
								{
									None,
									RemoveLineReturns,
									OneWordPerLine,
									OneCharacterPerLine
								}
							}

							IObservableProperty<Guid?> OtherElementUuid { get; }

							IObservableProperty<string?> OtherElementName { get; }

							IObservableProperty<uint> TextTransformOptions { get; }

							IObservableProperty<Types.TextTransformOption> TextTransform { get; }
						}

						internal sealed class AlternateElementText : IAlternateElementText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private OptionalGuidObservableProperty OtherElementUuid_;

							private OptionalStringObservableProperty OtherElementName_;

							private UintObservableProperty TextTransformOptions_;

							private EnumObservableProperty<IAlternateElementText.Types.TextTransformOption> TextTransform_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<Guid?> OtherElementUuid => OtherElementUuid_;

							public IObservableProperty<string?> OtherElementName => OtherElementName_;

							public IObservableProperty<uint> TextTransformOptions => TextTransformOptions_;

							public IObservableProperty<IAlternateElementText.Types.TextTransformOption> TextTransform => TextTransform_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								OtherElementUuid_.UpdateMap(_map);
								OtherElementName_.UpdateMap(_map);
								TextTransformOptions_.UpdateMap(_map);
								TextTransform_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								OtherElementUuid_.UpdateMapOnInternalMapUpdate(_map);
								OtherElementName_.UpdateMapOnInternalMapUpdate(_map);
								TextTransformOptions_.UpdateMapOnInternalMapUpdate(_map);
								TextTransform_.UpdateMapOnInternalMapUpdate(_map);
							}

							public AlternateElementText()
								: this(new LoroMap())
							{
							}

							public AlternateElementText(LoroMap values)
							{
								_map = values;
								OtherElementUuid_ = new OptionalGuidObservableProperty("other_element_uuid__1", LoroMap);
								OtherElementName_ = new OptionalStringObservableProperty("other_element_name__2", LoroMap);
								TextTransformOptions_ = new UintObservableProperty("text_transform_options__3", LoroMap);
								TextTransform_ = new EnumObservableProperty<IAlternateElementText.Types.TextTransformOption>("text_transform__4", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(OtherElementUuid_.WhenChangeHappens, OtherElementName_.WhenChangeHappens, TextTransformOptions_.WhenChangeHappens, TextTransform_.WhenChangeHappens);
							}

							public void Dispose()
							{
								OtherElementUuid_.Dispose();
								OtherElementName_.Dispose();
								TextTransformOptions_.Dispose();
								TextTransform_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								OtherElementUuid_.OnDiff(path, diff);
								OtherElementName_.OnDiff(path, diff);
								TextTransformOptions_.OnDiff(path, diff);
								TextTransform_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IAudioCountdown : IEntity, IDisposable
						{
							IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat { get; }

							IObservableProperty<string> TimerFormatString { get; }

							IComplexCollection<IColorTrigger> ColorTriggers { get; }

							IObservableProperty<bool> IgnoreLoopingAudio { get; }
						}

						internal sealed class AudioCountdown : IAudioCountdown, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private ComplexObservableProperty<ITimer.Types.IFormat> TimerFormat_;

							private StringObservableProperty TimerFormatString_;

							private MapCollection<IColorTrigger> ColorTriggers_;

							private BoolObservableProperty IgnoreLoopingAudio_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat => TimerFormat_;

							public IObservableProperty<string> TimerFormatString => TimerFormatString_;

							public IComplexCollection<IColorTrigger> ColorTriggers => ColorTriggers_;

							public IObservableProperty<bool> IgnoreLoopingAudio => IgnoreLoopingAudio_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								TimerFormat_.UpdateMap(_map);
								TimerFormatString_.UpdateMap(_map);
								ColorTriggers_.UpdateMap(_map);
								IgnoreLoopingAudio_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								TimerFormat_.UpdateMapOnInternalMapUpdate(_map);
								TimerFormatString_.UpdateMapOnInternalMapUpdate(_map);
								ColorTriggers_.UpdateMapOnInternalMapUpdate(_map);
								IgnoreLoopingAudio_.UpdateMapOnInternalMapUpdate(_map);
							}

							public AudioCountdown()
								: this(new LoroMap())
							{
							}

							public AudioCountdown(LoroMap values)
							{
								_map = values;
								TimerFormat_ = new ComplexObservableProperty<ITimer.Types.IFormat>("timer_format__1", LoroMap, new EntityFactory());
								TimerFormatString_ = new StringObservableProperty("timer_format_string__2", LoroMap);
								ColorTriggers_ = new MapCollection<IColorTrigger>(LoroMap, "color_triggers__3", new EntityFactory());
								IgnoreLoopingAudio_ = new BoolObservableProperty("ignore_looping_audio__4", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(TimerFormat_.WhenChangeHappens, TimerFormatString_.WhenChangeHappens, ColorTriggers_.WhenChangeHappens, IgnoreLoopingAudio_.WhenChangeHappens);
							}

							public void Dispose()
							{
								TimerFormat_.Dispose();
								TimerFormatString_.Dispose();
								ColorTriggers_.Dispose();
								IgnoreLoopingAudio_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								TimerFormat_.OnDiff(path, diff);
								TimerFormatString_.OnDiff(path, diff);
								ColorTriggers_.OnDiff(path, diff);
								IgnoreLoopingAudio_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IAutoAdvanceTimeRemaining : IEntity, IDisposable
						{
							public class Types
							{
								public enum AutoAdvanceSource
								{
									Presentation,
									Announcement
								}
							}

							IObservableProperty<Types.AutoAdvanceSource> AutoAdvanceSource { get; }

							IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat { get; }
						}

						internal sealed class AutoAdvanceTimeRemaining : IAutoAdvanceTimeRemaining, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource> AutoAdvanceSource_;

							private ComplexObservableProperty<ITimer.Types.IFormat> TimerFormat_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource> AutoAdvanceSource => AutoAdvanceSource_;

							public IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat => TimerFormat_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								AutoAdvanceSource_.UpdateMap(_map);
								TimerFormat_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								AutoAdvanceSource_.UpdateMapOnInternalMapUpdate(_map);
								TimerFormat_.UpdateMapOnInternalMapUpdate(_map);
							}

							public AutoAdvanceTimeRemaining()
								: this(new LoroMap())
							{
							}

							public AutoAdvanceTimeRemaining(LoroMap values)
							{
								_map = values;
								AutoAdvanceSource_ = new EnumObservableProperty<IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource>("auto_advance_source__1", LoroMap);
								TimerFormat_ = new ComplexObservableProperty<ITimer.Types.IFormat>("timer_format__2", LoroMap, new EntityFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = AutoAdvanceSource_.WhenChangeHappens.Merge(TimerFormat_.WhenChangeHappens);
							}

							public void Dispose()
							{
								AutoAdvanceSource_.Dispose();
								TimerFormat_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								AutoAdvanceSource_.OnDiff(path, diff);
								TimerFormat_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ICcliText : IEntity, IDisposable
						{
						}

						internal sealed class CcliText : ICcliText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public CcliText()
								: this(new LoroMap())
							{
							}

							public CcliText(LoroMap values)
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

						public interface ICaptureStatusColor : IEntity, IDisposable
						{
						}

						internal sealed class CaptureStatusColor : ICaptureStatusColor, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public CaptureStatusColor()
								: this(new LoroMap())
							{
							}

							public CaptureStatusColor(LoroMap values)
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

						public interface ICaptureStatusText : IEntity, IDisposable
						{
							public class Types
							{
								public interface IElapsedTime : IEntity, IDisposable
								{
									IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat { get; }
								}

								internal sealed class ElapsedTime : IElapsedTime, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
								{
									private LoroMap _map;

									private CompositeDisposable _linkedDisposables;

									private ComplexObservableProperty<ITimer.Types.IFormat> TimerFormat_;

									public LoroMap LoroMap => _map;

									public IObservable<Unit> WhenChangeHappens { get; }

									public IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat => TimerFormat_;

									public void UpdateMap(LoroMap value)
									{
										_map = value;
										TimerFormat_.UpdateMap(_map);
									}

									public void UpdateMapOnInternalMapUpdate(LoroMap value)
									{
										_map = value;
										TimerFormat_.UpdateMapOnInternalMapUpdate(_map);
									}

									public ElapsedTime()
										: this(new LoroMap())
									{
									}

									public ElapsedTime(LoroMap values)
									{
										_map = values;
										TimerFormat_ = new ComplexObservableProperty<ITimer.Types.IFormat>("timer_format__1", LoroMap, new EntityFactory());
										_linkedDisposables = new CompositeDisposable();
										WhenChangeHappens = Observable.Merge<Unit>(TimerFormat_.WhenChangeHappens);
									}

									public void Dispose()
									{
										TimerFormat_.Dispose();
										LoroMap.Dispose();
										_linkedDisposables.Dispose();
									}

									public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
									{
										TimerFormat_.OnDiff(path, diff);
									}

									public void RegisterLinkedDisposable(IDisposable disposable)
									{
										_linkedDisposables.Add(disposable);
									}
								}

								public interface IStatusText : IEntity, IDisposable
								{
								}

								internal sealed class StatusText : IStatusText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

									public StatusText()
										: this(new LoroMap())
									{
									}

									public StatusText(LoroMap values)
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

								public interface ITextType : IEntity, IDisposable
								{
									public interface IStatusText : ITextType, IEntity, IDisposable, IObservableProperty<Types.IStatusText>
									{
									}

									public interface IElapsedTime : ITextType, IEntity, IDisposable, IObservableProperty<Types.IElapsedTime>
									{
									}

									internal class StatusText : IStatusText, ITextType, IEntity, IDisposable, IObservableProperty<Types.IStatusText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<Types.IStatusText> _StatusText_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _StatusText_.WhenChangeHappens;

										public IObservable<Types.IStatusText> WhenValueChanges => _StatusText_.WhenValueChanges;

										public Types.IStatusText Value => _StatusText_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_StatusText_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_StatusText_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "status_text__1".ToLoroValueLike());
											return loroMap;
										}

										public StatusText()
											: this(InitializeMap())
										{
										}

										public StatusText(LoroMap values)
										{
											_map = values;
											_StatusText_ = new ComplexObservableProperty<Types.IStatusText>("status_text__1", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_StatusText_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_StatusText_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_StatusText_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(Types.IStatusText value)
										{
											_StatusText_.Set(value);
										}
									}

									internal class ElapsedTime : IElapsedTime, ITextType, IEntity, IDisposable, IObservableProperty<Types.IElapsedTime>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<Types.IElapsedTime> _ElapsedTime_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _ElapsedTime_.WhenChangeHappens;

										public IObservable<Types.IElapsedTime> WhenValueChanges => _ElapsedTime_.WhenValueChanges;

										public Types.IElapsedTime Value => _ElapsedTime_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_ElapsedTime_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_ElapsedTime_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "elapsed_time__2".ToLoroValueLike());
											return loroMap;
										}

										public ElapsedTime()
											: this(InitializeMap())
										{
										}

										public ElapsedTime(LoroMap values)
										{
											_map = values;
											_ElapsedTime_ = new ComplexObservableProperty<Types.IElapsedTime>("elapsed_time__2", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_ElapsedTime_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_ElapsedTime_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_ElapsedTime_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(Types.IElapsedTime value)
										{
											_ElapsedTime_.Set(value);
										}
									}
								}

								internal class TextTypeFactory : IUnionValueFactory<ITextType>
								{
									public string SelectionKey => "__tag";

									public ITextType? CreateInstance(LoroMap map)
									{
										string text = map.Get("__tag").ToStringValue();
										if (!(text == "status_text__1"))
										{
											if (text == "elapsed_time__2")
											{
												return new ITextType.ElapsedTime(map);
											}
											return null;
										}
										return new ITextType.StatusText(map);
									}

									public ITextType CreateDefault(LoroMap map)
									{
										map.Insert("__tag", "status_text__1".ToLoroValueLike());
										return new ITextType.StatusText(map);
									}
								}
							}

							IComplexObservableProperty<Types.ITextType> TextType { get; }
						}

						internal sealed class CaptureStatusText : ICaptureStatusText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private UnionObservableProperty<ICaptureStatusText.Types.ITextType> TextType_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IComplexObservableProperty<ICaptureStatusText.Types.ITextType> TextType => TextType_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								TextType_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								TextType_.UpdateMapOnInternalMapUpdate(_map);
							}

							public CaptureStatusText()
								: this(new LoroMap())
							{
							}

							public CaptureStatusText(LoroMap values)
							{
								_map = values;
								TextType_ = new UnionObservableProperty<ICaptureStatusText.Types.ITextType>("TextType__union", LoroMap, new ICaptureStatusText.Types.TextTypeFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(TextType_.WhenChangeHappens);
							}

							public void Dispose()
							{
								TextType_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								TextType_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IChordChart : IEntity, IDisposable
						{
						}

						internal sealed class ChordChart : IChordChart, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public ChordChart()
								: this(new LoroMap())
							{
							}

							public ChordChart(LoroMap values)
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

						public interface IChordProChart : IEntity, IDisposable
						{
						}

						internal sealed class ChordProChart : IChordProChart, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public ChordProChart()
								: this(new LoroMap())
							{
							}

							public ChordProChart(LoroMap values)
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

						public interface IClockText : IEntity, IDisposable
						{
							IObservableProperty<string> ClockFormatString { get; }

							IComplexObservableProperty<IClock.Types.IFormat> Format { get; }
						}

						internal sealed class ClockText : IClockText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private StringObservableProperty ClockFormatString_;

							private ComplexObservableProperty<IClock.Types.IFormat> Format_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<string> ClockFormatString => ClockFormatString_;

							public IComplexObservableProperty<IClock.Types.IFormat> Format => Format_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								ClockFormatString_.UpdateMap(_map);
								Format_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								ClockFormatString_.UpdateMapOnInternalMapUpdate(_map);
								Format_.UpdateMapOnInternalMapUpdate(_map);
							}

							public ClockText()
								: this(new LoroMap())
							{
							}

							public ClockText(LoroMap values)
							{
								_map = values;
								ClockFormatString_ = new StringObservableProperty("clock_format_string__1", LoroMap);
								Format_ = new ComplexObservableProperty<IClock.Types.IFormat>("format__5", LoroMap, new EntityFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = ClockFormatString_.WhenChangeHappens.Merge(Format_.WhenChangeHappens);
							}

							public void Dispose()
							{
								ClockFormatString_.Dispose();
								Format_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								ClockFormatString_.OnDiff(path, diff);
								Format_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IColorTrigger : IEntity, IDisposable
						{
							IObservableProperty<double> Time { get; }

							IObservableProperty<Color> Color { get; }
						}

						internal sealed class ColorTrigger : IColorTrigger, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private DoubleObservableProperty Time_;

							private AtomicObservableProperty<Color> Color_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<double> Time => Time_;

							public IObservableProperty<Color> Color => Color_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Time_.UpdateMap(_map);
								Color_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Time_.UpdateMapOnInternalMapUpdate(_map);
								Color_.UpdateMapOnInternalMapUpdate(_map);
							}

							public ColorTrigger()
								: this(new LoroMap())
							{
							}

							public ColorTrigger(LoroMap values)
							{
								_map = values;
								Time_ = new DoubleObservableProperty("time__1", LoroMap);
								Color_ = new AtomicObservableProperty<Color>("color__2", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Time_.WhenChangeHappens.Merge(Color_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Time_.Dispose();
								Color_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Time_.OnDiff(path, diff);
								Color_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IFileFeed : IEntity, IDisposable
						{
							IObservableProperty<Url> Url { get; }
						}

						internal sealed class FileFeed : IFileFeed, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public FileFeed()
								: this(new LoroMap())
							{
							}

							public FileFeed(LoroMap values)
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

						public interface IGroupColor : IEntity, IDisposable
						{
							IObservableProperty<GroupSourceType> GroupSource { get; }
						}

						internal sealed class GroupColor : IGroupColor, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<GroupSourceType> GroupSource_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<GroupSourceType> GroupSource => GroupSource_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								GroupSource_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								GroupSource_.UpdateMapOnInternalMapUpdate(_map);
							}

							public GroupColor()
								: this(new LoroMap())
							{
							}

							public GroupColor(LoroMap values)
							{
								_map = values;
								GroupSource_ = new EnumObservableProperty<GroupSourceType>("groupSource__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(GroupSource_.WhenChangeHappens);
							}

							public void Dispose()
							{
								GroupSource_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								GroupSource_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IGroupName : IEntity, IDisposable
						{
							IObservableProperty<GroupSourceType> GroupSource { get; }
						}

						internal sealed class GroupName : IGroupName, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<GroupSourceType> GroupSource_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<GroupSourceType> GroupSource => GroupSource_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								GroupSource_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								GroupSource_.UpdateMapOnInternalMapUpdate(_map);
							}

							public GroupName()
								: this(new LoroMap())
							{
							}

							public GroupName(LoroMap values)
							{
								_map = values;
								GroupSource_ = new EnumObservableProperty<GroupSourceType>("groupSource__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(GroupSource_.WhenChangeHappens);
							}

							public void Dispose()
							{
								GroupSource_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								GroupSource_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IOutputScreen : IEntity, IDisposable
						{
							IObservableProperty<Guid?> ScreenId { get; }

							IObservableProperty<string?> ScreenName { get; }
						}

						internal sealed class OutputScreen : IOutputScreen, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private OptionalGuidObservableProperty ScreenId_;

							private OptionalStringObservableProperty ScreenName_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<Guid?> ScreenId => ScreenId_;

							public IObservableProperty<string?> ScreenName => ScreenName_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								ScreenId_.UpdateMap(_map);
								ScreenName_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								ScreenId_.UpdateMapOnInternalMapUpdate(_map);
								ScreenName_.UpdateMapOnInternalMapUpdate(_map);
							}

							public OutputScreen()
								: this(new LoroMap())
							{
							}

							public OutputScreen(LoroMap values)
							{
								_map = values;
								ScreenId_ = new OptionalGuidObservableProperty("screen_id__1", LoroMap);
								ScreenName_ = new OptionalStringObservableProperty("screen_name__2", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = ScreenId_.WhenChangeHappens.Merge(ScreenName_.WhenChangeHappens);
							}

							public void Dispose()
							{
								ScreenId_.Dispose();
								ScreenName_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								ScreenId_.OnDiff(path, diff);
								ScreenName_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IPcoLive : IEntity, IDisposable
						{
							public class Types
							{
								public enum CountdownType
								{
									FullItemLength,
									EndItemOnTime,
									EndServiceOnTime
								}

								public enum Theme
								{
									PcoliveThemeLight,
									PcoliveThemeDark
								}
							}

							IObservableProperty<Types.Theme> Theme { get; }

							IObservableProperty<Types.CountdownType> CountdownType { get; }
						}

						internal sealed class PcoLive : IPcoLive, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<IPcoLive.Types.Theme> Theme_;

							private EnumObservableProperty<IPcoLive.Types.CountdownType> CountdownType_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<IPcoLive.Types.Theme> Theme => Theme_;

							public IObservableProperty<IPcoLive.Types.CountdownType> CountdownType => CountdownType_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Theme_.UpdateMap(_map);
								CountdownType_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Theme_.UpdateMapOnInternalMapUpdate(_map);
								CountdownType_.UpdateMapOnInternalMapUpdate(_map);
							}

							public PcoLive()
								: this(new LoroMap())
							{
							}

							public PcoLive(LoroMap values)
							{
								_map = values;
								Theme_ = new EnumObservableProperty<IPcoLive.Types.Theme>("theme__2", LoroMap);
								CountdownType_ = new EnumObservableProperty<IPcoLive.Types.CountdownType>("countdown_type__3", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Theme_.WhenChangeHappens.Merge(CountdownType_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Theme_.Dispose();
								CountdownType_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Theme_.OnDiff(path, diff);
								CountdownType_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IPlaybackMarkerIdentifier : IEntity, IDisposable
						{
							public class Types
							{
								public enum Destination
								{
									PlaybackMarkerDestinationPresentation,
									PlaybackMarkerDestinationAnnouncement,
									PlaybackMarkerDestinationAudio
								}

								public enum Type
								{
									PlaybackMarkerIdentifierFirst,
									PlaybackMarkerIdentifierPrevious,
									PlaybackMarkerIdentifierNext,
									PlaybackMarkerIdentifierLast,
									PlaybackMarkerIdentifierName
								}
							}

							IObservableProperty<Types.Destination> Destination { get; }

							IObservableProperty<Types.Type> Type { get; }

							IObservableProperty<string> Name { get; }
						}

						internal sealed class PlaybackMarkerIdentifier : IPlaybackMarkerIdentifier, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<IPlaybackMarkerIdentifier.Types.Destination> Destination_;

							private EnumObservableProperty<IPlaybackMarkerIdentifier.Types.Type> Type_;

							private StringObservableProperty Name_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<IPlaybackMarkerIdentifier.Types.Destination> Destination => Destination_;

							public IObservableProperty<IPlaybackMarkerIdentifier.Types.Type> Type => Type_;

							public IObservableProperty<string> Name => Name_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Destination_.UpdateMap(_map);
								Type_.UpdateMap(_map);
								Name_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Destination_.UpdateMapOnInternalMapUpdate(_map);
								Type_.UpdateMapOnInternalMapUpdate(_map);
								Name_.UpdateMapOnInternalMapUpdate(_map);
							}

							public PlaybackMarkerIdentifier()
								: this(new LoroMap())
							{
							}

							public PlaybackMarkerIdentifier(LoroMap values)
							{
								_map = values;
								Destination_ = new EnumObservableProperty<IPlaybackMarkerIdentifier.Types.Destination>("destination__1", LoroMap);
								Type_ = new EnumObservableProperty<IPlaybackMarkerIdentifier.Types.Type>("type__2", LoroMap);
								Name_ = new StringObservableProperty("name__3", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(Destination_.WhenChangeHappens, Type_.WhenChangeHappens, Name_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Destination_.Dispose();
								Type_.Dispose();
								Name_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Destination_.OnDiff(path, diff);
								Type_.OnDiff(path, diff);
								Name_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IPlaybackMarkerText : IEntity, IDisposable
						{
							public class Types
							{
								public interface IName : IEntity, IDisposable
								{
								}

								internal sealed class Name : IName, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

									public Name()
										: this(new LoroMap())
									{
									}

									public Name(LoroMap values)
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

								public interface ITime : IEntity, IDisposable
								{
									IComplexObservableProperty<ITimer.Types.IFormat> Format { get; }
								}

								internal sealed class Time : ITime, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
								{
									private LoroMap _map;

									private CompositeDisposable _linkedDisposables;

									private ComplexObservableProperty<ITimer.Types.IFormat> Format_;

									public LoroMap LoroMap => _map;

									public IObservable<Unit> WhenChangeHappens { get; }

									public IComplexObservableProperty<ITimer.Types.IFormat> Format => Format_;

									public void UpdateMap(LoroMap value)
									{
										_map = value;
										Format_.UpdateMap(_map);
									}

									public void UpdateMapOnInternalMapUpdate(LoroMap value)
									{
										_map = value;
										Format_.UpdateMapOnInternalMapUpdate(_map);
									}

									public Time()
										: this(new LoroMap())
									{
									}

									public Time(LoroMap values)
									{
										_map = values;
										Format_ = new ComplexObservableProperty<ITimer.Types.IFormat>("format__1", LoroMap, new EntityFactory());
										_linkedDisposables = new CompositeDisposable();
										WhenChangeHappens = Observable.Merge<Unit>(Format_.WhenChangeHappens);
									}

									public void Dispose()
									{
										Format_.Dispose();
										LoroMap.Dispose();
										_linkedDisposables.Dispose();
									}

									public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
									{
										Format_.OnDiff(path, diff);
									}

									public void RegisterLinkedDisposable(IDisposable disposable)
									{
										_linkedDisposables.Add(disposable);
									}
								}

								public interface ITextType : IEntity, IDisposable
								{
									public interface IName : ITextType, IEntity, IDisposable, IObservableProperty<Types.IName>
									{
									}

									public interface ITime : ITextType, IEntity, IDisposable, IObservableProperty<Types.ITime>
									{
									}

									internal class Name : IName, ITextType, IEntity, IDisposable, IObservableProperty<Types.IName>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<Types.IName> _Name_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _Name_.WhenChangeHappens;

										public IObservable<Types.IName> WhenValueChanges => _Name_.WhenValueChanges;

										public Types.IName Value => _Name_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_Name_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_Name_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "name__2".ToLoroValueLike());
											return loroMap;
										}

										public Name()
											: this(InitializeMap())
										{
										}

										public Name(LoroMap values)
										{
											_map = values;
											_Name_ = new ComplexObservableProperty<Types.IName>("name__2", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_Name_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_Name_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_Name_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(Types.IName value)
										{
											_Name_.Set(value);
										}
									}

									internal class Time : ITime, ITextType, IEntity, IDisposable, IObservableProperty<Types.ITime>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<Types.ITime> _Time_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _Time_.WhenChangeHappens;

										public IObservable<Types.ITime> WhenValueChanges => _Time_.WhenValueChanges;

										public Types.ITime Value => _Time_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_Time_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_Time_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "time__3".ToLoroValueLike());
											return loroMap;
										}

										public Time()
											: this(InitializeMap())
										{
										}

										public Time(LoroMap values)
										{
											_map = values;
											_Time_ = new ComplexObservableProperty<Types.ITime>("time__3", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_Time_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_Time_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_Time_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(Types.ITime value)
										{
											_Time_.Set(value);
										}
									}
								}

								internal class TextTypeFactory : IUnionValueFactory<ITextType>
								{
									public string SelectionKey => "__tag";

									public ITextType? CreateInstance(LoroMap map)
									{
										string text = map.Get("__tag").ToStringValue();
										if (!(text == "name__2"))
										{
											if (text == "time__3")
											{
												return new ITextType.Time(map);
											}
											return null;
										}
										return new ITextType.Name(map);
									}

									public ITextType CreateDefault(LoroMap map)
									{
										map.Insert("__tag", "name__2".ToLoroValueLike());
										return new ITextType.Name(map);
									}
								}
							}

							IComplexObservableProperty<IPlaybackMarkerIdentifier> Identifier { get; }

							IObservableProperty<bool> ShouldUseMarkerColor { get; }

							IComplexObservableProperty<Types.ITextType> TextType { get; }
						}

						internal sealed class PlaybackMarkerText : IPlaybackMarkerText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private ComplexObservableProperty<IPlaybackMarkerIdentifier> Identifier_;

							private BoolObservableProperty ShouldUseMarkerColor_;

							private UnionObservableProperty<IPlaybackMarkerText.Types.ITextType> TextType_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IComplexObservableProperty<IPlaybackMarkerIdentifier> Identifier => Identifier_;

							public IObservableProperty<bool> ShouldUseMarkerColor => ShouldUseMarkerColor_;

							public IComplexObservableProperty<IPlaybackMarkerText.Types.ITextType> TextType => TextType_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Identifier_.UpdateMap(_map);
								ShouldUseMarkerColor_.UpdateMap(_map);
								TextType_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Identifier_.UpdateMapOnInternalMapUpdate(_map);
								ShouldUseMarkerColor_.UpdateMapOnInternalMapUpdate(_map);
								TextType_.UpdateMapOnInternalMapUpdate(_map);
							}

							public PlaybackMarkerText()
								: this(new LoroMap())
							{
							}

							public PlaybackMarkerText(LoroMap values)
							{
								_map = values;
								Identifier_ = new ComplexObservableProperty<IPlaybackMarkerIdentifier>("identifier__1", LoroMap, new EntityFactory());
								ShouldUseMarkerColor_ = new BoolObservableProperty("should_use_marker_color__4", LoroMap);
								TextType_ = new UnionObservableProperty<IPlaybackMarkerText.Types.ITextType>("TextType__union", LoroMap, new IPlaybackMarkerText.Types.TextTypeFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(Identifier_.WhenChangeHappens, ShouldUseMarkerColor_.WhenChangeHappens, TextType_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Identifier_.Dispose();
								ShouldUseMarkerColor_.Dispose();
								TextType_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Identifier_.OnDiff(path, diff);
								ShouldUseMarkerColor_.OnDiff(path, diff);
								TextType_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IPlaylistItem : IEntity, IDisposable
						{
							public class Types
							{
								public enum PlaylistItemSourceType
								{
									Current,
									Next,
									CurrentHeader,
									NextHeader,
									ParentPlaylist
								}
							}

							IObservableProperty<Types.PlaylistItemSourceType> PlaylistItemSource { get; }

							IObservableProperty<bool> ShowArrangement { get; }
						}

						internal sealed class PlaylistItem : IPlaylistItem, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<IPlaylistItem.Types.PlaylistItemSourceType> PlaylistItemSource_;

							private BoolObservableProperty ShowArrangement_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<IPlaylistItem.Types.PlaylistItemSourceType> PlaylistItemSource => PlaylistItemSource_;

							public IObservableProperty<bool> ShowArrangement => ShowArrangement_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								PlaylistItemSource_.UpdateMap(_map);
								ShowArrangement_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								PlaylistItemSource_.UpdateMapOnInternalMapUpdate(_map);
								ShowArrangement_.UpdateMapOnInternalMapUpdate(_map);
							}

							public PlaylistItem()
								: this(new LoroMap())
							{
							}

							public PlaylistItem(LoroMap values)
							{
								_map = values;
								PlaylistItemSource_ = new EnumObservableProperty<IPlaylistItem.Types.PlaylistItemSourceType>("playlistItemSource__1", LoroMap);
								ShowArrangement_ = new BoolObservableProperty("showArrangement__2", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = PlaylistItemSource_.WhenChangeHappens.Merge(ShowArrangement_.WhenChangeHappens);
							}

							public void Dispose()
							{
								PlaylistItemSource_.Dispose();
								ShowArrangement_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								PlaylistItemSource_.OnDiff(path, diff);
								ShowArrangement_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IPresentation : IEntity, IDisposable
						{
							public class Types
							{
								public enum PresentationSource
								{
									Presentation,
									Announcement
								}
							}

							IObservableProperty<Types.PresentationSource> PresentationSource { get; }
						}

						internal sealed class Presentation : IPresentation, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<IPresentation.Types.PresentationSource> PresentationSource_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<IPresentation.Types.PresentationSource> PresentationSource => PresentationSource_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								PresentationSource_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								PresentationSource_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Presentation()
								: this(new LoroMap())
							{
							}

							public Presentation(LoroMap values)
							{
								_map = values;
								PresentationSource_ = new EnumObservableProperty<IPresentation.Types.PresentationSource>("presentation_source__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(PresentationSource_.WhenChangeHappens);
							}

							public void Dispose()
							{
								PresentationSource_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								PresentationSource_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IPresentationNotes : IEntity, IDisposable
						{
						}

						internal sealed class PresentationNotes : IPresentationNotes, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public PresentationNotes()
								: this(new LoroMap())
							{
							}

							public PresentationNotes(LoroMap values)
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

						public interface IRssFeed : IEntity, IDisposable
						{
							public class Types
							{
								public enum ContentType
								{
									TitleOnly,
									TitleAndDescription
								}
							}

							IObservableProperty<Url?> Url { get; }

							IObservableProperty<Types.ContentType> Content { get; }

							IObservableProperty<string?> TextDelimiter { get; }
						}

						internal sealed class RssFeed : IRssFeed, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private OptionalAtomicObservableProperty<Url> Url_;

							private EnumObservableProperty<IRssFeed.Types.ContentType> Content_;

							private OptionalStringObservableProperty TextDelimiter_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<Url?> Url => Url_;

							public IObservableProperty<IRssFeed.Types.ContentType> Content => Content_;

							public IObservableProperty<string?> TextDelimiter => TextDelimiter_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Url_.UpdateMap(_map);
								Content_.UpdateMap(_map);
								TextDelimiter_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Url_.UpdateMapOnInternalMapUpdate(_map);
								Content_.UpdateMapOnInternalMapUpdate(_map);
								TextDelimiter_.UpdateMapOnInternalMapUpdate(_map);
							}

							public RssFeed()
								: this(new LoroMap())
							{
							}

							public RssFeed(LoroMap values)
							{
								_map = values;
								Url_ = new OptionalAtomicObservableProperty<Url>("url__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
								Content_ = new EnumObservableProperty<IRssFeed.Types.ContentType>("content__2", LoroMap);
								TextDelimiter_ = new OptionalStringObservableProperty("text_delimiter__3", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(Url_.WhenChangeHappens, Content_.WhenChangeHappens, TextDelimiter_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Url_.Dispose();
								Content_.Dispose();
								TextDelimiter_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Url_.OnDiff(path, diff);
								Content_.OnDiff(path, diff);
								TextDelimiter_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ISlideCount : IEntity, IDisposable
						{
							public class Types
							{
								public enum SlideCountSourceType
								{
									Current,
									Remaining,
									Total
								}
							}

							IObservableProperty<Types.SlideCountSourceType> SlideCountSourceType { get; }
						}

						internal sealed class SlideCount : ISlideCount, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<ISlideCount.Types.SlideCountSourceType> SlideCountSourceType_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<ISlideCount.Types.SlideCountSourceType> SlideCountSourceType => SlideCountSourceType_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								SlideCountSourceType_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								SlideCountSourceType_.UpdateMapOnInternalMapUpdate(_map);
							}

							public SlideCount()
								: this(new LoroMap())
							{
							}

							public SlideCount(LoroMap values)
							{
								_map = values;
								SlideCountSourceType_ = new EnumObservableProperty<ISlideCount.Types.SlideCountSourceType>("slideCountSourceType__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(SlideCountSourceType_.WhenChangeHappens);
							}

							public void Dispose()
							{
								SlideCountSourceType_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								SlideCountSourceType_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ISlideImage : IEntity, IDisposable
						{
							IObservableProperty<SlideSourceType> SourceSlide { get; }
						}

						internal sealed class SlideImage : ISlideImage, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<SlideSourceType> SourceSlide_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<SlideSourceType> SourceSlide => SourceSlide_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								SourceSlide_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								SourceSlide_.UpdateMapOnInternalMapUpdate(_map);
							}

							public SlideImage()
								: this(new LoroMap())
							{
							}

							public SlideImage(LoroMap values)
							{
								_map = values;
								SourceSlide_ = new EnumObservableProperty<SlideSourceType>("source_slide__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(SourceSlide_.WhenChangeHappens);
							}

							public void Dispose()
							{
								SourceSlide_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								SourceSlide_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ISlideLabelColor : IEntity, IDisposable
						{
							IObservableProperty<SlideLabelSource> SlideLabelSource { get; }
						}

						internal sealed class SlideLabelColor : ISlideLabelColor, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<SlideLabelSource> SlideLabelSource_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<SlideLabelSource> SlideLabelSource => SlideLabelSource_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								SlideLabelSource_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								SlideLabelSource_.UpdateMapOnInternalMapUpdate(_map);
							}

							public SlideLabelColor()
								: this(new LoroMap())
							{
							}

							public SlideLabelColor(LoroMap values)
							{
								_map = values;
								SlideLabelSource_ = new EnumObservableProperty<SlideLabelSource>("slide_label_source__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(SlideLabelSource_.WhenChangeHappens);
							}

							public void Dispose()
							{
								SlideLabelSource_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								SlideLabelSource_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ISlideLabelText : IEntity, IDisposable
						{
							IObservableProperty<SlideLabelSource> SlideLabelSource { get; }
						}

						internal sealed class SlideLabelText : ISlideLabelText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<SlideLabelSource> SlideLabelSource_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<SlideLabelSource> SlideLabelSource => SlideLabelSource_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								SlideLabelSource_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								SlideLabelSource_.UpdateMapOnInternalMapUpdate(_map);
							}

							public SlideLabelText()
								: this(new LoroMap())
							{
							}

							public SlideLabelText(LoroMap values)
							{
								_map = values;
								SlideLabelSource_ = new EnumObservableProperty<SlideLabelSource>("slide_label_source__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(SlideLabelSource_.WhenChangeHappens);
							}

							public void Dispose()
							{
								SlideLabelSource_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								SlideLabelSource_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ISlideText : IEntity, IDisposable
						{
							public class Types
							{
								public enum TextSourceOption
								{
									Text,
									Notes,
									ElementMatchingName
								}
							}

							IObservableProperty<SlideSourceType> SourceSlide { get; }

							IObservableProperty<Types.TextSourceOption> SourceOption { get; }

							IObservableProperty<bool> PreserveNotesFormat { get; }

							IObservableProperty<string> NameToMatch { get; }

							IObservableProperty<IAlternateElementText.Types.TextTransformOption> ElementTextTransform { get; }
						}

						internal sealed class SlideText : ISlideText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<SlideSourceType> SourceSlide_;

							private EnumObservableProperty<ISlideText.Types.TextSourceOption> SourceOption_;

							private BoolObservableProperty PreserveNotesFormat_;

							private StringObservableProperty NameToMatch_;

							private EnumObservableProperty<IAlternateElementText.Types.TextTransformOption> ElementTextTransform_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<SlideSourceType> SourceSlide => SourceSlide_;

							public IObservableProperty<ISlideText.Types.TextSourceOption> SourceOption => SourceOption_;

							public IObservableProperty<bool> PreserveNotesFormat => PreserveNotesFormat_;

							public IObservableProperty<string> NameToMatch => NameToMatch_;

							public IObservableProperty<IAlternateElementText.Types.TextTransformOption> ElementTextTransform => ElementTextTransform_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								SourceSlide_.UpdateMap(_map);
								SourceOption_.UpdateMap(_map);
								PreserveNotesFormat_.UpdateMap(_map);
								NameToMatch_.UpdateMap(_map);
								ElementTextTransform_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								SourceSlide_.UpdateMapOnInternalMapUpdate(_map);
								SourceOption_.UpdateMapOnInternalMapUpdate(_map);
								PreserveNotesFormat_.UpdateMapOnInternalMapUpdate(_map);
								NameToMatch_.UpdateMapOnInternalMapUpdate(_map);
								ElementTextTransform_.UpdateMapOnInternalMapUpdate(_map);
							}

							public SlideText()
								: this(new LoroMap())
							{
							}

							public SlideText(LoroMap values)
							{
								_map = values;
								SourceSlide_ = new EnumObservableProperty<SlideSourceType>("source_slide__1", LoroMap);
								SourceOption_ = new EnumObservableProperty<ISlideText.Types.TextSourceOption>("source_option__2", LoroMap);
								PreserveNotesFormat_ = new BoolObservableProperty("preserve_notes_format__3", LoroMap);
								NameToMatch_ = new StringObservableProperty("name_to_match__4", LoroMap);
								ElementTextTransform_ = new EnumObservableProperty<IAlternateElementText.Types.TextTransformOption>("element_text_transform__5", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(SourceSlide_.WhenChangeHappens, SourceOption_.WhenChangeHappens, PreserveNotesFormat_.WhenChangeHappens, NameToMatch_.WhenChangeHappens, ElementTextTransform_.WhenChangeHappens);
							}

							public void Dispose()
							{
								SourceSlide_.Dispose();
								SourceOption_.Dispose();
								PreserveNotesFormat_.Dispose();
								NameToMatch_.Dispose();
								ElementTextTransform_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								SourceSlide_.OnDiff(path, diff);
								SourceOption_.OnDiff(path, diff);
								PreserveNotesFormat_.OnDiff(path, diff);
								NameToMatch_.OnDiff(path, diff);
								ElementTextTransform_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IStageMessage : IEntity, IDisposable
						{
							IObservableProperty<bool> ShouldFlash { get; }

							IObservableProperty<Color> FlashColor { get; }
						}

						internal sealed class StageMessage : IStageMessage, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private BoolObservableProperty ShouldFlash_;

							private AtomicObservableProperty<Color> FlashColor_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<bool> ShouldFlash => ShouldFlash_;

							public IObservableProperty<Color> FlashColor => FlashColor_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								ShouldFlash_.UpdateMap(_map);
								FlashColor_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								ShouldFlash_.UpdateMapOnInternalMapUpdate(_map);
								FlashColor_.UpdateMapOnInternalMapUpdate(_map);
							}

							public StageMessage()
								: this(new LoroMap())
							{
							}

							public StageMessage(LoroMap values)
							{
								_map = values;
								ShouldFlash_ = new BoolObservableProperty("should_flash__1", LoroMap);
								FlashColor_ = new AtomicObservableProperty<Color>("flash_color__2", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = ShouldFlash_.WhenChangeHappens.Merge(FlashColor_.WhenChangeHappens);
							}

							public void Dispose()
							{
								ShouldFlash_.Dispose();
								FlashColor_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								ShouldFlash_.OnDiff(path, diff);
								FlashColor_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ITicker : IEntity, IDisposable
						{
							public class Types
							{
								public interface IFileType : IEntity, IDisposable
								{
									IObservableProperty<Url> Url { get; }
								}

								internal sealed class FileType : IFileType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

									public FileType()
										: this(new LoroMap())
									{
									}

									public FileType(LoroMap values)
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

								public interface IRssType : IEntity, IDisposable
								{
									public class Types
									{
										public enum ContentType
										{
											TitleOnly,
											TitleAndDescription
										}
									}

									IObservableProperty<Url> Url { get; }

									IObservableProperty<Types.ContentType> Content { get; }
								}

								internal sealed class RssType : IRssType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
								{
									private LoroMap _map;

									private CompositeDisposable _linkedDisposables;

									private AtomicObservableProperty<Url> Url_;

									private EnumObservableProperty<IRssType.Types.ContentType> Content_;

									public LoroMap LoroMap => _map;

									public IObservable<Unit> WhenChangeHappens { get; }

									public IObservableProperty<Url> Url => Url_;

									public IObservableProperty<IRssType.Types.ContentType> Content => Content_;

									public void UpdateMap(LoroMap value)
									{
										_map = value;
										Url_.UpdateMap(_map);
										Content_.UpdateMap(_map);
									}

									public void UpdateMapOnInternalMapUpdate(LoroMap value)
									{
										_map = value;
										Url_.UpdateMapOnInternalMapUpdate(_map);
										Content_.UpdateMapOnInternalMapUpdate(_map);
									}

									public RssType()
										: this(new LoroMap())
									{
									}

									public RssType(LoroMap values)
									{
										_map = values;
										Url_ = new AtomicObservableProperty<Url>("url__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
										Content_ = new EnumObservableProperty<IRssType.Types.ContentType>("content__2", LoroMap);
										_linkedDisposables = new CompositeDisposable();
										WhenChangeHappens = Url_.WhenChangeHappens.Merge(Content_.WhenChangeHappens);
									}

									public void Dispose()
									{
										Url_.Dispose();
										Content_.Dispose();
										LoroMap.Dispose();
										_linkedDisposables.Dispose();
									}

									public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
									{
										Url_.OnDiff(path, diff);
										Content_.OnDiff(path, diff);
									}

									public void RegisterLinkedDisposable(IDisposable disposable)
									{
										_linkedDisposables.Add(disposable);
									}
								}

								public interface ITextType : IEntity, IDisposable
								{
									IObservableProperty<string> Text { get; }
								}

								internal sealed class TextType : ITextType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
								{
									private LoroMap _map;

									private CompositeDisposable _linkedDisposables;

									private StringObservableProperty Text_;

									public LoroMap LoroMap => _map;

									public IObservable<Unit> WhenChangeHappens { get; }

									public IObservableProperty<string> Text => Text_;

									public void UpdateMap(LoroMap value)
									{
										_map = value;
										Text_.UpdateMap(_map);
									}

									public void UpdateMapOnInternalMapUpdate(LoroMap value)
									{
										_map = value;
										Text_.UpdateMapOnInternalMapUpdate(_map);
									}

									public TextType()
										: this(new LoroMap())
									{
									}

									public TextType(LoroMap values)
									{
										_map = values;
										Text_ = new StringObservableProperty("text__1", LoroMap);
										_linkedDisposables = new CompositeDisposable();
										WhenChangeHappens = Observable.Merge<Unit>(Text_.WhenChangeHappens);
									}

									public void Dispose()
									{
										Text_.Dispose();
										LoroMap.Dispose();
										_linkedDisposables.Dispose();
									}

									public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
									{
										Text_.OnDiff(path, diff);
									}

									public void RegisterLinkedDisposable(IDisposable disposable)
									{
										_linkedDisposables.Add(disposable);
									}
								}

								public interface ISourceType : IEntity, IDisposable
								{
									public interface ITextType : ISourceType, IEntity, IDisposable, IObservableProperty<Types.ITextType>
									{
									}

									public interface IRssType : ISourceType, IEntity, IDisposable, IObservableProperty<Types.IRssType>
									{
									}

									public interface IFileType : ISourceType, IEntity, IDisposable, IObservableProperty<Types.IFileType>
									{
									}

									internal class TextType : ITextType, ISourceType, IEntity, IDisposable, IObservableProperty<Types.ITextType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<Types.ITextType> _TextType_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _TextType_.WhenChangeHappens;

										public IObservable<Types.ITextType> WhenValueChanges => _TextType_.WhenValueChanges;

										public Types.ITextType Value => _TextType_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_TextType_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_TextType_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "text_type__1".ToLoroValueLike());
											return loroMap;
										}

										public TextType()
											: this(InitializeMap())
										{
										}

										public TextType(LoroMap values)
										{
											_map = values;
											_TextType_ = new ComplexObservableProperty<Types.ITextType>("text_type__1", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_TextType_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_TextType_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_TextType_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(Types.ITextType value)
										{
											_TextType_.Set(value);
										}
									}

									internal class RssType : IRssType, ISourceType, IEntity, IDisposable, IObservableProperty<Types.IRssType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<Types.IRssType> _RssType_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _RssType_.WhenChangeHappens;

										public IObservable<Types.IRssType> WhenValueChanges => _RssType_.WhenValueChanges;

										public Types.IRssType Value => _RssType_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_RssType_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_RssType_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "rss_type__2".ToLoroValueLike());
											return loroMap;
										}

										public RssType()
											: this(InitializeMap())
										{
										}

										public RssType(LoroMap values)
										{
											_map = values;
											_RssType_ = new ComplexObservableProperty<Types.IRssType>("rss_type__2", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_RssType_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_RssType_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_RssType_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(Types.IRssType value)
										{
											_RssType_.Set(value);
										}
									}

									internal class FileType : IFileType, ISourceType, IEntity, IDisposable, IObservableProperty<Types.IFileType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<Types.IFileType> _FileType_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _FileType_.WhenChangeHappens;

										public IObservable<Types.IFileType> WhenValueChanges => _FileType_.WhenValueChanges;

										public Types.IFileType Value => _FileType_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_FileType_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_FileType_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "file_type__3".ToLoroValueLike());
											return loroMap;
										}

										public FileType()
											: this(InitializeMap())
										{
										}

										public FileType(LoroMap values)
										{
											_map = values;
											_FileType_ = new ComplexObservableProperty<Types.IFileType>("file_type__3", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_FileType_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_FileType_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_FileType_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(Types.IFileType value)
										{
											_FileType_.Set(value);
										}
									}
								}

								internal class SourceTypeFactory : IUnionValueFactory<ISourceType>
								{
									public string SelectionKey => "__tag";

									public ISourceType? CreateInstance(LoroMap map)
									{
										return map.Get("__tag").ToStringValue() switch
										{
											"text_type__1" => new ISourceType.TextType(map), 
											"rss_type__2" => new ISourceType.RssType(map), 
											"file_type__3" => new ISourceType.FileType(map), 
											_ => null, 
										};
									}

									public ISourceType CreateDefault(LoroMap map)
									{
										map.Insert("__tag", "text_type__1".ToLoroValueLike());
										return new ISourceType.TextType(map);
									}
								}
							}

							IObservableProperty<double> PlayRate { get; }

							IObservableProperty<bool> ShouldLoop { get; }

							IObservableProperty<double> LoopDelay { get; }

							IObservableProperty<string> TextDelimiter { get; }

							IComplexObservableProperty<Types.ISourceType> SourceType { get; }
						}

						internal sealed class Ticker : ITicker, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private DoubleObservableProperty PlayRate_;

							private BoolObservableProperty ShouldLoop_;

							private DoubleObservableProperty LoopDelay_;

							private StringObservableProperty TextDelimiter_;

							private UnionObservableProperty<ITicker.Types.ISourceType> SourceType_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<double> PlayRate => PlayRate_;

							public IObservableProperty<bool> ShouldLoop => ShouldLoop_;

							public IObservableProperty<double> LoopDelay => LoopDelay_;

							public IObservableProperty<string> TextDelimiter => TextDelimiter_;

							public IComplexObservableProperty<ITicker.Types.ISourceType> SourceType => SourceType_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								PlayRate_.UpdateMap(_map);
								ShouldLoop_.UpdateMap(_map);
								LoopDelay_.UpdateMap(_map);
								TextDelimiter_.UpdateMap(_map);
								SourceType_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								PlayRate_.UpdateMapOnInternalMapUpdate(_map);
								ShouldLoop_.UpdateMapOnInternalMapUpdate(_map);
								LoopDelay_.UpdateMapOnInternalMapUpdate(_map);
								TextDelimiter_.UpdateMapOnInternalMapUpdate(_map);
								SourceType_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Ticker()
								: this(new LoroMap())
							{
							}

							public Ticker(LoroMap values)
							{
								_map = values;
								PlayRate_ = new DoubleObservableProperty("play_rate__4", LoroMap);
								ShouldLoop_ = new BoolObservableProperty("should_loop__5", LoroMap);
								LoopDelay_ = new DoubleObservableProperty("loop_delay__6", LoroMap);
								TextDelimiter_ = new StringObservableProperty("text_delimiter__7", LoroMap);
								SourceType_ = new UnionObservableProperty<ITicker.Types.ISourceType>("SourceType__union", LoroMap, new ITicker.Types.SourceTypeFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(PlayRate_.WhenChangeHappens, ShouldLoop_.WhenChangeHappens, LoopDelay_.WhenChangeHappens, TextDelimiter_.WhenChangeHappens, SourceType_.WhenChangeHappens);
							}

							public void Dispose()
							{
								PlayRate_.Dispose();
								ShouldLoop_.Dispose();
								LoopDelay_.Dispose();
								TextDelimiter_.Dispose();
								SourceType_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								PlayRate_.OnDiff(path, diff);
								ShouldLoop_.OnDiff(path, diff);
								LoopDelay_.OnDiff(path, diff);
								TextDelimiter_.OnDiff(path, diff);
								SourceType_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ITimecodeStatus : IEntity, IDisposable
						{
						}

						internal sealed class TimecodeStatus : ITimecodeStatus, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public TimecodeStatus()
								: this(new LoroMap())
							{
							}

							public TimecodeStatus(LoroMap values)
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

						public interface ITimecodeText : IEntity, IDisposable
						{
						}

						internal sealed class TimecodeText : ITimecodeText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public TimecodeText()
								: this(new LoroMap())
							{
							}

							public TimecodeText(LoroMap values)
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

						public interface ITimerText : IEntity, IDisposable
						{
							IObservableProperty<Guid?> TimerUuid { get; }

							IObservableProperty<string?> TimerName { get; }

							IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat { get; }

							IObservableProperty<string> TimerFormatString { get; }

							IComplexCollection<IColorTrigger> ColorTriggers { get; }
						}

						internal sealed class TimerText : ITimerText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private OptionalGuidObservableProperty TimerUuid_;

							private OptionalStringObservableProperty TimerName_;

							private ComplexObservableProperty<ITimer.Types.IFormat> TimerFormat_;

							private StringObservableProperty TimerFormatString_;

							private MapCollection<IColorTrigger> ColorTriggers_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<Guid?> TimerUuid => TimerUuid_;

							public IObservableProperty<string?> TimerName => TimerName_;

							public IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat => TimerFormat_;

							public IObservableProperty<string> TimerFormatString => TimerFormatString_;

							public IComplexCollection<IColorTrigger> ColorTriggers => ColorTriggers_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								TimerUuid_.UpdateMap(_map);
								TimerName_.UpdateMap(_map);
								TimerFormat_.UpdateMap(_map);
								TimerFormatString_.UpdateMap(_map);
								ColorTriggers_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								TimerUuid_.UpdateMapOnInternalMapUpdate(_map);
								TimerName_.UpdateMapOnInternalMapUpdate(_map);
								TimerFormat_.UpdateMapOnInternalMapUpdate(_map);
								TimerFormatString_.UpdateMapOnInternalMapUpdate(_map);
								ColorTriggers_.UpdateMapOnInternalMapUpdate(_map);
							}

							public TimerText()
								: this(new LoroMap())
							{
							}

							public TimerText(LoroMap values)
							{
								_map = values;
								TimerUuid_ = new OptionalGuidObservableProperty("timer_uuid__1", LoroMap);
								TimerName_ = new OptionalStringObservableProperty("timer_name__2", LoroMap);
								TimerFormat_ = new ComplexObservableProperty<ITimer.Types.IFormat>("timer_format__3", LoroMap, new EntityFactory());
								TimerFormatString_ = new StringObservableProperty("timer_format_string__4", LoroMap);
								ColorTriggers_ = new MapCollection<IColorTrigger>(LoroMap, "color_triggers__5", new EntityFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(TimerUuid_.WhenChangeHappens, TimerName_.WhenChangeHappens, TimerFormat_.WhenChangeHappens, TimerFormatString_.WhenChangeHappens, ColorTriggers_.WhenChangeHappens);
							}

							public void Dispose()
							{
								TimerUuid_.Dispose();
								TimerName_.Dispose();
								TimerFormat_.Dispose();
								TimerFormatString_.Dispose();
								ColorTriggers_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								TimerUuid_.OnDiff(path, diff);
								TimerName_.OnDiff(path, diff);
								TimerFormat_.OnDiff(path, diff);
								TimerFormatString_.OnDiff(path, diff);
								ColorTriggers_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IVideoCountdown : IEntity, IDisposable
						{
							public class Types
							{
								public enum VideoCountdownSource
								{
									Presentation,
									Announcement
								}
							}

							IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat { get; }

							IObservableProperty<string> TimerFormatString { get; }

							IComplexCollection<IColorTrigger> ColorTriggers { get; }

							IObservableProperty<bool> IgnoreLoopingVideos { get; }

							IObservableProperty<Types.VideoCountdownSource> VideoCountdownSource { get; }
						}

						internal sealed class VideoCountdown : IVideoCountdown, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private ComplexObservableProperty<ITimer.Types.IFormat> TimerFormat_;

							private StringObservableProperty TimerFormatString_;

							private MapCollection<IColorTrigger> ColorTriggers_;

							private BoolObservableProperty IgnoreLoopingVideos_;

							private EnumObservableProperty<IVideoCountdown.Types.VideoCountdownSource> VideoCountdownSource_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IComplexObservableProperty<ITimer.Types.IFormat> TimerFormat => TimerFormat_;

							public IObservableProperty<string> TimerFormatString => TimerFormatString_;

							public IComplexCollection<IColorTrigger> ColorTriggers => ColorTriggers_;

							public IObservableProperty<bool> IgnoreLoopingVideos => IgnoreLoopingVideos_;

							public IObservableProperty<IVideoCountdown.Types.VideoCountdownSource> VideoCountdownSource => VideoCountdownSource_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								TimerFormat_.UpdateMap(_map);
								TimerFormatString_.UpdateMap(_map);
								ColorTriggers_.UpdateMap(_map);
								IgnoreLoopingVideos_.UpdateMap(_map);
								VideoCountdownSource_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								TimerFormat_.UpdateMapOnInternalMapUpdate(_map);
								TimerFormatString_.UpdateMapOnInternalMapUpdate(_map);
								ColorTriggers_.UpdateMapOnInternalMapUpdate(_map);
								IgnoreLoopingVideos_.UpdateMapOnInternalMapUpdate(_map);
								VideoCountdownSource_.UpdateMapOnInternalMapUpdate(_map);
							}

							public VideoCountdown()
								: this(new LoroMap())
							{
							}

							public VideoCountdown(LoroMap values)
							{
								_map = values;
								TimerFormat_ = new ComplexObservableProperty<ITimer.Types.IFormat>("timer_format__1", LoroMap, new EntityFactory());
								TimerFormatString_ = new StringObservableProperty("timer_format_string__2", LoroMap);
								ColorTriggers_ = new MapCollection<IColorTrigger>(LoroMap, "color_triggers__3", new EntityFactory());
								IgnoreLoopingVideos_ = new BoolObservableProperty("ignore_looping_videos__4", LoroMap);
								VideoCountdownSource_ = new EnumObservableProperty<IVideoCountdown.Types.VideoCountdownSource>("video_countdown_source__5", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(TimerFormat_.WhenChangeHappens, TimerFormatString_.WhenChangeHappens, ColorTriggers_.WhenChangeHappens, IgnoreLoopingVideos_.WhenChangeHappens, VideoCountdownSource_.WhenChangeHappens);
							}

							public void Dispose()
							{
								TimerFormat_.Dispose();
								TimerFormatString_.Dispose();
								ColorTriggers_.Dispose();
								IgnoreLoopingVideos_.Dispose();
								VideoCountdownSource_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								TimerFormat_.OnDiff(path, diff);
								TimerFormatString_.OnDiff(path, diff);
								ColorTriggers_.OnDiff(path, diff);
								IgnoreLoopingVideos_.OnDiff(path, diff);
								VideoCountdownSource_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IVisibilityLink : IEntity, IDisposable
						{
							public class Types
							{
								public interface ICondition : IEntity, IDisposable
								{
									public class Types
									{
										public interface IAudioCountdownVisibility : IEntity, IDisposable
										{
											public class Types
											{
												public enum AudioCountdownVisibilityCriterion
												{
													HasTimeRemaining,
													HasExpired,
													IsRunning,
													NotRunning,
													Looping,
													NotLooping
												}
											}

											IObservableProperty<Types.AudioCountdownVisibilityCriterion> VisibilityCriterion { get; }
										}

										internal sealed class AudioCountdownVisibility : IAudioCountdownVisibility, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
										{
											private LoroMap _map;

											private CompositeDisposable _linkedDisposables;

											private EnumObservableProperty<IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion> VisibilityCriterion_;

											public LoroMap LoroMap => _map;

											public IObservable<Unit> WhenChangeHappens { get; }

											public IObservableProperty<IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion> VisibilityCriterion => VisibilityCriterion_;

											public void UpdateMap(LoroMap value)
											{
												_map = value;
												VisibilityCriterion_.UpdateMap(_map);
											}

											public void UpdateMapOnInternalMapUpdate(LoroMap value)
											{
												_map = value;
												VisibilityCriterion_.UpdateMapOnInternalMapUpdate(_map);
											}

											public AudioCountdownVisibility()
												: this(new LoroMap())
											{
											}

											public AudioCountdownVisibility(LoroMap values)
											{
												_map = values;
												VisibilityCriterion_ = new EnumObservableProperty<IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion>("visibility_criterion__1", LoroMap);
												_linkedDisposables = new CompositeDisposable();
												WhenChangeHappens = Observable.Merge<Unit>(VisibilityCriterion_.WhenChangeHappens);
											}

											public void Dispose()
											{
												VisibilityCriterion_.Dispose();
												LoroMap.Dispose();
												_linkedDisposables.Dispose();
											}

											public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
											{
												VisibilityCriterion_.OnDiff(path, diff);
											}

											public void RegisterLinkedDisposable(IDisposable disposable)
											{
												_linkedDisposables.Add(disposable);
											}
										}

										public interface ICaptureSessionVisibility : IEntity, IDisposable
										{
											public class Types
											{
												public enum CaptureSessionVisibilityCriterion
												{
													Active,
													Inactive
												}
											}

											IObservableProperty<Types.CaptureSessionVisibilityCriterion> VisibilityCriterion { get; }
										}

										internal sealed class CaptureSessionVisibility : ICaptureSessionVisibility, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
										{
											private LoroMap _map;

											private CompositeDisposable _linkedDisposables;

											private EnumObservableProperty<ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion> VisibilityCriterion_;

											public LoroMap LoroMap => _map;

											public IObservable<Unit> WhenChangeHappens { get; }

											public IObservableProperty<ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion> VisibilityCriterion => VisibilityCriterion_;

											public void UpdateMap(LoroMap value)
											{
												_map = value;
												VisibilityCriterion_.UpdateMap(_map);
											}

											public void UpdateMapOnInternalMapUpdate(LoroMap value)
											{
												_map = value;
												VisibilityCriterion_.UpdateMapOnInternalMapUpdate(_map);
											}

											public CaptureSessionVisibility()
												: this(new LoroMap())
											{
											}

											public CaptureSessionVisibility(LoroMap values)
											{
												_map = values;
												VisibilityCriterion_ = new EnumObservableProperty<ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion>("visibility_criterion__1", LoroMap);
												_linkedDisposables = new CompositeDisposable();
												WhenChangeHappens = Observable.Merge<Unit>(VisibilityCriterion_.WhenChangeHappens);
											}

											public void Dispose()
											{
												VisibilityCriterion_.Dispose();
												LoroMap.Dispose();
												_linkedDisposables.Dispose();
											}

											public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
											{
												VisibilityCriterion_.OnDiff(path, diff);
											}

											public void RegisterLinkedDisposable(IDisposable disposable)
											{
												_linkedDisposables.Add(disposable);
											}
										}

										public interface IElementVisibility : IEntity, IDisposable
										{
											public class Types
											{
												public enum ElementVisibilityCriterion
												{
													HasText,
													HasNoText
												}
											}

											IObservableProperty<Guid?> OtherElementUuid { get; }

											IObservableProperty<string?> OtherElementName { get; }

											IObservableProperty<Types.ElementVisibilityCriterion> VisibilityCriterion { get; }
										}

										internal sealed class ElementVisibility : IElementVisibility, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
										{
											private LoroMap _map;

											private CompositeDisposable _linkedDisposables;

											private OptionalGuidObservableProperty OtherElementUuid_;

											private OptionalStringObservableProperty OtherElementName_;

											private EnumObservableProperty<IElementVisibility.Types.ElementVisibilityCriterion> VisibilityCriterion_;

											public LoroMap LoroMap => _map;

											public IObservable<Unit> WhenChangeHappens { get; }

											public IObservableProperty<Guid?> OtherElementUuid => OtherElementUuid_;

											public IObservableProperty<string?> OtherElementName => OtherElementName_;

											public IObservableProperty<IElementVisibility.Types.ElementVisibilityCriterion> VisibilityCriterion => VisibilityCriterion_;

											public void UpdateMap(LoroMap value)
											{
												_map = value;
												OtherElementUuid_.UpdateMap(_map);
												OtherElementName_.UpdateMap(_map);
												VisibilityCriterion_.UpdateMap(_map);
											}

											public void UpdateMapOnInternalMapUpdate(LoroMap value)
											{
												_map = value;
												OtherElementUuid_.UpdateMapOnInternalMapUpdate(_map);
												OtherElementName_.UpdateMapOnInternalMapUpdate(_map);
												VisibilityCriterion_.UpdateMapOnInternalMapUpdate(_map);
											}

											public ElementVisibility()
												: this(new LoroMap())
											{
											}

											public ElementVisibility(LoroMap values)
											{
												_map = values;
												OtherElementUuid_ = new OptionalGuidObservableProperty("other_element_uuid__1", LoroMap);
												OtherElementName_ = new OptionalStringObservableProperty("other_element_name__2", LoroMap);
												VisibilityCriterion_ = new EnumObservableProperty<IElementVisibility.Types.ElementVisibilityCriterion>("visibility_criterion__3", LoroMap);
												_linkedDisposables = new CompositeDisposable();
												WhenChangeHappens = Observable.Merge<Unit>(OtherElementUuid_.WhenChangeHappens, OtherElementName_.WhenChangeHappens, VisibilityCriterion_.WhenChangeHappens);
											}

											public void Dispose()
											{
												OtherElementUuid_.Dispose();
												OtherElementName_.Dispose();
												VisibilityCriterion_.Dispose();
												LoroMap.Dispose();
												_linkedDisposables.Dispose();
											}

											public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
											{
												OtherElementUuid_.OnDiff(path, diff);
												OtherElementName_.OnDiff(path, diff);
												VisibilityCriterion_.OnDiff(path, diff);
											}

											public void RegisterLinkedDisposable(IDisposable disposable)
											{
												_linkedDisposables.Add(disposable);
											}
										}

										public interface ITimerVisibility : IEntity, IDisposable
										{
											public class Types
											{
												public enum TimerVisibilityCriterion
												{
													HasTimeRemaining,
													HasExpired,
													IsRunning,
													NotRunning
												}
											}

											IObservableProperty<Guid?> TimerUuid { get; }

											IObservableProperty<string?> TimerName { get; }

											IObservableProperty<Types.TimerVisibilityCriterion> VisibilityCriterion { get; }
										}

										internal sealed class TimerVisibility : ITimerVisibility, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
										{
											private LoroMap _map;

											private CompositeDisposable _linkedDisposables;

											private OptionalGuidObservableProperty TimerUuid_;

											private OptionalStringObservableProperty TimerName_;

											private EnumObservableProperty<ITimerVisibility.Types.TimerVisibilityCriterion> VisibilityCriterion_;

											public LoroMap LoroMap => _map;

											public IObservable<Unit> WhenChangeHappens { get; }

											public IObservableProperty<Guid?> TimerUuid => TimerUuid_;

											public IObservableProperty<string?> TimerName => TimerName_;

											public IObservableProperty<ITimerVisibility.Types.TimerVisibilityCriterion> VisibilityCriterion => VisibilityCriterion_;

											public void UpdateMap(LoroMap value)
											{
												_map = value;
												TimerUuid_.UpdateMap(_map);
												TimerName_.UpdateMap(_map);
												VisibilityCriterion_.UpdateMap(_map);
											}

											public void UpdateMapOnInternalMapUpdate(LoroMap value)
											{
												_map = value;
												TimerUuid_.UpdateMapOnInternalMapUpdate(_map);
												TimerName_.UpdateMapOnInternalMapUpdate(_map);
												VisibilityCriterion_.UpdateMapOnInternalMapUpdate(_map);
											}

											public TimerVisibility()
												: this(new LoroMap())
											{
											}

											public TimerVisibility(LoroMap values)
											{
												_map = values;
												TimerUuid_ = new OptionalGuidObservableProperty("timer_uuid__1", LoroMap);
												TimerName_ = new OptionalStringObservableProperty("timer_name__2", LoroMap);
												VisibilityCriterion_ = new EnumObservableProperty<ITimerVisibility.Types.TimerVisibilityCriterion>("visibility_criterion__3", LoroMap);
												_linkedDisposables = new CompositeDisposable();
												WhenChangeHappens = Observable.Merge<Unit>(TimerUuid_.WhenChangeHappens, TimerName_.WhenChangeHappens, VisibilityCriterion_.WhenChangeHappens);
											}

											public void Dispose()
											{
												TimerUuid_.Dispose();
												TimerName_.Dispose();
												VisibilityCriterion_.Dispose();
												LoroMap.Dispose();
												_linkedDisposables.Dispose();
											}

											public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
											{
												TimerUuid_.OnDiff(path, diff);
												TimerName_.OnDiff(path, diff);
												VisibilityCriterion_.OnDiff(path, diff);
											}

											public void RegisterLinkedDisposable(IDisposable disposable)
											{
												_linkedDisposables.Add(disposable);
											}
										}

										public interface IVideoCountdownVisibility : IEntity, IDisposable
										{
											public class Types
											{
												public enum VideoCountdownVisibilityCriterion
												{
													HasTimeRemaining,
													HasExpired,
													IsRunning,
													NotRunning,
													Looping,
													NotLooping
												}
											}

											IObservableProperty<Types.VideoCountdownVisibilityCriterion> VisibilityCriterion { get; }
										}

										internal sealed class VideoCountdownVisibility : IVideoCountdownVisibility, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
										{
											private LoroMap _map;

											private CompositeDisposable _linkedDisposables;

											private EnumObservableProperty<IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion> VisibilityCriterion_;

											public LoroMap LoroMap => _map;

											public IObservable<Unit> WhenChangeHappens { get; }

											public IObservableProperty<IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion> VisibilityCriterion => VisibilityCriterion_;

											public void UpdateMap(LoroMap value)
											{
												_map = value;
												VisibilityCriterion_.UpdateMap(_map);
											}

											public void UpdateMapOnInternalMapUpdate(LoroMap value)
											{
												_map = value;
												VisibilityCriterion_.UpdateMapOnInternalMapUpdate(_map);
											}

											public VideoCountdownVisibility()
												: this(new LoroMap())
											{
											}

											public VideoCountdownVisibility(LoroMap values)
											{
												_map = values;
												VisibilityCriterion_ = new EnumObservableProperty<IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion>("visibility_criterion__1", LoroMap);
												_linkedDisposables = new CompositeDisposable();
												WhenChangeHappens = Observable.Merge<Unit>(VisibilityCriterion_.WhenChangeHappens);
											}

											public void Dispose()
											{
												VisibilityCriterion_.Dispose();
												LoroMap.Dispose();
												_linkedDisposables.Dispose();
											}

											public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
											{
												VisibilityCriterion_.OnDiff(path, diff);
											}

											public void RegisterLinkedDisposable(IDisposable disposable)
											{
												_linkedDisposables.Add(disposable);
											}
										}

										public interface IVideoInputVisibility : IEntity, IDisposable
										{
											public class Types
											{
												public enum VideoInputVisibilityCriterion
												{
													Active,
													Inactive
												}
											}

											IObservableProperty<int> VideoInputIndex { get; }

											IObservableProperty<Types.VideoInputVisibilityCriterion> VisibilityCriterion { get; }
										}

										internal sealed class VideoInputVisibility : IVideoInputVisibility, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
										{
											private LoroMap _map;

											private CompositeDisposable _linkedDisposables;

											private IntObservableProperty VideoInputIndex_;

											private EnumObservableProperty<IVideoInputVisibility.Types.VideoInputVisibilityCriterion> VisibilityCriterion_;

											public LoroMap LoroMap => _map;

											public IObservable<Unit> WhenChangeHappens { get; }

											public IObservableProperty<int> VideoInputIndex => VideoInputIndex_;

											public IObservableProperty<IVideoInputVisibility.Types.VideoInputVisibilityCriterion> VisibilityCriterion => VisibilityCriterion_;

											public void UpdateMap(LoroMap value)
											{
												_map = value;
												VideoInputIndex_.UpdateMap(_map);
												VisibilityCriterion_.UpdateMap(_map);
											}

											public void UpdateMapOnInternalMapUpdate(LoroMap value)
											{
												_map = value;
												VideoInputIndex_.UpdateMapOnInternalMapUpdate(_map);
												VisibilityCriterion_.UpdateMapOnInternalMapUpdate(_map);
											}

											public VideoInputVisibility()
												: this(new LoroMap())
											{
											}

											public VideoInputVisibility(LoroMap values)
											{
												_map = values;
												VideoInputIndex_ = new IntObservableProperty("video_input_index__1", LoroMap);
												VisibilityCriterion_ = new EnumObservableProperty<IVideoInputVisibility.Types.VideoInputVisibilityCriterion>("visibility_criterion__2", LoroMap);
												_linkedDisposables = new CompositeDisposable();
												WhenChangeHappens = VideoInputIndex_.WhenChangeHappens.Merge(VisibilityCriterion_.WhenChangeHappens);
											}

											public void Dispose()
											{
												VideoInputIndex_.Dispose();
												VisibilityCriterion_.Dispose();
												LoroMap.Dispose();
												_linkedDisposables.Dispose();
											}

											public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
											{
												VideoInputIndex_.OnDiff(path, diff);
												VisibilityCriterion_.OnDiff(path, diff);
											}

											public void RegisterLinkedDisposable(IDisposable disposable)
											{
												_linkedDisposables.Add(disposable);
											}
										}

										public interface IConditionType : IEntity, IDisposable
										{
											public interface IElementVisibility : IConditionType, IEntity, IDisposable, IObservableProperty<Types.IElementVisibility>
											{
											}

											public interface ITimerVisibility : IConditionType, IEntity, IDisposable, IObservableProperty<Types.ITimerVisibility>
											{
											}

											public interface IVideoCountdownVisibility : IConditionType, IEntity, IDisposable, IObservableProperty<Types.IVideoCountdownVisibility>
											{
											}

											public interface ICaptureSessionVisibility : IConditionType, IEntity, IDisposable, IObservableProperty<Types.ICaptureSessionVisibility>
											{
											}

											public interface IVideoInputVisibility : IConditionType, IEntity, IDisposable, IObservableProperty<Types.IVideoInputVisibility>
											{
											}

											public interface IAudioCountdownVisibility : IConditionType, IEntity, IDisposable, IObservableProperty<Types.IAudioCountdownVisibility>
											{
											}

											internal class ElementVisibility : IElementVisibility, IConditionType, IEntity, IDisposable, IObservableProperty<Types.IElementVisibility>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
											{
												private LoroMap _map;

												private ComplexObservableProperty<Types.IElementVisibility> _ElementVisibility_;

												public LoroMap LoroMap => _map;

												public IObservable<Unit> WhenChangeHappens => _ElementVisibility_.WhenChangeHappens;

												public IObservable<Types.IElementVisibility> WhenValueChanges => _ElementVisibility_.WhenValueChanges;

												public Types.IElementVisibility Value => _ElementVisibility_.Value;

												public void UpdateMap(LoroMap value)
												{
													_map = value;
													_ElementVisibility_.UpdateMap(_map);
												}

												public void UpdateMapOnInternalMapUpdate(LoroMap value)
												{
													_map = value;
													_ElementVisibility_.UpdateMapOnInternalMapUpdate(_map);
												}

												private static LoroMap InitializeMap()
												{
													LoroMap loroMap = new LoroMap();
													loroMap.Insert("__tag", "element_visibility__1".ToLoroValueLike());
													return loroMap;
												}

												public ElementVisibility()
													: this(InitializeMap())
												{
												}

												public ElementVisibility(LoroMap values)
												{
													_map = values;
													_ElementVisibility_ = new ComplexObservableProperty<Types.IElementVisibility>("element_visibility__1", LoroMap, new EntityFactory());
												}

												public void Dispose()
												{
													_ElementVisibility_.Dispose();
													LoroMap.Dispose();
												}

												public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
												{
													_ElementVisibility_.OnDiff(path, diff);
												}

												public void RegisterLinkedDisposable(IDisposable disposable)
												{
													_ElementVisibility_.Value.RegisterLinkedDisposable(disposable);
												}

												public void Set(Types.IElementVisibility value)
												{
													_ElementVisibility_.Set(value);
												}
											}

											internal class TimerVisibility : ITimerVisibility, IConditionType, IEntity, IDisposable, IObservableProperty<Types.ITimerVisibility>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
											{
												private LoroMap _map;

												private ComplexObservableProperty<Types.ITimerVisibility> _TimerVisibility_;

												public LoroMap LoroMap => _map;

												public IObservable<Unit> WhenChangeHappens => _TimerVisibility_.WhenChangeHappens;

												public IObservable<Types.ITimerVisibility> WhenValueChanges => _TimerVisibility_.WhenValueChanges;

												public Types.ITimerVisibility Value => _TimerVisibility_.Value;

												public void UpdateMap(LoroMap value)
												{
													_map = value;
													_TimerVisibility_.UpdateMap(_map);
												}

												public void UpdateMapOnInternalMapUpdate(LoroMap value)
												{
													_map = value;
													_TimerVisibility_.UpdateMapOnInternalMapUpdate(_map);
												}

												private static LoroMap InitializeMap()
												{
													LoroMap loroMap = new LoroMap();
													loroMap.Insert("__tag", "timer_visibility__2".ToLoroValueLike());
													return loroMap;
												}

												public TimerVisibility()
													: this(InitializeMap())
												{
												}

												public TimerVisibility(LoroMap values)
												{
													_map = values;
													_TimerVisibility_ = new ComplexObservableProperty<Types.ITimerVisibility>("timer_visibility__2", LoroMap, new EntityFactory());
												}

												public void Dispose()
												{
													_TimerVisibility_.Dispose();
													LoroMap.Dispose();
												}

												public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
												{
													_TimerVisibility_.OnDiff(path, diff);
												}

												public void RegisterLinkedDisposable(IDisposable disposable)
												{
													_TimerVisibility_.Value.RegisterLinkedDisposable(disposable);
												}

												public void Set(Types.ITimerVisibility value)
												{
													_TimerVisibility_.Set(value);
												}
											}

											internal class VideoCountdownVisibility : IVideoCountdownVisibility, IConditionType, IEntity, IDisposable, IObservableProperty<Types.IVideoCountdownVisibility>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
											{
												private LoroMap _map;

												private ComplexObservableProperty<Types.IVideoCountdownVisibility> _VideoCountdownVisibility_;

												public LoroMap LoroMap => _map;

												public IObservable<Unit> WhenChangeHappens => _VideoCountdownVisibility_.WhenChangeHappens;

												public IObservable<Types.IVideoCountdownVisibility> WhenValueChanges => _VideoCountdownVisibility_.WhenValueChanges;

												public Types.IVideoCountdownVisibility Value => _VideoCountdownVisibility_.Value;

												public void UpdateMap(LoroMap value)
												{
													_map = value;
													_VideoCountdownVisibility_.UpdateMap(_map);
												}

												public void UpdateMapOnInternalMapUpdate(LoroMap value)
												{
													_map = value;
													_VideoCountdownVisibility_.UpdateMapOnInternalMapUpdate(_map);
												}

												private static LoroMap InitializeMap()
												{
													LoroMap loroMap = new LoroMap();
													loroMap.Insert("__tag", "video_countdown_visibility__3".ToLoroValueLike());
													return loroMap;
												}

												public VideoCountdownVisibility()
													: this(InitializeMap())
												{
												}

												public VideoCountdownVisibility(LoroMap values)
												{
													_map = values;
													_VideoCountdownVisibility_ = new ComplexObservableProperty<Types.IVideoCountdownVisibility>("video_countdown_visibility__3", LoroMap, new EntityFactory());
												}

												public void Dispose()
												{
													_VideoCountdownVisibility_.Dispose();
													LoroMap.Dispose();
												}

												public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
												{
													_VideoCountdownVisibility_.OnDiff(path, diff);
												}

												public void RegisterLinkedDisposable(IDisposable disposable)
												{
													_VideoCountdownVisibility_.Value.RegisterLinkedDisposable(disposable);
												}

												public void Set(Types.IVideoCountdownVisibility value)
												{
													_VideoCountdownVisibility_.Set(value);
												}
											}

											internal class CaptureSessionVisibility : ICaptureSessionVisibility, IConditionType, IEntity, IDisposable, IObservableProperty<Types.ICaptureSessionVisibility>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
											{
												private LoroMap _map;

												private ComplexObservableProperty<Types.ICaptureSessionVisibility> _CaptureSessionVisibility_;

												public LoroMap LoroMap => _map;

												public IObservable<Unit> WhenChangeHappens => _CaptureSessionVisibility_.WhenChangeHappens;

												public IObservable<Types.ICaptureSessionVisibility> WhenValueChanges => _CaptureSessionVisibility_.WhenValueChanges;

												public Types.ICaptureSessionVisibility Value => _CaptureSessionVisibility_.Value;

												public void UpdateMap(LoroMap value)
												{
													_map = value;
													_CaptureSessionVisibility_.UpdateMap(_map);
												}

												public void UpdateMapOnInternalMapUpdate(LoroMap value)
												{
													_map = value;
													_CaptureSessionVisibility_.UpdateMapOnInternalMapUpdate(_map);
												}

												private static LoroMap InitializeMap()
												{
													LoroMap loroMap = new LoroMap();
													loroMap.Insert("__tag", "capture_session_visibility__4".ToLoroValueLike());
													return loroMap;
												}

												public CaptureSessionVisibility()
													: this(InitializeMap())
												{
												}

												public CaptureSessionVisibility(LoroMap values)
												{
													_map = values;
													_CaptureSessionVisibility_ = new ComplexObservableProperty<Types.ICaptureSessionVisibility>("capture_session_visibility__4", LoroMap, new EntityFactory());
												}

												public void Dispose()
												{
													_CaptureSessionVisibility_.Dispose();
													LoroMap.Dispose();
												}

												public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
												{
													_CaptureSessionVisibility_.OnDiff(path, diff);
												}

												public void RegisterLinkedDisposable(IDisposable disposable)
												{
													_CaptureSessionVisibility_.Value.RegisterLinkedDisposable(disposable);
												}

												public void Set(Types.ICaptureSessionVisibility value)
												{
													_CaptureSessionVisibility_.Set(value);
												}
											}

											internal class VideoInputVisibility : IVideoInputVisibility, IConditionType, IEntity, IDisposable, IObservableProperty<Types.IVideoInputVisibility>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
											{
												private LoroMap _map;

												private ComplexObservableProperty<Types.IVideoInputVisibility> _VideoInputVisibility_;

												public LoroMap LoroMap => _map;

												public IObservable<Unit> WhenChangeHappens => _VideoInputVisibility_.WhenChangeHappens;

												public IObservable<Types.IVideoInputVisibility> WhenValueChanges => _VideoInputVisibility_.WhenValueChanges;

												public Types.IVideoInputVisibility Value => _VideoInputVisibility_.Value;

												public void UpdateMap(LoroMap value)
												{
													_map = value;
													_VideoInputVisibility_.UpdateMap(_map);
												}

												public void UpdateMapOnInternalMapUpdate(LoroMap value)
												{
													_map = value;
													_VideoInputVisibility_.UpdateMapOnInternalMapUpdate(_map);
												}

												private static LoroMap InitializeMap()
												{
													LoroMap loroMap = new LoroMap();
													loroMap.Insert("__tag", "video_input_visibility__5".ToLoroValueLike());
													return loroMap;
												}

												public VideoInputVisibility()
													: this(InitializeMap())
												{
												}

												public VideoInputVisibility(LoroMap values)
												{
													_map = values;
													_VideoInputVisibility_ = new ComplexObservableProperty<Types.IVideoInputVisibility>("video_input_visibility__5", LoroMap, new EntityFactory());
												}

												public void Dispose()
												{
													_VideoInputVisibility_.Dispose();
													LoroMap.Dispose();
												}

												public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
												{
													_VideoInputVisibility_.OnDiff(path, diff);
												}

												public void RegisterLinkedDisposable(IDisposable disposable)
												{
													_VideoInputVisibility_.Value.RegisterLinkedDisposable(disposable);
												}

												public void Set(Types.IVideoInputVisibility value)
												{
													_VideoInputVisibility_.Set(value);
												}
											}

											internal class AudioCountdownVisibility : IAudioCountdownVisibility, IConditionType, IEntity, IDisposable, IObservableProperty<Types.IAudioCountdownVisibility>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
											{
												private LoroMap _map;

												private ComplexObservableProperty<Types.IAudioCountdownVisibility> _AudioCountdownVisibility_;

												public LoroMap LoroMap => _map;

												public IObservable<Unit> WhenChangeHappens => _AudioCountdownVisibility_.WhenChangeHappens;

												public IObservable<Types.IAudioCountdownVisibility> WhenValueChanges => _AudioCountdownVisibility_.WhenValueChanges;

												public Types.IAudioCountdownVisibility Value => _AudioCountdownVisibility_.Value;

												public void UpdateMap(LoroMap value)
												{
													_map = value;
													_AudioCountdownVisibility_.UpdateMap(_map);
												}

												public void UpdateMapOnInternalMapUpdate(LoroMap value)
												{
													_map = value;
													_AudioCountdownVisibility_.UpdateMapOnInternalMapUpdate(_map);
												}

												private static LoroMap InitializeMap()
												{
													LoroMap loroMap = new LoroMap();
													loroMap.Insert("__tag", "audio_countdown_visibility__6".ToLoroValueLike());
													return loroMap;
												}

												public AudioCountdownVisibility()
													: this(InitializeMap())
												{
												}

												public AudioCountdownVisibility(LoroMap values)
												{
													_map = values;
													_AudioCountdownVisibility_ = new ComplexObservableProperty<Types.IAudioCountdownVisibility>("audio_countdown_visibility__6", LoroMap, new EntityFactory());
												}

												public void Dispose()
												{
													_AudioCountdownVisibility_.Dispose();
													LoroMap.Dispose();
												}

												public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
												{
													_AudioCountdownVisibility_.OnDiff(path, diff);
												}

												public void RegisterLinkedDisposable(IDisposable disposable)
												{
													_AudioCountdownVisibility_.Value.RegisterLinkedDisposable(disposable);
												}

												public void Set(Types.IAudioCountdownVisibility value)
												{
													_AudioCountdownVisibility_.Set(value);
												}
											}
										}

										internal class ConditionTypeFactory : IUnionValueFactory<IConditionType>
										{
											public string SelectionKey => "__tag";

											public IConditionType? CreateInstance(LoroMap map)
											{
												return map.Get("__tag").ToStringValue() switch
												{
													"element_visibility__1" => new IConditionType.ElementVisibility(map), 
													"timer_visibility__2" => new IConditionType.TimerVisibility(map), 
													"video_countdown_visibility__3" => new IConditionType.VideoCountdownVisibility(map), 
													"capture_session_visibility__4" => new IConditionType.CaptureSessionVisibility(map), 
													"video_input_visibility__5" => new IConditionType.VideoInputVisibility(map), 
													"audio_countdown_visibility__6" => new IConditionType.AudioCountdownVisibility(map), 
													_ => null, 
												};
											}

											public IConditionType CreateDefault(LoroMap map)
											{
												map.Insert("__tag", "element_visibility__1".ToLoroValueLike());
												return new IConditionType.ElementVisibility(map);
											}
										}
									}

									IComplexObservableProperty<Types.IConditionType> ConditionType { get; }
								}

								internal sealed class Condition : ICondition, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
								{
									private LoroMap _map;

									private CompositeDisposable _linkedDisposables;

									private UnionObservableProperty<ICondition.Types.IConditionType> ConditionType_;

									public LoroMap LoroMap => _map;

									public IObservable<Unit> WhenChangeHappens { get; }

									public IComplexObservableProperty<ICondition.Types.IConditionType> ConditionType => ConditionType_;

									public void UpdateMap(LoroMap value)
									{
										_map = value;
										ConditionType_.UpdateMap(_map);
									}

									public void UpdateMapOnInternalMapUpdate(LoroMap value)
									{
										_map = value;
										ConditionType_.UpdateMapOnInternalMapUpdate(_map);
									}

									public Condition()
										: this(new LoroMap())
									{
									}

									public Condition(LoroMap values)
									{
										_map = values;
										ConditionType_ = new UnionObservableProperty<ICondition.Types.IConditionType>("ConditionType__union", LoroMap, new ICondition.Types.ConditionTypeFactory());
										_linkedDisposables = new CompositeDisposable();
										WhenChangeHappens = Observable.Merge<Unit>(ConditionType_.WhenChangeHappens);
									}

									public void Dispose()
									{
										ConditionType_.Dispose();
										LoroMap.Dispose();
										_linkedDisposables.Dispose();
									}

									public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
									{
										ConditionType_.OnDiff(path, diff);
									}

									public void RegisterLinkedDisposable(IDisposable disposable)
									{
										_linkedDisposables.Add(disposable);
									}
								}

								public enum VisibilityCriterion
								{
									All,
									Any,
									None
								}
							}

							IObservableProperty<Types.VisibilityCriterion> VisibilityCriterion { get; }

							IComplexCollection<Types.ICondition> Conditions { get; }
						}

						internal sealed class VisibilityLink : IVisibilityLink, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<IVisibilityLink.Types.VisibilityCriterion> VisibilityCriterion_;

							private MapCollection<IVisibilityLink.Types.ICondition> Conditions_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<IVisibilityLink.Types.VisibilityCriterion> VisibilityCriterion => VisibilityCriterion_;

							public IComplexCollection<IVisibilityLink.Types.ICondition> Conditions => Conditions_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								VisibilityCriterion_.UpdateMap(_map);
								Conditions_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								VisibilityCriterion_.UpdateMapOnInternalMapUpdate(_map);
								Conditions_.UpdateMapOnInternalMapUpdate(_map);
							}

							public VisibilityLink()
								: this(new LoroMap())
							{
							}

							public VisibilityLink(LoroMap values)
							{
								_map = values;
								VisibilityCriterion_ = new EnumObservableProperty<IVisibilityLink.Types.VisibilityCriterion>("visibility_criterion__1", LoroMap);
								Conditions_ = new MapCollection<IVisibilityLink.Types.ICondition>(LoroMap, "conditions__2", new EntityFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = VisibilityCriterion_.WhenChangeHappens.Merge(Conditions_.WhenChangeHappens);
							}

							public void Dispose()
							{
								VisibilityCriterion_.Dispose();
								Conditions_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								VisibilityCriterion_.OnDiff(path, diff);
								Conditions_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public enum GroupSourceType
						{
							CurrentSlide,
							NextSlide,
							NextGroup
						}

						public enum SlideLabelSource
						{
							CurrentSlide,
							NextSlide
						}

						public enum SlideSourceType
						{
							CurrentSlide,
							NextSlide
						}

						public interface IPropertyType : IEntity, IDisposable
						{
							public interface ITicker : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ITicker>
							{
							}

							public interface IAlternateText : IPropertyType, IEntity, IDisposable, IObservableProperty<IAlternateElementText>
							{
							}

							public interface ITimerText : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ITimerText>
							{
							}

							public interface IClockText : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IClockText>
							{
							}

							public interface IChordChart : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IChordChart>
							{
							}

							public interface IOutputScreen : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IOutputScreen>
							{
							}

							public interface IPcoLive : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPcoLive>
							{
							}

							public interface IAlternateFill : IPropertyType, IEntity, IDisposable, IObservableProperty<IAlternateElementFill>
							{
							}

							public interface IVisibilityLink : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IVisibilityLink>
							{
							}

							public interface ISlideText : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideText>
							{
							}

							public interface IStageMessage : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IStageMessage>
							{
							}

							public interface IVideoCountdown : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IVideoCountdown>
							{
							}

							public interface ISlideImage : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideImage>
							{
							}

							public interface ICcliText : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ICcliText>
							{
							}

							public interface IGroupName : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IGroupName>
							{
							}

							public interface IGroupColor : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IGroupColor>
							{
							}

							public interface IPresentationNotes : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPresentationNotes>
							{
							}

							public interface IPlaylistItem : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPlaylistItem>
							{
							}

							public interface IAutoAdvanceTimeRemaining : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IAutoAdvanceTimeRemaining>
							{
							}

							public interface ICaptureStatusText : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ICaptureStatusText>
							{
							}

							public interface ICaptureStatusColor : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ICaptureStatusColor>
							{
							}

							public interface ISlideCount : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideCount>
							{
							}

							public interface IAudioCountdown : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IAudioCountdown>
							{
							}

							public interface IPresentation : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPresentation>
							{
							}

							public interface ISlideLabelText : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideLabelText>
							{
							}

							public interface ISlideLabelColor : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideLabelColor>
							{
							}

							public interface IRssFeed : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IRssFeed>
							{
							}

							public interface IFileFeed : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IFileFeed>
							{
							}

							public interface IChordProChart : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IChordProChart>
							{
							}

							public interface IPlaybackMarkerText : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPlaybackMarkerText>
							{
							}

							public interface IPlaybackMarkerColor : IPropertyType, IEntity, IDisposable, IObservableProperty<IPlaybackMarkerIdentifier>
							{
							}

							public interface ITimecodeText : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ITimecodeText>
							{
							}

							public interface ITimecodeStatus : IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ITimecodeStatus>
							{
							}

							internal class Ticker : ITicker, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ITicker>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ITicker> _Ticker_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _Ticker_.WhenChangeHappens;

								public IObservable<Types.ITicker> WhenValueChanges => _Ticker_.WhenValueChanges;

								public Types.ITicker Value => _Ticker_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_Ticker_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_Ticker_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "ticker__1".ToLoroValueLike());
									return loroMap;
								}

								public Ticker()
									: this(InitializeMap())
								{
								}

								public Ticker(LoroMap values)
								{
									_map = values;
									_Ticker_ = new ComplexObservableProperty<Types.ITicker>("ticker__1", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_Ticker_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_Ticker_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_Ticker_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ITicker value)
								{
									_Ticker_.Set(value);
								}
							}

							internal class AlternateText : IAlternateText, IPropertyType, IEntity, IDisposable, IObservableProperty<IAlternateElementText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IAlternateElementText> _AlternateText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _AlternateText_.WhenChangeHappens;

								public IObservable<IAlternateElementText> WhenValueChanges => _AlternateText_.WhenValueChanges;

								public IAlternateElementText Value => _AlternateText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_AlternateText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_AlternateText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "alternate_text__2".ToLoroValueLike());
									return loroMap;
								}

								public AlternateText()
									: this(InitializeMap())
								{
								}

								public AlternateText(LoroMap values)
								{
									_map = values;
									_AlternateText_ = new ComplexObservableProperty<IAlternateElementText>("alternate_text__2", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_AlternateText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_AlternateText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_AlternateText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IAlternateElementText value)
								{
									_AlternateText_.Set(value);
								}
							}

							internal class TimerText : ITimerText, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ITimerText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ITimerText> _TimerText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _TimerText_.WhenChangeHappens;

								public IObservable<Types.ITimerText> WhenValueChanges => _TimerText_.WhenValueChanges;

								public Types.ITimerText Value => _TimerText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_TimerText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_TimerText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "timer_text__3".ToLoroValueLike());
									return loroMap;
								}

								public TimerText()
									: this(InitializeMap())
								{
								}

								public TimerText(LoroMap values)
								{
									_map = values;
									_TimerText_ = new ComplexObservableProperty<Types.ITimerText>("timer_text__3", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_TimerText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_TimerText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_TimerText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ITimerText value)
								{
									_TimerText_.Set(value);
								}
							}

							internal class ClockText : IClockText, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IClockText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IClockText> _ClockText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _ClockText_.WhenChangeHappens;

								public IObservable<Types.IClockText> WhenValueChanges => _ClockText_.WhenValueChanges;

								public Types.IClockText Value => _ClockText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_ClockText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_ClockText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "clock_text__4".ToLoroValueLike());
									return loroMap;
								}

								public ClockText()
									: this(InitializeMap())
								{
								}

								public ClockText(LoroMap values)
								{
									_map = values;
									_ClockText_ = new ComplexObservableProperty<Types.IClockText>("clock_text__4", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_ClockText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_ClockText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_ClockText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IClockText value)
								{
									_ClockText_.Set(value);
								}
							}

							internal class ChordChart : IChordChart, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IChordChart>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IChordChart> _ChordChart_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _ChordChart_.WhenChangeHappens;

								public IObservable<Types.IChordChart> WhenValueChanges => _ChordChart_.WhenValueChanges;

								public Types.IChordChart Value => _ChordChart_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_ChordChart_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_ChordChart_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "chord_chart__5".ToLoroValueLike());
									return loroMap;
								}

								public ChordChart()
									: this(InitializeMap())
								{
								}

								public ChordChart(LoroMap values)
								{
									_map = values;
									_ChordChart_ = new ComplexObservableProperty<Types.IChordChart>("chord_chart__5", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_ChordChart_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_ChordChart_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_ChordChart_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IChordChart value)
								{
									_ChordChart_.Set(value);
								}
							}

							internal class OutputScreen : IOutputScreen, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IOutputScreen>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IOutputScreen> _OutputScreen_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _OutputScreen_.WhenChangeHappens;

								public IObservable<Types.IOutputScreen> WhenValueChanges => _OutputScreen_.WhenValueChanges;

								public Types.IOutputScreen Value => _OutputScreen_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_OutputScreen_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_OutputScreen_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "output_screen__6".ToLoroValueLike());
									return loroMap;
								}

								public OutputScreen()
									: this(InitializeMap())
								{
								}

								public OutputScreen(LoroMap values)
								{
									_map = values;
									_OutputScreen_ = new ComplexObservableProperty<Types.IOutputScreen>("output_screen__6", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_OutputScreen_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_OutputScreen_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_OutputScreen_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IOutputScreen value)
								{
									_OutputScreen_.Set(value);
								}
							}

							internal class PcoLive : IPcoLive, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPcoLive>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IPcoLive> _PcoLive_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _PcoLive_.WhenChangeHappens;

								public IObservable<Types.IPcoLive> WhenValueChanges => _PcoLive_.WhenValueChanges;

								public Types.IPcoLive Value => _PcoLive_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_PcoLive_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_PcoLive_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "pco_live__7".ToLoroValueLike());
									return loroMap;
								}

								public PcoLive()
									: this(InitializeMap())
								{
								}

								public PcoLive(LoroMap values)
								{
									_map = values;
									_PcoLive_ = new ComplexObservableProperty<Types.IPcoLive>("pco_live__7", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_PcoLive_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_PcoLive_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_PcoLive_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IPcoLive value)
								{
									_PcoLive_.Set(value);
								}
							}

							internal class AlternateFill : IAlternateFill, IPropertyType, IEntity, IDisposable, IObservableProperty<IAlternateElementFill>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IAlternateElementFill> _AlternateFill_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _AlternateFill_.WhenChangeHappens;

								public IObservable<IAlternateElementFill> WhenValueChanges => _AlternateFill_.WhenValueChanges;

								public IAlternateElementFill Value => _AlternateFill_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_AlternateFill_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_AlternateFill_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "alternate_fill__8".ToLoroValueLike());
									return loroMap;
								}

								public AlternateFill()
									: this(InitializeMap())
								{
								}

								public AlternateFill(LoroMap values)
								{
									_map = values;
									_AlternateFill_ = new ComplexObservableProperty<IAlternateElementFill>("alternate_fill__8", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_AlternateFill_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_AlternateFill_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_AlternateFill_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IAlternateElementFill value)
								{
									_AlternateFill_.Set(value);
								}
							}

							internal class VisibilityLink : IVisibilityLink, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IVisibilityLink>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IVisibilityLink> _VisibilityLink_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _VisibilityLink_.WhenChangeHappens;

								public IObservable<Types.IVisibilityLink> WhenValueChanges => _VisibilityLink_.WhenValueChanges;

								public Types.IVisibilityLink Value => _VisibilityLink_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_VisibilityLink_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_VisibilityLink_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "visibility_link__9".ToLoroValueLike());
									return loroMap;
								}

								public VisibilityLink()
									: this(InitializeMap())
								{
								}

								public VisibilityLink(LoroMap values)
								{
									_map = values;
									_VisibilityLink_ = new ComplexObservableProperty<Types.IVisibilityLink>("visibility_link__9", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_VisibilityLink_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_VisibilityLink_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_VisibilityLink_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IVisibilityLink value)
								{
									_VisibilityLink_.Set(value);
								}
							}

							internal class SlideText : ISlideText, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ISlideText> _SlideText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _SlideText_.WhenChangeHappens;

								public IObservable<Types.ISlideText> WhenValueChanges => _SlideText_.WhenValueChanges;

								public Types.ISlideText Value => _SlideText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_SlideText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_SlideText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "slide_text__10".ToLoroValueLike());
									return loroMap;
								}

								public SlideText()
									: this(InitializeMap())
								{
								}

								public SlideText(LoroMap values)
								{
									_map = values;
									_SlideText_ = new ComplexObservableProperty<Types.ISlideText>("slide_text__10", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_SlideText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_SlideText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_SlideText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ISlideText value)
								{
									_SlideText_.Set(value);
								}
							}

							internal class StageMessage : IStageMessage, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IStageMessage>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IStageMessage> _StageMessage_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _StageMessage_.WhenChangeHappens;

								public IObservable<Types.IStageMessage> WhenValueChanges => _StageMessage_.WhenValueChanges;

								public Types.IStageMessage Value => _StageMessage_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_StageMessage_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_StageMessage_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "stage_message__11".ToLoroValueLike());
									return loroMap;
								}

								public StageMessage()
									: this(InitializeMap())
								{
								}

								public StageMessage(LoroMap values)
								{
									_map = values;
									_StageMessage_ = new ComplexObservableProperty<Types.IStageMessage>("stage_message__11", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_StageMessage_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_StageMessage_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_StageMessage_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IStageMessage value)
								{
									_StageMessage_.Set(value);
								}
							}

							internal class VideoCountdown : IVideoCountdown, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IVideoCountdown>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IVideoCountdown> _VideoCountdown_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _VideoCountdown_.WhenChangeHappens;

								public IObservable<Types.IVideoCountdown> WhenValueChanges => _VideoCountdown_.WhenValueChanges;

								public Types.IVideoCountdown Value => _VideoCountdown_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_VideoCountdown_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_VideoCountdown_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "video_countdown__12".ToLoroValueLike());
									return loroMap;
								}

								public VideoCountdown()
									: this(InitializeMap())
								{
								}

								public VideoCountdown(LoroMap values)
								{
									_map = values;
									_VideoCountdown_ = new ComplexObservableProperty<Types.IVideoCountdown>("video_countdown__12", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_VideoCountdown_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_VideoCountdown_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_VideoCountdown_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IVideoCountdown value)
								{
									_VideoCountdown_.Set(value);
								}
							}

							internal class SlideImage : ISlideImage, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideImage>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ISlideImage> _SlideImage_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _SlideImage_.WhenChangeHappens;

								public IObservable<Types.ISlideImage> WhenValueChanges => _SlideImage_.WhenValueChanges;

								public Types.ISlideImage Value => _SlideImage_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_SlideImage_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_SlideImage_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "slide_image__13".ToLoroValueLike());
									return loroMap;
								}

								public SlideImage()
									: this(InitializeMap())
								{
								}

								public SlideImage(LoroMap values)
								{
									_map = values;
									_SlideImage_ = new ComplexObservableProperty<Types.ISlideImage>("slide_image__13", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_SlideImage_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_SlideImage_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_SlideImage_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ISlideImage value)
								{
									_SlideImage_.Set(value);
								}
							}

							internal class CcliText : ICcliText, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ICcliText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ICcliText> _CcliText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _CcliText_.WhenChangeHappens;

								public IObservable<Types.ICcliText> WhenValueChanges => _CcliText_.WhenValueChanges;

								public Types.ICcliText Value => _CcliText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_CcliText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_CcliText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "ccli_text__14".ToLoroValueLike());
									return loroMap;
								}

								public CcliText()
									: this(InitializeMap())
								{
								}

								public CcliText(LoroMap values)
								{
									_map = values;
									_CcliText_ = new ComplexObservableProperty<Types.ICcliText>("ccli_text__14", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_CcliText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_CcliText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_CcliText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ICcliText value)
								{
									_CcliText_.Set(value);
								}
							}

							internal class GroupName : IGroupName, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IGroupName>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IGroupName> _GroupName_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _GroupName_.WhenChangeHappens;

								public IObservable<Types.IGroupName> WhenValueChanges => _GroupName_.WhenValueChanges;

								public Types.IGroupName Value => _GroupName_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_GroupName_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_GroupName_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "group_name__15".ToLoroValueLike());
									return loroMap;
								}

								public GroupName()
									: this(InitializeMap())
								{
								}

								public GroupName(LoroMap values)
								{
									_map = values;
									_GroupName_ = new ComplexObservableProperty<Types.IGroupName>("group_name__15", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_GroupName_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_GroupName_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_GroupName_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IGroupName value)
								{
									_GroupName_.Set(value);
								}
							}

							internal class GroupColor : IGroupColor, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IGroupColor>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IGroupColor> _GroupColor_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _GroupColor_.WhenChangeHappens;

								public IObservable<Types.IGroupColor> WhenValueChanges => _GroupColor_.WhenValueChanges;

								public Types.IGroupColor Value => _GroupColor_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_GroupColor_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_GroupColor_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "group_color__16".ToLoroValueLike());
									return loroMap;
								}

								public GroupColor()
									: this(InitializeMap())
								{
								}

								public GroupColor(LoroMap values)
								{
									_map = values;
									_GroupColor_ = new ComplexObservableProperty<Types.IGroupColor>("group_color__16", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_GroupColor_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_GroupColor_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_GroupColor_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IGroupColor value)
								{
									_GroupColor_.Set(value);
								}
							}

							internal class PresentationNotes : IPresentationNotes, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPresentationNotes>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IPresentationNotes> _PresentationNotes_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _PresentationNotes_.WhenChangeHappens;

								public IObservable<Types.IPresentationNotes> WhenValueChanges => _PresentationNotes_.WhenValueChanges;

								public Types.IPresentationNotes Value => _PresentationNotes_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_PresentationNotes_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_PresentationNotes_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "presentation_notes__17".ToLoroValueLike());
									return loroMap;
								}

								public PresentationNotes()
									: this(InitializeMap())
								{
								}

								public PresentationNotes(LoroMap values)
								{
									_map = values;
									_PresentationNotes_ = new ComplexObservableProperty<Types.IPresentationNotes>("presentation_notes__17", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_PresentationNotes_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_PresentationNotes_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_PresentationNotes_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IPresentationNotes value)
								{
									_PresentationNotes_.Set(value);
								}
							}

							internal class PlaylistItem : IPlaylistItem, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPlaylistItem>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IPlaylistItem> _PlaylistItem_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _PlaylistItem_.WhenChangeHappens;

								public IObservable<Types.IPlaylistItem> WhenValueChanges => _PlaylistItem_.WhenValueChanges;

								public Types.IPlaylistItem Value => _PlaylistItem_.Value;

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
									loroMap.Insert("__tag", "playlist_item__18".ToLoroValueLike());
									return loroMap;
								}

								public PlaylistItem()
									: this(InitializeMap())
								{
								}

								public PlaylistItem(LoroMap values)
								{
									_map = values;
									_PlaylistItem_ = new ComplexObservableProperty<Types.IPlaylistItem>("playlist_item__18", LoroMap, new EntityFactory());
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

								public void Set(Types.IPlaylistItem value)
								{
									_PlaylistItem_.Set(value);
								}
							}

							internal class AutoAdvanceTimeRemaining : IAutoAdvanceTimeRemaining, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IAutoAdvanceTimeRemaining>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IAutoAdvanceTimeRemaining> _AutoAdvanceTimeRemaining_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _AutoAdvanceTimeRemaining_.WhenChangeHappens;

								public IObservable<Types.IAutoAdvanceTimeRemaining> WhenValueChanges => _AutoAdvanceTimeRemaining_.WhenValueChanges;

								public Types.IAutoAdvanceTimeRemaining Value => _AutoAdvanceTimeRemaining_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_AutoAdvanceTimeRemaining_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_AutoAdvanceTimeRemaining_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "auto_advance_time_remaining__19".ToLoroValueLike());
									return loroMap;
								}

								public AutoAdvanceTimeRemaining()
									: this(InitializeMap())
								{
								}

								public AutoAdvanceTimeRemaining(LoroMap values)
								{
									_map = values;
									_AutoAdvanceTimeRemaining_ = new ComplexObservableProperty<Types.IAutoAdvanceTimeRemaining>("auto_advance_time_remaining__19", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_AutoAdvanceTimeRemaining_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_AutoAdvanceTimeRemaining_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_AutoAdvanceTimeRemaining_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IAutoAdvanceTimeRemaining value)
								{
									_AutoAdvanceTimeRemaining_.Set(value);
								}
							}

							internal class CaptureStatusText : ICaptureStatusText, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ICaptureStatusText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ICaptureStatusText> _CaptureStatusText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _CaptureStatusText_.WhenChangeHappens;

								public IObservable<Types.ICaptureStatusText> WhenValueChanges => _CaptureStatusText_.WhenValueChanges;

								public Types.ICaptureStatusText Value => _CaptureStatusText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_CaptureStatusText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_CaptureStatusText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "capture_status_text__20".ToLoroValueLike());
									return loroMap;
								}

								public CaptureStatusText()
									: this(InitializeMap())
								{
								}

								public CaptureStatusText(LoroMap values)
								{
									_map = values;
									_CaptureStatusText_ = new ComplexObservableProperty<Types.ICaptureStatusText>("capture_status_text__20", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_CaptureStatusText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_CaptureStatusText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_CaptureStatusText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ICaptureStatusText value)
								{
									_CaptureStatusText_.Set(value);
								}
							}

							internal class CaptureStatusColor : ICaptureStatusColor, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ICaptureStatusColor>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ICaptureStatusColor> _CaptureStatusColor_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _CaptureStatusColor_.WhenChangeHappens;

								public IObservable<Types.ICaptureStatusColor> WhenValueChanges => _CaptureStatusColor_.WhenValueChanges;

								public Types.ICaptureStatusColor Value => _CaptureStatusColor_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_CaptureStatusColor_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_CaptureStatusColor_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "capture_status_color__21".ToLoroValueLike());
									return loroMap;
								}

								public CaptureStatusColor()
									: this(InitializeMap())
								{
								}

								public CaptureStatusColor(LoroMap values)
								{
									_map = values;
									_CaptureStatusColor_ = new ComplexObservableProperty<Types.ICaptureStatusColor>("capture_status_color__21", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_CaptureStatusColor_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_CaptureStatusColor_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_CaptureStatusColor_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ICaptureStatusColor value)
								{
									_CaptureStatusColor_.Set(value);
								}
							}

							internal class SlideCount : ISlideCount, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideCount>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ISlideCount> _SlideCount_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _SlideCount_.WhenChangeHappens;

								public IObservable<Types.ISlideCount> WhenValueChanges => _SlideCount_.WhenValueChanges;

								public Types.ISlideCount Value => _SlideCount_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_SlideCount_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_SlideCount_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "slide_count__22".ToLoroValueLike());
									return loroMap;
								}

								public SlideCount()
									: this(InitializeMap())
								{
								}

								public SlideCount(LoroMap values)
								{
									_map = values;
									_SlideCount_ = new ComplexObservableProperty<Types.ISlideCount>("slide_count__22", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_SlideCount_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_SlideCount_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_SlideCount_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ISlideCount value)
								{
									_SlideCount_.Set(value);
								}
							}

							internal class AudioCountdown : IAudioCountdown, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IAudioCountdown>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IAudioCountdown> _AudioCountdown_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _AudioCountdown_.WhenChangeHappens;

								public IObservable<Types.IAudioCountdown> WhenValueChanges => _AudioCountdown_.WhenValueChanges;

								public Types.IAudioCountdown Value => _AudioCountdown_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_AudioCountdown_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_AudioCountdown_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "audio_countdown__23".ToLoroValueLike());
									return loroMap;
								}

								public AudioCountdown()
									: this(InitializeMap())
								{
								}

								public AudioCountdown(LoroMap values)
								{
									_map = values;
									_AudioCountdown_ = new ComplexObservableProperty<Types.IAudioCountdown>("audio_countdown__23", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_AudioCountdown_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_AudioCountdown_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_AudioCountdown_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IAudioCountdown value)
								{
									_AudioCountdown_.Set(value);
								}
							}

							internal class Presentation : IPresentation, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPresentation>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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
									loroMap.Insert("__tag", "presentation__24".ToLoroValueLike());
									return loroMap;
								}

								public Presentation()
									: this(InitializeMap())
								{
								}

								public Presentation(LoroMap values)
								{
									_map = values;
									_Presentation_ = new ComplexObservableProperty<Types.IPresentation>("presentation__24", LoroMap, new EntityFactory());
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

							internal class SlideLabelText : ISlideLabelText, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideLabelText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ISlideLabelText> _SlideLabelText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _SlideLabelText_.WhenChangeHappens;

								public IObservable<Types.ISlideLabelText> WhenValueChanges => _SlideLabelText_.WhenValueChanges;

								public Types.ISlideLabelText Value => _SlideLabelText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_SlideLabelText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_SlideLabelText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "slide_Label_Text__25".ToLoroValueLike());
									return loroMap;
								}

								public SlideLabelText()
									: this(InitializeMap())
								{
								}

								public SlideLabelText(LoroMap values)
								{
									_map = values;
									_SlideLabelText_ = new ComplexObservableProperty<Types.ISlideLabelText>("slide_Label_Text__25", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_SlideLabelText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_SlideLabelText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_SlideLabelText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ISlideLabelText value)
								{
									_SlideLabelText_.Set(value);
								}
							}

							internal class SlideLabelColor : ISlideLabelColor, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ISlideLabelColor>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ISlideLabelColor> _SlideLabelColor_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _SlideLabelColor_.WhenChangeHappens;

								public IObservable<Types.ISlideLabelColor> WhenValueChanges => _SlideLabelColor_.WhenValueChanges;

								public Types.ISlideLabelColor Value => _SlideLabelColor_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_SlideLabelColor_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_SlideLabelColor_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "slide_Label_Color__26".ToLoroValueLike());
									return loroMap;
								}

								public SlideLabelColor()
									: this(InitializeMap())
								{
								}

								public SlideLabelColor(LoroMap values)
								{
									_map = values;
									_SlideLabelColor_ = new ComplexObservableProperty<Types.ISlideLabelColor>("slide_Label_Color__26", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_SlideLabelColor_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_SlideLabelColor_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_SlideLabelColor_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ISlideLabelColor value)
								{
									_SlideLabelColor_.Set(value);
								}
							}

							internal class RssFeed : IRssFeed, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IRssFeed>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IRssFeed> _RssFeed_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _RssFeed_.WhenChangeHappens;

								public IObservable<Types.IRssFeed> WhenValueChanges => _RssFeed_.WhenValueChanges;

								public Types.IRssFeed Value => _RssFeed_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_RssFeed_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_RssFeed_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "rss_feed__27".ToLoroValueLike());
									return loroMap;
								}

								public RssFeed()
									: this(InitializeMap())
								{
								}

								public RssFeed(LoroMap values)
								{
									_map = values;
									_RssFeed_ = new ComplexObservableProperty<Types.IRssFeed>("rss_feed__27", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_RssFeed_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_RssFeed_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_RssFeed_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IRssFeed value)
								{
									_RssFeed_.Set(value);
								}
							}

							internal class FileFeed : IFileFeed, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IFileFeed>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IFileFeed> _FileFeed_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _FileFeed_.WhenChangeHappens;

								public IObservable<Types.IFileFeed> WhenValueChanges => _FileFeed_.WhenValueChanges;

								public Types.IFileFeed Value => _FileFeed_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_FileFeed_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_FileFeed_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "file_feed__28".ToLoroValueLike());
									return loroMap;
								}

								public FileFeed()
									: this(InitializeMap())
								{
								}

								public FileFeed(LoroMap values)
								{
									_map = values;
									_FileFeed_ = new ComplexObservableProperty<Types.IFileFeed>("file_feed__28", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_FileFeed_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_FileFeed_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_FileFeed_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IFileFeed value)
								{
									_FileFeed_.Set(value);
								}
							}

							internal class ChordProChart : IChordProChart, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IChordProChart>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IChordProChart> _ChordProChart_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _ChordProChart_.WhenChangeHappens;

								public IObservable<Types.IChordProChart> WhenValueChanges => _ChordProChart_.WhenValueChanges;

								public Types.IChordProChart Value => _ChordProChart_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_ChordProChart_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_ChordProChart_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "chord_pro_chart__29".ToLoroValueLike());
									return loroMap;
								}

								public ChordProChart()
									: this(InitializeMap())
								{
								}

								public ChordProChart(LoroMap values)
								{
									_map = values;
									_ChordProChart_ = new ComplexObservableProperty<Types.IChordProChart>("chord_pro_chart__29", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_ChordProChart_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_ChordProChart_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_ChordProChart_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IChordProChart value)
								{
									_ChordProChart_.Set(value);
								}
							}

							internal class PlaybackMarkerText : IPlaybackMarkerText, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.IPlaybackMarkerText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IPlaybackMarkerText> _PlaybackMarkerText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _PlaybackMarkerText_.WhenChangeHappens;

								public IObservable<Types.IPlaybackMarkerText> WhenValueChanges => _PlaybackMarkerText_.WhenValueChanges;

								public Types.IPlaybackMarkerText Value => _PlaybackMarkerText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_PlaybackMarkerText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_PlaybackMarkerText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "playback_marker_text__30".ToLoroValueLike());
									return loroMap;
								}

								public PlaybackMarkerText()
									: this(InitializeMap())
								{
								}

								public PlaybackMarkerText(LoroMap values)
								{
									_map = values;
									_PlaybackMarkerText_ = new ComplexObservableProperty<Types.IPlaybackMarkerText>("playback_marker_text__30", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_PlaybackMarkerText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_PlaybackMarkerText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_PlaybackMarkerText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IPlaybackMarkerText value)
								{
									_PlaybackMarkerText_.Set(value);
								}
							}

							internal class PlaybackMarkerColor : IPlaybackMarkerColor, IPropertyType, IEntity, IDisposable, IObservableProperty<IPlaybackMarkerIdentifier>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IPlaybackMarkerIdentifier> _PlaybackMarkerColor_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _PlaybackMarkerColor_.WhenChangeHappens;

								public IObservable<IPlaybackMarkerIdentifier> WhenValueChanges => _PlaybackMarkerColor_.WhenValueChanges;

								public IPlaybackMarkerIdentifier Value => _PlaybackMarkerColor_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_PlaybackMarkerColor_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_PlaybackMarkerColor_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "playback_marker_color__32".ToLoroValueLike());
									return loroMap;
								}

								public PlaybackMarkerColor()
									: this(InitializeMap())
								{
								}

								public PlaybackMarkerColor(LoroMap values)
								{
									_map = values;
									_PlaybackMarkerColor_ = new ComplexObservableProperty<IPlaybackMarkerIdentifier>("playback_marker_color__32", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_PlaybackMarkerColor_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_PlaybackMarkerColor_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_PlaybackMarkerColor_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IPlaybackMarkerIdentifier value)
								{
									_PlaybackMarkerColor_.Set(value);
								}
							}

							internal class TimecodeText : ITimecodeText, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ITimecodeText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ITimecodeText> _TimecodeText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _TimecodeText_.WhenChangeHappens;

								public IObservable<Types.ITimecodeText> WhenValueChanges => _TimecodeText_.WhenValueChanges;

								public Types.ITimecodeText Value => _TimecodeText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_TimecodeText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_TimecodeText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "timecode_text__33".ToLoroValueLike());
									return loroMap;
								}

								public TimecodeText()
									: this(InitializeMap())
								{
								}

								public TimecodeText(LoroMap values)
								{
									_map = values;
									_TimecodeText_ = new ComplexObservableProperty<Types.ITimecodeText>("timecode_text__33", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_TimecodeText_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_TimecodeText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_TimecodeText_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ITimecodeText value)
								{
									_TimecodeText_.Set(value);
								}
							}

							internal class TimecodeStatus : ITimecodeStatus, IPropertyType, IEntity, IDisposable, IObservableProperty<Types.ITimecodeStatus>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ITimecodeStatus> _TimecodeStatus_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _TimecodeStatus_.WhenChangeHappens;

								public IObservable<Types.ITimecodeStatus> WhenValueChanges => _TimecodeStatus_.WhenValueChanges;

								public Types.ITimecodeStatus Value => _TimecodeStatus_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_TimecodeStatus_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_TimecodeStatus_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "timecode_status__34".ToLoroValueLike());
									return loroMap;
								}

								public TimecodeStatus()
									: this(InitializeMap())
								{
								}

								public TimecodeStatus(LoroMap values)
								{
									_map = values;
									_TimecodeStatus_ = new ComplexObservableProperty<Types.ITimecodeStatus>("timecode_status__34", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_TimecodeStatus_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_TimecodeStatus_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_TimecodeStatus_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ITimecodeStatus value)
								{
									_TimecodeStatus_.Set(value);
								}
							}
						}

						internal class PropertyTypeFactory : IUnionValueFactory<IPropertyType>
						{
							public string SelectionKey => "__tag";

							public IPropertyType? CreateInstance(LoroMap map)
							{
								return map.Get("__tag").ToStringValue() switch
								{
									"ticker__1" => new IPropertyType.Ticker(map), 
									"alternate_text__2" => new IPropertyType.AlternateText(map), 
									"timer_text__3" => new IPropertyType.TimerText(map), 
									"clock_text__4" => new IPropertyType.ClockText(map), 
									"chord_chart__5" => new IPropertyType.ChordChart(map), 
									"output_screen__6" => new IPropertyType.OutputScreen(map), 
									"pco_live__7" => new IPropertyType.PcoLive(map), 
									"alternate_fill__8" => new IPropertyType.AlternateFill(map), 
									"visibility_link__9" => new IPropertyType.VisibilityLink(map), 
									"slide_text__10" => new IPropertyType.SlideText(map), 
									"stage_message__11" => new IPropertyType.StageMessage(map), 
									"video_countdown__12" => new IPropertyType.VideoCountdown(map), 
									"slide_image__13" => new IPropertyType.SlideImage(map), 
									"ccli_text__14" => new IPropertyType.CcliText(map), 
									"group_name__15" => new IPropertyType.GroupName(map), 
									"group_color__16" => new IPropertyType.GroupColor(map), 
									"presentation_notes__17" => new IPropertyType.PresentationNotes(map), 
									"playlist_item__18" => new IPropertyType.PlaylistItem(map), 
									"auto_advance_time_remaining__19" => new IPropertyType.AutoAdvanceTimeRemaining(map), 
									"capture_status_text__20" => new IPropertyType.CaptureStatusText(map), 
									"capture_status_color__21" => new IPropertyType.CaptureStatusColor(map), 
									"slide_count__22" => new IPropertyType.SlideCount(map), 
									"audio_countdown__23" => new IPropertyType.AudioCountdown(map), 
									"presentation__24" => new IPropertyType.Presentation(map), 
									"slide_Label_Text__25" => new IPropertyType.SlideLabelText(map), 
									"slide_Label_Color__26" => new IPropertyType.SlideLabelColor(map), 
									"rss_feed__27" => new IPropertyType.RssFeed(map), 
									"file_feed__28" => new IPropertyType.FileFeed(map), 
									"chord_pro_chart__29" => new IPropertyType.ChordProChart(map), 
									"playback_marker_text__30" => new IPropertyType.PlaybackMarkerText(map), 
									"playback_marker_color__32" => new IPropertyType.PlaybackMarkerColor(map), 
									"timecode_text__33" => new IPropertyType.TimecodeText(map), 
									"timecode_status__34" => new IPropertyType.TimecodeStatus(map), 
									_ => null, 
								};
							}

							public IPropertyType CreateDefault(LoroMap map)
							{
								map.Insert("__tag", "ticker__1".ToLoroValueLike());
								return new IPropertyType.Ticker(map);
							}
						}
					}

					IComplexObservableProperty<Types.IPropertyType> PropertyType { get; }
				}

				internal sealed class DataLink : IDataLink, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UnionObservableProperty<IDataLink.Types.IPropertyType> PropertyType_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<IDataLink.Types.IPropertyType> PropertyType => PropertyType_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						PropertyType_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						PropertyType_.UpdateMapOnInternalMapUpdate(_map);
					}

					public DataLink()
						: this(new LoroMap())
					{
					}

					public DataLink(LoroMap values)
					{
						_map = values;
						PropertyType_ = new UnionObservableProperty<IDataLink.Types.IPropertyType>("PropertyType__union", LoroMap, new IDataLink.Types.PropertyTypeFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(PropertyType_.WhenChangeHappens);
					}

					public void Dispose()
					{
						PropertyType_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						PropertyType_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITextScroller : IEntity, IDisposable
				{
					public class Types
					{
						public enum Direction
						{
							Left,
							Right,
							Up,
							Down
						}
					}

					IObservableProperty<bool> ShouldScroll { get; }

					IObservableProperty<double> ScrollRate { get; }

					IObservableProperty<bool> ShouldRepeat { get; }

					IObservableProperty<double> RepeatDistance { get; }

					IObservableProperty<Types.Direction> ScrollingDirection { get; }

					IObservableProperty<bool> StartsOffScreen { get; }

					IObservableProperty<double> FadeLeft { get; }

					IObservableProperty<double> FadeRight { get; }
				}

				internal sealed class TextScroller : ITextScroller, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private BoolObservableProperty ShouldScroll_;

					private DoubleObservableProperty ScrollRate_;

					private BoolObservableProperty ShouldRepeat_;

					private DoubleObservableProperty RepeatDistance_;

					private EnumObservableProperty<ITextScroller.Types.Direction> ScrollingDirection_;

					private BoolObservableProperty StartsOffScreen_;

					private DoubleObservableProperty FadeLeft_;

					private DoubleObservableProperty FadeRight_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<bool> ShouldScroll => ShouldScroll_;

					public IObservableProperty<double> ScrollRate => ScrollRate_;

					public IObservableProperty<bool> ShouldRepeat => ShouldRepeat_;

					public IObservableProperty<double> RepeatDistance => RepeatDistance_;

					public IObservableProperty<ITextScroller.Types.Direction> ScrollingDirection => ScrollingDirection_;

					public IObservableProperty<bool> StartsOffScreen => StartsOffScreen_;

					public IObservableProperty<double> FadeLeft => FadeLeft_;

					public IObservableProperty<double> FadeRight => FadeRight_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						ShouldScroll_.UpdateMap(_map);
						ScrollRate_.UpdateMap(_map);
						ShouldRepeat_.UpdateMap(_map);
						RepeatDistance_.UpdateMap(_map);
						ScrollingDirection_.UpdateMap(_map);
						StartsOffScreen_.UpdateMap(_map);
						FadeLeft_.UpdateMap(_map);
						FadeRight_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						ShouldScroll_.UpdateMapOnInternalMapUpdate(_map);
						ScrollRate_.UpdateMapOnInternalMapUpdate(_map);
						ShouldRepeat_.UpdateMapOnInternalMapUpdate(_map);
						RepeatDistance_.UpdateMapOnInternalMapUpdate(_map);
						ScrollingDirection_.UpdateMapOnInternalMapUpdate(_map);
						StartsOffScreen_.UpdateMapOnInternalMapUpdate(_map);
						FadeLeft_.UpdateMapOnInternalMapUpdate(_map);
						FadeRight_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TextScroller()
						: this(new LoroMap())
					{
					}

					public TextScroller(LoroMap values)
					{
						_map = values;
						ShouldScroll_ = new BoolObservableProperty("should_scroll__1", LoroMap);
						ScrollRate_ = new DoubleObservableProperty("scroll_rate__2", LoroMap);
						ShouldRepeat_ = new BoolObservableProperty("should_repeat__3", LoroMap);
						RepeatDistance_ = new DoubleObservableProperty("repeat_distance__4", LoroMap);
						ScrollingDirection_ = new EnumObservableProperty<ITextScroller.Types.Direction>("scrolling_direction__5", LoroMap);
						StartsOffScreen_ = new BoolObservableProperty("starts_off_screen__6", LoroMap);
						FadeLeft_ = new DoubleObservableProperty("fade_left__7", LoroMap);
						FadeRight_ = new DoubleObservableProperty("fade_right__8", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(ShouldScroll_.WhenChangeHappens, ScrollRate_.WhenChangeHappens, ShouldRepeat_.WhenChangeHappens, RepeatDistance_.WhenChangeHappens, ScrollingDirection_.WhenChangeHappens, StartsOffScreen_.WhenChangeHappens, FadeLeft_.WhenChangeHappens, FadeRight_.WhenChangeHappens);
					}

					public void Dispose()
					{
						ShouldScroll_.Dispose();
						ScrollRate_.Dispose();
						ShouldRepeat_.Dispose();
						RepeatDistance_.Dispose();
						ScrollingDirection_.Dispose();
						StartsOffScreen_.Dispose();
						FadeLeft_.Dispose();
						FadeRight_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						ShouldScroll_.OnDiff(path, diff);
						ScrollRate_.OnDiff(path, diff);
						ShouldRepeat_.OnDiff(path, diff);
						RepeatDistance_.OnDiff(path, diff);
						ScrollingDirection_.OnDiff(path, diff);
						StartsOffScreen_.OnDiff(path, diff);
						FadeLeft_.OnDiff(path, diff);
						FadeRight_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum TextRevealType
				{
					None,
					Bullet,
					Underline
				}
			}

			IComplexObservableProperty<IGraphics.Types.IElement> _Element { get; }

			IComplexObservableProperty<Types.IBuild?> BuildIn { get; }

			IComplexObservableProperty<Types.IBuild?> BuildOut { get; }

			IObservableProperty<uint> Info { get; }

			IObservableProperty<Types.TextRevealType> RevealType { get; }

			IComplexCollection<Types.IDataLink> DataLinks { get; }

			IComplexCollection<Types.IChildBuild> ChildBuilds { get; }

			IObservableProperty<uint> RevealFromIndex { get; }

			IComplexObservableProperty<Types.ITextScroller> TextScroller { get; }
		}

		internal sealed class Element : IElement, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IGraphics.Types.IElement> _Element_;

			private OptionalComplexObservableProperty<IElement.Types.IBuild> BuildIn_;

			private OptionalComplexObservableProperty<IElement.Types.IBuild> BuildOut_;

			private UintObservableProperty Info_;

			private EnumObservableProperty<IElement.Types.TextRevealType> RevealType_;

			private MapCollection<IElement.Types.IDataLink> DataLinks_;

			private MapCollection<IElement.Types.IChildBuild> ChildBuilds_;

			private UintObservableProperty RevealFromIndex_;

			private ComplexObservableProperty<IElement.Types.ITextScroller> TextScroller_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IGraphics.Types.IElement> _Element => _Element_;

			public IComplexObservableProperty<IElement.Types.IBuild?> BuildIn => BuildIn_;

			public IComplexObservableProperty<IElement.Types.IBuild?> BuildOut => BuildOut_;

			public IObservableProperty<uint> Info => Info_;

			public IObservableProperty<IElement.Types.TextRevealType> RevealType => RevealType_;

			public IComplexCollection<IElement.Types.IDataLink> DataLinks => DataLinks_;

			public IComplexCollection<IElement.Types.IChildBuild> ChildBuilds => ChildBuilds_;

			public IObservableProperty<uint> RevealFromIndex => RevealFromIndex_;

			public IComplexObservableProperty<IElement.Types.ITextScroller> TextScroller => TextScroller_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				_Element_.UpdateMap(_map);
				BuildIn_.UpdateMap(_map);
				BuildOut_.UpdateMap(_map);
				Info_.UpdateMap(_map);
				RevealType_.UpdateMap(_map);
				DataLinks_.UpdateMap(_map);
				ChildBuilds_.UpdateMap(_map);
				RevealFromIndex_.UpdateMap(_map);
				TextScroller_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				_Element_.UpdateMapOnInternalMapUpdate(_map);
				BuildIn_.UpdateMapOnInternalMapUpdate(_map);
				BuildOut_.UpdateMapOnInternalMapUpdate(_map);
				Info_.UpdateMapOnInternalMapUpdate(_map);
				RevealType_.UpdateMapOnInternalMapUpdate(_map);
				DataLinks_.UpdateMapOnInternalMapUpdate(_map);
				ChildBuilds_.UpdateMapOnInternalMapUpdate(_map);
				RevealFromIndex_.UpdateMapOnInternalMapUpdate(_map);
				TextScroller_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Element()
				: this(new LoroMap())
			{
			}

			public Element(LoroMap values)
			{
				_map = values;
				_Element_ = new ComplexObservableProperty<IGraphics.Types.IElement>("element__1", LoroMap, new EntityFactory());
				BuildIn_ = new OptionalComplexObservableProperty<IElement.Types.IBuild>("build_in__2", LoroMap, new EntityFactory());
				BuildOut_ = new OptionalComplexObservableProperty<IElement.Types.IBuild>("build_out__3", LoroMap, new EntityFactory());
				Info_ = new UintObservableProperty("info__4", LoroMap);
				RevealType_ = new EnumObservableProperty<IElement.Types.TextRevealType>("reveal_type__5", LoroMap);
				DataLinks_ = new MapCollection<IElement.Types.IDataLink>(LoroMap, "data_links__6", new EntityFactory());
				ChildBuilds_ = new MapCollection<IElement.Types.IChildBuild>(LoroMap, "childBuilds__7", new EntityFactory());
				RevealFromIndex_ = new UintObservableProperty("reveal_from_index__8", LoroMap);
				TextScroller_ = new ComplexObservableProperty<IElement.Types.ITextScroller>("text_scroller__9", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(_Element_.WhenChangeHappens, BuildIn_.WhenChangeHappens, BuildOut_.WhenChangeHappens, Info_.WhenChangeHappens, RevealType_.WhenChangeHappens, DataLinks_.WhenChangeHappens, ChildBuilds_.WhenChangeHappens, RevealFromIndex_.WhenChangeHappens, TextScroller_.WhenChangeHappens);
			}

			public void Dispose()
			{
				_Element_.Dispose();
				BuildIn_.Dispose();
				BuildOut_.Dispose();
				Info_.Dispose();
				RevealType_.Dispose();
				DataLinks_.Dispose();
				ChildBuilds_.Dispose();
				RevealFromIndex_.Dispose();
				TextScroller_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				_Element_.OnDiff(path, diff);
				BuildIn_.OnDiff(path, diff);
				BuildOut_.OnDiff(path, diff);
				Info_.OnDiff(path, diff);
				RevealType_.OnDiff(path, diff);
				DataLinks_.OnDiff(path, diff);
				ChildBuilds_.OnDiff(path, diff);
				RevealFromIndex_.OnDiff(path, diff);
				TextScroller_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IComplexCollection<Types.IElement> Elements { get; }

	ICollection<Guid> ElementBuildOrder { get; }

	IComplexCollection<IAlignmentGuide> Guidelines { get; }

	IObservableProperty<bool> DrawsBackgroundColor { get; }

	IObservableProperty<Color?> BackgroundColor { get; }

	IObservableProperty<IGraphics.Types.Size?> Size { get; }

	IObservableProperty<Guid> Uuid { get; }
}
