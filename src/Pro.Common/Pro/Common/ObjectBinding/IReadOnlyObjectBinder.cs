using System;

namespace Pro.Common.ObjectBinding;

public interface IReadOnlyObjectBinder : IDisposable
{
	void InitializeLeftFromRight();

	void InitializeRightFromLeft();
}
public interface IReadOnlyObjectBinder<out LeftType, out RightType> : IReadOnlyObjectBinder, IDisposable where LeftType : class where RightType : class
{
	LeftType? Left { get; }

	RightType? Right { get; }
}
