using System;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Transitions.Descriptions;

namespace ProPresenter.DO.Transitions;

public class GlobalTransitionProvider : TransitionProvider
{
	private TransitionParameters? _storedAutoParameters;

	private TransitionParameters? _storedAdvancedParameters;

	public TransitionParameters? StoredAutoParameters
	{
		get
		{
			return _storedAutoParameters;
		}
		set
		{
			SetValue("StoredAutoParameters", ref _storedAutoParameters, value);
		}
	}

	public TransitionParameters? StoredAdvancedParameters
	{
		get
		{
			return _storedAdvancedParameters;
		}
		set
		{
			SetValue("StoredAdvancedParameters", ref _storedAdvancedParameters, value);
		}
	}

	public GlobalTransitionProvider(ITransitionSet set, TransitionStoreType storeType, TimeSlice autoDuration, TransitionParameters? advancedParameters)
		: base(storeType)
	{
		StoredAutoParameters = set.AutoTransition?.LoadParameters();
		if ((object)StoredAutoParameters != null)
		{
			StoredAutoParameters.Duration = autoDuration;
		}
		StoredAdvancedParameters = advancedParameters;
	}

	public TransitionParameters? GetTransition(ITransitionSet set)
	{
		if (!base.ActiveStoreType.HasValue)
		{
			throw new InvalidOperationException();
		}
		return GetTransition(base.ActiveStoreType.Value, set);
	}

	public override TransitionParameters? GetTransition(TransitionStoreType storeType, ITransitionSet set)
	{
		switch (storeType)
		{
		case TransitionStoreType.Cut:
			return set?.CutTransition?.LoadParameters();
		case TransitionStoreType.Auto:
		{
			TransitionParameters transitionParameters = StoredAutoParameters;
			if ((object)transitionParameters == null)
			{
				if (set == null)
				{
					return null;
				}
				TransitionBase? autoTransition = set.AutoTransition;
				if (autoTransition == null)
				{
					return null;
				}
				transitionParameters = autoTransition.LoadParameters();
			}
			return transitionParameters;
		}
		case TransitionStoreType.Advanced:
			return StoredAdvancedParameters;
		default:
			throw new NotSupportedException();
		}
	}

	protected override TransitionStoreType? OnStoreTransition(TransitionStoreType storeType, TransitionParameters parameters)
	{
		switch (storeType)
		{
		case TransitionStoreType.Cut:
			return TransitionStoreType.Cut;
		case TransitionStoreType.Auto:
			StoredAutoParameters = parameters;
			return TransitionStoreType.Auto;
		case TransitionStoreType.Advanced:
			if (parameters.TransitionDescription?.ID == TransitionDescription.AutoTransitionID)
			{
				StoredAutoParameters = parameters;
				return TransitionStoreType.Auto;
			}
			if (parameters.TransitionDescription?.ID != TransitionDescription.CutTransitionID)
			{
				StoredAdvancedParameters = parameters;
				return TransitionStoreType.Advanced;
			}
			return TransitionStoreType.Cut;
		default:
			return null;
		}
	}
}
