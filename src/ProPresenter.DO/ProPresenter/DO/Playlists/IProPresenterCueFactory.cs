using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pro.DO.Application;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;

namespace ProPresenter.DO.Playlists;

public interface IProPresenterCueFactory
{
	void Deserialize(ObservableCollection<ProPresenterCue> collection, IEnumerable<PlaylistItem> items, ApplicationData? applicationData, bool removeExisting, string containerId);

	ProPresenterCue CreateHeader(string name);

	ProPresenterCue CreatePlaceholder(string name);

	ProPresenterCue CreateDocumentCue(IDocumentAction action, bool clone);

	ProPresenterCue? CreateDocumentCue(IPlaylistItem.Types.IItemType.IPresentation documentItem);

	ProPresenterCue CreateMediaCue(string file, string containerId);

	ProPresenterCue? CreateMediaCue(IAction.Types.IActionTypeData.IMedia entityMedia, string containerId);

	ProPresenterCue CreateMediaCue(MediaBase? media);

	ProPresenterCue CreateSlideCue();

	PCOCueBase CreatePCOCue(PCOItem item, string? planID, string serviceID);

	ProPresenterCue? CreateCue(IPlaylistItem entityPlaylistItem, string containerId);
}
