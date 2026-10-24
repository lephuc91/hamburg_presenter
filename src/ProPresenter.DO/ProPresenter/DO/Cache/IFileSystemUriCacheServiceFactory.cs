using System;

namespace ProPresenter.DO.Cache;

public interface IFileSystemUriCacheServiceFactory
{
	IUriCacheService<byte[]> Create(int maximumParalellDownloads, TimeSpan cacheEvictionTimeout, string cacheFolder);
}
