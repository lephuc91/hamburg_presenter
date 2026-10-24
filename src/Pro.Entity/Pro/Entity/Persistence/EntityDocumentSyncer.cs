using System;
using System.CodeDom.Compiler;
using System.IO.Abstractions;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity.Factory;

namespace Pro.Entity.Persistence;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "Document" })]
public sealed class EntityDocumentSyncer<TDocument> : IEntityDocumentSyncer<TDocument>, IDisposable where TDocument : IEntityDocument
{
	private readonly Guid _fileId;

	private readonly IFileSystem _fileSystem;

	private readonly ILogger _logger;

	private readonly IEntityDocumentRegistry _documentRegistry;

	private readonly IEntityFileLockFactory _fileLockFactory;

	private readonly Func<byte[]> _serializeLegacyDocument;

	private string _containingFolder;

	private string _baseFileName;

	private readonly string _legacyExtension;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public TDocument Document { get; }

	public Guid Id => _fileId;

	public EntityDocumentSyncer(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<TDocument> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType, IDocFactory<TDocument> docFactory, IFileSystem fileSystem, ILogger logger, IEntityDocumentRegistry documentRegistry, ulong peerId, IEntityFileLockFactory fileLockFactory)
	{
		_fileSystem = fileSystem;
		_logger = logger;
		_documentRegistry = documentRegistry;
		_fileLockFactory = fileLockFactory;
		_serializeLegacyDocument = serializeLegacyDocument;
		_baseFileName = baseFileName;
		_fileId = documentId;
		_containingFolder = containingFolder;
		_legacyExtension = legacyExtension;
		Document = docFactory.CreateInstance(peerId);
		initializeSync(Document);
		string relativeFilePath = _fileSystem.Path.Combine(relativeDirectoryPath, GetCrdtFileName());
		SaveDocument(Document);
		_documentRegistry.Add(_fileId, Document, relativeFilePath, documentType, SaveDocument);
	}

	public EntityDocumentSyncer(string containingFolder, string baseFileName, string legacyExtension, Action<TDocument, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults, IDocFactory<TDocument> docFactory, IFileSystem fileSystem, ILogger logger, IEntityDocumentRegistry documentRegistry, ulong peerId, IEntityFileLockFactory fileLockFactory)
	{
		_fileSystem = fileSystem;
		_logger = logger;
		_documentRegistry = documentRegistry;
		_fileLockFactory = fileLockFactory;
		_serializeLegacyDocument = serializeLegacyDocument;
		_containingFolder = containingFolder;
		_legacyExtension = legacyExtension;
		_baseFileName = baseFileName;
		(Document, _fileId) = CreateNewDocument(containingFolder, baseFileName, loadFromFile: true, null, docFactory, peerId, out var documentFileExists);
		if (!documentFileExists)
		{
			loadDefaults();
		}
		initializeSync(Document, !documentFileExists);
		if (!documentFileExists)
		{
			WriteInitialCloudSnapshot();
		}
		_documentRegistry.Register(_fileId, Document, SaveDocument, _baseFileName);
	}

	public EntityDocumentSyncer(string containingFolder, string baseFileName, string legacyExtension, Action<TDocument> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults, IDocFactory<TDocument> docFactory, IFileSystem fileSystem, ILogger logger, IEntityDocumentRegistry documentRegistry, ulong peerId, IEntityFileLockFactory fileLockFactory)
	{
		_fileSystem = fileSystem;
		_logger = logger;
		_documentRegistry = documentRegistry;
		_fileLockFactory = fileLockFactory;
		_serializeLegacyDocument = serializeLegacyDocument;
		_containingFolder = containingFolder;
		_legacyExtension = legacyExtension;
		_baseFileName = baseFileName;
		string legacyFilePath = GetLegacyFilePath();
		Guid? fileId = null;
		bool flag = false;
		if (_fileSystem.File.Exists(legacyFilePath))
		{
			try
			{
				byte[] arg = _fileSystem.File.ReadAllBytes(legacyFilePath);
				fileId = deserializeLegacyDocument(arg);
				flag = true;
			}
			catch (Exception ex)
			{
				_logger.Warning("[{0}]Failed to load legacy document {1}: {2}", "EntityDocumentSyncer", legacyFilePath, ex.Message);
			}
		}
		else
		{
			_logger.Info("[{0}]No legacy document found at {1}; creating a new document.", "EntityDocumentSyncer", legacyFilePath);
		}
		if (!flag)
		{
			loadDefaults();
		}
		(Document, _fileId) = CreateNewDocument(containingFolder, baseFileName, loadFromFile: false, fileId, docFactory, peerId, out var _);
		initializeSync(Document);
		WriteInitialCloudSnapshot();
		_documentRegistry.Register(_fileId, Document, SaveDocument, _baseFileName);
	}

	public void RenameFile(string newBaseFileName)
	{
		using (_fileLockFactory.EnterWrite(Id))
		{
			string legacyFilePath = GetLegacyFilePath();
			string filePath = GetFilePath();
			UpdateFileLocation(_containingFolder, newBaseFileName);
			if (_fileSystem.File.Exists(legacyFilePath))
			{
				_fileSystem.File.Move(legacyFilePath, GetLegacyFilePath(), overwrite: true);
			}
			if (_fileSystem.File.Exists(filePath))
			{
				_fileSystem.File.Move(filePath, GetFilePath(), overwrite: true);
			}
		}
	}

	public void MoveFile(string newContainingDirectory, string? newBaseFileName = null)
	{
		using (_fileLockFactory.EnterWrite(Id))
		{
			string legacyFilePath = GetLegacyFilePath();
			string filePath = GetFilePath();
			_fileSystem.Directory.CreateDirectory(newContainingDirectory);
			UpdateFileLocation(newContainingDirectory, newBaseFileName);
			if (_fileSystem.File.Exists(legacyFilePath))
			{
				_fileSystem.File.Move(legacyFilePath, GetLegacyFilePath(), overwrite: true);
			}
			if (_fileSystem.File.Exists(filePath))
			{
				_fileSystem.File.Move(filePath, GetFilePath(), overwrite: true);
			}
		}
	}

	public void FileRenamed(string newBaseFileName)
	{
		UpdateFileLocation(_containingFolder, newBaseFileName);
	}

	public void FileMoved(string newContainingDirectory, string? newBaseFileName = null)
	{
		UpdateFileLocation(newContainingDirectory, newBaseFileName);
	}

	public void Delete()
	{
		_documentRegistry.Remove(_fileId);
		Dispose();
		using (_fileLockFactory.EnterWrite(Id))
		{
			string filePath = GetFilePath();
			string legacyFilePath = GetLegacyFilePath();
			if (_fileSystem.File.Exists(filePath))
			{
				_fileSystem.File.Delete(filePath);
			}
			if (_fileSystem.File.Exists(legacyFilePath))
			{
				_fileSystem.File.Delete(legacyFilePath);
			}
		}
	}

	private void SaveDocument(ICanExportSnapshot snapshot)
	{
		using (_fileLockFactory.EnterWrite(Id))
		{
			string filePath = GetFilePath();
			string legacyFilePath = GetLegacyFilePath();
			_logger.Debug("[{0}]Saving document to {1}", "EntityDocumentSyncer", filePath);
			_fileSystem.Directory.CreateDirectory(_fileSystem.Path.GetDirectoryName(filePath));
			_fileSystem.File.WriteAllBytes(filePath, snapshot.ExportFullSnapshot());
			_fileSystem.File.WriteAllBytes(legacyFilePath, _serializeLegacyDocument());
		}
	}

	private void WriteInitialCloudSnapshot()
	{
		using (_fileLockFactory.EnterWrite(Id))
		{
			string filePath = GetFilePath();
			_fileSystem.Directory.CreateDirectory(_fileSystem.Path.GetDirectoryName(filePath));
			_fileSystem.File.WriteAllBytes(filePath, Document.ExportFullSnapshot());
		}
	}

	private (TDocument, Guid) CreateNewDocument(string directory, string baseFileName, bool loadFromFile, Guid? fileId, IDocFactory<TDocument> docFactory, ulong peerId, out bool documentFileExists)
	{
		documentFileExists = false;
		(string, Guid)? tuple = FindMatchingCloudFile(directory, baseFileName, fileId);
		if (tuple.HasValue)
		{
			documentFileExists = true;
			string filePath = _fileSystem.Path.Combine(directory, tuple.Value.Item1);
			return ((TDocument)(loadFromFile ? ((IEntityDocument)LoadFromFile(filePath, docFactory, peerId, tuple.Value.Item2)) : ((IEntityDocument)docFactory.CreateInstance(peerId))), tuple.Value.Item2);
		}
		_fileSystem.Directory.CreateDirectory(directory);
		Guid item = fileId ?? Guid.NewGuid();
		return (docFactory.CreateInstance(peerId), item);
	}

	private (string FileName, Guid FileId)? FindMatchingCloudFile(string directory, string baseFileName, Guid? fileId)
	{
		try
		{
			string[] files = _fileSystem.Directory.GetFiles(directory, baseFileName + "-*.proCloud");
			return baseFileName.FindCrdtDocument(files, fileId);
		}
		catch
		{
		}
		return null;
	}

	private TDocument LoadFromFile(string filePath, IDocFactory<TDocument> docFactory, ulong peerId, Guid fileId)
	{
		using (_fileLockFactory.EnterRead(fileId))
		{
			return docFactory.CreateInstance(_fileSystem.File.ReadAllBytes(filePath), peerId);
		}
	}

	private void UpdateFileLocation(string newContainingDirectory, string? newBaseFileName = null)
	{
		_containingFolder = newContainingDirectory;
		if (newBaseFileName != null)
		{
			_baseFileName = newBaseFileName;
		}
	}

	public void AddToDocumentRegistry(string relativeDirectoryPath, DocumentType documentType)
	{
		string relativeFilePath = _fileSystem.Path.Combine(relativeDirectoryPath, GetCrdtFileName());
		_documentRegistry.Add(_fileId, Document, relativeFilePath, documentType, SaveDocument);
	}

	private string GetCrdtFileName()
	{
		return _baseFileName.CreateCrdtFileName(_fileId);
	}

	private string GetLegacyFilePath()
	{
		return _fileSystem.Path.Combine(_containingFolder, _baseFileName + _legacyExtension);
	}

	private string GetFilePath()
	{
		return _fileSystem.Path.Combine(_containingFolder, GetCrdtFileName());
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
			Document.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_documentRegistry.Unregister(_fileId);
	}
}
