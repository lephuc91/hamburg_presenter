using System;
using System.Collections.Generic;
using System.IO;

namespace ProPresenter.DO.Sync.Local;

public interface ISyncRepository<T> where T : ISyncData
{
	T? Read(T data);

	void Write(T data, Action<double> progress);

	void Modify(T data, Action<double> progress);

	void Delete(T data, Action<double> progress);

	IReadOnlyCollection<ISyncData> GetAll(FileAccess fileAccess);
}
