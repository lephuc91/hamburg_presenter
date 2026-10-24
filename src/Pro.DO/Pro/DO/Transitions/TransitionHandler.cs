using System;
using System.Linq;
using Pro.Common.Components;
using Pro.DO.Effects;
using Pro.DO.Transitions.Favorite;

namespace Pro.DO.Transitions;

public class TransitionHandler : NotifyPropertyChangedBase
{
	private const string RecentModifiedFavoriteTransitionNameSuffix = "_edit";

	private TransitionStoreType? _lastStoreType;

	private TransitionBase? _activeTransition;

	private TransitionParameters? _activeParameters;

	private bool _isTransitionModified;

	private bool _wasSelectionChanged;

	private bool _ignoreActivation;

	private bool _isContinuousFinalize;

	private bool _isFinalizing;

	public ITransitionSet Set { get; }

	public ITransitionProvider Provider { get; }

	public bool IsActive
	{
		get
		{
			if (ActiveTransition != null)
			{
				return ActiveParameters != null;
			}
			return false;
		}
	}

	public TransitionBase? ActiveTransition
	{
		get
		{
			return _activeTransition;
		}
		private set
		{
			SetValue("ActiveTransition", ref _activeTransition, value, (Action<TransitionBase, TransitionBase>?)delegate
			{
				_wasSelectionChanged = true;
				OnPropertyChanged("IsActive");
			}, (Predicate<TransitionBase>?)null, referenceComparison: false);
		}
	}

	public TransitionParameters? ActiveParameters
	{
		get
		{
			return _activeParameters;
		}
		private set
		{
			SetValue<TransitionParameters>("ActiveParameters", ref _activeParameters, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				if (o != null)
				{
					o.ParametersChanged -= OnParametersChanged;
				}
				if (n != null)
				{
					n.ParametersChanged += OnParametersChanged;
				}
				OnPropertyChanged("IsActive");
				this.ActiveParametersChanged?.Invoke(o, n);
			}, null, referenceComparison: true);
		}
	}

	public bool IsTransitionModified
	{
		get
		{
			return _isTransitionModified;
		}
		private set
		{
			SetValue("IsTransitionModified", ref _isTransitionModified, value);
		}
	}

	public bool IsContinuousFinalize
	{
		get
		{
			return _isContinuousFinalize;
		}
		set
		{
			SetValue("IsContinuousFinalize", ref _isContinuousFinalize, value, delegate(bool o, bool n)
			{
				if (n && IsActive)
				{
					FinalizeTransition();
				}
			});
		}
	}

	public event Action<TransitionParameters?, TransitionParameters?>? ActiveParametersChanged;

	public event Action<TransitionParameters?>? TransitionFinalized;

	public TransitionHandler(ITransitionSet set, ITransitionProvider? provider = null)
	{
		Set = set;
		Provider = provider ?? new TransitionProvider(null);
		_lastStoreType = Provider.ActiveStoreType;
	}

	public void ActivateTransition(TransitionBase transition)
	{
		if (!_ignoreActivation)
		{
			_ignoreActivation = true;
			if (Set.StandardTransitions != null && !Set.FavoriteTransitions.Contains(transition) && !Set.RecentTransitions.Contains(transition) && !Set.StandardTransitions.Contains(transition))
			{
				throw new InvalidOperationException();
			}
			ActiveTransition = transition;
			ActiveParameters = transition.LoadParameters();
			UpdateIsModified();
			_ignoreActivation = false;
		}
	}

	public void ActivateTransition(TransitionStoreType storeType)
	{
		_lastStoreType = storeType;
		TransitionParameters transition = Provider.GetTransition(storeType, Set);
		if (transition != null)
		{
			ActivateTransition(transition);
		}
	}

	public void ActivateTransition(TransitionParameters? parameters)
	{
		if (!_ignoreActivation)
		{
			_ignoreActivation = true;
			TransitionBase transitionBase = parameters.FindTransition(Set);
			if (transitionBase != null)
			{
				ActiveTransition = transitionBase;
				TransitionParameters transitionParameters = transitionBase.LoadParameters();
				transitionParameters.CopyFrom(parameters);
				ActiveParameters = transitionParameters;
				UpdateIsModified();
			}
			else
			{
				ActiveTransition = null;
				ActiveParameters = null;
			}
			_ignoreActivation = false;
		}
	}

	public void FinalizeTransition()
	{
		if (!IsActive)
		{
			throw new InvalidOperationException();
		}
		if (_isFinalizing)
		{
			return;
		}
		_isFinalizing = true;
		TransitionParameters transitionParameters = ActiveParameters;
		bool flag = ActiveTransition != null && ActiveTransition.TransitionType == TransitionType.Favorite;
		if (!IsContinuousFinalize && ((!flag && _wasSelectionChanged) || IsTransitionModified))
		{
			string text = ActiveTransition?.Preset.Name;
			if (flag)
			{
				text += "_edit";
			}
			if (text != null && transitionParameters != null)
			{
				transitionParameters = new TransitionParameters(Set.RecentTransitions.Add(text, transitionParameters).Preset, resetToStandard: false);
			}
		}
		if (!IsContinuousFinalize)
		{
			ActiveParameters = null;
			ActiveTransition = null;
		}
		_wasSelectionChanged = false;
		UpdateIsModified();
		this.TransitionFinalized?.Invoke(transitionParameters);
		if (_lastStoreType.HasValue && transitionParameters != null)
		{
			Provider.StoreTransition(_lastStoreType.Value, transitionParameters);
		}
		_isFinalizing = false;
	}

	public void CreateFavorite(string newName)
	{
		if (!IsActive)
		{
			throw new InvalidOperationException();
		}
		if (ActiveParameters != null)
		{
			ActivateTransition(Set.FavoriteTransitions.Add(newName, ActiveParameters));
		}
	}

	public void ClearRecentList()
	{
		_ignoreActivation = true;
		Set.RecentTransitions.Clear();
		_ignoreActivation = false;
		TransitionBase? activeTransition = ActiveTransition;
		if (activeTransition != null && activeTransition.TransitionType == TransitionType.Recent && ActiveParameters != null)
		{
			ActivateTransition(ActiveParameters);
		}
	}

	public void RemoveFavorite(FavoriteTransition transition)
	{
		_ignoreActivation = true;
		Set.FavoriteTransitions.Remove(transition);
		_ignoreActivation = false;
		if (ActiveTransition == transition && ActiveParameters != null)
		{
			ActivateTransition(ActiveParameters);
		}
	}

	public void SaveChanges()
	{
		if (IsActive)
		{
			if (ActiveParameters != null)
			{
				ActiveTransition?.SaveChanges(ActiveParameters);
			}
			UpdateIsModified();
		}
	}

	public void RemoveTransition()
	{
		ActiveParameters = null;
		ActiveTransition = null;
		this.TransitionFinalized?.Invoke(null);
	}

	private void UpdateIsModified()
	{
		if (!IsActive)
		{
			IsTransitionModified = false;
		}
		else if (ActiveParameters != null)
		{
			OnParametersChanged(ActiveParameters);
		}
	}

	private void OnParametersChanged(EffectParameters parameters)
	{
		if (ActiveParameters != null && ActiveTransition?.Preset.Parameters != null)
		{
			IsTransitionModified = !ActiveParameters.Equals(ActiveTransition.Preset.Parameters, !ActiveParameters.CanResetDuration, ignoreName: true);
		}
		if (IsContinuousFinalize)
		{
			FinalizeTransition();
		}
	}
}
