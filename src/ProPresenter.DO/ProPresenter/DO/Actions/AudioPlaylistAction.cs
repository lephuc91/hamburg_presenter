using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Localization;

namespace ProPresenter.DO.Actions;

public class AudioPlaylistAction : PlaylistAction
{
	public override ActionType ActionType => ActionType.AudioPlaylist;

	protected override string DefaultName => LocalizedStrings.Get("PRESENTATION_CONTEXT_MENU_ADD_ACTION_AUDIO_PLAYLIST_title");

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, AudioPlaylistAction left, Pro.Entity.IAction right)
	{
		return PlaylistAction.CreateBinder(scheduler, entityFactory, left, right);
	}

	public AudioPlaylistAction(IPlaylistActionValidatorFactory? validatorFactory)
		: base(validatorFactory)
	{
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new AudioPlaylistAction(null));
	}
}
