using ProPresenter.DO.Registration.State.Bible;

namespace ProPresenter.DO.Bibles;

public class AvailablePurchasedBible : AvailableBibleBase
{
	private bool _isInUse;

	private bool _isActive;

	private string _activeMachineName;

	private string _activeDisplayName;

	public bool IsInUse => _isInUse;

	public override bool IsActive => _isActive;

	public string ActiveMachineName => _activeMachineName;

	public string ActiveDisplayName => _activeDisplayName;

	public AvailablePurchasedBible(Purchased license, ActiveCopy? activeCopy)
		: this(license.Metadata.Id, license.Metadata.Name, license.Metadata.InternalAbbreviation, license.Metadata.DisplayAbbreviation, activeCopy != null, isActive: false, activeCopy?.Hostname ?? string.Empty, activeCopy?.DisplayName ?? string.Empty)
	{
	}

	public AvailablePurchasedBible(Purchased license, bool isActive)
		: this(license.Metadata.Id, license.Metadata.Name, license.Metadata.InternalAbbreviation, license.Metadata.DisplayAbbreviation, isInUse: false, isActive, string.Empty, string.Empty)
	{
	}

	private AvailablePurchasedBible(string id, string name, string trackingAbbreviation, string displayAbbreviation, bool isInUse, bool isActive, string activeMachineName, string activeDisplayName)
		: base(id, name, trackingAbbreviation, displayAbbreviation)
	{
		_isInUse = isInUse;
		_isActive = isActive;
		_activeMachineName = activeMachineName;
		_activeDisplayName = activeDisplayName;
	}

	internal void UpdateSource(AvailablePurchasedBible availablePurchasedBible)
	{
		if (availablePurchasedBible != null)
		{
			_isInUse = availablePurchasedBible._isInUse;
			_isActive = availablePurchasedBible._isActive;
			_activeMachineName = availablePurchasedBible._activeDisplayName;
			_activeDisplayName = availablePurchasedBible._activeDisplayName;
			OnPropertyChanged("IsInUse");
			OnPropertyChanged("IsActive");
			OnPropertyChanged("ActiveMachineName");
			OnPropertyChanged("ActiveDisplayName");
		}
	}
}
