using System.IO.Abstractions;
using Pro.Common.HTTP;
using Pro.Localization.Services;
using ProPresenter.DO.WhatsNew;
using ProPresenter.UI.ViewModels.WhatsNew;
using ProPresenter.ViewModels.WhatsNew;

namespace ProPresenter.WhatsNew;

public class FeatureFactory : IFeatureFactory
{
	private readonly ILocalization _localization;

	private readonly IFileSystem _fileSystem;

	private readonly IHyperlinkService _hyperlinkService;

	public FeatureFactory(ILocalization localization, IFileSystem fileSystem, IHyperlinkService hyperlinkService)
	{
		_localization = localization;
		_fileSystem = fileSystem;
		_hyperlinkService = hyperlinkService;
	}

	public IFeatureItemVM Create(IFeatureItem featureItem)
	{
		return new FeatureItemVM(featureItem, _localization, _fileSystem, _hyperlinkService);
	}
}
