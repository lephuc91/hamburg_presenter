using Pro.DO.Triggering;

namespace ProPresenter.ViewModels.ActionsMenu;

public interface IAddActionInteractor
{
	IAction? Execute(IAction? action);
}
