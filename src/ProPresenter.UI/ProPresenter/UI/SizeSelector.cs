using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.Localization;
using ProPresenter.DO;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI;

public partial class SizeSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target", typeof(ISizeableTarget), typeof(SizeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SizeSelector)(object)s).VM.Target = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ISizeableTarget;
	}));

	public static readonly DependencyProperty SelectedSizeProperty = DependencyProperty.Register("SelectedSize", typeof(Vector2<double>), typeof(SizeSelector));

	public static readonly DependencyProperty ResizeButtonContentProperty = DependencyProperty.Register("ResizeButtonContent", typeof(string), typeof(SizeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)LocalizedStrings.Get("EDITOR_PRESENTATION_PRESENTATION_INSPECTOR_SIZE_MISMATCH_BUTTON_title")));

	public static readonly DependencyProperty UnconfiguredSizeMessageProperty = DependencyProperty.Register("UnconfiguredSizeMessage", typeof(string), typeof(SizeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)LocalizedStrings.Get("EDITOR_PRESENTATION_PRESENTATION_INSPECTOR_SIZE_MISMATCH_label")));

	public static readonly DependencyProperty SetTargetToDefaultSizeProperty = DependencyProperty.Register("SetTargetToDefaultSize", typeof(bool), typeof(SizeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SizeSelector)(object)s).VM.SetTargetToDefaultSize = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}));

	public static readonly DependencyProperty ConfirmResizeProperty = DependencyProperty.Register("ConfirmResize", typeof(Func<Vector2<double>, bool>), typeof(SizeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SizeSelector)(object)s).VM.ConfirmResize = (Func<Vector2<double>, bool>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}));

	public static readonly DependencyProperty ScreenTargetTypeProperty = DependencyProperty.Register("ScreenTargetType", typeof(ScreenTargetType), typeof(SizeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ScreenTargetType.Audience, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SizeSelector)(object)s).VM.ScreenTargetType = (ScreenTargetType)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}));

	private SizeSelectorVM VM => (SizeSelectorVM)base.DataContext;

	public ISizeableTarget Target
	{
		get
		{
			return (ISizeableTarget)((DependencyObject)this).GetValue(TargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetProperty, (object)value);
		}
	}

	public Vector2<double> SelectedSize
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(SelectedSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedSizeProperty, (object)value);
		}
	}

	public string ResizeButtonContent
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ResizeButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResizeButtonContentProperty, (object)value);
		}
	}

	public string UnconfiguredSizeMessage
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(UnconfiguredSizeMessageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnconfiguredSizeMessageProperty, (object)value);
		}
	}

	public bool SetTargetToDefaultSize
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SetTargetToDefaultSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetTargetToDefaultSizeProperty, (object)value);
		}
	}

	public Func<Vector2<double>, bool> ConfirmResize
	{
		get
		{
			return (Func<Vector2<double>, bool>)((DependencyObject)this).GetValue(ConfirmResizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ConfirmResizeProperty, (object)value);
		}
	}

	public ScreenTargetType ScreenTargetType
	{
		get
		{
			return (ScreenTargetType)((DependencyObject)this).GetValue(ScreenTargetTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScreenTargetTypeProperty, (object)value);
		}
	}

	public SizeSelector()
	{
		InitializeComponent();
		VM.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "SelectedSize")
			{
				((DependencyObject)this).SetValue(SelectedSizeProperty, (object)VM.SelectedSize);
			}
		};
	}

	private void ContextMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu contextMenu)
		{
			contextMenu.Items.Refresh();
		}
	}
}
