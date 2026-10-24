using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Pro.Common.Operations;

namespace Pro.Common.Components;

public abstract class NotifyPropertyChangedDisposableBase : DisposableBase, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged(string? name)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	protected void SetValue<T>(ref T field, T value, Action<T, T>? changedCallback = null, Predicate<T>? validationCallback = null, bool referenceComparison = false, [CallerMemberName] string? propertyName = null)
	{
		bool num;
		if (!referenceComparison)
		{
			if (field.Equal(value))
			{
				return;
			}
			if (validationCallback == null)
			{
				goto IL_003f;
			}
			num = !validationCallback(value);
		}
		else
		{
			num = (object)field == (object)value;
		}
		if (num)
		{
			return;
		}
		goto IL_003f;
		IL_003f:
		T arg = field;
		field = value;
		OnPropertyChanged(propertyName);
		changedCallback?.Invoke(arg, value);
	}
}
