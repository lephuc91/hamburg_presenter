using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class ToggleSwitch : ToggleButton, IComponentConnector
{
	public event Action<bool, bool>? IsCheckedChanged;

	static ToggleSwitch()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		ToggleButton.IsCheckedProperty.OverrideMetadata(typeof(ToggleSwitch), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ToggleSwitch)(object)d).IsCheckedChanged?.Invoke((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}));
	}

	public ToggleSwitch()
	{
		InitializeComponent();
	}
}
