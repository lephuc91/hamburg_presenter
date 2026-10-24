using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Versioning;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Updates;
using ProPresenter.UI.ViewModels.Updates;

namespace ProPresenter.ViewModels.Updates;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class UpdatesViewerVM : ObservableObject, IUpdatesViewerVM, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ReleaseNotes", "ReleaseNotes")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("BuildAvailable", "NewVersion")]
	private readonly IAppUpdateService _appUpdateService;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? skipThisVersionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? downloadUpdateCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string ReleaseNotes => _appUpdateService.ReleaseNotes;

	public string NewVersion
	{
		get
		{
			BuildInformation buildAvailable = _appUpdateService.BuildAvailable;
			if (!(buildAvailable == null))
			{
				return $"{buildAvailable.Version} ({buildAvailable.BuildNumber})";
			}
			return string.Empty;
		}
	}

	public string InstalledVersion { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SkipThisVersionCommand => skipThisVersionCommand ?? (skipThisVersionCommand = new RelayCommand(SkipThisVersion));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand DownloadUpdateCommand => downloadUpdateCommand ?? (downloadUpdateCommand = new RelayCommand(DownloadUpdate));

	public UpdatesViewerVM(IAppUpdateService appUpdateService, IVersionInfoProvider versionInfoProvider)
	{
		_appUpdateService = appUpdateService;
		InstalledVersion = versionInfoProvider.FullDisplayAppVersion;
		AddPropertyLinks();
	}

	[RelayCommand]
	private void SkipThisVersion()
	{
		if ((object)_appUpdateService.BuildAvailable != null)
		{
			_appUpdateService.SkipVersion(_appUpdateService.BuildAvailable);
		}
	}

	[RelayCommand]
	private void DownloadUpdate()
	{
		if ((object)_appUpdateService.BuildAvailable != null)
		{
			_appUpdateService.InstallVersion(_appUpdateService.BuildAvailable);
		}
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
	private void _appUpdateService_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "ReleaseNotes"))
		{
			if (propertyName == "BuildAvailable")
			{
				OnPropertyChanged("NewVersion");
			}
		}
		else
		{
			OnPropertyChanged("ReleaseNotes");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_appUpdateService.PropertyChanged += _appUpdateService_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_appUpdateService.PropertyChanged -= _appUpdateService_PropertyChanged;
	}
}
