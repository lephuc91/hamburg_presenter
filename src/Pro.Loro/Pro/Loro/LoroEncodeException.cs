namespace Pro.Loro;

public class LoroEncodeException : UniffiException
{
	public class FrontiersNotFound : LoroEncodeException
	{
		public FrontiersNotFound(string message)
			: base(message)
		{
		}
	}

	public class ShallowSnapshotIncompatibleWithOldFormat : LoroEncodeException
	{
		public ShallowSnapshotIncompatibleWithOldFormat(string message)
			: base(message)
		{
		}
	}

	public class UnknownContainer : LoroEncodeException
	{
		public UnknownContainer(string message)
			: base(message)
		{
		}
	}

	private LoroEncodeException(string message)
		: base(message)
	{
	}
}
