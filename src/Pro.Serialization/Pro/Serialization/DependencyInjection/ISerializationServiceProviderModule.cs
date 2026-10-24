using Jab;
using Pro.Serialization.Utility;

namespace Pro.Serialization.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IProtoService, ProtoService>]
public interface ISerializationServiceProviderModule
{
}
