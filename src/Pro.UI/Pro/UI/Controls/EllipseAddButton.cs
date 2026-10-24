using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class EllipseAddButton : Button, IComponentConnector
{
	public EllipseAddButton()
	{
		InitializeComponent();
	}

	static EllipseAddButton()
	{
		FrameworkElement.WidthProperty.OverrideMetadata(typeof(EllipseAddButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)24.0));
		FrameworkElement.HeightProperty.OverrideMetadata(typeof(EllipseAddButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)24.0));
	}
}
