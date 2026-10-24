namespace Pro.Loro;

internal struct UniffiRustCallStatus
{
	public sbyte code;

	public RustBuffer error_buf;

	public bool IsSuccess()
	{
		return code == 0;
	}

	public bool IsError()
	{
		return code == 1;
	}

	public bool IsPanic()
	{
		return code == 2;
	}
}
