using System;

namespace ProPresenter.DO.PCO;

public class PCOServiceType : PCOObject
{
	private PCOPlan[] _plans = new PCOPlan[1];

	private bool _hasData;

	public Action<PCOServiceType>? RequestPlans;

	public bool IsLoading => _plans == null;

	public PCOPlan[]? Plans
	{
		get
		{
			return _plans;
		}
		internal set
		{
			SetValue<PCOPlan[]>("Plans", ref _plans, value, delegate(PCOPlan[] o, PCOPlan[] n)
			{
				_hasData = n != null;
				OnPropertyChanged("IsLoading");
			});
		}
	}

	internal PCOServiceType(string? id, string? name)
		: base(id, name)
	{
	}

	public void LoadPlans()
	{
		if (!_hasData)
		{
			Plans = null;
			RequestPlans?.Invoke(this);
		}
	}
}
