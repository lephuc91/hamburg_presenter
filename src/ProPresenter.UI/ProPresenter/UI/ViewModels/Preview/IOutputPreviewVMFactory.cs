using ProPresenter.Controller;

namespace ProPresenter.UI.ViewModels.Preview;

public interface IOutputPreviewVMFactory
{
	IOutputPreviewVM Create(RenderViewType renderViewType);
}
