using Jab;
using Pro.UI.Converters;

namespace ProPresenter.UI.Converters.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<MediaInspectorConverter>]
[Jab.Transient<WarningTooltipConverter>]
public interface IConvertersServiceProviderModule
{
}
