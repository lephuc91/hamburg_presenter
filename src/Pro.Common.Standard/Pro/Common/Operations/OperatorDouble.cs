using System;
using System.Linq.Expressions;
using Pro.Common.Utility;

namespace Pro.Common.Operations;

internal static class OperatorDouble<T>
{
	public static readonly Func<T, T> Invoke = ExpressionHelper.CreateExpression<T, T>(Expression.Multiply, 2);
}
