namespace Pro.Editor.Canvas.Snapping.Lines;

public class ElementSL : ISnapLine
{
	private bool _isParent;

	private bool _isHorizontal;

	private bool _isEnabled = true;

	private double _position;

	private SnapEdge _snapEdges = SnapEdge.All;

	private double _nearestEdge;

	private double _farthestEdge;

	public bool IsParent
	{
		get
		{
			return _isParent;
		}
		set
		{
			_isParent = value;
		}
	}

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

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			_isEnabled = value;
		}
	}

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

	public double NearestEdge
	{
		get
		{
			return _nearestEdge;
		}
		set
		{
			_nearestEdge = value;
		}
	}

	public double FarthestEdge
	{
		get
		{
			return _farthestEdge;
		}
		set
		{
			_farthestEdge = value;
		}
	}
}
