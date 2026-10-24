using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.DO.Token;

namespace Pro.UI.Controls.Tokens;

public partial class TokenControl : UserControl, IComponentConnector
{
	private const string DefaultContentKey = "DefaultContent";

	public static readonly DependencyProperty ContentControlProperty = DependencyProperty.Register("ContentControl", typeof(FrameworkElement), typeof(TokenControl));

	public static readonly DependencyProperty TokenProperty = DependencyProperty.Register("Token", typeof(TokenBase), typeof(TokenControl));

	public static readonly DependencyProperty TokenForegroundProperty = DependencyProperty.Register("TokenForeground", typeof(Brush), typeof(TokenControl));

	public static readonly DependencyProperty TokenBackgroundProperty = DependencyProperty.Register("TokenBackground", typeof(Brush), typeof(TokenControl));

	public static readonly DependencyProperty TokenBorderProperty = DependencyProperty.Register("TokenBorder", typeof(Brush), typeof(TokenControl));

	public FrameworkElement ContentControl
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(ContentControlProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentControlProperty, (object)value);
		}
	}

	public TokenBase Token
	{
		get
		{
			return (TokenBase)((DependencyObject)this).GetValue(TokenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TokenProperty, (object)value);
		}
	}

	public Brush TokenForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TokenForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TokenForegroundProperty, (object)value);
		}
	}

	public Brush TokenBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TokenBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TokenBackgroundProperty, (object)value);
		}
	}

	public Brush TokenBorder
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TokenBorderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TokenBorderProperty, (object)value);
		}
	}

	public TokenControl()
	{
		InitializeComponent();
		((DependencyObject)this).SetValue(ContentControlProperty, base.Resources["DefaultContent"]);
	}
}
