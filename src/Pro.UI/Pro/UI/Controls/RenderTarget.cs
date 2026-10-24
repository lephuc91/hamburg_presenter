using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Pro.UI.Controls;

public class RenderTarget : HwndHost
{
	private nint _targetHandle = IntPtr.Zero;

	private readonly Func<nint, nint> _createWindow;

	private readonly Action<nint> _closeWindow;

	public nint TargetHandle => _targetHandle;

	public RenderTarget(Func<nint, nint> createWindow, Action<nint> closeWindow)
	{
		_createWindow = createWindow;
		_closeWindow = closeWindow;
	}

	protected override HandleRef BuildWindowCore(HandleRef hwndParent)
	{
		_targetHandle = _createWindow(hwndParent.Handle);
		return new HandleRef(this, _targetHandle);
	}

	protected override void DestroyWindowCore(HandleRef hwnd)
	{
		if (_targetHandle != IntPtr.Zero)
		{
			_closeWindow(_targetHandle);
			_targetHandle = IntPtr.Zero;
		}
	}
}
