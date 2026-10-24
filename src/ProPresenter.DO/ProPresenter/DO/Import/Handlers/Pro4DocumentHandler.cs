using System;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro4DocumentHandler : IRequestHandler
{
	private const string Pro4ToPro5XSL = "documents\\migration\\Pro4ToPro5.xsl";

	private XslCompiledTransform _transform = new XslCompiledTransform();

	private readonly bool _transformLoaded;

	public Pro4DocumentHandler()
	{
		try
		{
			_transform.Load("documents\\migration\\Pro4ToPro5.xsl");
			_transformLoaded = true;
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}

	public bool CanHandle(IImportRequest request)
	{
		if (_transformLoaded)
		{
			return (request as FileImportRequest)?.Filename.IsPro4DocumentFile() ?? false;
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
		foreach (IImportRequest importRequest in requests)
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(importRequest, ImportStatus.Migrating);
			try
			{
				FileImportRequest fileImportRequest = (FileImportRequest)importRequest;
				if (fileImportRequest.Filename.HasExtension(".pro4x"))
				{
					throw new NotImplementedException();
				}
				string tempFile = ImportHelper.GetTempFile(".pro5");
				_transform.Transform(fileImportRequest.FullName, tempFile);
				fileImportRequest.ChangeFile(tempFile);
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(importRequest, RequestHandlerType.Unknown, null);
			}
		}
	}
}
