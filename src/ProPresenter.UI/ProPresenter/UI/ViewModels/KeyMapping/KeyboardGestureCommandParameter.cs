using System.Windows.Input;

namespace ProPresenter.UI.ViewModels.KeyMapping;

public class KeyboardGestureCommandParameter
{
	public bool CtrlPressed { get; }

	public bool AltPressed { get; }

	public bool ShiftPressed { get; }

	public Key Key { get; }

	public Key SystemKey { get; }

	public KeyboardGestureCommandParameter(bool ctrlPressed, bool altPressed, bool shiftPressed, Key key, Key systemKey)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		CtrlPressed = ctrlPressed;
		AltPressed = altPressed;
		ShiftPressed = shiftPressed;
		Key = key;
		SystemKey = systemKey;
	}
}
