using Jab;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Workspace;
using ProPresenter.Rendering.Web;
using ProPresenter.UI.Converters.DependencyInjection;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.Web;

namespace ProPresenter.UI.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Import<IConvertersServiceProviderModule>]
[Jab.Singleton<IMediaActionService, MediaActionService>]
[Jab.Singleton<WebFillBrowserFactory>]
[Jab.Singleton<ICloudWorkspaceService, CloudWorkspaceService>]
[Jab.Singleton<IDocumentService, DocumentService>]
[Jab.Transient<IWebFillBrowserFactory>(Factory = "GetWebFillBrowserFactory")]
[Jab.Transient<IActionDialogService>(Factory = "GetActionDialigService")]
[Jab.Transient<ITemplateVM>(Factory = "GetTemplateVM")]
public interface IProPresenterUiServiceProviderModule
{
	static IWebFillBrowserFactory GetWebFillBrowserFactory(WebFillBrowserFactory factory)
	{
		return factory;
	}

	static IActionDialogService GetActionDialigService(IMainLayoutVM mainLayoutVM)
	{
		return mainLayoutVM.GetActionDialogService();
	}

	static ITemplateVM GetTemplateVM(IMainLayoutVM mainLayoutVM)
	{
		return mainLayoutVM.TemplateVM;
	}
}
