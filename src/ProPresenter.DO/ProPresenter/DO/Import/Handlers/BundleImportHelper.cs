using System.IO;
using Pro.Common.FileSystem;
using ProPresenter.DO.Import.Requests;

namespace ProPresenter.DO.Import.Handlers;

public static class BundleImportHelper
{
	public static FileImportRequest CreateImportRequest(FileImportRequest request, string fileName)
	{
		return new FileImportRequest(fileName)
		{
			TargetFolder = ((fileName.IsMediaFile() || fileName.IsPDFFile()) ? CommonPaths.MediaAssets : null),
			IsPlaylist = (Path.GetFileName(fileName) == "data"),
			ForceManageMedia = true,
			CompleteCallback = ((request.FullName.IsDocumentBundleFile() && fileName.IsMediaFile()) ? null : request.CompleteCallback),
			PlaylistImportData = request.PlaylistImportData,
			ParentRequest = request,
			OverWriteOnConflict = request.OverWriteOnConflict
		};
	}
}
