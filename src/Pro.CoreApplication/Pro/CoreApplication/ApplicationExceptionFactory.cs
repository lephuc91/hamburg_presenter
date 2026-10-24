using Pro.SerializationInterop.RVProtoData.Application;

namespace Pro.CoreApplication;

public class ApplicationExceptionFactory : IApplicationExceptionFactory
{
	public ApplicationException Create(Error error)
	{
		return error.Service switch
		{
			ServiceID.Application => new ApplicationException(error), 
			ServiceID.Media => new MediaServiceException(error), 
			_ => new ApplicationException(), 
		};
	}
}
