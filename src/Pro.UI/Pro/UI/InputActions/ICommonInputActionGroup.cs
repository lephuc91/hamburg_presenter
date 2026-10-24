namespace Pro.UI.InputActions;

public interface ICommonInputActionGroup
{
	InputAction ChangeOutputDestination { get; }

	InputAction Copy { get; }

	InputAction Cut { get; }

	InputAction Delete { get; }

	InputAction DeselectAll { get; }

	InputAction Duplicate { get; }

	InputAction Find { get; }

	InputAction NavigateDown { get; }

	InputAction NavigateUp { get; }

	InputAction Open { get; }

	InputAction Paste { get; }

	InputAction PasteAndMatchStyle { get; }

	InputAction Print { get; }

	InputAction Redo { get; }

	InputAction Rename { get; }

	InputAction SelectAll { get; }

	InputAction SelectNextCommand { get; }

	InputAction SelectPreviousCommand { get; }

	InputAction Submit { get; }

	InputAction Undo { get; }
}
