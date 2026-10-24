using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

public struct MONITORINFO
{
	public static readonly MONITORINFO Empty = new MONITORINFO
	{
		CbSize = (uint)Marshal.SizeOf<MONITORINFO>()
	};

	private uint _cbSize;

	private RECT _rcMonitor;

	private RECT _rcWork;

	private uint _dwFlags;

	public uint CbSize
	{
		get
		{
			return _cbSize;
		}
		private set
		{
			_cbSize = value;
		}
	}

	public RECT RcMonitor => _rcMonitor;

	public RECT RcWork => _rcWork;

	public uint DwFlags => _dwFlags;
}
