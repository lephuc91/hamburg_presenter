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

public interface IAudioInput : IEntity, IDisposable
{
	public class Types
	{
		public interface IBehaviorMode : IEntity, IDisposable
		{
			public class Types
			{
				public interface IAutoOff : IEntity, IDisposable
				{
				}

				internal sealed class AutoOff : IAutoOff, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

					public AutoOff()
						: this(new LoroMap())
					{
					}

					public AutoOff(LoroMap values)
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

				public interface IAutoOn : IEntity, IDisposable
				{
					ICollection<uint> LinkedVideoInputs { get; }
				}

				internal sealed class AutoOn : IAutoOn, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UIntCollection LinkedVideoInputs_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public ICollection<uint> LinkedVideoInputs => LinkedVideoInputs_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						LinkedVideoInputs_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						LinkedVideoInputs_.UpdateMapOnInternalMapUpdate(_map);
					}

					public AutoOn()
						: this(new LoroMap())
					{
					}

					public AutoOn(LoroMap values)
					{
						_map = values;
						LinkedVideoInputs_ = new UIntCollection(LoroMap, "linked_video_inputs__1");
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(LinkedVideoInputs_.WhenChangeHappens);
					}

					public void Dispose()
					{
						LinkedVideoInputs_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						LinkedVideoInputs_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IOff : IEntity, IDisposable
				{
				}

				internal sealed class Off : IOff, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

					public Off()
						: this(new LoroMap())
					{
					}

					public Off(LoroMap values)
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

				public interface IOn : IEntity, IDisposable
				{
				}

				internal sealed class On : IOn, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

					public On()
						: this(new LoroMap())
					{
					}

					public On(LoroMap values)
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

				public interface IMode : IEntity, IDisposable
				{
					public interface IOn : IMode, IEntity, IDisposable, IObservableProperty<Types.IOn>
					{
					}

					public interface IOff : IMode, IEntity, IDisposable, IObservableProperty<Types.IOff>
					{
					}

					public interface IAutoOn : IMode, IEntity, IDisposable, IObservableProperty<Types.IAutoOn>
					{
					}

					public interface IAutoOff : IMode, IEntity, IDisposable, IObservableProperty<Types.IAutoOff>
					{
					}

					internal class On : IOn, IMode, IEntity, IDisposable, IObservableProperty<Types.IOn>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<Types.IOn> _On_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _On_.WhenChangeHappens;

						public IObservable<Types.IOn> WhenValueChanges => _On_.WhenValueChanges;

						public Types.IOn Value => _On_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_On_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_On_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "on__1".ToLoroValueLike());
							return loroMap;
						}

						public On()
							: this(InitializeMap())
						{
						}

						public On(LoroMap values)
						{
							_map = values;
							_On_ = new ComplexObservableProperty<Types.IOn>("on__1", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_On_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_On_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_On_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(Types.IOn value)
						{
							_On_.Set(value);
						}
					}

					internal class Off : IOff, IMode, IEntity, IDisposable, IObservableProperty<Types.IOff>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<Types.IOff> _Off_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Off_.WhenChangeHappens;

						public IObservable<Types.IOff> WhenValueChanges => _Off_.WhenValueChanges;

						public Types.IOff Value => _Off_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Off_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Off_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "off__2".ToLoroValueLike());
							return loroMap;
						}

						public Off()
							: this(InitializeMap())
						{
						}

						public Off(LoroMap values)
						{
							_map = values;
							_Off_ = new ComplexObservableProperty<Types.IOff>("off__2", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Off_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Off_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Off_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(Types.IOff value)
						{
							_Off_.Set(value);
						}
					}

					internal class AutoOn : IAutoOn, IMode, IEntity, IDisposable, IObservableProperty<Types.IAutoOn>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<Types.IAutoOn> _AutoOn_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _AutoOn_.WhenChangeHappens;

						public IObservable<Types.IAutoOn> WhenValueChanges => _AutoOn_.WhenValueChanges;

						public Types.IAutoOn Value => _AutoOn_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_AutoOn_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_AutoOn_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "auto_on__3".ToLoroValueLike());
							return loroMap;
						}

						public AutoOn()
							: this(InitializeMap())
						{
						}

						public AutoOn(LoroMap values)
						{
							_map = values;
							_AutoOn_ = new ComplexObservableProperty<Types.IAutoOn>("auto_on__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_AutoOn_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_AutoOn_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_AutoOn_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(Types.IAutoOn value)
						{
							_AutoOn_.Set(value);
						}
					}

					internal class AutoOff : IAutoOff, IMode, IEntity, IDisposable, IObservableProperty<Types.IAutoOff>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<Types.IAutoOff> _AutoOff_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _AutoOff_.WhenChangeHappens;

						public IObservable<Types.IAutoOff> WhenValueChanges => _AutoOff_.WhenValueChanges;

						public Types.IAutoOff Value => _AutoOff_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_AutoOff_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_AutoOff_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "auto_off__4".ToLoroValueLike());
							return loroMap;
						}

						public AutoOff()
							: this(InitializeMap())
						{
						}

						public AutoOff(LoroMap values)
						{
							_map = values;
							_AutoOff_ = new ComplexObservableProperty<Types.IAutoOff>("auto_off__4", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_AutoOff_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_AutoOff_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_AutoOff_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(Types.IAutoOff value)
						{
							_AutoOff_.Set(value);
						}
					}
				}

				internal class ModeFactory : IUnionValueFactory<IMode>
				{
					public string SelectionKey => "__tag";

					public IMode? CreateInstance(LoroMap map)
					{
						return map.Get("__tag").ToStringValue() switch
						{
							"on__1" => new IMode.On(map), 
							"off__2" => new IMode.Off(map), 
							"auto_on__3" => new IMode.AutoOn(map), 
							"auto_off__4" => new IMode.AutoOff(map), 
							_ => null, 
						};
					}

					public IMode CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "on__1".ToLoroValueLike());
						return new IMode.On(map);
					}
				}
			}

			IComplexObservableProperty<Types.IMode> Mode { get; }
		}

		internal sealed class BehaviorMode : IBehaviorMode, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private UnionObservableProperty<IBehaviorMode.Types.IMode> Mode_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IBehaviorMode.Types.IMode> Mode => Mode_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Mode_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Mode_.UpdateMapOnInternalMapUpdate(_map);
			}

			public BehaviorMode()
				: this(new LoroMap())
			{
			}

			public BehaviorMode(LoroMap values)
			{
				_map = values;
				Mode_ = new UnionObservableProperty<IBehaviorMode.Types.IMode>("Mode__union", LoroMap, new IBehaviorMode.Types.ModeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Mode_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Mode_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Mode_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISource : IEntity, IDisposable
		{
			public interface IAudioDevice : ISource, IEntity, IDisposable, IObservableProperty<IDigitalAudio.Types.IDevice>
			{
			}

			public interface IVideoDevice : ISource, IEntity, IDisposable, IObservableProperty<IMedia.Types.IVideoDevice>
			{
			}

			internal class AudioDevice : IAudioDevice, ISource, IEntity, IDisposable, IObservableProperty<IDigitalAudio.Types.IDevice>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IDigitalAudio.Types.IDevice> _AudioDevice_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _AudioDevice_.WhenChangeHappens;

				public IObservable<IDigitalAudio.Types.IDevice> WhenValueChanges => _AudioDevice_.WhenValueChanges;

				public IDigitalAudio.Types.IDevice Value => _AudioDevice_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_AudioDevice_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_AudioDevice_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "audio_device__3".ToLoroValueLike());
					return loroMap;
				}

				public AudioDevice()
					: this(InitializeMap())
				{
				}

				public AudioDevice(LoroMap values)
				{
					_map = values;
					_AudioDevice_ = new ComplexObservableProperty<IDigitalAudio.Types.IDevice>("audio_device__3", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_AudioDevice_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_AudioDevice_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_AudioDevice_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IDigitalAudio.Types.IDevice value)
				{
					_AudioDevice_.Set(value);
				}
			}

			internal class VideoDevice : IVideoDevice, ISource, IEntity, IDisposable, IObservableProperty<IMedia.Types.IVideoDevice>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IMedia.Types.IVideoDevice> _VideoDevice_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _VideoDevice_.WhenChangeHappens;

				public IObservable<IMedia.Types.IVideoDevice> WhenValueChanges => _VideoDevice_.WhenValueChanges;

				public IMedia.Types.IVideoDevice Value => _VideoDevice_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_VideoDevice_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_VideoDevice_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "video_device__4".ToLoroValueLike());
					return loroMap;
				}

				public VideoDevice()
					: this(InitializeMap())
				{
				}

				public VideoDevice(LoroMap values)
				{
					_map = values;
					_VideoDevice_ = new ComplexObservableProperty<IMedia.Types.IVideoDevice>("video_device__4", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_VideoDevice_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_VideoDevice_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_VideoDevice_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IMedia.Types.IVideoDevice value)
				{
					_VideoDevice_.Set(value);
				}
			}
		}

		internal class SourceFactory : IUnionValueFactory<ISource>
		{
			public string SelectionKey => "__tag";

			public ISource? CreateInstance(LoroMap map)
			{
				string text = map.Get("__tag").ToStringValue();
				if (!(text == "audio_device__3"))
				{
					if (text == "video_device__4")
					{
						return new ISource.VideoDevice(map);
					}
					return null;
				}
				return new ISource.AudioDevice(map);
			}

			public ISource CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "audio_device__3".ToLoroValueLike());
				return new ISource.AudioDevice(map);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> UserDescription { get; }

	IComplexObservableProperty<Types.IBehaviorMode> BehaviorMode { get; }

	IComplexObservableProperty<Types.ISource> Source { get; }
}
