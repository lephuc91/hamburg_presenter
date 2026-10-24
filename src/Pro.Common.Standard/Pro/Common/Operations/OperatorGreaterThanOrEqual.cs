using System;
using System.Linq.Expressions;
using Pro.Common.Utility;

namespace Pro.Common.Operations;

internal static class OperatorGreaterThanOrEqual<T>
{
	public static readonly Func<T, T, bool> Invoke = ExpressionHelper.CreateExpression<T, T, bool>(Expression.GreaterThanOrEqual);
}
