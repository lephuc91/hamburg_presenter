using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI;

public partial class ResizeToScreenDialog : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TargetScreensProperty = DependencyProperty.Register("TargetScreens", typeof(IEnumerable<ScreenArrangementBase>), typeof(ResizeToScreenDialog));

	public static readonly DependencyProperty SelectedScreenProperty = DependencyProperty.Register("SelectedScreen", typeof(ScreenArrangementBase), typeof(ResizeToScreenDialog));

	public IEnumerable<ScreenArrangementBase> TargetScreens
	{
		get
		{
			return (IEnumerable<ScreenArrangementBase>)((DependencyObject)this).GetValue(TargetScreensProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetScreensProperty, (object)value);
		}
	}

	public ScreenArrangementBase SelectedScreen
	{
		get
		{
			return (ScreenArrangementBase)((DependencyObject)this).GetValue(SelectedScreenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedScreenProperty, (object)value);
		}
	}

	public ResizeToScreenDialog(IEnumerable<ScreenArrangementBase> targetScreens)
	{
		((DependencyObject)this).SetValue(TargetScreensProperty, (object)targetScreens);
		((DependencyObject)this).SetValue(SelectedScreenProperty, (object)targetScreens.First());
		InitializeComponent();
	}
}
