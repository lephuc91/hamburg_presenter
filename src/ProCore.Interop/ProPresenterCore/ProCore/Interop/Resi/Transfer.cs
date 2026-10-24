namespace ProPresenterCore.ProCore.Interop.Resi;

public class Transfer
{
	public ProResiTransferType Type { get; }

	public bool Success { get; }

	public Transfer(bool success, ProResiTransferType type)
	{
		Type = type;
		Success = success;
	}

	internal unsafe static Transfer FromNative(ProResiTransfer.__Internal* native)
	{
		return native->type switch
		{
			ProResiTransferType.kProResiTransferAboutInfo => new AboutInfoTransfer(native), 
			ProResiTransferType.kProResiTransferEventStatus => new EventStatusTransfer(native), 
			_ => new Transfer(ToSuccess(native->success), native->type), 
		};
	}

	protected static bool ToSuccess(uint success)
	{
		return success != 0;
	}
}
