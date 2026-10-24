using System;
using System.IO;
using Google.Protobuf;
using Pro.Common.Mathematics;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class AltSlideTransfer : TriggerTransfer
{
	private unsafe ProAltSlideTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.AltSlide;

	public Guid LookID { get; }

	public Guid ScreenID { get; }

	public Vector2<double> ScreenSize { get; }

	public ResourceAddress OriginalSlide { get; }

	public Slide? AltSlide { get; set; }

	public unsafe AltSlideTransfer(ProAltSlideTransfer.__Internal* native)
	{
		_native = native;
		LookID = *(Guid*)native->lookID;
		ScreenID = *(Guid*)native->screenID;
		ScreenSize = new Vector2<double>(native->screenWidth, native->screenHeight);
		OriginalSlide = new ResourceAddress(native->originalSlide);
	}

	internal unsafe override void Apply()
	{
		if (AltSlide != null)
		{
			int num = AltSlide.CalculateSize();
			_native->altSlideData = ProCore.DataTransferAlloc((uint)num);
			_native->altSlideDataSize = (uint)num;
			UnmanagedMemoryStream output = new UnmanagedMemoryStream((byte*)_native->altSlideData, num, num, FileAccess.Write);
			((IMessage)AltSlide).WriteTo((Stream)output);
		}
	}
}
