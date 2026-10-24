using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Repositories;

namespace ProPresenter.Controller.Outputs;

public interface IOutputService
{
	ssAPIOutput OutputController { get; }

	IOutputRepository OutputRepository { get; }

	DeviceCollection Devices { get; }

	IOutputConfiguration OutputConfiguration { get; }
}
