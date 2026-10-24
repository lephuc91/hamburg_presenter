using System;
using System.Reflection;
using Pro.Common.Versioning;

namespace ProPresenter.Versioning;

public class AssemblyInfoProvider : IAssemblyInfoProvider
{
	private readonly Assembly? _assembly;

	public Version? Version => _assembly?.GetName().Version;

	public string Location => _assembly?.Location ?? string.Empty;

	public AssemblyInfoProvider(Assembly? assembly)
	{
		_assembly = assembly;
	}

	public T? GetCustomAttribute<T>() where T : Attribute
	{
		Assembly? assembly = _assembly;
		if ((object)assembly == null)
		{
			return null;
		}
		return assembly.GetCustomAttribute<T>();
	}
}
