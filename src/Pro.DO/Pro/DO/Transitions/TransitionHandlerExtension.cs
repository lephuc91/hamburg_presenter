using System.Collections.Generic;
using System.Linq;
using Pro.DO.Transitions.Standard;

namespace Pro.DO.Transitions;

public static class TransitionHandlerExtension
{
	public static TransitionBase? FindTransition(this TransitionParameters? parameters, ITransitionSet set)
	{
		if (parameters == null)
		{
			return null;
		}
		IEnumerable<TransitionBase>[] array;
		if (parameters.Preset != null)
		{
			array = new IEnumerable<TransitionBase>[2] { set.FavoriteTransitions, set.RecentTransitions };
			for (int i = 0; i < array.Length; i++)
			{
				TransitionBase transitionBase = array[i].FirstOrDefault((TransitionBase t) => t.Preset == parameters.Preset);
				if (transitionBase != null)
				{
					return transitionBase;
				}
			}
		}
		array = new IEnumerable<TransitionBase>[3] { set.FavoriteTransitions, set.RecentTransitions, set.StandardTransitions };
		for (int i = 0; i < array.Length; i++)
		{
			TransitionBase transitionBase2 = array[i]?.FirstOrDefault((TransitionBase t) => t.Preset.Parameters != null && t.Preset.Parameters.Equals(parameters, ignoreDuration: false, ignoreName: true));
			if (transitionBase2 != null)
			{
				return transitionBase2;
			}
		}
		StandardTransition standardTransition = set.StandardTransitions?.FirstOrDefault((StandardTransition t) => t.Preset.Parameters != null && t.Preset.Parameters.TransitionDescription == parameters.TransitionDescription);
		if (standardTransition != null)
		{
			return standardTransition;
		}
		return null;
	}
}
