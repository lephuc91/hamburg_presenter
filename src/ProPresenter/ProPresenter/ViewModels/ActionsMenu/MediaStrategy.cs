using System;
using System.Linq;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.ViewModels.ActionsMenu;

public class MediaStrategy : IMediaStrategy
{
	private readonly Action<MediaAction> _addAction;

	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	public bool CanConvertMediaToSlideElement => false;

	public MediaStrategy(IApp app, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, Action<MediaAction> addAction)
	{
		_app = app;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_addAction = addAction;
	}

	public void AddMediaAction(string mediaFile)
	{
		_importProcessFactory.Create(new string[1] { mediaFile }.Select((string file) => new FileImportRequest(file, delegate(string _, string n, FileMediaBase? createdMedia)
		{
			FileMediaBase fileMediaBase = createdMedia ?? _mediaFactory.CreateEmptyFileMedia(n, "", null);
			fileMediaBase.MetadataLoadSuccessful += loadComplete;
			fileMediaBase.MetadataLoadFailed += loadComplete;
			if (fileMediaBase.MetadataLoaded)
			{
				fileMediaBase.MetadataLoadSuccessful -= loadComplete;
				fileMediaBase.MetadataLoadFailed -= loadComplete;
				loadComplete(fileMediaBase);
			}
			if (createdMedia == null)
			{
				fileMediaBase.UpdateSource(userInitiated: true, (RelativePath)n);
			}
			_addAction(new MediaAction(fileMediaBase, _app, _transitionDescriptions));
		}))).StartImport();
		static void loadComplete(FileMediaBase media)
		{
			media.MetadataLoadFailed -= loadComplete;
			media.MetadataLoadSuccessful -= loadComplete;
		}
	}

	public void ConvertMediaToSlideElement()
	{
	}
}
