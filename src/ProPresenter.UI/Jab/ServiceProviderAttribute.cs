using System;
using System.CodeDom.Compiler;

namespace Jab;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class ServiceProviderAttribute : Attribute
{
	public Type[]? RootServices { get; set; }
}
