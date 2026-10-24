using System;
using System.IO;
using Pro.Common.Components;

namespace Pro.Common.Utility;

public abstract class StreamCopy : DisposableBase
{
	protected Stream Source { get; }

	protected Stream Destination { get; }

	protected abstract long SourceLength { get; }

	protected StreamCopy(Stream source, Stream destination)
	{
		Source = source;
		Destination = destination;
	}

	public void Copy(Action? onStart, Action<double>? onProgressChanged, Action<bool>? onComplete)
	{
		bool flag = true;
		byte[] array = new byte[1048576];
		try
		{
			onStart?.Invoke();
			long sourceLength = SourceLength;
			if (sourceLength > 0)
			{
				int num = 0;
				int num2 = 0;
				while ((num2 = Source.Read(array, 0, array.Length)) > 0)
				{
					num += num2;
					double obj = (double)num * 100.0 / (double)sourceLength;
					Destination.Write(array, 0, num2);
					onProgressChanged?.Invoke(obj);
				}
			}
		}
		catch
		{
			flag = false;
		}
		finally
		{
			Source.Close();
			Destination.Close();
			OnComplete(flag);
			onComplete?.Invoke(flag);
		}
	}

	protected virtual void OnComplete(bool didSucceed)
	{
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			Source.Dispose();
			Destination.Dispose();
		}
	}
}
