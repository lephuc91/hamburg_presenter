using System;

namespace Pro.DO;

public interface IDataSyncer<in T> : IDisposable
{
	void Add(T model);

	void Remove(T model);
}
