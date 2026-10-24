using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class BlackmagicHardwareAlphaSettings : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(IBlackmagicHardwareAlphaConfigurationVM), typeof(BlackmagicHardwareAlphaSettings));

	public static readonly DependencyProperty DescriptionColumnSizeGroupNameProperty = DependencyProperty.Register("DescriptionColumnSizeGroupName", typeof(string), typeof(BlackmagicHardwareAlphaSettings));

	public static readonly DependencyProperty SettingsColumnSizeGroupNameProperty = DependencyProperty.Register("SettingsColumnSizeGroupName", typeof(string), typeof(BlackmagicHardwareAlphaSettings));

	public IBlackmagicHardwareAlphaConfigurationVM? Context
	{
		get
		{
			return (IBlackmagicHardwareAlphaConfigurationVM)((DependencyObject)this).GetValue(ContextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextProperty, (object)value);
		}
	}

	public string? DescriptionColumnSizeGroupName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DescriptionColumnSizeGroupNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DescriptionColumnSizeGroupNameProperty, (object)value);
		}
	}

	public string? SettingsColumnSizeGroupName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SettingsColumnSizeGroupNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SettingsColumnSizeGroupNameProperty, (object)value);
		}
	}

	public BlackmagicHardwareAlphaSettings()
	{
		InitializeComponent();
	}
}
