using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Pro.Common.Collections;

namespace Pro.UI.Controls;

public class BindableTextBlock : TextBlock
{
	public static readonly DependencyProperty RunsProperty = DependencyProperty.Register("Runs", typeof(IEnumerable<Run>), typeof(BindableTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnRunsPropertyChanged)));

	public IEnumerable<Run>? Runs
	{
		get
		{
			return (IEnumerable<Run>)((DependencyObject)this).GetValue(RunsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RunsProperty, (object)value);
		}
	}

	private static void OnRunsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BindableTextBlock)(object)d).SetInlines(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as IEnumerable<Run>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IEnumerable<Run>);
	}

	public BindableTextBlock()
	{
		((DependencyObject)this).SetCurrentValue(RunsProperty, (object)new ObservableCollection<Run>());
	}

	private void SetInlines(IEnumerable<Run>? oldValue, IEnumerable<Run>? newValue)
	{
		base.Inlines.Clear();
		if (oldValue is INotifyCollectionChanged notifyCollectionChanged)
		{
			notifyCollectionChanged.CollectionChanged -= Runs_CollectionChanged;
		}
		if (newValue is INotifyCollectionChanged notifyCollectionChanged2)
		{
			notifyCollectionChanged2.CollectionChanged += Runs_CollectionChanged;
		}
		base.Inlines.AddRange(newValue ?? Enumerable.Empty<Run>());
	}

	private void Runs_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<Run>().ForEach(delegate(Run r)
		{
			base.Inlines.Remove(r);
		});
		e.NewItems?.OfType<Run>().ForEach(base.Inlines.Add);
	}
}
