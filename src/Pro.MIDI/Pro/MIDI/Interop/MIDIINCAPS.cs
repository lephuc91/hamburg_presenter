using System.Runtime.InteropServices;

namespace Pro.MIDI.Interop;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct MIDIINCAPS
{
	private ushort _manufacturerID;

	private ushort _productID;

	private uint _driverVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	private string _name;

	private uint _reserved;

	public ushort ManufacturerID => _manufacturerID;

	public ushort ProductID => _productID;

	public uint DriverVersion => _driverVersion;

	public string Name => _name;
}
