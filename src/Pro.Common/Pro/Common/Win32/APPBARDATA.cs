using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

public struct APPBARDATA
{
	public static readonly APPBARDATA Empty = new APPBARDATA
	{
		CbSize = (uint)Marshal.SizeOf<APPBARDATA>()
	};

	private uint _cbSize;

	private nint _handle;

	private uint _callbackMessage;

	private ABE _edge;

	private RECT _rc;

	private nint _lParam;

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

	public nint Handle => _handle;

	public uint CallbackMessage => _callbackMessage;

	public ABE Edge => _edge;

	public RECT RC => _rc;

	public nint LParam => _lParam;
}
