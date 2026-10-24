namespace Pro.Loro;

public class InvalidEnumException : InternalException
{
	public InvalidEnumException(string message)
		: base(message)
	{
	}
}
