using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Logging;
using Pro.DO.Application;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

public class ProPlaylistHandler : IRequestHandler
{
	private readonly IAdvanced _advancedSettings;

	private readonly IFileSystem _fileSystem;

	private readonly IProPresenterResourceService _resouces;

	private readonly IProtoService _protoService;

	private readonly ILogger _logger;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private readonly IProPresenterCueFactory _cueFactory;

	public ProPlaylistHandler(IAdvanced advancedSettings, IFileSystem fileSystem, IProPresenterResourceService resouces, IProtoService protoService, ILogger logger, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactoryProvider, IProPresenterCueFactory cueFactory)
	{
		_advancedSettings = advancedSettings;
		_fileSystem = fileSystem;
		_resouces = resouces;
		_protoService = protoService;
		_logger = logger;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactoryProvider;
		_cueFactory = cueFactory;
	}

	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.IsPlaylist ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		IEnumerable<FileImportRequest> enumerable = requests.OfType<FileImportRequest>();
		if (enumerable.Empty())
		{
			return;
		}
		process.SelectedPlaylist = null;
		foreach (FileImportRequest item in enumerable)
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus?.Invoke(item, ImportStatus.Importing);
			try
			{
				if ((bool)_protoService.TryReadFile<PlaylistDocument>(item.FullName, out PlaylistDocument data))
				{
					ApplicationData applicationData = ApplicationData.Deserialize(data?.ApplicationInfo);
					if (data != null)
					{
						Relink(item, process, data);
						switch (item.PlaylistImportData?.PlaylistLocation ?? PlaylistLocation.Library)
						{
						case PlaylistLocation.Library:
							HandleLibraryPlaylist(item, data, process, applicationData);
							break;
						case PlaylistLocation.MediaBin:
							HandleMediaBinPlaylist(data, process);
							break;
						case PlaylistLocation.AudioBin:
							HandleAudioBinPlaylist(data, process);
							break;
						}
					}
				}
				handlingComplete?.Invoke(item, RequestHandlerType.Unknown, new NOPResult());
			}
			catch (Exception ex)
			{
				_logger.Error("[{0}] Failed to handle playlist:{1}\n{2}", GetType().Name, item.FullName, ex);
				handlingComplete?.Invoke(item, RequestHandlerType.Unknown, new NOPResult());
			}
		}
	}

	private void Relink(FileImportRequest request, ImportProcess process, PlaylistDocument data)
	{
		if ((!request.ForceManageMedia && !_advancedSettings.ManageMediaAutomatically) || process.FileChangedLibrary == null)
		{
			return;
		}
		data.RootNode.Relink(process.FileChangedLibrary.GetNewName, delegate
		{
			object obj;
			if (string.IsNullOrWhiteSpace(request.TargetFolder))
			{
				obj = process.SelectedLibrary?.Name;
				if (obj == null)
				{
					return string.Empty;
				}
			}
			else
			{
				obj = _fileSystem.DirectoryInfo.New(request.TargetFolder).Name;
			}
			return (string)obj;
		});
	}

	private void HandleLibraryPlaylist(FileImportRequest request, PlaylistDocument data, ImportProcess process, ApplicationData? applicationData)
	{
		bool num = request.PlaylistImportData?.OverWritePlaylist ?? false;
		IPlaylist<ProPresenterCue> targetPlaylist = request.PlaylistImportData?.TargetPlaylist;
		int insertIndex = request.PlaylistImportData?.InsertIndex ?? (-1);
		UndoStack undoStack = _resouces.LibraryPlaylists?.UndoStack;
		if (num)
		{
			PlaylistDocument libraryPlaylist = new PlaylistDocument
			{
				ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize(),
				Type = PlaylistDocument.Types.Type.Presentation,
				RootNode = new Playlist()
			};
			libraryPlaylist.RootNode.Type = Playlist.Types.Type.Root;
			libraryPlaylist.RootNode.Playlists = new Playlist.Types.PlaylistArray();
			if (!string.IsNullOrWhiteSpace(request.TargetFolder))
			{
				Playlist playlist = new Playlist
				{
					Playlists = new Playlist.Types.PlaylistArray(),
					Name = _fileSystem.DirectoryInfo.New(request.TargetFolder ?? string.Empty).Name
				};
				playlist.Playlists.Playlists.AddRange(data.RootNode.Playlists.Playlists);
				libraryPlaylist.RootNode.Playlists.Playlists.Add(playlist);
			}
			else
			{
				libraryPlaylist.RootNode.Playlists.Playlists.AddRange(data.RootNode.Playlists.Playlists);
			}
			process.Dispatcher?.InvokeAsync(delegate
			{
				_resouces.LibraryPlaylists?.Deserialize(libraryPlaylist);
			});
			return;
		}
		process.Dispatcher?.InvokeAsync(delegate
		{
			List<IPlaylist<ProPresenterCue>> list = new List<IPlaylist<ProPresenterCue>>();
			foreach (Playlist playlist3 in data.RootNode.Playlists.Playlists)
			{
				IPlaylist<ProPresenterCue> playlist2 = PlaylistLibraryHelper.ConstructPlaylist(playlist3, undoStack, _resouces, _importProcessFactory, _logger, _cueFactory, _mediaFactory);
				playlist2.ProtoDeserialize(playlist3, applicationData);
				list.Add(playlist2);
			}
			if (!string.IsNullOrWhiteSpace(request.TargetFolder))
			{
				GeneralGroupPlaylist groupPlaylist = new GeneralGroupPlaylist(_resouces, _importProcessFactory, _logger, _cueFactory, _mediaFactory, undoStack)
				{
					Name = _fileSystem.DirectoryInfo.New(request.TargetFolder ?? string.Empty).Name
				};
				list.ForEach(delegate(IPlaylist<ProPresenterCue> p)
				{
					groupPlaylist.AddChild(p);
				});
				InsertPlaylist(groupPlaylist, targetPlaylist, insertIndex);
			}
			else
			{
				list.ForEach(delegate(IPlaylist<ProPresenterCue> p)
				{
					InsertPlaylist(p, targetPlaylist, insertIndex);
				});
			}
		});
	}

	private void HandleMediaBinPlaylist(PlaylistDocument data, ImportProcess process)
	{
		PlaylistDocument mediaPlaylist = new PlaylistDocument
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize(),
			Type = PlaylistDocument.Types.Type.Media,
			RootNode = new Playlist()
		};
		mediaPlaylist.RootNode.Type = Playlist.Types.Type.Root;
		mediaPlaylist.RootNode.Playlists = new Playlist.Types.PlaylistArray();
		foreach (Playlist playlist in data.RootNode.Playlists.Playlists)
		{
			mediaPlaylist.RootNode.Playlists.Playlists.Add(playlist);
		}
		mediaPlaylist.LiveVideoPlaylist = new Playlist
		{
			Uuid = Guid.NewGuid().ToUUID(),
			Name = _resouces.VisualPlaylists?.LiveVideoPlaylist.Name,
			Items = new Playlist.Types.PlaylistItems()
		};
		process.Dispatcher?.InvokeAsync(delegate
		{
			_resouces.VisualPlaylists?.Deserialize(mediaPlaylist);
		});
	}

	private void HandleAudioBinPlaylist(PlaylistDocument data, ImportProcess process)
	{
		PlaylistDocument audioPlaylist = new PlaylistDocument
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize(),
			Type = PlaylistDocument.Types.Type.Audio,
			RootNode = new Playlist()
		};
		audioPlaylist.RootNode.Type = Playlist.Types.Type.Root;
		audioPlaylist.RootNode.Playlists = new Playlist.Types.PlaylistArray();
		foreach (Playlist playlist in data.RootNode.Playlists.Playlists)
		{
			audioPlaylist.RootNode.Playlists.Playlists.Add(playlist);
		}
		process.Dispatcher?.InvokeAsync(delegate
		{
			_resouces.AudioPlaylists.Deserialize(audioPlaylist);
		});
	}

	private void InsertPlaylist(IPlaylist<ProPresenterCue> playlist, IPlaylist<ProPresenterCue>? targetPlaylist, int insertIndex)
	{
		GeneralGroupPlaylist parent = ((targetPlaylist == null) ? null : ((targetPlaylist.Type == PlaylistType.Group) ? (targetPlaylist as GeneralGroupPlaylist) : (targetPlaylist.PlaylistParent as GeneralGroupPlaylist)));
		_resouces.LibraryPlaylists?.AddPlaylist(playlist, parent, insertIndex);
	}
}
