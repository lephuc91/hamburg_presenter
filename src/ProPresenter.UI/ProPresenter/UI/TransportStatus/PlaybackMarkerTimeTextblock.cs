using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace ProPresenter.UI.TransportStatus;

public partial class PlaybackMarkerTimeTextblock : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DisplayAltTextProperty = DependencyProperty.Register("DisplayAltText", typeof(bool), typeof(PlaybackMarkerTimeTextblock));

	public static readonly DependencyProperty PrimaryTextProperty = DependencyProperty.Register("PrimaryText", typeof(string), typeof(PlaybackMarkerTimeTextblock));

	public static readonly DependencyProperty AltTextProperty = DependencyProperty.Register("AltText", typeof(string), typeof(PlaybackMarkerTimeTextblock));

	public static readonly DependencyProperty AltFillProperty = DependencyProperty.Register("AltFill", typeof(Brush), typeof(PlaybackMarkerTimeTextblock));

	public static readonly DependencyProperty CanUseAltProperty = DependencyProperty.Register("CanUseAlt", typeof(bool), typeof(PlaybackMarkerTimeTextblock));

	public bool DisplayAltText
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DisplayAltTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayAltTextProperty, (object)value);
		}
	}

	public string? PrimaryText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(PrimaryTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrimaryTextProperty, (object)value);
		}
	}

	public string? AltText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AltTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AltTextProperty, (object)value);
		}
	}

	public Brush? AltFill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(AltFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AltFillProperty, (object)value);
		}
	}

	public bool CanUseAlt
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanUseAltProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanUseAltProperty, (object)value);
		}
	}

	public PlaybackMarkerTimeTextblock()
	{
		InitializeComponent();
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		((DependencyObject)this).SetCurrentValue(DisplayAltTextProperty, (object)(!DisplayAltText));
	}
}
