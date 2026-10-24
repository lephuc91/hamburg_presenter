using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.PropGroups;

public partial class PropCustomClearTime : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CustomTimeProperty = DependencyProperty.Register("CustomTimeProperty", typeof(double), typeof(PropCustomClearTime));

	public double CustomTime
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CustomTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomTimeProperty, (object)value);
		}
	}

	public PropCustomClearTime()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(PropCustomClearTime_IsVisibleChanged);
	}

	private void PropCustomClearTime_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		base.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(PropCustomClearTime_IsVisibleChanged);
		if (base.IsVisible)
		{
			TimeControl.Focus();
		}
	}
}
