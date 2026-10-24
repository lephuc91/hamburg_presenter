using Jab;
using Pro.DO.Triggering;

namespace ProPresenter.DO.Actions.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IPlaylistActionValidatorFactory, PlaylistActionValidatorFactory>]
[Jab.Singleton<IActionBinderFactory, ActionBinderFactory>]
internal interface IActionsServiceProviderModule
{
}
