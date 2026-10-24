using Jab;
using ProPresenter.DO.ProContent.Downloads;

namespace ProPresenter.DO.ProContent.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IProContentDownloadProcessFactory, ProContentDownloadProcessFactory>]
[Jab.Transient<IUnObservedProContentDownloadProcessFactory, UnObservedProContentDownloadProcessFactory>]
[Jab.Transient<IProContentUserInteractionBehavior, ProContentUserInteractionBehavior>]
[Jab.Singleton<IProContentProvider, ProContentProvider>]
[Jab.Singleton<IProContentAssetProvider, ProContentAssetProvider>]
public interface IProContentServiceProvicerModule
{
	const string ProContentRegistrationAuthorizationStorageKey = "ProContentRegistrationAuthorizationStorageKey";

	const string ProContentRegistrationAuthorizationInfoProviderKey = "ProContentRegistrationAuthorizationInfoProviderKey";
}
