using System;

namespace Pro.Entity;

public interface IEntity : IDisposable
{
	void RegisterLinkedDisposable(IDisposable disposable);
}
