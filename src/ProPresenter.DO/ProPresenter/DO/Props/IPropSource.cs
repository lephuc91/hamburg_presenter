using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ProPresenter.DO.Props;

public interface IPropSource
{
	IEnumerable<IPropCue> FlatCollection { get; }

	IEnumerable<IPropCue>? ActiveCollection { get; set; }

	IEnumerable<IPropGroup> PropGroups { get; }

	event NotifyCollectionChangedEventHandler? PropCollectionChanged;

	event PropertyChangedEventHandler? PropPropertyChanged;

	IPropCue? FindProp(Guid id, string name, Guid parentCollectionID, string parentCollectionName);

	void RemoveProp(IPropCue prop);

	IPropGroup? CreateGroup(string name, out int index);

	void RemoveGroup(IPropGroup propGroup);
}
