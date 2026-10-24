using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Repositories;

namespace ProPresenter.Controller.Outputs;

public class OutputService : IOutputService
{
	private readonly ICommunicationOutput _communicationOutput;

	public ssAPIOutput OutputController { get; private set; }

	public IOutputRepository OutputRepository { get; private set; }

	public IOutputConfiguration OutputConfiguration { get; }

	public DeviceCollection Devices => _communicationOutput.Devices;

	public OutputService(ssAPIOutput outputController, IOutputRepository outputRepository, ICommunicationOutput communicationOutput, IOutputConfiguration outputConfiguration)
	{
		OutputController = outputController;
		_communicationOutput = communicationOutput;
		OutputRepository = outputRepository;
		OutputConfiguration = outputConfiguration;
	}
}
