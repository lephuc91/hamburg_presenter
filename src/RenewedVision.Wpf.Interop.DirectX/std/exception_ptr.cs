using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace std;

[StructLayout(LayoutKind.Sequential, Size = 16)]
[NativeCppClass]
internal struct exception_ptr
{
	private long _003Calignment_0020member_003E;

	[SpecialName]
	public unsafe static void _003CMarshalCopy_003E(exception_ptr* A_0, exception_ptr* A_1)
	{
		if (A_0 != null)
		{
			*(long*)A_0 = 0L;
			*(long*)((ulong)(nint)A_0 + 8uL) = 0L;
			global::_003CModule_003E.__ExceptionPtrCopy(A_0, A_1);
		}
	}

	[SpecialName]
	public unsafe static void _003CMarshalDestroy_003E(exception_ptr* A_0)
	{
		global::_003CModule_003E.__ExceptionPtrDestroy(A_0);
	}
}
