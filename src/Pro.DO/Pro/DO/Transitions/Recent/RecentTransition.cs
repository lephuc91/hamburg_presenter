using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions.Recent;

public class RecentTransition : TransitionBase
{
	public override TransitionType TransitionType => TransitionType.Recent;

	internal RecentTransition(ITransitionDescriptionCollection transitionDescriptions, Transition.Types.Preset protoPreset)
		: base(new TransitionPreset(transitionDescriptions, protoPreset, canRename: false))
	{
	}

	internal RecentTransition(TransitionPreset preset)
		: base(preset)
	{
	}

	public override TransitionParameters LoadParameters()
	{
		return new TransitionParameters(base.Preset, resetToStandard: false);
	}
}
