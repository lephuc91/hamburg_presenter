using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6TemplateHandler : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsPro6TemplateFile() ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		foreach (FileImportRequest item in requests.Cast<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			try
			{
				string tempDirectory = ImportHelper.GetTempDirectory();
				string text = Path.Combine(tempDirectory, item.Name);
				string tempAssetsFolder = Path.Combine(text, "Assets");
				Directory.CreateDirectory(text);
				string text2 = Path.Combine(text, "Theme");
				if (proCore == null || proCore.MigrateDocument(item.FullName, text2, ProMigrationType.Template) != 0)
				{
					throw new Exception("Failed to migrate Pro6 template");
				}
				text2.RelinkThemeAssets(text, tempAssetsFolder, delegate(Pro.SerializationInterop.RVProtoData.Media m)
				{
					RelativePath relativePath = new RelativePath(m.Url);
					RelativePath relativePath2 = new RelativePath(Path.Combine(tempAssetsFolder, relativePath.Filename));
					if (relativePath.IsValid && (bool)FileHelper.WaitForFileAccess(relativePath2, enforceFileExists: false, null))
					{
						File.Copy(relativePath, relativePath2, overwrite: true);
					}
				});
				string tempFile = ImportHelper.GetTempFile(".proTheme");
				ZipHelper.ZipFolder(tempDirectory, tempFile);
				item.ChangeFile(tempFile);
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
