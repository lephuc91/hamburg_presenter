using Pro.Common.MessageService;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO;

public class EditThemeTemplateMessage : IMessage
{
	public Theme? TargetTheme { get; }

	public EditMode Mode { get; }

	public EditThemeTemplateMessage(Theme? theme, EditMode editMode)
	{
		TargetTheme = theme;
		Mode = editMode;
	}
}
