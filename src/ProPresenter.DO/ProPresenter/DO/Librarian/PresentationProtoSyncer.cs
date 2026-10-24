using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.ErrorReporting;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData" })]
public sealed class PresentationProtoSyncer : IPresentationDataSyncer, IDataSyncer<IPresentation>, IDisposable
{
	private string _libraryName;

	private readonly ISyncedPresentationFileData _syncedData;

	private readonly IFileSystem _fileSystem;

	private readonly ICommonPathsWrapper _commonPaths;

	private readonly IPresentationMetadataCache _metadataCache;

	private readonly IPresentationFactory _presentationFactory;

	private readonly IErrorReporter _errorReporter;

	private readonly Action<PresentationAndLoadData> _sanitizePresentationID;

	private readonly Action<IPresentationLoadData?> _onPresentationDataChanged;

	private readonly Action<DocumentCue> _onCueUpdated;

	private readonly Func<IEnumerable<IDocumentCue>> _getAllPresentations;

	private readonly Action<DocumentCue> _onAdd;

	private readonly Action<DocumentCue> _onRemove;

	private readonly Action<IPresentation, string> _onRename;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public PresentationProtoSyncer(string name, IFileSystem fileSystem, ICommonPathsWrapper commonPaths, IPresentationCapableSyncDataFactory syncDataFactory, IPresentationMetadataCache metadataCache, IPresentationFactory presentationFactory, IErrorReporter errorReporter, Action<PresentationAndLoadData> sanitizePresentationID, Action<IPresentationLoadData?> onPresentationDataChanged, Action<DocumentCue> onCueUpdated, Func<IEnumerable<IDocumentCue>> getAllPresentations, Action<DocumentCue> onAdd, Action<DocumentCue> onRemove, Action<IPresentation, string> onRename)
	{
		_fileSystem = fileSystem;
		_commonPaths = commonPaths;
		_metadataCache = metadataCache;
		_presentationFactory = presentationFactory;
		_errorReporter = errorReporter;
		_sanitizePresentationID = sanitizePresentationID;
		_onPresentationDataChanged = onPresentationDataChanged;
		_onCueUpdated = onCueUpdated;
		_getAllPresentations = getAllPresentations;
		_onAdd = onAdd;
		_onRemove = onRemove;
		_onRename = onRename;
		_libraryName = name;
		_syncedData = syncDataFactory.GetSyncedPresentationFileData(metadataCache, ".pro", _fileSystem.Path.Combine(_commonPaths.Libraries, name), SyncedFileParse, SyncedFileLoaded, SyncedFileDeleted, SyncedFileRenamed, SyncedFileUpdated);
	}

	public bool TryRenameLibrary(string newName)
	{
		string text = _fileSystem.Path.Combine(_commonPaths.Libraries, _libraryName);
		string text2 = _fileSystem.Path.Combine(_commonPaths.Libraries, newName);
		if (text == text2 || _fileSystem.Path.Exists(text2))
		{
			return false;
		}
		_syncedData.Move(text2);
		_libraryName = newName;
		return true;
	}

	private IPresentation? SyncedFileParse(string filename, IPresentationLoadData data)
	{
		try
		{
			IPresentation presentation = _presentationFactory.Create(data.PresentationType);
			presentation.Deserialize(data, filename);
			_sanitizePresentationID(new PresentationAndLoadData(presentation, data));
			return presentation;
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			Log.Warning("Failed to load [{0}]", filename);
			return null;
		}
	}

	private void SyncedFileLoaded(IPresentation model)
	{
		model.FileNameModified += Presentation_FileNameModified;
		model.DataModified += Presentation_DataModified;
		_onAdd(new DocumentCue(model, supportsArrangement: false, newID: false));
	}

	private void SyncedFileDeleted(string filename, IPresentation model)
	{
		if (_getAllPresentations().FirstOrDefault((IDocumentCue c) => c.DocumentAction?.Presentation == model) is DocumentCue obj)
		{
			model.FileNameModified -= Presentation_FileNameModified;
			model.DataModified -= Presentation_DataModified;
			_onRemove(obj);
		}
	}

	private static void SyncedFileRenamed(string oldFilename, string newFilename, IPresentation model)
	{
		model.Name = newFilename;
	}

	private void SyncedFileUpdated(string filename, IPresentationLoadData data, IPresentation model)
	{
		try
		{
			model.DataModified -= Presentation_DataModified;
			model.Deserialize(data, filename);
			_onPresentationDataChanged(data);
			if (_getAllPresentations().FirstOrDefault((IDocumentCue c) => c.DocumentAction?.Presentation == model) is DocumentCue obj)
			{
				_onCueUpdated(obj);
			}
			model.DataModified += Presentation_DataModified;
		}
		catch (Exception value)
		{
			Log.Error($"Failed to update presentation file: {model.Name} with error: {value}");
		}
	}

	private void Presentation_DataModified(IPresentation presentation)
	{
		if (_syncedData != null && _syncedData.TryGetParsedData(presentation, out IPresentationLoadData data))
		{
			data?.UpdateProtoData(presentation.Serialize());
			_syncedData.UpdateSyncedFile(data, presentation);
			_onPresentationDataChanged(data);
		}
	}

	public void Add(IPresentation model)
	{
		model.FileNameModified += Presentation_FileNameModified;
		model.DataModified += Presentation_DataModified;
		_syncedData.AddSyncedFile(model.Name, new PresentationLoadData(_metadataCache, model.Serialize()), model);
	}

	public void Remove(IPresentation model)
	{
		model.FileNameModified -= Presentation_FileNameModified;
		model.DataModified -= Presentation_DataModified;
		_syncedData.DeleteSyncedFile(model);
	}

	private void Presentation_FileNameModified(IPresentation presentation, string newName)
	{
		_syncedData?.RenameSyncedFile(presentation, newName);
		_onRename(presentation, newName);
	}

	public void UpdateFile(IPresentationLoadData? data, IPresentation model)
	{
		_syncedData.UpdateSyncedFile(data, model);
	}

	public bool TryGetData(IPresentation model, out IPresentationLoadData? data)
	{
		return _syncedData.TryGetParsedData(model, out data);
	}

	public void CommitAllInWriteQueue()
	{
		_syncedData.CommitAllInWriteQueue();
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
			_syncedData.Dispose();
		}
	}
}
