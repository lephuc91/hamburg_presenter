using Pro.UI.InputActions;
using ProPresenter.UI.ViewModels.KeyMapping;

namespace ProPresenter.ViewModels.KeyMapping;

public interface IInputActionGroupVMFactory
{
	IInputActionGroupVM Create(InputActionGroupBase group);

	IInputActionItemVM Create(InputAction action);
}
