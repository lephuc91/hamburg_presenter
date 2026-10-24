using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;

namespace ProPresenter.DO.Slide.Custom.Elements;

public static class BezierPathMath
{
	[CompilerGenerated]
	private sealed class _003CWalk_003Ed__17 : IEnumerable<Vector2<double>>, IEnumerable, IEnumerator<Vector2<double>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vector2<double> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private BezierPath path;

		public BezierPath _003C_003E3__path;

		private double stepIncrement;

		public double _003C_003E3__stepIncrement;

		private int _003Ci_003E5__2;

		private BezierPoint _003Cp_003E5__3;

		private BezierPoint _003Cnp_003E5__4;

		private double _003Ct_003E5__5;

		Vector2<double> IEnumerator<Vector2<double>>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CWalk_003Ed__17(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cp_003E5__3 = null;
			_003Cnp_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				_003Ct_003E5__5 += stepIncrement;
				goto IL_00d7;
			}
			_003C_003E1__state = -1;
			_003Ci_003E5__2 = 0;
			goto IL_0106;
			IL_00d7:
			if (_003Ct_003E5__5 < 1.0)
			{
				_003C_003E2__current = EvaluateCubicCurve(_003Ct_003E5__5, _003Cp_003E5__3.Position, _003Cp_003E5__3.Q1, _003Cnp_003E5__4.Q0, _003Cnp_003E5__4.Position);
				_003C_003E1__state = 1;
				return true;
			}
			_003Cp_003E5__3 = null;
			_003Cnp_003E5__4 = null;
			_003Ci_003E5__2++;
			goto IL_0106;
			IL_0106:
			if (_003Ci_003E5__2 < path.Points?.Length)
			{
				_003Cp_003E5__3 = path.Points[_003Ci_003E5__2];
				_003Cnp_003E5__4 = path.Points[(_003Ci_003E5__2 + 1) % path.Points.Length];
				_003Ct_003E5__5 = 0.0;
				goto IL_00d7;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<Vector2<double>> IEnumerable<Vector2<double>>.GetEnumerator()
		{
			_003CWalk_003Ed__17 _003CWalk_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CWalk_003Ed__ = this;
			}
			else
			{
				_003CWalk_003Ed__ = new _003CWalk_003Ed__17(0);
			}
			_003CWalk_003Ed__.path = _003C_003E3__path;
			_003CWalk_003Ed__.stepIncrement = _003C_003E3__stepIncrement;
			return _003CWalk_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Vector2<double>>)this).GetEnumerator();
		}
	}

	private const double Epsilon = 1E-12;

	private const double RootLimit = 0.0001;

	private static readonly double CurvatureToggleScale = Kappa.Value * 2.0.Sqrt() / 2.0;

	private const double MiterRatioLimit = 4.0;

	private const double DefaultStepIncrement = 0.125;

	public static Vector2<double> ProjectIntoBoundedLocalSpace(this Vector2<double> point, Rect<double> bounds, Angle<double> rotation)
	{
		Vector2<double> vector = point.ProjectIntoLocalSpace(bounds, rotation);
		return new Vector2<double>(vector.X.IsReal() ? vector.X : 0.0, vector.Y.IsReal() ? vector.Y : 0.0);
	}

	public static Rect<double> CalculateTightBounds(BezierPath path, bool includeFlipAndRotation = true, bool includeStroke = false)
	{
		if (includeStroke && (!path.Stroke.IsEnabled || path.Stroke.StrokeThickness <= 0.0))
		{
			includeStroke = false;
		}
		BezierPoint[] points = path.Points;
		List<Vector2<double>> list = new List<Vector2<double>>();
		double num = path.Stroke.StrokeThickness / 2.0 * 4.0;
		Func<Vector2<double>, Vector2<double>> func = PathToCanvasTransform(path, includeFlipAndRotation);
		list.Capacity = ((points != null) ? (points.Length * 3) : list.Capacity);
		for (int i = 0; i < points?.Length; i++)
		{
			bool flag = path.PathType == BezierPathType.Open && i == 0;
			bool flag2 = path.PathType == BezierPathType.Open && i + 1 == points.Length;
			BezierPoint bezierPoint = points[i];
			BezierPoint bezierPoint2 = points[(i + 1) % points.Length];
			Vector2<double> vector = func(bezierPoint.Position);
			Vector2<double> vector2 = func(bezierPoint.ActiveQ1);
			Vector2<double> vector3 = func(bezierPoint2.ActiveQ0);
			Vector2<double> vector4 = func(bezierPoint2.Position);
			IEnumerable<double> enumerable = null;
			enumerable = ((flag2 || (!bezierPoint.IsCurved && !bezierPoint2.IsCurved)) ? new double[0] : GetDerivativeRoots(vector, vector2, vector3, vector4));
			foreach (double item in enumerable)
			{
				Vector2<double> vector5 = EvaluateCubicCurve(item, vector, vector2, vector3, vector4);
				if (includeStroke)
				{
					double tangentAngle;
					Vector2<double> vector6 = CalculateStrokeOffset(vector5, item + 0.0001, path.Stroke.StrokeThickness, vector, vector2, vector3, vector4, out tangentAngle);
					list.Add(vector5 + vector6);
					list.Add(vector5 - vector6);
				}
				else
				{
					list.Add(vector5);
				}
			}
			if (!flag && !flag2)
			{
				Vector2<double> vector7 = EvaluateCubicCurve(0.0, vector, vector2, vector3, vector4);
				if (includeStroke)
				{
					BezierPoint bezierPoint3 = points[(i - 1).Mod(points.Length)];
					Vector2<double> a = func(bezierPoint3.Position);
					Vector2<double> b = func(bezierPoint3.ActiveQ1);
					Vector2<double> c = func(bezierPoint.ActiveQ0);
					Vector2<double> d = func(bezierPoint.Position);
					double tangentAngle2;
					Vector2<double> vector8 = CalculateStrokeOffset(vector7, 0.0001, path.Stroke.StrokeThickness, vector, vector2, vector3, vector4, out tangentAngle2);
					double tangentAngle3;
					Vector2<double> vector9 = CalculateStrokeOffset(vector7, 0.9999, path.Stroke.StrokeThickness, a, b, c, d, out tangentAngle3);
					Vector2<double> p = vector7 + vector8;
					Vector2<double> p2 = vector7 - vector8;
					Vector2<double> p3 = vector7 - vector9;
					Vector2<double> p4 = vector7 + vector9;
					Line<double> line = new Line<double>(p, new Angle<double>(tangentAngle2));
					Line<double> line2 = new Line<double>(p2, new Angle<double>(tangentAngle2));
					Line<double> b2 = new Line<double>(p3, new Angle<double>(tangentAngle3));
					Line<double> b3 = new Line<double>(p4, new Angle<double>(tangentAngle3));
					Vector2<double> intersection;
					bool num2 = line.Intersects(b2, out intersection);
					Vector2<double> intersection2;
					bool flag3 = line2.Intersects(b3, out intersection2);
					bool flag4 = num2 && flag3;
					if (flag4 && vector7.Distance(intersection) <= num)
					{
						list.Add(intersection);
						list.Add(intersection2);
					}
					else
					{
						double num3 = (flag4 ? intersection.Angle(vector7) : tangentAngle2);
						double num4 = (flag4 ? intersection2.Angle(vector7) : (tangentAngle2 + 180.0));
						Line<double> a2 = new Line<double>(vector7.Project(num, num3), new Angle<double>(num3 + 90.0));
						Line<double> a3 = new Line<double>(vector7.Project(num, num4), new Angle<double>(num4 + 90.0));
						if (a2.Intersects(line, out var intersection3) && a2.Intersects(b2, out var intersection4))
						{
							list.Add(intersection3);
							list.Add(intersection4);
						}
						if (a3.Intersects(line2, out var intersection5) && a3.Intersects(b3, out var intersection6))
						{
							list.Add(intersection5);
							list.Add(intersection6);
						}
					}
				}
				list.Add(vector7);
				continue;
			}
			Vector2<double> vector10 = EvaluateCubicCurve(0.0, vector, vector2, vector3, vector4);
			if (!includeStroke)
			{
				list.Add(vector10);
				continue;
			}
			double limitRoot = 0.0001;
			Vector2<double> a4 = vector;
			Vector2<double> b4 = vector2;
			Vector2<double> c2 = vector3;
			Vector2<double> d2 = vector4;
			if (flag2)
			{
				BezierPoint bezierPoint4 = points[(i - 1).Mod(points.Length)];
				limitRoot = 0.9999;
				a4 = func(bezierPoint4.Position);
				b4 = func(bezierPoint4.ActiveQ1);
				c2 = func(bezierPoint.ActiveQ0);
				d2 = func(bezierPoint.Position);
			}
			double tangentAngle4;
			Vector2<double> vector11 = CalculateStrokeOffset(vector10, limitRoot, path.Stroke.StrokeThickness, a4, b4, c2, d2, out tangentAngle4);
			list.Add(vector10 + vector11);
			list.Add(vector10 - vector11);
		}
		return list.GetBoundingBox();
	}

	private static Vector2<double> CalculateStrokeOffset(Vector2<double> edgePoint, double limitRoot, double strokeThickness, Vector2<double> a, Vector2<double> b, Vector2<double> c, Vector2<double> d, out double tangentAngle)
	{
		Vector2<double> a2 = EvaluateCubicCurve(limitRoot, a, b, c, d);
		tangentAngle = a2.Angle(edgePoint);
		return Vector2<double>.Zero.Project(strokeThickness / 2.0, tangentAngle + 90.0);
	}

	public static bool Intersects(BezierPath path, Rect<double> rect)
	{
		if (rect.Contains(path.SnapBounds))
		{
			return true;
		}
		if (!rect.Intersects(path.SnapBounds))
		{
			return false;
		}
		if (!Intersects(path, rect.TopEdge) && !Intersects(path, rect.LeftEdge) && !Intersects(path, rect.RightEdge))
		{
			return Intersects(path, rect.BottomEdge);
		}
		return true;
	}

	private static bool Intersects(BezierPath path, LineSegment<double> line)
	{
		BezierPoint[] points = path.Points;
		Func<Vector2<double>, Vector2<double>> func = PathToCanvasTransform(path, includeFlipAndRotation: true);
		int pointIterationCount = GetPointIterationCount(path);
		for (int i = 0; i < pointIterationCount; i++)
		{
			if (points != null)
			{
				BezierPoint bezierPoint = points[i];
				BezierPoint bezierPoint2 = points[(i + 1) % points.Length];
				Vector2<double> position = func(bezierPoint.Position);
				Vector2<double> controlpoint = func(bezierPoint.ActiveQ1);
				Vector2<double> controlpoint2 = func(bezierPoint2.ActiveQ0);
				Vector2<double> position2 = func(bezierPoint2.Position);
				if (Intersects(position, controlpoint, controlpoint2, position2, line))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static Func<Vector2<double>, Vector2<double>> PathToCanvasTransform(BezierPath path, bool includeFlipAndRotation)
	{
		Rect<double> bounds = new Rect<double>(path.Position, path.Size);
		if (!includeFlipAndRotation)
		{
			return (Vector2<double> point) => point.ComponentwiseProduct(bounds.Size) + bounds.Position;
		}
		Vector2<double> scale = new Vector2<double>(path.FlipMode.HasFlag(ElementFlipMode.Horizontal) ? (-1.0) : 1.0, path.FlipMode.HasFlag(ElementFlipMode.Vertical) ? (-1.0) : 1.0);
		Vector2<double> scale2 = bounds.Size.ComponentwiseProduct(scale);
		Vector2<double> translate = bounds.Center - scale2 / 2.0;
		double rotation = path.Rotation.InvertedCartesianValue;
		return (Vector2<double> point) => (point.ComponentwiseProduct(scale2) + translate).Rotate(bounds.Center, rotation);
	}

	public static void NormalizeBounds(BezierPath path)
	{
		BezierPoint[] points = path.Points;
		if (points != null && points.Length <= 1)
		{
			return;
		}
		Rect<double> oldBounds = new Rect<double>(path.Position, path.Size);
		Rect<double> newBounds = CalculateTightBounds(path, includeFlipAndRotation: false);
		Angle<double> rotation = path.Rotation;
		Func<Vector2<double>, Rect<double>, Vector2<double>> toWorldSpace = (Vector2<double> point, Rect<double> bounds) => point.ProjectIntoWorldSpace(bounds, Angle<double>.Zero);
		Func<Vector2<double>, Rect<double>, Vector2<double>> toLocalSpace = (Vector2<double> point, Rect<double> bounds) => point.ProjectIntoBoundedLocalSpace(bounds, Angle<double>.Zero);
		Func<Vector2<double>, Vector2<double>> func = (Vector2<double> point) => toLocalSpace(toWorldSpace(point, oldBounds), newBounds);
		if (path.Points != null)
		{
			BezierPoint[] points2 = path.Points;
			foreach (BezierPoint bezierPoint in points2)
			{
				bezierPoint.Position = func(bezierPoint.Position);
				bezierPoint.Q0 = func(bezierPoint.Q0);
				bezierPoint.Q1 = func(bezierPoint.Q1);
			}
		}
		Vector2<double> vector = Vector2<double>.Zero.Rotate(oldBounds.Center, rotation.InvertedCartesianValue);
		Vector2<double> vector2 = Vector2<double>.Zero.Rotate(newBounds.Center, rotation.InvertedCartesianValue) - vector;
		Vector2<double> vector3 = newBounds.Position - oldBounds.Position;
		Vector2<double> vector4 = oldBounds.Size - newBounds.Size;
		if (path.FlipMode.HasFlag(ElementFlipMode.Vertical))
		{
			if (vector3.Y == vector4.Y)
			{
				vector3.Y = 0.0;
			}
			else
			{
				vector3.Y = vector4.Y - vector3.Y;
			}
			vector2 = vector2.Rotate(Vector2<double>.Zero, 0.0 - rotation.InvertedCartesianValue);
			vector2.X = 0.0 - vector2.X;
		}
		if (path.FlipMode.HasFlag(ElementFlipMode.Horizontal))
		{
			if (vector3.X == vector4.X)
			{
				vector3.X = 0.0;
			}
			else
			{
				vector3.X = vector4.X - vector3.X;
			}
			vector2 = vector2.Rotate(Vector2<double>.Zero, 0.0 - rotation.InvertedCartesianValue);
			vector2.Y = 0.0 - vector2.Y;
		}
		path.Position = path.Position + vector3 - vector2;
		path.Size = newBounds.Size;
	}

	public static void ToggleBezierPoint(BezierPoint point, BezierPath path)
	{
		point.IsCurved = !point.IsCurved;
		if (!point.IsCurved)
		{
			return;
		}
		int num = path.Points.IndexOf(point);
		Rect<double> elementBounds = new Rect<double>(path.Position, path.Size);
		Func<Vector2<double>, Vector2<double>> func = (Vector2<double> p) => p.ProjectIntoBoundedLocalSpace(elementBounds, path.Rotation);
		Func<Vector2<double>, Vector2<double>> obj = (Vector2<double> p) => p.ProjectIntoWorldSpace(elementBounds, path.Rotation);
		BezierPoint bezierPoint = path.Points[(num - 1).Mod(path.Points.Length)];
		BezierPoint bezierPoint2 = path.Points[(num + 1).Mod(path.Points.Length)];
		if (path.PathType == BezierPathType.Open)
		{
			if (num + 1 >= path.Points.Length)
			{
				bezierPoint2 = bezierPoint;
			}
			else if (num - 1 < 0)
			{
				bezierPoint = bezierPoint2;
			}
		}
		Vector2<double> vector = obj(point.Position);
		Vector2<double> a = obj(bezierPoint.Position);
		Vector2<double> vector2 = obj(bezierPoint2.Position);
		double num2 = a.Distance(vector);
		double num3 = vector2.Distance(vector);
		Vector2<double> b = a.Midpoint(vector2);
		LineSegment<double> line = new LineSegment<double>(vector, b);
		double a2 = vector.Angle(b) + 90.0;
		int num4 = ((!vector2.RightSide(line)) ? 1 : (-1));
		point.Q0 = func(vector + num4 * new Vector2<double>(num2 * CurvatureToggleScale, 0.0).Rotate(Vector2<double>.Zero, a2));
		point.Q1 = func(vector - num4 * new Vector2<double>(num3 * CurvatureToggleScale, 0.0).Rotate(Vector2<double>.Zero, a2));
	}

	public static BezierPoint SplitCurve(BezierPoint startPoint, BezierPoint endPoint, double t)
	{
		Vector2<double> position = EvaluateCubicCurve(t, startPoint.Position, startPoint.ActiveQ1, endPoint.ActiveQ0, endPoint.Position);
		Func<Vector2<double>, Vector2<double>, Vector2<double>> func = (Vector2<double> a, Vector2<double> b) => (a + b) * t;
		Vector2<double> vector = func(startPoint.Position, startPoint.Q1);
		Vector2<double> vector2 = func(startPoint.Q1, endPoint.Q0);
		Vector2<double> vector3 = func(endPoint.Position, endPoint.Q0);
		startPoint.Q1 = vector;
		endPoint.Q0 = vector3;
		return new BezierPoint
		{
			Position = position,
			IsCurved = (startPoint.IsCurved || endPoint.IsCurved),
			Q0 = func(vector, vector2),
			Q1 = func(vector2, vector3)
		};
	}

	private static Vector2<double>[] GetBezierComponents(Vector2<double> a, Vector2<double> b, Vector2<double> c, Vector2<double> d)
	{
		double[] bezierComponents = GetBezierComponents(a.X, b.X, c.X, d.X);
		double[] bezierComponents2 = GetBezierComponents(a.Y, b.Y, c.Y, d.Y);
		return new Vector2<double>[4]
		{
			new Vector2<double>(bezierComponents[0], bezierComponents2[0]),
			new Vector2<double>(bezierComponents[1], bezierComponents2[1]),
			new Vector2<double>(bezierComponents[2], bezierComponents2[2]),
			new Vector2<double>(bezierComponents[3], bezierComponents2[3])
		};
	}

	private static double[] GetBezierComponents(double a, double b, double c, double d)
	{
		return new double[4]
		{
			0.0 - a + 3.0 * b - 3.0 * c + d,
			3.0 * a - 6.0 * b + 3.0 * c,
			-3.0 * a + 3.0 * b,
			a
		};
	}

	private static bool Intersects(Vector2<double> position1, Vector2<double> controlpoint1, Vector2<double> controlpoint2, Vector2<double> position2, LineSegment<double> line)
	{
		Vector2<double> a = new Vector2<double>(line.B.Y - line.A.Y, line.A.X - line.B.X);
		double num = line.A.X * (line.A.Y - line.B.Y) + line.A.Y * (line.B.X - line.A.X);
		Vector2<double>[] bezierComponents = GetBezierComponents(position1, controlpoint1, controlpoint2, position2);
		double a2 = a.DotProduct(bezierComponents[0]);
		double b = a.DotProduct(bezierComponents[1]);
		double c = a.DotProduct(bezierComponents[2]);
		double d = a.DotProduct(bezierComponents[3]) + num;
		foreach (double item in from t in GetCubicRoots(a2, b, c, d)
			where t.IsInRangeInclusive(0.0, 1.0)
			select t)
		{
			Vector2<double> vector = bezierComponents[0] * item.Cubed() + bezierComponents[1] * item.Squared() + bezierComponents[2] * item + bezierComponents[3];
			if (((line.B.X - line.A.X != 0.0) ? ((vector.X - line.A.X) / (line.B.X - line.A.X)) : ((vector.Y - line.A.Y) / (line.B.Y - line.A.Y))).IsInRangeInclusive(0.0, 1.0))
			{
				return true;
			}
		}
		return false;
	}

	[IteratorStateMachine(typeof(_003CWalk_003Ed__17))]
	public static IEnumerable<Vector2<double>> Walk(BezierPath path, double stepIncrement = 0.125)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CWalk_003Ed__17(-2)
		{
			_003C_003E3__path = path,
			_003C_003E3__stepIncrement = stepIncrement
		};
	}

	public static bool IsPointInShape(Vector2<double> l, BezierPath path, double stepIncrement = 0.125)
	{
		bool flag = false;
		Vector2<double>[] array = Walk(path, stepIncrement).ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Vector2<double> vector = array[i];
			Vector2<double> vector2 = array[(i + 1) % array.Length];
			if (vector.Y > l.Y != vector2.Y > l.Y && l.X < vector.X + (vector2.X - vector.X) * (l.Y - vector.Y) / (vector2.Y - vector.Y))
			{
				flag = !flag;
			}
		}
		return flag;
	}

	public static double EvaluateCubicCurve(double t, double pa, double pb, double pc, double pd)
	{
		if (t == 0.0)
		{
			return pa;
		}
		if (t == 1.0)
		{
			return pd;
		}
		return pa * (1.0 - t).Cubed() + pb * 3.0 * t * (1.0 - t).Squared() + pc * 3.0 * t.Squared() * (1.0 - t) + pd * t.Cubed();
	}

	public static Vector2<double> EvaluateCubicCurve(double t, Vector2<double> pa, Vector2<double> pb, Vector2<double> pc, Vector2<double> pd)
	{
		return new Vector2<double>(EvaluateCubicCurve(t, pa.X, pb.X, pc.X, pd.X), EvaluateCubicCurve(t, pa.Y, pb.Y, pc.Y, pd.Y));
	}

	private static IEnumerable<double> GetDerivativeRoots(Vector2<double> pa, Vector2<double> pb, Vector2<double> pc, Vector2<double> pd)
	{
		return GetDerivativeRoots(pa.X, pb.X, pc.X, pd.X).Concat(GetDerivativeRoots(pa.Y, pb.Y, pc.Y, pd.Y));
	}

	private static IEnumerable<double> GetDerivativeRoots(double pa, double pb, double pc, double pd)
	{
		double[] array = null;
		double num = -3.0 * pa + 9.0 * pb - 9.0 * pc + 3.0 * pd;
		double num2 = 6.0 * pa - 12.0 * pb + 6.0 * pc;
		double num3 = 3.0 * pb - 3.0 * pa;
		if (Math.Abs(num) < 1E-12)
		{
			if (Math.Abs(num2) > 1E-12)
			{
				array = new double[1] { (0.0 - num3) / num2 };
			}
		}
		else
		{
			double num4 = num2 * num2 - 4.0 * num3 * num;
			if (num4 > 0.0)
			{
				double num5 = Math.Sqrt(num4);
				array = new double[2]
				{
					(0.0 - num2 + num5) / (2.0 * num),
					(0.0 - num2 - num5) / (2.0 * num)
				};
			}
		}
		return array?.Where((double t) => t > 1E-12 && t < 0.999999999999) ?? new double[0];
	}

	private static double[] GetCubicRoots(double a, double b, double c, double d)
	{
		double num = b / a;
		double num2 = c / a;
		double num3 = d / a;
		double num4 = num / 3.0;
		double num5 = (3.0 * num2 - num.Squared()) / 9.0;
		double num6 = (9.0 * num * num2 - 27.0 * num3 - 2.0 * num.Cubed()) / 54.0;
		double num7 = num5.Cubed() + num6.Squared();
		if (num7 >= 0.0)
		{
			double num8 = num7.Sqrt();
			double num9 = (num6 + num8).Cbrt();
			double num10 = (num6 - num8).Cbrt();
			bool num11 = (3.0.Sqrt() * (num9 - num10) / 2.0).Abs() != 0.0;
			double num12 = 0.0 - num4 + (num9 + num10);
			double num13 = 0.0 - num4 - (num9 + num10) / 2.0;
			if (num11)
			{
				return new double[1] { num12 };
			}
			return new double[2] { num12, num13 };
		}
		double num14 = Math.Acos(num6 / (0.0 - num5.Cubed()).Sqrt());
		double num15 = 2.0 * (0.0 - num5).Sqrt();
		return new double[3]
		{
			num15 * Math.Cos(num14 / 3.0) - num4,
			num15 * Math.Cos((num14 + Math.PI * 2.0) / 3.0) - num4,
			num15 * Math.Cos((num14 + Math.PI * 4.0) / 3.0) - num4
		};
	}

	private static int GetPointIterationCount(BezierPath path)
	{
		return (path.Points?.Length - ((path.PathType == BezierPathType.Open) ? 1 : 0)).GetValueOrDefault();
	}
}
