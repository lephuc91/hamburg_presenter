using Pro.SerializationInterop.RVProtoData.Application;

namespace Pro.CoreApplication;

public interface IApplicationExceptionFactory
{
	ApplicationException Create(Error error);
}
