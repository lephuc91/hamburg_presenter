using System;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public abstract class TrackerBase : DrawingVisual
{
	protected const double TrackerOffset = 0.0;

	protected const double TrackerSize = 16.0;

	private bool _isVisible = true;

	private bool _isHorizontal = true;

	private double _scale = 1.0;

	private DrawingContext? _dc;

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			if (_isVisible != value)
			{
				_isVisible = value;
				OnTrackerInvalidated();
			}
		}
	}

	protected bool IsHorizontal => _isHorizontal;

	public event Action<TrackerBase>? TrackerInvalidated;

	public void Render(Vector2<double> offset, double scale, bool isHorizontal)
	{
		_isHorizontal = isHorizontal;
		_scale = scale;
		using (_dc = RenderOpen())
		{
			if (IsVisible)
			{
				_dc.PushTransform(new TranslateTransform(offset.X, offset.Y));
				OnRender();
			}
		}
		_dc = null;
	}

	protected abstract void OnRender();

	protected void OnTrackerInvalidated()
	{
		this.TrackerInvalidated?.Invoke(this);
	}

	protected void DrawLine(double position, Brush brush)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		position *= _scale;
		_dc?.DrawLine(new Pen(brush, 1.0), IsHorizontal.Orient(0.0, position), IsHorizontal.Orient(16.0, position));
	}

	protected void DrawLine(Vector2<double> position, Brush brush)
	{
		DrawLine(IsHorizontal ? position.X : position.Y, brush);
	}
}
