using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.ViewModels.ProContent.Asset;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ProContentPackAssetContainsDownloadEnableVM : ProContentPackAssetContainsVM, IProContentPackAssetContainsDownloadEnableVM, IProContentPackAssetContainsVM, INotifyPropertyChanged, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ProContentPackDownloadPreferences", "ShouldDownload")]
	private readonly IApp _app;

	private readonly ProContentDownloadAssetType _filterFlag;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool ShouldDownload
	{
		get
		{
			return ((ProContentDownloadAssetType)_app.ProContentPackDownloadPreferences).HasFlag(_filterFlag);
		}
		set
		{
			_app.ProContentPackDownloadPreferences = (value ? (_app.ProContentPackDownloadPreferences | (int)_filterFlag) : (_app.ProContentPackDownloadPreferences & (int)(~_filterFlag)));
		}
	}

	public ProContentPackAssetContainsDownloadEnableVM(string description, ProContentDownloadAssetType filterFlag, IApp app)
		: base(description)
	{
		_filterFlag = filterFlag;
		_app = app;
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
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _app_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ProContentPackDownloadPreferences")
		{
			OnPropertyChanged("ShouldDownload");
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
