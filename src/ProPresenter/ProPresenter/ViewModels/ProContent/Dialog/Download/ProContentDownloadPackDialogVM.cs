using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Animation;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization.Services;
using ProPresenter.DO;
using ProPresenter.DO.Cache;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;
using ProPresenter.ViewModels.ProContent.Asset;

namespace ProPresenter.ViewModels.ProContent.Dialog.Download;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ProContentDownloadPackDialogVM : ProContentDownloadDialogWithThumbnailVMBase, IProContentDownloadPackDialogVM, IProContentDownloadDialogWithThumbnailVM, IProContentDownloadDialogVM, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ProContentPackDownloadPreferences", "AssetTypesToDownload")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ProContentPackDownloadPreferences", "CanStartDownload")]
	private readonly IApp _app;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IReadOnlyList<IProContentPackAssetContainsDownloadEnableVM> Contains { get; }

	public string PackTitle { get; }

	public ProContentDownloadAssetType AssetTypesToDownload => (ProContentDownloadAssetType)_app.ProContentPackDownloadPreferences;

	public override bool CanStartDownload
	{
		get
		{
			if (base.CanStartDownload)
			{
				return Contains.Any((IProContentPackAssetContainsDownloadEnableVM c) => c.ShouldDownload);
			}
			return false;
		}
	}

	public ProContentDownloadPackDialogVM(IProPresenterResourceService resources, IApp app, ILocalization localization, IUriCacheService<NullableBitmapSource> thumbnailCacheService, IUriCacheService<IReadOnlyList<IAnimationFrame>> previewCacheService, IProContentPackAsset pack)
		: base(resources, app, thumbnailCacheService, previewCacheService, pack)
	{
		PackTitle = pack.DisplayName;
		_app = app;
		Contains = pack.ToContains(localization, app);
		Contains.ForEach(delegate(IProContentPackAssetContainsDownloadEnableVM c)
		{
			c.PropertyChanged += delegate
			{
				OnPropertyChanged("CanStartDownload");
			};
		});
		AddPropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		foreach (IProContentPackAssetContainsDownloadEnableVM contain in Contains)
		{
			contain.Dispose();
		}
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _app_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ProContentPackDownloadPreferences")
		{
			OnPropertyChanged("AssetTypesToDownload");
			OnPropertyChanged("CanStartDownload");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_app.PropertyChanged += _app_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_app.PropertyChanged -= _app_PropertyChanged;
	}
}
