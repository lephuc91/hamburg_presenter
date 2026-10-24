using Pro.Common.FileSystem;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Editor;

public class FillMediaValidator : IMediaValidator
{
	public bool IsValid(string mediaFile)
	{
		if (!mediaFile.IsVisualMediaFile())
		{
			MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("EDITOR_PRESENTATION_SHAPE_INSPECTOR_FILL_AUDIO_NOT_SUPPORTED_alert"), DefaultButtons.OK, DefaultButtons.OK);
			return false;
		}
		return true;
	}
}
