using System;
using System.Collections.Generic;
using System.IO;
using Pro.Common.FileSystem;
using Pro.DO.Transitions;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.ViewModels.Actions;

namespace ProPresenter.ViewModels;

public class PresentationMediaTypeActionProvider : IMediaActionProvider
{
	private readonly MediaType _mediaType;

	private readonly IPresentation? _presentation;

	private readonly bool _convertToForeground;

	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly Func<FileInfo?> _selectFile;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private readonly string _containerId;

	public PresentationMediaTypeActionProvider(MediaType mediaType, IPresentation? presentation, bool convertToForeground, IApp app, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, string containerId, Func<FileInfo?>? selectFile = null)
	{
		_mediaType = mediaType;
		_presentation = presentation;
		_convertToForeground = convertToForeground;
		_app = app;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_selectFile = selectFile ?? new Func<FileInfo>(SelectFile);
		_containerId = containerId;
	}

	private FileInfo? SelectFile()
	{
		string filter;
		switch (_mediaType)
		{
		case MediaType.Image:
		case MediaType.Video:
			filter = FileFilters.VisualFilter;
			break;
		case MediaType.Audio:
			filter = FileFilters.AudioFilter;
			break;
		default:
			throw new NotSupportedException("Unknown media type");
		}
		if (!DialogHelper.SelectFile(out string selectedFile, filter))
		{
			return null;
		}
		return new FileInfo(selectedFile);
	}

	public IEnumerable<MediaAction> GetActions()
	{
		switch (_mediaType)
		{
		case MediaType.Image:
		case MediaType.Video:
		case MediaType.Audio:
		{
			FileInfo fileInfo = _selectFile();
			if (fileInfo != null)
			{
				return MediaActionProviderFactory.Create(new global::_003C_003Ez__ReadOnlySingleElementList<FileInfo>(fileInfo), _presentation, _convertToForeground, _app, _importProcessFactory, _mediaFactory, _transitionDescriptions, _containerId).GetActions();
			}
			break;
		}
		case MediaType.LiveVideo:
			return new global::_003C_003Ez__ReadOnlySingleElementList<MediaAction>(new MediaAction(_mediaFactory.CreateLiveVideoMedia(), _app, _transitionDescriptions));
		}
		return Array.Empty<MediaAction>();
	}

	public IEnumerable<(string, IEnumerable<MediaAction>)> GetGroupedActions()
	{
		throw new NotSupportedException();
	}
}
