using System;

namespace Pro.Common.ObjectBinding;

internal interface IBinding<LeftType, RightType> : IDisposable where LeftType : class where RightType : class
{
	string Tag { get; }

	void ReplaceLeft(LeftType? left);

	void ReplaceRight(RightType? right);

	IDisposable SuspendSubscriptions();

	void ExecuteLeftChanged();

	void ExecuteRightChanged();
}
