using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Transitions.Standard;
using Pro.Entity.Persistence;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Migration;
using ProPresenter.DO.Migration.RVData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class ProPropsHandler : IRequestHandler
{
	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public ProPropsHandler(IFileCreator fileCreator, ICollectionStorage collectionStorage)
	{
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Name;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return Path.GetFileNameWithoutExtension(text).Equals("Props");
		}
		return false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, requests, updateStatus, handlingComplete);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete)
	{
		foreach (FileImportRequest item in requests.OfType<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(item, ImportStatus.Importing);
			string fullName = item.FullName;
			if ((bool)ProtoHelper.TryReadFile<PropDocument>(fullName, out PropDocument data))
			{
				Pro6Settings pro6Settings = new Pro6Settings();
				RVProPresenterVisualSettings uiSettings = pro6Settings.UISettings;
				if (uiSettings != null && uiSettings.PropTransitionData != null && !string.IsNullOrWhiteSpace(uiSettings.PropTransitionData.TransitionType))
				{
					StandardTransition standardTransition = DataVault.Transitions.StandardTransitions?.SelectMany((StandardTransition t) => t.Collection).FirstOrDefault((StandardTransition t) => t.Preset.Name.Equals(uiSettings.PropTransitionData.TransitionType));
					if (standardTransition != null)
					{
						TransitionParameters transitionParameters = standardTransition.LoadParameters();
						transitionParameters.Duration = TimeSlice.FromSeconds(uiSettings.PropTransitionData.Duration);
						if (data != null)
						{
							data.Transition = transitionParameters.Serialize();
						}
					}
				}
				if (process.FileChangedLibrary != null)
				{
					data?.Cues.Relink(process.FileChangedLibrary.GetNewName);
				}
				if ((bool)FileHelper.WaitForFileAccess(fullName, enforceFileExists: false, null))
				{
					ProtoHelper.WriteFile(fullName, data);
				}
			}
			handlingComplete(item, RequestHandlerType.Unknown, new FileImportResult(item.FullName, CommonPaths.Configuration, _fileCreator, _collectionStorage, appendExtension: false));
		}
	}
}
