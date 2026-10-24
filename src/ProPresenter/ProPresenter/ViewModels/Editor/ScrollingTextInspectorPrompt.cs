using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Editor;

internal class ScrollingTextInspectorPrompt : IScrollingTextInspectorPrompt
{
	public bool ConfirmRemoveTextReveal()
	{
		return MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("TEXT_INSPECTOR_TEXT_BUILDS_WITH_SCROLLING_ENABLED_ALERT_message") + "\r\n\r\n" + LocalizedStrings.Get("TEXT_INSPECTOR_TEXT_BUILDS_WITH_SCROLLING_ENABLED_ALERT_info"), DefaultButtons.YES | DefaultButtons.NO, DefaultButtons.NO) == DefaultButtons.YES;
	}

	public bool ConfirmRemoveTextFill()
	{
		return MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("TEXT_INSPECTOR_SCROLLING_WITH_ADVANCED_TEXT_FILL_ENABLED_ALERT_message") + "\r\n\r\n" + LocalizedStrings.Get("TEXT_INSPECTOR_SCROLLING_WITH_ADVANCED_TEXT_FILL_ENABLED_ALERT_info"), DefaultButtons.YES | DefaultButtons.NO, DefaultButtons.NO) == DefaultButtons.YES;
	}
}
