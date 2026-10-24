using Pro.DO.Transitions;
using ProPresenter.DO.Actions.PCO;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Cues.PCO;

public class PCOPlanCue : PCOCueBase
{
	public override PCOItemType PCOItemType => PCOItemType.Plan;

	public PCOPlanCue(PCOPlanItem planItem, string? planID, string serviceID, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
		: base(mediaFactory, new PCOPlanAction(app), planItem, planID, serviceID, transitionDescriptions)
	{
	}
}
