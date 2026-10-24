using System;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.PCO.Extensions;

namespace ProPresenter.DO.PCO.Items;

public class PCODetailsBase : NotifyPropertyChangedBase
{
	public string ID { get; private set; }

	public DateTime? UpdatedAt { get; private set; }

	public string PCOItemID { get; private set; }

	public string? Url { get; private set; }

	public DateTime? CreatedDate { get; private set; }

	public PCODetailsBase(string? id, DateTime? updatedAt, DateTime? created, string? url, string? pcoItemID)
	{
		id.ThrowWhenNull("id");
		ID = id;
		UpdatedAt = updatedAt;
		CreatedDate = created;
		PCOItemID = pcoItemID ?? string.Empty;
		Url = url;
	}

	internal PCODetailsBase(string pcoItemID)
	{
		PCOItemID = (ID = pcoItemID);
	}

	protected internal virtual PlanningCenterPlan.Types.PlanItem.Types.Attachment Serialize()
	{
		return new PlanningCenterPlan.Types.PlanItem.Types.Attachment
		{
			Url = Url.WebURLToProtoURL(),
			CreatedDate = CreatedDate?.ToTimeStamp(),
			PcoIdNum = ID.ToUintId(),
			PcoIdStr = ID,
			UpdateDate = UpdatedAt?.ToTimeStamp()
		};
	}

	protected internal virtual void Deserialize(PlanningCenterPlan.Types.PlanItem.Types.Attachment attachment)
	{
		if (attachment != null)
		{
			Url = attachment.Url?.ProtoURLToWebURL();
			CreatedDate = attachment.CreatedDate?.ToDateTime().ToLocalTime();
			PCOItemID = IdExtensions.FromProto(attachment.PcoIdStr, attachment.PcoIdNum);
			UpdatedAt = attachment.UpdateDate?.ToDateTime().ToLocalTime();
		}
	}
}
