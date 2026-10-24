using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct OSVERSIONINFOEXW
{
	public static readonly OSVERSIONINFOEXW Empty = new OSVERSIONINFOEXW
	{
		OSVersionInfoSize = (uint)Marshal.SizeOf<OSVERSIONINFOEXW>()
	};

	private uint _osVersionInfoSize;

	private uint _majorVersion;

	private uint _minorVersion;

	private uint _buildNumber;

	private uint _platformId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	private string _csdVersion;

	private ushort _servicePackMajor;

	private ushort _servicePackMinor;

	private ushort _suiteMask;

	private byte _productType;

	private byte _reserved;

	public uint OSVersionInfoSize
	{
		get
		{
			return _osVersionInfoSize;
		}
		private set
		{
			_osVersionInfoSize = value;
		}
	}

	public uint MajorVersion => _majorVersion;

	public uint MinorVersion => _minorVersion;

	public uint BuildNumber => _buildNumber;

	public uint PlatformId => _platformId;

	public string CSDVersion => _csdVersion;

	public ushort ServicePackMajor => _servicePackMajor;

	public ushort ServicePackMinor => _servicePackMinor;

	public ushort SuiteMask => _suiteMask;
}
