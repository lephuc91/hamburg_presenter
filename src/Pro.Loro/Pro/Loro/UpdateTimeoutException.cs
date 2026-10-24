namespace Pro.Loro;

public class UpdateTimeoutException : UniffiException
{
	public class Timeout : UpdateTimeoutException
	{
		public Timeout(string message)
			: base(message)
		{
		}
	}

	private UpdateTimeoutException(string message)
		: base(message)
	{
	}
}
