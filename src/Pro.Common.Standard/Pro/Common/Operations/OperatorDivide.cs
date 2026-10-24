using System;
using System.Linq.Expressions;
using Pro.Common.Utility;

namespace Pro.Common.Operations;

internal static class OperatorDivide<T>
{
	public static readonly Func<T, T, T> Invoke = ExpressionHelper.CreateExpression<T, T, T>(Expression.Divide);
}
