using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.CueInspector;

public partial class SavePresetContent : UserControl, IComponentConnector
{
	public static readonly DependencyProperty PresetNameProperty = DependencyProperty.Register("PresetName", typeof(string), typeof(SavePresetContent), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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

	public SavePresetContent()
	{
		InitializeComponent();
		base.Loaded += OnLoaded;
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		PresetNameTb.Focus();
	}
}
