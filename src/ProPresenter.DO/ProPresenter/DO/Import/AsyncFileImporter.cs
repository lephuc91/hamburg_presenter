using System;
using System.Threading.Tasks;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Import;

public class AsyncFileImporter : IAsyncFileImporter
{
	private IImportProcessFactory _processFactory;

	public AsyncFileImporter(IImportProcessFactory processFactory)
	{
		_processFactory = processFactory;
	}

	public Task<(string InputFilename, string FinalMediaFilename, FileMediaBase? CreatedMedia)> ImportMediaFileAsync(string file, string containerId, Action<FileImportRequest>? configureRequest = null)
	{
		TaskCompletionSource<(string InputFilename, string FinalMediaFilename, FileMediaBase? CreatedMedia)> completionSource = new TaskCompletionSource<(string, string, FileMediaBase)>();
		FileImportRequest fileImportRequest = new FileImportRequest(file, delegate(string input, string final, FileMediaBase? createdMedia)
		{
			completionSource.SetResult((input, final, createdMedia));
		})
		{
			ContainerId = containerId
		};
		configureRequest?.Invoke(fileImportRequest);
		_processFactory.Create(fileImportRequest).StartImport();
		return completionSource.Task;
	}
}
