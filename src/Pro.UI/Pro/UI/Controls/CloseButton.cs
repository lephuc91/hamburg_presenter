using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class CloseButton : Button, IComponentConnector
{
	public CloseButton()
	{
		InitializeComponent();
	}

	static CloseButton()
	{
		FrameworkElement.WidthProperty.OverrideMetadata(typeof(CloseButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)24.0));
		FrameworkElement.HeightProperty.OverrideMetadata(typeof(CloseButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)24.0));
	}
}
