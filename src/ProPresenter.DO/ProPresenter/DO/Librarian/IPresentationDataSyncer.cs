using System;
using Pro.DO;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public interface IPresentationDataSyncer : IDataSyncer<IPresentation>, IDisposable
{
	void UpdateFile(IPresentationLoadData? data, IPresentation model);

	bool TryGetData(IPresentation model, out IPresentationLoadData? data);

	void CommitAllInWriteQueue();

	bool TryRenameLibrary(string newName);
}
