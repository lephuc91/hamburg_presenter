using System;
using Pro.Serialization.DataManagement;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public interface ISyncedPresentationFileData : ISyncedFileData<IPresentationLoadData, IPresentation>, IDisposable
{
	string GenerateFullPath(string name);

	bool TryGetParsedData(IPresentation model, out IPresentationLoadData? data);

	void CommitAllInWriteQueue();

	void Move(string newPath);
}
