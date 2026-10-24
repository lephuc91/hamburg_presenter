using System;
using System.Runtime.InteropServices;

namespace CoreRegistrationClient;

public interface IRegistrationInteractor : IDisposable
{
	void Start(byte[] startupConfig);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Send(byte[] serializedData);
}
