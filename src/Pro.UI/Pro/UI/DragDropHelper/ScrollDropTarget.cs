using System;
using System.Windows;
using Pro.Common.Mathematics;
using Pro.Common.Time;

namespace Pro.UI.DragDropHelper;

public class ScrollDropTarget
{
	private readonly FrameworkElement _attachedObject;

	private readonly Clock _clock = new Clock();

	public double TopThreshold { get; set; } = 50.0;

	public double BottomThreshold { get; set; } = 50.0;

	public double LeftThreshold { get; set; } = 50.0;

	public double RightThreshold { get; set; } = 50.0;

	public double ScrollValue { get; set; } = 1000.0;

	public TimeSlice Interval { get; set; } = TimeSlice.FromSeconds(1.0 / 30.0);

	public event Action<double>? ScrollUp;

	public event Action<double>? ScrollDown;

	public event Action<double>? ScrollLeft;

	public event Action<double>? ScrollRight;

	public ScrollDropTarget(FrameworkElement attachedObject)
	{
		_attachedObject = attachedObject;
		DragDrop.AddPreviewDragEnterHandler((DependencyObject)(object)_attachedObject, delegate
		{
			_clock.Restart();
		});
		DragDrop.AddPreviewDragLeaveHandler((DependencyObject)(object)_attachedObject, delegate
		{
			_clock.Restart();
		});
		DragDrop.AddPreviewDragOverHandler((DependencyObject)(object)_attachedObject, OnPreviewDragOver);
	}

	private void OnPreviewDragOver(object? sender, DragEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = (Vector2<double>)e.GetPosition(_attachedObject);
		double num = ScrollValue * _clock.Restart().TotalSeconds;
		if (vector.Y < TopThreshold)
		{
			this.ScrollUp?.Invoke(num * ((TopThreshold - vector.Y) / TopThreshold));
		}
		else if (vector.Y > _attachedObject.ActualHeight - BottomThreshold)
		{
			this.ScrollDown?.Invoke(num * ((_attachedObject.ActualHeight - BottomThreshold - vector.Y).Abs() / BottomThreshold));
		}
		if (vector.X < LeftThreshold)
		{
			this.ScrollLeft?.Invoke(num * ((LeftThreshold - vector.X) / LeftThreshold));
		}
		else if (vector.X > _attachedObject.ActualWidth - RightThreshold)
		{
			this.ScrollRight?.Invoke(num * ((_attachedObject.ActualWidth - RightThreshold - vector.X).Abs() / RightThreshold));
		}
	}
}
