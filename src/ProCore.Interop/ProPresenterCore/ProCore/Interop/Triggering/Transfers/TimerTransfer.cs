using System;
using System.IO;
using Google.Protobuf;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Utility;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class TimerTransfer : TriggerTransfer
{
	private unsafe ProTimerTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.Timer;

	public Guid TimerID { get; }

	public string TimerName { get; }

	public Timer.Types.Configuration TimerConfiguration { get; } = new Timer.Types.Configuration();

	public TimeSlice TimerIncrementTime { get; }

	public ProTimerActionType TimerActionType { get; }

	public Timer? Timer { get; set; }

	internal unsafe TimerTransfer(ProTimerTransfer.__Internal* native)
	{
		_native = native;
		TimerID = *(Guid*)native->timerID;
		TimerName = StringMarshalling.StringFromCString(native->timerName);
		TimerActionType = native->timerAction;
		TimerIncrementTime = TimeSlice.FromSeconds(native->timerIncrementAmount);
		if (native->timerConfiguration != IntPtr.Zero)
		{
			UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)native->timerConfiguration, native->timerConfigurationSize);
			((IMessage)TimerConfiguration).MergeFrom((Stream)input);
		}
	}

	internal unsafe override void Apply()
	{
		if (Timer != null)
		{
			int num = Timer.CalculateSize();
			_native->timerData = ProCore.DataTransferAlloc((uint)num);
			_native->timerSize = (uint)num;
			UnmanagedMemoryStream output = new UnmanagedMemoryStream((byte*)_native->timerData, num, num, FileAccess.Write);
			((IMessage)Timer).WriteTo((Stream)output);
		}
	}
}
