namespace ProPresenter.UI.ViewModels.Navigation;

public interface INavigationItem
{
	bool IsNavigable { get; }

	bool CanExit { get; }

	void PromptUnableToExit();
}
