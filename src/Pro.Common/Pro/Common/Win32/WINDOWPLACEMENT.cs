using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

public struct WINDOWPLACEMENT
{
	public static readonly WINDOWPLACEMENT Empty = new WINDOWPLACEMENT
	{
		Length = (uint)Marshal.SizeOf<WINDOWPLACEMENT>()
	};

	private uint _length;

	private uint _flags;

	private SW _showCommand;

	private POINT _minPosition;

	private POINT _maxPosition;

	private RECT _normalPosition;

	public uint Length
	{
		get
		{
			return _length;
		}
		private set
		{
			_length = value;
		}
	}

	public uint Flags
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

	public SW ShowCommand
	{
		get
		{
			return _showCommand;
		}
		set
		{
			_showCommand = value;
		}
	}

	public POINT MinPosition
	{
		get
		{
			return _minPosition;
		}
		set
		{
			_minPosition = value;
		}
	}

	public POINT MaxPosition
	{
		get
		{
			return _maxPosition;
		}
		set
		{
			_maxPosition = value;
		}
	}

	public RECT NormalPosition
	{
		get
		{
			return _normalPosition;
		}
		set
		{
			_normalPosition = value;
		}
	}
}
