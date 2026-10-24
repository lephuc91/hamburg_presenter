using Jab;

namespace ProPresenter.Rendering.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<ISlidePreviewService, SlidePreviewService>]
public interface IRenderingServiceProviderModule
{
}
