using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.Settings.PageTemplates.Registration.Footer;

public partial class EnterActivationCode : UserControl, IComponentConnector
{
	private static readonly DependencyProperty IsHelpPopUpShownProperty = DependencyProperty.Register("IsHelpPopUpShown", typeof(bool), typeof(EnterActivationCode), new PropertyMetadata((object)false));

	public ICommand ToggleHelpPopUpCommand { get; }

	private bool IsHelpPopUpShown
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsHelpPopUpShownProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsHelpPopUpShownProperty, (object)value);
		}
	}

	public EnterActivationCode()
	{
		ToggleHelpPopUpCommand = new RelayCommand(ToggleHelpPopUp);
		InitializeComponent();
	}

	private void ToggleHelpPopUp()
	{
		IsHelpPopUpShown = !IsHelpPopUpShown;
	}
}
