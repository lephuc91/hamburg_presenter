using System.IO;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.UI.Components;
using ProPresenter.DO.Export;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Export;

public class ExportVM : LinkedNotifyPropertyChangedBase, IExportVM
{
	private string _exportName = string.Empty;

	private readonly IExportImagesInteractor _exportImagesInteractor;

	private readonly IExportImagesPrompt _exportImagesPrompt;

	private readonly IApp _app;

	public ImageExportExtension ImageExportExtension
	{
		get
		{
			return _app.ExportImageExtension;
		}
		set
		{
			_app.ExportImageExtension = value;
		}
	}

	public string Directory
	{
		get
		{
			return _app.ExportDirectory;
		}
		set
		{
			_app.ExportDirectory = value;
		}
	}

	public string ExportName
	{
		get
		{
			return _exportName;
		}
		set
		{
			SetValue("ExportName", ref _exportName, value, null, false, "FullFilePath");
		}
	}

	public string FullFilePath => Path.Combine(Directory, ExportName);

	public bool IncludeMedia
	{
		get
		{
			return _app.ExportIncludeMedia;
		}
		set
		{
			_app.ExportIncludeMedia = value;
		}
	}

	public ICommand ExportToImagesCommand => new RelayCommand(OnExportToImagesCommand, () => _exportImagesInteractor?.CanExecute() ?? false);

	public ExportVM(IExportImagesInteractor exportImagesInteractor, IApp app, IExportImagesPrompt? exportImagesPrompt = null)
	{
		_app = app;
		_exportImagesInteractor = exportImagesInteractor;
		_exportImagesPrompt = exportImagesPrompt ?? new ExportImagesPrompt(this);
		HookupSettings();
	}

	private void HookupSettings()
	{
		LinkProperties("ExportImageExtension", "ImageExportExtension");
		LinkProperties("ExportDirectory", new string[2] { "Directory", "FullFilePath" });
		LinkProperties("ExportIncludeMedia", "IncludeMedia");
		_app.PropertyChanged += base.RaiseLinkedValues;
	}

	private void OnExportToImagesCommand()
	{
		ExportName = _exportImagesInteractor.GetInitialExportName();
		if (_exportImagesPrompt.Confirm())
		{
			_exportImagesInteractor.Execute(new ExportImageSettings(ImageExportExtension, Directory.Trim(), ExportName.Trim(), IncludeMedia));
		}
	}
}
