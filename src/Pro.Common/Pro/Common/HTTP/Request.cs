using System.Collections.Generic;

namespace Pro.Common.HTTP;

public class Request : Request<dynamic>
{
}
public class Request<T> where T : class?
{
	public Method Method { get; set; }

	public string? URL { get; set; }

	public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

	public virtual T? Body { get; set; }
}
