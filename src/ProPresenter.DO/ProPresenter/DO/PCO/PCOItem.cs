using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.PCO.Extensions;
using ProPresenter.DO.PCO.Items;

namespace ProPresenter.DO.PCO;

public abstract class PCOItem : PCOObject, IPCOAttachmentsContainer
{
	private readonly List<PCOMediaDetails> _media = new List<PCOMediaDetails>();

	private readonly List<PCOAttachmentDetails> _attachments = new List<PCOAttachmentDetails>();

	private readonly List<PCOSongDetails> _songs = new List<PCOSongDetails>();

	public IEnumerable<PCOMediaDetails> Media => _media;

	public IEnumerable<PCOAttachmentDetails> Attachments => _attachments;

	public abstract PCOItemType PCOItemType { get; }

	public DateTime? UpdatedAt { get; private set; }

	public string? PlanID { get; private set; }

	public string? ServiceId { get; private set; }

	protected PCOItem(string? id, string? name, string? planId, DateTime? updatedAt, string? serviceID)
		: base(id, name)
	{
		PlanID = planId;
		ServiceId = serviceID;
		UpdatedAt = updatedAt;
	}

	protected PCOItem(PlanningCenterPlan.Types.PlanItem planItem, string serviceID)
		: base(string.Empty, string.Empty)
	{
		ServiceId = serviceID;
		Deserialize(planItem);
	}

	public void LoadMedia(IEnumerable<PCOMediaDetails> media)
	{
		media.ForEach(delegate(PCOMediaDetails m)
		{
			_media.Add(m);
		});
	}

	public void LoadAttachments(List<PCOAttachmentDetails> attachments)
	{
		_attachments.AddRange(attachments);
	}

	internal void UpdateDetails(string oldDetailsID, IPCOContent newDetails)
	{
		if (newDetails is PCOMediaDetails newMediaDetails)
		{
			UpdateMediaDetails(oldDetailsID, newMediaDetails);
		}
		else if (newDetails is PCOSongDetails newSongDetails)
		{
			UpdateSongDetails(oldDetailsID, newSongDetails);
		}
		else if (newDetails is PCOAttachmentDetails newAttachmentDetails)
		{
			UpdateAttachmentDetails(oldDetailsID, newAttachmentDetails);
		}
	}

	private void UpdateMediaDetails(string oldDetailID, PCOMediaDetails newMediaDetails)
	{
		PCOMediaDetails pCOMediaDetails = _media.FirstOrDefault((PCOMediaDetails m) => m.ID == oldDetailID);
		if (pCOMediaDetails != null)
		{
			_media.Remove(pCOMediaDetails);
			if (newMediaDetails != null)
			{
				newMediaDetails.LocalWorkingPath = new RelativePath(Path.Combine(Path.GetDirectoryName(pCOMediaDetails.LocalWorkingPath), Path.GetFileName(newMediaDetails.PreviewUrl)));
				_media.Add(newMediaDetails);
			}
		}
	}

	private void UpdateSongDetails(string oldDetailID, PCOSongDetails newSongDetails)
	{
		PCOSongDetails pCOSongDetails = _songs.FirstOrDefault((PCOSongDetails s) => s.ID == oldDetailID);
		if (pCOSongDetails != null)
		{
			_songs.Remove(pCOSongDetails);
			if (newSongDetails != null)
			{
				_songs.Add(newSongDetails);
			}
		}
	}

	private void UpdateAttachmentDetails(string oldDetailsID, PCOAttachmentDetails newAttachmentDetails)
	{
		if (newAttachmentDetails == null)
		{
			return;
		}
		if (oldDetailsID == null)
		{
			_attachments.Add(newAttachmentDetails);
			return;
		}
		PCOAttachmentDetails pCOAttachmentDetails = Attachments.FirstOrDefault((PCOAttachmentDetails a) => a.ID == oldDetailsID);
		if (pCOAttachmentDetails != null)
		{
			_attachments.Remove(pCOAttachmentDetails);
			_attachments.Add(newAttachmentDetails);
			return;
		}
		foreach (PCOMediaDetails medium in Media)
		{
			pCOAttachmentDetails = medium.FindAttachment(oldDetailsID);
			if (pCOAttachmentDetails != null)
			{
				medium.ReplaceAttachment(pCOAttachmentDetails, newAttachmentDetails);
				return;
			}
		}
		TryUpdatingAttachmentDetailsForOtherSources(oldDetailsID, newAttachmentDetails);
	}

	protected virtual void TryUpdatingAttachmentDetailsForOtherSources(string oldDetailsID, PCOAttachmentDetails newAttachmentDetails)
	{
	}

	public PlanningCenterPlan.Types.PlanItem Serialize()
	{
		PlanningCenterPlan.Types.PlanItem planItem = new PlanningCenterPlan.Types.PlanItem
		{
			ItemType = PCOItemType.ToProtoPlanItemType(),
			PcoIdNum = base.ID.ToUintId(),
			PcoIdStr = (base.ID ?? string.Empty),
			ServiceIdNum = ServiceId.ToUintId(),
			ServiceIdStr = (ServiceId ?? string.Empty),
			ParentIdNum = PlanID.ToUintId(),
			ParentIdStr = (PlanID ?? string.Empty),
			Name = (base.Name ?? string.Empty),
			UpdateDate = UpdatedAt.ToTimeStamp()
		};
		planItem.Attachments.AddRange(Attachments.Select((PCOAttachmentDetails a) => a.Serialize()).ToArray());
		OnSerialize(planItem);
		return planItem;
	}

	protected virtual void OnSerialize(PlanningCenterPlan.Types.PlanItem planItem)
	{
	}

	protected internal void Deserialize(PlanningCenterPlan.Types.PlanItem planItem)
	{
		base.ID = IdExtensions.FromProto(planItem.PcoIdStr, planItem.PcoIdNum);
		ServiceId = IdExtensions.FromProto(planItem.ServiceIdStr, planItem.ServiceIdNum);
		PlanID = IdExtensions.FromProto(planItem.ParentIdStr, planItem.ParentIdNum);
		base.Name = planItem.Name;
		UpdatedAt = planItem.UpdateDate?.ToDateTime().ToLocalTime();
		_attachments.Clear();
		foreach (PlanningCenterPlan.Types.PlanItem.Types.Attachment attachment in planItem.Attachments)
		{
			PCOAttachmentDetails pCOAttachmentDetails = new PCOAttachmentDetails(base.ID);
			pCOAttachmentDetails.Deserialize(attachment);
			_attachments.Add(pCOAttachmentDetails);
		}
		OnDeserialize(planItem);
	}

	protected virtual void OnDeserialize(PlanningCenterPlan.Types.PlanItem planItem)
	{
	}
}
