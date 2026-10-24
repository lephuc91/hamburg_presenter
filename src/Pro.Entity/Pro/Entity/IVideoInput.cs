using System;
using System.Reactive;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IVideoInput : IEntity, IDisposable
{
	public class Types
	{
		public enum AudioDeviceType
		{
			Default,
			None,
			Alternate
		}

		public interface IAltAudioSource : IEntity, IDisposable
		{
			public interface IAudioDevice : IAltAudioSource, IEntity, IDisposable, IObservableProperty<IDigitalAudio.Types.IDevice>
			{
			}

			public interface IVideoDevice : IAltAudioSource, IEntity, IDisposable, IObservableProperty<IMedia.Types.IVideoDevice>
			{
			}

			internal class AudioDevice : IAudioDevice, IAltAudioSource, IEntity, IDisposable, IObservableProperty<IDigitalAudio.Types.IDevice>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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
					loroMap.Insert("__tag", "audio_device__6".ToLoroValueLike());
					return loroMap;
				}

				public AudioDevice()
					: this(InitializeMap())
				{
				}

				public AudioDevice(LoroMap values)
				{
					_map = values;
					_AudioDevice_ = new ComplexObservableProperty<IDigitalAudio.Types.IDevice>("audio_device__6", LoroMap, new EntityFactory());
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

			internal class VideoDevice : IVideoDevice, IAltAudioSource, IEntity, IDisposable, IObservableProperty<IMedia.Types.IVideoDevice>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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
					loroMap.Insert("__tag", "video_device__7".ToLoroValueLike());
					return loroMap;
				}

				public VideoDevice()
					: this(InitializeMap())
				{
				}

				public VideoDevice(LoroMap values)
				{
					_map = values;
					_VideoDevice_ = new ComplexObservableProperty<IMedia.Types.IVideoDevice>("video_device__7", LoroMap, new EntityFactory());
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

		internal class AltAudioSourceFactory : IUnionValueFactory<IAltAudioSource>
		{
			public string SelectionKey => "__tag";

			public IAltAudioSource? CreateInstance(LoroMap map)
			{
				string text = map.Get("__tag").ToStringValue();
				if (!(text == "audio_device__6"))
				{
					if (text == "video_device__7")
					{
						return new IAltAudioSource.VideoDevice(map);
					}
					return null;
				}
				return new IAltAudioSource.AudioDevice(map);
			}

			public IAltAudioSource CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "audio_device__6".ToLoroValueLike());
				return new IAltAudioSource.AudioDevice(map);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string?> UserDescription { get; }

	IComplexObservableProperty<IMedia.Types.IVideoDevice?> VideoInputDevice { get; }

	IObservableProperty<Color> DisplayColor { get; }

	IObservableProperty<Types.AudioDeviceType> AudioType { get; }

	IObservableProperty<AlphaType> AlphaType { get; }

	IComplexObservableProperty<Types.IAltAudioSource> AltAudioSource { get; }
}
