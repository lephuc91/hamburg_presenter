using Jab;

namespace ProPresenter.DO.Themes.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IThemeImportProcessFactory, ThemeImportProcessFactory>]
[Jab.Singleton<IThemeService, ThemeService>]
internal interface IThemesServiceProviderFactory
{
}
