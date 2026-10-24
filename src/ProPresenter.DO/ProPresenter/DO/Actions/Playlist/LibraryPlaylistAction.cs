using System;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.DO.Triggering;
using Pro.Entity;

namespace ProPresenter.DO.Actions.Playlist;

public class LibraryPlaylistAction : PlaylistAction
{
	public override ActionType ActionType => ActionType.LibraryPlaylist;

	protected override string DefaultName => base.PlaylistName;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, LibraryPlaylistAction left, Pro.Entity.IAction right)
	{
		return PlaylistAction.CreateBinder(scheduler, entityFactory, left, right);
	}

	public static ObjectBinder<LibraryPlaylistAction, Pro.Entity.IAction.Types.IActionTypeData.IPlaylistItem> CreateBinder(IUiScheduler uiScheduler, LibraryPlaylistAction action, Pro.Entity.IAction.Types.IActionTypeData.IPlaylistItem entityActionData)
	{
		ObjectBinder<LibraryPlaylistAction, Pro.Entity.IAction.Types.IActionTypeData.IPlaylistItem> objectBinder = new ObjectBinder<LibraryPlaylistAction, Pro.Entity.IAction.Types.IActionTypeData.IPlaylistItem>(action, entityActionData);
		ObjectBinder<PlaylistAction, Pro.Entity.IAction.Types.IPlaylistItemType> actionDataBinder = PlaylistAction.CreateBinder(uiScheduler, action, entityActionData.Value);
		objectBinder.DoOnInitializeRightFromLeft(actionDataBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(actionDataBinder.InitializeLeftFromRight).RegisterChildDisposable(() => actionDataBinder);
		return objectBinder;
	}

	public LibraryPlaylistAction(IPlaylistActionValidatorFactory? validatorFactory, Guid? id = null)
		: base(validatorFactory)
	{
		base.ID = id ?? base.ID;
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new LibraryPlaylistAction(null, null));
	}
}
