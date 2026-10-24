using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Transitions.Descriptions;

namespace Pro.DO.Transitions.Standard;

public class StandardTransitionCollection : TransitionCollectionBase<StandardTransition>
{
	public StandardTransitionCollection(ITransitionDescriptionCollection transitionDescriptions)
	{
		base.Collection.AddRange(transitionDescriptions.Select((TransitionDescription d) => new StandardTransition(d, this)));
	}
}
