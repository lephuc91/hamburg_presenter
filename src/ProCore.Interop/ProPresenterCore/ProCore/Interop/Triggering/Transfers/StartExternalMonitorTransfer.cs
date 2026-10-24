using System;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class StartExternalMonitorTransfer : TriggerTransfer
{
	private unsafe ProStartMonitoringTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.StartExternalMonitor;

	public Guid SlideID { get; }

	public Guid ElementID { get; }

	public TriggerHandle TriggerHandle { get; }

	public unsafe StartExternalMonitorTransfer(ProStartMonitoringTransfer.__Internal* native)
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
