using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Pro.Common.Components;

namespace Pro.Interprocess;

public class InstanceValidator : DisposableBase, IInstanceValidator, IDisposable
{
	private readonly Mutex _lock;

	public bool IsUnique { get; }

	public InstanceValidator()
		: this(new Guid(Assembly.GetEntryAssembly().GetCustomAttribute<GuidAttribute>().Value))
	{
	}

	public InstanceValidator(Guid id)
	{
		_lock = new Mutex(initiallyOwned: true, id.ToString().ToUpperInvariant(), out var createdNew);
		IsUnique = createdNew;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			_lock.Dispose();
		}
	}
}
