using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class EdgeBlendCurveSelector : UserControl, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty BlendModeProperty = DependencyProperty.Register("BlendMode", typeof(BlendMode), typeof(EdgeBlendCurveSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)BlendMode.Linear, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public BlendMode BlendMode
	{
		get
		{
			return (BlendMode)((DependencyObject)this).GetValue(BlendModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BlendModeProperty, (object)value);
		}
	}

	public EdgeBlendCurveSelector()
	{
		InitializeComponent();
	}

	private void ToggleButton_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is ToggleButton { DataContext: var dataContext } && dataContext is BlendMode blendMode)
		{
			((DependencyObject)this).SetCurrentValue(BlendModeProperty, (object)blendMode);
		}
	}
}
