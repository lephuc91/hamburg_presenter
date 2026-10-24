using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.PCO.Items;

public class PCOPlanItem : PCOItem
{
	public override PCOItemType PCOItemType => PCOItemType.Plan;

	public PCOPlanItem(string? id, string? name, string? planId, DateTime? updatedAt, string? serviceID)
		: base(id, name, planId, updatedAt, serviceID)
	{
	}

	public PCOPlanItem(PlanningCenterPlan.Types.PlanItem planItem, string serviceID)
		: base(planItem, serviceID)
	{
	}
}
