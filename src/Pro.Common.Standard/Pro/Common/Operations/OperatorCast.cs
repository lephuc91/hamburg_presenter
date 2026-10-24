using System;
using System.Linq.Expressions;
using Pro.Common.Utility;

namespace Pro.Common.Operations;

internal static class OperatorCast<T, K>
{
	public static readonly Func<K, T> Invoke = ExpressionHelper.CreateExpression<K, T>(Expression.Convert);
}
