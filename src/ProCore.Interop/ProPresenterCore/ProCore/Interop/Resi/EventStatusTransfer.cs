using ProPresenterCore.ProCore.Interop.Resi.Types;

namespace ProPresenterCore.ProCore.Interop.Resi;

public class EventStatusTransfer : Transfer
{
	public EventStatus Status { get; }

	internal unsafe EventStatusTransfer(ProResiTransfer.__Internal* native)
		: base(Transfer.ToSuccess(native->success), native->type)
	{
		Status = new EventStatus(((ProResiTransferEventStatus.__Internal*)native)->status);
	}
}
