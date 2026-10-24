using Pro.Common.Mathematics;

namespace ProPresenter.ViewModels;

public interface IQuickEditPrompt
{
	void Hide();

	void Show(Vector2<double> position);
}
