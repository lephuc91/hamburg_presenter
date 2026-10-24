using Pro.Common.Mathematics;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class ScreenCornerPins
{
	private ScreenPoint? _topLeftPoint;

	private ScreenPoint? _topRightPoint;

	private ScreenPoint? _bottomLeftPoint;

	private ScreenPoint? _bottomRightPoint;

	[Child]
	[Alias("TopLeft", typeof(ScreenPoint), false)]
	public ScreenPoint? TopLeftPoint
	{
		get
		{
			return _topLeftPoint;
		}
		set
		{
			_topLeftPoint = value;
			if (_topLeftPoint != null)
			{
				TopLeft = new Vector2<int>(_topLeftPoint.X, _topLeftPoint.Y);
			}
		}
	}

	public Vector2<int> TopLeft { get; private set; }

	[Child]
	[Alias("TopRight", typeof(ScreenPoint), false)]
	public ScreenPoint? TopRightPoint
	{
		get
		{
			return _topRightPoint;
		}
		set
		{
			_topRightPoint = value;
			if (_topRightPoint != null)
			{
				TopRight = new Vector2<int>(_topRightPoint.X, _topRightPoint.Y);
			}
		}
	}

	public Vector2<int> TopRight { get; private set; }

	[Child]
	[Alias("BottomLeft", typeof(ScreenPoint), false)]
	public ScreenPoint? BottomLeftPoint
	{
		get
		{
			return _bottomLeftPoint;
		}
		set
		{
			_bottomLeftPoint = value;
			if (_bottomLeftPoint != null)
			{
				BottomLeft = new Vector2<int>(_bottomLeftPoint.X, _bottomLeftPoint.Y);
			}
		}
	}

	public Vector2<int> BottomLeft { get; private set; }

	[Child]
	[Alias("BottomRight", typeof(ScreenPoint), false)]
	public ScreenPoint? BottomRightPoint
	{
		get
		{
			return _bottomRightPoint;
		}
		set
		{
			_bottomRightPoint = value;
			if (_bottomRightPoint != null)
			{
				BottomRight = new Vector2<int>(_bottomRightPoint.X, _bottomRightPoint.Y);
			}
		}
	}

	public Vector2<int> BottomRight { get; private set; }
}
