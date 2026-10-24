using System;

namespace Pro.Interprocess;

public interface IInstanceValidator : IDisposable
{
	bool IsUnique { get; }
}
