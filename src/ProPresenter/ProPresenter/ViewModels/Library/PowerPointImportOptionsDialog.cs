using System.Windows;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.UI.LibraryView;

namespace ProPresenter.ViewModels.Library;

public class PowerPointImportOptionsDialog : IPowerPointImportOptionsDialog
{
	private readonly IMessageDialogService _messageDialogService;

	public PowerPointImportOptionsDialog(IMessageDialogService messageDialogService)
	{
		_messageDialogService = messageDialogService;
	}

	public bool? ShowLegacyPowerPointImportOptions()
	{
		PowerPointImportSelectorContent powerPointImportSelectorContent = new PowerPointImportSelectorContent();
		DefaultButtons buttons = DefaultButtons.OK | DefaultButtons.CANCEL;
		if (_messageDialogService.ShowDialog(LocalizedStrings.Get("IMPORT_POWERPOINT_OPTIONS_ALERT_title"), (DependencyObject)(object)powerPointImportSelectorContent, buttons, DefaultButtons.OK, DialogIcon.WithHiddenIcon) != DefaultButtons.OK)
		{
			return null;
		}
		return powerPointImportSelectorContent.UseLegacyImport;
	}
}
