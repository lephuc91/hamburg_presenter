using System;
using System.Threading.Tasks;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Import;

public interface IAsyncFileImporter
{
	Task<(string InputFilename, string FinalMediaFilename, FileMediaBase? CreatedMedia)> ImportMediaFileAsync(string file, string containerId, Action<FileImportRequest>? configureRequest = null);
}
