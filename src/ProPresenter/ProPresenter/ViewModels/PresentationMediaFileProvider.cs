using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.FileSystem;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.ViewModels.Actions;

namespace ProPresenter.ViewModels;

public class PresentationMediaFileProvider : IMediaActionProvider
{
	private readonly bool _convertToForeground;

	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private readonly Dictionary<string, List<(string FileName, MediaAction Action)>> _actions = new Dictionary<string, List<(string, MediaAction)>>();

	private readonly IPresentationMediaThumbnailUpdater _mediaThumbnailUpdater;

	private readonly string _containerId;

	public PresentationMediaFileProvider(IEnumerable<FileInfo> files, IPresentationMediaThumbnailUpdater mediaThumbnailUpdater, bool convertToForeground, IApp app, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, string containerId)
	{
		_convertToForeground = convertToForeground;
		_app = app;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_mediaThumbnailUpdater = mediaThumbnailUpdater;
		_containerId = containerId;
		foreach (FileInfo file in files)
		{
			if (file.Attributes == FileAttributes.Directory)
			{
				foreach (string item in from f in Directory.EnumerateFiles(file.FullName, "*.*", SearchOption.AllDirectories)
					where f.IsVisualMediaFile()
					select f)
				{
					GetGroupActionList(item.GetDirectoryNameWithoutPath() ?? string.Empty).Add((item, GenerateNewAction(item)));
				}
			}
			else
			{
				GetGroupActionList(string.Empty).Add((file.FullName, GenerateNewAction(file.FullName)));
			}
		}
	}

	public IEnumerable<MediaAction> GetActions()
	{
		ImportMedia();
		return from a in GetAllActions()
			select a.Action;
	}

	public IEnumerable<(string DirectoryName, IEnumerable<MediaAction> Actions)> GetGroupedActions()
	{
		ImportMedia();
		return _actions.Select<KeyValuePair<string, List<(string, MediaAction)>>, (string, IEnumerable<MediaAction>)>((KeyValuePair<string, List<(string FileName, MediaAction Action)>> kv) => (Key: kv.Key, kv.Value.Select(((string FileName, MediaAction Action) a) => a.Action)));
	}

	private List<(string FileName, MediaAction Action)> GetGroupActionList(string folder)
	{
		if (!_actions.TryGetValue(folder, out List<(string, MediaAction)> value))
		{
			value = new List<(string, MediaAction)>();
			_actions[folder] = value;
		}
		return value;
	}

	private MediaAction GenerateNewAction(string file)
	{
		MediaAction mediaAction = new MediaAction(_mediaFactory.CreateEmptyFileMedia(file, _containerId, null), _app, _transitionDescriptions)
		{
			Name = Path.GetFileNameWithoutExtension(file)
		};
		if (_convertToForeground)
		{
			mediaAction.ToForeground();
		}
		return mediaAction;
	}

	private void ImportMedia()
	{
		IEnumerable<(string FileName, MediaAction Action)> allActions = GetAllActions();
		_importProcessFactory.Create(allActions.Select<(string, MediaAction), FileImportRequest>(delegate((string FileName, MediaAction Action) t)
		{
			FileImportRequest request = new FileImportRequest(t.FileName);
			MediaAction matchingAction = allActions.FirstOrDefault<(string, MediaAction)>(((string FileName, MediaAction Action) a) => a.FileName == request.FullName).Item2;
			request.ExistingMedia = matchingAction.FileMedia;
			request.ContainerId = _containerId;
			request.CompleteCallback = delegate(string o, string n, FileMediaBase? createdMedia)
			{
				if (request.OverWrite)
				{
					_mediaThumbnailUpdater?.UpdateThumbnail(request.FinalName + request.FileExtension);
				}
				if (createdMedia == null)
				{
					matchingAction.FileMedia?.UpdateSource(userInitiated: true, (RelativePath)n);
				}
			};
			return request;
		})).StartImport();
	}

	private IEnumerable<(string FileName, MediaAction Action)> GetAllActions()
	{
		return _actions.SelectMany<KeyValuePair<string, List<(string, MediaAction)>>, (string, MediaAction)>((KeyValuePair<string, List<(string FileName, MediaAction Action)>> kv) => kv.Value);
	}
}
