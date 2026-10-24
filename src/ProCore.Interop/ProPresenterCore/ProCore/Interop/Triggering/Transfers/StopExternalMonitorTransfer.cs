using System;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class StopExternalMonitorTransfer : TriggerTransfer
{
	private unsafe ProStopMonitoringTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.StopExternalMonitor;

	public Guid SlideID { get; }

	public Guid ElementID { get; }

	public TriggerHandle TriggerHandle { get; }

	public unsafe StopExternalMonitorTransfer(ProStopMonitoringTransfer.__Internal* native)
	{
		_native = native;
		SlideID = *(Guid*)native->slideID;
		ElementID = *(Guid*)native->elementID;
		TriggerHandle = new TriggerHandle(native->handle);
	}

	internal override void Apply()
	{
	}
}
