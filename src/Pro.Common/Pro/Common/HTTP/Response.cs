using System.Collections.ObjectModel;

namespace Pro.Common.HTTP;

public class Response<T> where T : class
{
	public bool IsSuccessful { get; }

	public int StatusCode { get; }

	public ReadOnlyDictionary<string, string>? Headers { get; }

	public T? Body { get; }

	public Response(bool isSuccessful, int statusCode, ReadOnlyDictionary<string, string>? headers, T? body)
	{
		IsSuccessful = isSuccessful;
		StatusCode = statusCode;
		Headers = headers;
		Body = body;
	}
}
