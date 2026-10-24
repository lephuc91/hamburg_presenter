using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Transitions.Descriptions;

namespace Pro.DO.Transitions;

public class TransitionDescriptionCollection : ImmutableObservableCollection<TransitionDescription>, ITransitionDescriptionCollection, IImmutableObservableCollection<TransitionDescription>, IReadOnlyList<TransitionDescription>, IEnumerable<TransitionDescription>, IEnumerable, IReadOnlyCollection<TransitionDescription>, INotifyEnumerableChanged<TransitionDescription>, INotifyCollectionChanged
{
	public TransitionDescriptionCollection(IEnumerable<TransitionDescription> transitions)
		: base(transitions)
	{
	}

	public TransitionDescription? FindDescription(Guid id)
	{
		return base.Collection.FirstOrDefault((TransitionDescription d) => d.ID == id);
	}
}
