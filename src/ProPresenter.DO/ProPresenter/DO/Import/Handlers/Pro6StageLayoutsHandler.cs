using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Entity.Persistence;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6StageLayoutsHandler : IRequestHandler
{
	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public Pro6StageLayoutsHandler(IFileCreator fileCreator, ICollectionStorage collectionStorage)
	{
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Filename;
		if (!string.IsNullOrWhiteSpace(text) && text.IsPro6DataFile())
		{
			return Path.GetFileNameWithoutExtension(text).Equals("stageDisplayLayouts");
		}
		return false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete)
	{
		foreach (FileImportRequest item in requests.Cast<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(item, ImportStatus.Migrating);
			try
			{
				string tempFile = ImportHelper.GetTempFile(string.Empty);
				if (proCore == null || proCore.MigrateDocument(item.FullName, tempFile, ProMigrationType.StageDisplay) != 0)
				{
					throw new Exception("Failed to migrate Pro6 to Pro7 document");
				}
				if ((bool)ProtoHelper.TryReadFile<Stage.Types.Document>(tempFile, out Stage.Types.Document data))
				{
					foreach (Pro.SerializationInterop.RVProtoData.Slide.Types.Element item2 in data?.Layouts.Select((Stage.Types.Layout l) => l.Slide).SelectMany((Pro.SerializationInterop.RVProtoData.Slide s) => s.Elements) ?? Enumerable.Empty<Pro.SerializationInterop.RVProtoData.Slide.Types.Element>())
					{
						Vector2<double> point = item2.Element_.Bounds.Size.ToVector() - item2.Element_.Bounds.Origin.ToVector();
						item2.Element_.Bounds.Size = point.ToProtoSize();
					}
					if ((bool)FileHelper.WaitForFileAccess(tempFile, enforceFileExists: false, null) && data != null)
					{
						ProtoHelper.WriteFile(tempFile, data);
					}
				}
				item.ChangeFile(tempFile);
				item.ChangeName("Stage");
				handlingComplete(item, RequestHandlerType.Unknown, new FileImportResult(item.FullName, CommonPaths.Configuration, _fileCreator, _collectionStorage));
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
