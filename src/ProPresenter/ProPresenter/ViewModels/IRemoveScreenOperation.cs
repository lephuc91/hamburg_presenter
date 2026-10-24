using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.ViewModels;

public interface IRemoveScreenOperation
{
	bool Execute(ScreenArrangementBase target, ScreenArrangementCollectionBase collection, out ScreenArrangementBase? newSelection);
}
