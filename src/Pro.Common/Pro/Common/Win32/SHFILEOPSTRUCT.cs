using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct SHFILEOPSTRUCT
{
	private nint _handle;

	private FO _operation;

	[MarshalAs(UnmanagedType.LPWStr)]
	private string _from;

	[MarshalAs(UnmanagedType.LPWStr)]
	private string _to;

	private FOF _flags;

	[MarshalAs(UnmanagedType.Bool)]
	private bool _wasAborted;

	private nint _nameMappings;

	[MarshalAs(UnmanagedType.LPWStr)]
	private string _progressTitle;

	public FO Operation
	{
		get
		{
			return _operation;
		}
		set
		{
			_operation = value;
		}
	}

	public string? From
	{
		get
		{
			return _from?.Substring(0, _from.Length - 1);
		}
		set
		{
			_from = value + "\0";
		}
	}

	public string? To
	{
		get
		{
			return _to?.Substring(0, _to.Length - 1);
		}
		set
		{
			_to = value + "\0";
		}
	}

	public FOF Flags
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

	public bool WasAborted
	{
		get
		{
			return _wasAborted;
		}
		set
		{
			_wasAborted = value;
		}
	}
}
