using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using RenewedVision.Windows.Media;

namespace RenewedVision.Wpf.Interop.DirectX;

public class D3D11Image : D3DImage, IDisposable
{
	internal SurfaceQueueInteropHelper Helper;

	public static DependencyProperty OnRenderProperty;

	public static DependencyProperty WindowOwnerProperty;

	public nint WindowOwner
	{
		get
		{
			return (nint)((DependencyObject)this).GetValue(WindowOwnerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowOwnerProperty, (object)value);
		}
	}

	public Action<nint, bool> OnRender
	{
		get
		{
			return (Action<nint, bool>)((DependencyObject)this).GetValue(OnRenderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OnRenderProperty, (object)value);
		}
	}

	private static void RenderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is D3D11Image { Helper: not null } d3D11Image)
		{
			d3D11Image.Helper.RenderD2D = (Action<nint, bool>)((DependencyPropertyChangedEventArgs)(ref args)).NewValue;
		}
	}

	private static void HWNDOwnerChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is D3D11Image { Helper: not null } d3D11Image)
		{
			d3D11Image.Helper.HWND = (nint)((DependencyPropertyChangedEventArgs)(ref args)).NewValue;
		}
	}

	private void EnsureHelper()
	{
		if (Helper == null)
		{
			Helper = new SurfaceQueueInteropHelper();
			nint windowOwner = WindowOwner;
			Helper.HWND = windowOwner;
			Helper.D3DImage = this;
			Helper.RenderD2D = OnRender;
		}
		GC.KeepAlive(this);
	}

	static D3D11Image()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		OnRenderProperty = DependencyProperty.Register("OnRender", typeof(Action<nint, bool>), typeof(D3D11Image), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(RenderChanged)));
		WindowOwnerProperty = DependencyProperty.Register("WindowOwner", typeof(nint), typeof(D3D11Image), (PropertyMetadata)(object)new UIPropertyMetadata(IntPtr.Zero, new PropertyChangedCallback(HWNDOwnerChanged)));
	}

	protected override Freezable CreateInstanceCore()
	{
		return (Freezable)(object)new D3D11Image();
	}

	private void _007ED3D11Image()
	{
		SurfaceQueueInteropHelper helper = Helper;
		if (helper != null)
		{
			((IDisposable)helper).Dispose();
			Helper = null;
		}
	}

	public void RequestRender()
	{
		EnsureHelper();
		if (null != OnRender)
		{
			Helper.RequestRenderD2D();
		}
		GC.KeepAlive(this);
	}

	public void SetPixelSize(int pixelWidth, int pixelHeight)
	{
		EnsureHelper();
		Helper.SetPixelSize((uint)pixelWidth, (uint)pixelHeight);
		GC.KeepAlive(this);
	}

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_007ED3D11Image();
		}
		else
		{
			Finalize();
		}
	}

	public sealed override void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
		GC.KeepAlive(this);
	}
}
