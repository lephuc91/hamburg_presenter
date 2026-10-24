using System.Collections.Generic;
using ProPresenter.UI.PresentationView;

namespace ProPresenter.UI.ViewModels.Presentation;

public interface IHeaderContentContextMenuVM
{
	List<HeaderContextMenuItem> MenuItems { get; }

	void BuildMenuItems(IPresentationHeaderVM viewModel);
}
