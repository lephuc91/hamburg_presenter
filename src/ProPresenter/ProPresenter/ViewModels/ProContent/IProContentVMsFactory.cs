using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;
using ProPresenter.DO.ProContent.Model.Group;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Collection;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent;

public interface IProContentVMsFactory
{
	IProContentGroupVM CreateGroup(IProContentGroup group, INavigationItem parent);

	IProContentAssetVM CreateAsset(IProContentAsset asset, IProContentGroupVM group);

	IProContentCollectionVM CreateCollection(IProContentCollection collection, IProContentGroupVM group);
}
