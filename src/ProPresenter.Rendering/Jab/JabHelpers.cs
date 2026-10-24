using System;
using System.CodeDom.Compiler;

namespace Jab;

[GeneratedCode("Jab", null)]
internal static class JabHelpers
{
	public static InvalidOperationException CreateServiceNotFoundException<T>(string? name = null)
	{
		return CreateServiceNotFoundException(typeof(T), name);
	}

	public static InvalidOperationException CreateServiceNotFoundException(Type type, string? name = null)
	{
		return new InvalidOperationException((name != null) ? $"Service with type {type} and name {name} not registered" : $"Service with type {type} not registered");
	}
}
