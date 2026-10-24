using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Presentation;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

public class ImportOptionsHandler : IRequestHandler
{
	private readonly IMessageService _messageService;

	private readonly IPresentationFactory _presentationFactory;

	[GeneratedRegex("^(.+):$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex MediaShoutHeaderRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__MediaShoutHeaderRegex_2.Instance;
	}

	public ImportOptionsHandler(IMessageService messageService, IPresentationFactory presentationFactory)
	{
		_messageService = messageService;
		_presentationFactory = presentationFactory;
	}

	public bool CanHandle(IImportRequest request)
	{
		FileImportRequest obj = request as FileImportRequest;
		if (obj == null || !obj.HasPlainText)
		{
			return request is MemoryImportRequest;
		}
		return true;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		try
		{
			bool importRemaining = true;
			bool abort = false;
			Dictionary<DocumentOptions, IImportRequest> remainingOptions = new Dictionary<DocumentOptions, IImportRequest>();
			foreach (IImportRequest importRequest in requests)
			{
				updateStatus(importRequest, ImportStatus.Converting);
				IEnumerable<string> textComponents = GetTextComponents(importRequest);
				if (textComponents.Count() > 1)
				{
					foreach (string item in textComponents)
					{
						MemoryImportRequest memoryImportRequest = GenerateNewRequest(importRequest, item);
						addRequest(importRequest, memoryImportRequest);
						remainingOptions.Add(new DocumentOptions(memoryImportRequest.CCLIInfo, memoryImportRequest.Name, memoryImportRequest.Text, memoryImportRequest.Notes ?? string.Empty, _messageService, _presentationFactory, strictGroupMatching: true, null, memoryImportRequest.MultiTracksInfo), memoryImportRequest);
					}
					handlingComplete(importRequest, RequestHandlerType.Unknown, new NOPResult());
				}
				else
				{
					string text = textComponents.First();
					ImportHelper.GetRequestData(importRequest, text, out string name, out string notes, out CCLIData ccliData);
					importRequest.FinalName = name;
					bool flag = text.IsMediaShoutFormat();
					remainingOptions.Add(new DocumentOptions(ccliData, name, text, notes, _messageService, _presentationFactory, strictGroupMatching: false, flag ? MediaShoutHeaderRegex() : null, importRequest.MultiTracksInfo), importRequest);
				}
			}
			process.Dispatcher?.Invoke(delegate
			{
				ImportPrompt.HandleOptions(process, remainingOptions.Keys.ToArray(), doImport, out importRemaining, out abort);
			});
			if (abort)
			{
				process.CancelImport();
			}
			else if (importRemaining)
			{
				remainingOptions.Keys.ToArray().ForEach(doImport);
			}
			void doImport(DocumentOptions options)
			{
				if (options != null && remainingOptions.TryGetValue(options, out IImportRequest value))
				{
					updateStatus(value, ImportStatus.Importing);
					remainingOptions.Remove(options);
					value.UpdateNameWithCCLITitle();
					handlingComplete(value, RequestHandlerType.Presentation, new MemoryImportResult(options.WorkingPresentation));
				}
			}
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			requests.ForEach(delegate(IImportRequest r)
			{
				handlingComplete(r, RequestHandlerType.Unknown, null);
			});
		}
	}

	private static MemoryImportRequest GenerateNewRequest(IImportRequest request, string textComponent)
	{
		ImportHelper.GetRequestData(request, textComponent, out string name, out string notes, out CCLIData ccliData);
		return new MemoryImportRequest(name, textComponent, notes, ccliData, request.MultiTracksInfo);
	}

	private static IEnumerable<string> GetTextComponents(IImportRequest request)
	{
		string text = string.Empty;
		if (!(request is FileImportRequest fileImportRequest))
		{
			if (request is MemoryImportRequest memoryImportRequest)
			{
				text = memoryImportRequest.Text;
			}
		}
		else
		{
			text = fileImportRequest.PlainText;
		}
		if (!text.IsMediaShoutFormat())
		{
			return text.ToEnumerable();
		}
		return text.SplitByTitle();
	}
}
