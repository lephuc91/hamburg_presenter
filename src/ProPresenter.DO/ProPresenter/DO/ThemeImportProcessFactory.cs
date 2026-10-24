using System.Collections.Generic;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;

namespace ProPresenter.DO;

public class ThemeImportProcessFactory : IThemeImportProcessFactory
{
	private readonly IImportProcessFactory _importProcessFactory;

	public ThemeImportProcessFactory(IImportProcessFactory importProcessFactory)
	{
		_importProcessFactory = importProcessFactory;
	}

	public IImportProcess ConstructImportProcess(IEnumerable<string> allFullFilePaths)
	{
		List<FileImportRequest> list = new List<FileImportRequest>();
		foreach (string allFullFilePath in allFullFilePaths)
		{
			list.Add(new FileImportRequest(allFullFilePath)
			{
				Source = ImportSource.MediaStore
			});
		}
		return _importProcessFactory.Create(list);
	}
}
