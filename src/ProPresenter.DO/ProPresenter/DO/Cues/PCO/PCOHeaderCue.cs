using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;

namespace ProPresenter.DO.Cues.PCO;

public class PCOHeaderCue : PCOCueBase, IHeaderCue
{
	public override PCOItemType PCOItemType => PCOItemType.Header;

	public HeaderAction HeaderAction => base.Actions.FirstOf<HeaderAction>();

	protected override void CreateLinkDataBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, ObjectBinder<PCOCueBase, IPlaylistItem.Types.IPlanningCenter> cueBinder)
	{
		ObjectBinder<PCOHeaderCue, IPlaylistItem.Types.IPlanningCenter> headerCueBinder = new ObjectBinder<PCOHeaderCue, IPlaylistItem.Types.IPlanningCenter>(this, cueBinder.Right);
		headerCueBinder.Bind((PCOHeaderCue l) => l.WhenPropertyChanges("HeaderAction"), (IPlaylistItem.Types.IPlanningCenter r) => r.LinkedData.WhenValueChanges.ToUnit(), delegate(PCOHeaderCue l, IPlaylistItem.Types.IPlanningCenter r)
		{
			IPlaylistItem playlistItem = entityFactory.Create<IPlaylistItem>();
			IPlaylistItem.Types.IItemType.IHeader header = entityFactory.Create<IPlaylistItem.Types.IItemType.IHeader>();
			playlistItem.ItemType.Set(header);
			r.LinkedData.Set(playlistItem);
			ObjectBinder<HeaderAction, IPlaylistItem.Types.IHeader> objectBinder = ProPresenter.DO.Actions.HeaderAction.CreateBinder(scheduler, entityFactory, l.HeaderAction, header.Value);
			objectBinder.InitializeRightFromLeft();
			header.Value.RegisterLinkedDisposable(objectBinder);
		}, delegate(IPlaylistItem.Types.IPlanningCenter r, PCOHeaderCue l)
		{
			if (r.LinkedData.Value?.ItemType is IPlaylistItem.Types.IItemType.IHeader header2)
			{
				ObjectBinder<HeaderAction, IPlaylistItem.Types.IHeader> objectBinder2 = ProPresenter.DO.Actions.HeaderAction.CreateBinder(scheduler, entityFactory, l.HeaderAction, header2.Value);
				objectBinder2.InitializeLeftFromRight();
				header2.Value.RegisterLinkedDisposable(objectBinder2);
			}
		});
		cueBinder.DoOnInitializeRightFromLeft(headerCueBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(headerCueBinder.InitializeLeftFromRight).RegisterChildDisposable(() => headerCueBinder);
	}

	public PCOHeaderCue(PCOPlanHeader planHeader, string? planID, string serviceID, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
		: base(mediaFactory, new HeaderAction(), planHeader, planID, serviceID, transitionDescriptions)
	{
		if (HeaderAction != null)
		{
			planHeader.Name.ThrowWhenNull("planHeader.Name");
			HeaderAction.Name = planHeader.Name;
		}
	}

	protected override void OnProtoSerializePlaylistItem(PlaylistItem playlistItem)
	{
		base.OnProtoSerializePlaylistItem(playlistItem);
		if (HeaderAction != null)
		{
			playlistItem.PlanningCenter.LinkedData = new HeaderCue(HeaderAction).ProtoSerializePlaylistItem();
		}
	}

	protected override void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		base.OnProtoDeserializePlaylistItem(playlistItem, applicationData, containerId);
		HeaderAction?.ProtoDeserializePlaylistItemHeader(playlistItem.PlanningCenter.LinkedData.Header);
	}
}
