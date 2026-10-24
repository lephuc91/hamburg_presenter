using System.IO.Abstractions;
using System.Linq;
using System.Text;
using Pro.Common.Background;
using ProPresenter.DO.Export.Requests;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Export.Handlers;

public class PlainTextDocumentHandler : IRequestHandler
{
	private readonly IFileSystem _fileSystem;

	private readonly IFileService _fileService;

	public PlainTextDocumentHandler(IFileSystem fileSystem, IFileService fileService)
	{
		_fileSystem = fileSystem;
		_fileService = fileService;
	}

	public bool CanHandle(IExportRequest request)
	{
		DocumentExportRequest obj = request as DocumentExportRequest;
		if (obj == null)
		{
			return false;
		}
		return obj.DocumentExportOption == DocumentExportOption.PlainText;
	}

	public void Handle(IExportProcess process, IExportRequest request, UpdateStatusDelegate updateStatus, ResolveConflictDelegate resolveConflict)
	{
		if (_fileService == null)
		{
			process.CancelExport();
		}
		else if (request is DocumentExportRequest documentExportRequest)
		{
			IPresentation[] array = documentExportRequest.Documents.ToArray();
			if (array.Length != 0)
			{
				request.CurrentItemName = array[0].Name;
				updateStatus(request);
			}
			for (int i = 0; i < array.Length; i++)
			{
				IPresentation presentation = array[i];
				IPresentation next = array.ElementAtOrDefault(i + 1);
				string filePath = ((documentExportRequest.Documents.Count() == 1) ? process.Destination : _fileSystem.Path.Combine(process.Destination, presentation.Name + ".txt"));
				_fileService.WriteToTextFileAsync(filePath, CreateContents(presentation)).ContinueWith(delegate
				{
					if (next != null)
					{
						request.CurrentItemName = next.Name;
						updateStatus(request);
					}
				}).ExecuteAsync();
			}
		}
		else
		{
			process.CancelExport();
		}
	}

	private static string CreateContents(IPresentation document)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
		handler.AppendLiteral("Title: ");
		handler.AppendFormatted(string.IsNullOrWhiteSpace(document.CCLIInfo.Title) ? document.Name : document.CCLIInfo.Title);
		stringBuilder2.AppendLine(ref handler);
		stringBuilder.AppendLine();
		foreach (string item in document.Content)
		{
			stringBuilder.AppendLine(item);
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}
}
