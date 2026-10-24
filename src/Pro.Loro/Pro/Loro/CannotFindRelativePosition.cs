namespace Pro.Loro;

public class CannotFindRelativePosition : UniffiException
{
	public class ContainerDeleted : CannotFindRelativePosition
	{
		public ContainerDeleted(string message)
			: base(message)
		{
		}
	}

	public class HistoryCleared : CannotFindRelativePosition
	{
		public HistoryCleared(string message)
			: base(message)
		{
		}
	}

	public class IdNotFound : CannotFindRelativePosition
	{
		public IdNotFound(string message)
			: base(message)
		{
		}
	}

	private CannotFindRelativePosition(string message)
		: base(message)
	{
	}
}
