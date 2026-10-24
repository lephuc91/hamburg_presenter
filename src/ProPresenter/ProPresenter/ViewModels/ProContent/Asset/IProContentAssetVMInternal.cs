using System.ComponentModel;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.ViewModels.ProContent.Asset;

public interface IProContentAssetVMInternal : IProContentAssetVM, INotifyPropertyChanged, IUniformViewSource
{
	IProContentAsset Asset { get; }
}
