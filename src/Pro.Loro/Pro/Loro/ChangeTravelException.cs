namespace Pro.Loro;

public class ChangeTravelException : UniffiException
{
	public class TargetIdNotFound : ChangeTravelException
	{
		public TargetIdNotFound(string message)
			: base(message)
		{
		}
	}

	public class TargetVersionNotIncluded : ChangeTravelException
	{
		public TargetVersionNotIncluded(string message)
			: base(message)
		{
		}
	}

	private ChangeTravelException(string message)
		: base(message)
	{
	}
}
