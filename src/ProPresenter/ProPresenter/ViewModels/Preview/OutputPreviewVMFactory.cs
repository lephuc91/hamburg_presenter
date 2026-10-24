using ProPresenter.Controller;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.ViewModels.Preview;

public class OutputPreviewVMFactory : IOutputPreviewVMFactory
{
	private readonly ICoreManager _coreManager;

	public OutputPreviewVMFactory(ICoreManager coreManager)
	{
		_coreManager = coreManager;
	}

	public IOutputPreviewVM Create(RenderViewType renderViewType)
	{
		return new OutputPreviewVM(renderViewType, _coreManager);
	}
}
