using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.MIDI.Interop;

namespace Pro.MIDI;

public class Input : DisposableBase
{
	private struct DataMessage
	{
		public TimeSlice Timestamp { get; set; }

		public byte Status { get; set; }

		public byte D1 { get; set; }

		public byte D2 { get; set; }
	}

	public delegate void NoteDelegate(Input sender, TimeSlice timestamp, int channel, int noteValue, int intensity);

	private const int DefaultNoteIntensity = 64;

	private DeviceInfo _deviceInfo;

	private Dispatcher _dispatcher;

	private MidiInProc _callback;

	private nint _handle;

	private ConcurrentQueue<DataMessage> _queuedData = new ConcurrentQueue<DataMessage>();

	public DeviceInfo DeviceInfo => _deviceInfo;

	public bool IsOpen => _handle != IntPtr.Zero;

	public event Action<Input>? Closed;

	public event NoteDelegate? NoteOff;

	public event NoteDelegate? NoteOn;

	internal Input(InputDevice device, Dispatcher dispatcher)
	{
		_deviceInfo = device.Info;
		_dispatcher = dispatcher;
		_callback = MessageHandler;
		MMRESULT mMRESULT;
		if ((mMRESULT = MidiFunctions.InOpen(out _handle, device.ID, Marshal.GetFunctionPointerForDelegate(_callback), IntPtr.Zero, CALLBACK.FUNCTION)) != 0)
		{
			throw new Exception($"Failed to open requested midi input device - {mMRESULT}");
		}
		if ((mMRESULT = MidiFunctions.InStart(_handle)) != 0)
		{
			MidiFunctions.InClose(_handle);
			throw new Exception($"Failed to start requested midi input device - {mMRESULT}");
		}
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (IsOpen)
		{
			MidiFunctions.InStop(_handle);
			MidiFunctions.InClose(_handle);
		}
	}

	private void MessageHandler(nint handle, MIM msg, nint instance, nint param1, nint param2)
	{
		switch (msg)
		{
		case MIM.DATA:
			_queuedData.Enqueue(new DataMessage
			{
				Timestamp = TimeSlice.FromMilliseconds(param2),
				Status = (byte)((ulong)param1 & 0xFFuL),
				D1 = (byte)(((ulong)param1 & 0xFF00uL) >> 8),
				D2 = (byte)(((ulong)param1 & 0xFF0000uL) >> 16)
			});
			_dispatcher.InvokeAsyncIfRequired(HandleDataMessages);
			break;
		case MIM.CLOSE:
			_dispatcher.InvokeAsyncIfRequired(HandleCloseMessage);
			break;
		}
	}

	private void HandleDataMessages()
	{
		DataMessage result;
		while (_queuedData.TryDequeue(out result))
		{
			if (result.Status >= 128 && result.Status <= 143)
			{
				OnNoteMessage(result, this.NoteOff);
			}
			else if (result.Status >= 144 && result.Status <= 159)
			{
				OnNoteMessage(result, this.NoteOn);
			}
		}
	}

	private void OnNoteMessage(DataMessage message, NoteDelegate? handler)
	{
		int channel = (message.Status & 0xF) + 1;
		int noteValue = message.D1 & 0x7F;
		int num = message.D2 & 0x7F;
		if (num == 0)
		{
			num = 64;
			handler = this.NoteOff;
		}
		handler?.Invoke(this, message.Timestamp, channel, noteValue, num);
	}

	private void HandleCloseMessage()
	{
		_handle = IntPtr.Zero;
		this.Closed?.Invoke(this);
	}
}
