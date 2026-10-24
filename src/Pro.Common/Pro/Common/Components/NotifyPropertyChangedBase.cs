using System;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Operations;

namespace Pro.Common.Components;

public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged(string? propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected void SetValue<T>(string propertyName, ref T storageVariable, T value, Action changedCallback, Predicate<T>? validationCallback = null, bool referenceComparison = false)
	{
		SetValue(propertyName, ref storageVariable, value, (Action<T, T>?)delegate
		{
			changedCallback?.Invoke();
		}, validationCallback, referenceComparison);
	}

	protected void SetValue<T>(string propertyName, ref T storageVariable, T value, Predicate<T>? validationCallback = null, bool referenceComparison = false, params string[] otherProperties)
	{
		SetValue(propertyName, ref storageVariable, value, (Action)delegate
		{
			otherProperties?.ForEach(OnPropertyChanged);
		}, validationCallback, referenceComparison);
	}

	protected void SetValue<T>(string propertyName, ref T storageVariable, T value, Action<T, T>? changedCallback = null, Predicate<T>? validationCallback = null, bool referenceComparison = false)
	{
		bool num;
		if (!referenceComparison)
		{
			if (storageVariable.Equal(value))
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
			num = (object)storageVariable == (object)value;
		}
		if (num)
		{
			return;
		}
		goto IL_003f;
		IL_003f:
		T arg = storageVariable;
		storageVariable = value;
		OnPropertyChanged(propertyName);
		changedCallback?.Invoke(arg, value);
	}

	protected void SetValue<T>(T currentValue, T newValue, Action changedCallback, Predicate<T>? validationCallback = null, bool referenceComparison = false)
	{
		SetValue(currentValue, newValue, (Action<T, T>)delegate
		{
			changedCallback();
		}, validationCallback, referenceComparison);
	}

	protected void SetValue<T>(T currentValue, T newValue, Action<T, T> changedCallback, Predicate<T>? validationCallback = null, bool referenceComparison = false)
	{
		bool num;
		if (!referenceComparison)
		{
			if (currentValue.Equal(newValue))
			{
				return;
			}
			if (validationCallback == null)
			{
				goto IL_0035;
			}
			num = !validationCallback(newValue);
		}
		else
		{
			num = (object)currentValue == (object)newValue;
		}
		if (num)
		{
			return;
		}
		goto IL_0035;
		IL_0035:
		changedCallback?.Invoke(currentValue, newValue);
	}
}
