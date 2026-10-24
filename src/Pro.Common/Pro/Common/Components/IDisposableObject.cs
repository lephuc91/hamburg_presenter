using System;

namespace Pro.Common.Components;

public interface IDisposableObject : IDisposable
{
	bool IsDisposed { get; }
}
