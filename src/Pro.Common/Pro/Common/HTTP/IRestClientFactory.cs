using RestSharp;

namespace Pro.Common.HTTP;

public interface IRestClientFactory
{
	IRestClient Get(ConfigureRestClient? configureClient = null, ConfigureSerialization? configureSerialization = null);
}
