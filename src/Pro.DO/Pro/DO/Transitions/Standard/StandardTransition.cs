using Pro.DO.Transitions.Descriptions;

namespace Pro.DO.Transitions.Standard;

public class StandardTransition : TransitionBase
{
	public override TransitionType TransitionType => TransitionType.Standard;

	public StandardTransitionCollection Collection { get; }

	internal StandardTransition(TransitionDescription? description, StandardTransitionCollection collection)
		: base(new TransitionPreset(description, canRename: false))
	{
		Collection = collection;
	}

	public override TransitionParameters LoadParameters()
	{
		return new TransitionParameters(base.Preset, resetToStandard: true, canResetDuration: false);
	}
}
