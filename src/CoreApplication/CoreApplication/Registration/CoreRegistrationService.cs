using System;

namespace CoreApplication.Registration;

public abstract class CoreRegistrationService
{
	public unsafe void SendMessage(nint service, byte[] @params)
	{
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(@params);
		try
		{
			obj = obj2;
			ulong num = (ulong)obj.Length();
			byte* ptr = obj.Get();
			global::_003CModule_003E.RegistrationServiceExecuteCommand((RegistrationService*)((IntPtr)service).ToPointer(), ptr, num);
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
	}

	public CoreRegistrationService()
	{
	}
}
