using System.Collections.Generic;
using Pro.Loro;

namespace Pro.Entity.Factory;

internal interface IAtomicValueFactory<out T> : IFactory<T>
{
	T CreateInstance(Dictionary<string, LoroValue> map);
}
