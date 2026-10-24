using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Updates;
using ProPresenter.UI.ViewModels.Updates;

namespace ProPresenter.ViewModels.Updates;

public class AppDownloadVM : ObservableObject, IAppDownloadVM, INotifyPropertyChanged
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("DownloadPercentComplete", "PercentComplete")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("DownloadFinished", "DownloadComplete")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("DownloadSuccessful", "DownloadSuccessful")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("BytesDownloaded", "BytesDownloaded")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("TotalBytes", "TotalBytes")]
	[Pro.Common.SourceGenerator.Attributes.NotifyCanExecuteChangedLink("DownloadSuccessful", "InstallCommand")]
	private readonly IAppDownload _appDownload;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cancelCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? installCommand;

	public int PercentComplete => _appDownload.DownloadPercentComplete;

	public long BytesDownloaded => _appDownload.BytesDownloaded;

	public long TotalBytes => _appDownload.TotalBytes;

	public bool DownloadComplete => _appDownload.DownloadFinished;

	public bool DownloadSuccessful => _appDownload.DownloadSuccessful;

	private bool CanInstall => _appDownload.DownloadSuccessful;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CancelCommand => cancelCommand ?? (cancelCommand = new RelayCommand(Cancel));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand InstallCommand => installCommand ?? (installCommand = new RelayCommand(Install, () => CanInstall));

	public AppDownloadVM(IAppDownload appDownload)
	{
		_appDownload = appDownload;
		AddPropertyLinks();
	}

	[RelayCommand]
	private void Cancel()
	{
		_appDownload.CancelDownload();
	}

	[RelayCommand(CanExecute = "CanInstall")]
	private void Install()
	{
		_appDownload.GetInstaller()?.Install();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _appDownload_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "DownloadPercentComplete":
			OnPropertyChanged("PercentComplete");
			break;
		case "DownloadFinished":
			OnPropertyChanged("DownloadComplete");
			break;
		case "DownloadSuccessful":
			OnPropertyChanged("DownloadSuccessful");
			InstallCommand.NotifyCanExecuteChanged();
			break;
		case "BytesDownloaded":
			OnPropertyChanged("BytesDownloaded");
			break;
		case "TotalBytes":
			OnPropertyChanged("TotalBytes");
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_appDownload.PropertyChanged += _appDownload_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_appDownload.PropertyChanged -= _appDownload_PropertyChanged;
	}
}
