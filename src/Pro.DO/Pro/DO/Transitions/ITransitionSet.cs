using Pro.DO.Transitions.Favorite;
using Pro.DO.Transitions.Recent;
using Pro.DO.Transitions.Standard;

namespace Pro.DO.Transitions;

public interface ITransitionSet
{
	StandardTransitionCollection? StandardTransitions { get; }

	FavoriteTransitionCollection FavoriteTransitions { get; }

	RecentTransitionCollection RecentTransitions { get; }

	TransitionBase? CutTransition { get; }

	TransitionBase? AutoTransition { get; }
}
