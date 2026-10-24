using System.CodeDom.Compiler;

namespace Jab;

[GeneratedCode("Jab", null)]
internal interface INamedServiceProvider<T>
{
	T GetService(string name);
}
