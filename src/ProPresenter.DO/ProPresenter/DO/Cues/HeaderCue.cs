using System.Reactive;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Cues;

public class HeaderCue : ProPresenterCue, IHeaderCue
{
	public override CueType Type => CueType.Header;

	public HeaderAction HeaderAction => base.Actions.FirstOf<HeaderAction>();

	public override IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem right)
	{
		IPlaylistItem.Types.IItemType.IHeader header = right.ItemType.Value as IPlaylistItem.Types.IItemType.IHeader;
		if (header == null)
		{
			header = entityFactory.Create<IPlaylistItem.Types.IItemType.IHeader>();
			right.ItemType.Set(header);
		}
		ObjectBinder<HeaderAction, IPlaylistItem.Types.IHeader> headerBinder = ProPresenter.DO.Actions.HeaderAction.CreateBinder(scheduler, entityFactory, HeaderAction, header.Value);
		ObjectBinder<HeaderCue, IPlaylistItem> objectBinder = new ObjectBinder<HeaderCue, IPlaylistItem>(this, right);
		objectBinder.Bind((HeaderCue l) => l.WhenPropertyChanges("ID"), (IPlaylistItem r) => r.Uuid.WhenValueChanges, delegate(HeaderCue l, IPlaylistItem r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IPlaylistItem r, HeaderCue l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((HeaderCue l) => l.WhenPropertyChanges("Name"), (IPlaylistItem r) => r.Name.WhenValueChanges, delegate(HeaderCue l, IPlaylistItem r)
		{
			r.Name.Set(l.Name);
		}, delegate(IPlaylistItem r, HeaderCue l)
		{
			l.Name = r.Name.Value;
		}).Bind((HeaderCue l) => l.WhenPropertyChanges("IsHidden"), (IPlaylistItem r) => r.IsHidden.WhenValueChanges, delegate(HeaderCue l, IPlaylistItem r)
		{
			r.IsHidden.Set(l.IsHidden);
		}, delegate(IPlaylistItem r, HeaderCue l)
		{
			l.IsHidden = r.IsHidden.Value;
		})
			.Bind<Unit, Unit>(null, (IPlaylistItem r) => r.ItemType.WhenValueChanges.ToUnit(), delegate
			{
				Log.Error("[{0}] Attempting to change the type of the cue from within ProPresenter.", typeof(PlaceholderCue));
			}, delegate(IPlaylistItem r, HeaderCue l)
			{
				Log.Error("[{0}] Attempting to change the type of the cue via CRDT to {1}. This is not supported currently.", typeof(PlaceholderCue), r.ItemType.Value);
			})
			.DoOnInitializeRightFromLeft(headerBinder.InitializeRightFromLeft)
			.DoOnInitializeLeftFromRight(headerBinder.InitializeLeftFromRight)
			.RegisterChildDisposable(() => headerBinder);
		return objectBinder;
	}

	public HeaderCue(HeaderAction action)
	{
		AddAction(action);
		Name = action.Name;
		LinkAction("Name", delegate
		{
			Name = HeaderAction.Name;
		});
		HookupActionEvents(action);
	}

	private HeaderCue()
	{
	}

	public override Pro.DO.Triggering.Cue Clone()
	{
		return CopyProperties(new HeaderCue());
	}

	private void HookupActionEvents(HeaderAction action)
	{
		if (action != null)
		{
			action.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	protected override void OnProtoSerializePlaylistItem(PlaylistItem playlistItem)
	{
		playlistItem.Header = HeaderAction.ProtoSerializePlaylistItemHeader();
		playlistItem.Name = Name ?? string.Empty;
	}

	protected override void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		HeaderAction.ProtoDeserializePlaylistItemHeader(playlistItem.Header);
		Name = playlistItem.Name;
	}

	protected override void OnNameChanged(string oldName, string newName)
	{
		HeaderAction.Name = newName;
	}
}
