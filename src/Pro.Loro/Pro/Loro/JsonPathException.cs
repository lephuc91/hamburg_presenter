namespace Pro.Loro;

public class JsonPathException : UniffiException
{
	public class InvalidJsonPath : JsonPathException
	{
		public InvalidJsonPath(string message)
			: base(message)
		{
		}
	}

	public class EvaluationException : JsonPathException
	{
		public EvaluationException(string message)
			: base(message)
		{
		}
	}

	private JsonPathException(string message)
		: base(message)
	{
	}
}
