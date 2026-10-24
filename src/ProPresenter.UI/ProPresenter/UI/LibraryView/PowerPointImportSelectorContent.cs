using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;

namespace ProPresenter.UI.LibraryView;

public partial class PowerPointImportSelectorContent : UserControl, IComponentConnector
{
	private static readonly DependencyProperty IsPopUpOpenProperty = DependencyProperty.Register("IsPopUpOpen", typeof(bool), typeof(PowerPointImportSelectorContent), new PropertyMetadata((object)false));

	private static readonly DependencyProperty UseLegacyImportProperty = DependencyProperty.Register("UseLegacyImport", typeof(bool), typeof(PowerPointImportSelectorContent), new PropertyMetadata((object)false));

	private bool IsPopUpOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsPopUpOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsPopUpOpenProperty, (object)value);
		}
	}

	public bool UseLegacyImport
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(UseLegacyImportProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UseLegacyImportProperty, (object)value);
		}
	}

	public ICommand ShowHelpCommand => new RelayCommand(delegate
	{
		IsPopUpOpen = !IsPopUpOpen;
	});

	public bool IsCancel { get; set; }

	public PowerPointImportSelectorContent()
	{
		InitializeComponent();
	}
}
