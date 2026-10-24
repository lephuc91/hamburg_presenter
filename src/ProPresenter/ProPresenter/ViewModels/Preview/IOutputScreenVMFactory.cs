using Pro.UI.InputActions;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.ViewModels.Preview;

public interface IOutputScreenVMFactory
{
	IOutputScreenVM Create(ScreenArrangementBase screen);

	IOutputScreenVM Create(InputAction inputAction);
}
