using System.Windows;

namespace Pro.UI.Components;

public abstract class DataMultiConverterBase<T> : BindableMultiConverterBase
{
	public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(T), typeof(DataMultiConverterBase<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)default(T), new PropertyChangedCallback(DataPropertyChanged)));

	public T Data
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(DataProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DataProperty, (object)value);
		}
	}

	private static void DataPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		if (callerObject is DataMultiConverterBase<T> dataMultiConverterBase && ((DependencyPropertyChangedEventArgs)(ref e)).OldValue is T oldValue && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is T newValue)
		{
			dataMultiConverterBase.OnDataPropertyChanged(oldValue, newValue);
		}
	}

	protected virtual void OnDataPropertyChanged(T oldValue, T newValue)
	{
	}
}
