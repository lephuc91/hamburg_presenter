using System.Threading.Tasks;

namespace ProPresenter.DO.Analytics;

public interface IApplicationLaunchEventPublisher
{
	Task PublishApplicationLaunchEvent();
}
