using System;
using ProPresenterCore.ProCore.Interop.Triggering.Types;
using ProPresenterCore.ProCore.Interop.Utility;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class RemoteStageSlideDataTransfer : TriggerTransfer
{
	private unsafe ProRemoteStageSlideDataTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.RemoteStageSlideData;

	public ResourceAddress CurrentSlideAddress { get; }

	public string CurrentSlideText { get; set; } = string.Empty;

	public string CurrentSlideNotes { get; set; } = string.Empty;

	public string CurrentSlideRTFNotes { get; set; } = string.Empty;

	public Guid NextSlideID { get; set; } = Guid.Empty;

	public string NextSlideText { get; set; } = string.Empty;

	public string NextSlideNotes { get; set; } = string.Empty;

	public string NextSlideRTFNotes { get; set; } = string.Empty;

	public unsafe RemoteStageSlideDataTransfer(ProRemoteStageSlideDataTransfer.__Internal* native)
	{
		_native = native;
		CurrentSlideAddress = new ResourceAddress(native->slideAddress);
	}

	internal unsafe override void Apply()
	{
		_native->currentText = StringMarshalling.StringToCString(CurrentSlideText);
		_native->currentNotes = StringMarshalling.StringToCString(CurrentSlideNotes);
		_native->currentRTFNotes = StringMarshalling.StringToCString(CurrentSlideRTFNotes);
		*(Guid*)(&_native->nextID) = NextSlideID;
		_native->nextText = StringMarshalling.StringToCString(NextSlideText);
		_native->nextNotes = StringMarshalling.StringToCString(NextSlideNotes);
		_native->nextRTFNotes = StringMarshalling.StringToCString(NextSlideRTFNotes);
	}
}
