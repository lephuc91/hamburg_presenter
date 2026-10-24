using ProPresenter.DO.Props;

namespace ProPresenter.UI.ViewModels.Props;

public interface IPropGroupCollectionFactoryVM
{
	IPropGroupVM CreatePropGroupVM(IPropGroup propGroup, IPropGroupCollectionVM propGroupCollectionVM);

	IPropCueVM CreatePropCueVM(IPropCue propCue, IPropGroupVM parentGroupVM);
}
