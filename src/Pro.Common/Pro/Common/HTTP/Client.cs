using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pro.Common.Async;
using Pro.Common.IO;
using RestSharp;

namespace Pro.Common.HTTP;

public class Client
{
	private readonly IRestClient _restClient;

	public Client(IRestClientFactory clientFactory)
	{
		_restClient = clientFactory.Get();
	}

	private static RestRequest SetupRequest<T>(Request<T> request, ContentType contentEncoding) where T : class?
	{
		if (string.IsNullOrWhiteSpace(request.URL))
		{
			throw new InvalidOperationException();
		}
		RestRequest restRequest = new RestRequest(request.URL, (RestSharp.Method)request.Method);
		if (request.Body != null)
		{
			switch (contentEncoding)
			{
			case ContentType.JSON:
				restRequest.AddBody(JsonConvert.SerializeObject(request.Body), "application/json");
				break;
			case ContentType.FormURLEncoded:
				foreach (KeyValuePair<string, JToken> item in JObject.FromObject(request.Body))
				{
					restRequest.AddParameter(item.Key, item.Value?.ToString() ?? string.Empty, ParameterType.GetOrPost);
				}
				break;
			default:
				throw new NotSupportedException();
			}
		}
		if (request.Headers != null)
		{
			foreach (KeyValuePair<string, string> header in request.Headers)
			{
				restRequest.AddHeader(header.Key, header.Value);
			}
		}
		return restRequest;
	}

	private static ReadOnlyDictionary<string, string> ConvertHeaders(RestResponse restResponse)
	{
		return new ReadOnlyDictionary<string, string>(restResponse.Headers?.Where((HeaderParameter h) => h.Name != null && h.Value != null).ToDictionary((HeaderParameter h) => h.Name ?? string.Empty, (HeaderParameter h) => h.Value?.ToString() ?? string.Empty) ?? new Dictionary<string, string>());
	}

	public Task<Response<dynamic>> SendRequestAsync<T>(Request<T> request, ContentType contentEncoding = ContentType.JSON) where T : class
	{
		return SendRequestAsync<T, object>(request, contentEncoding);
	}

	public async Task<Response<O>> SendRequestAsync<I, O>(Request<I> request, ContentType contentEncoding = ContentType.JSON) where I : class? where O : class
	{
		RestRequest request2 = SetupRequest(request, contentEncoding);
		RestResponse restResponse = await _restClient.ExecuteAsync(request2);
		O data = null;
		bool flag = restResponse.Content?.TryFromJson<O>(out data) ?? false;
		return new Response<O>(restResponse.IsSuccessful && flag, (int)restResponse.StatusCode, ConvertHeaders(restResponse), data);
	}

	public Response<dynamic>? SendRequest<T>(Request<T> request, ContentType contentEncoding = ContentType.JSON) where T : class
	{
		return SendRequest<T, object>(request, contentEncoding);
	}

	public Response<O>? SendRequest<I, O>(Request<I> request, ContentType contentEncoding = ContentType.JSON) where I : class? where O : class
	{
		Response<O> result = null;
		using PumpingSynchronizationContextExecutor pumpingSynchronizationContextExecutor = new PumpingSynchronizationContextExecutor(async delegate
		{
			result = await SendRequestAsync<I, O>(request, contentEncoding);
		});
		pumpingSynchronizationContextExecutor.Run();
		return result;
	}
}
