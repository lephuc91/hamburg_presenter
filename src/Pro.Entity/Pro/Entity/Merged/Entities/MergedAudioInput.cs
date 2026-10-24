using System;
using System.Reactive.Disposables;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public sealed class MergedAudioInput(ICloudAudioInput remote, IAudioInput local) : IMergedAudioInput, ICloudAudioInput, IEntity, IDisposable, IAudioInput
{
	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public IObservableProperty<Guid> Uuid => remote.Uuid;

	public IObservableProperty<string> UserDescription => remote.UserDescription;

	public IComplexObservableProperty<IAudioInput.Types.IBehaviorMode> BehaviorMode => local.BehaviorMode;

	public IComplexObservableProperty<IAudioInput.Types.ISource> Source => local.Source;

	public ICloudAudioInput Remote => remote;

	public IAudioInput Local => local;

	public void Dispose()
	{
		_disposables.Dispose();
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_disposables.Add(disposable);
	}
}
