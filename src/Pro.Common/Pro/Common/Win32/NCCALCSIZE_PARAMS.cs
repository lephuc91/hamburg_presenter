namespace Pro.Common.Win32;

public struct NCCALCSIZE_PARAMS
{
	private RECT _finalRect;

	private RECT _sourceRect;

	private RECT _targetRect;

	private nint _lppos;

	public RECT FinalRect
	{
		get
		{
			return _finalRect;
		}
		set
		{
			_finalRect = value;
		}
	}

	public RECT SourceRect
	{
		get
		{
			return _sourceRect;
		}
		set
		{
			_sourceRect = value;
		}
	}

	public RECT TargetRect
	{
		get
		{
			return _targetRect;
		}
		set
		{
			_targetRect = value;
		}
	}
}
