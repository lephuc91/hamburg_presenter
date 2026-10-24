using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace RenewedVision.Windows.Media;

public class SurfaceQueueInteropHelper : IDisposable
{
	private enum QueueRenderMode
	{
		None,
		RenderDXGI
	}

	private Action<nint, bool> m_renderD2D;

	private D3DImage m_d3dImage;

	private DependencyPropertyChangedEventHandler m_frontBufferAvailableChanged;

	private uint m_pixelWidth;

	private uint m_pixelHeight;

	private unsafe HWND__* m_hwnd;

	private unsafe IDirect3D9Ex* m_pD3D9;

	private unsafe IDirect3DDevice9Ex* m_pD3D9Device;

	private unsafe ID3D10Device1* m_D3D10Device;

	private unsafe ISurfaceQueue* m_ABQueue;

	private unsafe ISurfaceQueue* m_BAQueue;

	private unsafe ISurfaceConsumer* m_ABConsumer;

	private unsafe ISurfaceProducer* m_BAProducer;

	private unsafe ISurfaceConsumer* m_BAConsumer;

	private unsafe ISurfaceProducer* m_ABProducer;

	private bool m_isD3DInitialized;

	private bool m_areSurfacesInitialized;

	private bool m_shouldSkipRender;

	public unsafe nint HWND
	{
		get
		{
			nint result = (nint)(void*)m_hwnd;
			GC.KeepAlive(this);
			return result;
		}
		set
		{
			m_hwnd = (HWND__*)(void*)value;
			GC.KeepAlive(this);
		}
	}

	public uint PixelHeight => m_pixelHeight;

	public uint PixelWidth => m_pixelWidth;

	public unsafe D3DImage D3DImage
	{
		get
		{
			return m_d3dImage;
		}
		set
		{
			//IL_0016: Expected I, but got I8
			D3DImage d3dImage = m_d3dImage;
			if (value != d3dImage)
			{
				if (null != d3dImage)
				{
					nint backBuffer = (nint)(void*)null;
					m_d3dImage.SetBackBuffer(D3DResourceType.IDirect3DSurface9, backBuffer);
				}
				m_d3dImage = value;
			}
		}
	}

	public Action<nint, bool> RenderD2D
	{
		set
		{
			m_renderD2D = value;
		}
	}

	private unsafe int InitD3D10()
	{
		//IL_001d: Expected I, but got I8
		//IL_001d: Expected I, but got I8
		//IL_0079: Expected I, but got I8
		fixed (ID3D10Device1** d3D10Device = &m_D3D10Device)
		{
			int num = global::_003CModule_003E.D3D10CreateDevice1(null, (D3D10_DRIVER_TYPE)0, null, 32u, (D3D10_FEATURE_LEVEL1)40960, 32u, d3D10Device);
			if (num < 0)
			{
				GC.KeepAlive(this);
				return num;
			}
			Unsafe.SkipInit(out D3D10_VIEWPORT d3D10_VIEWPORT);
			Unsafe.As<D3D10_VIEWPORT, int>(ref Unsafe.AddByteOffset(ref d3D10_VIEWPORT, 8)) = 640;
			Unsafe.As<D3D10_VIEWPORT, int>(ref Unsafe.AddByteOffset(ref d3D10_VIEWPORT, 12)) = 480;
			Unsafe.As<D3D10_VIEWPORT, float>(ref Unsafe.AddByteOffset(ref d3D10_VIEWPORT, 16)) = 0f;
			Unsafe.As<D3D10_VIEWPORT, float>(ref Unsafe.AddByteOffset(ref d3D10_VIEWPORT, 20)) = 1f;
			*(int*)(&d3D10_VIEWPORT) = 0;
			Unsafe.As<D3D10_VIEWPORT, int>(ref Unsafe.AddByteOffset(ref d3D10_VIEWPORT, 4)) = 0;
			ID3D10Device1* d3D10Device2 = m_D3D10Device;
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint, D3D10_VIEWPORT*, void>)(*(ulong*)(*(long*)d3D10Device2 + 240)))((nint)d3D10Device2, 1u, &d3D10_VIEWPORT);
			GC.KeepAlive(this);
			return 0;
		}
	}

	private void RenderToDXGI(nint pdxgiSurface, [MarshalAs(UnmanagedType.U1)] bool isNewSurface)
	{
		if (null != m_renderD2D)
		{
			m_renderD2D(pdxgiSurface, isNewSurface);
		}
		GC.KeepAlive(this);
	}

	private unsafe void CleanupD3D10()
	{
		//IL_0019: Expected I, but got I8
		//IL_0022: Expected I, but got I8
		ID3D10Device1* d3D10Device = m_D3D10Device;
		if (0L != (nint)d3D10Device)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)d3D10Device + 16)))((nint)d3D10Device);
			m_D3D10Device = null;
		}
	}

	private unsafe int InitD3D9()
	{
		//IL_002a: Expected I4, but got I8
		//IL_007a: Expected I, but got I8
		//IL_007a: Expected I, but got I8
		fixed (IDirect3D9Ex** pD3D = &m_pD3D9)
		{
			global::_003CModule_003E.Direct3DCreate9Ex(32u, pD3D);
			if (m_pD3D9 == null)
			{
				return -2147467259;
			}
			Unsafe.SkipInit(out _D3DPRESENT_PARAMETERS_ d3DPRESENT_PARAMETERS_);
			// IL initblk instruction
			Unsafe.InitBlock(ref d3DPRESENT_PARAMETERS_, 0, 64);
			Unsafe.As<_D3DPRESENT_PARAMETERS_, int>(ref Unsafe.AddByteOffset(ref d3DPRESENT_PARAMETERS_, 40)) = 1;
			Unsafe.As<_D3DPRESENT_PARAMETERS_, int>(ref Unsafe.AddByteOffset(ref d3DPRESENT_PARAMETERS_, 24)) = 1;
			Unsafe.As<_D3DPRESENT_PARAMETERS_, long>(ref Unsafe.AddByteOffset(ref d3DPRESENT_PARAMETERS_, 32)) = 0L;
			Unsafe.As<_D3DPRESENT_PARAMETERS_, int>(ref Unsafe.AddByteOffset(ref d3DPRESENT_PARAMETERS_, 60)) = int.MinValue;
			fixed (IDirect3DDevice9Ex** pD3D9Device = &m_pD3D9Device)
			{
				IDirect3D9Ex* pD3D2 = m_pD3D9;
				int result = ((delegate* unmanaged[Cdecl, Cdecl]<nint, uint, _D3DDEVTYPE, HWND__*, uint, _D3DPRESENT_PARAMETERS_*, D3DDISPLAYMODEEX*, IDirect3DDevice9Ex**, int>)(*(ulong*)(*(long*)pD3D2 + 160)))((nint)pD3D2, 0u, (_D3DDEVTYPE)1, m_hwnd, 70u, &d3DPRESENT_PARAMETERS_, null, pD3D9Device);
				GC.KeepAlive(this);
				return result;
			}
		}
	}

	private unsafe void CleanupD3D9()
	{
		//IL_0019: Expected I, but got I8
		//IL_0022: Expected I, but got I8
		//IL_003b: Expected I, but got I8
		//IL_0044: Expected I, but got I8
		IDirect3DDevice9Ex* pD3D9Device = m_pD3D9Device;
		if (0L != (nint)pD3D9Device)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)pD3D9Device + 16)))((nint)pD3D9Device);
			m_pD3D9Device = null;
		}
		IDirect3D9Ex* pD3D = m_pD3D9;
		if (0L != (nint)pD3D)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)pD3D + 16)))((nint)pD3D);
			m_pD3D9 = null;
		}
	}

	private unsafe void CleanupSurfaces()
	{
		//IL_0023: Expected I, but got I8
		//IL_002c: Expected I, but got I8
		//IL_0048: Expected I, but got I8
		//IL_0051: Expected I, but got I8
		//IL_006a: Expected I, but got I8
		//IL_0073: Expected I, but got I8
		//IL_008c: Expected I, but got I8
		//IL_0095: Expected I, but got I8
		//IL_00ae: Expected I, but got I8
		//IL_00b7: Expected I, but got I8
		//IL_00d0: Expected I, but got I8
		//IL_00d9: Expected I, but got I8
		m_areSurfacesInitialized = false;
		ISurfaceProducer* bAProducer = m_BAProducer;
		if (0L != (nint)bAProducer)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)bAProducer + 16)))((nint)bAProducer);
			m_BAProducer = null;
		}
		ISurfaceProducer* aBProducer = m_ABProducer;
		if (0L != (nint)aBProducer)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)aBProducer + 16)))((nint)aBProducer);
			m_ABProducer = null;
		}
		ISurfaceConsumer* bAConsumer = m_BAConsumer;
		if (0L != (nint)bAConsumer)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)bAConsumer + 16)))((nint)bAConsumer);
			m_BAConsumer = null;
		}
		ISurfaceConsumer* aBConsumer = m_ABConsumer;
		if (0L != (nint)aBConsumer)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)aBConsumer + 16)))((nint)aBConsumer);
			m_ABConsumer = null;
		}
		ISurfaceQueue* aBQueue = m_ABQueue;
		if (0L != (nint)aBQueue)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)aBQueue + 16)))((nint)aBQueue);
			m_ABQueue = null;
		}
		ISurfaceQueue* bAQueue = m_BAQueue;
		if (0L != (nint)bAQueue)
		{
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)bAQueue + 16)))((nint)bAQueue);
			m_BAQueue = null;
		}
	}

	private void CleanupD3D()
	{
		if (m_areSurfacesInitialized)
		{
			CleanupSurfaces();
		}
		m_isD3DInitialized = false;
		CleanupD3D10();
		CleanupD3D9();
	}

	private int InitD3D()
	{
		int num = 0;
		if (!m_isD3DInitialized)
		{
			num = InitD3D9();
			if (num >= 0)
			{
				num = InitD3D10();
				if (num >= 0)
				{
					m_isD3DInitialized = true;
					goto IL_002f;
				}
			}
			CleanupD3D();
		}
		goto IL_002f;
		IL_002f:
		return num;
	}

	private unsafe int InitSurfaces()
	{
		//IL_000d: Expected I4, but got I8
		//IL_0047: Expected I4, but got I8
		//IL_00c5: Expected I, but got I8
		//IL_00f8: Expected I, but got I8
		//IL_0128: Expected I, but got I8
		//IL_0155: Expected I, but got I8
		//IL_0182: Expected I, but got I8
		//The blocks IL_0192 are reachable both inside and outside the pinned region starting at IL_0081. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0192 are reachable both inside and outside the pinned region starting at IL_00a4. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0192 are reachable both inside and outside the pinned region starting at IL_00d3. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0192 are reachable both inside and outside the pinned region starting at IL_0106. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0192 are reachable both inside and outside the pinned region starting at IL_0133. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0192 are reachable both inside and outside the pinned region starting at IL_0160. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		int result = 0;
		Unsafe.SkipInit(out SURFACE_QUEUE_DESC sURFACE_QUEUE_DESC);
		// IL initblk instruction
		Unsafe.InitBlockUnaligned(ref sURFACE_QUEUE_DESC, 0, 24);
		*(uint*)(&sURFACE_QUEUE_DESC) = m_pixelWidth;
		Unsafe.As<SURFACE_QUEUE_DESC, uint>(ref Unsafe.AddByteOffset(ref sURFACE_QUEUE_DESC, 4)) = m_pixelHeight;
		Unsafe.As<SURFACE_QUEUE_DESC, int>(ref Unsafe.AddByteOffset(ref sURFACE_QUEUE_DESC, 8)) = 87;
		Unsafe.As<SURFACE_QUEUE_DESC, int>(ref Unsafe.AddByteOffset(ref sURFACE_QUEUE_DESC, 12)) = 1;
		Unsafe.As<SURFACE_QUEUE_DESC, int>(ref Unsafe.AddByteOffset(ref sURFACE_QUEUE_DESC, 16)) = 4;
		Unsafe.As<SURFACE_QUEUE_DESC, int>(ref Unsafe.AddByteOffset(ref sURFACE_QUEUE_DESC, 20)) = 2;
		Unsafe.SkipInit(out SURFACE_QUEUE_CLONE_DESC sURFACE_QUEUE_CLONE_DESC);
		// IL initblk instruction
		Unsafe.InitBlockUnaligned(ref sURFACE_QUEUE_CLONE_DESC, 0, 8);
		*(int*)(&sURFACE_QUEUE_CLONE_DESC) = 0;
		Unsafe.As<SURFACE_QUEUE_CLONE_DESC, int>(ref Unsafe.AddByteOffset(ref sURFACE_QUEUE_CLONE_DESC, 4)) = 2;
		if (m_isD3DInitialized && *(int*)(&sURFACE_QUEUE_DESC) != 0 && Unsafe.As<SURFACE_QUEUE_DESC, int>(ref Unsafe.AddByteOffset(ref sURFACE_QUEUE_DESC, 4)) != 0)
		{
			if (!m_areSurfacesInitialized)
			{
				fixed (ISurfaceQueue** aBQueue = &m_ABQueue)
				{
					result = global::_003CModule_003E.CreateSurfaceQueue(&sURFACE_QUEUE_DESC, (IUnknown*)m_pD3D9Device, aBQueue);
					if (result >= 0)
					{
						fixed (ISurfaceQueue** bAQueue = &m_BAQueue)
						{
							ISurfaceQueue* aBQueue2 = m_ABQueue;
							result = ((delegate* unmanaged[Cdecl, Cdecl]<nint, SURFACE_QUEUE_CLONE_DESC*, ISurfaceQueue**, int>)(*(ulong*)(*(long*)aBQueue2 + 40)))((nint)aBQueue2, &sURFACE_QUEUE_CLONE_DESC, bAQueue);
							if (result >= 0)
							{
								fixed (ISurfaceProducer** bAProducer = &m_BAProducer)
								{
									ISurfaceQueue* bAQueue2 = m_BAQueue;
									result = ((delegate* unmanaged[Cdecl, Cdecl]<nint, IUnknown*, ISurfaceProducer**, int>)(*(ulong*)(*(long*)bAQueue2 + 24)))((nint)bAQueue2, (IUnknown*)m_D3D10Device, bAProducer);
									if (result >= 0)
									{
										fixed (ISurfaceConsumer** aBConsumer = &m_ABConsumer)
										{
											ISurfaceQueue* aBQueue3 = m_ABQueue;
											result = ((delegate* unmanaged[Cdecl, Cdecl]<nint, IUnknown*, ISurfaceConsumer**, int>)(*(ulong*)(*(long*)aBQueue3 + 32)))((nint)aBQueue3, (IUnknown*)m_D3D10Device, aBConsumer);
											if (result >= 0)
											{
												fixed (ISurfaceProducer** aBProducer = &m_ABProducer)
												{
													ISurfaceQueue* aBQueue4 = m_ABQueue;
													result = ((delegate* unmanaged[Cdecl, Cdecl]<nint, IUnknown*, ISurfaceProducer**, int>)(*(ulong*)(*(long*)aBQueue4 + 24)))((nint)aBQueue4, (IUnknown*)m_pD3D9Device, aBProducer);
													if (result >= 0)
													{
														fixed (ISurfaceConsumer** bAConsumer = &m_BAConsumer)
														{
															ISurfaceQueue* bAQueue3 = m_BAQueue;
															result = ((delegate* unmanaged[Cdecl, Cdecl]<nint, IUnknown*, ISurfaceConsumer**, int>)(*(ulong*)(*(long*)bAQueue3 + 32)))((nint)bAQueue3, (IUnknown*)m_pD3D9Device, bAConsumer);
															if (result >= 0)
															{
																m_areSurfacesInitialized = true;
															}
															return result;
														}
													}
													return result;
												}
											}
											return result;
										}
									}
									return result;
								}
							}
							return result;
						}
					}
					return result;
				}
			}
		}
		else
		{
			result = 1;
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private unsafe bool Initialize()
	{
		//IL_0023: Expected I, but got I8
		//IL_0023: Expected I, but got I8
		int num = 0;
		if (m_isD3DInitialized)
		{
			IDirect3DDevice9Ex* pD3D9Device = m_pD3D9Device;
			num = ((delegate* unmanaged[Cdecl, Cdecl]<nint, HWND__*, int>)(*(ulong*)(*(long*)pD3D9Device + 1024)))((nint)pD3D9Device, null);
			if (0 != num)
			{
				CleanupD3D();
			}
		}
		if (!m_isD3DInitialized)
		{
			num = InitD3D();
			if (num < 0)
			{
				goto IL_0054;
			}
		}
		if (!m_areSurfacesInitialized)
		{
			num = InitSurfaces();
		}
		if (num < 0)
		{
			goto IL_0054;
		}
		goto IL_005a;
		IL_0054:
		CleanupD3D();
		goto IL_005a;
		IL_005a:
		return m_areSurfacesInitialized;
	}

	private unsafe void QueueHelper(QueueRenderMode renderMode)
	{
		//IL_0003: Expected I, but got I8
		//IL_0007: Expected I, but got I8
		//IL_000a: Expected I, but got I8
		//IL_000e: Expected I, but got I8
		//IL_0012: Expected I, but got I8
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected I, but got I8
		//IL_006b: Expected I, but got I8
		//IL_008f: Expected I, but got I8
		//IL_0202: Expected I, but got I8
		//IL_0207: Expected I, but got I8
		//IL_00a7: Expected I, but got I8
		//IL_0219: Expected I, but got I8
		//IL_021d: Expected I, but got I8
		//IL_00bc: Expected I, but got I8
		//IL_0231: Expected I, but got I8
		//IL_0236: Expected I, but got I8
		//IL_0248: Expected I, but got I8
		//IL_024c: Expected I, but got I8
		//IL_00f9: Expected I, but got I8
		//IL_00f9: Expected I, but got I8
		//IL_0111: Expected I, but got I8
		//IL_0111: Expected I, but got I8
		//IL_0135: Expected I, but got I8
		//IL_0135: Expected I, but got I8
		//IL_0135: Expected I, but got I8
		//IL_0260: Expected I, but got I8
		//IL_0265: Expected I, but got I8
		//IL_014d: Expected I, but got I8
		//IL_0163: Expected I, but got I8
		//IL_019a: Expected I, but got I8
		//IL_01b2: Expected I, but got I8
		//IL_01b2: Expected I, but got I8
		IDXGISurface* ptr = null;
		IUnknown* ptr2 = null;
		IDirect3DTexture9* ptr3 = null;
		IUnknown* ptr4 = null;
		IDirect3DSurface9* ptr5 = null;
		int num = 0;
		uint num2 = 4u;
		bool isNewSurface = !m_areSurfacesInitialized;
		bool flag;
		if (!m_shouldSkipRender && null != m_d3dImage)
		{
			if (Initialize())
			{
				m_d3dImage.Lock();
				flag = true;
				ISurfaceProducer* aBProducer = m_ABProducer;
				((delegate* unmanaged[Cdecl, Cdecl]<nint, uint, uint*, int>)(*(ulong*)(*(long*)aBProducer + 32)))((nint)aBProducer, 0u, null);
				ISurfaceConsumer* aBConsumer = m_ABConsumer;
				Unsafe.SkipInit(out DXGI_SURFACE_DESC dXGI_SURFACE_DESC);
				if (((delegate* unmanaged[Cdecl, Cdecl]<nint, _GUID*, IUnknown**, void*, uint*, uint, int>)(*(ulong*)(*(long*)aBConsumer + 24)))((nint)aBConsumer, global::_003CModule_003E.surfaceIDDXGI, &ptr2, &num, &num2, uint.MaxValue) >= 0 && ((delegate* unmanaged[Cdecl, Cdecl]<nint, _GUID*, void**, int>)(*(ulong*)(*(ulong*)ptr2)))((nint)ptr2, global::_003CModule_003E.surfaceIDDXGI, (void**)(&ptr)) >= 0 && ((delegate* unmanaged[Cdecl, Cdecl]<nint, DXGI_SURFACE_DESC*, int>)(*(ulong*)(*(long*)ptr + 64)))((nint)ptr, &dXGI_SURFACE_DESC) >= 0)
				{
					if (renderMode == QueueRenderMode.RenderDXGI)
					{
						try
						{
							nint pdxgiSurface = (nint)(void*)ptr;
							RenderToDXGI(pdxgiSurface, isNewSurface);
						}
						catch (Exception)
						{
							goto IL_01b3;
						}
					}
					ISurfaceProducer* bAProducer = m_BAProducer;
					((delegate* unmanaged[Cdecl, Cdecl]<nint, IUnknown*, void*, uint, uint, int>)(*(ulong*)(*(long*)bAProducer + 24)))((nint)bAProducer, (IUnknown*)ptr, null, 0u, 1u);
					bAProducer = m_BAProducer;
					((delegate* unmanaged[Cdecl, Cdecl]<nint, uint, uint*, int>)(*(ulong*)(*(long*)bAProducer + 32)))((nint)bAProducer, 0u, null);
					ISurfaceConsumer* bAConsumer = m_BAConsumer;
					if (((delegate* unmanaged[Cdecl, Cdecl]<nint, _GUID*, IUnknown**, void*, uint*, uint, int>)(*(ulong*)(*(long*)bAConsumer + 24)))((nint)bAConsumer, global::_003CModule_003E.surfaceID9, &ptr4, null, null, uint.MaxValue) >= 0 && ((delegate* unmanaged[Cdecl, Cdecl]<nint, _GUID*, void**, int>)(*(ulong*)(*(ulong*)ptr4)))((nint)ptr4, global::_003CModule_003E.surfaceID9, (void**)(&ptr3)) >= 0 && ((delegate* unmanaged[Cdecl, Cdecl]<nint, uint, IDirect3DSurface9**, int>)(*(ulong*)(*(long*)ptr3 + 144)))((nint)ptr3, 0u, &ptr5) >= 0)
					{
						nint backBuffer = (nint)(void*)ptr5;
						m_d3dImage.SetBackBuffer(D3DResourceType.IDirect3DSurface9, backBuffer, enableSoftwareFallback: true);
						ISurfaceProducer* aBProducer2 = m_ABProducer;
						((delegate* unmanaged[Cdecl, Cdecl]<nint, IUnknown*, void*, uint, uint, int>)(*(ulong*)(*(long*)aBProducer2 + 24)))((nint)aBProducer2, (IUnknown*)ptr3, &num, 4u, 1u);
						aBProducer = m_ABProducer;
						((delegate* unmanaged[Cdecl, Cdecl]<nint, uint, uint*, int>)(*(ulong*)(*(long*)aBProducer + 32)))((nint)aBProducer, 1u, null);
					}
					goto IL_01b3;
				}
				goto IL_01b7;
			}
			goto IL_01ee;
		}
		goto IL_0265;
		IL_01b7:
		Unsafe.SkipInit(out Int32Rect dirtyRect);
		((Int32Rect)(ref dirtyRect))._002Ector(0, 0, m_d3dImage.PixelWidth, m_d3dImage.PixelHeight);
		m_d3dImage.AddDirtyRect(dirtyRect);
		m_d3dImage.Unlock();
		goto IL_01ee;
		IL_01ee:
		if (0L != (nint)ptr5)
		{
			IDirect3DSurface9* intPtr = ptr5;
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)intPtr + 16)))((nint)intPtr);
			ptr5 = null;
		}
		if (0L != (nint)ptr3)
		{
			IDirect3DTexture9* intPtr2 = ptr3;
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)intPtr2 + 16)))((nint)intPtr2);
			ptr3 = null;
		}
		if (0L != (nint)ptr4)
		{
			IUnknown* intPtr3 = ptr4;
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)intPtr3 + 16)))((nint)intPtr3);
			ptr4 = null;
		}
		if (0L != (nint)ptr)
		{
			IDXGISurface* intPtr4 = ptr;
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)intPtr4 + 16)))((nint)intPtr4);
			ptr = null;
		}
		if (0L != (nint)ptr2)
		{
			IUnknown* intPtr5 = ptr2;
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)intPtr5 + 16)))((nint)intPtr5);
			ptr2 = null;
		}
		goto IL_0265;
		IL_01b3:
		if (flag)
		{
			goto IL_01b7;
		}
		goto IL_01ee;
		IL_0265:
		GC.KeepAlive(this);
	}

	public void SetPixelSize(uint pixelWidth, uint pixelHeight)
	{
		if (m_pixelWidth != pixelWidth || m_pixelHeight != pixelHeight)
		{
			m_pixelWidth = pixelWidth;
			m_pixelHeight = pixelHeight;
			CleanupSurfaces();
			QueueHelper(QueueRenderMode.RenderDXGI);
		}
	}

	public void RequestRenderD2D()
	{
		QueueHelper(QueueRenderMode.RenderDXGI);
	}

	private void _0021SurfaceQueueInteropHelper()
	{
		CleanupD3D();
	}

	private void _007ESurfaceQueueInteropHelper()
	{
		CleanupD3D();
	}

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_007ESurfaceQueueInteropHelper();
			return;
		}
		try
		{
			_0021SurfaceQueueInteropHelper();
		}
		finally
		{
			base.Finalize();
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
		GC.KeepAlive(this);
	}

	~SurfaceQueueInteropHelper()
	{
		Dispose(A_0: false);
	}
}
