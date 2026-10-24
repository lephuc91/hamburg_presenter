using System.CodeDom.Compiler;

namespace Jab;

[GeneratedCode("Jab", null)]
internal interface IServiceProvider<T>
{
	T GetService();
}
