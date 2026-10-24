using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class MacroNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly IMacroSource _macroSource;

	public MacroNetworkTriggerDataHandler(IMacroSource macroSource)
	{
		_macroSource = macroSource;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_macroSource == null)
		{
			return null;
		}
		ProPresenterMacro proPresenterMacro = id.FindItem(_macroSource.FlatCollection);
		if (proPresenterMacro != null)
		{
			op.AttachMacroInfo(proPresenterMacro);
		}
		return proPresenterMacro.ToAction()?.ToTriggerDataItem();
	}
}
