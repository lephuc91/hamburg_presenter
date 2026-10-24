using Pro.Common.Collections;

namespace Pro.DO.Transitions;

public abstract class TransitionCollectionBase<T> : ImmutableObservableCollection<T> where T : TransitionBase
{
}
