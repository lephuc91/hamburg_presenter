using System;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.PCO.Extensions;

namespace ProPresenter.DO.PCO.Items;

public class PCOPlanSong : PCOItem
{
	public override PCOItemType PCOItemType => PCOItemType.Song;

	public string? SongID { get; private set; }

	public PCOSongDetails? Song { get; private set; }

	public PCOSongArrangement? Arrangement { get; private set; }

	public string? SelectedArrangementID { get; private set; }

	public PCOPlanSong(string? id, string? name, string? planId, DateTime? updatedAt, string? serviceID, string? songId, string? songArrangmentId)
		: base(id, name, planId, updatedAt, serviceID)
	{
		SongID = songId;
		SelectedArrangementID = songArrangmentId;
	}

	public PCOPlanSong(PlanningCenterPlan.Types.PlanItem planItem, string serviceID)
		: base(planItem, serviceID)
	{
	}

	public void LoadSong(PCOSongDetails songDetails)
	{
		Song = songDetails;
	}

	public void LoadArrangment(PCOSongArrangement arrangement)
	{
		Arrangement = arrangement;
	}

	protected override void OnSerialize(PlanningCenterPlan.Types.PlanItem planItem)
	{
		planItem.LinkedSong = new PlanningCenterPlan.Types.PlanItem.Types.SongItem
		{
			PcoIdNum = SongID.ToUintId(),
			PcoIdStr = (SongID ?? string.Empty),
			ArrangementIdNum = SelectedArrangementID.ToUintId(),
			ArrangementIdStr = (SelectedArrangementID ?? string.Empty),
			Ccli = Song?.SerializeCCLI()
		};
		if (Arrangement != null)
		{
			PlanningCenterPlan.Types.PlanItem.Types.SongItem.Types.Sequence sequence = new PlanningCenterPlan.Types.PlanItem.Types.SongItem.Types.Sequence
			{
				Name = (Arrangement.Name ?? string.Empty),
				PcoIdNum = Arrangement.ID.ToUintId(),
				PcoIdStr = (Arrangement.ID ?? string.Empty)
			};
			sequence.GroupNames.AddRange(Arrangement.Sequence);
			planItem.LinkedSong.Sequence = sequence;
		}
	}

	protected override void OnDeserialize(PlanningCenterPlan.Types.PlanItem planItem)
	{
		PlanningCenterPlan.Types.PlanItem.Types.SongItem songItem = planItem?.LinkedSong;
		if (songItem != null)
		{
			SongID = IdExtensions.FromProto(songItem.PcoIdStr, songItem.PcoIdNum);
			Song = new PCOSongDetails(SongID, songItem.Ccli);
			PlanningCenterPlan.Types.PlanItem.Types.SongItem.Types.Sequence sequence = songItem.Sequence;
			if (sequence != null)
			{
				Arrangement = new PCOSongArrangement(IdExtensions.FromProto(sequence.PcoIdStr, sequence.PcoIdNum), sequence.Name, sequence.GroupNames);
			}
			SelectedArrangementID = IdExtensions.FromProto(songItem.ArrangementIdStr, songItem.ArrangementIdNum);
		}
	}

	protected override void TryUpdatingAttachmentDetailsForOtherSources(string oldDetailsID, PCOAttachmentDetails newAttachmentDetails)
	{
		PCOAttachmentDetails pCOAttachmentDetails = Song?.FindAttachment(oldDetailsID);
		if (pCOAttachmentDetails != null)
		{
			Song.ReplaceAttachment(pCOAttachmentDetails, newAttachmentDetails);
		}
	}
}
