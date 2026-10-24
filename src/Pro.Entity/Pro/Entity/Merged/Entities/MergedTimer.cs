using System;
using System.Reactive.Disposables;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public sealed class MergedTimer(ITimer remoteTimer, ILocalTimer localTimer) : IMergedTimer, ITimer, IEntity, IDisposable, ILocalTimer
{
	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public IObservableProperty<Guid> Uuid => remoteTimer.Uuid;

	public IObservableProperty<string> Name => remoteTimer.Name;

	public IComplexObservableProperty<ITimer.Types.IConfiguration> Configuration => localTimer.Configuration;

	public ITimer Remote => remoteTimer;

	public ILocalTimer Local => localTimer;

	public void Dispose()
	{
		_disposables.Dispose();
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_disposables.Add(disposable);
	}
}
