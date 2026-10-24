using System;
using System.Runtime.InteropServices;
using Pro.Common.Components;
using Pro.Common.Mathematics;

namespace Pro.PPTViewer;

public class ProcessManager : DisposableBase
{
	private const string ImportPrefix = "ProcessManager_";

	private IntPtr _handle = IntPtr.Zero;

	private string _presentationPath;

	public string PresentationPath => _presentationPath;

	public double DPIScalar
	{
		get
		{
			EnsureValid();
			return GetDPIScalar(_handle);
		}
	}

	public bool Offscreen
	{
		get
		{
			EnsureValid();
			return IsOffscreen(_handle);
		}
	}

	public bool Visible
	{
		get
		{
			EnsureValid();
			return IsVisible(_handle);
		}
	}

	public ProcessManager(string presentationPath, string viewerPath, bool isOffscreen = false, bool isVisible = false)
	{
		if (!ViewerFinder.IsValidViewer(viewerPath))
		{
			throw new Exception("PowerPoint Viewer not found");
		}
		_handle = CreateProcessManager(viewerPath, presentationPath, isOffscreen, isVisible);
		_presentationPath = presentationPath;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (_handle != IntPtr.Zero)
		{
			DestroyProcessManager(_handle);
		}
		_handle = IntPtr.Zero;
	}

	public void GoToSlide(uint slideNumber)
	{
		EnsureValid();
		GoToSlide(_handle, slideNumber);
	}

	public void CaptureSlide(string capturedImagePath, bool waitForRedraw = true)
	{
		EnsureValid();
		CaptureSlide(_handle, capturedImagePath, waitForRedraw);
	}

	public void SetWindowPosition(Vector2<int> position)
	{
		EnsureValid();
		SetWindowPosition(_handle, position.X, position.Y);
	}

	public void SetWindowPositionOffscreen()
	{
		EnsureValid();
		SetWindowPositionOffscreen(_handle);
	}

	public void SetWindowBehindOther(IntPtr otherWindowHandle)
	{
		EnsureValid();
		SetWindowBehindOther(_handle, otherWindowHandle);
	}

	public void SetWindowSize(Vector2<int> size)
	{
		EnsureValid();
		SetWindowSize(_handle, size.X, size.Y);
	}

	public void Show(bool showOnTop = true)
	{
		EnsureValid();
		Show(_handle, showOnTop);
	}

	public void Hide()
	{
		EnsureValid();
		Hide(_handle);
	}

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_CreateProcessManager")]
	private static extern IntPtr CreateProcessManager([MarshalAs(UnmanagedType.LPWStr)] string viewerPath, [MarshalAs(UnmanagedType.LPWStr)] string presentationPath, bool isOffscreen, bool isVisible);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_DestroyProcessManager")]
	private static extern void DestroyProcessManager(IntPtr handle);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_GetDPIScalar")]
	private static extern double GetDPIScalar(IntPtr handle);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_GoToSlide")]
	private static extern void GoToSlide(IntPtr handle, uint slideNumber);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_CaptureSlide")]
	private static extern void CaptureSlide(IntPtr handle, [MarshalAs(UnmanagedType.LPWStr)] string capturedImagePath, bool waitForRedraw);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_IsOffscreen")]
	private static extern bool IsOffscreen(IntPtr handle);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_SetWindowPosition")]
	private static extern void SetWindowPosition(IntPtr handle, int x, int y);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_SetWindowPositionOffscreen")]
	private static extern void SetWindowPositionOffscreen(IntPtr handle);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_SetWindowBehindOther")]
	private static extern void SetWindowBehindOther(IntPtr handle, IntPtr otherWindow);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_SetWindowSize")]
	private static extern void SetWindowSize(IntPtr handle, int w, int h);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_IsVisible")]
	private static extern bool IsVisible(IntPtr handle);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_Show")]
	private static extern void Show(IntPtr handle, bool showOnTop);

	[DllImport("PPV.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessManager_Hide")]
	private static extern void Hide(IntPtr handle);
}
