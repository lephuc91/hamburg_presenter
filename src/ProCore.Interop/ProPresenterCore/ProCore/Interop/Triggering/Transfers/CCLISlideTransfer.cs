using System.IO;
using Google.Protobuf;
using Pro.Common.Mathematics;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class CCLISlideTransfer : TriggerTransfer
{
	private unsafe ProCCLISlideTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.CCLISlide;

	public Vector2<double> ScreenSize { get; }

	public ResourceAddress OriginalSlide { get; }

	public Slide? CCLISlide { get; set; }

	public unsafe CCLISlideTransfer(ProCCLISlideTransfer.__Internal* native)
	{
		_native = native;
		ScreenSize = new Vector2<double>(native->screenWidth, native->screenHeight);
		OriginalSlide = new ResourceAddress(native->originalSlide);
	}

	internal unsafe override void Apply()
	{
		if (CCLISlide != null)
		{
			int num = CCLISlide.CalculateSize();
			_native->ccliSlideData = ProCore.DataTransferAlloc((uint)num);
			_native->ccliSlideDataSize = (uint)num;
			UnmanagedMemoryStream output = new UnmanagedMemoryStream((byte*)_native->ccliSlideData, num, num, FileAccess.Write);
			((IMessage)CCLISlide).WriteTo((Stream)output);
		}
	}
}
