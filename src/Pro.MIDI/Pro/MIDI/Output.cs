using System;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.MIDI.Interop;

namespace Pro.MIDI;

public class Output : DisposableBase
{
	private DeviceInfo _deviceInfo;

	private Dispatcher _dispatcher;

	private MidiOutProc _callback;

	private nint _handle;

	public DeviceInfo DeviceInfo => _deviceInfo;

	public bool IsOpen => _handle != IntPtr.Zero;

	public event Action<Output>? Closed;

	internal Output(OutputDevice device, Dispatcher dispatcher)
	{
		_deviceInfo = device.Info;
		_dispatcher = dispatcher;
		_callback = MessageHandler;
		MMRESULT mMRESULT;
		if ((mMRESULT = MidiFunctions.OutOpen(out _handle, device.ID, Marshal.GetFunctionPointerForDelegate(_callback), IntPtr.Zero, CALLBACK.FUNCTION)) != 0)
		{
			throw new Exception($"Failed to open requested midi output device - {mMRESULT}");
		}
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (IsOpen)
		{
			MidiFunctions.OutClose(_handle);
		}
	}

	private void MessageHandler(nint handle, MOM msg, nint instance, nint param1, nint param2)
	{
		if (msg == MOM.CLOSE)
		{
			_dispatcher.InvokeAsyncIfRequired(HandleCloseMessage);
		}
	}

	private void HandleCloseMessage()
	{
		_handle = IntPtr.Zero;
		this.Closed?.Invoke(this);
	}

	public void SendNoteOff(int channel, int noteValue, int intensity)
	{
		OnSendNote(128, channel, noteValue, intensity);
	}

	public void SendNoteOn(int channel, int noteValue, int intensity)
	{
		OnSendNote(144, channel, noteValue, intensity);
	}

	private void OnSendNote(byte statusFlag, int channel, int noteValue, int intensity)
	{
		EnsureValid();
		if (!IsOpen)
		{
			throw new Exception("Output is already closed");
		}
		byte num = (byte)(statusFlag | ((channel - 1) & 0xF));
		byte b = (byte)(noteValue & 0x7F);
		byte b2 = (byte)(intensity & 0x7F);
		uint message = (uint)(num | (b << 8) | (b2 << 16));
		MMRESULT mMRESULT;
		if ((mMRESULT = MidiFunctions.OutShortMsg(_handle, message)) != 0 && IsOpen)
		{
			throw new Exception($"Failed to send message - {mMRESULT}");
		}
	}
}
