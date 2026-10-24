using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.ArrangementView;

public partial class NewArrangementDialog : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ArrangementNameProperty = DependencyProperty.Register("ArrangementName", typeof(string), typeof(NewArrangementDialog));

	public string? ArrangementName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ArrangementNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ArrangementNameProperty, (object)value);
		}
	}

	public NewArrangementDialog()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate
		{
			ArrangementTextBox.Focus();
		};
	}
}
