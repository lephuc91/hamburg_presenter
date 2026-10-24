using Pro.DO.Transitions;
using ProPresenter.DO.Actions.PCO;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Cues.PCO;

public class PCOMediaCue : PCOCueBase
{
	public override PCOItemType PCOItemType => PCOItemType.Media;

	public PCOMediaCue(PCOPlanMedia planMedia, string? planID, string serviceID, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
		: base(mediaFactory, new PCOMediaAction(app), planMedia, planID, serviceID, transitionDescriptions)
	{
	}
}
