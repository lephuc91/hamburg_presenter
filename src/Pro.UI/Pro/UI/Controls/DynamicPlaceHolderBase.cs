using System.Windows;

namespace Pro.UI.Controls;

public abstract class DynamicPlaceHolderBase<T> : DependencyObject
{
	public static readonly DependencyProperty DisplayMemberProperty = DependencyProperty.Register("DisplayMember", typeof(string), typeof(DynamicPlaceHolderBase<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDisplayMemberDependencyPropertyChanged)));

	public static readonly DependencyProperty DisplayValueProperty = DependencyProperty.Register("DisplayValue", typeof(T), typeof(DynamicPlaceHolderBase<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDisplayValueDependencyPropertyChanged)));

	public string DisplayMember
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DisplayMemberProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayMemberProperty, (object)value);
		}
	}

	public T? DisplayValue
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(DisplayValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayValueProperty, (object)value);
		}
	}

	public override string ToString()
	{
		return DisplayMember;
	}

	protected virtual void OnDisplayMemberChanged(string oldValue, string newValue)
	{
	}

	protected virtual void OnDisplayValueChanged(T oldValue, T newValue)
	{
	}

	private static void OnDisplayMemberDependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DynamicPlaceHolderBase<T>)(object)d).OnDisplayMemberChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnDisplayValueDependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DynamicPlaceHolderBase<T>)(object)d).OnDisplayValueChanged((T)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (T)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}
}
