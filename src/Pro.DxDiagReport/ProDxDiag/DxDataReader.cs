using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ProDxDiag;

[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal static struct DxDataReader
{
	[NativeCppClass]
	[CLSCompliant(false)]
	public enum ValueType
	{

	}

	[StructLayout(LayoutKind.Sequential, Size = 48)]
	[NativeCppClass]
	[CLSCompliant(false)]
	[UnsafeValueType]
	public struct Value
	{
		private long _003Calignment_0020member_003E;
	}

	private long _003Calignment_0020member_003E;
}
