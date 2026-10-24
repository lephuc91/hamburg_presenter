using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;

namespace ProPresenter.DO.Props;

public class PropCueCollectionSource : IPropSource
{
	private readonly IPropCueCollection _props;

	public IEnumerable<IPropCue> FlatCollection => _props;

	public IEnumerable<IPropCue>? ActiveCollection { get; set; }

	public IEnumerable<IPropGroup> PropGroups => Enumerable.Empty<IPropGroup>();

	public event NotifyCollectionChangedEventHandler? PropCollectionChanged;

	public event PropertyChangedEventHandler? PropPropertyChanged;

	public PropCueCollectionSource(IPropCueCollection props)
	{
		_props = props;
		_props.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			this.PropCollectionChanged?.Invoke(s, e);
		};
		_props.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			this.PropPropertyChanged?.Invoke(s, e);
		};
	}

	public IPropGroup? CreateGroup(string name, out int index)
	{
		index = -1;
		return null;
	}

	public IPropCue? FindProp(Guid id, string name, Guid parentCollectionID, string parentCollectionName)
	{
		return _props?.FirstOrDefaultBy((IPropCue m) => m.ID == id, (IPropCue m) => m.Name == name);
	}

	public void RemoveGroup(IPropGroup propGroup)
	{
	}

	public void RemoveProp(IPropCue prop)
	{
		_props.UndoStack?.StartIgnoring();
		_props.RemoveProp(prop);
		_props.UndoStack?.StopIgnoring();
	}
}
