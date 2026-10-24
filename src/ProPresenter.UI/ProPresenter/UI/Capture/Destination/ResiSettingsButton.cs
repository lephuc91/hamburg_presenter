using System.Windows;
using System.Windows.Controls;

namespace ProPresenter.UI.Capture.Destination;

internal class ResiSettingsButton : Button
{
	static ResiSettingsButton()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		UIElement.IsEnabledProperty.OverrideMetadata(typeof(ResiSettingsButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, null, (CoerceValueCallback)((DependencyObject d, object v) => true)));
	}
}
