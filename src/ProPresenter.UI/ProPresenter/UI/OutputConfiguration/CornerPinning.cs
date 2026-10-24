using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class CornerPinning : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ScreenProperty = DependencyProperty.Register("Screen", typeof(Screen), typeof(CornerPinning), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CornerPinning)(object)s).OnScreenChanged((Screen)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	private static readonly DependencyProperty CornerPinningOptionsProperty = DependencyProperty.Register("CornerPinningOptions", typeof(CornerPinningOptions), typeof(CornerPinning));

	private static readonly DependencyProperty ClipToMinMaxProperty = DependencyProperty.Register("ClipToMinMax", typeof(bool), typeof(CornerPinning), new PropertyMetadata((object)false));

	public Screen? Screen
	{
		get
		{
			return (Screen)((DependencyObject)this).GetValue(ScreenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScreenProperty, (object)value);
		}
	}

	private CornerPinningOptions? CornerPinningOptions
	{
		get
		{
			return (CornerPinningOptions)((DependencyObject)this).GetValue(CornerPinningOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CornerPinningOptionsProperty, (object)value);
		}
	}

	private bool ClipToMinMax
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ClipToMinMaxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClipToMinMaxProperty, (object)value);
		}
	}

	public CornerPinning()
	{
		InitializeComponent();
	}

	private void CornerPinningReset_Click(object? sender, RoutedEventArgs e)
	{
		Screen?.CornerPinning.ResetAll();
	}

	private void OnScreenChanged(Screen newScreen)
	{
		ClipToMinMax = false;
		CornerPinningOptions = newScreen?.CornerPinning;
		ClipToMinMax = true;
	}
}
