using System;
using System.ComponentModel;
using Pro.Common.Components;

namespace Pro.DO.Transitions;

public class TransitionProvider : NotifyPropertyChangedBase, ITransitionProvider, INotifyPropertyChanged
{
	private TransitionStoreType? _activeStoreType;

	public TransitionStoreType? ActiveStoreType
	{
		get
		{
			return _activeStoreType;
		}
		private set
		{
			SetValue("ActiveStoreType", ref _activeStoreType, value);
		}
	}

	public TransitionProvider(TransitionStoreType? activeStoreType = null)
	{
		_activeStoreType = activeStoreType;
	}

	public virtual TransitionParameters? GetTransition(TransitionStoreType storeType, ITransitionSet set)
	{
		return storeType switch
		{
			TransitionStoreType.Cut => set.CutTransition?.LoadParameters(), 
			TransitionStoreType.Auto => set.AutoTransition?.LoadParameters(), 
			TransitionStoreType.Advanced => null, 
			_ => throw new NotSupportedException(), 
		};
	}

	public void StoreTransition(TransitionStoreType storeType, TransitionParameters parameters)
	{
		ActiveStoreType = OnStoreTransition(storeType, parameters);
	}

	protected virtual TransitionStoreType? OnStoreTransition(TransitionStoreType storeType, TransitionParameters parameters)
	{
		return null;
	}
}
