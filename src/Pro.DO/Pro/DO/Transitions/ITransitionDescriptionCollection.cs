using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.DO.Transitions.Descriptions;

namespace Pro.DO.Transitions;

public interface ITransitionDescriptionCollection : IImmutableObservableCollection<TransitionDescription>, IReadOnlyList<TransitionDescription>, IEnumerable<TransitionDescription>, IEnumerable, IReadOnlyCollection<TransitionDescription>, INotifyEnumerableChanged<TransitionDescription>, INotifyCollectionChanged
{
	TransitionDescription? FindDescription(Guid id);
}
