using System;
using System.Reactive.Disposables;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public sealed class MergedVideoInput(ICloudVideoInput remote, IVideoInput local) : IMergedVideoInput, ICloudVideoInput, IEntity, IDisposable, IVideoInput
{
	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public IObservableProperty<Guid> Uuid => remote.Uuid;

	public IObservableProperty<string?> UserDescription => remote.UserDescription;

	public IComplexObservableProperty<IMedia.Types.IVideoDevice?> VideoInputDevice => local.VideoInputDevice;

	public IObservableProperty<Color> DisplayColor => local.DisplayColor;

	public IObservableProperty<AlphaType> AlphaType => local.AlphaType;

	public IObservableProperty<IVideoInput.Types.AudioDeviceType> AudioType => local.AudioType;

	public IComplexObservableProperty<IVideoInput.Types.IAltAudioSource> AltAudioSource => local.AltAudioSource;

	public IObservableProperty<Url?> ThumbnailPath => remote.ThumbnailPath;

	public ICloudVideoInput Remote => remote;

	public IVideoInput Local => local;

	public void Dispose()
	{
		_disposables.Dispose();
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_disposables.Add(disposable);
	}
}
