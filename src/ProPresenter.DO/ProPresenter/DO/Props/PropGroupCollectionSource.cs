using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;

namespace ProPresenter.DO.Props;

public class PropGroupCollectionSource : IPropSource
{
	private readonly IPropGroupCollection _propsGroups;

	public IEnumerable<IPropCue> FlatCollection => _propsGroups.SelectMany((IPropGroup g) => g);

	public IEnumerable<IPropCue>? ActiveCollection { get; set; }

	public IEnumerable<IPropGroup> PropGroups => _propsGroups;

	public event NotifyCollectionChangedEventHandler? PropCollectionChanged;

	public event PropertyChangedEventHandler? PropPropertyChanged;

	public PropGroupCollectionSource(IPropGroupCollection props)
	{
		_propsGroups = props;
		_propsGroups.ForEach(delegate(IPropGroup g)
		{
			g.CollectionChanged += PropGroups_CollectionChanged;
			g.ForEach(delegate(IPropCue c)
			{
				c.PropertyChanged += Prop_PropertyChanged;
			});
		});
		_propsGroups.CollectionChanged += PropGroups_CollectionChanged;
	}

	public void RemoveProp(IPropCue prop)
	{
		IPropGroup propGroup = _propsGroups.FirstOrDefault((IPropGroup g) => g.Contains(prop));
		if (propGroup != null)
		{
			propGroup.UndoStack?.StartIgnoring();
			propGroup.RemoveProp(prop);
			propGroup.UndoStack?.StopIgnoring();
		}
	}

	public IPropCue? FindProp(Guid id, string name, Guid parentCollectionID, string parentCollectionName)
	{
		return _propsGroups.FirstOrDefaultBy((IPropGroup g) => g.ID == parentCollectionID, (IPropGroup g) => g.Name == parentCollectionName)?.FirstOrDefaultBy((IPropCue p) => p.ID == id, (IPropCue p) => p.Name == name) ?? _propsGroups.SelectMany((IPropGroup g) => g).FirstOrDefaultBy((IPropCue p) => p.ID == id, (IPropCue p) => p.Name == name);
	}

	public IPropGroup? CreateGroup(string name, out int index)
	{
		_propsGroups.UndoStack?.StartIgnoring();
		IPropGroup propGroup = _propsGroups.AddGroup();
		propGroup.Name = name;
		index = ((IImmutableObservableCollection<IPropGroup>)_propsGroups).IndexOf(propGroup);
		_propsGroups.UndoStack?.StopIgnoring();
		return propGroup;
	}

	public void RemoveGroup(IPropGroup propGroup)
	{
		_propsGroups.UndoStack?.StartIgnoring();
		_propsGroups.RemoveGroup(propGroup);
		_propsGroups.UndoStack?.StopIgnoring();
	}

	private void PropGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IPropGroup>().ForEach(delegate(IPropGroup g)
		{
			g.CollectionChanged -= PropGroup_CollectionChanged;
			g.ForEach(delegate(IPropCue c)
			{
				c.PropertyChanged -= Prop_PropertyChanged;
			});
		});
		e.NewItems?.OfType<IPropGroup>().ForEach(delegate(IPropGroup g)
		{
			g.CollectionChanged += PropGroup_CollectionChanged;
			g.ForEach(delegate(IPropCue c)
			{
				c.PropertyChanged += Prop_PropertyChanged;
			});
		});
	}

	private void PropGroup_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IPropCue>().ForEach(delegate(IPropCue c)
		{
			c.PropertyChanged -= Prop_PropertyChanged;
		});
		e.NewItems?.OfType<IPropCue>().ForEach(delegate(IPropCue c)
		{
			c.PropertyChanged += Prop_PropertyChanged;
		});
		this.PropCollectionChanged?.Invoke(sender, e);
	}

	private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		this.PropPropertyChanged?.Invoke(sender, e);
	}
}
