using System;
using System.Threading.Tasks;

namespace ProPresenter.DO.Cache;

public interface IUriCacheService<T> : IAsyncDisposable
{
	void Prefetch(Uri uri);

	Task<T> GetAsync(Uri uri);
}
