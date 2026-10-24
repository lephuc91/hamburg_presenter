using Pro.Loro;

namespace Pro.Entity.Factory;

internal interface IValueFactory<out T> : IFactory<T>
{
	T CreateInstance(LoroMap map);
}
