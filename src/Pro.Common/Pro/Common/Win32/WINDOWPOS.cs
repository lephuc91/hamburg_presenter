namespace Pro.Common.Win32;

public struct WINDOWPOS
{
	private nint _hwnd;

	private nint _hwndInsertAfter;

	private int _x;

	private int _y;

	private int _cx;

	private int _cy;

	private SWP _flags;

	public nint Hwnd
	{
		get
		{
			return _hwnd;
		}
		set
		{
			_hwnd = value;
		}
	}

	public nint HwndInsertAfter
	{
		get
		{
			return _hwndInsertAfter;
		}
		set
		{
			_hwndInsertAfter = value;
		}
	}

	public int X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public int Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public int CX
	{
		get
		{
			return _cx;
		}
		set
		{
			_cx = value;
		}
	}

	public int CY
	{
		get
		{
			return _cy;
		}
		set
		{
			_cy = value;
		}
	}

	public SWP Flags
	{
		get
		{
			return _flags;
		}
		set
		{
			_flags = value;
		}
	}
}
