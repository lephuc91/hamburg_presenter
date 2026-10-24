using Jab;

namespace ProPresenter.DO.Capture.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<IEncoderValidator, EncoderValidator>]
internal interface ICaptureServiceProviderModule
{
}
