using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.DO.Application;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Masks;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class ProMaskHandler : IRequestHandler
{
	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IMaskCollection _masks;

	public ProMaskHandler(IProPresenterDOFactoryProvider factoryProvider, IMaskCollection masks)
	{
		_factoryProvider = factoryProvider;
		_masks = masks;
	}

	public bool CanHandle(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Name;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return Path.GetFileNameWithoutExtension(text).Equals("Mask");
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
			updateStatus(item, ImportStatus.Importing);
			try
			{
				if ((bool)ProtoHelper.TryReadFile<Pro.SerializationInterop.RVProtoData.Presentation>(item.FullName, out Pro.SerializationInterop.RVProtoData.Presentation protoPresentation))
				{
					ApplicationData applicationData = ApplicationData.Deserialize(protoPresentation?.ApplicationInfo);
					if (process.FileChangedLibrary != null)
					{
						protoPresentation?.Cues.Relink(process.FileChangedLibrary.GetNewName);
					}
					process.Dispatcher?.InvokeAsync(delegate
					{
						List<SlideCue> list = new List<SlideCue>();
						if (protoPresentation?.Cues != null)
						{
							foreach (Cue cue in protoPresentation.Cues)
							{
								SlideCue slideCue = new SlideCue(_factoryProvider);
								slideCue.Deserialize(cue, applicationData, "Workspace");
								list.Add(slideCue);
							}
						}
						_masks.ReplaceMasks(list);
					});
				}
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
