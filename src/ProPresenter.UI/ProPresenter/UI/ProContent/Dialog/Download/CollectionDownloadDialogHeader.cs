using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.UI.ProContent.Dialog.Download;

public partial class CollectionDownloadDialogHeader : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(IProContentDownloadCollectionDialogVM), typeof(CollectionDownloadDialogHeader));

	public IProContentDownloadCollectionDialogVM? Context
	{
		get
		{
			return (IProContentDownloadCollectionDialogVM)((DependencyObject)this).GetValue(ContextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextProperty, (object)value);
		}
	}

	public CollectionDownloadDialogHeader()
	{
		InitializeComponent();
	}
}
