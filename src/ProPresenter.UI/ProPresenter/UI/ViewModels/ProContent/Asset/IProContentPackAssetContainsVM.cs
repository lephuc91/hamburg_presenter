using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.ProContent.Asset;

public interface IProContentPackAssetContainsVM : INotifyPropertyChanged
{
	string Description { get; }
}
