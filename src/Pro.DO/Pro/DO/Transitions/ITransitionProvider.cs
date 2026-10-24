using System.ComponentModel;

namespace Pro.DO.Transitions;

public interface ITransitionProvider : INotifyPropertyChanged
{
	TransitionStoreType? ActiveStoreType { get; }

	TransitionParameters? GetTransition(TransitionStoreType storeType, ITransitionSet set);

	void StoreTransition(TransitionStoreType storeType, TransitionParameters parameters);
}
