using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CoreRegistrationClient;

[StructLayout(LayoutKind.Sequential, Size = 40)]
[NativeCppClass]
[UnsafeValueType]
internal struct UnmanagedSendResult
{
	private long _003Calignment_0020member_003E;
}
