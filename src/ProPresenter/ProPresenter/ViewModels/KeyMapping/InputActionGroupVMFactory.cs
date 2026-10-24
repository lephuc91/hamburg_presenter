using Pro.UI.InputActions;
using ProPresenter.UI.ViewModels.KeyMapping;

namespace ProPresenter.ViewModels.KeyMapping;

public class InputActionGroupVMFactory : IInputActionGroupVMFactory
{
	private readonly IKeyGesturePrompt _prompt;

	public InputActionGroupVMFactory(IKeyGesturePrompt prompt)
	{
		_prompt = prompt;
	}

	public IInputActionGroupVM Create(InputActionGroupBase group)
	{
		return new InputActionGroupVM(group, this);
	}

	public IInputActionItemVM Create(InputAction action)
	{
		return new InputActionItemVM(action, _prompt);
	}
}
