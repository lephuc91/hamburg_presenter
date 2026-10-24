using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.Capture;

public partial class CapturePresetNameDialog : UserControl, IComponentConnector
{
	public static readonly DependencyProperty PresetNameProperty = DependencyProperty.Register("PresetName", typeof(string), typeof(CapturePresetNameDialog));

	public string? PresetName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(PresetNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PresetNameProperty, (object)value);
		}
	}

	public CapturePresetNameDialog()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate
		{
			PresetTextBox.Focus();
			PresetTextBox.SelectAll();
		};
	}
}
