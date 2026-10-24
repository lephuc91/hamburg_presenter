namespace Pro.Common.Win32;

public struct CANDIDATEFORM
{
	private uint _dwIndex;

	private CFS _dwStyle;

	private POINT _ptCurrentPos;

	private RECT _rcArea;

	public uint DwIndex
	{
		get
		{
			return _dwIndex;
		}
		set
		{
			_dwIndex = value;
		}
	}

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

	public CANDIDATEFORM(uint dwIndex, CFS dwStyle, POINT ptCurrentPos, RECT rcArea)
	{
		_dwIndex = dwIndex;
		_dwStyle = dwStyle;
		_ptCurrentPos = ptCurrentPos;
		_rcArea = rcArea;
	}
}
