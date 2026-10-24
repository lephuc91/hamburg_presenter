using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.ViewModels.Editor.Links;

public interface IColorTriggerVMFactory
{
	IColorTriggerItemVM Create(IColorTrigger colorTrigger);

	IColorTriggersVM CreateColorTriggersVM();
}
