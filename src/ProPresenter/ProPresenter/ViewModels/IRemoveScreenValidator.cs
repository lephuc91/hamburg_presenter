using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.ViewModels;

public interface IRemoveScreenValidator
{
	bool CanRemoveScreen(ScreenArrangementBase target);
}
