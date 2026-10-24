using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Receive.Command;

public abstract class CommandHandlerBase
{
	protected ITriggering Triggering { get; }

	public CommandHandlerBase(ITriggering triggering)
	{
		Triggering = triggering;
	}

	public abstract void Handle(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action command);

	public virtual bool Handle(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_TwoStepTrigger twoStepTriggering)
	{
		return false;
	}
}
