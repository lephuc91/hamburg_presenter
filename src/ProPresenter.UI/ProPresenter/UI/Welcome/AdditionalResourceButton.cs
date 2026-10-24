using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace ProPresenter.UI.Welcome;

public partial class AdditionalResourceButton : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(AdditionalResourceButton), new PropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(AdditionalResourceButton), new PropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(AdditionalResourceButton));

	public static readonly DependencyProperty IconColorProperty = DependencyProperty.Register("IconColor", typeof(Brush), typeof(AdditionalResourceButton), new PropertyMetadata((object)Brushes.White));

	public static readonly DependencyProperty AdditionalIconProperty = DependencyProperty.Register("AdditionalIcon", typeof(ImageSource), typeof(AdditionalResourceButton));

	public static readonly DependencyProperty AdditionalIconColorProperty = DependencyProperty.Register("AdditionalIconColor", typeof(Brush), typeof(AdditionalResourceButton), new PropertyMetadata((object)Brushes.White));

	public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(AdditionalResourceButton), new PropertyMetadata((object)new SolidColorBrush(Color.FromArgb(64, 0, 0, 0))));

	public static readonly DependencyProperty BackgroundOpacityProperty = DependencyProperty.Register("BackgroundOpacity", typeof(double), typeof(AdditionalResourceButton), new PropertyMetadata((object)0.25));

	public static readonly DependencyProperty HoverBackgroundColorProperty = DependencyProperty.Register("HoverBackgroundColor", typeof(Brush), typeof(AdditionalResourceButton), new PropertyMetadata((object)new SolidColorBrush(Color.FromArgb(96, 0, 0, 0))));

	public static readonly DependencyProperty HoverBackgroundOpacityProperty = DependencyProperty.Register("HoverBackgroundOpacity", typeof(double), typeof(AdditionalResourceButton), new PropertyMetadata((object)0.38));

	public static readonly DependencyProperty TitleForegroundProperty = DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(AdditionalResourceButton), new PropertyMetadata((object)Brushes.White));

	public static readonly DependencyProperty DescriptionForegroundProperty = DependencyProperty.Register("DescriptionForeground", typeof(Brush), typeof(AdditionalResourceButton), new PropertyMetadata((object)new SolidColorBrush(Color.FromRgb(154, 154, 154))));

	public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(AdditionalResourceButton));

	public string Title
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TitleProperty, (object)value);
		}
	}

	public string Description
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DescriptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DescriptionProperty, (object)value);
		}
	}

	public ImageSource? Icon
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(IconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconProperty, (object)value);
		}
	}

	public Brush IconColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(IconColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconColorProperty, (object)value);
		}
	}

	public ImageSource? AdditionalIcon
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(AdditionalIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdditionalIconProperty, (object)value);
		}
	}

	public Brush AdditionalIconColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(AdditionalIconColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdditionalIconColorProperty, (object)value);
		}
	}

	public Brush BackgroundColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BackgroundColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundColorProperty, (object)value);
		}
	}

	public double BackgroundOpacity
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BackgroundOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundOpacityProperty, (object)value);
		}
	}

	public Brush HoverBackgroundColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(HoverBackgroundColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HoverBackgroundColorProperty, (object)value);
		}
	}

	public double HoverBackgroundOpacity
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HoverBackgroundOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HoverBackgroundOpacityProperty, (object)value);
		}
	}

	public Brush TitleForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TitleForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TitleForegroundProperty, (object)value);
		}
	}

	public Brush DescriptionForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(DescriptionForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DescriptionForegroundProperty, (object)value);
		}
	}

	public ICommand? Command
	{
		get
		{
			return ((DependencyObject)this).GetValue(CommandProperty) as ICommand;
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public AdditionalResourceButton()
	{
		InitializeComponent();
	}
}
