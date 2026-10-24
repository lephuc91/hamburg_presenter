using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.Handles;

public class BezierControlPointHandle : BezierPointHandle
{
	private const double HandleRadius = 4.0;

	private const double HandleEdgeThickness = 1.0;

	private const double MirrorAngle = 180.0;

	private static readonly Brush FillBrush = Brushes.White;

	private static readonly Pen BorderPen = new Pen(Brushes.Gray, 1.0);

	private BezierControlPointType _controlPointType;

	public override bool CanSelect => false;

	internal bool IsQ0 => _controlPointType == BezierControlPointType.Q0;

	internal bool AngleToggle { get; set; }

	internal bool DistanceToggle { get; set; }

	private Vector2<double> ControlPoint
	{
		get
		{
			if (!IsQ0)
			{
				return base.Point.Q1;
			}
			return base.Point.Q0;
		}
		set
		{
			if (IsQ0)
			{
				base.Point.Q0 = value;
			}
			else
			{
				base.Point.Q1 = value;
			}
		}
	}

	private Vector2<double> OppositeControlPoint
	{
		get
		{
			if (!IsQ0)
			{
				return base.Point.Q0;
			}
			return base.Point.Q1;
		}
		set
		{
			if (IsQ0)
			{
				base.Point.Q1 = value;
			}
			else
			{
				base.Point.Q0 = value;
			}
		}
	}

	public BezierControlPointHandle(BezierPath element, BezierPoint point, BezierHandleSetProvider set, BezierControlPointType controlPointType)
		: base(element, point, set)
	{
		_controlPointType = controlPointType;
	}

	protected override void MovePoint(Vector2<double> delta)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		MoveControlPoints(Keyboard.Modifiers, delta);
	}

	protected override void OnDragEnded()
	{
		AngleToggle = false;
		DistanceToggle = false;
		base.OnDragEnded();
	}

	protected override void OnRenderHandle(DrawingContext dc)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (base.Point.IsCurved)
		{
			dc.DrawEllipse(FillBrush, BorderPen, Vector2<double>.Zero, 4.0, 4.0);
		}
	}

	protected override void OnUpdateLocation()
	{
		UpdateLocation(ControlPoint);
	}

	protected override bool DidHandleMove(PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "Q0" || propertyName == "Q1")
		{
			return true;
		}
		return base.DidHandleMove(e);
	}

	private void MoveControlPoints(ModifierKeys modifiers, Vector2<double> delta)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		ControlPoint -= delta;
		bool flag = (((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)2) ? (!DistanceToggle) : DistanceToggle);
		bool flag2 = (((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)4) ? (!AngleToggle) : AngleToggle);
		if (flag2 || flag)
		{
			if (flag2 && flag)
			{
				OppositeControlPoint = ControlPoint.Rotate(base.Point.Position, 180.0);
				return;
			}
			Vector2<double> vector = ControlPoint.ProjectIntoWorldSpace(base.ElementBounds, Angle<double>.Zero);
			Vector2<double> a = OppositeControlPoint.ProjectIntoWorldSpace(base.ElementBounds, Angle<double>.Zero);
			Vector2<double> vector2 = base.Point.Position.ProjectIntoWorldSpace(base.ElementBounds, Angle<double>.Zero);
			double num = (flag2 ? a.Distance(vector2) : vector.Distance(vector2));
			double a2 = (flag2 ? vector2.Angle(vector) : a.Angle(vector2));
			OppositeControlPoint = new Vector2<double>(num + vector2.X, vector2.Y).Rotate(vector2, a2).ProjectIntoBoundedLocalSpace(base.ElementBounds, Angle<double>.Zero);
		}
	}
}
