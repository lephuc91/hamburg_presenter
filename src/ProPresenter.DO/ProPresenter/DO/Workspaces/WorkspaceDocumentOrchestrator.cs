using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Effect;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.CoreApplication.Document.Presentation;
using Pro.CoreApplication.Document.Theme;
using Pro.CoreApplication.Document.Transition;
using Pro.CoreApplication.Workspace;
using Pro.Entity;
using Pro.Entity.Persistence;
using ProPresenter.DO.CommonPathsWrapper;

namespace ProPresenter.DO.Workspaces;

public class WorkspaceDocumentOrchestrator : IWorkspaceDocumentOrchestrator
{
	private sealed record DocumentData(IDirectoryInfo Root, string RelativePath, Guid Id, byte[] Data);

	[CompilerGenerated]
	private sealed class _003CGetDocuments_003Ed__16 : IEnumerable<Pro.CoreApplication.Document.IDocument>, IEnumerable, IEnumerator<Pro.CoreApplication.Document.IDocument>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Pro.CoreApplication.Document.IDocument _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public WorkspaceDocumentOrchestrator _003C_003E4__this;

		private string path;

		public string _003C_003E3__path;

		private string rootPath;

		public string _003C_003E3__rootPath;

		private Func<string, Guid, byte[], Pro.CoreApplication.Document.IDocument> createReady;

		public Func<string, Guid, byte[], Pro.CoreApplication.Document.IDocument> _003C_003E3__createReady;

		private Func<string, Guid, Pro.CoreApplication.Document.IDocument> createRemote;

		public Func<string, Guid, Pro.CoreApplication.Document.IDocument> _003C_003E3__createRemote;

		private Func<string, Guid, DateTimeOffset, Pro.CoreApplication.Document.IDocument> createLocal;

		public Func<string, Guid, DateTimeOffset, Pro.CoreApplication.Document.IDocument> _003C_003E3__createLocal;

		private IEnumerator<IFileInfo> _003C_003E7__wrap1;

		Pro.CoreApplication.Document.IDocument IEnumerator<Pro.CoreApplication.Document.IDocument>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetDocuments_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || (uint)(num - 1) <= 1u)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				WorkspaceDocumentOrchestrator workspaceDocumentOrchestrator = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					IEnumerable<IFileInfo> crdtFiles = workspaceDocumentOrchestrator.GetCrdtFiles(path);
					_003C_003E7__wrap1 = crdtFiles.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				}
				case 1:
					_003C_003E1__state = -3;
					break;
				case 2:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					IFileInfo current = _003C_003E7__wrap1.Current;
					string fullName = current.FullName;
					if (!workspaceDocumentOrchestrator.TryGetCleanedFilePath(rootPath, fullName, out string cleanedPath))
					{
						workspaceDocumentOrchestrator._logger.Error("[{0}]Failed to get crdt base path from {1}", "WorkspaceDocumentOrchestrator", fullName);
						continue;
					}
					if (!fullName.TryParseFilenameAndIdFromCrdtFile(out string _, out Guid? id))
					{
						workspaceDocumentOrchestrator._logger.Error("[{0}]Failed to parse id from path {1}", "WorkspaceDocumentOrchestrator", fullName);
						continue;
					}
					if (workspaceDocumentOrchestrator._entityDocumentRegistry.TryGet(id.Value, out IEntityDocument document))
					{
						_003C_003E2__current = createReady(cleanedPath, id.Value, document.ExportFullSnapshot());
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003E2__current = ((current.Length == 0L) ? createRemote(cleanedPath, id.Value) : createLocal(cleanedPath, id.Value, new DateTimeOffset(current.LastWriteTime)));
					_003C_003E1__state = 2;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<Pro.CoreApplication.Document.IDocument> IEnumerable<Pro.CoreApplication.Document.IDocument>.GetEnumerator()
		{
			_003CGetDocuments_003Ed__16 _003CGetDocuments_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetDocuments_003Ed__ = this;
			}
			else
			{
				_003CGetDocuments_003Ed__ = new _003CGetDocuments_003Ed__16(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CGetDocuments_003Ed__.rootPath = _003C_003E3__rootPath;
			_003CGetDocuments_003Ed__.path = _003C_003E3__path;
			_003CGetDocuments_003Ed__.createReady = _003C_003E3__createReady;
			_003CGetDocuments_003Ed__.createRemote = _003C_003E3__createRemote;
			_003CGetDocuments_003Ed__.createLocal = _003C_003E3__createLocal;
			return _003CGetDocuments_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Pro.CoreApplication.Document.IDocument>)this).GetEnumerator();
		}
	}

	private readonly ICloudWorkspaceService _cloudWorkspaceService;

	private readonly IEntityDocumentRegistry _entityDocumentRegistry;

	private readonly ICommonPathsWrapper _commonPaths;

	private readonly IFileSystem _fileSystem;

	private readonly ILogger _logger;

	private readonly IEnumerable<IDocumentProvider> _documentProviders;

	public WorkspaceDocumentOrchestrator(ICloudWorkspaceService cloudWorkspaceService, IEntityDocumentRegistry entityDocumentRegistry, ICommonPathsWrapper commonPaths, IFileSystem fileSystem, ILogger logger, IEnumerable<IDocumentProvider> documentProviders)
	{
		_cloudWorkspaceService = cloudWorkspaceService;
		_entityDocumentRegistry = entityDocumentRegistry;
		_commonPaths = commonPaths;
		_fileSystem = fileSystem;
		_logger = logger;
		_documentProviders = documentProviders;
	}

	public async Task SendWorkspaceDocumentsToCoreAsync(IWorkspace workspace)
	{
		Pro.CoreApplication.Document.IDocument[] documents = _documentProviders.Select((IDocumentProvider d) => d.GetDocument()).NonNull().Concat(GetNonIntrinsics(workspace.Path))
			.ToArray();
		await _cloudWorkspaceService.OpenLocalAsync(workspace.Path, workspace.Name, workspace.MinimumRequiredAppVersion.ToString(), workspace.CloudId, documents).ConfigureAwait(continueOnCapturedContext: false);
		foreach (IReadyDocument item in documents.OfType<IReadyDocument>())
		{
			_entityDocumentRegistry.MarkDocumentAsKnownToCore(item.Id);
		}
	}

	public async Task CreateRemoteWorkspaceAsync(RemoteWorkspaceDocuments remoteWorkspaceDocuments, string path)
	{
		await CreateDocumentsAsync(_fileSystem.DirectoryInfo.New(path), remoteWorkspaceDocuments.Documents);
	}

	private async Task CreateDocumentsAsync(IDirectoryInfo workspaceDirectory, IEnumerable<Pro.CoreApplication.Document.IDocument> documents)
	{
		IDirectoryInfo configuration = workspaceDirectory.CreateSubdirectory(_commonPaths.ConfigurationPostfix);
		IDirectoryInfo playlists = workspaceDirectory.CreateSubdirectory(_commonPaths.PlaylistPostfix);
		IDirectoryInfo playlistTemplates = playlists.CreateSubdirectory(_commonPaths.TemplatesPostfix);
		IDirectoryInfo libraries = workspaceDirectory.CreateSubdirectory(_commonPaths.LibraryPostfix);
		IDirectoryInfo themes = workspaceDirectory.CreateSubdirectory(_commonPaths.ThemesPostfix);
		IDirectoryInfo directoryInfo = workspaceDirectory.CreateSubdirectory(_commonPaths.PresetsPostFix);
		IDirectoryInfo effects = directoryInfo.CreateSubdirectory(_commonPaths.EffectsPostFix);
		IDirectoryInfo transitionsFolder = directoryInfo.CreateSubdirectory(_commonPaths.TransitionPostFix);
		await Task.WhenAll(documents.Select(delegate(Pro.CoreApplication.Document.IDocument document)
		{
			if (document is CCLIDocument cCLIDocument)
			{
				return new DocumentData(configuration, "CCLI", cCLIDocument.Id, cCLIDocument.Data);
			}
			if (document is CalendarDocument calendarDocument)
			{
				return new DocumentData(configuration, "Calendar", calendarDocument.Id, calendarDocument.Data);
			}
			if (document is ClearGroupsDocument clearGroupsDocument)
			{
				return new DocumentData(configuration, "ClearGroups", clearGroupsDocument.Id, clearGroupsDocument.Data);
			}
			if (document is GroupsDocument groupsDocument)
			{
				return new DocumentData(configuration, "Groups", groupsDocument.Id, groupsDocument.Data);
			}
			if (document is KeyMappingsDocument keyMappingsDocument)
			{
				return new DocumentData(configuration, "KeyMappings", keyMappingsDocument.Id, keyMappingsDocument.Data);
			}
			if (document is LabelsDocument labelsDocument)
			{
				return new DocumentData(configuration, "Labels", labelsDocument.Id, labelsDocument.Data);
			}
			if (document is MacrosDocument macrosDocument)
			{
				return new DocumentData(configuration, "Macros", macrosDocument.Id, macrosDocument.Data);
			}
			if (document is MessagesDocument messagesDocument)
			{
				return new DocumentData(configuration, "Messages", messagesDocument.Id, messagesDocument.Data);
			}
			if (document is WorkspaceDocument workspaceDocument)
			{
				return new DocumentData(configuration, "Workspace", workspaceDocument.Id, workspaceDocument.Data);
			}
			if (document is StageDocument stageDocument)
			{
				return new DocumentData(configuration, "Stage", stageDocument.Id, stageDocument.Data);
			}
			if (document is PropsDocument propsDocument)
			{
				return new DocumentData(configuration, "Props", propsDocument.Id, propsDocument.Data);
			}
			if (document is TimersDocument timersDocument)
			{
				return new DocumentData(configuration, "Timers", timersDocument.Id, timersDocument.Data);
			}
			if (document is PlaylistLibraryDocument playlistLibraryDocument)
			{
				return new DocumentData(playlists, "Library", playlistLibraryDocument.Id, playlistLibraryDocument.Data);
			}
			if (document is PlaylistTemplatesDocument playlistTemplatesDocument)
			{
				return new DocumentData(playlistTemplates, "PlaylistTemplates", playlistTemplatesDocument.Id, playlistTemplatesDocument.Data);
			}
			if (document is PlaylistAudioDocument playlistAudioDocument)
			{
				return new DocumentData(playlists, "Audio", playlistAudioDocument.Id, playlistAudioDocument.Data);
			}
			if (document is PlaylistMediaDocument playlistMediaDocument)
			{
				return new DocumentData(playlists, "Media", playlistMediaDocument.Id, playlistMediaDocument.Data);
			}
			if (document is LibraryDataDocument libraryDataDocument)
			{
				return new DocumentData(libraries, "LibraryData", libraryDataDocument.Id, libraryDataDocument.Data);
			}
			if (document is ReadyPresentationDocument readyPresentationDocument)
			{
				return new DocumentData(libraries, readyPresentationDocument.Path, readyPresentationDocument.Id, readyPresentationDocument.Data);
			}
			if (document is RemotePresentationDocument remotePresentationDocument)
			{
				return new DocumentData(libraries, remotePresentationDocument.Path, remotePresentationDocument.Id, Array.Empty<byte>());
			}
			if (document is ReadyThemeDocument readyThemeDocument)
			{
				return new DocumentData(themes, readyThemeDocument.Path, readyThemeDocument.Id, readyThemeDocument.Data);
			}
			if (document is RemoteThemeDocument remoteThemeDocument)
			{
				return new DocumentData(themes, remoteThemeDocument.Path, remoteThemeDocument.Id, Array.Empty<byte>());
			}
			if (document is ReadyEffectDocument readyEffectDocument)
			{
				return new DocumentData(effects, readyEffectDocument.Path, readyEffectDocument.Id, readyEffectDocument.Data);
			}
			if (document is RemoteEffectDocument remoteEffectDocument)
			{
				return new DocumentData(effects, remoteEffectDocument.Path, remoteEffectDocument.Id, Array.Empty<byte>());
			}
			if (document is ReadyTransitionDocument readyTransitionDocument)
			{
				return new DocumentData(transitionsFolder, readyTransitionDocument.Path, readyTransitionDocument.Id, readyTransitionDocument.Data);
			}
			return (document is RemoteTransitionDocument remoteTransitionDocument) ? new DocumentData(transitionsFolder, remoteTransitionDocument.Path, remoteTransitionDocument.Id, Array.Empty<byte>()) : null;
		}).NotNull().Select(CreateFileAsync));
	}

	private async Task CreateFileAsync(DocumentData data)
	{
		IFileInfo fileInfo = _fileSystem.FileInfo.New(_fileSystem.Path.Combine(data.Root.FullName, data.RelativePath.CreateCrdtFileName(data.Id)));
		if (!fileInfo.FullName.StartsWith(data.Root.FullName + _fileSystem.Path.DirectorySeparatorChar))
		{
			_logger.Error($"Attempted to create a file outside of the containing directory. Containing Directory: {data.Root}, Relative Path: {data.RelativePath}");
			return;
		}
		try
		{
			fileInfo.Directory?.Create();
			using FileSystemStream fileStream = fileInfo.Create();
			using MemoryStream dataStream = new MemoryStream(data.Data);
			await dataStream.CopyToAsync(fileStream);
			_logger.Info("File successfully created at: " + fileInfo.FullName);
		}
		catch (IOException value)
		{
			_logger.Error($"An IO error occurred: {value}");
		}
		catch (UnauthorizedAccessException value2)
		{
			_logger.Error($"A permission error occurred: {value2}");
		}
		catch (Exception value3)
		{
			_logger.Error($"An unexpected error occurred: {value3}");
		}
	}

	private IEnumerable<Pro.CoreApplication.Document.IDocument> GetNonIntrinsics(string path)
	{
		return GetPresentationDocuments(path).Concat(GetThemeDocuments(path)).Concat(GetTransitionDocuments(path)).Concat(GetEffectDocument(path));
	}

	private IEnumerable<Pro.CoreApplication.Document.IDocument> GetPresentationDocuments(string path)
	{
		string libraryFolder = _fileSystem.Path.Combine(path, _commonPaths.LibraryPostfix);
		if (!_fileSystem.Directory.Exists(libraryFolder))
		{
			return Array.Empty<Pro.CoreApplication.Document.IDocument>();
		}
		return _fileSystem.Directory.GetDirectories(libraryFolder).SelectMany((string subfolder) => GetDocuments(libraryFolder, subfolder, (string f, Guid i, byte[] d) => new ReadyPresentationDocument(f, i, d), (string f, Guid i) => new RemotePresentationDocument(f, i), (string f, Guid i, DateTimeOffset d) => new LocalPresentationDocument(f, i, d)));
	}

	private IEnumerable<Pro.CoreApplication.Document.IDocument> GetThemeDocuments(string path)
	{
		string themeFolder = _fileSystem.Path.Combine(path, _commonPaths.ThemesPostfix);
		if (!_fileSystem.Directory.Exists(themeFolder))
		{
			return Array.Empty<Pro.CoreApplication.Document.IDocument>();
		}
		return _fileSystem.Directory.GetDirectories(themeFolder).SelectMany((string subfolder) => GetDocuments(themeFolder, subfolder, (string f, Guid i, byte[] d) => new ReadyThemeDocument(f, i, d), (string f, Guid i) => new RemoteThemeDocument(f, i), (string f, Guid i, DateTimeOffset d) => new LocalThemeDocument(f, i, d)));
	}

	private IEnumerable<Pro.CoreApplication.Document.IDocument> GetTransitionDocuments(string path)
	{
		string path2 = _fileSystem.Path.Combine(path, _commonPaths.PresetsPostFix);
		string text = _fileSystem.Path.Combine(path2, _commonPaths.TransitionPostFix);
		return GetDocuments(text, text, (string f, Guid i, byte[] d) => new ReadyTransitionDocument(f, i, d), (string f, Guid i) => new RemoteTransitionDocument(f, i), (string f, Guid i, DateTimeOffset d) => new LocalTransitionDocument(f, i, d));
	}

	private IEnumerable<Pro.CoreApplication.Document.IDocument> GetEffectDocument(string path)
	{
		string path2 = _fileSystem.Path.Combine(path, _commonPaths.PresetsPostFix);
		string text = _fileSystem.Path.Combine(path2, _commonPaths.EffectsPostFix);
		return GetDocuments(text, text, (string f, Guid i, byte[] d) => new ReadyEffectDocument(f, i, d), (string f, Guid i) => new RemoteEffectDocument(f, i), (string f, Guid i, DateTimeOffset d) => new LocalEffectDocument(f, i, d));
	}

	[IteratorStateMachine(typeof(_003CGetDocuments_003Ed__16))]
	private IEnumerable<Pro.CoreApplication.Document.IDocument> GetDocuments(string rootPath, string path, Func<string, Guid, byte[], Pro.CoreApplication.Document.IDocument> createReady, Func<string, Guid, Pro.CoreApplication.Document.IDocument> createRemote, Func<string, Guid, DateTimeOffset, Pro.CoreApplication.Document.IDocument> createLocal)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetDocuments_003Ed__16(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__rootPath = rootPath,
			_003C_003E3__path = path,
			_003C_003E3__createReady = createReady,
			_003C_003E3__createRemote = createRemote,
			_003C_003E3__createLocal = createLocal
		};
	}

	private IEnumerable<IFileInfo> GetCrdtFiles(string path, SearchOption option = SearchOption.TopDirectoryOnly)
	{
		try
		{
			if (!_fileSystem.Directory.Exists(path))
			{
				return Array.Empty<IFileInfo>();
			}
			return _fileSystem.DirectoryInfo.New(path).EnumerateFiles("*-*.proCloud", option).ToArray();
		}
		catch (Exception ex)
		{
			_logger.Error("[{0}]Failed to get documents from path {1}\n{2}", "WorkspaceDocumentOrchestrator", path, ex);
			return Array.Empty<IFileInfo>();
		}
	}

	private bool TryGetCleanedFilePath(string rootPath, string file, [NotNullWhen(true)] out string? cleanedPath)
	{
		return _fileSystem.Path.GetRelativePath(rootPath, file).TryGetTrimmedCrdtFilePath(out cleanedPath);
	}
}
