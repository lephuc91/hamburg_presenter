using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Disposables.Fluent;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Interaction;
using Pro.Entity.Persistence;
using ProPresenter.DO.CommonPathsWrapper;

namespace ProPresenter.Data.Crdt;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_disposables" })]
public class CollectionStorage : ICollectionStorage, IDisposable
{
	private const int GuidStringLength = 36;

	private readonly IFileSystem _fileSystem;

	private readonly ICommonPathsWrapper _commonPaths;

	private readonly IUiScheduler _scheduler;

	private readonly DisposableCollection _disposables;

	private readonly ConcurrentDictionary<Guid, string> _remoteOnlyDocuments = new ConcurrentDictionary<Guid, string>();

	private readonly Subject<(Guid Id, string DocumentPath)> _remoteOnlyDocumentBecomesAvailableSubject = new Subject<(Guid, string)>();

	private readonly Subject<(Guid Id, string OldDocumentPath, string NewDocumentPath)> _documentRelocatedNotificationSubject = new Subject<(Guid, string, string)>();

	private readonly Subject<(Guid Id, string DocumentPath)> _documentRemovedNotificationSubject = new Subject<(Guid, string)>();

	private readonly Subject<string> _localLegacyFileCreatedSubject = new Subject<string>();

	private readonly IEntityFileLockFactory _fileLockFactory;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public CollectionStorage(IFileSystem fileSystem, IDocumentService documentService, ICommonPathsWrapper commonPaths, IUiScheduler scheduler, IEntityFileLockFactory fileLockFactory, IEntityDocumentRegistry entityDocumentRegistry)
	{
		CollectionStorage collectionStorage = this;
		_fileSystem = fileSystem;
		_commonPaths = commonPaths;
		_scheduler = scheduler;
		_fileLockFactory = fileLockFactory;
		global::_003C_003Ey__InlineArray8<IDisposable> buffer = default(global::_003C_003Ey__InlineArray8<IDisposable>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(ref buffer, 0) = documentService.WhenDocumentAdded.Subscribe(delegate(DocumentAdd doc)
		{
			Pro.Entity.Persistence.DocumentType type = doc.DocumentType.ToEntityDocumentType();
			string fullPath = collectionStorage.GetFullPath(type, doc.RelativeFilePath, doc.DocumentId, alreadyProCloudFormat: true);
			using (collectionStorage._fileLockFactory.EnterWrite(doc.DocumentId))
			{
				if (!collectionStorage._fileSystem.File.Exists(fullPath))
				{
					collectionStorage._fileSystem.Directory.CreateDirectory(collectionStorage._fileSystem.Path.GetDirectoryName(fullPath));
					collectionStorage._fileSystem.File.WriteAllBytes(fullPath, default(ReadOnlySpan<byte>));
					collectionStorage._remoteOnlyDocuments.TryAdd(doc.DocumentId, fullPath);
				}
			}
		});
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(ref buffer, 1) = documentService.WhenDocumentAvailable.Subscribe(delegate(DocumentAvailable doc)
		{
			using (collectionStorage._fileLockFactory.EnterWrite(doc.DocumentId))
			{
				if (collectionStorage._remoteOnlyDocuments.TryRemove(doc.DocumentId, out string value))
				{
					collectionStorage._fileSystem.File.WriteAllBytes(value, doc.Data);
					entityDocumentRegistry.MarkDocumentAsKnownToCore(doc.DocumentId);
					string text = value;
					int num = collectionStorage._fileSystem.Path.GetExtension(value).Length + 36 + 1;
					string item = text.Substring(0, text.Length - num);
					collectionStorage._remoteOnlyDocumentBecomesAvailableSubject.OnNext((doc.DocumentId, item));
				}
			}
		});
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(ref buffer, 2) = documentService.WhenDocumentRemoved.Subscribe(delegate(DocumentRemove doc)
		{
			collectionStorage.HandleDocumentRemoval(doc.DocumentId, doc.DocumentType.ToEntityDocumentType());
		});
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(ref buffer, 3) = documentService.WhenDocumentRelocated.Subscribe(delegate(DocumentRelocate doc)
		{
			collectionStorage.HandleDocumentRelocation(doc.DocumentId, doc.DocumentType.ToEntityDocumentType(), doc.NewRelativeFilePath);
		});
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(ref buffer, 4) = _remoteOnlyDocumentBecomesAvailableSubject;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(ref buffer, 5) = _documentRelocatedNotificationSubject;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(ref buffer, 6) = _documentRemovedNotificationSubject;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(ref buffer, 7) = _localLegacyFileCreatedSubject;
		_disposables = DisposableCollection.Create(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<IDisposable>, IDisposable>(in buffer, 8));
	}

	public IDisposable SubscribeForFiles(ICollectionStorage.ObservationDetails details, Action<string, bool, Guid?> onAdd, Action<Guid> onRemove, Action<Guid, string> onMove)
	{
		details.Validate();
		if (_fileSystem.Directory.Exists(details.ContainingFolder))
		{
			IDirectoryInfo directoryInfo = _fileSystem.DirectoryInfo.New(details.ContainingFolder);
			var (readOnlyList, source) = PartitionCloudFiles(directoryInfo.EnumerateFiles(details.GetCloudFileMatchPatternByFileName(), new EnumerationOptions
			{
				RecurseSubdirectories = details.AllowNesting
			}).Where(delegate(IFileInfo f)
			{
				if (f.Name.Length - f.Extension.Length > 36)
				{
					string name = f.Name;
					int num = 36 + f.Extension.Length;
					int length = f.Extension.Length;
					int length2 = name.Length;
					int num2 = length2 - num;
					Guid result;
					return Guid.TryParse(name.Substring(num2, length2 - length - num2), out result);
				}
				return false;
			}));
			foreach (var item in readOnlyList)
			{
				_remoteOnlyDocuments.TryAdd(item.Item3, item.Item1);
			}
			IEnumerable<(string, Guid?)> second = directoryInfo.EnumerateFiles(details.GetLegacyFileMatchPatternByFileName(), details.AllowNesting ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Select(delegate(IFileInfo f)
			{
				string fullName = f.FullName;
				int length3 = f.Extension.Length;
				return ((string Path, Guid? Id))(Path: fullName.Substring(0, fullName.Length - length3), Id: null);
			}).ExceptBy(readOnlyList.Select<(string, string, Guid), string>(((string FilePath, string PathWithoutExtensionAndId, Guid Id) f) => f.PathWithoutExtensionAndId), ((string Path, Guid? Id) f) => f.Path);
			foreach (var item2 in source.Select<(string, Guid), (string, Guid?)>(((string PathWithoutExtensionAndId, Guid Id) f) => ((string Path, Guid? Id))(Path: f.PathWithoutExtensionAndId, Id: f.Id)).UnionBy<(string, Guid?), string>(second, ((string Path, Guid? Id) x) => x.Path))
			{
				onAdd(_fileSystem.Path.GetRelativePath(details.ContainingFolder, item2.Item1), details.LoadInitialFilesFromLegacy, item2.Item2);
			}
		}
		CompositeDisposable compositeDisposable = new CompositeDisposable();
		_localLegacyFileCreatedSubject.Subscribe(delegate(string filePath)
		{
			string extension = _fileSystem.Path.GetExtension(filePath);
			if (string.IsNullOrEmpty(details.LegacyFileExtension) || string.Compare(extension, details.LegacyFileExtension, StringComparison.InvariantCultureIgnoreCase) == 0)
			{
				int length4 = extension.Length;
				string path = filePath.Substring(0, filePath.Length - length4);
				string relativePath = _fileSystem.Path.GetRelativePath(details.ContainingFolder, path);
				if (IsSubPath(relativePath) && MatchesFileNameFilter(relativePath, details.FileName) && MatchesNestingConstraint(relativePath, details.AllowNesting))
				{
					_scheduler.Scheduler.Schedule((Action)delegate
					{
						onAdd(relativePath, arg2: true, null);
					});
				}
			}
		}).DisposeWith(compositeDisposable);
		(from d in _remoteOnlyDocumentBecomesAvailableSubject
			select (RelativePath: _fileSystem.Path.GetRelativePath(details.ContainingFolder, d.DocumentPath), Id: d.Id) into d
			where IsSubPath(d.RelativePath) && MatchesFileNameFilter(d.RelativePath, details.FileName) && MatchesNestingConstraint(d.RelativePath, details.AllowNesting)
			select d).ObserveOn(_scheduler.Scheduler).Subscribe<(string, Guid)>(delegate((string RelativePath, Guid Id) d)
		{
			onAdd(d.RelativePath, arg2: false, d.Id);
		}).DisposeWith(compositeDisposable);
		(from d in _documentRemovedNotificationSubject
			select (Id: d.Id, RelativePath: _fileSystem.Path.GetRelativePath(details.ContainingFolder, d.DocumentPath)) into d
			where IsSubPath(d.RelativePath) && MatchesFileNameFilter(d.RelativePath, details.FileName) && MatchesNestingConstraint(d.RelativePath, details.AllowNesting)
			select d).ObserveOn(_scheduler.Scheduler).Subscribe<(Guid, string)>(delegate((Guid Id, string RelativePath) d)
		{
			onRemove(d.Id);
		}).DisposeWith(compositeDisposable);
		_documentRelocatedNotificationSubject.Select<(Guid, string, string), (Guid, string, string)>(((Guid Id, string OldDocumentPath, string NewDocumentPath) d) => (Id: d.Id, OldRelativePath: _fileSystem.Path.GetRelativePath(details.ContainingFolder, d.OldDocumentPath), NewRelativePath: _fileSystem.Path.GetRelativePath(details.ContainingFolder, d.NewDocumentPath))).ObserveOn(_scheduler.Scheduler).Subscribe<(Guid, string, string)>(delegate((Guid Id, string OldRelativePath, string NewRelativePath) d)
		{
			bool flag = IsSubPath(d.OldRelativePath) && MatchesFileNameFilter(d.OldRelativePath, details.FileName) && MatchesNestingConstraint(d.OldRelativePath, details.AllowNesting);
			bool flag2 = IsSubPath(d.NewRelativePath) && MatchesFileNameFilter(d.NewRelativePath, details.FileName) && MatchesNestingConstraint(d.NewRelativePath, details.AllowNesting);
			if (flag && flag2)
			{
				onMove(d.Id, d.NewRelativePath);
			}
			else if (flag)
			{
				onRemove(d.Id);
			}
			else if (flag2)
			{
				onAdd(d.NewRelativePath, arg2: false, d.Id);
			}
		})
			.DisposeWith(compositeDisposable);
		return compositeDisposable;
	}

	public void HandleLocalLegacyFileCreated(string filePath)
	{
		_localLegacyFileCreatedSubject.OnNext(filePath);
	}

	private static (IReadOnlyList<(string FilePath, string PathWithoutExtensionAndId, Guid Id)> remoteOnly, IReadOnlyList<(string PathWithoutExtensionAndId, Guid Id)> synced) PartitionCloudFiles(IEnumerable<IFileInfo> validCloudFiles)
	{
		List<(string, string, Guid)> list = new List<(string, string, Guid)>();
		List<(string, Guid)> list2 = new List<(string, Guid)>();
		foreach (IFileInfo validCloudFile in validCloudFiles)
		{
			string name = validCloudFile.Name;
			int num = 36 + validCloudFile.Extension.Length;
			int length = validCloudFile.Extension.Length;
			int length2 = name.Length;
			int num2 = length2 - num;
			Guid guid = Guid.Parse(name.Substring(num2, length2 - length - num2));
			string fullName = validCloudFile.FullName;
			num2 = 36 + validCloudFile.Extension.Length + 1;
			string text = fullName.Substring(0, fullName.Length - num2);
			if (validCloudFile.Length <= 0)
			{
				list.Add((validCloudFile.FullName, text, guid));
			}
			else
			{
				list2.Add((text, guid));
			}
		}
		return (remoteOnly: list, synced: list2);
	}

	private string GetRootPath(Pro.Entity.Persistence.DocumentType type)
	{
		return type switch
		{
			Pro.Entity.Persistence.DocumentType.Presentation => _commonPaths.Libraries, 
			Pro.Entity.Persistence.DocumentType.Theme => _commonPaths.Themes, 
			Pro.Entity.Persistence.DocumentType.Effect => _commonPaths.EffectsPresets, 
			Pro.Entity.Persistence.DocumentType.Transition => _commonPaths.TransitionPresets, 
			_ => throw new InvalidOperationException($"Unsupported document type {type}"), 
		};
	}

	private string GetFullPath(Pro.Entity.Persistence.DocumentType type, string relativePath, Guid id, bool alreadyProCloudFormat)
	{
		string fullPath = _fileSystem.Path.GetFullPath(GetRootPath(type));
		string text = (alreadyProCloudFormat ? _fileSystem.Path.GetFullPath(_fileSystem.Path.Combine(fullPath, relativePath)) : _fileSystem.Path.GetFullPath(_fileSystem.Path.Combine(fullPath, relativePath.CreateCrdtFileName(id))));
		if (!IsStrictSubPathOfRoot(fullPath, text))
		{
			throw new InvalidOperationException($"Resolved path '{text}' is outside root '{fullPath}'.");
		}
		return text;
	}

	private bool IsStrictSubPathOfRoot(string rootPath, string fullPath)
	{
		string relativePath = _fileSystem.Path.GetRelativePath(rootPath, fullPath);
		if (relativePath != ".")
		{
			return IsSubPath(relativePath);
		}
		return false;
	}

	private bool IsSubPath(string path)
	{
		if (_fileSystem.Path.IsPathRooted(path))
		{
			return false;
		}
		if (path == "..")
		{
			return false;
		}
		if (path.StartsWith($"..{_fileSystem.Path.DirectorySeparatorChar}") || (_fileSystem.Path.AltDirectorySeparatorChar != _fileSystem.Path.DirectorySeparatorChar && path.StartsWith($"..{_fileSystem.Path.AltDirectorySeparatorChar}")))
		{
			return false;
		}
		return true;
	}

	private bool MatchesFileNameFilter(string relativePath, string? fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			return true;
		}
		return string.Equals(_fileSystem.Path.GetFileName(relativePath), fileName, StringComparison.OrdinalIgnoreCase);
	}

	private bool MatchesNestingConstraint(string relativePath, bool allowNesting)
	{
		if (allowNesting)
		{
			return true;
		}
		if (!relativePath.Contains(_fileSystem.Path.DirectorySeparatorChar))
		{
			if (_fileSystem.Path.AltDirectorySeparatorChar != _fileSystem.Path.DirectorySeparatorChar)
			{
				return !relativePath.Contains(_fileSystem.Path.AltDirectorySeparatorChar);
			}
			return true;
		}
		return false;
	}

	private void HandleDocumentRemoval(Guid documentId, Pro.Entity.Persistence.DocumentType documentType)
	{
		using (_fileLockFactory.EnterWrite(documentId))
		{
			string rootPath = GetRootPath(documentType);
			IDirectoryInfo directoryInfo = _fileSystem.DirectoryInfo.New(rootPath);
			if (!directoryInfo.Exists)
			{
				return;
			}
			IFileInfo[] array = directoryInfo.EnumerateFiles("*".CreateCrdtFileName(documentId), SearchOption.AllDirectories).ToArray();
			string value;
			foreach (IFileInfo fileInfo in array)
			{
				value = fileInfo.FullName;
				int num = fileInfo.Extension.Length + 36 + 1;
				string text = value.Substring(0, value.Length - num);
				string directoryName = _fileSystem.Path.GetDirectoryName(text);
				string fileName = _fileSystem.Path.GetFileName(text);
				IFileInfo[] array2 = (from file in _fileSystem.DirectoryInfo.New(directoryName).EnumerateFiles(fileName + ".*", new EnumerationOptions
					{
						RecurseSubdirectories = false
					})
					where !file.Name.EndsWith(".proCloud")
					select file).ToArray();
				foreach (IFileInfo fileInfo2 in array2)
				{
					_fileSystem.File.Delete(fileInfo2.FullName);
				}
				_fileSystem.File.Delete(fileInfo.FullName);
				_documentRemovedNotificationSubject.OnNext((documentId, text));
			}
			_remoteOnlyDocuments.TryRemove(documentId, out value);
		}
	}

	private void HandleDocumentRelocation(Guid documentId, Pro.Entity.Persistence.DocumentType documentType, string newPath)
	{
		using (_fileLockFactory.EnterWrite(documentId))
		{
			string rootPath = GetRootPath(documentType);
			IDirectoryInfo directoryInfo = _fileSystem.DirectoryInfo.New(rootPath);
			if (!directoryInfo.Exists)
			{
				return;
			}
			IFileInfo[] array = directoryInfo.EnumerateFiles("*".CreateCrdtFileName(documentId), SearchOption.AllDirectories).ToArray();
			if (array.Length == 0)
			{
				return;
			}
			if (array.Length > 1)
			{
				throw new InvalidOperationException($"Multiple CRDT files found for document id '{documentId}' in '{rootPath}'. Relocation aborted to prevent data loss.");
			}
			IFileInfo fileInfo = array[0];
			string fullPath = GetFullPath(documentType, newPath, documentId, alreadyProCloudFormat: false);
			string directoryName = _fileSystem.Path.GetDirectoryName(fullPath);
			_fileSystem.Directory.CreateDirectory(directoryName);
			string fullName = fileInfo.FullName;
			int num = fileInfo.Extension.Length + 36 + 1;
			string text = fullName.Substring(0, fullName.Length - num);
			string directoryName2 = _fileSystem.Path.GetDirectoryName(text);
			string fileName = _fileSystem.Path.GetFileName(text);
			List<IFileInfo> list = (from f in _fileSystem.DirectoryInfo.New(directoryName2).EnumerateFiles(fileName + ".*", new EnumerationOptions
				{
					RecurseSubdirectories = false
				})
				where !f.Name.EndsWith(".proCloud")
				select f).ToList();
			fullName = fullPath;
			num = ".proCloud".Length + 36 + 1;
			string text2 = fullName.Substring(0, fullName.Length - num);
			string directoryName3 = _fileSystem.Path.GetDirectoryName(text2);
			string fileName2 = _fileSystem.Path.GetFileName(text2);
			_fileSystem.File.Move(fileInfo.FullName, fullPath, overwrite: false);
			foreach (IFileInfo item in list)
			{
				string extension = item.Extension;
				string destFileName = _fileSystem.Path.Combine(directoryName3, fileName2 + extension);
				try
				{
					_fileSystem.File.Move(item.FullName, destFileName, overwrite: true);
				}
				catch
				{
				}
			}
			if (!_remoteOnlyDocuments.TryUpdate(documentId, fullPath, fileInfo.FullName))
			{
				_documentRelocatedNotificationSubject.OnNext((documentId, text, text2));
			}
		}
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
			_disposables.Dispose();
		}
	}
}
