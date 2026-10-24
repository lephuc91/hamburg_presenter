using Pro.DO.Transitions;
using ProPresenter.DO.Actions.PCO;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Cues.PCO;

public class PCOSongCue : PCOCueBase
{
	public override PCOItemType PCOItemType => PCOItemType.Song;

	public PCOSongCue(PCOPlanSong planSong, string? planID, string serviceID, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, LibraryCollection? libraries = null)
		: base(mediaFactory, new PCOSongAction(app, StoredPcoOptions.Settings), planSong, planID, serviceID, transitionDescriptions, libraries)
	{
	}
}
