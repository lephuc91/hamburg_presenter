using System;

namespace Pro.Common.Versioning;

public interface IAssemblyInfoProvider
{
	Version? Version { get; }

	string Location { get; }

	T? GetCustomAttribute<T>() where T : Attribute;
}
