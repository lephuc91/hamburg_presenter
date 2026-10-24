using System;
using System.Linq.Expressions;
using Pro.Common.Utility;

namespace Pro.Common.Operations;

internal static class OperatorInvert<T>
{
	public static readonly Func<T, T> Invoke = ExpressionHelper.CreateExpression<T, T>(Expression.Divide, 1, flipOrder: true);
}
