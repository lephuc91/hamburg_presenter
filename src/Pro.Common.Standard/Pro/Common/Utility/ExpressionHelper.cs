using System;
using System.Linq.Expressions;

namespace Pro.Common.Utility;

public static class ExpressionHelper
{
	public static Func<TArg, TResult> CreateExpression<TArg, TResult>(Func<Expression, UnaryExpression> body)
	{
		try
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg));
			return Expression.Lambda<Func<TArg, TResult>>(body(parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
		}
		catch
		{
			return delegate
			{
				throw new NotSupportedException();
			};
		}
	}

	public static Func<TLhs, TRhs, TResult> CreateExpression<TLhs, TRhs, TResult>(Func<Expression, Expression, BinaryExpression> body)
	{
		try
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TLhs));
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TRhs));
			return Expression.Lambda<Func<TLhs, TRhs, TResult>>(body(parameterExpression, parameterExpression2), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
		}
		catch
		{
			return delegate
			{
				throw new NotSupportedException();
			};
		}
	}

	public static Func<TArg, TResult> CreateExpression<TArg, TResult>(Func<Expression, Type, Expression> body)
	{
		try
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg));
			return Expression.Lambda<Func<TArg, TResult>>(body(parameterExpression, typeof(TResult)), new ParameterExpression[1] { parameterExpression }).Compile();
		}
		catch
		{
			return delegate
			{
				throw new NotSupportedException();
			};
		}
	}

	public static Func<TArg, TResult> CreateExpression<TArg, TResult>(Func<Expression, Expression, BinaryExpression> body, object constant, bool flipOrder = false)
	{
		try
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg));
			UnaryExpression unaryExpression = Expression.Convert(Expression.Constant(constant), typeof(TArg));
			return Expression.Lambda<Func<TArg, TResult>>((!flipOrder) ? body(parameterExpression, unaryExpression) : body(unaryExpression, parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
		}
		catch
		{
			return delegate
			{
				throw new NotSupportedException();
			};
		}
	}

	public static MemberExpression GetMemberExpression<T>(Expression<Func<T, object>> expression)
	{
		MemberExpression memberExpression = null;
		if (expression.Body.NodeType == ExpressionType.Convert)
		{
			memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
		}
		else if (expression.Body.NodeType == ExpressionType.MemberAccess)
		{
			memberExpression = expression.Body as MemberExpression;
		}
		if (memberExpression == null)
		{
			throw new ArgumentException("Not a member access", "expression");
		}
		return memberExpression;
	}
}
