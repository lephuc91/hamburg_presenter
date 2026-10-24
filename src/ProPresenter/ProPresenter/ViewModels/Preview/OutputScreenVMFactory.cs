using Pro.UI.InputActions;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.ViewModels.Preview;

public class OutputScreenVMFactory : IOutputScreenVMFactory
{
	public IOutputScreenVM Create(ScreenArrangementBase screen)
	{
		return new OutputScreenVM(screen);
	}

	public IOutputScreenVM Create(InputAction inputAction)
	{
		return new OutputScreenVM(inputAction);
	}
}
