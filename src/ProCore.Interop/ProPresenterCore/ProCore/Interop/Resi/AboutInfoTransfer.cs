using ProPresenterCore.ProCore.Interop.Resi.Types;

namespace ProPresenterCore.ProCore.Interop.Resi;

public class AboutInfoTransfer : Transfer
{
	public AboutInfo AboutInfo { get; }

	public unsafe AboutInfoTransfer(ProResiTransfer.__Internal* native)
		: base(Transfer.ToSuccess(native->success), native->type)
	{
		AboutInfo = new AboutInfo(((ProResiTransferAboutInfo.__Internal*)native)->aboutInfo);
	}
}
