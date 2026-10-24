namespace ProPresenter.ViewModels.KeyMapping;

public interface IKeyGesturePrompt
{
	void ShowNeedsModifier(string name);

	void ShowGestureIsReservedForAlternate(string name, string alterName);

	bool ShowResetAllConfirmation();
}
