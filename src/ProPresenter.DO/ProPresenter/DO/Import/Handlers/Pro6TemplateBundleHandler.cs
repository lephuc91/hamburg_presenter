using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6TemplateBundleHandler : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsPro6TemplateBundleFile() ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		foreach (FileImportRequest item in from FileImportRequest r in requests
			where File.Exists(r.FullName)
			select r)
		{
			try
			{
				string unzipDirectory = ImportHelper.GetTempDirectory();
				item.FullName.UnzipFile(unzipDirectory);
				IEnumerable<string> assets = from f in Directory.GetFiles(unzipDirectory, "*.*", SearchOption.AllDirectories)
					where f.IsMediaFile()
					select f;
				foreach (string item2 in from f in Directory.GetFiles(unzipDirectory, "*.*", SearchOption.AllDirectories)
					where f.IsPro6TemplateFile()
					select f)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(item2);
					string tempDirectory = ImportHelper.GetTempDirectory();
					string text = Path.Combine(tempDirectory, fileNameWithoutExtension);
					string tempAssetsFolder = Path.Combine(text, "Assets");
					Directory.CreateDirectory(text);
					string text2 = Path.Combine(text, "Theme");
					if (proCore == null || proCore.MigrateDocument(item2, text2, ProMigrationType.Template) != 0)
					{
						throw new Exception("Failed to migrate Pro6 template");
					}
					text2.RelinkThemeAssets(text, tempAssetsFolder, delegate(Pro.SerializationInterop.RVProtoData.Media m)
					{
						RelativePath source = new RelativePath(m.Url);
						RelativePath relativePath = new RelativePath(Path.Combine(tempAssetsFolder, source.Filename));
						string text3 = assets.FirstOrDefault((string a) => source.FullPath?.Contains(a.Replace(unzipDirectory, string.Empty)) ?? false);
						if (File.Exists(text3) && (bool)FileHelper.WaitForFileAccess(relativePath, enforceFileExists: false, null))
						{
							File.Copy(text3, relativePath, overwrite: true);
						}
					});
					string tempFile = ImportHelper.GetTempFile(".proTheme");
					ZipHelper.ZipFolder(tempDirectory, tempFile);
					addRequest(item, new FileImportRequest(tempFile));
				}
				handlingComplete(item, RequestHandlerType.Unknown, new NOPResult());
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
