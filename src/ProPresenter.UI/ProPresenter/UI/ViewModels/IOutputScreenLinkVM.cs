using System.Collections.Generic;
using Pro.UI.Components;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.ViewModels;

public interface IOutputScreenLinkVM
{
	IEnumerable<ScreenArrangementBase> Screens { get; }

	ScreenArrangementBase? SelectedScreen { get; }

	ICommand<ScreenArrangementBase> SelectScreeenCommand { get; }
}
