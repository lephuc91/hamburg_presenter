using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.InputActions;
using ProPresenter.UI.ViewModels.KeyMapping;

namespace ProPresenter.ViewModels.KeyMapping;

public class InputActionItemVM : LinkedNotifyPropertyChangedBase, IInputActionItemVM, INotifyPropertyChanged
{
	private readonly IKeyGesturePrompt _prompt;

	public InputActionType Type => Action.Type;

	public string Label => Action.AccessPath;

	public VirtualKeyGesture? DefaultKeyboardGesture => Action.DefaultKeyboardGesture;

	public VirtualKeyGesture? KeyboardGesture => Action.KeyboardGesture;

	public string DefaultKeyboardGestureText
	{
		get
		{
			if ((object)Action.DefaultKeyboardGesture != null)
			{
				return LocalizedStrings.Get("KEYMAPPING_PREFERENCES_DEFAULT_SHORTCUT_KEYBOARD_EQUIVALENT_tooltip", new object[1] { Action.DefaultKeyboardGesture.GestureText });
			}
			return LocalizedStrings.Get("KEYMAPPING_PREFERENCES_DEFAULT_SHORTCUT_NONE_tooltip");
		}
	}

	public string KeyboardGestureText => Action.KeyboardGesture?.GestureText ?? string.Empty;

	public bool HasConflicts => Action.HasConflicts;

	public bool IsCustomized => Action.IsCustomized;

	public string ConflictMessage
	{
		get
		{
			if (!HasConflicts)
			{
				return string.Empty;
			}
			return LocalizedStrings.Get("KEYMAPPING_PREFERENCES_VALIDATION_CONFLICT_message", new object[2]
			{
				KeyboardGestureText,
				string.Join(",", Action.Conflicts.Select((InputAction a) => a.Label).ToArray())
			});
		}
	}

	public string DetailText
	{
		get
		{
			if (!HasConflicts)
			{
				return DefaultKeyboardGestureText;
			}
			return ConflictMessage;
		}
	}

	public ICommand<KeyboardGestureCommandParameter> ChangeKeyboardGestureCommand => new RelayCommand<KeyboardGestureCommandParameter>(OnChangeKeyboardGestureCommand);

	public ICommand ClearKeyboardGestureCommand => new RelayCommand(OnClearKeyboardGestureCommand);

	private InputAction Action { get; }

	public InputActionItemVM(InputAction action, IKeyGesturePrompt prompt)
	{
		Action = action;
		_prompt = prompt;
		LinkProperties("KeyboardGesture", new string[2] { "KeyboardGesture", "KeyboardGestureText" });
		LinkProperties("DefaultKeyboardGesture", "DefaultKeyboardGesture");
		LinkProperties("IsCustomized", "IsCustomized");
		LinkProperties("AccessPath", "Label");
		LinkProperties("DefaultKeyboardGesture", "DefaultKeyboardGesture");
		LinkProperties("KeyboardGesture", "KeyboardGesture");
		LinkProperties("HasConflicts", new string[4] { "HasConflicts", "ConflictMessage", "DefaultKeyboardGestureText", "DetailText" });
		Action.PropertyChanged += base.RaiseLinkedValues;
		Action.DidUpdateKeyGesture += Action_DidUpdateKeyGesture;
	}

	private void OnChangeKeyboardGestureCommand(KeyboardGestureCommandParameter param)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		bool ctrlPressed = param.CtrlPressed;
		bool altPressed = param.AltPressed;
		bool shiftPressed = param.ShiftPressed;
		Key val = (((int)param.Key == 156) ? param.SystemKey : param.Key);
		ModifierKeys val2 = (ModifierKeys)0;
		if (ctrlPressed)
		{
			val2 = (ModifierKeys)(val2 | 2);
		}
		if (altPressed)
		{
			val2 = (ModifierKeys)(val2 | 1);
		}
		if (shiftPressed && (altPressed || ctrlPressed))
		{
			val2 = (ModifierKeys)(val2 | 4);
		}
		if (!val.IsModifierKey() && (int)val != 156 && val.IsSupported(out var virtualKey))
		{
			Action.KeyboardGesture = VirtualKeyGesture.CreateKeyGesture(virtualKey, val2);
		}
	}

	private void Action_DidUpdateKeyGesture(bool success)
	{
		if (!success && Action.Type != InputActionType.GroupLabel)
		{
			_prompt?.ShowNeedsModifier(Label);
		}
	}

	private void OnClearKeyboardGestureCommand()
	{
		Action.KeyboardGesture = null;
	}
}
