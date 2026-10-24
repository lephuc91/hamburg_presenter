using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class ColorTriggerVMFactory : IColorTriggerVMFactory
{
	private readonly IApp _app;

	public ColorTriggerVMFactory(IApp app)
	{
		_app = app;
	}

	public IColorTriggerItemVM Create(IColorTrigger colorTrigger)
	{
		return new ColorTriggerItemVM(colorTrigger);
	}

	public IColorTriggersVM CreateColorTriggersVM()
	{
		return new ColorTriggersVM(this, _app);
	}
}
