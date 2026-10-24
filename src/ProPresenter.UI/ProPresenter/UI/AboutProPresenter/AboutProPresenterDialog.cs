using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.AboutProPresenter;

public partial class AboutProPresenterDialog : ChromedWindow, IComponentConnector
{
	private const string AgreementFolder = "agreements";

	private const string LicenseFile = "ProLicense.txt";

	public static readonly DependencyProperty AssemblyVersionDescriptionProperty = DependencyProperty.Register("AssemblyVersionDescription", typeof(string), typeof(AboutProPresenterDialog));

	public static readonly DependencyProperty LicensesProperty = DependencyProperty.Register("Licenses", typeof(IReadOnlyList<KeyValuePair<string, string>>), typeof(AboutProPresenterDialog));

	public static readonly DependencyProperty LicenseContentProperty = DependencyProperty.Register("LicenseContent", typeof(string), typeof(AboutProPresenterDialog));

	public static readonly DependencyProperty BuildYearProperty = DependencyProperty.Register("BuildYear", typeof(string), typeof(AboutProPresenterDialog));

	public string? AssemblyVersionDescription
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AssemblyVersionDescriptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AssemblyVersionDescriptionProperty, (object)value);
		}
	}

	public IReadOnlyList<KeyValuePair<string, string>> Licenses
	{
		get
		{
			return (IReadOnlyList<KeyValuePair<string, string>>)((DependencyObject)this).GetValue(LicensesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LicensesProperty, (object)value);
		}
	}

	public string? LicenseContent
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LicenseContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LicenseContentProperty, (object)value);
		}
	}

	public string? BuildYear
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(BuildYearProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BuildYearProperty, (object)value);
		}
	}

	public AboutProPresenterDialog(string proLicense, IReadOnlyList<KeyValuePair<string, string>> licenses)
	{
		InitializeComponent();
		((DependencyObject)this).SetValue(LicensesProperty, (object)licenses);
		((DependencyObject)this).SetValue(LicenseContentProperty, (object)proLicense);
	}

	private void AcknowlegementsButton_Checked(object? sender, RoutedEventArgs e)
	{
		licenseButton.IsChecked = false;
	}

	private void LicenseButton_Checked(object? sender, RoutedEventArgs e)
	{
		acknowlegementsButton.IsChecked = false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
