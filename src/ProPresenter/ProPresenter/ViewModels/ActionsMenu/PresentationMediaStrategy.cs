using System.Collections.ObjectModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.ViewModels.ActionsMenu;

public class PresentationMediaStrategy : IMediaStrategy
{
	private readonly IApp _app;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public IPresentation? SelectedPresentation { get; set; }

	public ObservableCollection<ArrangedCue> SelectedSlides { get; }

	public bool CanConvertMediaToSlideElement => true;

	public PresentationMediaStrategy(IApp app, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, ObservableCollection<ArrangedCue> selectedSlides)
	{
		_app = app;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		SelectedSlides = selectedSlides;
	}

	public void AddMediaAction(string mediaFile)
	{
		SelectedPresentation.ThrowWhenNull("SelectedPresentation");
		SlideCue[] cues = SelectedSlides.Select((ArrangedCue a) => a.Source).ToArray();
		_importProcessFactory.Create(new string[1] { mediaFile }.Select((string file) => new FileImportRequest(file, delegate(string _, string n, FileMediaBase? createdMedia)
		{
			FileMediaBase fileMediaBase = createdMedia ?? _mediaFactory.CreateEmptyFileMedia(n, SelectedPresentation.ContainerId, null);
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
			SelectedPresentation.AddSlideAction(cues, new MediaAction(fileMediaBase, _app, _transitionDescriptions), cloneAction: false);
		})
		{
			ContainerId = SelectedPresentation.ContainerId
		})).StartImport();
		static void loadComplete(FileMediaBase media)
		{
			media.MetadataLoadFailed -= loadComplete;
			media.MetadataLoadSuccessful -= loadComplete;
		}
	}

	public void ConvertMediaToSlideElement()
	{
		SelectedSlides.Select((ArrangedCue s) => s.Source).NonNull().ForEach(delegate(SlideCue s)
		{
			s.ConvertMediaActionToSlideElement();
		});
	}
}
