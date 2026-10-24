using System.Threading.Tasks;

namespace Pro.Common.Cache;

public interface IAsyncValue<T>
{
	Task<T> LoadAsync();
}
