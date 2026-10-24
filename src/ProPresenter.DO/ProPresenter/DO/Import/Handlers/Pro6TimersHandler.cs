using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.DO.Application;
using Pro.Entity.Persistence;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Migration.RVData;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6TimersHandler : IRequestHandler
{
	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public Pro6TimersHandler(IFileCreator fileCreator, ICollectionStorage collectionStorage)
	{
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Filename;
		if (!string.IsNullOrWhiteSpace(text) && text.IsPro6DataFile())
		{
			return Path.GetFileNameWithoutExtension(text).Equals("countdownTimers");
		}
		return false;
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
			updateStatus(item, ImportStatus.Migrating);
			try
			{
				string tempFile = ImportHelper.GetTempFile(string.Empty);
				if (!XHelper.TryReadFile<RVTimerControlDocument>(item.FullName, out RVTimerControlDocument data))
				{
					continue;
				}
				List<TimerData> list = new List<TimerData>();
				if (data?.CountdownTimers != null)
				{
					foreach (RVTimer rvTimer in data.CountdownTimers)
					{
						TimerData timerData = rvTimer.TimerType?.ToTimerData();
						if (list.Any((TimerData t) => t.ID == rvTimer.FieldId))
						{
							rvTimer.FieldId = Guid.NewGuid();
						}
						if (timerData != null)
						{
							timerData.RVDeserialize(rvTimer);
							list.Add(timerData);
						}
					}
				}
				TimersDocument timersDocument = new TimersDocument
				{
					ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize()
				};
				timersDocument.Timers.Add(list.Select((TimerData t) => t.Serialize()));
				if ((bool)FileHelper.WaitForFileAccess(tempFile, enforceFileExists: false, null))
				{
					ProtoHelper.WriteFile(tempFile, timersDocument);
				}
				item.ChangeFile(tempFile);
				item.ChangeName("Timers");
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
