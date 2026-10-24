using System.Collections.Generic;
using Jab;
using Pro.Common.Animation;

namespace ProPresenter.DO.Cache.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<IFileSystemUriCacheServiceFactory, FileSystemUriCacheServiceFactory>]
[Jab.Singleton<IUriCacheService<NullableBitmapSource>, UrlBitmapThumbnailCacheService>]
[Jab.Singleton<IUriCacheService<IReadOnlyList<IAnimationFrame>>, UrlAnimatedImageCacheService>]
public interface ICacheServiceProviderModule
{
}
