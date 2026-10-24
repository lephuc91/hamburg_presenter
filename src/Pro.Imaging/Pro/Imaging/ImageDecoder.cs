using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using std;

namespace Pro.Imaging;

public class ImageDecoder : IImageDecoder
{
	public unsafe virtual void DecodeImage(byte[] data, BitmapDecodedDelegate onDecodeComplete)
	{
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(data);
		try
		{
			obj = obj2;
			ulong num = (ulong)obj.Length();
			Unsafe.SkipInit(out int width);
			Unsafe.SkipInit(out int height);
			byte* ptr = global::_003CModule_003E.WebPDecodeBGRA(obj.Get(), num, &width, &height);
			if (ptr == null)
			{
				throw new Exception("Failed to decode image");
			}
			try
			{
				nint data2 = new IntPtr(ptr);
				onDecodeComplete(data2, width, height, PixelFormat.Bgra32);
			}
			finally
			{
				global::_003CModule_003E.WebPFree(ptr);
			}
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
	}

	public unsafe virtual void DecodeAnimation(byte[] data, AnimationFrameDecodedDelegate onDecodeComplete)
	{
		//IL_000a: Expected I8, but got I
		//IL_0176: Expected I, but got I8
		//IL_013b: Expected I, but got I8
		//IL_0149: Expected I, but got I8
		//IL_0059: Expected I, but got I8
		//IL_0067: Expected I, but got I8
		//IL_0067: Expected I, but got I8
		//IL_0070: Expected I, but got I8
		//IL_0080: Expected I, but got I8
		//IL_0080: Expected I, but got I8
		//IL_008c: Expected I, but got I8
		//IL_009f: Expected I, but got I8
		//IL_009f: Expected I, but got I8
		//IL_00d3: Expected I, but got I8
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		long num = (nint)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		Unsafe.SkipInit(out runtime_error* ptr6);
		try
		{
			PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(data);
			try
			{
				obj = obj2;
				ulong num2 = (ulong)obj.Length();
				Unsafe.SkipInit(out unique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E obj3);
				unique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E* right = global::_003CModule_003E.Pro_002EImaging_002EAnimationDecoderFactory_002ECreate(&obj3, obj.Get(), num2, (WEBP_CSP_MODE)3);
				Unsafe.SkipInit(out unique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E obj4);
				try
				{
					global::_003CModule_003E.std_002Eunique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cclass_0020Pro_003A_003AImaging_003A_003AAnimationDecoder_003E_002C0_003E(&obj4, right);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E_002E_007Bdtor_007D), &obj3);
					throw;
				}
				try
				{
					if (*(long*)(&obj3) != 0L)
					{
						default_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E* ptr = (default_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E*)(&obj3);
						AnimationDecoder* ptr2 = (AnimationDecoder*)(*(ulong*)(&obj3));
						void* ptr3 = ((delegate* unmanaged[Cdecl, Cdecl]<nint, uint, void*>)(*(ulong*)(*(ulong*)(*(ulong*)(&obj3)))))((nint)(*(long*)(&obj3)), 1u);
					}
					int num3 = 0;
					Unsafe.SkipInit(out AnimationFrame animationFrame);
					Unsafe.SkipInit(out exception exception);
					while (true)
					{
						AnimationDecoder* ptr4 = (AnimationDecoder*)(*(ulong*)(&obj4));
						if (((delegate* unmanaged[Cdecl, Cdecl]<nint, byte>)(*(ulong*)(*(long*)(*(ulong*)(&obj4)) + 8)))((nint)(*(long*)(&obj4))) == 0)
						{
							break;
						}
						AnimationDecoder* ptr5 = (AnimationDecoder*)(*(ulong*)(&obj4));
						if (((delegate* unmanaged[Cdecl, Cdecl]<nint, AnimationFrame*, byte>)(*(ulong*)(*(long*)(*(ulong*)(&obj4)) + 16)))((nint)(*(long*)(&obj4)), &animationFrame) == 0)
						{
							global::_003CModule_003E.std_002Eexception_002E_007Bctor_007D(&exception, (sbyte*)Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0CB_0040NCNHCNPL_0040Failed_003F5to_003F5decode_003F5animation_003F5fram_0040));
							global::_003CModule_003E._CxxThrowException(&exception, (_s__ThrowInfo*)Unsafe.AsPointer(ref global::_003CModule_003E._TI1_003FAVexception_0040std_0040_0040));
						}
						int duration = Unsafe.As<AnimationFrame, int>(ref Unsafe.AddByteOffset(ref animationFrame, 8)) - num3;
						num3 = Unsafe.As<AnimationFrame, int>(ref Unsafe.AddByteOffset(ref animationFrame, 8));
						nint data2 = new IntPtr((void*)(*(ulong*)(&animationFrame)));
						onDecodeComplete(data2, Unsafe.As<AnimationFrame, int>(ref Unsafe.AddByteOffset(ref animationFrame, 12)), Unsafe.As<AnimationFrame, int>(ref Unsafe.AddByteOffset(ref animationFrame, 16)), PixelFormat.Bgra32, duration);
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E_002E_007Bdtor_007D), &obj4);
					throw;
				}
				global::_003CModule_003E.std_002Eunique_ptr_003CPro_003A_003AImaging_003A_003AAnimationDecoder_002Cstd_003A_003Adefault_delete_003CPro_003A_003AImaging_003A_003AAnimationDecoder_003E_0020_003E_002E_007Bdtor_007D(&obj4);
			}
			catch
			{
				//try-fault
				((IDisposable)obj).Dispose();
				throw;
			}
			((IDisposable)obj).Dispose();
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVruntime_error_0040std_0040_0040_00408), 9, &ptr6) != 0)
		{
			uint num4 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					runtime_error* intPtr = ptr6;
					throw new Exception(new string(((delegate* unmanaged[Cdecl, Cdecl]<nint, sbyte*>)(*(ulong*)(*(long*)intPtr + 8)))((nint)intPtr)));
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num4 != 0;
				}).Invoke())
				{
				}
				if (num4 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
			}
		}
	}
}
