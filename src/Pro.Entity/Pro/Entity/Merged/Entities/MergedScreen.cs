using System;
using System.Reactive.Disposables;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public sealed class MergedScreen(ICloudProPresenterScreen remote, IProPresenterScreen local) : IMergedScreen, ICloudProPresenterScreen, IEntity, IDisposable, IProPresenterScreen
{
	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public IObservableProperty<Guid> Uuid => remote.Uuid;

	public IObservableProperty<string> Name => remote.Name;

	public IObservableProperty<IProPresenterScreen.Types.ScreenType> ScreenType => remote.ScreenType;

	public IObservableProperty<IGraphics.Types.Size> Size => remote.Size;

	public IObservableProperty<bool> BackgroundColorEnabled => local.BackgroundColorEnabled;

	public IObservableProperty<Color> BackgroundColor => local.BackgroundColor;

	public IComplexObservableProperty<IProPresenterScreen.Types.IArrangement> Arrangement => local.Arrangement;

	public IComplexObservableProperty<IProPresenterScreen.Types.IRenderingEnabledOptional> RenderingEnabledOptional => local.RenderingEnabledOptional;

	public ICloudProPresenterScreen Remote => remote;

	public IProPresenterScreen Local => local;

	public void Dispose()
	{
		_disposables.Dispose();
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_disposables.Add(disposable);
	}
}
