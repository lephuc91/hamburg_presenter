using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.UI.Components;
using Pro.UI.InputActions;
using ProPresenter.DO.InputActionMap.OutputScreen;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.ViewModels.Preview;

public sealed class OutputScreenVM : LinkedNotifyPropertyChangedBase, IOutputScreenVMInternal, IOutputScreenVM, INotifyPropertyChanged, IEquatable<IOutputScreenVM>
{
	private readonly ScreenArrangementBase? _screen;

	private readonly InputAction? _inputAction;

	public Guid Id => _screen?.ID ?? Guid.Empty;

	public string Name => _screen?.Name ?? string.Empty;

	public ScreenArrangementBase? Screen => _screen;

	public BindableRoutedCommand? Command { get; private set; }

	public OutputScreenVM(ScreenArrangementBase? screen)
	{
		_screen = screen;
		LinkProperties("Name", "Name");
		if (_screen != null)
		{
			_screen.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	public OutputScreenVM(InputAction inputAction)
		: this((inputAction as OutputScreenInputAction)?.Screen)
	{
		_inputAction = inputAction;
		Command = new BindableRoutedCommand(inputAction.Identifier, inputAction.Label, inputAction.ParentGroup.GetType());
		LinkAction("KeyboardGesture", OnKeyboardGestureChanged);
		inputAction.PropertyChanged += base.RaiseLinkedValues;
	}

	private void OnKeyboardGestureChanged()
	{
		if (_inputAction != null && Command != null)
		{
			Command.UpdateInputGesture(_inputAction.KeyboardGesture.ToKeyGesture());
		}
	}

	public bool Equals(IOutputScreenVM? other)
	{
		if (other is IOutputScreenVMInternal outputScreenVMInternal)
		{
			return outputScreenVMInternal.Screen == _screen;
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		return Equals(obj as IOutputScreenVM);
	}

	public override int GetHashCode()
	{
		return _screen?.GetHashCode() ?? (-1);
	}
}
