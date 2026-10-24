using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.PCO.Items;

public class PCOPlanMedia : PCOItem
{
	public override PCOItemType PCOItemType => PCOItemType.Media;

	public PCOPlanMedia(string? id, string? name, string? planId, DateTime? updatedAt, string? serviceID)
		: base(id, name, planId, updatedAt, serviceID)
	{
	}

	public PCOPlanMedia(PlanningCenterPlan.Types.PlanItem planItem, string serviceID)
		: base(planItem, serviceID)
	{
	}
}
