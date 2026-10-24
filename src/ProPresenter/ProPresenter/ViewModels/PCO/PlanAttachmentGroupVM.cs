using Pro.Common.Collections;
using ProPresenter.DO.PCO;

namespace ProPresenter.ViewModels.PCO;

public class PlanAttachmentGroupVM : AttachmentGroupVMBase
{
	private readonly PCOPlan _plan;

	public override string Name => _plan.Name ?? string.Empty;

	public override PCOObject ReferenceObject => _plan;

	public PlanAttachmentGroupVM(IPCOConsumer consumer, PCOPlan plan)
		: base(consumer)
	{
		_plan = plan;
		base.SourceAttachments.AddRange(plan.Attachments);
	}
}
