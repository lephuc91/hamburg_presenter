using System.Threading.Tasks;
using Pro.Common.Mathematics;

namespace ProPresenter.Rendering.Web;

public interface IWebFillBrowserFactory
{
	Task<IWebFillBrowser?> CreateBrowserAsync(Vector2<double> windowSize);
}
