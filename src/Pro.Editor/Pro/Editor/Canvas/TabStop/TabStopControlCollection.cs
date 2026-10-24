using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.TabStop;

public class TabStopControlCollection : ImmutableObservableCollection<TabStopControlBase>
{
	public virtual bool IsEditing { get; }

	public event Action? VisualInvalidated;

	public TabStopControlCollection()
	{
		base.CollectionChanged += delegate
		{
			OnVisualInvalidated();
		};
	}

	public virtual void ChangeTabStopType(TabStopControlBase tabStopControl)
	{
	}

	public virtual void AddTabStop(Vector2<double> mousePosition)
	{
	}

	public void AddTabStop(TabStopControlBase tabStop)
	{
		AddTabStops(tabStop.ToEnumerable());
	}

	public void AddTabStops(IEnumerable<TabStopControlBase> tabStops)
	{
		base.Collection.AddRange(tabStops);
	}

	public void RemoveTabStop(TabStopControlBase tabStop)
	{
		RemoveTabStops(tabStop.ToEnumerable());
	}

	public void RemoveTabStops(IEnumerable<TabStopControlBase> tabStops)
	{
		base.Collection.RemoveRange(tabStops);
	}

	public void Clear()
	{
		RemoveTabStops(base.Collection.ToArray());
	}

	public virtual void RemoveTabStopData(TabStopControlBase tabStop)
	{
	}

	protected void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}
}
