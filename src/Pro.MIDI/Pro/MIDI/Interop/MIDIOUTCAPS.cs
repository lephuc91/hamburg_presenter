using System.Runtime.InteropServices;

namespace Pro.MIDI.Interop;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct MIDIOUTCAPS
{
	private ushort _manufacturerID;

	private ushort _productID;

	private uint _driverVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	private string _name;

	private MOD _type;

	private ushort _voices;

	private ushort _notes;

	private ushort _channelMask;

	private MIDICAPS _flags;

	public ushort ManufacturerID => _manufacturerID;

	public ushort ProductID => _productID;

	public uint DriverVersion => _driverVersion;

	public string Name => _name;

	public MOD Type => _type;

	public ushort Voices => _voices;

	public ushort Notes => _notes;

	public ushort ChannelMask => _channelMask;

	public MIDICAPS Flags => _flags;
}
