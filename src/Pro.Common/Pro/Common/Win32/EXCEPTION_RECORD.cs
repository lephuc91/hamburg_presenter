namespace Pro.Common.Win32;

public struct EXCEPTION_RECORD
{
	private EXCEPTION _code;

	private uint _flags;

	private nint _record;

	private nint _address;

	private uint _parameterCount;

	private nint _parameters;

	public EXCEPTION Code => _code;

	public uint Flags => _flags;

	public nint Record => _record;

	public nint Address => _address;

	public uint ParameterCount => _parameterCount;

	public nint Parameters => _parameters;
}
