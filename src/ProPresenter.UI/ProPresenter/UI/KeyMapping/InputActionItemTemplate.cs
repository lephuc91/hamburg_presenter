using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Utility;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.KeyMapping;

namespace ProPresenter.UI.KeyMapping;

public partial class InputActionItemTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ShowConflictsCommandProperty = DependencyProperty.Register("ShowConflictsCommand", typeof(ICommand), typeof(InputActionItemTemplate));

	public ICommand? ShowConflictsCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ShowConflictsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowConflictsCommandProperty, (object)value);
		}
	}

	public InputActionItemTemplate()
	{
		InitializeComponent();
	}

	private void GestureBox_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		e.Handled = true;
	}

	private void GestureBox_PreviewKeyUp(object? sender, KeyEventArgs e)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (base.DataContext is IInputActionItemVM inputActionItemVM)
		{
			bool ctrlPressed = KeyboardHelper.IsModifierPressed((ModifierKeys)2);
			bool altPressed = KeyboardHelper.IsModifierPressed((ModifierKeys)1);
			bool shiftPressed = KeyboardHelper.IsModifierPressed((ModifierKeys)4);
			inputActionItemVM.ChangeKeyboardGestureCommand?.Invoke(new KeyboardGestureCommandParameter(ctrlPressed, altPressed, shiftPressed, e.Key, e.SystemKey));
			e.Handled = true;
		}
	}
}
