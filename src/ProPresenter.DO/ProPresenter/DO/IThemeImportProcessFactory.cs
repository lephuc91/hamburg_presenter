using System.Collections.Generic;
using ProPresenter.DO.Import;

namespace ProPresenter.DO;

public interface IThemeImportProcessFactory
{
	IImportProcess ConstructImportProcess(IEnumerable<string> fullFilePath);
}
