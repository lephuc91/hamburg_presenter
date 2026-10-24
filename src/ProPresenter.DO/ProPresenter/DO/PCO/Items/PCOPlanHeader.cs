using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.PCO.Items;

public class PCOPlanHeader : PCOItem
{
	public override PCOItemType PCOItemType => PCOItemType.Header;

	public PCOPlanHeader(string? id, string? name, string? planId, DateTime? updatedAt, string? serviceID)
		: base(id, name, planId, updatedAt, serviceID)
	{
	}

	public PCOPlanHeader(PlanningCenterPlan.Types.PlanItem planItem, string serviceID)
		: base(planItem, serviceID)
	{
	}
}
