using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.ViewModels.ProContent.Asset;

public class ProContentPackAssetContainsVM : ObservableObject, IProContentPackAssetContainsVM, INotifyPropertyChanged
{
	public string Description { get; }

	public ProContentPackAssetContainsVM(string description)
	{
		Description = description;
	}
}
