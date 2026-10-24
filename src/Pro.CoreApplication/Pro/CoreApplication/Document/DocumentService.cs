using System;
using System.Reactive.Disposables;
using System.Reactive.Disposables.Fluent;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Google.Protobuf;
using Pro.Common.Logging;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.Document.CoreInteraction;
using Pro.CoreApplication.Document.Interaction;
using Pro.SerializationInterop.RVProtoData.Service.Document;
using Pro.SerializationInterop.RVProtoData.Service.Document.Call;

namespace Pro.CoreApplication.Document;

public class DocumentService : IDocumentService, IAsyncDisposable
{
	private readonly Task<ICoreCloudDocumentService?> _startupTask;

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	private readonly Subject<DocumentPatch> _patchSubject = new Subject<DocumentPatch>();

	private readonly Subject<Guid> _documentRequestSubject = new Subject<Guid>();

	private readonly Subject<DocumentAdd> _documentAddSubject = new Subject<DocumentAdd>();

	private readonly Subject<DocumentAvailable> _documentAvailableSubject = new Subject<DocumentAvailable>();

	private readonly Subject<DocumentRelocate> _documentRelocatedSubject = new Subject<DocumentRelocate>();

	private readonly Subject<DocumentRemove> _documentRemoveSubject = new Subject<DocumentRemove>();

	public IObservable<DocumentPatch> WhenPatchReceived => _patchSubject;

	public IObservable<Guid> WhenDocumentRequested => _documentRequestSubject;

	public IObservable<DocumentAdd> WhenDocumentAdded => _documentAddSubject;

	public IObservable<DocumentAvailable> WhenDocumentAvailable => _documentAvailableSubject;

	public IObservable<DocumentRelocate> WhenDocumentRelocated => _documentRelocatedSubject;

	public IObservable<DocumentRemove> WhenDocumentRemoved => _documentRemoveSubject;

	public DocumentService(ICoreApplication coreApplication, ILogger logger)
	{
		_patchSubject.DisposeWith(_disposables);
		_documentRequestSubject.DisposeWith(_disposables);
		_documentAddSubject.DisposeWith(_disposables);
		_documentAvailableSubject.DisposeWith(_disposables);
		_documentRelocatedSubject.DisposeWith(_disposables);
		_documentRemoveSubject.DisposeWith(_disposables);
		_startupTask = StartupAsync(coreApplication, logger);
	}

	private async Task<ICoreCloudDocumentService?> StartupAsync(ICoreApplication coreApplication, ILogger logger)
	{
		ServiceResult<ICoreCloudDocumentService> serviceResult = await coreApplication.GetCoreCloudDocumentServiceAsync();
		if (!serviceResult.IsSuccess)
		{
			return null;
		}
		logger.Info("Subscribing to Cloud Document Service notifications");
		ICoreCloudDocumentSubscription coreCloudDocumentSubscription = serviceResult.Instance.Subscribe(logger);
		coreCloudDocumentSubscription.WhenDocumentRequired.Select((Notification.Types.Required d) => Guid.Parse(d.Uuid)).Subscribe(_documentRequestSubject).DisposeWith(_disposables);
		coreCloudDocumentSubscription.WhenPatchReceived.Select((Notification.Types.Patch d) => new DocumentPatch(Guid.Parse(d.Uuid), d.Blob.ToByteArray())).Subscribe(_patchSubject).DisposeWith(_disposables);
		coreCloudDocumentSubscription.WhenDocumentAdded.Select((Notification.Types.Added d) => new DocumentAdd(Guid.Parse(d.Uuid), d.Path, d.Kind.ToDomain())).Subscribe(_documentAddSubject).DisposeWith(_disposables);
		coreCloudDocumentSubscription.WhenDocumentAvailable.Select((Notification.Types.Available d) => new DocumentAvailable(Guid.Parse(d.Uuid), d.Blob.ToByteArray())).Subscribe(_documentAvailableSubject).DisposeWith(_disposables);
		coreCloudDocumentSubscription.WhenDocumentRelocated.Select((Notification.Types.Moved d) => new DocumentRelocate(Guid.Parse(d.Uuid), d.Path, d.Kind.ToDomain())).Subscribe(_documentRelocatedSubject).DisposeWith(_disposables);
		coreCloudDocumentSubscription.WhenDocumentRemoved.Select((Notification.Types.Removed d) => new DocumentRemove(Guid.Parse(d.Uuid), d.Kind.ToDomain())).Subscribe(_documentRemoveSubject).DisposeWith(_disposables);
		return serviceResult.Instance;
	}

	public async Task LoadAsync(Guid documentId, byte[] data)
	{
		ICoreCloudDocumentService obj = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
		Load request = new Load
		{
			Blob = ByteString.CopyFrom(data),
			Uuid = documentId.ToString()
		};
		Load.Types.Result result = await obj.LoadAsync(request).ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case Load.Types.Result.ResultOneofCase.Ok:
			return;
		case Load.Types.Result.ResultOneofCase.Error:
			throw new DocumentApplicationException(result.Error);
		}
		throw new DocumentApplicationException($"Unknown result type detected:{result.ResultCase}.");
	}

	public async Task PatchAsync(DocumentPatch patch)
	{
		ICoreCloudDocumentService obj = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
		Patch request = new Patch
		{
			Patch_ = ByteString.CopyFrom(patch.Data),
			Uuid = patch.DocumentId.ToString()
		};
		Patch.Types.Result result = await obj.PatchAsync(request).ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case Patch.Types.Result.ResultOneofCase.Ok:
			return;
		case Patch.Types.Result.ResultOneofCase.Error:
			throw new DocumentApplicationException(result.Error);
		}
		throw new DocumentApplicationException($"Unknown result type detected:{result.ResultCase}.");
	}

	public async Task AddAsync(Guid documentId, byte[] data, string relativeFilePath, DocumentType documentType)
	{
		if ((uint)(documentType - 2) > 1u)
		{
			ICoreCloudDocumentService obj = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
			Add request = new Add
			{
				Uuid = documentId.ToString(),
				Data = ByteString.CopyFrom(data),
				Path = relativeFilePath,
				Kind = documentType.ToProto()
			};
			Add.Types.Result result = await obj.AddAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			switch (result.ResultCase)
			{
			case Add.Types.Result.ResultOneofCase.Ok:
				return;
			case Add.Types.Result.ResultOneofCase.Error:
				throw new DocumentApplicationException(result.Error);
			}
			throw new DocumentApplicationException($"Unknown result type detected:{result.ResultCase}.");
		}
	}

	public async Task RelocateAsync(Guid documentId, DocumentType documentType, string toRelativeFilePath)
	{
		if ((uint)(documentType - 2) > 1u)
		{
			ICoreCloudDocumentService obj = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
			Relocate request = new Relocate
			{
				Uuid = documentId.ToString(),
				Path = toRelativeFilePath,
				Kind = documentType.ToProto()
			};
			Relocate.Types.Result result = await obj.RelocateAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			switch (result.ResultCase)
			{
			case Relocate.Types.Result.ResultOneofCase.Ok:
				return;
			case Relocate.Types.Result.ResultOneofCase.Error:
				throw new DocumentApplicationException(result.Error);
			}
			throw new DocumentApplicationException($"Unknown result type detected:{result.ResultCase}.");
		}
	}

	public async Task RemoveAsync(Guid documentId)
	{
		ICoreCloudDocumentService obj = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
		Remove request = new Remove
		{
			Uuid = documentId.ToString()
		};
		Remove.Types.Result result = await obj.RemoveAsync(request).ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case Remove.Types.Result.ResultOneofCase.Ok:
			return;
		case Remove.Types.Result.ResultOneofCase.Error:
			throw new DocumentApplicationException(result.Error);
		}
		throw new DocumentApplicationException($"Unknown result type detected:{result.ResultCase}.");
	}

	private async Task<ICoreCloudDocumentService> GetServiceAsync()
	{
		return (await _startupTask.ConfigureAwait(continueOnCapturedContext: false)) ?? throw new DocumentApplicationException("Cloud Document Service is not available.");
	}

	public async ValueTask DisposeAsync()
	{
		await _startupTask.ConfigureAwait(continueOnCapturedContext: false);
		_disposables.Dispose();
	}
}
