using Pro.Common.MessageService;

namespace ProPresenter.DO.Themes;

public class ThemePickerSettingsUpdatedMessage : IMessage
{
	public ThemePickerSettingsModel Model { get; }

	public ThemePickerSettingsUpdatedMessage(ThemePickerSettingsModel model)
	{
		Model = model;
	}
}
