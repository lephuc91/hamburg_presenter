namespace Pro.DO.Effects.Extensions;

public static class EffectParametersExtension
{
	public static EffectParameters MakeCopy(this EffectParameters effectParameters)
	{
		EffectParameters effectParameters2 = new EffectParameters(effectParameters.EffectDescription, effectParameters.IsEnabled);
		effectParameters2.CopyFrom(effectParameters);
		return effectParameters2;
	}
}
