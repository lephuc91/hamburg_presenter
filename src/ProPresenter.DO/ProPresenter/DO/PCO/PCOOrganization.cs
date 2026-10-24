using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Components;

namespace ProPresenter.DO.PCO;

public class PCOOrganization : NotifyPropertyChangedBase
{
	private string? _name = string.Empty;

	public string? Name
	{
		get
		{
			return _name;
		}
		private set
		{
			SetValue("Name", ref _name, value);
		}
	}

	public IEnumerable<PCOObject> Items { get; private set; } = Array.Empty<PCOObject>();

	public void FindPlan(string serviceTypeID, string planID, Action<PCOPlan?> callback)
	{
		PCOServiceType serviceType = Items.OfType<PCOServiceType>().Union(Items.OfType<PCOFolder>().SelectMany(GetServiceTypesFromFolder)).FirstOrDefault((PCOServiceType i) => i.ID == serviceTypeID);
		if (serviceType == null)
		{
			callback(null);
			return;
		}
		serviceType.PropertyChanged += serviceTypeChanged;
		serviceType.LoadPlans();
		void serviceTypeChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Plans" && serviceType.Plans != null)
			{
				serviceType.PropertyChanged -= serviceTypeChanged;
				callback(serviceType.Plans.FirstOrDefault((PCOPlan p) => p.ID == planID));
			}
		}
	}

	internal void Reload(string? name, PCOServiceType[] rootServiceTypes, PCOFolder[] folders)
	{
		Name = name;
		Items = ((IEnumerable<PCOObject>)folders).Concat((IEnumerable<PCOObject>)rootServiceTypes);
		OnPropertyChanged("Items");
	}

	internal void Reset()
	{
		Reload(string.Empty, Array.Empty<PCOServiceType>(), Array.Empty<PCOFolder>());
	}

	private IEnumerable<PCOServiceType> GetServiceTypesFromFolder(PCOFolder folder)
	{
		return folder.ServiceTypes.Union(folder.Folders.SelectMany(GetServiceTypesFromFolder));
	}
}
