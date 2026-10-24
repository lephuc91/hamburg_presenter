using System;
using Pro.Common.Components;

namespace ProPresenter.DO.Bibles;

public abstract class AvailableBibleBase : LinkedNotifyPropertyChangedBase
{
	private bool _isInstalling;

	private bool _isInstalled;

	public string ID { get; }

	public virtual string Name { get; }

	public virtual string TrackingAbbreviation { get; }

	public virtual string DisplayAbbreviation { get; }

	public abstract bool IsActive { get; }

	public bool IsInstalling
	{
		get
		{
			return _isInstalling;
		}
		internal set
		{
			SetValue("IsInstalling", ref _isInstalling, value);
		}
	}

	public bool IsInstalled
	{
		get
		{
			return _isInstalled;
		}
		internal set
		{
			SetValue("IsInstalled", ref _isInstalled, value, (Action)delegate
			{
				IsInstalling = false;
			}, (Predicate<bool>?)null, referenceComparison: false);
		}
	}

	protected AvailableBibleBase(string id, string name, string trackingAbbreviation, string displayAbbreviation)
	{
		ID = id;
		Name = name;
		TrackingAbbreviation = trackingAbbreviation;
		DisplayAbbreviation = displayAbbreviation;
	}
}
