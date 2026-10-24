using System.Linq;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.ViewModels;

public class GroupNameValidator : IStringValueValidator
{
	private readonly ClearGroupCollection _clearGroups;

	public GroupNameValidator(ClearGroupCollection clearGroups)
	{
		_clearGroups = clearGroups;
	}

	public bool Validate(string? value)
	{
		if (_clearGroups == null)
		{
			return false;
		}
		if (_clearGroups.Any((ClearGroup c) => c.Name == value))
		{
			MessageDialogService.ShowSimpleContent(LocalizedStrings.Get("CLEAR_GROUPS_NAME_ALREADY_EXISTS_title"), LocalizedStrings.Get("CLEAR_GROUPS_NAME_ALREADY_EXISTS_message", new object[1] { value }), canCancel: false);
			return false;
		}
		return true;
	}
}
