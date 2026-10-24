using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Localization;

namespace ProPresenter.DO.Actions;

public class VisualPlaylistAction : PlaylistAction
{
	public override ActionType ActionType => ActionType.VisualPlaylist;

	protected override string DefaultName => LocalizedStrings.Get("PRESENTATION_CONTEXT_MENU_ADD_ACTION_MEDIA_PLAYLIST_title");

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, VisualPlaylistAction left, Pro.Entity.IAction right)
	{
		return PlaylistAction.CreateBinder(scheduler, entityFactory, left, right);
	}

	public VisualPlaylistAction(IPlaylistActionValidatorFactory? validatorFactory)
		: base(validatorFactory)
	{
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new VisualPlaylistAction(null));
	}
}
