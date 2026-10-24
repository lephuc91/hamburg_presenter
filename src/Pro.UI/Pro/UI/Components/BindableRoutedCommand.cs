using System;
using System.Windows.Input;

namespace Pro.UI.Components;

public class BindableRoutedCommand : RoutedUICommand
{
	public InputGesture? InputGesture { get; private set; }

	public event Action? InputGestureUpdated;

	public BindableRoutedCommand(string? desc, string? name, Type ownerType)
		: base(desc ?? string.Empty, string.IsNullOrEmpty(name) ? ownerType.Name : name, ownerType)
	{
	}

	public void UpdateInputGesture(InputGesture? newGesture)
	{
		base.InputGestures.Clear();
		InputGesture = newGesture;
		if (newGesture != null)
		{
			base.InputGestures.Add(newGesture);
		}
		this.InputGestureUpdated?.Invoke();
	}
}
