namespace CoreRegistrationClient;

public interface IManagedNativeCallbackReceiver
{
	unsafe void NativeCallback(byte* buf, ulong size);
}
