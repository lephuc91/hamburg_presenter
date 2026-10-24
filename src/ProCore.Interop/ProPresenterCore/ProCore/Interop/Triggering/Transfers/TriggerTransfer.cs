using Pro.Common.Components;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public abstract class TriggerTransfer : DisposableBase
{
	public abstract ProTriggerTransferType TransferType { get; }

	internal abstract void Apply();

	internal unsafe static TriggerTransfer? FromNative(ProTriggerTransfer.__Internal* native)
	{
		return native->type switch
		{
			ProTriggerTransferType.SlideElement => new SlideElementTransfer((ProSlideElementTransfer.__Internal*)native), 
			ProTriggerTransferType.MessageSlide => new MessageSlideTransfer((ProMessageSlideTransfer.__Internal*)native), 
			ProTriggerTransferType.NextCue => new NextCueTransfer((ProNextCueTransfer.__Internal*)native), 
			ProTriggerTransferType.RemoteStageSlideData => new RemoteStageSlideDataTransfer((ProRemoteStageSlideDataTransfer.__Internal*)native), 
			ProTriggerTransferType.AltSlide => new AltSlideTransfer((ProAltSlideTransfer.__Internal*)native), 
			ProTriggerTransferType.Timer => new TimerTransfer((ProTimerTransfer.__Internal*)native), 
			ProTriggerTransferType.CCLISlide => new CCLISlideTransfer((ProCCLISlideTransfer.__Internal*)native), 
			ProTriggerTransferType.PlaylistCue => new PlaylistCueTransfer((ProPlaylistCueTransfer.__Internal*)native), 
			ProTriggerTransferType.NewAction => new NewActionTransfer((ProNewActionTransfer.__Internal*)native), 
			ProTriggerTransferType.StartExternalMonitor => new StartExternalMonitorTransfer((ProStartMonitoringTransfer.__Internal*)native), 
			ProTriggerTransferType.StopExternalMonitor => new StopExternalMonitorTransfer((ProStopMonitoringTransfer.__Internal*)native), 
			ProTriggerTransferType.GetNewContext => new GetNewContextTransfer((ProGetNewContextTransfer.__Internal*)native), 
			_ => null, 
		};
	}
}
