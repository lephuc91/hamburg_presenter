using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using Pro.UI.InputActions;

namespace ProPresenter.UI.ViewModels.KeyMapping;

public interface IInputActionItemVM : INotifyPropertyChanged
{
	InputActionType Type { get; }

	string Label { get; }

	VirtualKeyGesture? DefaultKeyboardGesture { get; }

	VirtualKeyGesture? KeyboardGesture { get; }

	string DefaultKeyboardGestureText { get; }

	string KeyboardGestureText { get; }

	bool HasConflicts { get; }

	bool IsCustomized { get; }

	string ConflictMessage { get; }

	string DetailText { get; }

	ICommand<KeyboardGestureCommandParameter> ChangeKeyboardGestureCommand { get; }

	ICommand ClearKeyboardGestureCommand { get; }
}
