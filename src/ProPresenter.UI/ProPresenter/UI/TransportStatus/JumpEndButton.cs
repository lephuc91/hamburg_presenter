using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls;

namespace ProPresenter.UI.TransportStatus;

public partial class JumpEndButton : BorderlessButton, IComponentConnector
{
	public static readonly DependencyProperty JumpTimeProperty = DependencyProperty.Register("JumpTime", typeof(double), typeof(JumpEndButton));

	public double JumpTime
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(JumpTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(JumpTimeProperty, (object)value);
		}
	}

	public JumpEndButton()
	{
		InitializeComponent();
	}
}
