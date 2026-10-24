using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;

namespace ProPresenter.UI.CueInspector;

public class EffectCommandParameters
{
	public EffectParameters? TargetEffectParameters { get; }

	public EffectDescription? NewEffect { get; }

	public bool IsReplace { get; }

	public EffectCommandParameters(EffectParameters? targetEffectParams, bool isReplace = false, EffectDescription? newEffect = null)
	{
		TargetEffectParameters = targetEffectParams;
		IsReplace = isReplace;
		NewEffect = newEffect;
	}
}
