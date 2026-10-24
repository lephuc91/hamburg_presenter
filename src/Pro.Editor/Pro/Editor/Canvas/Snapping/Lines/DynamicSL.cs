namespace Pro.Editor.Canvas.Snapping.Lines;

public abstract class DynamicSL : ISnapLine
{
	private bool _isHorizontal;

	private double _position;

	private SnapEdge _snapEdges;

	public bool IsHorizontal
	{
		get
		{
			return _isHorizontal;
		}
		set
		{
			_isHorizontal = value;
		}
	}

	public bool IsEnabled => true;

	public double Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public SnapEdge SnapEdges
	{
		get
		{
			return _snapEdges;
		}
		set
		{
			_snapEdges = value;
		}
	}
}
