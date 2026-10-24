using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions.Favorite;

public class FavoriteTransition : TransitionBase
{
	public override TransitionType TransitionType => TransitionType.Favorite;

	public FavoriteTransition(TransitionDescriptionCollection transitionDescriptions, Transition.Types.Preset protoPreset)
		: base(new TransitionPreset(transitionDescriptions, protoPreset, canRename: true))
	{
	}

	public FavoriteTransition(TransitionPreset preset)
		: base(preset)
	{
	}

	public override TransitionParameters LoadParameters()
	{
		return new TransitionParameters(base.Preset, resetToStandard: false);
	}

	protected internal override void SaveChanges(TransitionParameters parameters)
	{
		if (parameters.Preset == base.Preset && base.Preset.Parameters?.TransitionDescription != null)
		{
			base.Preset.UpdateParameters((TransitionParameters)new TransitionParameters(base.Preset.Parameters.TransitionDescription).CopyFrom(parameters));
		}
	}
}
