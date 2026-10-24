using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Pro.UI.Controls;

[ContentProperty("Collection")]
public partial class GroupedControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CollectionProperty = DependencyProperty.Register("Collection", typeof(Collection<object>), typeof(GroupedControl));

	public static readonly DependencyProperty GroupBackgroundProperty = DependencyProperty.Register("GroupBackground", typeof(Brush), typeof(GroupedControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(SolidColorBrush)new BrushConverter().ConvertFromString("#2A2A2A")));

	public static readonly DependencyProperty SeparatorBackgroundProperty = DependencyProperty.Register("SeparatorBackground", typeof(Brush), typeof(GroupedControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(SolidColorBrush)new BrushConverter().ConvertFromString("#3F3F3F")));

	public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(GroupedControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Thickness(8.0)));

	public static readonly DependencyProperty ItemContentTemplateProperty = DependencyProperty.Register("ItemContentTemplate", typeof(DataTemplate), typeof(GroupedControl), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty ItemsProperty;

	public Collection<object> Collection
	{
		get
		{
			return (Collection<object>)((DependencyObject)this).GetValue(CollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CollectionProperty, (object)value);
		}
	}

	public Brush GroupBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(GroupBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GroupBackgroundProperty, (object)value);
		}
	}

	public Brush SeparatorBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(SeparatorBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SeparatorBackgroundProperty, (object)value);
		}
	}

	public Thickness ContentMargin
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(ContentMarginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentMarginProperty, (object)value);
		}
	}

	public DataTemplate? ItemContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(ItemContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemContentTemplateProperty, (object)value);
		}
	}

	public IReadOnlyCollection<object>? Items
	{
		get
		{
			return (IReadOnlyCollection<object>)((DependencyObject)this).GetValue(ItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsProperty, (object)value);
		}
	}

	private static void Items_ProerptyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (!(d is GroupedControl groupedControl) || !(((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IReadOnlyCollection<object> readOnlyCollection))
		{
			return;
		}
		groupedControl.Collection.Clear();
		foreach (object item in readOnlyCollection)
		{
			groupedControl.Collection.Add(item);
		}
	}

	public GroupedControl()
	{
		InitializeComponent();
		((DependencyObject)this).SetCurrentValue(CollectionProperty, (object)new ObservableCollection<object>());
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	static GroupedControl()
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		Type? typeFromHandle = typeof(IReadOnlyCollection<object>);
		Type? typeFromHandle2 = typeof(GroupedControl);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata).PropertyChangedCallback = new PropertyChangedCallback(Items_ProerptyChanged);
		ItemsProperty = DependencyProperty.Register("Items", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
	}
}
