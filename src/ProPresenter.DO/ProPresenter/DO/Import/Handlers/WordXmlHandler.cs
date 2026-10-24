using System;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class WordXmlHandler : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsWordXMLFile() ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, requests, updateStatus, handlingComplete);
		return default(ValueTask);
	}

	private static void Handle(ImportProcess process, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete)
	{
		foreach (IImportRequest importRequest in requests)
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(importRequest, ImportStatus.Importing);
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				FileImportRequest fileImportRequest = importRequest as FileImportRequest;
				if (fileImportRequest == null && !FileHelper.WaitForFileAccess(fileImportRequest?.FullName ?? string.Empty, enforceFileExists: false, null))
				{
					continue;
				}
				Body body = WordprocessingDocument.Open(fileImportRequest?.FullName ?? string.Empty, isEditable: false).MainDocumentPart?.Document?.Body;
				if (body != null)
				{
					foreach (Paragraph item in body.Descendants<Paragraph>())
					{
						foreach (Text item2 in item.Descendants<Text>())
						{
							stringBuilder.Append(item2.Text);
						}
						stringBuilder.AppendLine();
					}
				}
				fileImportRequest?.SetPlainText(stringBuilder.ToString());
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(importRequest, RequestHandlerType.Unknown, null);
			}
		}
	}
}
