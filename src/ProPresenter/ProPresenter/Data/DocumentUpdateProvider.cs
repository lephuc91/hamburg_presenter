using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Concurrency;
using Pro.Common.ErrorReporting;
using Pro.Common.FileSystem;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Interaction;
using Pro.Entity;
using Pro.Entity.Persistence;
using ProPresenter.DO.Analytics.Events.CloudDiagnostics;
using ProPresenter.DO.CommonPathsWrapper;

namespace ProPresenter.Data;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_disposables" })]
public class DocumentUpdateProvider : IEntityDocumentRegistry, IDocumentDiagnosticsProvider, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_changeSubscription" })]
	private sealed class DocumentDescription : IDisposable
	{
		private readonly IDisposable _changeSubscription;

		private readonly Func<DocumentDescription, Task> _doSend;

		private readonly Action<ICanExportSnapshot> _saveDocument;

		private readonly Action<Guid, string, Exception> _onError;

		private readonly Subject<Unit> _stopSignal = new Subject<Unit>();

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		private bool _disposed;

		public IEntityDocument Document { get; }

		public byte[]? LastSentVersion { get; set; }

		public Guid Id { get; }

		public string DocumentName { get; set; }

		public string? Kind { get; }

		public string? FileName { get; }

		public DocumentDescription(IThreadPoolScheduler scheduler, IEntityDocument document, Guid id, string documentName, Func<DocumentDescription, Task> doSend, Action<ICanExportSnapshot> saveDocument, byte[]? lastSentVersion, Action<Guid, string, Exception> onError, string? kind = null, string? fileName = null)
		{
			Document = document;
			Id = id;
			DocumentName = documentName;
			Kind = kind;
			FileName = fileName;
			_doSend = doSend;
			_saveDocument = saveDocument;
			_onError = onError;
			_changeSubscription = (from s in document.WhenChangeHappened.TakeUntil(_stopSignal).Throttle(TimeSpan.FromMilliseconds(100L, 0L), scheduler.Scheduler)
				select Observable.FromAsync(() => DoSendAsync(s.Item1, s.Item2))).Concat().Subscribe();
			LastSentVersion = lastSentVersion;
		}

		private async Task DoSendAsync(ICanExportSnapshot snapshot, bool isLocalChange)
		{
			try
			{
				_saveDocument(snapshot);
				if (isLocalChange)
				{
					await _doSend(this);
				}
			}
			catch (Exception arg)
			{
				_onError(Id, DocumentName, arg);
			}
		}

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		private void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				_disposed = true;
				OnDispose();
				_changeSubscription.Dispose();
			}
		}

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		private void OnDispose()
		{
			_stopSignal.OnNext(Unit.Default);
			_stopSignal.OnCompleted();
		}
	}

	private readonly DisposableCollection _disposables;

	private readonly IDocumentService _documentService;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IFileSystem _fileSystem;

	private readonly IEntityFileLockFactory _fileLockFactory;

	private readonly ICommonPathsWrapper _paths;

	private readonly IDocumentFactory _documentFactory;

	private readonly ICollaborationPeerIdProvider _peerIdProvider;

	private readonly IThreadPoolScheduler _scheduler;

	private readonly ICloudDiagnosticsPublisher _cloudDiagnostics;

	private readonly IErrorReporter _errorReporter;

	private readonly ConcurrentDictionary<Guid, DocumentDescription> _documents = new ConcurrentDictionary<Guid, DocumentDescription>();

	private readonly Lock _sentDocumentLock = new Lock();

	private readonly HashSet<Guid> _documentsCoreHasLoaded = new HashSet<Guid>();

	private const int GuidStringLength = 36;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	private static string ExtractDocumentName(string fileName, string extension)
	{
		int num = 36 + extension.Length + 1;
		if (fileName.Length <= num)
		{
			return string.Empty;
		}
		int num2 = num;
		return fileName.Substring(0, fileName.Length - num2);
	}

	private string GetDocumentName(Guid id)
	{
		if (!_documents.TryGetValue(id, out DocumentDescription value))
		{
			return string.Empty;
		}
		return value.DocumentName;
	}

	public DocumentUpdateProvider(IDocumentService documentService, IAsyncExecutor asyncExecutor, IFileSystem fileSystem, IEntityFileLockFactory fileLockFactory, ICommonPathsWrapper paths, IDocumentFactory documentFactory, ICollaborationPeerIdProvider peerIdProvider, IThreadPoolScheduler scheduler, ICloudDiagnosticsPublisher cloudDiagnostics, IErrorReporter errorReporter)
	{
		_documentService = documentService;
		_asyncExecutor = asyncExecutor;
		_fileSystem = fileSystem;
		_fileLockFactory = fileLockFactory;
		_paths = paths;
		_documentFactory = documentFactory;
		_peerIdProvider = peerIdProvider;
		_scheduler = scheduler;
		_cloudDiagnostics = cloudDiagnostics;
		_errorReporter = errorReporter;
		global::_003C_003Ey__InlineArray5<IDisposable> buffer = default(global::_003C_003Ey__InlineArray5<IDisposable>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<IDisposable>, IDisposable>(ref buffer, 0) = documentService.WhenDocumentRequested.SelectMany((Guid id) => Observable.FromAsync(() => SendDocumentAsync(id))).Subscribe();
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<IDisposable>, IDisposable>(ref buffer, 1) = documentService.WhenPatchReceived.SelectMany((DocumentPatch patch) => Observable.FromAsync(() => ApplyPatchAsync(patch))).Subscribe();
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<IDisposable>, IDisposable>(ref buffer, 2) = documentService.WhenDocumentAvailable.Subscribe(delegate(DocumentAvailable doc)
		{
			_cloudDiagnostics.DocumentDownloaded(doc.DocumentId, GetDocumentName(doc.DocumentId), "Document received from core");
		});
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<IDisposable>, IDisposable>(ref buffer, 3) = documentService.WhenDocumentRelocated.Subscribe(delegate(DocumentRelocate doc)
		{
			string documentName = GetDocumentName(doc.DocumentId);
			if (_documents.TryGetValue(doc.DocumentId, out DocumentDescription value))
			{
				value.DocumentName = doc.NewRelativeFilePath;
			}
			_cloudDiagnostics.DocumentUpdated(doc.DocumentId, documentName, doc.NewRelativeFilePath, "Document relocated on client");
		});
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<IDisposable>, IDisposable>(ref buffer, 4) = documentService.WhenDocumentRemoved.Subscribe(delegate(DocumentRemove doc)
		{
			_cloudDiagnostics.DocumentDeleted(doc.DocumentId, GetDocumentName(doc.DocumentId), "Document removed on client");
		});
		_disposables = DisposableCollection.Create(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray5<IDisposable>, IDisposable>(in buffer, 5));
	}

	private async Task SendDocumentAsync(Guid guid)
	{
		if (_documents.TryGetValue(guid, out DocumentDescription documentDescription))
		{
			try
			{
				byte[] vv = documentDescription.Document.GetVersionVector();
				await _documentService.LoadAsync(documentDescription.Id, documentDescription.Document.ExportFullSnapshot());
				documentDescription.LastSentVersion = vv;
				_cloudDiagnostics.DocumentUploaded(documentDescription.Id, documentDescription.DocumentName, "Document sent to core");
				return;
			}
			catch (Exception ex)
			{
				_errorReporter.Error(ex, "[{0}] Failed to send document {1} to core", "DocumentUpdateProvider", guid);
				_cloudDiagnostics.Error(guid, documentDescription.DocumentName, "Failed to send document to core: " + ex.Message);
				return;
			}
		}
		string matchingFile = null;
		try
		{
			byte[] array = null;
			using (_fileLockFactory.EnterRead(guid))
			{
				string text = guid.FormatCrdtFileNameId();
				matchingFile = _fileSystem.Directory.EnumerateFiles(_paths.Base, "*" + text + ".proCloud").FirstOrDefault();
				if (matchingFile != null)
				{
					array = await _fileSystem.File.ReadAllBytesAsync(matchingFile);
				}
			}
			if (array == null)
			{
				return;
			}
			Pro.Entity.IDocument document = _documentFactory.CreateDocument(array, _peerIdProvider.CollaborationPeerId);
			using (_sentDocumentLock.EnterScope())
			{
				_documentsCoreHasLoaded.Add(guid);
			}
			try
			{
				await _documentService.LoadAsync(guid, document.ExportFullSnapshot());
				string extension = _fileSystem.Path.GetExtension(matchingFile);
				string documentName = ExtractDocumentName(_fileSystem.Path.GetFileName(matchingFile), extension);
				_cloudDiagnostics.DocumentUploaded(guid, documentName, "Document sent to core from file");
			}
			catch
			{
				using (_sentDocumentLock.EnterScope())
				{
					_documentsCoreHasLoaded.Remove(guid);
				}
				throw;
			}
		}
		catch (Exception ex2)
		{
			string documentName2 = string.Empty;
			if (matchingFile != null)
			{
				string extension2 = _fileSystem.Path.GetExtension(matchingFile);
				documentName2 = ExtractDocumentName(_fileSystem.Path.GetFileName(matchingFile), extension2);
			}
			_errorReporter.Error(ex2, "[{0}] Failed to send document {1} to core", "DocumentUpdateProvider", guid);
			_cloudDiagnostics.Error(guid, documentName2, "Failed to send document to core: " + ex2.Message);
		}
	}

	private async Task SendPatchAsync(DocumentDescription doc)
	{
		if (doc.LastSentVersion != null)
		{
			string fromVv = Convert.ToHexString(doc.LastSentVersion);
			await _documentService.PatchAsync(new DocumentPatch(doc.Id, doc.Document.ExportUpdateFromVersionVector(doc.LastSentVersion)));
			doc.LastSentVersion = doc.Document.GetVersionVector();
			_cloudDiagnostics.DiffPushed(doc.Id, doc.DocumentName, fromVv, "Diff sent to core");
		}
	}

	private async Task ApplyPatchAsync(DocumentPatch patch)
	{
		_ = 1;
		try
		{
			if (TryGet(patch.DocumentId, out IEntityDocument document))
			{
				document.Import(patch.Data);
			}
			_cloudDiagnostics.DiffReceived(patch.DocumentId, GetDocumentName(patch.DocumentId), "Diff received from core");
			using (_fileLockFactory.EnterWrite(patch.DocumentId))
			{
				string text = patch.DocumentId.FormatCrdtFileNameId();
				string matchingFile = _fileSystem.Directory.EnumerateFiles(_paths.Base, "*" + text + ".proCloud").FirstOrDefault();
				if (matchingFile != null)
				{
					byte[] document2 = await _fileSystem.File.ReadAllBytesAsync(matchingFile);
					Pro.Entity.IDocument document3 = _documentFactory.CreateDocument(document2, _peerIdProvider.CollaborationPeerId);
					document3.Import(patch.Data);
					await _fileSystem.File.WriteAllBytesAsync(matchingFile, document3.ExportFullSnapshot());
				}
			}
		}
		catch (Exception ex)
		{
			_errorReporter.Error(ex, "[{0}] Failed to apply diff for document {1}", "DocumentUpdateProvider", patch.DocumentId);
			_cloudDiagnostics.Error(patch.DocumentId, GetDocumentName(patch.DocumentId), "Failed to apply diff from core: " + ex.Message);
		}
	}

	public void MarkDocumentAsKnownToCore(Guid id)
	{
		if (_documents.TryGetValue(id, out DocumentDescription value))
		{
			value.LastSentVersion = value.Document.GetVersionVector();
			return;
		}
		using (_sentDocumentLock.EnterScope())
		{
			_documentsCoreHasLoaded.Add(id);
		}
	}

	public bool TryGet(Guid id, [NotNullWhen(true)] out IEntityDocument? document)
	{
		if (_documents.TryGetValue(id, out DocumentDescription value))
		{
			document = value.Document;
			return true;
		}
		document = null;
		return false;
	}

	public void Add(Guid id, IEntityDocument document, string relativeFilePath, Pro.Entity.Persistence.DocumentType documentType, Action<ICanExportSnapshot> saveDocument)
	{
		_asyncExecutor.ExecuteAsync(() => AddAsync(id, document, relativeFilePath, documentType, saveDocument));
	}

	private async Task AddAsync(Guid id, IEntityDocument document, string relativeFilePath, Pro.Entity.Persistence.DocumentType documentType, Action<ICanExportSnapshot> saveDocument)
	{
		string kind = documentType.ToString();
		relativeFilePath.TryParseFilenameAndIdFromCrdtFile(out string baseFileName, out Guid? _);
		byte[] vv = document.GetVersionVector();
		await _documentService.AddAsync(id, document.ExportFullSnapshot(), relativeFilePath, documentType.ToCoreApplicationDocumentType());
		_documents.AddOrUpdate(id, (Guid key) => new DocumentDescription(_scheduler, document, key, relativeFilePath, SendPatchAsync, saveDocument, vv, OnDocumentDescriptionError, kind, baseFileName), delegate(Guid key, DocumentDescription oldValue)
		{
			oldValue.Dispose();
			return new DocumentDescription(_scheduler, document, key, relativeFilePath, SendPatchAsync, saveDocument, vv, OnDocumentDescriptionError, kind, baseFileName);
		});
	}

	public void Remove(Guid id)
	{
		string name = GetDocumentName(id);
		_asyncExecutor.ExecuteAsync(async delegate
		{
			try
			{
				await _documentService.RemoveAsync(id);
				_cloudDiagnostics.DocumentDeleted(id, name, "Document removed by client");
				Unregister(id);
			}
			catch (Exception ex)
			{
				_errorReporter.Error(ex, "[{0}] Failed to remove document {1}", "DocumentUpdateProvider", id);
				_cloudDiagnostics.Error(id, name, "Failed to remove document: " + ex.Message);
			}
		});
	}

	public void Register(Guid id, IEntityDocument document, Action<ICanExportSnapshot> saveDocument)
	{
		Register(id, document, saveDocument, string.Empty);
	}

	public void Register(Guid id, IEntityDocument document, Action<ICanExportSnapshot> saveDocument, string documentName = "")
	{
		bool alreadySent = false;
		using (_sentDocumentLock.EnterScope())
		{
			if (_documentsCoreHasLoaded.Contains(id))
			{
				_documentsCoreHasLoaded.Remove(id);
				alreadySent = true;
			}
		}
		_documents.AddOrUpdate(id, (Guid key) => new DocumentDescription(_scheduler, document, key, documentName, SendPatchAsync, saveDocument, alreadySent ? document.GetVersionVector() : null, OnDocumentDescriptionError), delegate(Guid key, DocumentDescription oldValue)
		{
			oldValue.Dispose();
			return new DocumentDescription(_scheduler, document, key, documentName, SendPatchAsync, saveDocument, alreadySent ? document.GetVersionVector() : null, OnDocumentDescriptionError);
		});
	}

	public void Unregister(Guid id)
	{
		if (_documents.TryRemove(id, out DocumentDescription value))
		{
			value.Dispose();
		}
	}

	public IReadOnlyList<DocumentInfoEntry> GetDocumentInfoEntries()
	{
		return DocumentInfoEntriesBuilder.Build(_documents.Values.Select((DocumentDescription doc) => new DocumentInfoSource
		{
			Id = doc.Id,
			Kind = doc.Kind,
			FileName = doc.FileName,
			SentToCore = (doc.LastSentVersion != null),
			LastSentVersion = doc.LastSentVersion,
			CurrentVersionVector = doc.Document.GetVersionVector()
		}), _fileSystem, _paths);
	}

	public void Reset()
	{
		foreach (KeyValuePair<Guid, DocumentDescription> document in _documents)
		{
			if (_documents.TryRemove(document.Key, out DocumentDescription value))
			{
				value.Dispose();
			}
		}
		using (_sentDocumentLock.EnterScope())
		{
			_documentsCoreHasLoaded.Clear();
		}
	}

	private void OnDocumentDescriptionError(Guid id, string documentName, Exception e)
	{
		_errorReporter.Error(e, "[{0}] Failed to process update for document {1}", "DocumentUpdateProvider", id);
		_cloudDiagnostics.Error(id, documentName, "Failed to process update: " + e.Message);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_disposables.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		Reset();
	}
}
