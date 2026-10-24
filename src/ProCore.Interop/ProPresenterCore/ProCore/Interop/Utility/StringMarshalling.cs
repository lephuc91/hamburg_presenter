using System;
using System.Text;

namespace ProPresenterCore.ProCore.Interop.Utility;

public static class StringMarshalling
{
	public unsafe static string StringFromCString(nint charPtr)
	{
		return StringFromCString((sbyte*)((IntPtr)charPtr).ToPointer());
	}

	public unsafe static string StringFromCString(sbyte* charPtr)
	{
		if (charPtr == (sbyte*)IntPtr.Zero)
		{
			return string.Empty;
		}
		sbyte* ptr;
		for (ptr = charPtr; *ptr != 0; ptr++)
		{
		}
		return new string(charPtr, 0, (int)(ptr - charPtr), Encoding.UTF8);
	}

	public unsafe static nint StringToCString(string str)
	{
		if (str == null)
		{
			return IntPtr.Zero;
		}
		int num = Encoding.UTF8.GetByteCount(str) + 1;
		byte* ptr = (byte*)((IntPtr)ProCore.DataTransferAlloc((uint)num)).ToPointer();
		int length = str.Length;
		fixed (char* chars = str)
		{
			Encoding.UTF8.GetBytes(chars, length, ptr, num);
		}
		ptr[num - 1] = 0;
		return new IntPtr(ptr);
	}
}
