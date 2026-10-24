using Pro.Loro;

namespace Pro.Entity.Factory;

internal interface IUnionValueFactory<out T> where T : notnull
{
	string SelectionKey { get; }

	T? CreateInstance(LoroMap map);

	T CreateDefault(LoroMap map);
}
