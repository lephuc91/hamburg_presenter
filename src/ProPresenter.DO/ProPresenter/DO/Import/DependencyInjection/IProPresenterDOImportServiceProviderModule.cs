using Jab;
using Pro.Text;
using ProPresenter.DO.Import.Results;

namespace ProPresenter.DO.Import.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<IImportProcessFactory, ImportProcessFactory>]
[Jab.Transient<IAsyncFileImporter, AsyncFileImporter>]
[Jab.Transient<IPowerPointImageLoader, PowerPointImageLoader>]
[Jab.Transient<TypefaceLibrary>(Factory = "GetSharedTypefaceLibrary")]
[Jab.Transient<IFontDetector, FontDetector>]
[Jab.Transient<IMissingFontService, MissingFontService>]
[Jab.Transient<IFontDetectionSessionFactory, FontDetectionSessionFactory>]
public interface IProPresenterDOImportServiceProviderModule
{
	static TypefaceLibrary GetSharedTypefaceLibrary()
	{
		return SharedTypefaceLibrary.Library;
	}
}
