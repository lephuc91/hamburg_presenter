using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.ThirdParty;

public partial class ThirdPartyViewer : UserControl, IComponentConnector
{
	public static readonly DependencyProperty LicenseAgreementCollectionProperty = DependencyProperty.Register("Licenses", typeof(IReadOnlyList<KeyValuePair<string, string>>), typeof(ThirdPartyViewer));

	public IReadOnlyList<KeyValuePair<string, string>> Licenses
	{
		get
		{
			return (IReadOnlyList<KeyValuePair<string, string>>)((DependencyObject)this).GetValue(LicenseAgreementCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LicenseAgreementCollectionProperty, (object)value);
		}
	}

	public ThirdPartyViewer()
	{
		InitializeComponent();
	}
}
