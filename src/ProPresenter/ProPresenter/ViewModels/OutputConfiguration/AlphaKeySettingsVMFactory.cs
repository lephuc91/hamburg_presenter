using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public class AlphaKeySettingsVMFactory : IAlphaKeySettingsVMFactory
{
	private readonly IHardwareAlphaConfigurationVMFactory _hardwareAlphaConfigurationFactory;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IApiService _apiService;

	public AlphaKeySettingsVMFactory(IHardwareAlphaConfigurationVMFactory hardwareAlphaConfigurationFactory, IHyperlinkService hyperlinkService, IApiService apiService)
	{
		_hardwareAlphaConfigurationFactory = hardwareAlphaConfigurationFactory;
		_hyperlinkService = hyperlinkService;
		_apiService = apiService;
	}

	public IAlphaKeySettingsVM Create(Screen screen)
	{
		return new AlphaKeySettingsVM(screen, _hardwareAlphaConfigurationFactory, _hyperlinkService, _apiService);
	}
}
