namespace Pro.Common.Win32;

public struct CWPRETSTRUCT
{
	private nint _lResult;

	private nint _lParam;

	private nint _wParam;

	private WM _message;

	private nint _hwnd;

	public nint LResult
	{
		get
		{
			return _lResult;
		}
		set
		{
			_lResult = value;
		}
	}

	public nint LParam
	{
		get
		{
			return _lParam;
		}
		set
		{
			_lParam = value;
		}
	}

	public nint WParam
	{
		get
		{
			return _wParam;
		}
		set
		{
			_wParam = value;
		}
	}

	public WM Message
	{
		get
		{
			return _message;
		}
		set
		{
			_message = value;
		}
	}

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
}
