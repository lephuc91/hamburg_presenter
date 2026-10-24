using Jab;
using ProPresenter.DO.Macros;

namespace ProPresenter.DO.Presentation.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IPresentationFactory, PresentationFactory>]
[Jab.Transient<IPropsRepo, PropsRepo>]
[Jab.Transient<IMacrosRepo, MacrosRepo>]
internal interface IPresentationServiceProviderModule
{
}
