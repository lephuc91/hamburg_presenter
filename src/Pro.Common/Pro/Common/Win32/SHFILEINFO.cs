using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct SHFILEINFO
{
	private nint _iconHandle;

	private int _iconIndex;

	private uint _attributes;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	private string _displayName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
	private string _typeName;

	public nint IconHandle => _iconHandle;

	public int IconIndex => _iconIndex;

	public uint Attributes => _attributes;

	public string DisplayName => _displayName;

	public string TypeName => _typeName;
}
