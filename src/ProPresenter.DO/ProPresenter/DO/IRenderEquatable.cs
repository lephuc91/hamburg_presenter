using System.Diagnostics.CodeAnalysis;

namespace ProPresenter.DO;

public interface IRenderEquatable<in T> : IRenderHashable where T : class
{
	bool RenderEquals([NotNullWhen(true)] T? other);
}
