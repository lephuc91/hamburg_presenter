using System;

namespace ProPresenter.Controller.Monitors;

public abstract class MonitorBase
{
	public abstract MonitorType MonitorType { get; }

	public event Action<MonitorBase>? ResourceChanged;

	protected void OnResourceChanged()
	{
		this.ResourceChanged?.Invoke(this);
	}

	public abstract void StopMonitoring();
}
