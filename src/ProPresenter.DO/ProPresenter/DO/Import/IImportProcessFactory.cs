using System.Collections.Generic;

namespace ProPresenter.DO.Import;

public interface IImportProcessFactory
{
	IImportProcess Create(IEnumerable<string> files);

	IImportProcess Create(IImportRequest request);

	IImportProcess Create(IEnumerable<IImportRequest> requests, IFileChangedLibrary? fileChangedLibrary = null, bool allowSelectPlaylist = true);
}
