namespace CoreApplication;

public interface IManagedNativeCallbackReceiver
{
	void NativeCallback(nint instancePointer);

	void NativeCallback(byte[] protoData);

	void NativeErrorCallback();
}
