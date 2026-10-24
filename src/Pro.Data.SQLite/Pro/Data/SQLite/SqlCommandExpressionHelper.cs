using System;
using System.Collections;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Pro.Common.Nullability;

namespace Pro.Data.SQLite;

public static class SqlCommandExpressionHelper
{
	public static string CastString(string right, Type type)
	{
		return $"cast({right} AS {SqliteCommandHelper.GetSqlType(type)})";
	}

	public static string FormatValueString(object? value)
	{
		if (value == null)
		{
			return "NULL";
		}
		if (value is DBNull)
		{
			return "";
		}
		if (value is string || value is Guid || value is char)
		{
			return "'" + Convert.ToString(value)?.Replace("'", "''") + "'";
		}
		if (value is DateTime dateTime)
		{
			return ToSqlDate(dateTime);
		}
		return value.ToString() ?? string.Empty;
	}

	public static object GetValue(Expression member)
	{
		return Expression.Lambda<Func<object>>(Expression.Convert(member, typeof(object)), Array.Empty<ParameterExpression>()).Compile()();
	}

	public static object GetValue(MemberExpression member)
	{
		object obj = Expression.Lambda<Func<object>>(Expression.Convert(member, typeof(object)), Array.Empty<ParameterExpression>()).Compile()();
		if (member.Type.IsEnum)
		{
			return (int)obj;
		}
		return obj;
	}

	public static object NodeTypeToString(ExpressionType nodeType, bool rightIsNull)
	{
		switch (nodeType)
		{
		case ExpressionType.Add:
			return "+";
		case ExpressionType.And:
			return "&";
		case ExpressionType.AndAlso:
			return "AND";
		case ExpressionType.Divide:
			return "/";
		case ExpressionType.Equal:
			if (!rightIsNull)
			{
				return "=";
			}
			return "IS";
		case ExpressionType.ExclusiveOr:
			return "^";
		case ExpressionType.GreaterThan:
			return ">";
		case ExpressionType.GreaterThanOrEqual:
			return ">=";
		case ExpressionType.LessThan:
			return "<";
		case ExpressionType.LessThanOrEqual:
			return "<=";
		case ExpressionType.Modulo:
			return "%";
		case ExpressionType.Multiply:
			return "*";
		case ExpressionType.Negate:
			return "-";
		case ExpressionType.Not:
			return "NOT";
		case ExpressionType.NotEqual:
			if (!rightIsNull)
			{
				return "<>";
			}
			return "IS NOT";
		case ExpressionType.Or:
			return "|";
		case ExpressionType.OrElse:
			return "OR";
		case ExpressionType.Subtract:
			return "-";
		default:
			throw new Exception($"Unsupported node type: {nodeType}");
		}
	}

	public static string ParseExpression(Expression? expression, bool isUnary = false, Table? table = null)
	{
		if (!(expression is UnaryExpression unaryExpression))
		{
			if (!(expression is BinaryExpression binaryExpression))
			{
				if (!(expression is ConstantExpression constantExpression))
				{
					if (!(expression is MemberExpression memberExpression))
					{
						if (expression is MethodCallExpression methodCallExpression)
						{
							if (methodCallExpression.Method == typeof(string).GetMethod("Contains", new Type[1] { typeof(string) }))
							{
								return "(" + ParseExpression(methodCallExpression.Object) + " LIKE '%" + ParseExpression(methodCallExpression.Arguments[0]) + "%')";
							}
							if (methodCallExpression.Method == typeof(string).GetMethod("StartsWith", new Type[1] { typeof(string) }))
							{
								return "(" + ParseExpression(methodCallExpression.Object) + " LIKE '" + ParseExpression(methodCallExpression.Arguments[0]) + "%')";
							}
							if (methodCallExpression.Method == typeof(string).GetMethod("EndsWith", new Type[1] { typeof(string) }))
							{
								return "(" + ParseExpression(methodCallExpression.Object) + " LIKE '%" + ParseExpression(methodCallExpression.Arguments[0]) + "')";
							}
							if (methodCallExpression.Method.Name == "Contains")
							{
								Expression expression2;
								Expression expression3;
								if (methodCallExpression.Method.IsDefined(typeof(ExtensionAttribute)) && methodCallExpression.Arguments.Count == 2)
								{
									expression2 = methodCallExpression.Arguments[0];
									expression3 = methodCallExpression.Arguments[1];
								}
								else
								{
									if (methodCallExpression.Method.IsDefined(typeof(ExtensionAttribute)) || methodCallExpression.Arguments.Count != 1)
									{
										throw new Exception("Unsupported method call: " + methodCallExpression.Method.Name);
									}
									expression2 = methodCallExpression.Object;
									expression3 = methodCallExpression.Arguments[0];
								}
								expression2.ThrowWhenNull("collection");
								IEnumerable obj = (IEnumerable)GetValue(expression2);
								string text = "";
								foreach (object item in obj)
								{
									text = text + ValueToString(item, isUnary: false) + ", ";
								}
								if (text == "")
								{
									return ValueToString(false, isUnary: true);
								}
								return "(" + ParseExpression(expression3) + " IN (" + text.Substring(0, text.Length - 2) + "))";
							}
							throw new Exception("Unsupported method call: " + methodCallExpression.Method.Name);
						}
						throw new Exception("Unsupported expression: " + expression?.GetType().Name);
					}
					if (memberExpression.Member is PropertyInfo propertyInfo)
					{
						if (memberExpression.NodeType == ExpressionType.MemberAccess)
						{
							Expression? expression4 = memberExpression.Expression;
							if (expression4 != null && expression4.NodeType == ExpressionType.Parameter)
							{
								string text2 = ((table != null) ? table.GetColumnNameFor(propertyInfo.Name) : propertyInfo.Name);
								if (isUnary && memberExpression.Type == typeof(bool))
								{
									return "([" + text2 + "] = 1)";
								}
								return "[" + text2 + "]";
							}
							return FormatValueString(GetValue(memberExpression));
						}
						if (memberExpression.Expression is ConstantExpression constantExpression2)
						{
							return ValueToString(propertyInfo.GetValue(constantExpression2.Value, null), isUnary);
						}
					}
					if (memberExpression.Member is FieldInfo)
					{
						return ValueToString(GetValue(memberExpression), isUnary);
					}
					throw new Exception($"Expression does not refer to a property or field: {expression}");
				}
				return ValueToString(constantExpression.Value, isUnary);
			}
			string text3 = ParseExpression(binaryExpression.Right);
			return "(" + ParseExpression(binaryExpression.Left) + " " + NodeTypeToString(binaryExpression.NodeType, text3 == "NULL")?.ToString() + " " + text3 + ")";
		}
		string text4 = ParseExpression(unaryExpression.Operand, isUnary: true);
		if (unaryExpression.NodeType == ExpressionType.Convert)
		{
			return CastString(text4, unaryExpression.Type);
		}
		return "(" + NodeTypeToString(unaryExpression.NodeType, text4 == "NULL")?.ToString() + " " + text4 + ")";
	}

	public static string ToSqlDate(DateTime dateTime)
	{
		return "'" + dateTime.ToString("o", CultureInfo.InvariantCulture) + "'";
	}

	public static string ValueToString(object? value, bool isUnary)
	{
		if (value is bool flag)
		{
			if (isUnary)
			{
				if (!flag)
				{
					return "(1=0)";
				}
				return "(1=1)";
			}
			if (!flag)
			{
				return "0";
			}
			return "1";
		}
		return FormatValueString(value);
	}
}
