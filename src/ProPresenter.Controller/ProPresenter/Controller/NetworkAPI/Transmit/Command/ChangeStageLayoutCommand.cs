using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class ChangeStageLayoutCommand : INetworkCommand
{
	private readonly IEnumerable<(int, int)> _assignments;

	public ChangeStageLayoutCommand(IEnumerable<(int, int)> assignments)
	{
		_assignments = assignments;
	}

	public Pro.SerializationInterop.RVProtoData.NetworkAPI GetCommandProto()
	{
		return ProtoCommandExtensions.Build(delegate(Pro.SerializationInterop.RVProtoData.NetworkAPI c)
		{
			c.ChangeStageLayout(_assignments);
		});
	}
}
