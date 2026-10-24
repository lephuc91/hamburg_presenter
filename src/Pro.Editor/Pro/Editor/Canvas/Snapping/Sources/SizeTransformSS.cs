using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Transforming;

namespace Pro.Editor.Canvas.Snapping.Sources;

public class SizeTransformSS : ElementSS
{
	private HandleLocation _handleLocation;

	private bool _allowHorizontalSnap = true;

	private bool _allowVerticalSnap = true;

	public HandleLocation HandleLocation
	{
		get
		{
			return _handleLocation;
		}
		set
		{
			if (_handleLocation != value)
			{
				_handleLocation = value;
				InvaldiateSnapLines();
			}
		}
	}

	public bool AllowHorizontalSnap
	{
		get
		{
			return _allowHorizontalSnap;
		}
		set
		{
			if (_allowHorizontalSnap != value)
			{
				_allowHorizontalSnap = value;
				InvaldiateSnapLines();
			}
		}
	}

	public bool AllowVerticalSnap
	{
		get
		{
			return _allowVerticalSnap;
		}
		set
		{
			if (_allowVerticalSnap != value)
			{
				_allowVerticalSnap = value;
				InvaldiateSnapLines();
			}
		}
	}

	public SizeTransformSS(ICanvasElement sourceElement, HandleLocation handleLocation)
		: base(sourceElement)
	{
		_handleLocation = handleLocation;
		base.HorizontalLines[0].SnapEdges = SnapEdge.Near;
		base.HorizontalLines[1].SnapEdges = SnapEdge.Center;
		base.HorizontalLines[2].SnapEdges = SnapEdge.Far;
		base.VerticalLines[0].SnapEdges = SnapEdge.Near;
		base.VerticalLines[1].SnapEdges = SnapEdge.Center;
		base.VerticalLines[2].SnapEdges = SnapEdge.Far;
	}

	protected override void OnCalculateLines()
	{
		base.OnCalculateLines();
		double invertedCartesianValue = base.Element.GetGlobalRotation().InvertedCartesianValue;
		bool flag = invertedCartesianValue % 90.0 == 0.0;
		int num = (int)(invertedCartesianValue / 90.0).Mod(4.0);
		HandleLocation location = (flag ? HandleLocation.GetNextHandle(num * 2) : HandleLocation);
		Vector2<double> point = base.Element.Size;
		if (num % 2 != 0)
		{
			point = point.Reflect();
		}
		bool flag2 = point.Y < 0.0;
		bool flag3 = point.X < 0.0;
		base.HorizontalLines[flag2 ? 2 : 0].IsEnabled = AllowHorizontalSnap && flag && location.IsTop();
		base.HorizontalLines[(!flag2) ? 2 : 0].IsEnabled = AllowHorizontalSnap && flag && !location.IsTop() && location.AdjustsHeight();
		base.VerticalLines[flag3 ? 2 : 0].IsEnabled = AllowVerticalSnap && flag && location.IsLeft();
		base.VerticalLines[(!flag3) ? 2 : 0].IsEnabled = AllowVerticalSnap && flag && !location.IsLeft() && location.AdjustsWidth();
		base.HorizontalLines[1].IsEnabled = false;
		base.VerticalLines[1].IsEnabled = false;
	}
}
