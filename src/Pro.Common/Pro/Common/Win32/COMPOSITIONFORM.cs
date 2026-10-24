namespace Pro.Common.Win32;

public struct COMPOSITIONFORM
{
	private CFS _dwStyle;

	private POINT _ptCurrentPos;

	private RECT _rcArea;

	public CFS DwStyle
	{
		get
		{
			return _dwStyle;
		}
		set
		{
			_dwStyle = value;
		}
	}

	public POINT PtCurrentPos
	{
		get
		{
			return _ptCurrentPos;
		}
		set
		{
			_ptCurrentPos = value;
		}
	}

	public RECT RcArea
	{
		get
		{
			return _rcArea;
		}
		set
		{
			_rcArea = value;
		}
	}

	public COMPOSITIONFORM(CFS dwStyle, POINT ptCurrentPos, RECT rcArea)
	{
		_dwStyle = dwStyle;
		_ptCurrentPos = ptCurrentPos;
		_rcArea = rcArea;
	}
}
