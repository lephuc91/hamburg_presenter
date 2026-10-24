using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Strings;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Transitions.Descriptions;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Transitions;

public static class TransitionHelper
{
	public static TransitionParameters? ToTransition(this Pro.SerializationInterop.RVProtoData.Transition? protoTransition, IReadOnlyList<TransitionDescription> availableTransitions)
	{
		if (protoTransition == null)
		{
			return null;
		}
		TransitionDescription transitionDescription = availableTransitions.FirstOrDefault((TransitionDescription t) => t.ID.ToString().ToUpperInvariant() == protoTransition.Effect.RenderId);
		if (transitionDescription == null)
		{
			return null;
		}
		TransitionParameters transitionParameters = new TransitionParameters(transitionDescription);
		transitionParameters.Deserialize(protoTransition);
		return transitionParameters;
	}

	public static TransitionParameters? ToTransition(this ITransition transition, IReadOnlyList<TransitionDescription> availableTransitions)
	{
		if (transition == null)
		{
			return null;
		}
		IEffect value = transition.Effect.Value;
		string renderId = value?.RenderId.Value;
		if (string.IsNullOrWhiteSpace(renderId))
		{
			return null;
		}
		TransitionDescription transitionDescription = availableTransitions.FirstOrDefault((TransitionDescription t) => t.ID.ToString().Equals(renderId, StringComparison.InvariantCultureIgnoreCase));
		if (transitionDescription == null)
		{
			return null;
		}
		TransitionParameters transitionParameters = new TransitionParameters(transitionDescription);
		if (value != null)
		{
			transitionParameters.Deserialize(value);
		}
		if (transitionParameters.SupportsDuration)
		{
			transitionParameters.Duration = TimeSlice.FromSeconds(transition.Duration.Value);
		}
		return transitionParameters;
	}

	public static TransitionBase? FindSelectedTransition(this TransitionParameters transitionParameters)
	{
		return transitionParameters.FindTransition(DataVault.Transitions);
	}

	public static TransitionParameters? CloneTransitionParameters(this TransitionParameters transitionParameters)
	{
		TransitionBase transitionBase = transitionParameters.FindTransition(DataVault.Transitions);
		if (transitionBase == null)
		{
			return null;
		}
		TransitionParameters transitionParameters2 = transitionBase.LoadParameters();
		transitionParameters2.CopyFrom(transitionParameters);
		return transitionParameters2;
	}

	public static string CreateNewFavoriteTransitionName(string candidate, double duration)
	{
		return (candidate + " " + duration.ToString().Replace('.', '_') + "s").DuplicateName(Directory.GetFiles(CommonPaths.TransitionPresets), Path.GetFileNameWithoutExtension);
	}
}
