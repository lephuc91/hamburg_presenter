using System;
using System.CodeDom.Compiler;

namespace Jab;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class FromNamedServicesAttribute : Attribute
{
	public string? Name { get; set; }

	public FromNamedServicesAttribute(string name)
	{
		Name = name;
	}
}
