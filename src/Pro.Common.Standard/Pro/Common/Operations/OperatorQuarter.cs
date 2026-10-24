using System;
using System.Linq.Expressions;
using Pro.Common.Utility;

namespace Pro.Common.Operations;

internal static class OperatorQuarter<T>
{
	public static readonly Func<T, T> Invoke = ExpressionHelper.CreateExpression<T, T>(Expression.Divide, 4);
}
