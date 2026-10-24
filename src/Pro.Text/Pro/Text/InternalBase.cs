using System;
using Pro.Common.Components;

namespace Pro.Text;

public abstract class InternalBase : DisposableBase
{
	private nint _handle;

	internal nint Handle => _handle;

	internal InternalBase(nint handle)
	{
		_handle = handle;
	}

	protected abstract void Destroy();

	protected override void OnDispose(bool disposeObjects)
	{
		if (_handle != IntPtr.Zero)
		{
			Destroy();
		}
	}
}
