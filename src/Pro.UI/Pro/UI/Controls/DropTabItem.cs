using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Time;

namespace Pro.UI.Controls;

public class DropTabItem : TabItem
{
	private static readonly TimeSlice DragOverThreshold = TimeSlice.FromSeconds(SystemParameters.MouseHoverTime.TotalSeconds);

	private readonly DispatcherTimer _dragOverTimer = new DispatcherTimer
	{
		Interval = DragOverThreshold
	};

	private readonly List<Type> _disAllowedDropTypes = new List<Type>();

	public DropTabItem()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		base.AllowDrop = true;
		DragDrop.AddDragEnterHandler((DependencyObject)(object)this, OnDragEnter);
		DragDrop.AddDragLeaveHandler((DependencyObject)(object)this, OnDragLeave);
		_dragOverTimer.Tick += delegate
		{
			((DependencyObject)this).SetCurrentValue(TabItem.IsSelectedProperty, (object)true);
			_dragOverTimer.Stop();
		};
	}

	private void OnDragLeave(object? sender, DragEventArgs e)
	{
		_dragOverTimer.Stop();
	}

	private void OnDragEnter(object? sender, DragEventArgs e)
	{
		if (!_disAllowedDropTypes.Select((Type t) => e.Data.GetData(t)).NonNull().Any())
		{
			_dragOverTimer.Start();
		}
	}

	public void AddDisallowDropTypes(Type type)
	{
		if (!_disAllowedDropTypes.Contains(type))
		{
			_disAllowedDropTypes.Add(type);
		}
	}
}
