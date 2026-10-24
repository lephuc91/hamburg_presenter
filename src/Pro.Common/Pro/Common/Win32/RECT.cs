namespace Pro.Common.Win32;

public struct RECT
{
	private int _left;

	private int _top;

	private int _right;

	private int _bottom;

	public int Left
	{
		get
		{
			return _left;
		}
		set
		{
			_left = value;
		}
	}

	public int Top
	{
		get
		{
			return _top;
		}
		set
		{
			_top = value;
		}
	}

	public int Right
	{
		get
		{
			return _right;
		}
		set
		{
			_right = value;
		}
	}

	public int Bottom
	{
		get
		{
			return _bottom;
		}
		set
		{
			_bottom = value;
		}
	}

	public int Width => _right - _left;

	public int Height => _bottom - _top;
}
