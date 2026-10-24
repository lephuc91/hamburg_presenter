using System;
using System.Threading.Tasks;
using CoreApplication;
using Pro.CoreApplication.Document;

namespace Pro.CoreApplication.CoreInteraction;

internal sealed class CallbackReceiver<TProtoResult> : IManagedNativeCallbackReceiver
{
	private readonly TaskCompletionSource<TProtoResult> _completor;

	private readonly Func<byte[], TProtoResult> _parser;

	public CallbackReceiver(TaskCompletionSource<TProtoResult> completor, Func<byte[], TProtoResult> parser)
	{
		_completor = completor;
		_parser = parser;
	}

	public void NativeCallback(nint instancePointer)
	{
		_completor.SetException(new DocumentApplicationException(instancePointer));
	}

	public void NativeCallback(byte[] protoData)
	{
		try
		{
			TProtoResult result = _parser(protoData);
			_completor.SetResult(result);
		}
		catch (Exception exception)
		{
			_completor.SetException(exception);
		}
	}

	public void NativeErrorCallback()
	{
		_completor.SetException(new DocumentApplicationException());
	}
}
